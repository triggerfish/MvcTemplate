using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MvcTemplate.Database.Tests
{
	[TestClass]
	public class TransactionTests : DatabaseTest
	{
		[TestMethod]
		public void ShouldRollbackIfExceptionThrown()
		{
			Genre g = new Genre { Name = "Pop" };
			Session.WithinTransaction(s => s.Save(g));

			try
			{
				g.Name = "Rock";
				Session.WithinTransaction(s => {
					s.Update(g);
					throw new Exception("Don't allow the commit"); 
				});
				Assert.IsFalse(true); // should never get here
			}
			catch (Exception ex)
			{
				Assert.AreEqual(ex.Message, "Don't allow the commit");
			}
		
			Session.Clear();
			g = Session.Get<Genre>(1);
			Assert.AreEqual(g.Name, "Pop");
		}
	}
}
