using ExcelDataReader;
using Microsoft.VisualBasic.Devices;
using System.Runtime.InteropServices;

namespace ExcelMultipleFileSearch
{
	public partial class MainForm : Form
	{
		static SortedDictionary<string, IExcelDataReader> readers = new SortedDictionary<string, IExcelDataReader>();
		static SortedDictionary<string, string> shortNameToLongName = new SortedDictionary<string, string>();

		public MainForm()
		{
			InitializeComponent();
			radioBtn_OR.Select();
			checkListBox_files.Sorted = true;
		}

		private void btn_addFile_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
			openFileDialog.Multiselect = true;

			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				foreach (string fileName in openFileDialog.FileNames)
				{
					loadFile(fileName);
				}
			}
		}

		private void btn_Search_Click(object sender, EventArgs e)
		{
			if (txtBox_searchKeyword.Text.Length == 0)
			{
				MessageBox.Show("예시: 체육 -체육관 \n'체육'이 들어간 셀을 검색하되, '체육관'이 들어간 셀은 제외합니다.");
				return;
			}

			dgv_SearchResults.Rows.Clear();

			List<SearchResult> results = new List<SearchResult>(10000);

			List<string> checkedFiles = GetCheckedFiles();

			string[] words = txtBox_searchKeyword.Text.Split(' ');

			List<string> checkWords = new List<string>(words.Length);
			List<string> exceptWords = new List<string>(words.Length);
			foreach (string word in words)
			{
				if (word.StartsWith("-"))
				{
					exceptWords.Add(word.Substring(1));
				}
				else
				{
					checkWords.Add(word);
				}
			}

			foreach (string fileName in checkedFiles)
			{
				IExcelDataReader reader = readers[fileName];
				string shortFileName = Path.GetFileName(fileName);

				if (!shortNameToLongName.ContainsKey(shortFileName))
				{
					shortNameToLongName.Add(shortFileName, fileName);
				}

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

							int cntContains = 0;

							for (int w = 0; w < checkWords.Count; w++)
							{
								if (str.Contains(checkWords[w]))
								{
									cntContains++;
								}
							}

							if (radioBtn_AND.Checked && cntContains == checkWords.Count)
							{
								for (int ex = 0; ex < exceptWords.Count; ex++)
								{
									if (str.Contains(exceptWords[ex]))
									{
										goto LB_READ_NEXT;
									}
								}

								results.Add(new SearchResult(shortFileName, reader.Name, str));
							}
							else if (radioBtn_OR.Checked && cntContains >= 1)
							{
								for (int ex = 0; ex < exceptWords.Count; ex++)
								{
									if (str.Contains(exceptWords[ex]))
									{
										goto LB_READ_NEXT;
									}
								}

								results.Add(new SearchResult(shortFileName, reader.Name, str));
							}
						}

					LB_READ_NEXT:;
					}
				} while (reader.NextResult());
			}

			foreach (SearchResult result in results)
			{
				dgv_SearchResults.Rows.Add(result.File, result.Sheet, result.Content);
			}
		}

		// return checked file names
		internal List<string> GetCheckedFiles()
		{
			List<string> checkedFiles = new List<string>(checkListBox_files.CheckedItems.Count);

			foreach (string fileName in checkListBox_files.CheckedItems)
			{
				checkedFiles.Add(fileName);
			}

			return checkedFiles;
		}

		[DllImport("Shell32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		static extern IntPtr ShellExecute(IntPtr hwnd, string lpOperation, string lpFile, string lpParameters, string lpDirectory, int nShowCmd);


		private void dgv_SearchResults_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			// open the file when the user clicks on the cell
			if (e.RowIndex >= 0)
			{
				string shortName = dgv_SearchResults.Rows[e.RowIndex].Cells[0].Value.ToString()!;
				string fullName = shortNameToLongName[shortName];

				ShellExecute(IntPtr.Zero, "open", fullName, "", "", 1);
			}
		}

		private void dragDrop(object sender, DragEventArgs e)
		{
			string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

			if (files.Length > 0 && System.IO.File.Exists(files[0]))
			{
				foreach (string fileName in files)
				{
					if (System.IO.File.Exists(fileName))
						loadFile(fileName);
				}
			}
		}

		private void loadFile(string fullPath)
		{
			if (!fullPath.EndsWith(".xls") && !fullPath.EndsWith(".xlsx") && !fullPath.EndsWith(".xlsm"))
			{
				return;
			}

			if (checkListBox_files.Items.Contains(fullPath))
			{
				return;
			}

			try
			{
				MemoryStream stream = new MemoryStream(System.IO.File.ReadAllBytes(fullPath));
				readers.Add(fullPath, ExcelReaderFactory.CreateReader(stream));
				checkListBox_files.Items.Add(fullPath, true);
			}
			catch (Exception)
			{
			
			}
		}

		private void dragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				e.Effect = DragDropEffects.Copy;
			}
		}
	}
}
