using System;

static class MoodFactory
{
    public static Mood SeeGandalfsMood(string moodType)
    {
        switch (moodType)
        {
            case "angry":
                return new Angry();
            case "sad":
                return new Sad();
            case "happy":
                return new Happy();
            case "javascript":
                return new JavaScript();
            default:
                return null;
        }
    }
}
