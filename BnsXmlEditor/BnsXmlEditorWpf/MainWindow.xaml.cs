using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace BnsXmlEditorWpf
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		List<TranslatableItem> items;
		
		public MainWindow()
		{
			InitializeComponent();
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			XDocument doc = XDocument.Load("new_local.xml");
			XElement el = doc.Root;

			items = new List<TranslatableItem>();

			foreach (XElement elem in el.Elements())
			{
				int autoId = int.Parse(elem.Element("autoId").Value);
				string alias = elem.Element("alias").Value;
				string original = elem.Element("original").Value;
				string translate = elem.Element("replacement").Value;

				items.Add(new TranslatableItem(autoId, alias, original, translate));
			}

			lstTranslatableItems.ItemsSource = items;
			lblElementsCount.Content = items.Count.ToString("N0");
		}

		private void findButton_Click(object sender, RoutedEventArgs e)
		{
			cmbSearch.UpdateHistory();
		}
	}
}
