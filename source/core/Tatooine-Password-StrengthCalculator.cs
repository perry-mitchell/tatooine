using System;
using System.Text.RegularExpressions;
using Tatooine;

namespace Tatooine.Password {

	public enum PasswordStrength {
		BLANK,
		SHORT,
		WEAK,
		AVERAGE,
		STRONG
	}

	public class StrengthCalculator {

		protected string _password;

		public const int PASSWORD_MIN_LENGTH = 8;

		protected StrengthCalculator(string password) {
			_password = password;
		}

		public static PasswordStrength calculateStrength(string password) {
			int length = password.Length;
			if (length == 0) {
				return PasswordStrength.BLANK;
			} else if (length < PASSWORD_MIN_LENGTH) {
				return PasswordStrength.SHORT;
			}

			// In-range
			int index = calculateStrengthIndex(password);

			return PasswordStrength.WEAK;
		}

		public static int calculateStrengthIndex(string password) {
			StrengthCalculator calc = new StrengthCalculator(password);
			return calc.processPasswordScore();
		}

		protected int processPasswordScore() {
			int score = 0;
			int length = _password.Length;

			// Specs borrowed from: http://www.passwordmeter.com/

			if (length == 0) {
				return 0;
			} else if (length < PASSWORD_MIN_LENGTH) {
				return 1;
			}

			// ** ADDITIONS

			// Length
			score += (length - PASSWORD_MIN_LENGTH) * 4;

			// Lower case
			score += (length - Regex.Matches(_password, @"/[a-z]/", RegexOptions.ECMAScript).Count) * 2;

			// Upper case
			score += (length - Regex.Matches(_password, @"/[A-Z]/", RegexOptions.ECMAScript).Count) * 2;

			// Numbers
			score += Regex.Matches(_password, @"/[0-9]/", RegexOptions.ECMAScript).Count * 4;

			// Symbols
			score += Regex.Matches(_password, "/[$-/:-?{-~!\"^_`\\[\\]]/", RegexOptions.ECMAScript).Count * 6;

			// Middle symbols/numbers
			score += Regex.Matches(_password, "/^.{1,}[$-/:-?{-~!\"^_`\\[\\]0-9].{1,}$/", RegexOptions.ECMAScript).Count * 2;

			// ** DEDUCTIONS

			// Letters only
			if (Regex.Matches(_password, @"/[a-zA-Z]/", RegexOptions.ECMAScript).Count == length) {
				score -= length;
			}

			// Numbers only
			if (Regex.Matches(_password, @"/[0-9]/", RegexOptions.ECMAScript).Count == length) {
				score -= length;
			}

			// Consecutive uppercase letters
			int totalUpperConsec = 0;
			foreach (Match upperMatch in Regex.Matches(_password, @"/[A-Z]{2,}/", RegexOptions.ECMAScript)) {
				totalUpperConsec += upperMatch.Value.Length;
			}
			score -= totalUpperConsec * 2;

			// Consecutive lowercase letters
			int totalLowerConsec = 0;
			foreach (Match lowerMatch in Regex.Matches(_password, @"/[a-z]{2,}/", RegexOptions.ECMAScript)) {
				totalLowerConsec += lowerMatch.Value.Length;
			}
			score -= totalLowerConsec * 2;

			// Consecutive numbers
			int totalNumberConsec = 0;
			foreach (Match cNumbersMatch in Regex.Matches(_password, @"/[0-9]{2,}/", RegexOptions.ECMAScript)) {
				totalNumberConsec += cNumbersMatch.Value.Length;
			}
			score -= totalNumberConsec * 2;

			// Character sequences
			score -= Tools.PasswordAnalysis.countSequentialCharacters(_password) * 3;

			return score;
		}

	}

}