using System;
using System.Text.RegularExpressions;
using System.Text;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace Lab2ver2
{
    internal class bai2
    {

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            Tracuu();
        }
        //ham tu dien
        static void Tracuu()
        {
            string[] FileContents = File.ReadAllLines("vnedict.txt");
            Dictionary<string, string> dict = new Dictionary<string, string>();
            foreach (string line in FileContents)
            {
                var keyvalue = Regex.Match(line, @"(.*):(.*)");
                dict.Add(keyvalue.Groups[1].Value.Trim(), keyvalue.Groups[2].Value.Trim());
            }

            string keyinput = "";
            string keyitem = dict[keyinput];
            while (true)
            {
                Console.WriteLine("Hãy nhập từ cần tra: ");
                keyinput = Console.ReadLine();
                if (dict.ContainsKey(keyinput))
                {
                    Console.WriteLine(dict[keyinput]);
                }
                else
                {
                    Console.WriteLine("Không có từ này trong từ điển");
                }
            }
        }
    }
}
