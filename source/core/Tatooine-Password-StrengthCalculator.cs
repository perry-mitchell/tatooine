using System;

namespace Tatooine.Password {

	public class StrengthCalculator {

		protected string _password;

		protected StrengthCalculator(string password) {
			_password = password;
		}

	}

}