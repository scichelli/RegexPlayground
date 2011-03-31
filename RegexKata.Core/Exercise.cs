using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace RegexKata.Core
{
	public class Exercise
	{
		public string Title { get; private set; }
		public IEnumerable<TestCase> Cases { get; private set; }

		public Exercise(string title, IEnumerable<TestCase> cases)
		{
			Title = title;
			Cases = cases;
		}

		public ExerciseResult Evaluate(string pattern)
		{
			var regex = new Regex(pattern);
			var failedCases = Cases.Where(c => regex.IsMatch(c.Input) != c.ShouldMatch);
			return new ExerciseResult(!failedCases.Any(), Cases.Except(failedCases), failedCases);
		}
	}
}