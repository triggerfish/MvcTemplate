using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web;
using System.Security.Principal;
using System.Security.Cryptography;

namespace MvcTemplate.Web
{
	public sealed class BCryptEncryptor : IEncryptor
	{
		public string Encrypt(string a_plainText)
		{
			return BCrypt.HashPassword(a_plainText, BCrypt.GenerateSalt());
		}

		public bool IsMatch(string a_plainText, string a_encryptedText)
		{
			return BCrypt.CheckPassword(a_plainText, a_encryptedText);
		}
	}
}
