using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Library;
using XCode;
namespace UnitTest
{
    [TestClass]
    public class PubMedReaderTest
    {
        [TestMethod]
        public void ReadFileList()
        {
            List<string> filenames = new List<string>() { @"D:\项目文档\PubMed\文档\pubmed_result.txt" };
            PubMedReader reader = new PubMedReader();
            Tuple<EntityList<Title>, EntityList<MESH>> result = reader.Read(filenames);
            Assert.AreEqual(result.Item1.Count > 0, true);
        }
    }
}
