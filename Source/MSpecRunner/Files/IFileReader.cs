using System;
using System.IO;

namespace MSpecRunner.Files
{
	public interface IFileReader
	{
		string	ReadAllText(string path);
	}
}

