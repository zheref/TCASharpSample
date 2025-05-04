using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TCASharpTests;
internal record struct TestState
{
    public int Count { get; set; } = 0;
    public TestState() { }
}

internal abstract record TestAction;
internal record IncrementTapped : TestAction;
internal record DecrementTapped : TestAction;