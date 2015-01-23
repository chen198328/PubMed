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
using XCode;
using Library;
namespace PubMedInput
{
    public partial class Main : Form
    {
        System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
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
            //查找相应的表名是否存在
            string sql = string.Format("select count(*)  from sysobjects where id in (object_id('{0}_Title'),object_id('{0}_Mesh')) and type = 'u'", taskname);
            int count = (int)GetExcuteSql(sql);
            if (count > 1)
            {
                lbl_taskmessageshow.Text = string.Format("系统存在{0}_Title,{0}_Mesh", taskname);
                btnGenerateTables.Enabled = false;
            }
            else
            {
                lbl_taskmessageshow.Text = string.Format("系统不存在{0}_Title,{0}_Mesh,请生成", taskname);
                btnGenerateTables.Enabled = true;
            }
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
            Action<string> addmessage = (message) =>
            {
                AddMessage(message);
            };
            string taskname = txtTaskName.Text.Trim();
            if (string.IsNullOrEmpty(taskname))
            {
                if (DialogResult.OK != MessageBox.Show("确定数据要保存在Title和Mesh表中吗？"))
                {
                    return;
                }
            }
            Task task = new Task(() =>
            {
                using (StreamReader reader = new StreamReader("GenerateTables.sql", Encoding.Default))
                {
                    string sql = reader.ReadToEnd();
                    sql = string.Format(sql, taskname);
                    string error = ExcuteSql(sql);
                    if (string.IsNullOrEmpty(error))
                    {
                        this.BeginInvoke(addmessage, string.Format("[成功]创建表{0}_Title,{0}_Mesh", taskname));
                    }
                    else
                    {
                        MessageBox.Show("创建失败:" + error);
                        this.BeginInvoke(addmessage, string.Format("[失败]创建表{0}_Title,{0}_Mesh", taskname));
                    }

                }
            });
            task.Start();
        }
        private string ExcuteSql(string sql)
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

