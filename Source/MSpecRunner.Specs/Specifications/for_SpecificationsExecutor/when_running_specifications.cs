using System;
using System.Reflection;
using System.Linq;
using Machine.Specifications;
using Machine.Specifications.Runner;

namespace MSpecRunner.Specs.Specifications.for_SpecificationsExecutor
{
	public class when_running_specifications : given.a_specification_executor
	{
		Establish context = () =>
		{
			specifications_to_run.Type = typeof(FakeSpecs);
			specifications_to_run.TargetAssembly = specifications_to_run.Type.Assembly;
			specifications_to_run.Namespace = specifications_to_run.Type.Namespace;
			specifications_to_run.ClassName = specifications_to_run.Type.Name;
			specifications_to_run.Specifications = specifications_to_run.Type.GetFields(BindingFlags.NonPublic|BindingFlags.Instance);
		};

		Because of = () => specification_executor.Execute ("", "", 0);

		It should_run_the_specifications_in_the_class = () => specification_runner_mock.Verify(s=>s.RunMember(specifications_to_run.TargetAssembly, Moq.It.IsAny<MemberInfo>()), Moq.Times.Exactly(2));
	}
}
