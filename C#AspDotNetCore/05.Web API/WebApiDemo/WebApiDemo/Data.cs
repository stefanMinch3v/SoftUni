using System.Collections.Generic;
using System.Linq;
using WebApiDemo.Models;

namespace WebApiDemo
{
    public class Data : IData
    {
        private readonly List<Cat> data;

        public Data()
        {
            this.data = new List<Cat>
            {
                new Cat {Id = 1, Name = "Ivan", Age = 13},
                new Cat {Id = 2, Name = "Gosho", Age = 3},
                new Cat {Id = 3, Name = "Pesho", Age = 31},
                new Cat {Id = 4, Name = "Mitko", Age = 33},
            };
        }

        public int Add(Cat cat)
        {
            var id = this.data.Max(c => c.Id) + 1;
            cat.Id = id;
            this.data.Add(cat);
            return id;
        }

        public IEnumerable<Cat> All()
            => new List<Cat>(this.data);

        public Cat Find(int id)
            => this.All().FirstOrDefault(c => c.Id == id);
        
        public void Delete(int id)
        {
            this.data.RemoveAll(c => c.Id == id);
        }
    }
}
