namespace Patents.Models.Entities
{
    internal interface IPerson
    {
        string FullName { get; set; }
        string Email { get; set; }
        string Password { get; set; }
        int GetPersonId();
    }
}
