# Asymmetric/Public Key Cryptography
Public Key cryptography allows the usage a key pair of a private and a public key. The public key can be shared with everyone, while the private key needs to be kept secret.

If Alice wants to send an encrypted message to Bob, she needs Bobs public key. Bob can then use his private Key to Decrypt the message.

![Alice To Bob](../img/PubKeyRoundTrip.png)

To ensure that the message is indeed send by Alice, she can use her private key to sign the message. Bob then need Alice public key, to verify the signature.

## Encrypt
To encrypt and decrypt messages with an asymmetric `KeyPair`, use the `SharedLocker` class.

```cs
var MESSAGE = "eine kuh macht muh, viele kühe machen mühe"
// Create a KeyPair for Alice and Bob
var AliceKeys = new KeyPair();
var BobKeys = new KeyPair();

// Create a Lockbox to encrypt Messages from Alice to Bob
var locker = new SharedLocker(recieverPubKey: BobKeys.Public, senderPrivKey: AliceKeys.Secret);

// Encrypt the message
var locked = locker.Lock(MESSAGE);

// Bob can then Decrypt the message
var unlocked = locked.UnlockString(AliceKeys.Public, BobKeys.Secret);

// Clear keys from memory
locker.Clear();
```

## Sign
To Sign a Message with a `SigningKeyPair`, use the `Signer` class.

```cs
// Create KeyPair
var AliceKeys = new SigningKeyPair();

// Create Sigend with the Private Key
var pen = new Signer(AliceKeys.Secret);

// create signature
var signature = pen.Sign(MESSAGE);

// Validate with the Public Key
if(signature.Verify(MESSAGE, AliceKeys.Public))
    // Singature is Valid!

// Clear keys from memory
pen.Clear();
```