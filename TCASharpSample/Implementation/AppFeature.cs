using System;
using System.Collections.Generic;
using System.Linq;
using TCASharpSample.Library;
using static TCASharpSample.CollectionHelpers;

namespace TCASharpSample.Implementation
{
    struct AppState
    {
        public int Count { get; set; } = 0;

        public List<int> FavoritePrimes { get; set; } = [1, 2, 3];

        public AppState() { }
    }

    abstract record AppAction
    {
        internal record Counter(CounterAction action) : AppAction;
        internal record PrimeModal(PrimeModalAction action) : AppAction;
        internal record FavoritePrimes(FavoritePrimesAction action) : AppAction;
    }       
    

    // Actual Reducer
    static class AppReducer
    {
        internal static ReduxStore<AppState, AppAction>.Reducer Body 
            => (AppState state, AppAction action) => action switch
            {
                AppAction.Counter(IncrementTapped) => state with { Count = state.Count + 1 },
                AppAction.Counter(DecrementTapped) => state with { Count = state.Count - 1 },
                AppAction.PrimeModal(SaveFavoritePrimeTapped) => state with {
                    FavoritePrimes = new(state.FavoritePrimes.Append(state.Count))
                },
                AppAction.PrimeModal(RemoveFavoritePrimeTapped) => state with {
                    FavoritePrimes = new(state.FavoritePrimes.Where((n) => n != state.Count).ToList())
                },
                AppAction.FavoritePrimes(DeleteFavoritePrimes a) => state with
                {
                    FavoritePrimes = state.FavoritePrimes.RemovingIndexes(a.indexes)
                },
                _ => state
            };
    }
}