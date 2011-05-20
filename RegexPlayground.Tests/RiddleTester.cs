using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using RegexPlayground.Core;

namespace RegexPlayground.Tests
{
	public class RiddleTester
	{
		[TestFixture]
		public class When_evaluating_clues
		{
			[Test]
			public void Should_return_successful_result_when_all_clues_match_correctly()
			{
				var clues = new List<Clue> { new Clue("cat", true) };
				var riddle = new Riddle("Test", clues);

				var riddleResult = riddle.Evaluate("cat");

				Assert.That(riddleResult.Passed, Is.True);
				Assert.That(riddleResult.FailedClues, Is.Empty);
				Assert.That(riddleResult.SuccessfulClues, Is.EquivalentTo(clues));
			}

			[Test]
			public void Should_return_failing_clue_when_expected_to_match()
			{
				var clues = new List<Clue> { new Clue("cat", true) };
				var riddle = new Riddle("Test", clues);

				var riddleResult = riddle.Evaluate("dog");

				Assert.That(riddleResult.Passed, Is.False);
				Assert.That(riddleResult.FailedClues, Is.EquivalentTo(clues));
			}

			[Test]
			public void Should_return_failing_clue_when_expected_not_to_match()
			{
				const string expectedFailingPrompt = "cat";
				var clues = new List<Clue> { new Clue(expectedFailingPrompt, false) };
				var riddle = new Riddle("Test", clues);

				var riddleResult = riddle.Evaluate(expectedFailingPrompt);

				Assert.That(riddleResult.Passed, Is.False);
				Assert.That(riddleResult.FailedClues, Is.EquivalentTo(clues));
			}

			[Test]
			public void Should_return_only_the_clues_that_failed()
			{
				const string expectedPassingPrompt = "dog";
				var expectedFailingClue = new Clue("cat", true);
				var riddle = new Riddle("Test", new List<Clue>
				                                    	{
				                                    		new Clue("other", false),
				                                    		expectedFailingClue,
				                                    		new Clue(expectedPassingPrompt, true)
				                                    	});

				var riddleResult = riddle.Evaluate(expectedPassingPrompt);

				Assert.That(riddleResult.Passed, Is.False);
				Assert.That(riddleResult.FailedClues, Is.EquivalentTo(new List<Clue> {expectedFailingClue}));
			}

			[Test]
			public void Should_return_multiple_failing_clues()
			{
				const string expectedMismatch = "cat";
				const string expectedMissingMatch = "dog";
				var riddle = new Riddle("Test", new List<Clue>
				                                    	{
				                                    		new Clue(expectedMismatch, true),
				                                    		new Clue(expectedMissingMatch, false),
				                                    		new Clue("other", false)
				                                    	});

				var riddleResult = riddle.Evaluate(expectedMissingMatch);

				Assert.That(riddleResult.FailedClues.Count(), Is.EqualTo(2));
				Assert.That(riddleResult.FailedClues.Any(c => c.Prompt == expectedMismatch));
				Assert.That(riddleResult.FailedClues.Any(c => c.Prompt == expectedMissingMatch));
			}
		}
	}
}
