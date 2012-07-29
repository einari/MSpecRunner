using System;
using Machine.Specifications;
using MSpecRunner.Specifications;
namespace MSpecRunner.Specs.Specifications.for_SpecificationsToRun.given
{
	public class a_specifications_to_run_instance
	{
		protected static SpecificationsToRun	specifications_to_run;
		
		Establish	context = () => specifications_to_run = new SpecificationsToRun();
	}
}

