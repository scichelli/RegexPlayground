namespace RegexKata.Core
{
	public class TestCase
	{
		public string Input { get; private set; }
		public bool ShouldMatch { get; private set; }

		public TestCase(string input, bool shouldMatch)
		{
			Input = input;
			ShouldMatch = shouldMatch;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != typeof (TestCase)) return false;
			return Equals((TestCase) obj);
		}

		public bool Equals(TestCase other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return Equals(other.Input, Input) && other.ShouldMatch.Equals(ShouldMatch);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				return ((Input != null ? Input.GetHashCode() : 0)*397) ^ ShouldMatch.GetHashCode();
			}
		}
	}
}