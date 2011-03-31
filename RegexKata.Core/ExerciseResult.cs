using System.Collections.Generic;

namespace RegexKata.Core
{
	public class ExerciseResult
	{
		public bool Passed { get; private set; }
		public IEnumerable<TestCase> SuccessfulCases { get; private set; }
		public IEnumerable<TestCase> FailedCases { get; private set; }

		public ExerciseResult(bool passed, IEnumerable<TestCase> successfulCases, IEnumerable<TestCase> failedCases)
		{
			Passed = passed;
			SuccessfulCases = successfulCases;
			FailedCases = failedCases;
		}
	}
}