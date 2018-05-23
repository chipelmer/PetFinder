using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Finder.Repository
{
    public interface IPetRepo
    {
        Task<IEnumerable<Pet>> SearchPets();
        Task<Pet> GetPet(int id);
        Task<IEnumerable<Pet>> GetPetSizes();
        Task<IEnumerable<Pet>> GetPetTypes();
        int DeletePet(int id);
        int UpdatePet(Pet pet);
        int AddPet(Pet pet);
    }
}
