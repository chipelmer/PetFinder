using System;

namespace Finder.Shared
{
    public class Pet
    {
        public int Id { get; set; }
        public PetType Type { get; set; }
        public PetSize Size { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public DateTime DateLost { get; set; }
        public DateTime DateFound { get; set; }
        public string LostNumber { get; set; }
        public string FoundNumber { get; set; }
    }
}
