using System;

namespace RegexKata.Core
{
	public interface IRiddleRepository
	{
		Riddle GetRandom();
		Riddle GetById(Guid id);
	}
}