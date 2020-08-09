using System;
using System.Collections.Generic;
using System.IO;

namespace DrivingHistory
{
    public class FileAccess
    {
        public List<string> ReadFile(string filePath)
        {
            List<string> lines = new List<string>();

            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    while (!sr.EndOfStream)
                    {
                        lines.Add(sr.ReadLine());             
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("Error reading the file");
                Console.WriteLine(e.Message);
            }
     
            return lines;
        }
    }
}
