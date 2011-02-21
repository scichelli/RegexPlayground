using System.Text.RegularExpressions;
using NUnit.Framework;

namespace RegexKata
{
	/// <summary>
	/// This kata is a series of exercises in defining regular expression patterns to match given inputs.
	/// Complete each exercise by defining a pattern that passes all of the TestCases. You might also need 
	/// to supply RegexOptions to the Regex constructor.
	/// </summary>
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
			const string pattern = "";
			var regex = new Regex(pattern);
			return regex.IsMatch(input);
		}

		[TestCase("car", Result=true)]
		[TestCase("Car", Result=true)]
		[TestCase("CaR", Result=true)]
		[TestCase("CAR", Result=true)]
		[TestCase("carabiner", Result=true)]
		[TestCase("scare", Result=true)]
		[TestCase("cae", Result = false)]
		[TestCase("caar", Result = false)]
		public bool LiteralCharacters_CaseInsensitive_WithinWord(string input)
		{
			const string pattern = "";
			var regex = new Regex(pattern);
			return regex.IsMatch(input);
		}
	}
}