using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication3
{    
    public class FileIO : IFileIO
    {
        string Separator { get; set; } = ";";


        public List<HostUri> ReadListAddress(string filePath)
        {
            List<HostUri> result = new List<HostUri>();

            using (StreamReader reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] values = line.Split(new string[] { Separator }, StringSplitOptions.RemoveEmptyEntries);
                    result.Add(new HostUri() {
                        Host = values[0],
                        Uri = values[1]
                    });
                }
            }

            return result;
        }

        public void WriteListAddress(string filePath, HostUri[] adresses)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (HostUri address in adresses)
                {
                    string line = address.Host + Separator + address.Uri;
                    writer.WriteLine(line);
                }
            }            
        }
    }
}
