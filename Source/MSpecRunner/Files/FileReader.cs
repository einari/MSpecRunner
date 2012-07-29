using System;
using System.IO;

namespace MSpecRunner.Files
{
	public class FileReader : IFileReader
	{
		
		public string ReadAllText (string path)
		{
			var text = File.ReadAllText (path);
			return text;
		}
		
	}
}
