using System.Collections.Generic;

namespace Otus.Generics.Demo
{
public class MyList<T>
{
    public MyList()
    => _list = new List<T>();

    private List<T> _list;

    public void Add(T v)
    => _list.Add(v);
}

}