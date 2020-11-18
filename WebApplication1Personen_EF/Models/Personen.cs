using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1Personen_EF.Models
{
    [Serializable]
    public class Personen
    {

        public int Id { get; set; }


        public string Vorname { get; set; }


        public string Nachname { get; set; }


        public DateTime Geburtstag { get; set; }


        public string EmailAdr { get; set; }


        public string TelNummer { get; set; }

        //public Firmen Firma { get; set; }

        public virtual ICollection<Firmen> FirmenListe { get; set; }


        public int Geburtsjahr { get; set; }

    }
}