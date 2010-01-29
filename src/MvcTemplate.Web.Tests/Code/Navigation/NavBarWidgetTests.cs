using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcTemplate.Model;
using MvcTemplate.Web.Tests;
using Moq;

namespace MvcTemplate.Web.Tests
{
	[TestClass]
	public class NavBarWidgetTests
	{
		[TestMethod]
		public void ShouldReturnNullIfNoGeneratorSet()
		{
			// arrange
			NavBarWidget widget = new NavBarWidget(null);

			// act
			IEnumerable<Hyperlink> links = widget.GenerateHyperlinks();

			// assert
			Assert.AreEqual(null, links);
		}

		[TestMethod]
		public void ShouldInvokeCreateMethod()
		{
			// arrange
			Mock<IHyperlinkGenerator> generator = new Mock<IHyperlinkGenerator>();
			generator.Setup(x => x.Create(It.IsAny<IHyperlinkGeneratorArguments>())).Returns<IEnumerable<Hyperlink>>(null);
			NavBarWidget widget = new NavBarWidget(generator.Object);

			// act
			IEnumerable<Hyperlink> links = widget.GenerateHyperlinks();

			// assert
			generator.Verify(x => x.Create(It.IsAny<IHyperlinkGeneratorArguments>()));
			Assert.AreEqual(null, links);
		}
	}

	internal class Generator : IHyperlinkGenerator
	{
		public IEnumerable<Hyperlink> Create(IHyperlinkGeneratorArguments arguments)
		{
			return null;
		}
	}
}
