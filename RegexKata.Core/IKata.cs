using System.Collections.Generic;

namespace RegexKata.Core
{
	public interface IKata
	{
		IEnumerable<Exercise> Exercises { get; }
	}
}