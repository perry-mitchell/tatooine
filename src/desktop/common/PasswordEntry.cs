using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Tatooine {

	public class PasswordEntry {

		protected Hashtable data;

		public PasswordEntry(Hashtable entryData) {
			data = entryData;
		}

		public string getGroup() {
			return (data.ContainsKey("group")) ? (string)data["group"] : "";
		}

		public string getProperty(string propKey) {
			if (data.ContainsKey("properties")) {
				Hashtable properties = (Hashtable)data["properties"];
				return (properties.ContainsKey(propKey)) ? (string)properties[propKey] : "";
			}
			return "";
		}

		public List<string> getPropertyNames() {
			if (data.ContainsKey("properties")) {
				Hashtable properties = (Hashtable)data["properties"];
				Dictionary<string, string> props = Tools.Encoding.hashtableToDictionary<string, string>(properties);
				return props.Keys.ToList();
			} else {
				return new List<string>();
			}
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