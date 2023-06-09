using System.Reactive.Linq;
using SequenceGenerators.Classes;

var obs = Observable.Range(0, 20);

var d = obs.Inspect(nameof(obs));
Console.ReadLine();