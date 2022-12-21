namespace AutomapperBenchmark;

public record UserModel(
    string FirstName,
    string LastName,
    DateTime BirthDate,
    AddressModel Address
);
    
public record AddressModel(double Latitude, double Longitude);

public static class UserModelExtensions
{
    public static User ToUser(this UserModel model) =>
        new(model.FirstName, model.LastName, model.BirthDate, model.Address.ToAddress());
}

public static class AddressModelExtensions
{
    public static Address ToAddress(this AddressModel model) =>
        new(model.Latitude, model.Longitude);
}