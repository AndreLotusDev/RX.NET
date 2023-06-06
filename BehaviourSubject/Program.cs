using System.Reactive.Subjects;
using BehaviourSubject.Classes;

const int DEFAULT_VALUE = -1;

var subject = new BehaviorSubject<int>(DEFAULT_VALUE);

subject.Inspect(nameof(subject));

subject.OnNext(1);

subject.OnCompleted();

