using System.Net.Http.Json;
using BlazingChat.Shared.Models;

namespace BlazingChat.ViewModels
{
    public class SettingsViewModel : ISettingsViewModel
    {
        public bool Notifications { get; set; }

        public bool DarkTheme { get; set; }

        private HttpClient? _httpClient;

        public SettingsViewModel()
        {

        }

        public SettingsViewModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task getSettingDetails()
        {
            User? user = await _httpClient!.GetFromJsonAsync<User>("user/getprofile/10");
            LoadCurrentObject(user!); // This is only applicable when we use operator -> SettingsViewModel
        }

        public async Task updateSettingDetails()
        {
            // await _httpClient!.GetFromJsonAsync<User>($"user/updatetheme?userId={10}&value={this.DarkTheme.ToString()}");

            // await _httpClient!.GetFromJsonAsync<User>($"user/updatenotifications?userId={10}&value={this.Notifications.ToString()}");
        }

        private void LoadCurrentObject(SettingsViewModel settingsViewModel)
        {
            this.DarkTheme = settingsViewModel.DarkTheme;
            this.Notifications = settingsViewModel.Notifications;
        }

        public static implicit operator SettingsViewModel(User user)
        {
            return new SettingsViewModel
            {
                Notifications = (user.Notifications == null || (long)user.Notifications == 0) ? false : true,
                DarkTheme = (user.DarkTheme == null || (long)user.DarkTheme == 0) ? false : true
            };
        }

        public static implicit operator User(SettingsViewModel settingsViewModel)
        {
            return new User
            {
                Notifications = settingsViewModel.Notifications ? 1 : 0,
                DarkTheme = settingsViewModel.DarkTheme ? 1 : 0
            };
        }
    }

}