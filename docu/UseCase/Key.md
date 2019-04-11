# Key
There are three types of cryptographic Keys:

- Symmetric Keys: `Key`
- Asymmetric Keys: `KeyPair`
    - Private Key:  `PrivateSecretKey`
    - Public Key: `PublicKey`
- Asymmetric Keys (Signatures): `SigningKeyPair`
    - Private Key:  `PrivateSecretKey`
    - Public Key: `PublicKey`


## Create
To create a new key, just create a new `Key` object without parameters.

```cs
// Symmetric Key
var symmetricKey = new Key();

// Asymmetric Key
var asymmetricKeyPair = new KeyPair();
var privateKey = asymmetricKeyPair.Secret;
var publicKey = asymmetricKeyPair.Public;

// Asymmetric Key for Signatures
var signingKeyPair = new SigningKeyPair();
var privateSigningKey = signingKeyPair.Secret;
var publicSigningKey = signingKeyPair.Public;
```

## Store
On Windows, keys can be encrypted with the [Windows DPAPI](https://docs.microsoft.com/en-us/dotnet/standard/security/how-to-use-data-protection).

```cs
var key = new Key();
// encrypt
var storeable = key.Storable();

// Load Encrypted Key
var loadedKey = new Key(storeable);
```

**Important**: *`Storeable` is currently not available on Linux and Mac and will throw a `NotImplementedException`.*

## Clear
After a key is not needed any longer, `Clear()` should be called, to override the key in memory.

```cs
var key = new Key();

key.Clear();
```