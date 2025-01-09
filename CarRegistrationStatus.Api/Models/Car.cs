public class Car
{
    public Guid Id { get; set; }
    public required string Make { get; set; }
    public required string Model { get; set; }
    public required string Plate { get; set; }
    public required DateTime RegistrationExpiryDate { get; set; }
    public bool IsRegistrationValid => RegistrationExpiryDate > DateTime.Now;
}
