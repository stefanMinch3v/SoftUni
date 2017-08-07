public class Cat
{
    private string name;
    private int earSize;
    private int decibelsOfMeow;
    private double furLength;

    public Cat(string name, int earSize, int decibelsOfMeow, double furLength)
    {
        this.name = name;
        this.earSize = earSize;
        this.decibelsOfMeow = decibelsOfMeow;
        this.furLength = furLength;
    }

    public int GetEarSize => this.earSize;
    public int GetDecibelsOfMeow => this.decibelsOfMeow;
    public double GetFurLength => this.furLength;
    public string GetName => this.name;

    public void SetEarSize(int earSize)
    {
        this.earSize = earSize;
    }
    public void SetDecibelsOfMeow(int decibelsOfMeow)
    {
        this.decibelsOfMeow = decibelsOfMeow;
    }
    public void SetFurLength(double furLength)
    {
        this.furLength = furLength;
    }
    public void SetName(string name)
    {
        this.name = name;
    }
}
