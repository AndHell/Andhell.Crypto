# Symmetric/Secret Key Cryptography

In symmetric cryptography, a secret key is used. To communicate, this key needs to be exchanged. A third party should never be able to see/get this key.

## Encrypt
To encrypt and decrypt messages with a secret key, use the `SecretLocker` class.

```cs
var TEST_STRING = "eine kuh macht muh, viele kühe machen mühe"
// Create a new Symmertic Key
var key = new Key();
// Create a locker with this key
var locker = new SecretLocker(key);
// Encrypt the Text
var ciphertext = locker.Lock(TEST_STRING);
// Decrypt the Text
var plaintext = locker.UnlockString(ciphertext);

// Clear keys from memory
locker.Clear();
```

## Authenticate
To authenticate a message with a secret key, use the `HMACHashBox` class.


Example:  
> Alice and Bob share a secret Key `K` and want to exchange a message `M`.  
> If Alice sends a tag `T` with `T = MAC(M, K)` together with `M`, Bob can validate that the received message `M'` is not tampered, and indeed, sent from Alice (or at least someone who knows `K`). To do so, he computes `T' = MAC(M', K)` on his own, and compares the tags `T` and `T'`.
> *Note that the Key `K` is not transmitted. Only `T` and `M`.*


```cs
string Text = "Hallo Welt!";
Key key = new Key();
HMACHashBox hmac = new Hash.HMACHashBox(key);
Hashed hash = hmac.Compute(Text);

var tag = hash.Hash;

//Verify
Hashed hash = new Hashed(tag);

if (hash.Verify(Text, key))
    // Authentication OK!

hmac.Clear();
```