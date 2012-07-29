using System;
using System.Reflection;
using System.Linq;
using Machine.Specifications;
using Machine.Specifications.Runner;

namespace MSpecRunner.Specs.Specifications.for_SpecificationsExecutor
{
	public class when_running_a_namespace : given.a_specification_executor
	{
		Establish context = () => {
			specifications_to_run.Type = typeof(FakeSpecs);
			specifications_to_run.TargetAssembly = specifications_to_run.Type.Assembly;
			specifications_to_run.Namespace = specifications_to_run.Type.Namespace;
		};
		
		Because of = () => specification_executor.Execute("","",0);


		It should_run_the_namespace = () => specification_runner_mock.Verify(s=>s.RunNamespace(specifications_to_run.TargetAssembly, specifications_to_run.Namespace));
	}
}

