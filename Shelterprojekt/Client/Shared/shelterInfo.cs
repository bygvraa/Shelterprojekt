using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shelterprojekt.Client.Shared
{
    public class shelterInfo
    {

        public string navn { get; set; }
        public string cvr_navn { get; set; }
        public string handicap { get; set; }
        public string antal_pl { get; set; }
        public string postnr { get; set; }
        public string vejnavn { get; set; }
        public string kontakt_ved { get; set; }

        public shelterInfo(string navn, string cvr_navn, string handicap, string antal_pl, string postnr, string vejnavn, string kontakt_ved)
        {
            this.navn = navn;
            this.cvr_navn = cvr_navn;
            this.handicap = handicap;
            this.antal_pl = antal_pl;
            this.postnr = postnr;
            this.vejnavn = vejnavn;
            this.kontakt_ved = kontakt_ved;

        }
    }
}
