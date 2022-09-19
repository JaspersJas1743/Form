using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WpfApp1.Utility
{
    class Document
    {
        public Document(string pathToFile)
        {
            PathToFile = pathToFile;
        }

        public string PathToFile { get; set; }

        public async Task<IEnumerable<string[]>> AsyncGetData()
        {
            using (StreamReader reader = new(PathToFile))
            {
                List<string[]> data = new();
                string? lines;
                while ((lines = await reader.ReadLineAsync()) != null)
                    data.Add(lines.Split());
                return data;
            }
        }

        public async Task AsyncWriteData(string data)
        {
            using (StreamWriter writer = new(PathToFile, true))
            {
                await writer.WriteLineAsync(data);
            }
        }
    }
}
