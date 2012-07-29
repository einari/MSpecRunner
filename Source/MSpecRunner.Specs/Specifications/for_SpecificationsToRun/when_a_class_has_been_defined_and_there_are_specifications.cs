
using System;
using Machine.Specifications;
using System.Reflection;
namespace MSpecRunner.Specs.Specifications.for_SpecificationsToRun
{
	public class when_a_class_has_been_defined_and_there_are_specifications : given.a_specifications_to_run_instance
	{
		Because of = () =>
		{
			specifications_to_run.ClassName = "Something";
			specifications_to_run.Specifications = typeof(FakeSpecs).GetFields (BindingFlags.NonPublic | BindingFlags.Instance);
		};

		It should_return_true_for_has_specifications = () => specifications_to_run.HasSpecifications.ShouldBeTrue ();
	}
}
