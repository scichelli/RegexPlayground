using System.Collections.Generic;

namespace RegexKata.Core
{
	public interface IPuzzle
	{
		IEnumerable<Riddle> Riddles { get; }
	}
}