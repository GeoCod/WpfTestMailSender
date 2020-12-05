using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTestMailSender.Data
{
    public static class PasswordClass
    {
        /// <summary>На вход подаем закодированный пароль, на выходе получаем дешифрованный пароль</summary>
        /// <param name="encodedPassw">Расшифрованный пароль</param>
        /// <returns></returns>
        public static string Encode(string encodedPassw)
        {
            string password = "";
            foreach (char a in encodedPassw)
            {
                char ch = a;
                ch--;
                password += ch;
            }

            return password;
        }
        /// <summary>На вход подаем пароль, на выходе получаем зашифрованный пароль</summary>
        /// <param name="codedPassword">Закодированный пароль</param>
        /// <returns>Раскодированный пароль</returns>
        public static string Decode(string codedPassword)
        {
            string sCode = "";
            foreach (char a in codedPassword)
            {
                char ch = a;
                ch++;
                sCode += ch;
            }
            return sCode;
        }

    }
}
