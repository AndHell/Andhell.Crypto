Cryptography Library with .NET Standard 2.0 and [libsodium](https://github.com/jedisct1/libsodium).

## What is this?
This library aims to make the use of cryptography easier. To do so, this Project builds around libsodium, but, for example, hides every `byte[]` for a Key or a Hash inside a container class. To get an impression, see the [Examples](#examples) below.

To make the entry even simpler, take a look at the ["By Usecase"](docu/By_UseCase.md) documentation.

If already know how to use cryptography and need more flexibility to build strong protocols, you are better of with using [libsodium](https://github.com/jedisct1/libsodium) (or another library) directly.

## Andhell.Crypto
Implementation with [libsodium](https://github.com/jedisct1/libsodium).

## Features
- [x] Password Hashing
- [x] General Hashing
- [x] Keyed Hashing
- [ ] Password based Key Derivation *not ready*
- [x] Symmetric Encryption and Decryption
    - [x] Authenticated Encryption
- [x] Asymmetric Encryption and Decryption

## Tools and Build
The Solution can be opened with [Visual Studio 2017](https://visualstudio.microsoft.com/vs/) (and later) or [VS Core](https://code.visualstudio.com/). It is based [.NET Standard 2.0](https://docs.microsoft.com/en-us/dotnet/standard/net-standard). The MSTest Unit Tests are based on [.NET Core 2.1](https://docs.microsoft.com/en-us/dotnet/core/)

**Build on Linux:**
```bash
cd src/andhell.crypto
dotnet build
```

# Documentation
- [By Usecase](docu/By_UseCase.md)
- [API](docu/API/Andhell.Crypto.Salty.md) 

# Examples
### Store and Verify Password
```cs
// Create a Password object for the string
var password = new Password("Correct Horse Battery Staple");
// Hash the Pasword to get a storable data
ISecuredPassword storablePassword = password.Storable();           
// To Verify
if (storablePassword.Verify(password))
    Console.WriteLine("Password matched");
```

### Generic Hash
```cs
var MESSAGE = "eine kuh macht muh, viele kühe machen mühe"
// Create a new HashBox
IHashBox hashBox = new HashBox();
// Compute the Hash
var result = hashBox.Compute(MESSAGE);
// Verify if the hash is the hash MESSAGE
if (result.Verify(MESSAGE)) 
    Console.WriteLine("Hash matched!");
```

### Encrypt and Decrypt Text with a Symmetric Key
```cs
var MESSAGE = "eine kuh macht muh, viele kühe machen mühe"
// Create a new Symmetric Key
var key = new Key();
// Create a locker with this key
var locker = new SecretLocker(key);
// Encrypt the Text
var ciphertext = locker.Lock(MESSAGE);
// Decrypt the Text
var plaintext = locker.UnlockString(ciphertext);

// clear keys from Memory
key.Clear();
locker.Clear();
```

### Encrypt and Decrypt Text with a Asymmetric KeyPair
```cs
var MESSAGE = "eine kuh macht muh, viele kühe machen mühe"
// Create a KeyPair for Alice and Bob
var AliceKeys = new KeyPair();
var BobKeys = new KeyPair();

// Create a Locker to encrypt Messages from Alice to Bob
var locker = new SharedLocker(recieverPubKey: BobKeys.Public, senderPrivKey: AliceKeys.Secret);
// Encrypt the Message
var locked = locker.Lock(MESSAGE);

// Bob can then decrypt the Message
var unlocked = locked.UnlockString(AliceKeys.Public, BobKeys.Secret);

// clear keys from Memory
AliceKeys.Clear();
BobKeys.Clear();
locker.Clear();
```

# Licenses
- Andhell.Crypto: [LGPG](LICENSE)
- [libsodium](https://github.com/jedisct1/libsodium):  [ISC License](https://github.com/jedisct1/libsodium/blob/master/LICENSE)
- [Sodium.Core](https://github.com/tabrath/libsodium-core): [MIT](https://github.com/tabrath/libsodium-core/blob/master/LICENSE)