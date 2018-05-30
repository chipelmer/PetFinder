using System;
using System.IO;
using System.Collections.Generic;
using Dapper;
using System.Data;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using Finder.Shared;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;

namespace Finder.Repository
{
    public class PetRepository : IPetRepo
    {
        private readonly IDbConnection _conn;

        public PetRepository()
        {
            string connStr = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
#if DEBUG
        .AddJsonFile("appsettings.Development.json")
#else
        .AddJsonFile("appsettings.json")
#endif
        .Build()
        .GetConnectionString("DefaultConnection");

            _conn = new MySqlConnection(connStr);
        }

        public PetRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        public int AddPet(Pet pet)
        {
            using (var conn = _conn)
            {
                var con = (MySqlConnection)conn;
                conn.Open();

                var cmd = new MySqlCommand(
                    "INSERT INTO lostpets (dateLost, loserContactNumber, dateFound, foundLocation, finderContactNumber, petSizesID, petTypesID) " +
                    "VALUES (@dL, @lL, @lCN, @dF, @fL, @fCN, @pSID, @pTID);"
                    , con);
                cmd.Parameters.AddWithValue("dL", pet.DateLost);
                cmd.Parameters.AddWithValue("lCN", pet.LostNumber);
                cmd.Parameters.AddWithValue("dF", pet.DateFound);
                cmd.Parameters.AddWithValue("fL", pet.Location);
                cmd.Parameters.AddWithValue("fCN", pet.FoundNumber);
                cmd.Parameters.AddWithValue("pSID", pet.Size.Id);
                cmd.Parameters.AddWithValue("pTID", pet.Type.Id);

                return cmd.ExecuteNonQuery();
            }
        }

        public int DeletePet(int id)
        {
            using (var conn = _conn)
            {
                conn.Open();
                return conn.Execute("DELETE FROM lostpets WHERE lostPetsID = @id;", new { id });
            }
        }

        public Pet GetPet(int id)
        {
            using (var conn = _conn)
            {
                var con = (MySqlConnection)conn;
                conn.Open();

                var cmd = new MySqlCommand(
                    "SELECT * FROM lostpets lp " +
                    "LEFT JOIN petsizes ps ON lp.petSizesId = ps.PetSizesId " +
                    "LEFT JOIN pettypes pt ON pt.petTypesId = lp.PetTypesID " +
                    "WHERE lp.lostPetsId=@lPID;"
                    , con);
                cmd.Parameters.AddWithValue("lPID", id);

                using (var myReader = cmd.ExecuteReader())
                {
                    while (myReader.Read())
                    {
                        DateTime? dateLost = null;
                        DateTime? dateFound = null;

                        if (DateTime.TryParse(myReader["dateLost"].ToString(), out var dl)) { dateLost = dl; }
                        if (DateTime.TryParse(myReader["dateFound"].ToString(), out var df)) { dateFound = df; }

                        return new Pet
                        {
                            Id = (int)myReader["lostPetsID"],
                            Description = myReader["petDescription"].ToString(),
                            Size = new PetSize { Id = (int)myReader["petSizesID"], Name = myReader["petSize"].ToString() },
                            Type = new PetType { Id = (int)myReader["petTypesID"], Name = myReader["petType"].ToString() },
                            Location = myReader["foundLocation"].ToString(),
                            DateLost = dateLost,
                            FoundNumber = myReader["finderContactNumber"].ToString(),
                            DateFound = dateFound,
                            LostNumber = myReader["loserContactNumber"].ToString()
                        });
                    }
                }
                return null;
            }
        }

        public IEnumerable<Pet> SearchPets(Pet pet)
        {
            using (var conn = _conn)
            {
                var con = (MySqlConnection)conn;
                conn.Open();

                var cmd = new MySqlCommand(
                    "SELECT * FROM lostpets lp " +
                    "LEFT JOIN petsizes ps ON lp.petSizesId = ps.PetSizesId " +
                    "LEFT JOIN pettypes pt ON pt.petTypesId = lp.PetTypesID " +
                    "WHERE ps.petSizesId=@SizeId AND pt.petTypesId=@TypeId;"
                    , con);
                cmd.Parameters.AddWithValue("SizeId", pet.Size.Id);
                cmd.Parameters.AddWithValue("TypeId", pet.Type.Id);

                var pets = new List<Pet>();
                using (var myReader = cmd.ExecuteReader())
                {
                    while (myReader.Read())
                    {
                        DateTime? dateLost = null;
                        DateTime? dateFound = null;

                        if (DateTime.TryParse(myReader["dateLost"].ToString(), out var dl)) { dateLost = dl; }
                        if (DateTime.TryParse(myReader["dateFound"].ToString(), out var df)) { dateFound = df; }

                        pets.Add(new Pet
                        {
                            Id = (int)myReader["lostPetsID"],
                            Description = myReader["petDescription"].ToString(),
                            Size = new PetSize { Id = (int)myReader["petSizesID"], Name = myReader["petSize"].ToString() },
                            Type = new PetType { Id = (int)myReader["petTypesID"], Name = myReader["petType"].ToString() },
                            Location = myReader["foundLocation"].ToString(),
                            DateLost = dateLost,
                            FoundNumber = myReader["finderContactNumber"].ToString(),
                            DateFound = dateFound,
                            LostNumber = myReader["loserContactNumber"].ToString()
                        });
                    }
                }
                return pets;
            }
        }

        public IEnumerable<PetSize> GetPetSizes()
        {
            using (var conn = _conn)
            {
                conn.Open();
                return conn.Query<PetSize>("SELECT PetSizesId AS Id, PetSize AS Name FROM petsizes;");
            }
        }

        public IEnumerable<PetType> GetPetTypes()
        {
            using (var conn = _conn)
            {
                conn.Open();
                return conn.Query<PetType>("SELECT petTypesID AS Id, petType AS Name FROM pettypes;");
            }
        }
    }
}
