using System;

namespace BibTeXLibrary
{
    public class BibWriterConfig
    {
        public bool Align { get; set; } = false;

        public string Indent { get; set; } = "    ";

        public string NewLine { get; set; } = Environment.NewLine;

        public bool NewLineBetweenItems { get; set; } = true;
    }
}