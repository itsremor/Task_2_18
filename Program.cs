using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Task_2_18
{
    internal static class Program
    {
        private static void Main()
        {
            const string baseDir = "D:/CS/Tasks/Task_2_18/";
            Wrap(
                3,
                baseDir + "file.txt",
                baseDir + "res.txt",
                true
            );
        }

        private static void Wrap(
            int n, string inputFilePath, string outputFilePath, bool rightAlign = false
        )
        {
            var text = Regex.Replace(
                File.ReadAllText(inputFilePath), " +", " "
            ).Replace("\r\n", "\n");
            var lines = new List<string>();
            foreach (var line in text.Split("\n"))
            {
                if (line.Equals(""))
                {
                    lines.Add("");
                    continue;
                }

                var newLines = new List<string>();
                while (line.Length > (newLines.Count + 1) * n)
                {
                    newLines.Add(
                        line.Substring(
                            newLines.Count * n, n
                        )
                    );
                }

                var remains = line[(newLines.Count * n)..];
                if (!remains.Equals(""))
                {
                    newLines.Add(remains);
                }

                foreach (var newLine in newLines)
                {
                    var resLine = newLine.Trim();
                    if (rightAlign)
                    {
                        lines.Add(
                            string.Concat(
                                Enumerable.Repeat(" ", n - newLine.Length)
                            ) + resLine
                        );
                    }
                    else
                    {
                        lines.Add(resLine);
                    }
                }
            }

            File.WriteAllText(outputFilePath, string.Join("\r\n", lines));
        }
    }
}
