using System;

namespace BibTeXLibrary
{
    /// <summary>Configuration for <see cref="BibWriter"/>.</summary>
    public class BibWriterConfig
    {
        /// <summary>Gets or sets a value indicating whether the field values should be aligned.</summary>
        /// <value>
        ///   <c>true</c> if the field values are aligned; otherwise, <c>false</c>.</value>
        public bool Align { get; set; } = false;

        /// <summary>Gets or sets the indentation of the fields.</summary>
        /// <value>The indentation of the fields.</value>
        public string Indent { get; set; } = "    ";

        /// <summary>The new line string.</summary>
        /// <value>The new line string.</value>
        public string NewLine { get; set; } = Environment.NewLine;

        /// <summary>Determined whether to insert an empty line between bib entries.</summary>
        /// <value>
        ///   <c>true</c> if empty lines are inserted; otherwise, <c>false</c>.</value>
        public bool NewLineBetweenItems { get; set; } = true;
    }
}
