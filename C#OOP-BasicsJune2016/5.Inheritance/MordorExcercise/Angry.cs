using System;

public class Angry : Mood
{
    public override string Type
    {
        get
        {
            return nameof(Angry);
        }
    }
}
