using System;

public class Singleton<T> where T : class, new()
{
	private static T mInstance = default(T);
	
	public static T Instance {
		get {
			if (Singleton<T>.mInstance == null) {
				Singleton<T>.mInstance = Activator.CreateInstance<T> ();
			}
			return Singleton<T>.mInstance;
		}
	}
}

