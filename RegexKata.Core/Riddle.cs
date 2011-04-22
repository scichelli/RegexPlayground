using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace RegexKata.Core
{
	public class Riddle
	{
		public Guid Id { get; set; }
		public string Title { get; private set; }
		public IEnumerable<Clue> Clues { get; private set; }

		public Riddle(string title, IEnumerable<Clue> clues)
		{
			Title = title;
			Clues = clues;
		}

		public RiddleResult Evaluate(string pattern)
		{
			var regex = new Regex(pattern);
			var failedClues = Clues.Where(c => regex.IsMatch(c.Prompt) != c.ShouldMatch);
			return new RiddleResult(!failedClues.Any(), Clues.Except(failedClues), failedClues);
		}
	}
}