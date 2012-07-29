using System;
using Machine.Specifications;
using MSpecRunner.Specifications;
using Moq;
using MSpecRunner.Files;

namespace MSpecRunner.Specs.Specifications.for_SpecificationManager.given
{
	public class a_specification_manager
	{
		protected static SpecificationManager specification_manager;
		protected static Mock<IFileReader> file_reader_mock;
		protected static Mock<IAssemblyLoader> assembly_loader_mock;
		
		Establish context = () => {
			file_reader_mock = new Mock<IFileReader>();
			assembly_loader_mock = new Mock<IAssemblyLoader>();
			specification_manager = new SpecificationManager(file_reader_mock.Object, assembly_loader_mock.Object);
		};
	}
}

