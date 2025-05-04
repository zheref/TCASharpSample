using Microsoft.VisualStudio.TestTools.UnitTesting;
using TCASharpSample.Library;

namespace TCASharpTests;

[TestClass]
public class ComposableStoreTests
{
    ComposableStore<TestState, TestAction>? store;

    [TestInitialize]
    public void Setup()
    {
        store = new ComposableStore<TestState, TestAction>(
            new TestState(),
            (ref TestState state, TestAction action) =>
            {
                switch (action)
                {
                    case IncrementTapped _:
                        state.Count++;
                        break;
                    case DecrementTapped _:
                        state.Count--;
                        break;
                }
            }
        );
        Assert.IsNotNull(store);
    }

    [TestMethod]
    public void TestSend()
    {
        if (store == null) return;
        Assert.AreEqual(0, store.Value.Count);
        store.Send(new IncrementTapped());
        Assert.AreEqual(1, store.Value.Count);
        store.Send(new IncrementTapped());
        Assert.AreEqual(2, store.Value.Count);
        store.Send(new DecrementTapped());
        Assert.AreEqual(1, store.Value.Count);
        store.Send(new DecrementTapped());
        Assert.AreEqual(0, store.Value.Count);
    }

    [TestCleanup]
    public void Cleanup()
    {
        store = null;
    }
}
