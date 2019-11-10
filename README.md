# BibTeXLibrary

A utility library for BibTeX written in C#, adapted from [BERef/BibTeXLibrary](https://github.com/BERef/BibTeXLibrary). 

It contains changes from [AizazZaidee/BibTeXLibrary](https://github.com/AizazZaidee/BibTeXLibrary) which allow the parser to handle (read: ignore) comments.

The reader will sometimes choke on special characters, most notably in entry keys. It is neither fast nor memory efficient, but it works and it does not require any external libraries.

## Usage

### Parsing
The [`BibParser`](BibTeXLibrary/BibParser.cs) takes a `TextReader` and optionally a [`BibParserConfig`](BibTeXLibrary/BibParserConfig.cs).

```csharp
TextReader reader = ....; 
var parser = new BibParser(reader);
foreach (var item in parser.Parse()) {
  // Process
}
```

To read a `string`:
```csharp
var reader = new StringReader(...input...);
```

To read a file:
```csharp
var reader = new StreamReader(...filename...);
```

### Entries
The parser returns a collection of [`BibEntry`](BibTeXLibrary/BibEntry.cs). Entries have a `Key` (their unique index), and a  `Type` (e.g. "article", "book", etc). All other properties are available as `KeyValuePair<string, string>` through the indexer. Keys are converted to lower case.

```csharp
var item = new BibEntry();
item.Type = "article";
item.Key = "key";
item["title"] = "Example article";
item["author"] = "Doe, John";
```

### Writing
Entries can be written using the [`BibWriter`](BibTeXLibrary/BibWriter.cs). The writer takes a `TextWriter` as output, and optionally a [`BibWriterConfig`](BibTeXLibrary/BibWriterConfig.cs). item properties with `null` or empty value are not written to the output.

```csharp
IEnumerable<BibEntry> items = ...;
TextWriter writer = ....; 
var bibWriter = new BibWriter(writer);
bibWriter.Write(items);
```

To write to `string`:
```csharp
var builder = new StringBuilder();
var writer = new StringWriter(builder);
// ... Write to writer ...
var result = builder.ToString();
```

To write to file:
```csharp
var writer = new StreamWriter(file);
```

## License

The MIT License (MIT)  
Copyright (c) 2016 BERef

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
