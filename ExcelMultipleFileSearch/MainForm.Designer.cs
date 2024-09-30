using System.Drawing;
using System.Windows.Forms;


namespace ExcelMultipleFileSearch
{
	partial class MainForm
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			checkListBox_files = new CheckedListBox();
			btn_addFile = new Button();
			txtBox_searchKeyword = new TextBox();
			btn_Search = new Button();
			dgv_SearchResults = new DataGridView();
			File = new DataGridViewTextBoxColumn();
			Sheet = new DataGridViewTextBoxColumn();
			Content = new DataGridViewTextBoxColumn();
			radioBtn_OR = new RadioButton();
			radioBtn_AND = new RadioButton();
			((System.ComponentModel.ISupportInitialize)dgv_SearchResults).BeginInit();
			SuspendLayout();
			// 
			// checkListBox_files
			// 
			checkListBox_files.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
			checkListBox_files.FormattingEnabled = true;
			checkListBox_files.Location = new Point(853, 20);
			checkListBox_files.Name = "checkListBox_files";
			checkListBox_files.Size = new Size(387, 418);
			checkListBox_files.TabIndex = 0;
			// 
			// btn_addFile
			// 
			btn_addFile.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			btn_addFile.Location = new Point(853, 444);
			btn_addFile.Name = "btn_addFile";
			btn_addFile.Size = new Size(387, 72);
			btn_addFile.TabIndex = 1;
			btn_addFile.Text = "파일 추가";
			btn_addFile.UseVisualStyleBackColor = true;
			btn_addFile.Click += btn_addFile_Click;
			// 
			// txtBox_searchKeyword
			// 
			txtBox_searchKeyword.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			txtBox_searchKeyword.Location = new Point(12, 12);
			txtBox_searchKeyword.Name = "txtBox_searchKeyword";
			txtBox_searchKeyword.Size = new Size(705, 23);
			txtBox_searchKeyword.TabIndex = 2;
			// 
			// btn_Search
			// 
			btn_Search.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			btn_Search.Location = new Point(723, 12);
			btn_Search.Name = "btn_Search";
			btn_Search.Size = new Size(124, 23);
			btn_Search.TabIndex = 3;
			btn_Search.Text = "검색";
			btn_Search.UseVisualStyleBackColor = true;
			btn_Search.Click += btn_Search_Click;
			// 
			// dgv_SearchResults
			// 
			dgv_SearchResults.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			dgv_SearchResults.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
			dgv_SearchResults.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
			dgv_SearchResults.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgv_SearchResults.Columns.AddRange(new DataGridViewColumn[] { File, Sheet, Content });
			dgv_SearchResults.Location = new Point(12, 66);
			dgv_SearchResults.Name = "dgv_SearchResults";
			dgv_SearchResults.Size = new Size(835, 450);
			dgv_SearchResults.TabIndex = 4;
			dgv_SearchResults.CellContentClick += dgv_SearchResults_CellContentClick;
			// 
			// File
			// 
			File.HeaderText = "File";
			File.Name = "File";
			File.Width = 50;
			// 
			// Sheet
			// 
			Sheet.HeaderText = "Sheet";
			Sheet.Name = "Sheet";
			Sheet.Width = 61;
			// 
			// Content
			// 
			Content.HeaderText = "Keyword";
			Content.Name = "Content";
			Content.Width = 78;
			// 
			// radioBtn_OR
			// 
			radioBtn_OR.AutoSize = true;
			radioBtn_OR.Location = new Point(17, 39);
			radioBtn_OR.Name = "radioBtn_OR";
			radioBtn_OR.Size = new Size(68, 19);
			radioBtn_OR.TabIndex = 5;
			radioBtn_OR.TabStop = true;
			radioBtn_OR.Text = "OR 검색";
			radioBtn_OR.UseVisualStyleBackColor = true;
			// 
			// radioBtn_AND
			// 
			radioBtn_AND.AutoSize = true;
			radioBtn_AND.Location = new Point(91, 39);
			radioBtn_AND.Name = "radioBtn_AND";
			radioBtn_AND.Size = new Size(77, 19);
			radioBtn_AND.TabIndex = 5;
			radioBtn_AND.TabStop = true;
			radioBtn_AND.Text = "AND 검색";
			radioBtn_AND.UseVisualStyleBackColor = true;
			// 
			// MainForm
			// 
			AllowDrop = true;
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1252, 528);
			Controls.Add(radioBtn_AND);
			Controls.Add(radioBtn_OR);
			Controls.Add(dgv_SearchResults);
			Controls.Add(btn_Search);
			Controls.Add(txtBox_searchKeyword);
			Controls.Add(btn_addFile);
			Controls.Add(checkListBox_files);
			Name = "MainForm";
			Text = "Form1";
			DragDrop += dragDrop;
			DragEnter += dragEnter;
			((System.ComponentModel.ISupportInitialize)dgv_SearchResults).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private CheckedListBox checkListBox_files;
		private Button btn_addFile;
		private TextBox txtBox_searchKeyword;
		private Button btn_Search;
		private DataGridView dgv_SearchResults;
		private RadioButton radioBtn_OR;
		private RadioButton radioBtn_AND;
		private DataGridViewTextBoxColumn File;
		private DataGridViewTextBoxColumn Sheet;
		private DataGridViewTextBoxColumn Content;
	}
}
