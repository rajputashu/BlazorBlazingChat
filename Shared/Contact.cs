namespace BlazingChat.Shared;

public class Contact
{
    public int ContactId { set; get; }

    public string? FirstName { set; get; } = null;

    public string? LastName { set; get; } = null;

    public Contact(int ContactId, string? FirstName, string? LastName)
    {
        this.ContactId = ContactId;
        this.FirstName = FirstName;
        this.LastName = LastName;
    }
}