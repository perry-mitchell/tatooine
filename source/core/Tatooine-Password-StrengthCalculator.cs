using System;
using System.Text.RegularExpressions;

namespace Tatooine.Password {

	public class StrengthCalculator {

		protected string _password;

		public const int PASSWORD_MIN_LENGTH = 8;

		protected StrengthCalculator(string password) {
			_password = password;
		}

		public static int calculateStrength(string password) {
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

			return score;
		}

	}

}