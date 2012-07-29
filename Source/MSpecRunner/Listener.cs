using System;
using System.IO;
using Mono.CSharp;
using System.Text.RegularExpressions;
using Machine.Specifications.Runner;
using Machine.Specifications.Runner.Impl;
using System.Reflection;
using MonoDevelop.Ide;
using MonoDevelop.Ide.Gui;
using MonoDevelop.Ide.Gui.Content;
using Mono.TextEditor;
using MonoDevelop.Core.Execution;
using MonoDevelop.Ide.Gui.Pads;
using MonoDevelop.Core;

namespace MSpecRunner
{
	public class Listener : Machine.Specifications.Runner.Impl.RunListenerBase
	{
		static ProgressMonitorManager _manager = new ProgressMonitorManager();

		static IProgressMonitor _console;

		static Listener()
		{
			_console = _manager.GetOutputProgressMonitor("Machine.Specifications",(IconId)"md-pin-down",true,true);
		}

		public override void OnSpecificationStart (SpecificationInfo specification)
		{
			base.OnSpecificationStart (specification);
		}
		
		public override void OnSpecificationEnd (SpecificationInfo specification, Machine.Specifications.Result result)
		{
			_console.Log.WriteLine ("  It " + specification.Name);
			if (!result.Passed)
			{
				if (result.Exception != null) 
				{
					_console.Log.WriteLine ("Exception : " + result.Exception.Message);
					_console.Log.WriteLine ("StackTrace : " + result.Exception.StackTrace);
				} else if (!string.IsNullOrEmpty (result.ConsoleError)) 
				{
					Console.WriteLine(result.ConsoleError);
				}
			} 
			base.OnSpecificationEnd (specification, result);
		}
		
		public override void OnContextStart (ContextInfo context)
		{
			_console.Log.WriteLine (context.FullName);
			base.OnContextStart (context);
		}
		
		public override void OnContextEnd (ContextInfo context)
		{
			base.OnContextEnd (context);
		}
		
	}
}