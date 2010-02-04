using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentNHibernate.Testing;
using NHibernate;

namespace MvcTemplate.Database.Tests
{
	[TestClass]
	public class UserTests : DatabaseTest
	{
		[TestMethod]
		public void ShouldHaveCorrectMappings()
		{
			new PersistenceSpecification<User>(Session)
				.CheckProperty(x => x.Id, 1) //identity starts at 1 - can't reset to zero
				.CheckProperty(x => x.Forename, "User")
				.CheckProperty(x => x.Surname, "One")
				.CheckProperty(x => x.Credentials.Email, "userone@test.com")
				.CheckProperty(x => x.Credentials.Password, "password")
				.VerifyTheMappings();
		}
	}
}
