using System;

public class BoxClass
{
    private double length;
    private double width;
    private double height;

    public BoxClass(double length, double width, double height)
    {
        this.Length = length;
        this.Width = width;
        this.Height = height;
    }

    public double Length
    {
        get
        {
            return this.length;
        }
        private set
        {
            if (value < 1)
            {
                throw new ArgumentException($"{nameof(Length)} cannot be zero or negative.");
            }
            this.length = value;
        }
    }
    public double Width
    {
        get
        {
            return this.width;
        }
        private set
        {
            if (value < 1)
            {
                throw new ArgumentException($"{nameof(Width)} cannot be zero or negative.");
            }
            this.width = value;
        }
    }
    public double Height
    {
        get
        {
            return this.height;
        }
        private set
        {
            if (value < 1)
            {
                throw new ArgumentException($"{nameof(Height)} cannot be zero or negative.");
            }
            this.height = value;
        }
    }

    public string GetSurfaceArea()
    {
        return $"Surface Area - {((2 * this.length * this.width) + (2 * this.length * this.height) + (2 * this.width * this.height)):F2}";
    }
    public string GetLateralSurfaceArea()
    {
        return $"Lateral Surface Area - { ((2 * this.length * this.height) + (2 * this.width * this.height)):F2}";
    }
    public string GetVolume()
    {
        return $"Volume - {(this.length * this.width * this.height):F2}";
    }
}
