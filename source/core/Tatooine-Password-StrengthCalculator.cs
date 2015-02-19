using System;
using System.Text.RegularExpressions;

namespace Tatooine.Password {

	public class StrengthCalculator {

		protected string _password;

		public const int PASSWORD_MIN_LENGTH = 8;

		protected StrengthCalculator(string password) {
			_password = password;
			_score = processPasswordScore();
		}

		public static int calculateStrength(string password) {
			StrengthCalculator calc = new StrengthCalculator(password);
			return calc.getPasswordScore();
		}

		protected int getPasswordScore() {
			return _score;
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
			score += (length - Regex.Match(password, @"/[a-z]/", RegexOptions.ECMAScript).Count) * 2;

			// Upper case
			score += (length - Regex.Match(password, @"/[A-Z]/", RegexOptions.ECMAScript).Count) * 2;

			// Numbers
			score += Regex.Match(password, @"/[0-9]/", RegexOptions.ECMAScript).Count * 4;

			// Symbols
			score += Regex.Match(password, "/[$-/:-?{-~!\"^_`\\[\\]]/", RegexOptions.ECMAScript).Count * 6;

			// Middle symbols/numbers
			score += Regex.Match(password, "/^.{1,}[$-/:-?{-~!\"^_`\\[\\]0-9].{1,}$/", RegexOptions.ECMAScript).Count * 2;

			// ** DEDUCTIONS

			// Letters only
			if (Regex.Match(password, @"/[a-zA-Z]/", RegexOptions.ECMAScript).Count == length) {
				score -= length;
			}

			// Numbers only
			if (Regex.Match(password, @"/[0-9]/", RegexOptions.ECMAScript).Count == length) {
				score -= length;
			}

			return score;
		}

	}

}