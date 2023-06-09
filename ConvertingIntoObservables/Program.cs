using System.Reactive.Linq;

var market = new Market();
var priceChanges = Observable.FromEventPattern<float>(
	h => market.PriceChanged += h,
	h => market.PriceChanged -= h);

var o = priceChanges.Subscribe(h =>
{
	Console.WriteLine("Price changed: " + h.EventArgs);
});

market.ChangePrice(123);
market.ChangePrice(456);
market.ChangePrice(789);

o.Dispose();

class Market
{
	public float Price { get; set; }

	public EventHandler<float> PriceChanged;

	public void ChangePrice(float newPrice)
	{
		Price = newPrice;
		PriceChanged?.Invoke(this, newPrice);
	}
}