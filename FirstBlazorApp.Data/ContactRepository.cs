using Dapper;
using FirstBlazorApp.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstBlazorApp.Data
{
    public class ContactRepository : IContactRepository
    {
        private readonly IDbConnection _dbConnection;

        public ContactRepository(IDbConnection dbConnection)
        {

            _dbConnection = dbConnection;

        }

        public async Task Delete(int id)
        {
            var sql = @"DELETE FROM Contactos
                        WHERE Id = @Id";

            await _dbConnection.ExecuteAsync(sql, new { Id = id });
        }

        public async Task<IEnumerable<Contact>> GetAll()
        {
            var sql = @"SELECT Id, FirstName, LastName, Phone, Address
                        FROM Contactos";

            return await _dbConnection.QueryAsync<Contact>(sql, new { });
        }

        public async Task<Contact> GetDetails(int id)
        {
            var sql = @"SELECT Id, FirstName, LastName, Phone, Address
                        FROM Contactos 
                        WHERE Id = @Id";

            return await _dbConnection.QueryFirstOrDefaultAsync<Contact>(sql, new { Id = id });
        }

        public async Task Insert(Contact contactos)
        {
            var sql = @"INSERT INTO Contactos (FirstName, LastName, Phone, Address)
                         VALUES(@FirstName,@LastName,@Phone,@Address)";

            await _dbConnection.ExecuteAsync(sql, new
            {
                contactos.FirstName,
                contactos.LastName,
                contactos.Phone,
                contactos.Address
            });
        }

        public async Task Update(Contact contactos)
        {
            var sql = @"UPDATE Contactos 
                         SET FirstName = @FirstName, 
                                    LastName = @LastName, 
                                    Phone = @Phone, 
                                    Address = @Address 
                             WHERE Id = @Id";


            await _dbConnection.ExecuteAsync(sql, new
            {
                contactos.FirstName,
                contactos.LastName,
                contactos.Phone,
                contactos.Address,
                contactos.Id
            });
        }
    }
}
