using System.Reactive.Subjects;

var market = new ReplaySubject<float>();

market.OnNext(123.45f);
market.OnNext(123.46f);
market.OnNext(123.47f);

market.Subscribe(f => Console.WriteLine($"Generated value {f}"));
