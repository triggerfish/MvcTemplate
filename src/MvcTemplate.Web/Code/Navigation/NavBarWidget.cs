using System;
using Triggerfish.Ninject;
using System.Collections.Generic;

namespace MvcTemplate.Web
{
	public class NavBarWidget : IHyperlinkGeneratorArguments
	{
		private Type m_generatorType;

		public Type HyperlinkGenerator 
		{
			get { return m_generatorType; }
			set
			{
				if (value == typeof(IHyperlinkGenerator))
					throw new ArgumentException("Must be of type IHyperlinkGenerator");
				m_generatorType = value;
			}
		}

		public string Selected { get; set; }

		public IEnumerable<Hyperlink> GenerateHyperlinks()
		{
			if (null != m_generatorType)
			{
				IHyperlinkGenerator gen = ObjectFactory.TryGet<IHyperlinkGenerator>(m_generatorType);

				if (null != gen)
				{
					return gen.Create(this);
				}
			}
			return null;
		}
	}
}
