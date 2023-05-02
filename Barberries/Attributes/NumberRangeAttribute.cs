using System.ComponentModel.DataAnnotations;

namespace Barberries.Attributes {
	public class NumberRangeAttribute<T> : ValidationAttribute where T : struct, IComparable<T>, IEquatable<T> {
		public static T DefaultValue = (T)(typeof(T).GetProperty("MaxValue").GetValue(null));
		public T MaxValue { get; set; } = DefaultValue;
		public T MinValue { get; set; } = DefaultValue;
		public override bool IsValid(object? value) {
			T? val = (T)value;
			if (value == null) return false;
			if (MaxValue.CompareTo(DefaultValue) != 0 && MaxValue.CompareTo(val.Value) < 0) {
				ErrorMessage = $"Слишком большое число. Должно быть меньше{MaxValue}";
				return false;
			}
			else if (MinValue.CompareTo(DefaultValue) != 0 && MinValue.CompareTo(val.Value) > 0) {
				ErrorMessage = $"Слишком маленькое число. Должно быть больше{MinValue}";
				return false;
			}
			return true;
		}
	}
}
