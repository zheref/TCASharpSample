using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCASharpSample.Implementation;

struct CounterState
{
    public int Count { get; set; } = 0;

    public CounterState() { }
}

abstract record CounterAction;
internal record DecrementTapped : CounterAction;
internal record IncrementTapped : CounterAction;