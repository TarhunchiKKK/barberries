using System.ComponentModel.DataAnnotations;

namespace Barberries.Attributes {
	public class TextLengthAttribute : ValidationAttribute {
		public int MaxLength { get; set; }
		public int MinLength { get; set; }
		public override bool IsValid(object? value) {
			string? str = value as string;
			if (str == null) return false;
			if (MaxLength != -1 && str.Length >= MaxLength) {
				ErrorMessage = $"Слишком длинный текст. Должно быть не более {MaxLength} символов";
				return false;
			}
			else if (MinLength != -1 && str.Length <= MinLength) {
				ErrorMessage = $"Слишком короткий текст. Должно быть не менее {MinLength} символов";
				return false;
			}
			else return true;
		}
	}
}
