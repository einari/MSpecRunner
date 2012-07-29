using System;
namespace MonoDevelop.MSpecRunner
{
	public interface ISourceReader
	{
		string Source { get; }
		string[] Lines { get; }
	}
}

