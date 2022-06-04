namespace BlazingChat.ViewModels
{
    public interface ISettingsViewModel
    {
        public bool Notifications { get; set; }

        public bool DarkTheme { get; set; }

        public Task getSettingDetails();

        public Task updateSettingDetails();
    }
}