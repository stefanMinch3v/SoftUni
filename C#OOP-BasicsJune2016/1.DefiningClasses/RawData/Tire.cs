class Tire
{
    private double[] allPressure = new double[4];
    private int[] allAge = new int[4];

    public Tire(double pressure1, int age1, double pressure2, int age2, double pressure3, int age3, double pressure4, int age4)
    {
        allPressure[0] = pressure1;
        allPressure[1] = pressure2;
        allPressure[2] = pressure3;
        allPressure[3] = pressure4;

        allAge[0] = age1;
        allAge[1] = age2;
        allAge[2] = age3;
        allAge[3] = age4;
    }

    public double[] GetPressure => this.allPressure;
    public int[] GetAge => this.allAge;
}
