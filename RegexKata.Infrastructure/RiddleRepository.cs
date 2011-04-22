using System;
using RegexKata.Core;

namespace RegexKata.Infrastructure
{
	public class RiddleRepository : IRiddleRepository
	{
		public Riddle GetRandom()
		{
			return new Riddle("word boundaries",
				new[]
					{
						new Clue("car", true),
						new Clue("a car parks.", true),
						new Clue("a car.", true),
						new Clue("a caR.", true),
						new Clue("scare", false),
						new Clue("cargo", false),
						new Clue("gocar", false)
					}
				);
		}

		public Riddle GetById(Guid id)
		{
			return GetRandom();
		}
	}
}