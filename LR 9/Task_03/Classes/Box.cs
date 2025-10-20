using System;
namespace Classes
{
	public class Box<T>
	{
		private T value;
		public T Value
		{
			get { return value; }
			private set { this.value = value; }
		}
	public Box(T value)
		{
			Value = value;
		}
		public override string ToString()
		{
			return value.GetType().FullName + ": " + value;
		}
	}
}
