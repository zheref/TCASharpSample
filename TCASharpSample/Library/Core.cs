using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace TCASharpSample.Library;

internal partial class Store<V>: ObservableObject
{
    [ObservableProperty]
    V value;

    internal Store(V initialValue)
    {
        this.value = value;
    }
}