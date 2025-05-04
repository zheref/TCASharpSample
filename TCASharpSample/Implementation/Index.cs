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
        internal static ComposableStore<AppState, AppAction>.Reducer Body => (ref AppState state, AppAction action) =>
        {
            switch (action)
            {
                case IncrementTapped:
                    state.Count++;
                    break;
                case DecrementTapped:
                    state.Count--;
                    break;
            }
        };
    }
}