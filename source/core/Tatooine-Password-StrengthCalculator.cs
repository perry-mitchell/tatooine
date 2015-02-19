using System;
using System.Text.RegularExpressions;

namespace Tatooine.Password {

	// Scoring algorithm borrowed from this post:
	//		http://stackoverflow.com/questions/12899876/checking-strings-for-a-strong-enough-password

	public enum PasswordScore {
		Blank = 0,
		VeryWeak = 1,
		Weak = 2,
		Medium = 3,
		Strong = 4,
		VeryStrong = 5
	}

	public class StrengthCalculator {

		protected string _password;
		protected PasswordScore _score;

		protected StrengthCalculator(string password) {
			_password = password;
			_score = PasswordScore.VeryWeak;

			processPasswordScore();
		}

		public static PasswordScore calculateStrength(string password) {
			StrengthCalculator calc = new StrengthCalculator(password);
			return calc.getPasswordScore();
		}

		protected PasswordScore getPasswordScore() {
			return _score;
		}

		protected void processPasswordScore() {
			_score = PasswordScore.VeryWeak;

			if (_password.Length < 1) {
				_score = PasswordScore.Blank;
			}
			if (_password.Length < 4) {
				_score = PasswordScore.VeryWeak;
			}

			if (_password.Length >= 8) {
				_score += 1;
			}
			if (_password.Length >= 12) {
				_score += 1;
			}
			if (Regex.Match(_password, @"/\d+/", RegexOptions.ECMAScript).Success) {
				_score += 1;
			}
			if (Regex.Match(_password, @"/[a-z]/", RegexOptions.ECMAScript).Success &&
				Regex.Match(_password, @"/[A-Z]/", RegexOptions.ECMAScript).Success) {
				_score += 1;
			}
			if (Regex.Match(_password, @"/.[!,@,#,$,%,^,&,*,?,_,~,-,£,(,)]/", RegexOptions.ECMAScript).Success) {
				_score += 1;
			}
		}

	}

}