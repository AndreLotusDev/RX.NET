using System.Reactive.Subjects;
using ProxyAndBroadcast.Classes;

var market = new Subject<float>();
var marketConsumer = new Subject<float>();

using (market.Subscribe(marketConsumer))
{
	marketConsumer.Inspect("Market proxy 1");
	market.OnNext(1, 2, 3, 4);
	market.OnCompleted();
}
