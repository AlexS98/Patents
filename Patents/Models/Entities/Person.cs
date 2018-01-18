namespace Patents.Models.Entities
{
    interface Person
    {
        string FullName { get; set; }
        string Email { get; set; }
        string Password { get; set; }
        int GetPersonId();
    }
}
