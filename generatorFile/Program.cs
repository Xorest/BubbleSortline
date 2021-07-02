using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;


namespace generatorFile
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] str = Directory.GetFiles(Directory.GetCurrentDirectory(), "test*.txt");
            List<string> list= str.ToList();
            int lastNum = list.Any() ? Convert.ToInt32(Path.GetFileNameWithoutExtension(list[list.Count - 1]).Split('_')[1]) : 0;
            Random rand = new Random();

            using (FileStream fs = File.Create(Directory.GetCurrentDirectory() + $"/test_{++lastNum}.txt"))
            {
                for (int i = 0; i < Convert.ToInt32(args[0]); i++)
                {
                    fs.Write(Encoding.ASCII.GetBytes(generatorLine(rand.Next(1, Convert.ToInt32(args[1])))));
                    fs.Write(Encoding.ASCII.GetBytes("\n"));
                }
            }

            Console.WriteLine("End Generation");
            Console.ReadLine();
        }

        static string generatorLine(int sizeLine) 
        {
            string result = "";
            Random rand = new Random();

            for (int i = 0; i < sizeLine; i++)
            {
                result += (char)rand.Next(0x0061, 0x007a);
            }

            return result;
        }
    }
}
