using System.Collections;
using System.Collections.Generic;
using System.Linq;

class ImmutableList
{
    public List<int> integers;

    public ImmutableList(List<int> integers)
    {
        this.integers = integers;
    }

    public ImmutableList GetCollection()
    {
        return new ImmutableList(this.integers);
    }
}
