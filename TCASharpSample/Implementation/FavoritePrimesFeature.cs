using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCASharpSample.Implementation;

using IndexSet = HashSet<int>;

public record FavoritePrimesAction;
internal record DeleteFavoritePrimes(IndexSet indexes) : FavoritePrimesAction;
