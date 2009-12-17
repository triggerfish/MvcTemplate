using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Routing;
using Moq;

namespace MvcTemplate.Web.Tests
{
	internal static class MockHttp
	{
		public static Mock<HttpContextBase> MakeMockHttpContext(string url)
		{
			var context = new Mock<HttpContextBase>();

			// Mock the request
			var request = new Mock<HttpRequestBase>();
			context.Setup(x => x.Request).Returns(request.Object);
			request.Setup(x => x.AppRelativeCurrentExecutionFilePath).Returns(url);

			// Mock the response
			var mockResponse = new Mock<HttpResponseBase>();
			context.Setup(x => x.Response).Returns(mockResponse.Object);
			mockResponse.Setup(x => x.ApplyAppPathModifier(It.IsAny<string>())).Returns<string>(x => x);

			return context;
		}

		public static VirtualPathData GenerateUrlViaMocks(object a_route)
		{
			return GenerateUrlViaMocks(new RouteValueDictionary(a_route));
		}

		public static VirtualPathData GenerateUrlViaMocks(RouteValueDictionary a_route)
		{
			// Arrange (get the routing config and test context)
			RouteCollection routeConfig = new RouteCollection();
			MvcApplication.RegisterRoutes(routeConfig);

			var mockContext = MakeMockHttpContext(null);
			RequestContext context = new RequestContext(mockContext.Object, new RouteData());

			// Act (generate a URL)
			return routeConfig.GetVirtualPath(context, a_route);
		}

		public static bool IsValidOutboundUrl(RouteValueDictionary a_route, string a_expectedUrl)
		{
			VirtualPathData result = MockHttp.GenerateUrlViaMocks(a_route);

			return (a_expectedUrl == result.VirtualPath);
		}
	}
}
