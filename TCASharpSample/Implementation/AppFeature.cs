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

    abstract record AppAction
    {
        internal record Counter(CounterAction action) : AppAction;
        internal record PrimeModal(PrimeModalAction action) : AppAction;
    }
    

    // Actual Reducer
    static class AppReducer
    {
        internal static ReduxStore<AppState, AppAction>.Reducer Body 
            => (AppState state, AppAction action) => action switch
            {
                AppAction.Counter(IncrementTapped) => state with { Count = state.Count + 1 },
                AppAction.Counter(DecrementTapped) => state with { Count = state.Count - 1 },
                AppAction.PrimeModal(SaveFavoritePrimeTapped) => state,
                AppAction.PrimeModal(RemoveFavoritePrimeTapped) => state,
                _ => state
            };
    }
}