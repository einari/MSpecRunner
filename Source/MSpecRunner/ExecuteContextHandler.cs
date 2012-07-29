using System;
using System.Linq;
using MonoDevelop.Components.Commands;
using MonoDevelop.Ide;
using MonoDevelop.Ide.Gui;
using MonoDevelop.Ide.Gui.Content;
using Mono.TextEditor;
using MSpecRunner.Ninject;
using Machine.Specifications.Runner;
using Machine.Specifications.Runner.Impl;
using Ninject;
using MSpecRunner.Specifications;


namespace MSpecRunner
{
    public class ExecuteContextHandler : CommandHandler
    {
		protected override void Run ()
		{
		    var doc = IdeApp.Workbench.ActiveDocument;
			/*
			var operation = doc.Build ();

			operation.WaitForCompleted();
			if( !operation.Success )
				return;*/

			//IdeApp.ProjectOperations.CurrentSelectedProject.Build()



		    var textEditorData = doc.GetContent<ITextEditorDataProvider> ().GetTextEditorData ();

			var project = IdeApp.Workspace.GetProjectContainingFile(doc.FileName);
			var targetFile = project.GetOutputFileName(project.DefaultConfiguration.Selector).FullPath;

			var sourceFile = doc.FileName;
			var lineNumber = textEditorData.Caret.Line;

			var kernel = new ConventionKernel ();
			var listener = new Listener ();
			var runner = new DefaultRunner (listener, new RunOptions (new string[] {  }, new string[] {  }, new string[] {} ));
			kernel.Bind<ISpecificationRunner> ().ToConstant (runner);
		
			var executor = kernel.Get<ISpecificationsExecutor> ();
			executor.Execute (targetFile, sourceFile, lineNumber);

			/*
			textEditorData.InsertAtCaret(
				string.Format("Target : {0} - Source : {1} - Line : {2}", 
			              targetFile, sourceFile, lineNumber));*/

				/*
		    string date = DateTime.Now.ToString ();
		    textEditorData.InsertAtCaret (date);*/
		}       

		protected override void Update (CommandInfo info)
		{
		    MonoDevelop.Ide.Gui.Document doc = IdeApp.Workbench.ActiveDocument;
		    info.Enabled = doc != null && doc.GetContent<ITextEditorDataProvider> () != null;
		}

    }
}