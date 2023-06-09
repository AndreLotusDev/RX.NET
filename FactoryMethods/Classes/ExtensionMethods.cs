namespace FactoryMethods.Classes
{
	public static class ExtensionMethods
	{
		public static IDisposable Inspect<T>(this IObservable<T> self, string name)
		{
			return self.Subscribe(
				x =>
				{
					Console.WriteLine($"Has generated {x} value");
				},
				ex =>
				{
					Console.WriteLine($"Has generated {ex} exception");
				},
				() =>
				{
					Console.WriteLine($"Has completed {name}");
				}
			);
		}

		public static IObserver<T> OnNext<T>(this IObserver<T> self, params T[] args)
		{
			foreach (var arg in args)
			{
				self.OnNext(arg);
			}

			return self;
		}
	}
}
