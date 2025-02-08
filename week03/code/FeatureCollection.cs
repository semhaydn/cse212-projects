// Remove these duplicate definitions if they are already present in FeatureCollection.cs
public class FeatureCollection
{
    public Feature[] Features { get; set; }
}

public class Feature
{
    public EarthquakeProperties Properties { get; set; }
}

public class EarthquakeProperties
{
    public double? Mag { get; set; }
    public string Place { get; set; }
}
