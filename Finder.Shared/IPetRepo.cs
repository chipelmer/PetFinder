using System.Collections.Generic;

namespace Finder.Shared
{
    public interface IPetRepo
    {
        IEnumerable<Pet> SearchPets(Pet pet);
        Pet GetPet(int id);
        int DeletePet(int id);
        //int UpdatePet(Pet pet);
        int AddPet(Pet pet);
        IEnumerable<PetSize> GetPetSizes();
        IEnumerable<PetType> GetPetTypes();
    }
}
