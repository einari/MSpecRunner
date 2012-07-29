using System;
using Ninject;
using System.Collections.Generic;
using Ninject.Activation;

namespace MSpecRunner.Ninject
{
	public class ConventionKernel : StandardKernel
	{
		

		public override IEnumerable<object> Resolve (IRequest request)
		{
			var serviceInstanceType = GetServiceInstanceType (request);
			if (null != serviceInstanceType) {
				var service = request.Service;
				Bind (service).To (serviceInstanceType);
			}			
			
			
			return base.Resolve (request);
		}
		
		private static Type GetServiceInstanceType (IRequest request)
		{
			var service = request.Service;
			var serviceName = service.Name;
			if (serviceName.StartsWith ("I")) {
				var instanceName = string.Format ("{0}.{1}", service.Namespace, serviceName.Substring (1));
				var serviceInstanceType = service.Assembly.GetType (instanceName);
				if (null != serviceInstanceType) {
					if (serviceInstanceType.IsAbstract) {
						return null;
					}
					
					return serviceInstanceType;
				}
			}
			return null;
		}
		
		
	}
}
