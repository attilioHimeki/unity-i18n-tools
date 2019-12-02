using System.Collections.Generic;
using System.Linq; 

public class CSVUtils
{

	public static Dictionary<string, string> parseLocalisationFile(string csvText)
	{
		string[] lines = csvText.Split("\n"[0]); 
		int numLines = lines.Length;

		var result = new Dictionary<string, string>(numLines);

		for (int i = 0; i < numLines; i++)
		{
			string[] row = SplitCsvLine(lines[i]); 
			if(row.Length > 1)
			{
				var key = row[0];
				var val = row[1];
				result[key] = val;
			}
		}

		return result;
	}
 
	static public string[] SplitCsvLine(string line)
	{
		return (from System.Text.RegularExpressions.Match m in System.Text.RegularExpressions.Regex.Matches(line,
		@"(((?<x>(?=[,\r\n]+))|""(?<x>([^""]|"""")+)""|(?<x>[^,\r\n]+)),?)", 
		System.Text.RegularExpressions.RegexOptions.ExplicitCapture)
		select m.Groups[1].Value).ToArray();
	}
}