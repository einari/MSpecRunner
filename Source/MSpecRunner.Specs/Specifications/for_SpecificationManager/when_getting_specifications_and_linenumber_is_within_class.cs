
using System;
using Machine.Specifications;
using MSpecRunner.Specifications;
using System.IO;
namespace MSpecRunner.Specs.Specifications.for_SpecificationManager
{
	public class when_getting_specifications_and_linenumber_is_within_class : given.a_specification_manager_with_an_assembly_and_a_source_file
	{
		static SpecificationsToRun specifications_to_run;

		Because of = () => specifications_to_run = specification_manager.GetSpecificationsToRun (string.Empty, string.Empty, 9);
		
		It should_contain_the_namespace_for_the_class_containing_the_specification = () => specifications_to_run.Namespace.ShouldEqual (typeof(FakeSpecs).Namespace);
		It should_contain_the_class_for_the_specification = () => specifications_to_run.ClassName.ShouldEqual (typeof(FakeSpecs).Name);
		It should_contain_two_specifications = () => specifications_to_run.Specifications.Length.ShouldEqual(2);
	}
}
