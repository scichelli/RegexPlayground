using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using RegexKata.Core;

namespace RegexKata.Tests
{
	public class ExerciseTester
	{
		[TestFixture]
		public class When_evaluating_test_cases
		{
			[Test]
			public void Should_return_successful_result_when_all_cases_match_correctly()
			{
				var testCases = new List<TestCase> { new TestCase("cat", true) };
				var exercise = new Exercise("Test", testCases);

				var exerciseResult = exercise.Evaluate("cat");

				Assert.That(exerciseResult.Passed, Is.True);
				Assert.That(exerciseResult.FailedCases, Is.Empty);
				Assert.That(exerciseResult.SuccessfulCases, Is.EquivalentTo(testCases));
			}

			[Test]
			public void Should_return_failing_case_when_expected_to_match()
			{
				var testCases = new List<TestCase> { new TestCase("cat", true) };
				var exercise = new Exercise("Test", testCases);

				var exerciseResult = exercise.Evaluate("dog");

				Assert.That(exerciseResult.Passed, Is.False);
				Assert.That(exerciseResult.FailedCases, Is.EquivalentTo(testCases));
			}

			[Test]
			public void Should_return_failing_case_when_expected_not_to_match()
			{
				const string expectedFailingInput = "cat";
				var testCases = new List<TestCase> { new TestCase(expectedFailingInput, false) };
				var exercise = new Exercise("Test", testCases);

				var exerciseResult = exercise.Evaluate(expectedFailingInput);

				Assert.That(exerciseResult.Passed, Is.False);
				Assert.That(exerciseResult.FailedCases, Is.EquivalentTo(testCases));
			}

			[Test]
			public void Should_return_only_the_cases_that_failed()
			{
				const string expectedPassingInput = "dog";
				var expectedFailingTestCase = new TestCase("cat", true);
				var exercise = new Exercise("Test", new List<TestCase>
				                                    	{
				                                    		new TestCase("other", false),
				                                    		expectedFailingTestCase,
				                                    		new TestCase(expectedPassingInput, true)
				                                    	});

				var exerciseResult = exercise.Evaluate(expectedPassingInput);

				Assert.That(exerciseResult.Passed, Is.False);
				Assert.That(exerciseResult.FailedCases, Is.EquivalentTo(new List<TestCase> {expectedFailingTestCase}));
			}

			[Test]
			public void Should_return_multiple_failing_cases()
			{
				const string expectedMismatch = "cat";
				const string expectedMissingMatch = "dog";
				var exercise = new Exercise("Test", new List<TestCase>
				                                    	{
				                                    		new TestCase(expectedMismatch, true),
				                                    		new TestCase(expectedMissingMatch, false),
				                                    		new TestCase("other", false)
				                                    	});

				var exerciseResult = exercise.Evaluate(expectedMissingMatch);

				Assert.That(exerciseResult.FailedCases.Count(), Is.EqualTo(2));
				Assert.That(exerciseResult.FailedCases.Any(c => c.Input == expectedMismatch));
				Assert.That(exerciseResult.FailedCases.Any(c => c.Input == expectedMissingMatch));
			}
		}
	}
}
