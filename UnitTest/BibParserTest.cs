using BibTeXLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Linq;
using System.Text;

namespace UnitTest
{
    [TestClass]
    public class BibParserTest
    {
        [TestMethod]
        public void TestParserRegularBibEntry()
        {
            var parser = new BibParser(
                new StringReader("@article{keyword, title = {\"0\"{123}456{789}}, year = 2012, address=\"PingLeYuan\"}"));
            var entry = parser.Parse().First();

            Assert.AreEqual("article"           , entry.Type.ToLowerInvariant());
            Assert.AreEqual("\"0\"{123}456{789}", entry["Title"]);
            Assert.AreEqual("2012"              , entry["Year"]);
            Assert.AreEqual("PingLeYuan"        , entry["Address"]);
        }

        [TestMethod]
        public void TestParserString()
        {
            var parser = new BibParser(
                new StringReader("@article{keyword, title = \"hello \\\"world\\\"\", address=\"Ping\" # \"Le\" # \"Yuan\",}"));
            var entry = parser.Parse().First();

            Assert.AreEqual("article"            , entry.Type.ToLowerInvariant());
            Assert.AreEqual("hello \\\"world\\\"", entry["Title"]);
            Assert.AreEqual("PingLeYuan"         , entry["Address"]);
        }

        [TestMethod]
        public void TestParserWithoutKey()
        {
            var parser = new BibParser(new StringReader("@book{, title = {}}"));
            var entry = parser.Parse().First();

            Assert.AreEqual("book", entry.Type.ToLowerInvariant());
            Assert.AreEqual(""    , entry["Title"]);
        }

        [TestMethod]
        public void TestParserWithoutKeyAndTags()
        {
            var parser = new BibParser(new StringReader("@book{}"));
            var entry = parser.Parse().First();

            Assert.AreEqual("book", entry.Type.ToLowerInvariant());
        }

        [TestMethod]
        [ExpectedException(typeof(UnexpectedTokenException))]
        public void TestParserWithBrokenBibEntry()
        {
            var parser = new BibParser(new StringReader("@book{,"));
            var entries = parser.Parse().ToList();
        }

        [TestMethod]
        [ExpectedException(typeof(UnexpectedTokenException))]
        public void TestParserWithIncompletedTag()
        {
            var parser = new BibParser(new StringReader("@book{,title=,}"));
            var entries = parser.Parse().ToList();
        }

        [TestMethod]
        [ExpectedException(typeof(UnexpectedTokenException))]
        public void TestParserWithBrokenTag()
        {
            var parser = new BibParser(new StringReader("@book{,titl"));
            var entries = parser.Parse().ToList();
        }

        [TestMethod]
        [ExpectedException(typeof(UnexpectedTokenException))]
        public void TestParserWithBrokenNumber()
        {
            var parser = new BibParser(new StringReader("@book{,title = 2014"));
            var entries = parser.Parse().ToList();
        }

        [TestMethod]
        [ExpectedException(typeof(UnrecognizableCharacterException))]
        public void TestParserWithUnexpectedCharacter()
        {
            var parser = new BibParser(new StringReader("@book{,ti?le = {Hadoop}}"));
            var entries = parser.Parse().ToList();
        }

        [TestMethod]
        public void TestParserWithBibFile()
        {
            var parser = new BibParser(new StreamReader("TestData/BibParserTest1_In.bib", Encoding.Default));
            var entries = parser.Parse().ToList();

            Assert.AreEqual(3                                                    , entries.Count);
            Assert.AreEqual("nobody"                                             , entries[0]["Publisher"]);
            Assert.AreEqual("Apache hadoop yarn: Yet another resource negotiator", entries[1]["Title"]);
            Assert.AreEqual("KalavriShang-797"                                   , entries[2].Key);
        }
    }
}
