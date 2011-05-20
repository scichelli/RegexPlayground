using System;

namespace RegexPlayground.Core
{
	public interface IRiddleRepository
	{
		Riddle GetRandom();
		Riddle GetById(Guid id);
	}
}