﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace BibTeXLibrary
{
    public class BibEntry : IReadOnlyCollection<KeyValuePair<string, string>>
    {
        private readonly Dictionary<string, string> tags = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);

        public string Key { get; set; }

        public string Type { get; set; }

        public int Count => tags.Count;

        /// <summary>
        /// Get value by given tagname(index) or create new tag by index and value.
        /// </summary>
        /// <param name="index"></param>
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

        public bool ContainsKey(string key) => this.tags.ContainsKey(key);

        public IEnumerator<KeyValuePair<string, string>> GetEnumerator() => this.tags.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => this.tags.GetEnumerator();
    }
}
