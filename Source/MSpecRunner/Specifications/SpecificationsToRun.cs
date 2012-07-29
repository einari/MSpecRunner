using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Reflection;

namespace MSpecRunner.Specifications
{
	public class SpecificationsToRun
	{
		public Assembly TargetAssembly { get; set; }
		public string Namespace { get; set; }
		public string ClassName { get; set; }
		public Type Type { get; set; }
		public MemberInfo[] Specifications { get; set; }
		
		
		public bool HasClass {
			get { return !string.IsNullOrEmpty (ClassName); }
		}
		
		public bool HasSpecifications {
			get { return Specifications != null && Specifications.Length > 0 && HasClass; }
		}
		
	}
}
