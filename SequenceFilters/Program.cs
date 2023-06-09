using System.Reactive.Linq;
using SequenceFilters.Classes;

var value = Observable.Range(-10, 20);

value.SkipWhile(s => s < 0)
	.TakeWhile(s => s <= 6)
	.Inspect(nameof(value));
