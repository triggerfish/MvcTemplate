using System;
using Triggerfish.Ninject;
using System.Collections.Generic;

namespace MvcTemplate.Web
{
	public class NavBarWidget : IHyperlinkGeneratorArguments
	{
		private IHyperlinkGenerator m_generator;

		public string Selected { get; set; }

		public NavBarWidget(IHyperlinkGenerator generator)
		{
			m_generator = generator;
		}

		public IEnumerable<Hyperlink> GenerateHyperlinks()
		{
			if (null != m_generator)
			{
				return m_generator.Create(this);
			}
			return null;
		}
	}
}
