using ExcelDataReader;
namespace ExcelMultipleFileSearch
{
	internal static class Program
	{
		static Dictionary<string, IExcelDataReader> readers = new Dictionary<string, IExcelDataReader>(1000);

		/// <summary>
		///  The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
			// To customize application configuration such as set high DPI settings or default font,
			// see https://aka.ms/applicationconfiguration.
			System.Windows.Forms.Application.Run(new MainForm());

		}

		internal static List<SearchResult> Search(string keyword, List<string> checkedFileNames)
		{
			List<SearchResult> results = new List<SearchResult>(10000);

			foreach (string fileName in checkedFileNames)
			{
				IExcelDataReader reader = readers[fileName];
				string shortFileName = Path.GetFileName(fileName);

				reader.Reset();
				do
				{
					while (reader.Read())
					{
						for (int i = 0; i < reader.FieldCount; i++)
						{
							var value = reader.GetValue(i);
							if (value == null)
							{
								continue;
							}

							string str = value.ToString()!;
							if (str.Contains(keyword))
							{
								results.Add(new SearchResult(shortFileName, reader.Name, str));
							}
						}
					}
				} while (reader.NextResult());
			}


			return results;
		}

	}
}
