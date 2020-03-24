using System;
using System.Text.RegularExpressions;

namespace APBD_cw2
{
    class Program
    {

        static void Main(string[] args)
        {
            string CSVPath = "data/dane.csv";
            string outputPath = "data/result.xml";
            string dataType = "xml";

            if (args.Length == 3)
            {
                CSVPath = args[0];
                outputPath = args[1];
                dataType = args[2];

            }
            else if (args.Length < 3)
            {
                Regex firstArg = new Regex("[\\w\\/]*\\.csv");
                Regex secondArg = new Regex("[\\w\\/]*\\.\\w*");
                Regex thirdArg = new Regex("^[^\\/]$");

                foreach (var arg in args)
                {
                    if (firstArg.Matches(arg).Count > 0)
                    {
                        CSVPath = arg;
                        break;
                    }
                }
                foreach (var arg in args)
                {
                    if (secondArg.Matches(arg).Count > 0)
                    {
                        outputPath = arg;
                        break;
                    }
                }
                foreach (var arg in args)
                {
                    if (thirdArg.Matches(arg).Count > 0)
                    {
                        dataType = arg;
                        break;
                    }
                }
            }

            Console.Write($"input: {CSVPath} output: {outputPath} type: {dataType}");

        }

        public static void WriteToLog(string msg)
        {

        }
    }
}
