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

namespace MSpecRunner
{
	public class Listener : Machine.Specifications.Runner.Impl.RunListenerBase
	{
		public override void OnSpecificationStart (SpecificationInfo specification)
		{
			base.OnSpecificationStart (specification);
		}
		
		public override void OnSpecificationEnd (SpecificationInfo specification, Machine.Specifications.Result result)
		{
		    var doc = IdeApp.Workbench.ActiveDocument;
		    var textEditorData = doc.GetContent<ITextEditorDataProvider> ().GetTextEditorData ();

			textEditorData.InsertAtCaret ("  It " + specification.Name);

			Console.WriteLine ("  It " + specification.Name);
			if (!result.Passed)
			{
				if (result.Exception != null) 
				{
					textEditorData.InsertAtCaret ("Exception : " + result.Exception.Message);
					textEditorData.InsertAtCaret ("StackTrace : " + result.Exception.StackTrace);


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
		    var doc = IdeApp.Workbench.ActiveDocument;
		    var textEditorData = doc.GetContent<ITextEditorDataProvider> ().GetTextEditorData ();
			textEditorData.InsertAtCaret(context.FullName);
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
