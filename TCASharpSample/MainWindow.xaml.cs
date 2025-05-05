using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using TCASharpSample.Implementation;
using TCASharpSample.Library;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.DialProtocol;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace TCASharpSample;

using AppStore = ReduxStore<AppState, AppAction>;

/// <summary>
/// An empty window that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class MainWindow : Window
{
    AppStore store;

    public MainWindow()
    {
        this.InitializeComponent();

        AppState initialState = new();

        this.store = new ReduxStore<AppState, AppAction>(
            initialState,
            AppReducer.Body
        );

        mainPage.DataContext = this.store;
    }

    private void decrementButton_Click(object sender, RoutedEventArgs e)
    {
        store.Dispatch(new AppAction.Counter(new DecrementTapped()));
    }

    private void incrementButton_Click(object sender, RoutedEventArgs e)
    {
        store.Dispatch(new AppAction.Counter(new IncrementTapped()));
    }

    private void savePrime_Click(object sender, RoutedEventArgs e)
    {
        store.Dispatch(new AppAction.PrimeModal(
            new SaveFavoritePrimeTapped()
        ));
    }

    private void removePrime_Click(object sender, RoutedEventArgs e)
    {
        store.Dispatch(new AppAction.PrimeModal(
            new RemoveFavoritePrimeTapped()
        ));
    }

    private void primeListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (sender is ListView listView)
        {
            //var selectedItems = listView.SelectedItems;
            //var indexes = new List<int>();
            //foreach (var item in selectedItems)
            //{
            //    indexes.Add(listView.Items.IndexOf(item));
            //}
            //store.Dispatch(new AppAction.FavoritePrimes(new DeleteFavoritePrimes(indexes)));
        }
    }

    private void clearFavorites_Click(object sender, RoutedEventArgs e)
    {
        var selectedItems = primeListView.SelectedRanges;
        var indexes = new HashSet<int>();
        foreach (var range in selectedItems)
            for (int i = range.FirstIndex; i <= range.LastIndex; i++) 
                indexes.Add(i);
        store.Dispatch(new AppAction.FavoritePrimes(
            new DeleteFavoritePrimes(indexes)
        ));
    }
}
