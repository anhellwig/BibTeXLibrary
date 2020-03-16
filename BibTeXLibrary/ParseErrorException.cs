using System;

namespace BibTeXLibrary
{
    /// <summary>The excpetion that is thrown when an error occured during parsing a bib file.</summary>
    public abstract class ParseErrorException : Exception
    {
        /// <summary>
        /// The line number.
        /// </summary>
        public readonly int LineNo;

        /// <summary>
        /// The column number.
        /// </summary>
        public readonly int ColNo;

        /// <summary>Initializes a new instance of the <see cref="ParseErrorException"/> class.</summary>
        /// <param name="lineNo">The line number.</param>
        /// <param name="colNo">The column number.</param>
        protected ParseErrorException(int lineNo, int colNo)
        {
            LineNo = lineNo;
            ColNo = colNo;
        }
    }
}
