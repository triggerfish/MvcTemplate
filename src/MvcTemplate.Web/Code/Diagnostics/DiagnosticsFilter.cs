using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace MvcTemplate.Web
{
	public class DiagnosticsFilter : MemoryStream
	{
		private Stream m_innerStream;
		private string m_text;

		public DiagnosticsFilter(Stream a_inner, string a_text)
		{
			m_innerStream = a_inner;
			m_text = a_text;
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
			string str = UTF8Encoding.UTF8.GetString(buffer);
			Regex r = new Regex("</body>", RegexOptions.Compiled | RegexOptions.Multiline);
			if (r.IsMatch(str))
			{
				str = r.Replace(str, m_text + "</body>");
				byte[] b = UTF8Encoding.UTF8.GetBytes(str);
				m_innerStream.Write(b, offset, b.Length);
			}
			else
			{
				m_innerStream.Write(buffer, offset, count);
			}
		}
	}
}
