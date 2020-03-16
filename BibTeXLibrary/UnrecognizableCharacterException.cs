namespace BibTeXLibrary
{
    /// <summary>The exception that is thrown when an unrecognizable character is encountered.</summary>
    /// <seealso cref="BibTeXLibrary.ParseErrorException" />
    public class UnrecognizableCharacterException : ParseErrorException
    {
        #region Public Property
        /// <summary>
        /// The error message.
        /// </summary>
        public override string Message { get; }
        #endregion

        #region Constructor
        /// <summary>Initializes a new instance of the <see cref="UnrecognizableCharacterException"/> class.</summary>
        /// <param name="lineNo">The line number.</param>
        /// <param name="colNo">The column number.</param>
        /// <param name="unexpected">The unrecognizable charcter.</param>
        public UnrecognizableCharacterException(int lineNo, int colNo, char unexpected)
            : base(lineNo, colNo)
        {
            Message = $"Line {lineNo}, Col {colNo}. Unrecognizable character: '{unexpected}'.";
        }
        #endregion
    }
}
