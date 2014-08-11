using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BnsXmlEditorWpf
{
	class HistoryComboBox : ComboBox
	{
		string historyFile;

		public HistoryComboBox()
			: base()
		{
			Dispatcher.ShutdownStarted += Dispatcher_ShutdownStarted;
		}

		void Dispatcher_ShutdownStarted(object sender, EventArgs e)
		{
			SaveHistory();
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
			{
				string[] lines = File.ReadAllLines(HistoryFile);
				foreach (string line in lines)
					Items.Add(line);
			}
		}

		public void UpdateHistory()
		{
			string temp = Text;
			if (Text == string.Empty)
				return;

			int index = Items.IndexOf(Text);

			if (index != -1)
				Items.RemoveAt(index);

			Items.Insert(0, Text);

			if (Items.Count > HistoryMaxItems)
				Items.RemoveAt(Items.Count - 1);

			if (Text == string.Empty)
				Text = temp;
		}
		
		//protected override void Dispose(bool disposing)
		//{
		//	if (disposing)
		//		SaveHistory();
		//}
	}
}
