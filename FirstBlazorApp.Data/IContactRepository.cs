using FirstBlazorApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstBlazorApp.Data
{
    public interface IContactRepository
    {
        Task<IEnumerable<Contact>> GetAll();
        Task<Contact> GetDetails(int id);
        Task Insert(Contact contactos);
        Task Update(Contact contactos);
        Task Delete(int id);

    }
}
