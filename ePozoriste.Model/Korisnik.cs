﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ePozoriste.Model
{
    public class Korisnik
    {
        public int KorisnikId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public string KorisnickoIme { get; set; }

       // public ICollection<KorisnikUloga> KorisnikUloga { get; set; }
    }
}
