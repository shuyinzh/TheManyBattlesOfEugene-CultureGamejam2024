public class Artist
{
    public string Name;
    public string Description;
}

public class Artists
{
    public static Artist Klimt = new Artist()
    {
        Name = "Gustav Klimt",
        Description = "An Austrian symbolist painter."
    };
    public static Artist Rembrandt = new Artist()
    {
        Name = "Rembrandt van Rijn",
        Description = "A Dutch draughtsman, painter, and printmaker."
    };
    
    public static Artist Crespi = new Artist()
    {
        Name = "Giuseppe Maria Crespi",
        Description = "An Italian late Baroque painter of the Bolognese School."
    };

    public static Artist Auerbach = new Artist()
    {
        Name = "Johann Gottfried Auerbach",
        Description = "A German painter and etcher."
    };

}