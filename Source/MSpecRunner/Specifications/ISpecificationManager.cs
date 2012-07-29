using System;
using System.IO;
using System.Text.RegularExpressions;

namespace MSpecRunner.Specifications
{
	public interface ISpecificationManager
	{
		SpecificationsToRun GetSpecificationsToRun(string targetPath, string sourcePath, int lineNumber);
	}
}
