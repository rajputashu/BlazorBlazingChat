using Microsoft.AspNetCore.Mvc;
using BlazingChat.Shared;
using BlazingChat.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazingChat.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;

    private readonly BlazingChatContext _context;

    public UserController(ILogger<UserController> logger, BlazingChatContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet("getcontacts")]
    public List<Contact> GetContacts()
    {
        // WILL USE MVVM - MAPPER CONCEPT TO CONVERT DTOs
        List<User> usersList = _context.Users.ToList();
        List<Contact> contacts = new List<Contact>();
        int id = 0;
        foreach (var User in usersList)
        {
            contacts.Add(new Contact(id++, User.FirstName, User.LastName));
        }
        return contacts;
    }


    [HttpGet("getprofile/{userId}")]
    public async Task<User> getProfile(int userId)
    {
        User? u = await _context.Users.Where(u => u.UserId == userId).FirstOrDefaultAsync();
        return u!;
    }

    [HttpPut("updateprofile/{userId}")]
    public async Task<User> updateProfile(int userId, [FromBody] User updatedUser)
    {
        User? usertoUpdate = await _context.Users.Where(u => u.UserId == userId).FirstOrDefaultAsync();
        usertoUpdate!.FirstName = updatedUser.FirstName;
        usertoUpdate.LastName = updatedUser.LastName;
        usertoUpdate.EmailAddress = updatedUser.EmailAddress;

        Console.WriteLine(usertoUpdate.LastName);

        await _context.SaveChangesAsync();

        return await Task.FromResult(updatedUser);
    }
}
