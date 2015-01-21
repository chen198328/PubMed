using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
namespace PubMedInput
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string taskname = txtTaskName.Text.Trim();

            lbl_taskmessageshow.Text = string.Format("系统生成表明：{0}_Title,{0}_Mesh", taskname);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();
            cbxFilenames.Items.Clear();
            for (int index = 0; index < openFileDialog.FileNames.Length; index++)
            {
                cbxFilenames.Items.Add(openFileDialog.FileNames[index]);
            }
        }

        private void btnGenerateTables_Click(object sender, EventArgs e)
        {
            string taskname = txtTaskName.Text.Trim();
            if (string.IsNullOrEmpty(taskname))
            {
                if (DialogResult.OK != MessageBox.Show("确定数据要保存在Title和Mesh表中吗？"))
                {
                    return;
                }
            }
            using (StreamReader reader = new StreamReader("GenerateTables.sql", Encoding.Default))
            {
                string sql = reader.ReadToEnd();
                if (ExcuteSql(sql))
                {
                    btnGenerateTables.Text = "已创建";
                    btnGenerateTables.Enabled = false;
                }
                else
                {
                    MessageBox.Show("创建失败，建议修改任务名称");
                }

            }
        }
        private bool ExcuteSql(string sql)
        {
            string connectionstring = System.Configuration.ConfigurationManager.ConnectionStrings["PubMed"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = sql;
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();

                    return true;
                }
                catch (SqlException ex)
                {
                    return false;
                }
                catch (TimeoutException ex)
                {
                    return false;
                }
                finally
                {
                    conn.Close();
                }
            }
        }
    }
}
