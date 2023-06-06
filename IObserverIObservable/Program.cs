class Program : IObserver<float>
{
	public Market market { get; set; }
	private IDisposable subscription;
	public Program()
	{
		market = new Market();

		market.Subscribe(this);

		//Add prices
		market.AddPrice(220);
		market.AddPrice(380);
		market.AddPrice(197);

		subscription = market.Subscribe(this);

		this.Unsubscribe();
	}

	static void Main(string[] args)
	{
		Program program = new Program();
	}

	public void OnCompleted()
	{
		throw new NotImplementedException();
	}

	public void OnError(Exception error)
	{
		throw new NotImplementedException();
	}

	public void OnNext(float value)
	{
		Console.WriteLine($"Added a new price in market: {value}");
	}

	public void Unsubscribe()
	{
		subscription.Dispose();
	}
}


class Market : IObservable<float>
{
	public List<float> Prices { get; private set; }
	private List<IObserver<float>> Observers { get; set; } 

	public Market()
	{
		Prices = new List<float>();
		Observers = new List<IObserver<float>>();
	}

	public void AddPrice(float price)
	{
		Prices.Add(price);

		foreach (var observer in Observers)
		{
			observer.OnNext(price);
		}
	}

	public IDisposable Subscribe(IObserver<float> observer)
	{
		Observers.Add(observer);

		return new Subscription(observer);
	}
}

class Subscription : IDisposable
{
	private IObserver<float> observer;

	public Subscription(IObserver<float> observer)
	{
		this.observer = observer;
	}

	public void Dispose()
	{
		observer = null;
	}
}
