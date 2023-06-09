using System.Reactive.Linq;
using FactoryMethods.Classes;

var replayInt = Observable.Return(32);
replayInt.Inspect(nameof(replayInt));

var empty = Observable.Empty<int>();
empty.Inspect(nameof(empty));

var error = Observable.Throw<int>(new Exception("Error"));
error.Inspect(nameof(error));