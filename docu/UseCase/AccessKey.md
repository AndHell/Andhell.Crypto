# Access Key

AccessKeys, like database or API secrets, should not be stored are plaintext in a config file. Instead use the `AccessKey` class to encrypt and decrypt the secret.

`Storeable` encrypts the secret with the [Windows DPAPI](https://docs.microsoft.com/en-us/dotnet/standard/security/how-to-use-data-protection) on the user level. As a result, the access keys can only be decrypted on a specific machine with a specific user logged in. 

To deploy API keys, the suggested process is to enter them manually during the setup phase on the target machine. (Or, if this is not possible, encrypt them at the first launch and then delete the plaintext keys).

## Store
On Windows, access keys can be encrypted with the [Windows DPAPI](https://docs.microsoft.com/en-us/dotnet/standard/security/how-to-use-data-protection).

```cs
var accessKey = new AccessKey("API SECRET");
// encrypt
var storeable = accessKey.Storable();

// Store string to Config
Store(storeable.ProtectedString);

// Load string
string stored_s = Load();
ProtectedKey stored = new ProtectedKey(stored_s);

// Decrypt Key
var loadedKey = new AccessKey(stored);
```

**Important**: *`Storeable` is currently not available on Linux and Mac and will throw a `NotImplementedException`.*

## Clear
After a key is not needed any longer, `Clear()` should be called, to override the key in memory.

```cs
accessKey.Clear();
```