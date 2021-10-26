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
        public int antal_pl { get; set; }
        public int postnr { get; set; }
        public string vejnavn { get; set; }
        public string kontakt_ved { get; set; }
    }
}
