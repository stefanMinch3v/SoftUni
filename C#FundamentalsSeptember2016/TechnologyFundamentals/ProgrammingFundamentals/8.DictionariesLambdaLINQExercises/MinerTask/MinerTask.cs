using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinerTask
{
    class MinerTask
    {
        static void Main(string[] args)
        {
            Dictionary<string, long> phonebook = new Dictionary<string, long>();

            var resource = Console.ReadLine();

            while (!resource.Equals("stop"))
            {
                long quantity = long.Parse(Console.ReadLine());

                if (!phonebook.ContainsKey(resource))
                {
                    phonebook.Add(resource, 0);
                }
                phonebook[resource] += quantity;

                resource = Console.ReadLine();
            }
            foreach (var item in phonebook)
            {
                Console.WriteLine("{0} -> {1}", item.Key, item.Value);
            }
        }
    }
}
