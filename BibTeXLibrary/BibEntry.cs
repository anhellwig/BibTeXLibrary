using System;
using System.Collections;
using System.Collections.Generic;

namespace BibTeXLibrary
{
    /// <summary>Represents an entry in a bib file.</summary>
    public class BibEntry : IReadOnlyCollection<KeyValuePair<string, string>>
    {
        private readonly Dictionary<string, string> tags = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);

        /// <summary>
        /// Gets or sets the key of the bib entry.
        /// </summary>
        /// <value>
        /// The key.
        /// </value>
        public string Key { get; set; }

        /// <summary>
        /// Gets or sets the type of the bib entry.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        public string Type { get; set; }

        /// <summary>
        /// Gets the number of fields.
        /// </summary>
        public int Count => tags.Count;

        /// <summary>
        /// Get value by given field name (index) or create new field by index and value.
        /// </summary>
        /// <param name="index">The name of a field.</param>
        /// <returns>The value if the key exists, otherwise `null`.</returns>
        public string this[string index]
        {
            get
            {
                return this.tags.TryGetValue(index.ToLowerInvariant(), out var value) ? value : null;
            }
            set
            {
                if (value == null)
                {
                    if (this.ContainsKey(index))
                    {
                        this.tags.Remove(index);
                    }
                }
                else
                {
                    this.tags[index.ToLowerInvariant()] = value;
                }
            }
        }

        /// <summary>
        /// Determines whether the specified field is defined.
        /// </summary>
        /// <param name="fieldName">The key.</param>
        /// <returns>
        ///   <c>true</c> if the specified field is defined; otherwise, <c>false</c>.
        /// </returns>
        public bool ContainsKey(string fieldName) => tags.ContainsKey(fieldName);

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// An enumerator that can be used to iterate through the collection.
        /// </returns>
        public IEnumerator<KeyValuePair<string, string>> GetEnumerator() => tags.GetEnumerator();

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerator" /> object that can be used to iterate through the collection.
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator() => tags.GetEnumerator();
    }
}
