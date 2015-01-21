using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCode;
using System.IO;
namespace Library
{
  public  class PubMedReader
    {
        private Tuple<EntityList<Title>, EntityList<MESH>> Read(string filename)
        {
            using (StreamReader reader = new StreamReader(filename, Encoding.Default))
            {
                string line = string.Empty;
                Title title = null;
                EntityList<Title> titles = new EntityList<Title>();
                EntityList<MESH> meshs = new EntityList<MESH>();
                while ((line = reader.ReadLine()) != null)
                {
                    Tuple<string, string> item = SplitLine(line);
                    switch (item.Item1)
                    {
                        case "PMID":
                            if (title != null)
                            {
                                titles.Add(title);
                            }
                            title = new Title();
                            title.Guid = Guid.NewGuid().ToString();
                            title.PMID = int.Parse(item.Item2);
                            break;
                        case "TI":
                            title.TI = item.Item2;
                            break;
                        case "DP":
                            title.DP = int.Parse(item.Item2);
                            break;
                        case "VI":
                            title.VI = int.Parse(item.Item2);
                            break;
                        case "PG":
                            title.PG = int.Parse(item.Item2);
                            break;
                        case "MH":
                            MESH mesh = new MESH();
                            mesh.PMID = title.PMID;
                            mesh.TitleGuid = title.Guid;
                            mesh.MH = item.Item2;
                            meshs.Add(mesh);
                            break;
                        default:
                            break;
                    }
                }
                titles.Add(title);
                return new Tuple<EntityList<Title>, EntityList<MESH>>(titles, meshs);
            }
        }

        /// <summary>
        /// 文件格式规范化
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        private string ConvertFomart(string filename)
        {
            using (StreamReader reader = new StreamReader(filename, Encoding.Default))
            {
                string _filename = filename + "_";
                StreamWriter writer = new StreamWriter(_filename, false, Encoding.Default);
                string line = string.Empty;

                while ((line = reader.ReadLine()) != null)
                {
                    if (line.Trim().Length == 0)
                    {
                        continue;
                    }
                    else
                    {
                        if(string.IsNullOrEmpty(line.Substring(1).Trim())){
                            writer.Write(" "+line.Trim());
                        }else{
                            writer.WriteLine(line.Trim());
                        }
                    }
                }
                writer.Flush();
                writer.Close();
                return _filename;
            }
        }
        private Tuple<string, string> SplitLine(string line)
        {
            if (line.IndexOf('-') == 4)
            {
                return new Tuple<string, string>(line.Substring(0, 4).Trim(), line.Substring(5).Trim());
            }
            else
            {
                return new Tuple<string, string>(null, line.Trim());
            }
        }

        public Tuple<EntityList<Title>, EntityList<MESH>> Read(List<string> filenames)
        {
            if (filenames == null)
            {
                throw new Exception("filenames is null");
            }
            EntityList<Title> titles = new EntityList<Title>();
            EntityList<MESH> meshs = new EntityList<MESH>();
            for (int index = 0; index < filenames.Count; index++)
            {
                string filename = ConvertFomart(filenames[index]);
                Tuple<EntityList<Title>, EntityList<MESH>> result = Read(filename);
                titles.AddRange(result.Item1);
                meshs.AddRange(result.Item2);
                File.Delete(filename);
            }
            return new Tuple<EntityList<Title>, EntityList<MESH>>(titles, meshs);
        }
    }
}
