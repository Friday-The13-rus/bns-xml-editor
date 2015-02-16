namespace Core
{
	public class ReplaceCriteria
	{
		public string Pattern { get; private set; }
		public string Replacement { get; private set; }
		public bool IsRegex { get; private set; }
		public bool IsIgnoreCase { get; private set; }

		public ReplaceCriteria(string pattern, string replacement, bool isRegex, bool isIgnoreCase)
		{
			Pattern = pattern;
			Replacement = replacement;
			IsRegex = isRegex;
			IsIgnoreCase = isIgnoreCase;
		}
	}
}
