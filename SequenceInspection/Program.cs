using System.Reactive.Linq;
using System.Reactive.Subjects;

var isOdd = new Subject<int>();

isOdd.Where(a => (a % 2) != 0).Subscribe(a => Console.WriteLine($"{a} is odd (s1)"));
isOdd.Where(a => (a % 2) != 0).Any().Subscribe(s =>
{
	if(s)
		Console.WriteLine("Is odd (s2)");
}); //Execute just one time

isOdd.OnNext(1);
isOdd.OnNext(2);
isOdd.OnNext(3);

//isEven.OnCompleted();

Console.ReadKey();