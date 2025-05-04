using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace TCASharpTests;
internal record TestState
{
    public int Count { get; set; } = 0;
    public int[] Numbers { get; set; } = [];
    public TestState() { }
}

internal abstract record TestAction;
internal record IncrementTapped : TestAction;
internal record DecrementTapped : TestAction;
internal record AddTapped: TestAction;