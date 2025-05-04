using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using TCASharpSample.Implementation;
using Windows.Media.Devices;

namespace TCASharpSample.Library;

public partial class ComposableStore<V, Action>: ObservableObject
{
    public delegate void Reducer(ref V state, Action action);

    Reducer reducer;

    [ObservableProperty]
    V value;

    public ComposableStore(V initialValue, Reducer reducer)
    {
        this.value = value;
        this.reducer = reducer;
    }

    public void Send(Action action)
    {
        reducer(ref value, action);
        OnPropertyChanged(nameof(Value));
    }
}

public partial class ReduxStore<V, Action>: ObservableObject
{
    public delegate V Reducer(V state, Action action);

    Reducer reducer;

    [ObservableProperty]
    public V value;

    public ReduxStore(V initialValue, Reducer reducer)
    {
        this.Value = value;
        this.reducer = reducer;
    }

    public void Dispatch(Action action)
    {
        Value = reducer(Value, action);
    }
}