using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.ObjectModel;
using System.Linq;
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
            new TestState() {
                Count = 0,
                Numbers = []
            },
            (TestState state, TestAction action) =>
            action switch
            {
                IncrementTapped _ => state with { Count = state.Count + 1 },
                DecrementTapped _ => state with { Count = state.Count - 1 },
                AddTapped => state with
                {
                    Numbers = [..state.Numbers, state.Count]
                },
                _ => state
            }
        );
        Assert.IsNotNull(store);
    }

    [TestMethod]
    public void TestDispatch()
    {
        if (store == null) return;
        Assert.AreEqual(0, store.Value.Count);
        store.Dispatch(new IncrementTapped());
        Assert.AreEqual(1, store.Value.Count);
        store.Dispatch(new IncrementTapped());
        Assert.AreEqual(2, store.Value.Count);

        store.Dispatch(new AddTapped());
        Assert.AreEqual(1, store.Value.Numbers.Length);
        //Assert.AreSame([2], store.Value.Numbers);
        Assert.AreEqual(2, store.Value.Numbers[0]);

        store.Dispatch(new DecrementTapped());
        Assert.AreEqual(1, store.Value.Count);
        store.Dispatch(new DecrementTapped());
        Assert.AreEqual(0, store.Value.Count);
    }

    [TestCleanup]
    public void Cleanup()
    {
        store = null;
    }
}
