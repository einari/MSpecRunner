
using System;
using Machine.Specifications;
using MSpecRunner.Specifications;
using Moq;
using System.IO;
namespace MSpecRunner.Specs.Specifications.for_SpecificationManager.given
{
	public class a_specification_manager_with_an_assembly_and_a_source_file : a_specification_manager
	{
		Establish context = () =>
		{
			file_reader_mock.Setup (f => f.ReadAllText (Moq.It.IsAny<string> ())).Returns (File.ReadAllText ("FakeSpecs.cs"));
			assembly_loader_mock.Setup (a => a.Load (Moq.It.IsAny<string> ())).Returns (typeof(FakeSpecs).Assembly);
		};
	}
}
