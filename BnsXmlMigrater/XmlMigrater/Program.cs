using System;
using System.Collections.Generic;
using System.Linq;

namespace XmlMigrater
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			ReassignId(args);
		}

		private static string ReadOriginalFilePath()
		{
			return ReadPath("Original file:");
		}

		private static string ReadTranslateFilePath()
		{
			return ReadPath("Translate file:");
		}

		private static string ReadPath(string message)
		{
			Console.WriteLine(message);
			return Console.ReadLine();
		}

		static void CreateNewTranslateFile()
		{
			IEnumerable<OriginalItem> original = XmlWorker.ReadOriginalFile(ReadOriginalFilePath());
			IEnumerable<TranslatedItem> translated = XmlWorker.CreateNewTranslateFile(original);
			XmlWorker.SaveToXml(translated, "new_local.xml");
		}

		private static void SplitFile()
		{
			IEnumerable<TranslatedItem> translated = XmlWorker.ReadTranslateFile(ReadTranslateFilePath());
			XmlWorker.SaveSplitted(translated, "local");
		}

		private static void ReplaceKoreanTranslate()
		{
			IEnumerable<TranslatedItem> result = XmlWorker.ReplaceKoreanTranslate(XmlWorker.ReadTranslateFile("new_local.xml"));
			XmlWorker.SaveToXml(result, "new_local_repaired.xml");
		}

		private static void RepairTags()
		{
			IEnumerable<TranslatedItem> translated = XmlWorker.ReadTranslateFile("new_local_migrated.xml");
			IEnumerable<TranslatedItem> invalidTags;
			IEnumerable<TranslatedItem> result = XmlWorker.RepairTags(translated, out invalidTags);
			XmlWorker.SaveToXml(result, "new_local_repaired.xml");
			XmlWorker.SaveToXml(invalidTags, "invalidTags.xml");
		}

		static void CheckTranslate()
		{
			List<OriginalItem> original = (List<OriginalItem>)XmlWorker.ReadOriginalFile(ReadOriginalFilePath());
			List<TranslatedItem> translated = (List<TranslatedItem>)XmlWorker.ReadTranslateFile(ReadTranslateFilePath());

			Console.WriteLine(XmlWorker.CheckTranslate(original, translated));
			Console.ReadLine();
		}

		private static void ReassignTranslate()
		{
			IDictionary<string, OriginalItem> original = XmlWorker.ReadOriginalFileAlias("free.xml");
			IEnumerable<TranslatedItem> translated = XmlWorker.ReadTranslateFile("new_local.xml");

			IEnumerable<TranslatedItem> result = XmlWorker.ReassignTranslate(original, translated);
			XmlWorker.SaveToXml(result, "new_local_migrated.xml");
		}

		private static void ReassignId(IList<string> args)
		{
			if (args.Count == 2)
			{
				IEnumerable<OriginalItem> original = XmlWorker.ReadOriginalFile(args[0]);
				IEnumerable<TranslatedItem> translated = XmlWorker.ReadTranslateFile(args[1]);

				IEnumerable<TranslatedItem> result;
				IEnumerable<InvalidTranslateItem> invalidTranslate;

				XmlWorker.ReassignId(original, new SortedList<int, TranslatedItem>(translated.ToDictionary(el => el.AutoId)), 
					out result, out invalidTranslate);

				XmlWorker.SaveToXml(result, "new_local.xml");
				XmlWorker.SaveToXml(invalidTranslate, "new_local_invalid.xml");
			}
			else
			{
				Console.WriteLine("Using:\nXmlMigrater.exe <original.xml> <translate.xml>");
				Console.ReadKey();
			}
		}
	}
}