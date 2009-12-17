using System;
using Ninject;
using Ninject.Modules;

namespace MvcTemplate.Model
{
    public static class ObjectFactory
    {
		private static readonly IKernel m_kernel = new StandardKernel(new ModelDependencies());

		public static IKernel Kernel
		{
			get { return m_kernel; }
		}

        public static T Get<T>()
        {
            return Kernel.Get<T>();
        }

        public static T Get<T>(Type type)
        {
			return (T)Kernel.Get(type);
        }

        public static T TryGet<T>()
        {
			return Kernel.TryGet<T>();
        }

        public static T TryGet<T>(Type type)
        {
			return (T)Kernel.TryGet(type);
        }

        public static void Load(INinjectModule module)
        {
			Kernel.Load(module);
        }
    }
}