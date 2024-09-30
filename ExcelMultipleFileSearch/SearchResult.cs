using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelMultipleFileSearch
{
	internal class SearchResult
	{
		public string File { get; set; }
		public string Sheet { get; set; }
		public string Content { get; set; }

		public SearchResult(string file, string sheet, string content)
		{
			File = file;
			Sheet = sheet;
			Content = content;
		}
	}
}
