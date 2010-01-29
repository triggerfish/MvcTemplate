using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcTemplate.Web.Controllers;
using Moq;
using Triggerfish.Validator;

namespace MvcTemplate.Web.Tests
{
	[TestClass]
	public class ModelBinderTests
	{
		[TestMethod]
		public void ShouldValidate()
		{
			// Arrange
			Mock<IValidator> validator = new Mock<IValidator>();
			validator.Setup(x => x.Validate(It.IsAny<object>()));
			
			TestModelBinder binder = new TestModelBinder(validator.Object);

			ModelBindingContext ctx = BinderHelpers.CreateModelBindingContext("key", "value");
			
			// Act
			string s = binder.BindModel(null, ctx) as string;

			// Assert
			validator.Verify(x => x.Validate(s));
		}

		[TestMethod]
		public void ShouldHaveModelErrorIfValidateFails()
		{
			// Arrange
			Mock<IValidator> validator = new Mock<IValidator>();
			validator.Setup(x => x.Validate(It.IsAny<object>())).Throws(new ValidationException("key", "Invalid"));

			TestModelBinder binder = new TestModelBinder(validator.Object);

			ModelBindingContext ctx = BinderHelpers.CreateModelBindingContext("key", "value");

			// Act
			string s = binder.BindModel(null, ctx) as string;

			// Assert
			validator.Verify(x => x.Validate(It.IsAny<object>()));
			Assert.AreEqual(1, ctx.ModelState["key"].Errors.Count);
		}
	}

	internal class TestModelBinder : ModelBinder<string>
	{
		public TestModelBinder(IValidator validator) : base(validator) { }
		protected override object Bind()
		{
			return GetValue("key", false);
		}
	}
}
