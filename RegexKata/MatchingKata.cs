using System.Text.RegularExpressions;
using NUnit.Framework;

namespace RegexKata
{
	/// <summary>
	/// This kata is a series of exercises in defining regular expression patterns to match given inputs.
	/// Complete each exercise by defining a pattern that passes all of the TestCases. You might also need 
	/// to supply RegexOptions to the Regex constructor.
	/// </summary>
	/* 
	Notes to self, to prep for blog post:
	 1. To run tests, run C:\Users\Sharon\CodeUnruly\NUnitRunner\NUnit-2.5.5.10112\bin\net-2.0\nunit.exe, 
	 and open the RegexKata.nunit project in this solution's bin\Debug folder.
	 2. To clear the answers from the tests, use a Regex find-replace. 
	 Find: const string pattern = \".*\";
	 Replace with: const string pattern = \"\";
	 3. Mention the rkt Live Template.
	 4. Delete this comment, but keep the summary.
	*/
	[TestFixture]
	public class MatchingKata
	{
		[TestCase("car", Result = true)]
		[TestCase("Car", Result = false)]
		[TestCase("CaR", Result = false)]
		[TestCase("CAR", Result = false)]
		[TestCase("carabiner", Result = true)]
		[TestCase("scare", Result = true)]
		[TestCase("cae", Result = false)]
		[TestCase("caar", Result = false)]
		public bool LiteralCharacters_CaseSensitive_WithinWord(string input)
		{
			const string pattern = @"car";
			var regex = new Regex(pattern);
			return regex.IsMatch(input);
		}

		[TestCase("car", Result = true)]
		[TestCase("Car", Result = true)]
		[TestCase("CaR", Result = true)]
		[TestCase("CAR", Result = true)]
		[TestCase("carabiner", Result = true)]
		[TestCase("scare", Result = true)]
		[TestCase("cae", Result = false)]
		[TestCase("caar", Result = false)]
		public bool LiteralCharacters_CaseInsensitive_WithinWord(string input)
		{
			const string pattern = @"[Cc][Aa][Rr]";
			var regex = new Regex(pattern);
			return regex.IsMatch(input);
		}

		[TestCase("car", Result = true)]
		[TestCase("Car", Result = true)]
		[TestCase("CaR", Result = true)]
		[TestCase("CAR", Result = true)]
		[TestCase("carabiner", Result = true)]
		[TestCase("scare", Result = true)]
		[TestCase("cae", Result = false)]
		[TestCase("caar", Result = false)]
		public bool CaseInsensitive_ByUsingRegexOptions(string input)
		{
			const string pattern = @"car";
			var regex = new Regex(pattern, RegexOptions.IgnoreCase);
			return regex.IsMatch(input);
		}

		[TestCase("car", Result = true)]
		[TestCase("a car parks.", Result = true)]
		[TestCase("a car.", Result = true)]
		[TestCase("a caR.", Result = true)]
		[TestCase("scare", Result = false)]
		[TestCase("cargo", Result = false)]
		[TestCase("gocar", Result = false)]
		public bool LiteralCharacters_CaseInsensitive_AsAWord(string input)
		{
			const string pattern = @"\b[Cc][Aa][Rr]\b";
			var regex = new Regex(pattern);
			return regex.IsMatch(input);
		}

		[TestCase("cat", Result = true)]
		[TestCase("cot", Result = true)]
		[TestCase("coot", Result = false)]
		[TestCase("ct", Result = false)]
		[TestCase("c#t", Result = true)]
		[TestCase("c t", Result = true)]
		[TestCase("c2t", Result = true)]
		public bool AnySingleCharacter(string input)
		{
			const string pattern = @"c.t";
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
			const string pattern = @"c\wt";
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
			const string pattern = @"c[a-zA-Z]t";
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
			const string pattern = @"c\dt";
			var regex = new Regex(pattern);
			return regex.IsMatch(input);
		}
	}
}