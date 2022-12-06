public class UserJsonModel
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Username { get; set; }
    public string? Email { get; set; }
    public Address? Address { get; set; }
}

public class Address
{
    public string? Street { get; set; }
    public string? City { get; set; }
}