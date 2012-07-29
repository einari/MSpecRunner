
using System;
using System.IO;
using Mono.CSharp;
using System.Text.RegularExpressions;
using Machine.Specifications.Runner;
using Machine.Specifications.Runner.Impl;
using System.Reflection;
namespace MonoDevelop.MSpecRunner
{
	public class Listener : Machine.Specifications.Runner.Impl.RunListenerBase
	{
		public override void OnSpecificationStart (SpecificationInfo specification)
		{
			base.OnSpecificationStart (specification);
		}
		
		public override void OnSpecificationEnd (SpecificationInfo specification, Machine.Specifications.Result result)
		{
			Console.WriteLine ("  It " + specification.Name);
			if (!result.Passed)
			{
				if (result.Exception != null) 
				{
					Console.WriteLine ("Exception : " + result.Exception.Message);
					Console.WriteLine ("StackTrace : " + result.Exception.StackTrace);
				} else if (!string.IsNullOrEmpty (result.ConsoleError)) 
				{
					Console.WriteLine(result.ConsoleError);
				}
			} 
			base.OnSpecificationEnd (specification, result);
		}
		
		public override void OnContextStart (ContextInfo context)
		{
			Console.WriteLine (context.FullName);
			base.OnContextStart (context);
		}
		
		public override void OnContextEnd (ContextInfo context)
		{
			Console.WriteLine("");
			base.OnContextEnd (context);
		}
		
	}
}
