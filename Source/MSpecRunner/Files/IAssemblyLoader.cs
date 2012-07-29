using System;
using System.Reflection;

namespace MSpecRunner.Files
{
	public interface IAssemblyLoader
	{
		Assembly	Load(string path);
	}
}

