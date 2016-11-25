using System;
using System.Text;

namespace TelefonoAndriod
{
	public static class Traductor
	{
		public static string TraduceNumeroACadena( string num )
		{
			if (string.IsNullOrWhiteSpace(num))
			{
				return "";
			}
			else {
				num = num.ToUpperInvariant();
			}

			var nuevoNumero = new StringBuilder();

			foreach ( var c in num )
			{
				if (" -0123456789".Contains(c))
				{
					nuevoNumero.Append(c);
				}
				else {
					var resultado = TraduceNumeroACadena( c );
					if (resultado != null)
					{
						nuevoNumero.Append( resultado );
					}
				}
			}

			return nuevoNumero.ToString();
		}

		static bool Contains(this string keyString, char c)
		{
			return keyString.IndexOf(c) >= 0;
		}

		static int? TraduceNumeroACadena(char c)
		{
			if ("ABC".Contains(c))
			{
				return 2;
			}
			else if ("DEF".Contains(c))
			{
				return 3;
			}
			else if ("GHI".Contains(c))
			{
				return 4;
			}
			else if ("JKL".Contains(c))
			{
				return 5;
			}
			else if ("MNO".Contains(c))
			{
				return 6;
			}
			else if ("PQRS".Contains(c))
			{
				return 7;
			}
			else if ("TUV".Contains(c))
			{
				return 8;
			}
			else if ("WXYZ".Contains(c))
			{
				return 9;
			}
			else
			{
				return null;
			}
		}
	}
}
