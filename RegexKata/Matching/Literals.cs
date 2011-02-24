using System.Text.RegularExpressions;
using NUnit.Framework;

namespace RegexKata.Matching
{
	[TestFixture]
	public class Literals
	{
		[TestCase("car", Result = true)]
		[TestCase("Car", Result = false)]
		[TestCase("CaR", Result = false)]
		[TestCase("CAR", Result = false)]
		[TestCase("carabiner", Result = true)]
		[TestCase("scare", Result = true)]
		[TestCase("cae", Result = false)]
		[TestCase("caar", Result = false)]
		public bool CaseSensitive_WithinWord(string input)
		{
			const string pattern = @"";
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
		public bool CaseInsensitive_WithinWord(string input)
		{
			const string pattern = @"";
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
			const string pattern = @"";
			var regex = new Regex(pattern); //Pass options to this constructor.
			return regex.IsMatch(input);
		}

		[TestCase("car", Result = true)]
		[TestCase("a car parks.", Result = true)]
		[TestCase("a car.", Result = true)]
		[TestCase("a caR.", Result = true)]
		[TestCase("scare", Result = false)]
		[TestCase("cargo", Result = false)]
		[TestCase("gocar", Result = false)]
		public bool CaseInsensitive_AsAWord(string input)
		{
			const string pattern = @"";
			var regex = new Regex(pattern);
			return regex.IsMatch(input);
		}
	}
}