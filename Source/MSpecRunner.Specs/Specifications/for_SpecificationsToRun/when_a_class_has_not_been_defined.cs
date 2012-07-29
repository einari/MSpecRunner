
using System;
using Machine.Specifications;
namespace MSpecRunner.Specs.Specifications.for_SpecificationsToRun
{
	public class when_a_class_has_not_been_defined : given.a_specifications_to_run_instance
	{
		Because of = () => specifications_to_run.ClassName = string.Empty;

		It should_return_false_for_has_class = () => specifications_to_run.HasClass.ShouldBeFalse ();
	}
}
