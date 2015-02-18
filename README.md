Tatooine
========

A C# based, cross-platform, password management system.

Tatooine was designed, primarily, to be a minimalistic & reliable password manager that has binaries available for most common operating systems. Along with these ideals, Tatooine hopes to provide the most comprehensive number of password-archive sources, including (eventually) (and not limited to):

 * Dropbox
 * OwnCloud
 * iCloud
 * Cubby
 * Ubuntu One
 * WebDAV
 * Local storage
 * Hosted password storage
 
This repository
---------------

This repo is home to both the core system (Tatooine) as well as the GTK desktop source (TatooineDesktop).

### Stability

* Core --> [![Build Status](http://penkins.doomdns.org/buildStatus/icon?job=Tatooine-core)](http://penkins.doomdns.org/job/Tatooine-core/)

Development environment
-----------------------

The core system has primarily been built and compiled on both Debian Linux and Mac OSX using Mono. Obviously, being a cross-platform application, using only libraries that Mono supports is a necessity.

The desktop GTK solution has been developed in both Xamarin (Mac) and MonoDevelop (Debian).

### Coding style

Although there may be some exceptions to these guidelines during the infancy of the project, it's imperative that some code style is adheared to:

 * Camel-case, lower-case first letter for functions and variables
 * Camel-case, upper-case first letter for classes/namespaces etc.
 * Functions in alphabetical order, excluding constructor and magic methods
 * All braces start on same-line
 
Eg.

```
 	class SomeClass {
	
		public SomeClass() {
			setupSomeStuff("...");
		}
		
		protected void setupSomeStuff(string amazingData) {
			
		}
	
	}
```

Encryption of the archives
--------------------------

Currently, password archives are JSON encoded before being encrypted using 256bit AES. Any software that claims to "manage passwords" must be secure, especially one that plans to source its archive content from cloud based systems. The encryption functionality of this system is then by-far the most important piece, so it should be treated as such - recommendations on strengthening the encryption process are most welcome!