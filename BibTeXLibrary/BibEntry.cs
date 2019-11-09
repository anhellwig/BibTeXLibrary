using System.Collections;
using System.Collections.Generic;

namespace BibTeXLibrary
{
    public class BibEntry : IEnumerable<KeyValuePair<string, string>>
    {
        /// <summary>
        /// Store all tags
        /// </summary>
        private readonly Dictionary<string, string> _tags = new Dictionary<string, string>();

        /// <summary>
        /// Entry's key
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Entry's type
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Get value by given tagname(index) or create new tag by index and value.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public string this[string index]
        {
            get
            {
                return _tags.TryGetValue(index.ToLowerInvariant(), out var value) ? value : string.Empty;
            }
            set
            {
                _tags[index.ToLowerInvariant()] = value;
            }
        }

        public IEnumerator<KeyValuePair<string, string>> GetEnumerator() => this._tags.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => this._tags.GetEnumerator();
    }
}
