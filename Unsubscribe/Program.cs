using System.Reactive.Subjects;

var sensor = new Subject<float>();

using (sensor.Subscribe(f => Console.WriteLine("Detected movement"), () => { }))
{
	sensor.OnNext(1);
	sensor.OnNext(2);
	sensor.OnNext(3);
}

sensor.OnNext(4);

Console.WriteLine("Done");