                    return null;
                }
                catch (SqlException ex)
                {
                    return ex.Message.ToString();
                }
                catch (TimeoutException ex)
                {
                    return ex.Message.ToString();
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        private void AddMessage(string message)
        {
            rbxLog.AppendText(string.Format("{0}:{1}\r\n", DateTime.Now, message));
            rbxLog.ScrollToCaret();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            cbxFilenames.Items.Clear();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            Action<string> addmessage = (message) =>
              {
                  AddMessage(message);
              };
            string taskname = txtTaskName.Text.Trim();
            if (cbxFilenames.Items.Count == 0)
            {
                MessageBox.Show("请选择要输入的源文件");
                return;
            }
            if (taskname.Length == 0)
            {
                if (DialogResult.OK != MessageBox.Show("确定要将数据导入到Title和Mesh表中？"))
                {
                    return;
                }
            }
            int titleid = 0;
            int meshid = 0;

            watch.Restart();

            Timer timer = new Timer();
            timer.Tick += timer_Tick;
            timer.Interval = 500;
            timer.Start();

            Task task = new Task(() =>
            {
                this.UseWaitCursor = true;
                object obj = GetExcuteSql(string.Format("select max(id) from [{0}_Title]", taskname));
                if (obj != null && obj.ToString().Length > 0)
                {
                    titleid = (int)obj;
                }

                obj = GetExcuteSql(string.Format("select max(id) from [{0}_Mesh]", taskname));
                if (obj != null && obj.ToString().Length > 0)
                {
                    meshid = (int)obj;
                }

                this.BeginInvoke(addmessage, "数据导入中");


                Library.PubMedReader reader = new Library.PubMedReader();
                Tuple<EntityList<Title>, EntityList<MESH>> result = reader.Read(openFileDialog.FileNames.ToList<string>());
                bool issuccess = BatchImportData(result.Item1, result.Item2, taskname);
                watch.Stop();
                timer.Stop();
                if (issuccess)
                {
                    MessageBox.Show("数据导入成功！");

                    string sql = string.Format("select count(*) from [{0}_Title] where id>{1}", taskname, titleid);
                    int titlecount = (int)GetExcuteSql(sql);
                    sql = string.Format("select count(*) from [{0}_Mesh] where id>{1}", taskname, meshid);
                    int meshcount = (int)GetExcuteSql(sql);
                    string message = string.Format("数据导入成功。总共导入：{0}_Title记录：{1}条，{0}_Mesh记录：{2}条", taskname, titlecount, meshcount);
                    this.BeginInvoke(addmessage, message);
                }
                else
                {
                    MessageBox.Show("数据导入失败");
                    string sql = string.Format("delete from [{0}_Title] where id>{1}", taskname, titleid);
                    ExcuteSql(sql);
                    sql = string.Format("delete from [{0}_Mesh] where id>{1}", taskname, meshid);
                    ExcuteSql(sql);
                }
            });
            task.Start();

            task.ContinueWith(t =>
            {
                if (t.Exception != null)
                {

                    MessageBox.Show("数据导入失败，请查看日志记录");
                    this.BeginInvoke(addmessage, t.Exception.Message.ToString());
                }
                this.UseWaitCursor = false;
            });

        }

        void timer_Tick(object sender, EventArgs e)
        {
            lblTimer.Text = "耗时:" + watch.Elapsed.TotalMilliseconds.ToString() + "毫秒";
        }
        private bool BatchImportData(EntityList<Title> titles, EntityList<MESH> meshs, string taskname)
        {
            string connectionstring = System.Configuration.ConfigurationManager.ConnectionStrings["PubMed"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                try
                {
                    conn.Open();
                    SqlBulkCopy copy = new SqlBulkCopy(conn);
                    copy.DestinationTableName = taskname + "_Title";
                    copy.ColumnMappings.Add("TI", "TI");
                    copy.ColumnMappings.Add("DP", "DP");
                    copy.ColumnMappings.Add("VI", "VI");
                    copy.ColumnMappings.Add("PG", "PG");
                    copy.ColumnMappings.Add("Guid", "Guid");
                    copy.ColumnMappings.Add("PMID", "PMID");
                    copy.WriteToServer(GetTitle(titles));

                    copy.DestinationTableName = taskname + "_Mesh";
                    copy.ColumnMappings.Clear();
                    copy.ColumnMappings.Add("TitleGuid", "TitleGuid");
                    copy.ColumnMappings.Add("PMID", "PMID");
                    copy.ColumnMappings.Add("MH", "MH");
                    copy.WriteToServer(GetMesh(meshs));

                    copy.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
        private DataTable GetTitle(EntityList<Title> titles)
        {
            DataTable table = new DataTable();
            table.Columns.Add(new DataColumn("TI", typeof(string)));
            table.Columns.Add(new DataColumn("DP", typeof(int)));
            table.Columns.Add(new DataColumn("VI", typeof(int)));
            table.Columns.Add(new DataColumn("PG", typeof(int)));
            table.Columns.Add(new DataColumn("PMID", typeof(int)));
            table.Columns.Add(new DataColumn("Guid", typeof(string)));

            for (int index = 0; index < titles.Count; index++)
            {
                DataRow dr = table.NewRow();
                dr["TI"] = titles[index].TI;
                dr["DP"] = titles[index].DP;
                dr["VI"] = titles[index].VI;
                dr["PG"] = titles[index].PG;
                dr["PMID"] = titles[index].PMID;
                dr["Guid"] = titles[index].Guid;
                table.Rows.Add(dr);
            }
            return table;
        }
        private DataTable GetMesh(EntityList<MESH> meshs)
        {
            DataTable table = new DataTable();
            table.Columns.Add(new DataColumn("TitleGuid", typeof(string)));
            table.Columns.Add(new DataColumn("PMID", typeof(int)));
            table.Columns.Add(new DataColumn("MH", typeof(string)));

            for (int index = 0; index < meshs.Count; index++)
            {
                DataRow dr = table.NewRow();
                dr["TitleGuid"] = meshs[index].TitleGuid;
                dr["PMID"] = meshs[index].PMID;
                dr["MH"] = meshs[index].MH;
                table.Rows.Add(dr);
            }
            return table;
        }
        private object GetExcuteSql(string sql)
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
                    return cmd.ExecuteScalar();
                }
                catch (SqlException ex)
                {
                    return 0;
                }
                catch (TimeoutException ex)
                {
                    return 0;
                }
                finally
                {
                    conn.Close();
                }
            }
        }
    }
}
