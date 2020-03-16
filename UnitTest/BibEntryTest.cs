using BibTeXLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class BibEntryTest
    {
        [TestMethod]
        public void TestIndexer()
        {
            const string title = "Mapreduce";
            var entry = new BibEntry {["Title"] = title};

            Assert.AreEqual(title, entry["title"]);
            Assert.AreEqual(title, entry["Title"]);
            Assert.AreEqual(title, entry["TitlE"]);
        }
    }
}
