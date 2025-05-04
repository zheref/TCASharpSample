using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public List<int> FavoritePrimes { get; set; }

        public AppState() {
            Count = 0;
            FavoritePrimes = [1];
        }
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
                AppAction.PrimeModal(SaveFavoritePrimeTapped) => state with {
                    FavoritePrimes = new(state.FavoritePrimes.Append(state.Count))
                },
                AppAction.PrimeModal(RemoveFavoritePrimeTapped) => state with {
                    FavoritePrimes = new(state.FavoritePrimes.Where((n) => n != state.Count).ToList())
                },
                _ => state
            };
    }
}