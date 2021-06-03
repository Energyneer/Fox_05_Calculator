using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    class FileIO
    {
        private string inputFilePath { get; set; }
        private string outputFileName { get; set; }
        private string outputFilePath { get; set; }
        private List<string> expression { get; set; }

        public FileIO(string inputFilePath, string outputFileName)
        {
            this.inputFilePath = inputFilePath;
            this.outputFileName = outputFileName;
            DirectoryInfo dinfo = new DirectoryInfo(inputFilePath);
            outputFilePath = dinfo.Parent.ToString() + Path.DirectorySeparatorChar + outputFileName;
            expression = new List<string>();
        }

        public static bool FileExist(string path)
        {
            return File.Exists(path);
        }

        public void Process()
        {
            ReadAllExpressions();
            WriteAllExpressions();
        }

        private void ReadAllExpressions()
        {
            using (StreamReader reader = new StreamReader(inputFilePath))
            {
                while (reader.Peek() >= 0)
                {
                    expression.Add(reader.ReadLine());
                }
            }
        }

        private void WriteAllExpressions()
        {
            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                foreach (string line in expression)
                {
                    writer.WriteLine(OutLine(line));
                }
            }
        }

        private string OutLine(string expression)
        {
            try
            {
                return expression + " = " + MathParser.ParseSimpleExp(expression);
            }
            catch
            {
                return expression + " = ошибка в выражении";
            }
        }

    }
}
