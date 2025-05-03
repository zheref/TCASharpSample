using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCASharpSample.Library;

internal class Store<Value>
{
    Value value { get; set; }

    internal Store(Value initialValue)
    {
        this.value = value;
    }
}