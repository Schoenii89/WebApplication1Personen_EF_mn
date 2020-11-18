using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1Personen_EF.Models
{
    public class Firmen
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PLZ { get; set; }

        public virtual ICollection<Personen> PersonenListe { get; set; }

    }
}