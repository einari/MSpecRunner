using System;
using System.Reflection;

namespace MSpecRunner.Files
{
	public class AssemblyLoader : IAssemblyLoader
	{
		public Assembly Load (string path)
		{
			var assembly = Assembly.LoadFile (path);
			return assembly;
		}
	}
}
