using System;
using Machine.Specifications;
using System.Reflection;
namespace MSpecRunner.Specs.Specifications.for_SpecificationsToRun
{
	public class when_a_class_has_been_defined : given.a_specifications_to_run_instance
	{
		Because of = () => specifications_to_run.ClassName = "Something";
		
		It should_return_true_for_has_class = () => specifications_to_run.HasClass.ShouldBeTrue();
	}
}