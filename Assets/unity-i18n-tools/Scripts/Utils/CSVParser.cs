using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Himeki.i18n
{
    public class CSVParser
    {

        public static Dictionary<string, string> parseLocalisationFile(string csvText)
        {
            var csvTable = parseCSVFile(csvText);
            int numLines = csvTable.Count;

            var result = new Dictionary<string, string>(numLines);

            for (int i = 0; i < numLines; i++)
            {
                string[] row = csvTable[i];
                if (row.Length > 1)
                {
                    var key = row[0];
                    var val = row[1];
                    result[key] = val;
                }
            }

            return result;
        }

        public static List<string[]> parseCSVFile(string csvText)
        {
            string[] lines = csvText.Split('\n');
            int numLines = lines.Length;

            var result = new List<string[]>(numLines);

            for (int i = 0; i < numLines; i++)
            {
                string[] row = splitCsvLine(lines[i]);
                result.Add(row);
            }

            return result;
        }

        private static string[] splitCsvLine(string line)
        {
            return (from Match m in Regex.Matches(line,
            @"(((?<x>(?=[,\r\n]+))|""(?<x>([^""]|"""")+)""|(?<x>[^,\r\n]+)),?)",
            RegexOptions.ExplicitCapture)
                    select m.Groups[1].Value).ToArray();
        }
    }
}