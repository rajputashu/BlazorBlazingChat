using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazingChat.Client;
using BlazingChat.ViewModels;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
// builder.Services.AddSingleton<IProfileViewModel, ProfileViewModel>();// Only 1 instance will be created
//Or
// builder.Services.AddScoped<IProfileViewModel, ProfileViewModel>();// Only 1 instance will be created
// builder.Services.AddTransient<ProfileViewModel>();// Everytime new reference will be created


builder.Services.AddHttpClient<IProfileViewModel, ProfileViewModel>(
    "BlazingChatClient", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));

builder.Services.AddHttpClient<IContactViewModel, ContactViewModel>("BlazingChatClient",
client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));

builder.Services.AddHttpClient<ISettingsViewModel,SettingsViewModel>("BlazingChatClient",
client=>client.BaseAddress=new Uri(builder.HostEnvironment.BaseAddress));

await builder.Build().RunAsync();
