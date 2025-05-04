using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using TCASharpSample.Implementation;
using Windows.Media.Devices;

namespace TCASharpSample.Library;

public partial class Store<V, Action>: ObservableObject
{
    public delegate V Reducer(V state, Action action);

    Reducer reducer;

    [ObservableProperty]
    V value;

    public Store(V initialValue, Reducer reducer)
    {
        this.value = value;
        this.reducer = reducer;
    }

    public void Send(Action action)
    {
        value = reducer(value, action);
    }
}