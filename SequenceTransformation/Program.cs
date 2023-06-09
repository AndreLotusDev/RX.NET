using System.Reactive.Linq;

var seq = Observable.Interval(TimeSpan.FromSeconds(1));

int timesExecuted = 0;
seq.Subscribe(x =>
{
	Console.WriteLine($"Elapsed some time: {x}");
	Console.WriteLine($"Times executed {timesExecuted}");

	timesExecuted++;
});

Console.ReadKey();