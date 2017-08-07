using System;

static class FoodFactory
{
    public static Food GetSomeFood(string foodName)
    {
        switch (foodName)
        {
            case "cram":
                return new Cram();
            case "lembass":
                return new Lembass();
            case "apple":
                return new Apple();
            case "melon":
                return new Melon();
            case "honeycake":
                return new HoneyCake();
            case "mushrooms":
                return new Mushrooms();
            case "anythingElse":
                return new EverythingElseFood();
            default:
                return null;
        }
    }    
}
