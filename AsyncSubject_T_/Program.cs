using System.Reactive.Subjects;
using AsyncSubject_T_.Classes;

var sensor = new AsyncSubject<int>();

sensor.Inspect(nameof(sensor));

sensor.OnNext(1);
sensor.OnNext(2);
sensor.OnCompleted();