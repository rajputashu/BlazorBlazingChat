using System.Net.Http.Json;
using BlazingChat.Shared.Models;

namespace BlazingChat.ViewModels
{
    public class ProfileViewModel : IProfileViewModel
    {
        public long UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? EmailAddress { get; set; }
        public string? message { get; set; }

        private HttpClient? _httpClient;

        public ProfileViewModel()
        {
        }

        public ProfileViewModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public static implicit operator ProfileViewModel(User user)
        {
            return new ProfileViewModel
            {
                UserId = user.UserId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                EmailAddress = user.EmailAddress
            };
        }

        public static implicit operator User(ProfileViewModel profileViewModel)
        {
            return new User
            {
                UserId = profileViewModel.UserId,
                FirstName = profileViewModel.FirstName,
                LastName = profileViewModel.LastName,
                EmailAddress = profileViewModel.EmailAddress!
            };
        }

        public async Task validateProfile()
        {
            User updatedUser = this;
            await _httpClient!.PutAsJsonAsync("user/updateprofile/9", updatedUser);
            this.message = "Profile updated";
        }

        // public async Task getProfileData()
        public async Task getProfileData()
        {
            User? user = await _httpClient!.GetFromJsonAsync<User>("user/getprofile/9");
            // profileViewModel = user!;
            convertUserToViewModel(user!);
            this.message = "Fetched data from profile";
        }

        public void convertUserToViewModel(ProfileViewModel profileViewModel)
        {
            this.UserId = profileViewModel.UserId;
            this.FirstName = profileViewModel.FirstName;
            this.LastName = profileViewModel.LastName;
            this.EmailAddress = profileViewModel.EmailAddress;

        }
    }

}