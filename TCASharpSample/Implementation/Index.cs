using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TCASharpSample.Library;

namespace TCASharpSample.Implementation
{
    struct AppState
    {
        public int Count { get; set; } = 0;

        public AppState() { }
    }

    abstract record AppAction;
    internal record DecrementTapped : AppAction;
    internal record IncrementTapped : AppAction;

    // Actual Reducer
    static class AppReducer
    {
        internal static ReduxStore<AppState, AppAction>.Reducer Body => (AppState state, AppAction action) =>
        action switch
        {
            IncrementTapped _ => state with { Count = state.Count + 1 },
            DecrementTapped _ => state with { Count = state.Count - 1 },
            _ => state
        };
    }
}