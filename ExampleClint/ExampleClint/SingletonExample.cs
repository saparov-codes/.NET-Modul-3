using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleClint;

public class SingletonExample
{
    public int Id { get; set; }

    public string FirstName { get; set; }

    // Mainda new qilib obj olib bo'lmaydi!
    // var obj1 = SingletonExample.GetInstance() 
    // obj olinadi^

    private static SingletonExample _instance;

    private SingletonExample() { }

    public static SingletonExample GetInstance()
    {
        if(_instance == null)
        {
            _instance = new SingletonExample();
        }

        return _instance;
    }
}
