using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web;
using System.Security.Principal;
using MvcTemplate.Model;

namespace MvcTemplate.Web
{
	public interface IEncryptor
	{
		string Encrypt(string a_plainText);
		bool IsMatch(string a_plainText, string a_encryptedText);
	}
}
