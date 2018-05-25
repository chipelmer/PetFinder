using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Finder.Shared;
using Microsoft.AspNet.Identity;

namespace Finder.Repository
{
    public interface IPetRepo
    {
        Task<IEnumerable<Pet>> SearchPets();
        Task<Pet> GetPet(int id);
        Task<IEnumerable<PetSize>> GetPetSizes();
        Task<IEnumerable<PetType>> GetPetTypes();
        IPasswordHasher GetPassword();
        int DeletePet(int id);
        int UpdatePet(Pet pet);
        int AddPet(Pet pet);
    }
}
