using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace APBD_cw2
{
    class Program
    {

        static void Main(string[] args)
        {
            string CSVPath = "C:\\Users\\kubas\\OneDrive - Polsko-Japońska Wyższa Szkoła Technik Komputerowych\\Dokumenty\\APBD\\APBD-cw2\\APBD-cw2\\APBD-cw2\\APBD-cw2\\data\\dane.csv";
            string outputPath = "data\\result.xml";
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

            List<Student> students = new List<Student>();
            try
            {
                using (var reader = new StreamReader(CSVPath))
                {
                    
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(',');

                        if (values.Length != 9) continue;

                        Student tmp = new Student()
                        {
                            fname = values[0],
                            lname = values[1],
                            studiesName = values[2],
                            studiesMode = values[3],
                            indexNumber = Int32.Parse(values[4]),
                            birthdate = values[5],
                            email = values[6],
                            mothersName = values[7],
                            fathersName = values[8]

                        };

                        students.Add(tmp);
                    }
                }
            }
            catch (IOException exc)
            {
                WriteToLog("podana sciezka jest niepoprawna");
            }

            FileStream writer = new FileStream(@"data.xml", FileMode.Create);
            XmlSerializer serializer = new XmlSerializer(typeof(List<Student>), new XmlRootAttribute("uczelnia"));
            
            serializer.Serialize(writer, students);
        }



        public static void WriteToLog(string msg)
        {

        }
    }
}
