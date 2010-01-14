using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcTemplate.Web.Controllers;
using Moq;
using MvcTemplate.Model;
using System.Globalization;
using System.Security.Cryptography;

namespace MvcTemplate.Web.Tests
{
	[TestClass]
	public class BCryptEncryptorTests
	{
		[TestMethod]
		public void ShouldHashString()
		{
			// Arrange
			string str = "Test String";
			BCryptEncryptor encryptor = new BCryptEncryptor();
			
			// Act
			string strEncrypted = encryptor.Encrypt(str);

			// Assert
			Assert.AreNotEqual(strEncrypted, str);
		}

		[TestMethod]
		public void ShouldMatchStrings()
		{
			// Arrange
			string str = "Test String";
			BCryptEncryptor encryptor = new BCryptEncryptor();

			// Act
			string strEncrypted = encryptor.Encrypt(str);

			// Assert
			Assert.IsTrue(encryptor.IsMatch(str, strEncrypted));
		}

		[TestMethod]
		public void ShouldNotMatchStrings()
		{
			// Arrange
			string str = "Test String";
			BCryptEncryptor encryptor = new BCryptEncryptor();

			// Act
			string strEncrypted = encryptor.Encrypt(str);

			// Assert
			Assert.IsFalse(encryptor.IsMatch("testing", strEncrypted));
		}
	}
}
