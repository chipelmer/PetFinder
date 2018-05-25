using System;
using System.Collections.Generic;
using System.Text;
using Finder.Shared;

namespace Finder.Repository
{
    public class Pet
    {
        public int Id { get; set; }
        public string HashedWord { get; set; }
        public PetType PetType { get; set; }
        public PetSize PetSize { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public DateTime DateLost { get; set; }
        public DateTime DateFound { get; set; }
        public string LostNumber { get; set; }
        public string FoundNumber { get; set; }
    }
}
