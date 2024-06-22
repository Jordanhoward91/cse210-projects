using System;

public class Entry
{
	public string Prompt { get; private set; }
	public string Response { get; private set; }
	public string Date { get; private set; }

	public Entry(string prompt, string response, string date)
	{
		Prompt = prompt;
		Response = response;
		Date = date;
	}

	public override string ToString()
	{
		return $"Date: {Date}\nPrompt: {Prompt}\nResponse: {Response}\n";
	}

	public string ToCsv()
	{
		return $"{EscapeForCsv(Date)},{EscapeForCsv(Prompt)},{EscapeForCsv(Response)}";
	}

	public static Entry FromCsv(string csvLine)
	{
		string[] parts = SplitCsvLine(csvLine);
		return new Entry(parts[1], parts[2], parts[0]);
	}

	private string EscapeForCsv(string field)
	{
		if (field.Contains(",") || field.Contains("\""))
		{
			field = field.Replace("\"", "\"\"");
			field = $"\"{field}\"";
		}
		return field;
	}

	private static string[] SplitCsvLine(string line)
	{
		List<string> fields = new List<string>();
		bool inQuotes = false;
		string currentField = "";
		foreach (char c in line)
		{
			if (c == '"' && !inQuotes)
			{
				inQuotes = true;
			}
			else if (c == '"' && inQuotes)
			{
				inQuotes = false;
			}
			else if (c == ',' && !inQuotes)
			{
				fields.Add(currentField);
				currentField = "";
			}
			else
			{
				currentField += c;
			}
		}
		fields.Add(currentField);
		return fields.ToArray();
	}
}
