using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace WebApplicationRockPaperScissor
{
    public class FileManager
    {
        public string readFile(string dir) {
            string line;
            string result ="";
            string[] aux2;
            // Read the file and display it line by line.
            System.IO.StreamReader file =
               new System.IO.StreamReader(dir);
            while ((line = file.ReadLine()) != null)
            {
                result = result + line;
            }
            file.Close();
            return result;
        }

        public void writeWinners(string winnerName) {
            string dir = "C:\\Users\\Andy\\Desktop\\Winners.txt";
            int count = 0;
            string line;
            string[] temp;
            string[] aux;
            string[] aux2;
            if (!File.Exists(dir)) {
                TextWriter tw = new StreamWriter(dir);
                tw.WriteLine(winnerName + " "+"3");
                tw.Close();
                return;
            }
            TextReader tr = new StreamReader(dir);
            while (tr.ReadLine() != null)
            {
                count++;
            }
            temp = new string[count];
            count = 0;
            tr.Close();
            TextReader tr2 = new StreamReader(dir);
            while ((line=tr2.ReadLine()) != null)
            {
                temp[count] = line;
                count++;
            }
            tr2.Close();
            aux2 = (Regex.Replace(winnerName, @"[^0-9a-zA-Z]+", " ")).Split(' ');
            TextWriter tw2 = new StreamWriter(dir);
            for (int i=0; i < count; i++)
            {
                aux = (Regex.Replace(temp[i], @"[^0-9a-zA-Z]+", " ")).Split(' ');
                
                if (aux[1]==aux2[1]) {
                    tw2.WriteLine("[" + "\"" + aux[1] + "\"" + ", " + "\"" + aux[2] + "\"" + "]" + " "+ ((Int32.Parse(aux[3])) +3).ToString());
                }
                else {
                    tw2.WriteLine("[" + "\"" + aux2[1] + "\"" + ", " + "\"" + aux2[2] + "\"" + "]" + " " + "3");
                }
            }
            tw2.Close();
        }
    }
}