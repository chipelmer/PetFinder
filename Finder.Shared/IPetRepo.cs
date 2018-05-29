using System.Collections.Generic;

namespace Finder.Shared
{
    public interface IPetRepo
    {
        IEnumerable<Pet> SearchPets();
        Pet GetPet(int id);
        IEnumerable<Pet> GetPetSizes();
        IEnumerable<Pet> GetPetTypes();
        IEnumerable<PetSize> GetPetSizes2();
        IEnumerable<PetType> GetPetTypes2();
        int DeletePet(int id);
        int UpdatePet(Pet pet);
        int AddPet(Pet pet);
    }
}
