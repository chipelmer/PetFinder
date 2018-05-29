using System.Collections.Generic;

namespace Finder.Shared
{
    public interface IPetRepo
    {
        IEnumerable<Pet> SearchPets();
        Pet GetPet(int id);
        int DeletePet(int id);
        int UpdatePet(Pet pet);
        int AddPet(Pet pet);
        IEnumerable<Pet> GetPetSizes();
        IEnumerable<Pet> GetPetTypes();
    }
}
