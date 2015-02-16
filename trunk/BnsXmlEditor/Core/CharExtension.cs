namespace Core
{
	public static class CharExtension
	{
		public static bool IsRussianChar(this char elem)
		{
			return elem >= '\u0401' && elem <= '\u0451';
		}

		public static bool IsChineseChar(this char elem)
		{
			return elem >= '\u4E00' && elem <= '\u9FFF';
		}
	}
}
