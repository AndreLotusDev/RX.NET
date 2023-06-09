using System.Reactive.Subjects;

var subject = new Subject<int>();

subject.Subscribe(
	onNext: value => Console.WriteLine($"Received value: {value}"),
	onError: ex => Console.WriteLine($"Error: {ex.Message}"),
	onCompleted: () => Console.WriteLine("Completed")
);

subject.OnNext(1);
subject.OnNext(2);

try
{
	throw new Exception("Something went wrong");
}
catch (Exception ex)
{
	subject.OnError(ex);
}

subject.OnNext(3);
subject.OnCompleted();

Console.ReadKey();