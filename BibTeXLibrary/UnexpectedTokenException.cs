using System;
using System.Text;

namespace BibTeXLibrary
{
    /// <summary>The exception that is thrown when an unexpected token is encountered.</summary>
    /// <seealso cref="BibTeXLibrary.ParseErrorException" />
    [Serializable]
    public sealed class UnexpectedTokenException : ParseErrorException
    {
        /// <summary>
        /// The error message.
        /// </summary>
        public override string Message { get; }

        /// <summary>Initializes a new instance of the <see cref="UnexpectedTokenException"/> class.</summary>
        /// <param name="lineNo">The line number.</param>
        /// <param name="colNo">The column number.</param>
        /// <param name="unexpected">The unexpected token type.</param>
        /// <param name="expected">The expected token type.</param>
        public UnexpectedTokenException(int lineNo, int colNo, TokenType unexpected, params TokenType[] expected)
            : base(lineNo, colNo)
        {
            var errorMsg = new StringBuilder(
                $"Line {lineNo}, Col {colNo}. Unexpected token: {unexpected}. ");
            errorMsg.Append("Expected: ");
            foreach (var item in expected)
            {
                errorMsg.Append($"{item}, ");
            }
            errorMsg.Remove(errorMsg.Length - 2, 2);
            Message = errorMsg.ToString();
        }
    }
}
