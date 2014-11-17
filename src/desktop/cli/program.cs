using System;
using Tatooine;

namespace Tatooine.CLI {

	class Program {

		public static void Main(string[] args) {
			Console.WriteLine("Tatooine Password Management: 0.1.0");

			if (args.Length > 0) {
				Interactive i = new Interactive(args[0]);
			} else {
				throw new Exception("Invalid arguments: A password archive file is required");
			}
		}

	}

}