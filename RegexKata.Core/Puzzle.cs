using System.Collections.Generic;

namespace RegexKata.Core
{
	public class Puzzle
	{
		public Puzzle(IEnumerable<Riddle> riddles)
		{
			Riddles = riddles;
		}

		public IEnumerable<Riddle> Riddles { get; private set; }
	}
}