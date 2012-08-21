using System;
using System.Linq;
using MonoDevelop.Components.Commands;
using MonoDevelop.Ide;
using MonoDevelop.Ide.Gui;
using MonoDevelop.Ide.Gui.Content;
using MonoDevelop.Core.Execution;
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
			IdeApp.Workbench.SaveAll();


			var doc = IdeApp.Workbench.ActiveDocument;

			var textEditorData = doc.GetContent<ITextEditorDataProvider> ().GetTextEditorData ();

			var project = IdeApp.Workspace.GetProjectContainingFile (doc.FileName);
			var targetFile = project.GetOutputFileName (project.DefaultConfiguration.Selector).FullPath;

			var sourceFile = doc.FileName;
			var lineNumber = textEditorData.Caret.Line;

			var manager = new ProgressMonitorManager();
			var build = manager.GetBuildProgressMonitor ();

			IdeApp.ProjectOperations.CurrentSelectedProject.Build(build, project.DefaultConfiguration.Selector);


			IdeApp.Workbench.StatusBar.ShowMessage("Executing specifications");


			using (var context = IdeApp.Workbench.StatusBar.CreateContext()) 
			{

				var kernel = new ConventionKernel ();
				var listener = new Listener ();
				var runner = new DefaultRunner (listener, new RunOptions (new string[] {  }, new string[] {  }, new string[] {}));
				kernel.Bind<ISpecificationRunner> ().ToConstant (runner);
		
				var executor = kernel.Get<ISpecificationsExecutor> ();
				executor.Execute (targetFile, sourceFile, lineNumber);
			}

			IdeApp.Workbench.StatusBar.ShowMessage ("Specifications executed");
		}       

		protected override void Update (CommandInfo info)
		{
		    MonoDevelop.Ide.Gui.Document doc = IdeApp.Workbench.ActiveDocument;
		    info.Enabled = doc != null && doc.GetContent<ITextEditorDataProvider> () != null;
		}

    }
}














