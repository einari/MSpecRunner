using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;
using System.Reflection;
using Machine.Specifications;
using MSpecRunner.Files;

namespace MSpecRunner.Specifications
{
	public class SpecificationManager : ISpecificationManager
	{
		private IFileReader _fileReader;
		private IAssemblyLoader _assemblyLoader;
		
		public SpecificationManager (IFileReader fileReader, IAssemblyLoader assemblyLoader)
		{
			_fileReader = fileReader;
			_assemblyLoader = assemblyLoader;
		}
		
		public SpecificationsToRun GetSpecificationsToRun (string targetPath, string sourcePath, int lineNumber)
		{
			var specificationsToRun = new SpecificationsToRun ();
			specificationsToRun.TargetAssembly = _assemblyLoader.Load(targetPath);
			
			var source = _fileReader.ReadAllText (sourcePath);
			var lines = source.Split ('\n');
			var currentLine = lines[lineNumber];
			specificationsToRun.Namespace = GetNamespace (source);
			specificationsToRun.ClassName = GetClass (lines, lineNumber);
			var specification = GetSpecificationName (currentLine);
			var type = specificationsToRun.TargetAssembly.GetType (specificationsToRun.Namespace + "." + specificationsToRun.ClassName);

		
			if (!string.IsNullOrEmpty (specification) && type != null) {
				var specificationMember = type.GetField (specification, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
				if (specificationMember != null)
					specificationsToRun.Specifications = new[] { specificationMember };
			} else {
				if (type != null) {
					var query = from f in type.GetFields (BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
						where f.FieldType.Equals (typeof(It))
						select f;
					
					specificationsToRun.Specifications = query.ToArray();
				}
			}
			
			return specificationsToRun;
		}
		
		
		static string GetClass (string[] lines, int lineNumber)
		{
			for (var lineIndex = lineNumber; lineIndex > 0; lineIndex--) {
				var line = lines[lineIndex];
				var className = GetClassFromLine (line);
				if (!string.IsNullOrEmpty (className)) {
					return className;
				}
			}
			
			for (var lineIndex = lineNumber; lineIndex < lines.Length; lineIndex++) {
				var line = lines[lineIndex];
				var className = GetClassFromLine (line);
				if (!string.IsNullOrEmpty (className)) {
					return className;
				}
			}
			
			
			return string.Empty;
		}

		static string GetClassFromLine (string line)
		{
			var classRegex = new Regex (@"[ \w]*[\t ]*class ([\w.]*)");
			var match = classRegex.Match (line);
			if (match.Success && match.Groups.Count >= 2) {
				var className = match.Groups[1].Value.Trim ();
				return className;
			}
			
			return string.Empty;
			
		}


		private static string GetNamespace (string source)
		{
			var namespaceRegex = new Regex (@"[ \w\n]*[\t ]*namespace ([\w.]*)");
			var match = namespaceRegex.Match (source);
			if (match.Success && match.Groups.Count >= 2) {
				var ns = match.Groups[1].Value.Trim ();
				return ns;
			}
			
			return string.Empty;
		}

		private static string GetSpecificationName (string line)
		{
			var specificationRegex = new Regex (@"[ \w]*It[ \t]*([\w_]*)");
			var match = specificationRegex.Match (line);
			if (match.Success && match.Groups.Count >= 2) {
				var specification = match.Groups[1].Value.Trim ();
				return specification;
			}
			return string.Empty;
		}
		
	}
}

