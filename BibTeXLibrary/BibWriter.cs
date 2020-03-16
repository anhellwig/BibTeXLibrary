using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BibTeXLibrary
{
    public class BibWriter
    {
        private readonly BibWriterConfig config;
        private readonly TextWriter stream;
        private bool isFirstItem = true;

        public BibWriter(TextWriter stream) : this(stream, new BibWriterConfig())
        {
        }

        public BibWriter(TextWriter stream, BibWriterConfig config)
        {
            this.stream = stream ?? throw new ArgumentNullException(nameof(stream));
            this.config = config ?? throw new ArgumentNullException(nameof(config));
        }

        public void Write(IEnumerable<BibEntry> items)
        {
            foreach (var item in items)
            {
                if (!this.isFirstItem && this.config.NewLineBetweenItems)
                {
                    this.stream.Write(this.config.NewLine);
                }

                this.WriteEntryToStream(item, this.stream);
                this.stream.Write(this.config.NewLine);
                this.isFirstItem = false;
            }
        }

        public void Write(params BibEntry[] items)
        {
            this.Write((IEnumerable<BibEntry>)items);
        }

        private void WriteEntryToStream(BibEntry value, TextWriter stream)
        {
            stream.Write("@");
            stream.Write(value.Type);
            stream.Write('{');
            stream.Write(value.Key);

            int count = value.Count;
            if (count > 0)
            {
                stream.Write(",");
                stream.Write(this.config.NewLine);

                var pad = 0;
                if (this.config.Align)
                {
                    pad = value.Max(v => v.Key.Length);
                }

                int i = 0;
                foreach (var tag in value)
                {
                    i++;
                    if (!string.IsNullOrWhiteSpace(tag.Key) && !string.IsNullOrWhiteSpace(tag.Value))
                    {
                        stream.Write(this.config.Indent);
                        stream.Write(tag.Key.PadRight(pad));
                        stream.Write(" = {");
                        stream.Write(tag.Value);
                        stream.Write("}");
                        if (i < count) stream.Write(",");
                        stream.Write(this.config.NewLine);
                    }
                }
            }

            stream.Write("}");
            stream.Flush();
        }
    }
}
