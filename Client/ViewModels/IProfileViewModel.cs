using BlazingChat.Shared.Models;

namespace BlazingChat.ViewModels
{
    public interface IProfileViewModel
    {
        public long UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? EmailAddress { get; set; }
        public string? message { get; set; }

        public Task validateProfile();        

        public Task getProfileData();
    }
}