using System;
using Machine.Specifications.Runner;

namespace MSpecRunner.Specifications
{
	public class SpecificationsExecutor : ISpecificationsExecutor
	{
		ISpecificationManager _specificationManager;
		ISpecificationRunner _runner;
		
		public SpecificationsExecutor (ISpecificationManager specificationManager, ISpecificationRunner runner)
		{
			_specificationManager = specificationManager;
			_runner = runner;
		}
		
		
		public void Execute (string targetPath, string sourceFile, int lineNumber)
		{
			var specificationsToRun = _specificationManager.GetSpecificationsToRun (targetPath, sourceFile, lineNumber);
			if (specificationsToRun != null)
			{
				if (specificationsToRun.HasSpecifications)
				{
					foreach( var specification in specificationsToRun.Specifications )
						_runner.RunMember(specificationsToRun.TargetAssembly, specification);
				} else
				{
					_runner.RunNamespace (specificationsToRun.TargetAssembly, specificationsToRun.Namespace);
				}
			}
		}
	}
}
