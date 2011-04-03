using System.Collections.Generic;

namespace RegexKata.Core
{
	public class Puzzle
	{
        public IEnumerable<Riddle> Riddles { get; private set; }
        
        public Puzzle(IEnumerable<Riddle> riddles)
	    {
	        Riddles = riddles;
	    }
	}
}