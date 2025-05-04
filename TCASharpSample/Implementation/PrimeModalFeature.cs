using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCASharpSample.Implementation;



abstract record PrimeModalAction;
internal record SaveFavoritePrimeTapped : PrimeModalAction;
internal record RemoveFavoritePrimeTapped : PrimeModalAction;