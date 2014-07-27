using System.IO;
using System.Linq;
using System.Windows.Forms;
using System;

namespace BnsXmlEditor
{
	class HistoryComboBox : ComboBox
	{
		public string HistoryFile { get; set; }

		public int HistoryMaxItems { get; set; }
		
		public void SaveHistory()
		{
			File.WriteAllLines(HistoryFile, Items.Cast<string>());
		}

		public void LoadHistory()
		{
			if (string.IsNullOrWhiteSpace(HistoryFile))
				throw new ArgumentException("Имя файла с историей не заполнено.", "HistoryFile");

			if (File.Exists(HistoryFile))
				Items.AddRange(File.ReadAllLines(HistoryFile));
		}

		public void Add(string query)
		{
			int index = Items.IndexOf(query);

			if (index != -1)
				Items.RemoveAt(index);

			Items.Insert(0, query);

			if (Items.Count > HistoryMaxItems)
				Items.RemoveAt(Items.Count - 1);
		}
	}
}