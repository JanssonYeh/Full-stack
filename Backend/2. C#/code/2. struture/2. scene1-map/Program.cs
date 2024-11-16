struct Coordinates
{
    public double Latitude { get; }
    
    public double Longitude { get; }

    public Coordinates(double latitude, double longitude)
    {
        if (latitude < -90 || latitude > 90)
        {
            throw new ArgumentException("latitude must be between -90 and 90");
        }

        if (longitude < -90 || longitude > 90)
        {
            throw new ArgumentException("longitude must be between -90 and 90");
        }
        Latitude = latitude;
        Longitude = longitude;
    }

    //计算距离
    public double CalculateDistanceTo()
    {
        return 0;
    }
}