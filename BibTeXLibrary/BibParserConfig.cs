namespace BibTeXLibrary
{
    /// <summary>Configuration for the <see cref="BibParser"/></summary>
    public class BibParserConfig
    {
        /// <summary>Gets or sets the possible characters for declaring the beginning of a comment.</summary>
        /// <value>The possible characters for declaring the beginning of a comment.</value>
        public char[] BeginCommentCharacters { get; set; } = { '%' };
    }
}
