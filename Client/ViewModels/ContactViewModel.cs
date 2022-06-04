

using System.Net.Http.Json;
using BlazingChat.Client;
using BlazingChat.Shared;

namespace BlazingChat.ViewModels
{
    public class ContactViewModel : IContactViewModel
    {
        public List<Contact>? _contactList { set; get; }

        private HttpClient? _httpClient;

        public ContactViewModel()
        {

        }

        public ContactViewModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task getContactList()
        {
            List<Contact>? contacts = await _httpClient!.GetFromJsonAsync<List<Contact>>("user/getcontacts");
            LoadCurrentObject(contacts!);
        }

        private void LoadCurrentObject(List<Contact> dbContacts)
        {
            _contactList = new List<Contact>();
            foreach (Contact contact in dbContacts)
            {
                _contactList.Add(contact);
            }
        }
    }
}