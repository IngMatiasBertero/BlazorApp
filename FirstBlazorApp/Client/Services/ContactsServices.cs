using FirstBlazorApp.Shared;
using System.Net.Http.Json;

namespace FirstBlazorApp.Client.Services
{
    public class ContactsServices : IContactsServices
    {
        private readonly HttpClient _httpClient;

        public ContactsServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task Delete(int id)
        {
            await _httpClient.DeleteAsync($"api/contacts/{id}");
        }

        public async Task<IEnumerable<Contact>> GetAll()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Contact>>($"api/contacts/");
        }

        public async Task<Contact> GetDetails(int id)
        {
            return await _httpClient.GetFromJsonAsync<Contact>($"api/contacts/{id}");
        }

        public async Task Save(Contact contact)
        {
            if (contact.Id == 0)
            {
                //Insert
                await _httpClient.PostAsJsonAsync<Contact>($"api/contacts/", contact);
            }
            else
            {
                //Update
                await _httpClient.PutAsJsonAsync<Contact>($"api/contacts/{contact.Id}", contact);

            }

        }
    }
}
