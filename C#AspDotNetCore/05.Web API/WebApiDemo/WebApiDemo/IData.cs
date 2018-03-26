using System.Collections.Generic;
using WebApiDemo.Models;

namespace WebApiDemo
{
    public interface IData
    {
        IEnumerable<Cat> All();

        Cat Find(int id);

        int Add(Cat cat);

        void Delete(int id);
    }
}
