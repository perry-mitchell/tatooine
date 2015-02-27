using System;
using System.Collections.Generic;

namespace Tatooine.Password {

	// idea from: http://stackoverflow.com/questions/8002455/how-to-easily-initialize-a-list-of-tuples
	public class PasswordCharsetTupleList<T1, T2, T3> : List<Tuple<T1, T2, T3>> {
		public void Add(T1 item, T2 item2, T3 item3) {
			Add(new Tuple<T1, T2, T3>(item, item2, item3));
		}
	}

	public class PasswordGeneratorOptions {

		protected PasswordCharsetTupleList<string, bool, string> charsets;
		protected int length;

		public PasswordGeneratorOptions() {
			// Defaults:
			length = 16;

			// Characters:
			charsets = new PasswordCharsetTupleList<string, bool, string> {
				{ "alpha-low", true, "abcdefghijklmnopqrstuvwxyz" },
				{ "alpha-up", true, "ABCDEFGHIJKLMNOPQRSTUVWXYZ" },
				{ "numeric", true, "0123456789" },
				{ "dash", false, "-" },
				{ "underline", false, "_" },
				{ "space", false, " " },
				{ "special", true, "~!@#$%^&*+=;:,./?|" },
				{ "brackets", false, "[]{}()<>" }
			};
		}

		public void setCharsetStatus(string name, bool status) {
			foreach (Tuple<string, bool, string> charset in charsets) {
				if (charset.Item1.Equals(name)) {
					charset.Item2 = status;
				}
			}
		}

	}

	public class PasswordGenerator {



	}

}