namespace AutomapperBenchmark;

public record User(
    string FirstName,
    string LastName,
    DateTime BirthDate,
    Address Address
);
    
public record Address(double Latitude, double Longitude);