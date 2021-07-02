using System.IO;
using System.Collections.Generic;

namespace sortString
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePaht = args[0];
            int size = 0;

            string inFileName = "inFile.txt";
            string outFileName = "outFile.txt";

            using (FileStream inFile = new FileStream(inFileName, FileMode.Create))
            using (FileStream outFile = new FileStream(outFileName, FileMode.Create))
            using (StreamWriter sw = new StreamWriter(outFile))
            using (StreamReader sr = new StreamReader(filePaht))
            {
                string tempStr;

                while ((tempStr = sr.ReadLine()) != null)
                {
                    size++;
                    sw.WriteLine(tempStr);
                }
            }

            for (int i = 0; i < size - 1; i++)
            {
                File.Copy(outFileName, inFileName, true);
                mySort(inFileName);
            }
        }

        static void mySort(string nameFile)
        {
            string outFileName = "outFile.txt";
            string firstStr;
            string secondStr;

            using (FileStream outFile = new FileStream(outFileName, FileMode.Create))
            using (StreamWriter sw = new StreamWriter(outFile))
            { 
                using (StreamReader sr = new StreamReader(nameFile))
                {
                    firstStr = sr.ReadLine();

                    while ((secondStr = sr.ReadLine()) != null)
                    {
                        if (FirestIsAfteSecond(firstStr, secondStr))
                        {
                            sw.WriteLine(secondStr);
                        }
                        else 
                        {
                            sw.WriteLine(firstStr);
                            firstStr = secondStr;
                        }
                    }

                    sw.WriteLine(firstStr);
                }

            }
        }
        static bool FirestIsAfteSecond(string firest, string second) 
        {
            List<string> strs = new List<string>();
            strs.Add(firest);
            strs.Add(second);

            strs.Sort();

            return strs[1] == firest;
        }
    }
}
