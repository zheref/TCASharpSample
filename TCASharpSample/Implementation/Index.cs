using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TCASharpSample.Library;

namespace TCASharpSample.Implementation;
struct AppState
{
    public int Count { get; set; } = 0;

    public AppState() { }
}

abstract record AppAction;
record DecrementTapped: AppAction;
record IncrementTapped : AppAction;

// Alias
delegate AppState Reducer(AppState state, AppAction action);

// Actual Reducer
static class AppReducer
{
    internal static Store<AppState, AppAction>.Reducer Body => (state, action) =>
    action switch
    {
        IncrementTapped => state with {
            Count = state.Count + 1
        },
        DecrementTapped => state with { Count = state.Count - 1 },
        _ => state
    };
}