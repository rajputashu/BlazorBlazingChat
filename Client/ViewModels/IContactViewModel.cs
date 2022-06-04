using BlazingChat.Shared;

namespace BlazingChat.ViewModels
{
    public interface IContactViewModel
    {
        public List<Contact>? _contactList { set; get; }

        public Task getContactList();
    }
}