using System;

namespace MSpecRunner.Specifications
{
	public interface ISpecificationsExecutor
	{
		void Execute(string targetPath, string sourceFile, int lineNumber);
	}
}

