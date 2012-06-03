using System;
using Castle.Windsor;
using ServiceStack.Configuration;

namespace Bartender
{
	public class WindsorContainerAdapter : IContainerAdapter, IDisposable
	{
		private readonly IWindsorContainer container;

		public WindsorContainerAdapter(IWindsorContainer container)
		{
			this.container = container;
		}

		public T TryResolve<T>()
		{
			if (container.Kernel.HasComponent(typeof(T)))
			{
				return (T)container.Resolve(typeof(T));
			}

			return default(T);
		}

		public T Resolve<T>()
		{
			return container.Resolve<T>();
		}

		public void Dispose()
		{
			container.Dispose();
		}
	}
}