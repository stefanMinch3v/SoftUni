namespace Ferrari
{
    public interface ICar
    {
        string Model { get;}

        string DriverName { get; set; }

        string UseBrakes();

        string PushTheGasPedal();
    }
}
