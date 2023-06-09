using System.Reactive.Subjects;

const int HOLD_ONE_ELEMENT = 1;
var lastOdd = new ReplaySubject<int>(HOLD_ONE_ELEMENT); 

lastOdd.Subscribe(number =>
{
	if (number % 2 != 0)
	{
		Console.WriteLine($"{number} is odd");
	}
});

lastOdd.OnNext(1);
lastOdd.OnNext(2);
lastOdd.OnNext(3); 