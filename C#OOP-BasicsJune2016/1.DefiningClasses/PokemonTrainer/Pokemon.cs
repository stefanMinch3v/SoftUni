public class Pokemon
{
    private string name;
    private string element;
    private int health;

    public Pokemon(string name, string element, int health)
    {
        this.name = name;
        this.element = element;
        this.health = health;
    }

    public string GetElement => this.element;
    public int GetHealth => this.health;
    public string GetName => this.name;

    public void DecreaseHealthBy10()
    {
        health -= 10;
    }
}
