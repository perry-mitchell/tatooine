using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Linq;

namespace Tatooine.Tools {

	class Encoding {

		private Encoding() {}

		public static Dictionary<K, V> hashtableToDictionary<K, V> (Hashtable table) {
			return table
				.Cast<DictionaryEntry> ()
				.ToDictionary (kvp => (K)kvp.Key, kvp => (V)kvp.Value);
		}

		public static string sha256(string text) {
			SHA256Managed crypt = new SHA256Managed();
			string hash = String.Empty;
			byte[] crypto = crypt.ComputeHash(System.Text.Encoding.UTF8.GetBytes(text), 0, System.Text.Encoding.UTF8.GetByteCount(text));
			foreach (byte bit in crypto) {
				hash += bit.ToString("x2");
			}
			return hash;
		}

	}

}