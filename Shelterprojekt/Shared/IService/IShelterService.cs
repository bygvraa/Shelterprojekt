using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shelterprojekt.Shared.IService
{
    public interface IShelterService
    {
        void SaveOrUpdate(Shelter shelter);
        Shelter GetShelter(string shelterNavn);
        List<Shelter> GetShelters();
        string Delete(string shelterNavn);
    }
}
