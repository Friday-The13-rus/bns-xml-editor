using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using XmlMigrater;

namespace XmlMigrater
{
	internal class Program
	{
		private static int percentS;

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
			List<OriginalItem> original = XmlWorker.ReadOriginalFile(ReadOriginalFilePath());
			List<TranslatedItem> translated = XmlWorker.CreateNewTranslateFile(original);
			XmlWorker.SaveToXml(translated, "new_local.xml");
		}

		private static void ReplaceKoreianTranslate()
		{
			List<TranslatedItem> result = XmlWorker.ReplaceKoreianTranslate(XmlWorker.ReadTranslateFile("new_local.xml"));
			XmlWorker.SaveToXml(result, "new_local_repaired.xml");
		}

		static void BinarySerialize()
		{
			SortedList<int, TranslatedItem> list = XmlWorker.ReadTranslateFile("new_local.xml");
			using (FileStream stream = new FileStream("bin.bin", FileMode.Create))
			{
				BinaryFormatter formatter = new BinaryFormatter();
				formatter.Serialize(stream, list);
			}
		}

		private static void RepairTags()
		{
			SortedList<int, TranslatedItem> translated = XmlWorker.ReadTranslateFile("new_local_migrated.xml");
			List<TranslatedItem> invalidTags;
			List<TranslatedItem> result = XmlWorker.RepairTags(translated, out invalidTags);
			XmlWorker.SaveToXml(result, "new_local_repaired.xml");
			XmlWorker.SaveToXml(invalidTags, "invalidTags.xml");
		}

		static void CheckTranslate()
		{
			List<OriginalItem> original = XmlWorker.ReadOriginalFile(ReadOriginalFilePath());
			SortedList<int, TranslatedItem> translated = XmlWorker.ReadTranslateFile(ReadTranslateFilePath());

			Console.WriteLine(XmlWorker.CheckTranslate(original, translated));
			Console.ReadLine();
		}

		private static void ReassignTranslate()
		{
			Dictionary<string, OriginalItem> original = XmlWorker.ReadOriginalFileAlias("free.xml");
			SortedList<int, TranslatedItem> translated = XmlWorker.ReadTranslateFile("new_local.xml");

			List<TranslatedItem> result = XmlWorker.ReassignTranslate(original, translated);
			XmlWorker.SaveToXml(result, "new_local_migrated.xml");
		}

		private static void ReassignId(string[] args)
		{
			if (args.Length == 2)
			{
				List<OriginalItem> original = XmlWorker.ReadOriginalFile(args[0]);
				SortedList<int, TranslatedItem> translated = XmlWorker.ReadTranslateFile(args[1]);

				List<TranslatedItem> result = new List<TranslatedItem>();
				List<InvalidItem> invalidTranslate = new List<InvalidItem>();

				XmlWorker.ReassignId(original, translated, out result, out invalidTranslate);

				XmlWorker.SaveToXml(result, "new_local.xml");
				XmlWorker.SaveToXml(invalidTranslate, "new_local_invalid.xml");
			}
			else
			{
				Console.WriteLine("Using:\nXmlMigrater.exe <original.xml> <translate.xml>");
				Console.ReadKey();
			}
		}

		private static void Progress(int percent)
		{
			//Console.Clear();

			if (percent != percentS && percent % 5 == 0)
			{
				Console.SetCursorPosition(0, 0);
				Console.Write(percent + "%");
			}
			percentS = percent;
		}
	}
}