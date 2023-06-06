using System.Reactive.Subjects;

var market = new Subject<float>();

market.Subscribe(f =>
{
	Console.WriteLine($"Added new price to market {f}");
}, () =>
{
	Console.WriteLine("Completed execution");
});

market.OnNext(123.45f);
market.OnNext(123.46f);
market.OnNext(123.47f);
market.OnCompleted();
