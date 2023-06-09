using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Timers;
using ObservableDisposeHandling.Classes;
using Timer = System.Timers.Timer;

const int ONE_SECOND = 1000;

var obs = Observable.Create<string>(o =>
{
	var timer = new Timer(ONE_SECOND);

	timer.Elapsed += (sender, args) =>
	{
		o.OnNext($"Tick {args.SignalTime}");
	};

	timer.Elapsed += TimerOnElapsed;
	timer.Start();

	return () =>
	{
		o.OnCompleted();
		timer.Elapsed -= TimerOnElapsed;
		timer.Dispose();
	};
});

var sub = obs.Inspect(nameof(obs));
Console.ReadLine();

sub.Dispose();
Console.ReadLine();

static void TimerOnElapsed(object sender, ElapsedEventArgs args)
{
	Console.WriteLine($"Tock {args.SignalTime}");
}