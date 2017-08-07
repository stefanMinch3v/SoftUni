namespace ReflectionDemos
{
    public class Cat : Animal
    {
        public Cat()
        {

        }

        public Cat(string name)
        {
            this.Name = name;
        }

        public string Name{ get; set; }

        public int Age { get; set; }
    }
}
