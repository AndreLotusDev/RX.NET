using System.Reactive.Linq;

var random = new Random();

const int MINIMUM_VALUE = 1;
const int MAXIMUM_VALUE = 100;
const int ONE_SECOND = 1;

var observable = Observable.Interval(TimeSpan.FromSeconds(ONE_SECOND))
	.Select(_ => random.Next(MINIMUM_VALUE, MAXIMUM_VALUE)); 

observable
	.Scan((Sum: 0L, Count: 0L, Min: long.MaxValue, Max: long.MinValue),
		(acc, value) => (
			Sum: acc.Sum + value,
			Count: acc.Count + 1,
			Min: Math.Min(acc.Min, value),
			Max: Math.Max(acc.Max, value)))
	.Select(stats => (
		Average: (double)stats.Sum / stats.Count,
		Min: stats.Min,
		Max: stats.Max))
	.Subscribe(stats =>
	{
		Console.WriteLine($"Average: {stats.Average:F2}, Minimum: {stats.Min}, Maximum: {stats.Max}");
	});

Console.ReadLine(); 