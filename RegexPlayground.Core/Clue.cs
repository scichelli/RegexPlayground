namespace RegexPlayground.Core
{
	public class Clue
	{
		public string Prompt { get; private set; }
		public bool ShouldMatch { get; private set; }

		public Clue(string input, bool shouldMatch)
		{
			Prompt = input;
			ShouldMatch = shouldMatch;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != typeof (Clue)) return false;
			return Equals((Clue) obj);
		}

		public bool Equals(Clue other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return Equals(other.Prompt, Prompt) && other.ShouldMatch.Equals(ShouldMatch);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				return ((Prompt != null ? Prompt.GetHashCode() : 0)*397) ^ ShouldMatch.GetHashCode();
			}
		}
	}
}