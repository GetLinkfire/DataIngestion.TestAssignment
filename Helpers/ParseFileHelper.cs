using DataIngestion.TestAssignment.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DataIngestion.TestAssignment.Helpers
{
    public class ParseFileHelper
    {
        private List<LinkFireCollection> _collection;
        public ParseFileHelper()
        {
            _collection = new List<LinkFireCollection>();
        }
        public IEnumerable<LinkFireCollection> ParseFile()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "fileCollection");

            using var reader = new StreamReader(path, new UTF8Encoding(true));
            string line = reader.ReadLine();

            while (line != null)
            {
                line = reader.ReadLine();
                var array = line.Split("\u0001");

                try
                {
                    if (!line.StartsWith("#"))
                    {
                        var album = new LinkFireCollection()
                        {
                            Id = (1 < array.Length) ? array[1] : string.Empty,
                            Name = (2  < array.Length) ? array[2] : string.Empty,
                            ImageUrl = (8 < array.Length) ? array[8] : string.Empty,
                            Url = (7 < array.Length) ? array[7] : string.Empty
                        };
                        _collection.Add(album);
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
                
            }

            if (File.Exists(path))
                File.Delete(path);

            return _collection;
        }
    }
}
