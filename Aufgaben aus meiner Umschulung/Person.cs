using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Aufgaben_aus_meiner_Umschulung
{
    internal class Person
    {
        string _vorname;
        string _nachname;
        string _telnummer;
        string _email;

        public Person() { }

        public Person(string vorname, string nachname, string telnummer, string email)
        {
            _vorname = vorname;
            _nachname = nachname;
            if(TelGültig(telnummer)) _telnummer = TelNormalisieren(telnummer);
            else throw new Exception("Ungültige Telefonnummer!");
            if (EmailGültig(email)) _email = email;
            else throw new Exception("Ungültige E-Mail-Adresse!");
        }

        public override string ToString()
        {
            return $"Name: {_vorname} {_nachname}\nTel: {_telnummer}\nE-Mail: {_email}";
        }

        private bool TelGültig(String nummer)
        {
            return (Regex.IsMatch(nummer, @"^[+]{0,1}[0-9]+[ .-]{0,1}[0-9]+[ .-]{0,1}[0-9]*"));
        }

        private string TelNormalisieren(string tel)
        {
            return tel.Replace(" ", "").Replace(".", "").Replace("-", "").Replace("0049", "0").Replace("+49", "0");
        }

        private bool EmailGültig(string mail)
        {
            return (mail.Contains('@') && mail.Contains('.'));
        }
    }
}
