using System;

namespace MSpecRunner
{
	public interface ISourceReader
	{
		string Source { get; }
		string[] Lines { get; }
	}
}

