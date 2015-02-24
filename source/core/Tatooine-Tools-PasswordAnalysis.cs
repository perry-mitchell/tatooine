using System;

namespace Tatooine.Tools {

	public class PasswordAnalysis {

		private PasswordAnalysis() {}

		public static int countSequentialCharacters(string text) {
			int seq = 0;
			int lastChar = -1;
			int dir = 0;
			for (int i = 0; i < text.Length; i += 1) {
				int thisChar = (int)text[i];
				bool dirIncreasing = (thisChar == (lastChar + 1)) && (lastChar > -1);
				bool dirDecreasing = (thisChar == (lastChar - 1)) && (lastChar > -1);
				if (dirIncreasing) {
					if (dir == 0) {
						seq += 2;
					} else if (dir == 1) {
						seq += 1;
					}
					dir = 1;
				} else if (dirDecreasing) {
					if (dir == 0) {
						seq += 2;
					} else if (dir == -1) {
						seq += 1;
					}
					dir = -1;
				} else {
					dir = 0;
				}
				lastChar = thisChar;
			}
			return seq;
		}

	}

}