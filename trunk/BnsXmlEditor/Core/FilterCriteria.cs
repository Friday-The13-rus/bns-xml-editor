namespace Core
{
	public class FilterCriteria
	{
		public string Value { get; private set; }
		public TranslatableItem.Fields Field { get; private set; }
		public bool IsRegex { get; private set; }
		public bool IsIgnoreCase { get; private set; }

		public FilterCriteria(string value, TranslatableItem.Fields field, bool isRegex, bool isIgnoreCase)
		{
			Value = value;
			Field = field;
			IsRegex = isRegex;
			IsIgnoreCase = isIgnoreCase;
		}
	}
}
