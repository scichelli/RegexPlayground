using System.Text.RegularExpressions;
using NUnit.Framework;

namespace RegexKata.Matching
{
	[TestFixture]
	public class Wildcards
	{
		[TestCase("cat", Result = true)]
		[TestCase("cot", Result = true)]
		[TestCase("coot", Result = false)]
		[TestCase("ct", Result = false)]
		[TestCase("c#t", Result = true)]
		[TestCase("c t", Result = true)]
		[TestCase("c2t", Result = true)]
		public bool AnySingleCharacter(string input)
		{
			const string pattern = @"";
			var regex = new Regex(pattern);
			return regex.IsMatch(input);
		}

		[TestCase("cat", Result = true)]
		[TestCase("cot", Result = true)]
		[TestCase("coot", Result = false)]
		[TestCase("ct", Result = false)]
		[TestCase("c#t", Result = false)]
		[TestCase("c t", Result = false)]
		[TestCase("c2t", Result = true)]
		[TestCase("c_t", Result = true)]
		public bool AnySingleAlphaNumericOrUnderscore(string input)
		{
			const string pattern = @"";
			var regex = new Regex(pattern);
			return regex.IsMatch(input);
		}

		[TestCase("cat", Result = true)]
		[TestCase("cot", Result = true)]
		[TestCase("coot", Result = false)]
		[TestCase("ct", Result = false)]
		[TestCase("c#t", Result = false)]
		[TestCase("c t", Result = false)]
		[TestCase("c2t", Result = false)]
		[TestCase("c_t", Result = false)]
		public bool AnySingleLetter(string input)
		{
			const string pattern = @"";
			var regex = new Regex(pattern);
			return regex.IsMatch(input);
		}

		[TestCase("cat", Result = false)]
		[TestCase("cot", Result = false)]
		[TestCase("coot", Result = false)]
		[TestCase("ct", Result = false)]
		[TestCase("c#t", Result = false)]
		[TestCase("c t", Result = false)]
		[TestCase("c2t", Result = true)]
		[TestCase("c_t", Result = false)]
		public bool AnySingleDigit(string input)
		{
			const string pattern = @"";
			var regex = new Regex(pattern);
			return regex.IsMatch(input);
		}
	}
}