using System.ComponentModel;

//This is a example using raw c# that is possible to make reactivity system

//observer

var market = new Market();
market.Prices.ListChanged += (sender, eventArgs) =>
{
	if (eventArgs.ListChangedType == ListChangedType.ItemAdded)
	{
		var lastPriceAdded = market.Prices[eventArgs.NewIndex];
		Console.WriteLine($"Last price added: {lastPriceAdded}");
	}

	if (eventArgs.ListChangedType == ListChangedType.ItemChanged)
	{
		var lastPriceChanged = market.Prices[eventArgs.NewIndex];
		Console.WriteLine($"Last price changed: {lastPriceChanged}");
	}

	if (eventArgs.ListChangedType == ListChangedType.ItemDeleted)
	{
		var lastPriceDeleted = eventArgs.OldIndex;
		Console.WriteLine($"Last price deleted: {lastPriceDeleted}");
	}

	if (eventArgs.ListChangedType == ListChangedType.Reset)
	{
		Console.WriteLine("Prices reset");
	}
};

market.Prices.Add(20);

class Market //observable
{
	public BindingList<float> Prices { get; set; } = new();
}