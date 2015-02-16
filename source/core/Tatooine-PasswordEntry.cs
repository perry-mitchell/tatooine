using System;
using System.Collections;
using System.Collections.Generic;
using System.Security;
using System.Linq;

using Tatooine.IO;

namespace Tatooine {

	public class PasswordEntry {

		protected Hashtable data;

		public PasswordEntry(Hashtable entryData) {
			data = entryData;
		}

		public string getGroup() {
			return (data.ContainsKey("group")) ? (string)data["group"] : "";
		}

		public Dictionary<string, string> getProperties() {
			if (data.ContainsKey("properties")) {
				Hashtable properties = (Hashtable)data["properties"];
				return Tools.Encoding.hashtableToDictionary<string, string>(properties);
			} else {
				return new Dictionary<string, string>();
			}
		}

		public string getProperty(string propKey) {
			if (data.ContainsKey("properties")) {
				Hashtable properties = (Hashtable)data["properties"];
				return (properties.ContainsKey(propKey)) ? (string)properties[propKey] : "";
			}
			return "";
		}

		public List<string> getPropertyNames() {
			return getProperties().Keys.ToList();
		}

		public string getTitle() {
			return (data.ContainsKey("title")) ? (string)data["title"] : "";
		}

		public PasswordEntry setGroup(string newGroup) {
			if (data.ContainsKey("group")) {
				data["group"] = newGroup;
			} else {
				data.Add("group", newGroup);
			}
			return this;
		}

		public PasswordEntry setProperty(string propKey, string propVal) {
			if (!data.ContainsKey("properties")) {
				data.Add("properties", new Hashtable());
			}
			Hashtable properties = (Hashtable)data["properties"];
			if (properties.ContainsKey(propKey)) {
				properties[propKey] = propVal;
			} else {
				properties.Add(propKey, propVal);
			}
			return this;
		}

		public PasswordEntry setTitle(string newTitle) {
			if (data.ContainsKey("title")) {
				data["title"] = newTitle;
			} else {
				data.Add("title", newTitle);
			}
			return this;
		}

	}

}