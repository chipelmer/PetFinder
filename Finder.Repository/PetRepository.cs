﻿using System;
using System.Collections.Generic;
using Dapper;
using System.Data;
using System.Threading.Tasks;
using Finder.Shared;

namespace Finder.Repository
{
    public class PetRepository : IPetRepo
    {
        private readonly IDbConnection _conn;

        public PetRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        public int AddPet(Pet pet)
        {
            using (var conn = _conn)
            {
                conn.Open();
                return conn.Execute("INSERT INTO lostpets (HashedWord, PetDescription, Picture, DateLost, FinderContactNumber, DateFound, Type, PetSize) VALUES (@HashedWord, @Description, @DateLost, @FindNumber, @DateFound, @Type, @Size);", pet);
            }
        }

        public int DeletePet(int id)
        {
            using (var conn = _conn)
            {
                conn.Open();
                return conn.Execute("DELETE FROM lostpets WHERE lostpets.Id = @id;", new Pet { Id = id });
            }
        }

        public async Task<Pet> GetPet(int id)
        {
            using (var conn = _conn)
            {
                conn.Open();
                return await conn.QueryFirstAsync<Pet>("SELECT * FROM lostpets lp LEFT OUTER JOIN petsize ps ON lp.Id = ps.Id LEFT OUTER JOIN pettype pt ON pt.Id = lp.ID WHERE lp.Id = @id;", new Pet { Id = id });
            }
        }

        public async Task<IEnumerable<Pet>> SearchPets()
        {
            using (var conn = _conn)
            {
                conn.Open();
                return await conn.QueryAsync<Pet>("SELECT * FROM lostpets lp LEFT OUTER JOIN petsize ps ON lp.PetSizesId = ps.PetSizesId LEFT OUTER JOIN pettype pt ON pt.PetTypeId = lp.PetTypeID;");
            }
        }

        public async Task<IEnumerable<PetSize>> GetPetSizes()
        {
            using (var conn = _conn)
            {
                conn.Open();
                return await conn.QueryAsync<PetSize>("SELECT PetSizeId, PetSize FROM petsizes;");
            }
        }

        public async Task<IEnumerable<PetType>> GetPetTypes()
        {
            using (var conn = _conn)
            {
                conn.Open();
                return await conn.QueryAsync<PetType>("SELECT PetTypeId, PetType from pettypes;");
            }
        }

        public int UpdatePet(Pet pet)
        {
            using (var conn = _conn)
            {
                conn.Open();
                return conn.Execute("UPDATE lostpets SET PetType = @Type, PetSize = @Size, Location = @Location, PetDescription = @Description, DatePetLost = @DateLost, DatePetFound = @DateFound, LostNumber = @LostNumber, FoundNumber = @FoundNumber WHERE LostPet.Id = @Id;", pet);
            }
        }


    }
}
