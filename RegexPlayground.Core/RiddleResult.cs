using System.Collections.Generic;

namespace RegexPlayground.Core
{
	public class RiddleResult
	{
		public bool Passed { get; private set; }
		public IEnumerable<Clue> SuccessfulClues { get; private set; }
		public IEnumerable<Clue> FailedClues { get; private set; }

		public RiddleResult(bool passed, IEnumerable<Clue> successfulCases, IEnumerable<Clue> failedCases)
		{
			Passed = passed;
			SuccessfulClues = successfulCases;
			FailedClues = failedCases;
		}
	}
}