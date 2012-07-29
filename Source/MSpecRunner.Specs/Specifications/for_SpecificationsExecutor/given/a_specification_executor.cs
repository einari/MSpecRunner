using System;
using MSpecRunner.Specifications;
using Moq;
using Machine.Specifications.Runner;
using Machine.Specifications;

namespace MSpecRunner.Specs.Specifications.for_SpecificationsExecutor.given
{
	public class a_specification_executor
	{
		protected static SpecificationsExecutor	specification_executor;
		protected static Mock<ISpecificationManager> specification_manager_mock;
		protected static Mock<ISpecificationRunner> specification_runner_mock;
		protected static SpecificationsToRun specifications_to_run;
		
		Establish context = () => {
			specifications_to_run = new SpecificationsToRun();
			specification_manager_mock = new Mock<ISpecificationManager>();
			specification_manager_mock.Setup(s=>s.GetSpecificationsToRun(Moq.It.IsAny<string>(), Moq.It.IsAny<string>(), Moq.It.IsAny<int>())).Returns(specifications_to_run);
			specification_runner_mock = new Mock<ISpecificationRunner>();
			specification_executor = new SpecificationsExecutor(specification_manager_mock.Object, specification_runner_mock.Object);
		};
	}
}

