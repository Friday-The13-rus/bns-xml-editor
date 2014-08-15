using System.IO;
using System.Linq;
using System.Windows.Forms;
using System;
using System.ComponentModel;

namespace BnsXmlEditor.Controls
{
	class HistoryComboBox : ComboBox
	{
		string historyFile;

		public HistoryComboBox()
		{
			HistoryMaxItems = 20;
		}
		
		public string HistoryFile
		{
			get { return historyFile; }
			set
			{
				if (historyFile != value)
				{
					historyFile = value;
					LoadHistory();
				}
			}
		}

		[DefaultValue(20)]
		public int HistoryMaxItems { get; set; }
		
		public void SaveHistory()
		{
			File.WriteAllLines(HistoryFile, Items.Cast<string>());
		}

		void LoadHistory()
		{
			if (string.IsNullOrWhiteSpace(HistoryFile))
				throw new ArgumentException("Имя файла с историей не заполнено.", "HistoryFile");

			if (File.Exists(HistoryFile))
				Items.AddRange(File.ReadAllLines(HistoryFile));
		}

		public void UpdateHistory()
		{
			string temp = Text;
			if (Text == string.Empty)
				return;

			int index = Items.IndexOf(temp);

			if (index != -1)
				Items.RemoveAt(index);

			Items.Insert(0, temp);

			if (Items.Count > HistoryMaxItems)
				Items.RemoveAt(Items.Count - 1);

			if (Text == string.Empty)
				Text = temp;
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
				SaveHistory();
			
			base.Dispose(disposing);
		}
	}
}