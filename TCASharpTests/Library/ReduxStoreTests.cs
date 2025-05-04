using Microsoft.VisualStudio.TestTools.UnitTesting;
using TCASharpSample.Library;

namespace TCASharpTests;

[TestClass]
public class ReduxStoreTests
{
    ReduxStore<TestState, TestAction>? store;

    [TestInitialize]
    public void Setup()
    {
        store = new ReduxStore<TestState, TestAction>(
            new TestState(),
            (TestState state, TestAction action) =>
            action switch
            {
                IncrementTapped _ => state with { Count = state.Count + 1 },
                DecrementTapped _ => state with { Count = state.Count - 1 },
                _ => state
            }
        );
        Assert.IsNotNull(store);
    }

    [TestMethod]
    public void TestIncrement()
    {
        if (store == null) return;
        Assert.AreEqual(0, store.Value.Count);
        store.Dispatch(new IncrementTapped());
        Assert.AreEqual(1, store.Value.Count);
    }

    [TestCleanup]
    public void Cleanup()
    {
        store = null;
    }
}
