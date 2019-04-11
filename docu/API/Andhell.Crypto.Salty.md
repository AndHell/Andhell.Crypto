<a name='assembly'></a>
# Andhell.Crypto.Salty

## Contents

- [GenericHash](#T-Andhell-Crypto-Salty-Hash-GenericHash 'Andhell.Crypto.Salty.Hash.GenericHash')
  - [#ctor(hash)](#M-Andhell-Crypto-Salty-Hash-GenericHash-#ctor-System-Byte[]- 'Andhell.Crypto.Salty.Hash.GenericHash.#ctor(System.Byte[])')
  - [#ctor(hash)](#M-Andhell-Crypto-Salty-Hash-GenericHash-#ctor-System-String- 'Andhell.Crypto.Salty.Hash.GenericHash.#ctor(System.String)')
  - [Hash](#P-Andhell-Crypto-Salty-Hash-GenericHash-Hash 'Andhell.Crypto.Salty.Hash.GenericHash.Hash')
  - [HashBytes](#P-Andhell-Crypto-Salty-Hash-GenericHash-HashBytes 'Andhell.Crypto.Salty.Hash.GenericHash.HashBytes')
  - [Verify(hash)](#M-Andhell-Crypto-Salty-Hash-GenericHash-Verify-Andhell-Crypto-IHashed- 'Andhell.Crypto.Salty.Hash.GenericHash.Verify(Andhell.Crypto.IHashed)')
  - [Verify(plaintext)](#M-Andhell-Crypto-Salty-Hash-GenericHash-Verify-System-String- 'Andhell.Crypto.Salty.Hash.GenericHash.Verify(System.String)')
  - [Verify(plaindata)](#M-Andhell-Crypto-Salty-Hash-GenericHash-Verify-System-Byte[]- 'Andhell.Crypto.Salty.Hash.GenericHash.Verify(System.Byte[])')
  - [Verify(plaintext,key)](#M-Andhell-Crypto-Salty-Hash-GenericHash-Verify-System-String,Andhell-Crypto-IKey- 'Andhell.Crypto.Salty.Hash.GenericHash.Verify(System.String,Andhell.Crypto.IKey)')
  - [Verify(plaindata,key)](#M-Andhell-Crypto-Salty-Hash-GenericHash-Verify-System-Byte[],Andhell-Crypto-IKey- 'Andhell.Crypto.Salty.Hash.GenericHash.Verify(System.Byte[],Andhell.Crypto.IKey)')
- [HMACHashBox](#T-Andhell-Crypto-Salty-Hash-HMACHashBox 'Andhell.Crypto.Salty.Hash.HMACHashBox')
  - [#ctor()](#M-Andhell-Crypto-Salty-Hash-HMACHashBox-#ctor 'Andhell.Crypto.Salty.Hash.HMACHashBox.#ctor')
  - [#ctor(key)](#M-Andhell-Crypto-Salty-Hash-HMACHashBox-#ctor-Andhell-Crypto-IKey- 'Andhell.Crypto.Salty.Hash.HMACHashBox.#ctor(Andhell.Crypto.IKey)')
  - [Compute(message)](#M-Andhell-Crypto-Salty-Hash-HMACHashBox-Compute-System-String- 'Andhell.Crypto.Salty.Hash.HMACHashBox.Compute(System.String)')
  - [Compute(data)](#M-Andhell-Crypto-Salty-Hash-HMACHashBox-Compute-System-Byte[]- 'Andhell.Crypto.Salty.Hash.HMACHashBox.Compute(System.Byte[])')
- [HashBox](#T-Andhell-Crypto-Salty-Hash-HashBox 'Andhell.Crypto.Salty.Hash.HashBox')
  - [#ctor(generateKey)](#M-Andhell-Crypto-Salty-Hash-HashBox-#ctor-System-Boolean- 'Andhell.Crypto.Salty.Hash.HashBox.#ctor(System.Boolean)')
  - [#ctor(key)](#M-Andhell-Crypto-Salty-Hash-HashBox-#ctor-Andhell-Crypto-IKey- 'Andhell.Crypto.Salty.Hash.HashBox.#ctor(Andhell.Crypto.IKey)')
  - [Key](#P-Andhell-Crypto-Salty-Hash-HashBox-Key 'Andhell.Crypto.Salty.Hash.HashBox.Key')
  - [Compute(message)](#M-Andhell-Crypto-Salty-Hash-HashBox-Compute-System-String- 'Andhell.Crypto.Salty.Hash.HashBox.Compute(System.String)')
  - [Compute(data)](#M-Andhell-Crypto-Salty-Hash-HashBox-Compute-System-Byte[]- 'Andhell.Crypto.Salty.Hash.HashBox.Compute(System.Byte[])')
- [HashedTag](#T-Andhell-Crypto-Salty-Hash-HashedTag 'Andhell.Crypto.Salty.Hash.HashedTag')
  - [Verify(hash)](#M-Andhell-Crypto-Salty-Hash-HashedTag-Verify-Andhell-Crypto-IHashed- 'Andhell.Crypto.Salty.Hash.HashedTag.Verify(Andhell.Crypto.IHashed)')
  - [Verify()](#M-Andhell-Crypto-Salty-Hash-HashedTag-Verify-System-String- 'Andhell.Crypto.Salty.Hash.HashedTag.Verify(System.String)')
  - [Verify()](#M-Andhell-Crypto-Salty-Hash-HashedTag-Verify-System-Byte[]- 'Andhell.Crypto.Salty.Hash.HashedTag.Verify(System.Byte[])')
  - [Verify(plaintext,key)](#M-Andhell-Crypto-Salty-Hash-HashedTag-Verify-System-String,Andhell-Crypto-IKey- 'Andhell.Crypto.Salty.Hash.HashedTag.Verify(System.String,Andhell.Crypto.IKey)')
  - [Verify(plaindata,key)](#M-Andhell-Crypto-Salty-Hash-HashedTag-Verify-System-Byte[],Andhell-Crypto-IKey- 'Andhell.Crypto.Salty.Hash.HashedTag.Verify(System.Byte[],Andhell.Crypto.IKey)')
- [Key](#T-Andhell-Crypto-Salty-Key 'Andhell.Crypto.Salty.Key')
  - [#ctor(key)](#M-Andhell-Crypto-Salty-Key-#ctor-System-Byte[]- 'Andhell.Crypto.Salty.Key.#ctor(System.Byte[])')
  - [#ctor(key)](#M-Andhell-Crypto-Salty-Key-#ctor-Andhell-Crypto-IProtectedKey- 'Andhell.Crypto.Salty.Key.#ctor(Andhell.Crypto.IProtectedKey)')
  - [#ctor()](#M-Andhell-Crypto-Salty-Key-#ctor 'Andhell.Crypto.Salty.Key.#ctor')
  - [Bytes](#P-Andhell-Crypto-Salty-Key-Bytes 'Andhell.Crypto.Salty.Key.Bytes')
  - [Clear()](#M-Andhell-Crypto-Salty-Key-Clear 'Andhell.Crypto.Salty.Key.Clear')
  - [Storable()](#M-Andhell-Crypto-Salty-Key-Storable 'Andhell.Crypto.Salty.Key.Storable')
- [KeyPair](#T-Andhell-Crypto-Salty-KeyPair 'Andhell.Crypto.Salty.KeyPair')
  - [#ctor()](#M-Andhell-Crypto-Salty-KeyPair-#ctor 'Andhell.Crypto.Salty.KeyPair.#ctor')
  - [#ctor(privKey)](#M-Andhell-Crypto-Salty-KeyPair-#ctor-Andhell-Crypto-IPrivateSecretKey- 'Andhell.Crypto.Salty.KeyPair.#ctor(Andhell.Crypto.IPrivateSecretKey)')
  - [#ctor(privKey,pubKey)](#M-Andhell-Crypto-Salty-KeyPair-#ctor-Andhell-Crypto-IPrivateSecretKey,Andhell-Crypto-IPublicKey- 'Andhell.Crypto.Salty.KeyPair.#ctor(Andhell.Crypto.IPrivateSecretKey,Andhell.Crypto.IPublicKey)')
  - [Public](#P-Andhell-Crypto-Salty-KeyPair-Public 'Andhell.Crypto.Salty.KeyPair.Public')
  - [Secret](#P-Andhell-Crypto-Salty-KeyPair-Secret 'Andhell.Crypto.Salty.KeyPair.Secret')
- [Locked](#T-Andhell-Crypto-Salty-Locked 'Andhell.Crypto.Salty.Locked')
  - [Ciphertext](#P-Andhell-Crypto-Salty-Locked-Ciphertext 'Andhell.Crypto.Salty.Locked.Ciphertext')
  - [Combined](#P-Andhell-Crypto-Salty-Locked-Combined 'Andhell.Crypto.Salty.Locked.Combined')
  - [Nonce](#P-Andhell-Crypto-Salty-Locked-Nonce 'Andhell.Crypto.Salty.Locked.Nonce')
- [Message](#T-Andhell-Crypto-Salty-Message 'Andhell.Crypto.Salty.Message')
  - [Text](#P-Andhell-Crypto-Salty-Message-Text 'Andhell.Crypto.Salty.Message.Text')
  - [Authenticate(key)](#M-Andhell-Crypto-Salty-Message-Authenticate-Andhell-Crypto-IKey- 'Andhell.Crypto.Salty.Message.Authenticate(Andhell.Crypto.IKey)')
  - [Fingerprint()](#M-Andhell-Crypto-Salty-Message-Fingerprint 'Andhell.Crypto.Salty.Message.Fingerprint')
  - [Lock(key)](#M-Andhell-Crypto-Salty-Message-Lock-Andhell-Crypto-IKey- 'Andhell.Crypto.Salty.Message.Lock(Andhell.Crypto.IKey)')
  - [Sign(key)](#M-Andhell-Crypto-Salty-Message-Sign-Andhell-Crypto-IPrivateSecretKey- 'Andhell.Crypto.Salty.Message.Sign(Andhell.Crypto.IPrivateSecretKey)')
  - [Unlock(key,locked)](#M-Andhell-Crypto-Salty-Message-Unlock-Andhell-Crypto-IKey,Andhell-Crypto-ILocked- 'Andhell.Crypto.Salty.Message.Unlock(Andhell.Crypto.IKey,Andhell.Crypto.ILocked)')
  - [Verify(key,messageHash)](#M-Andhell-Crypto-Salty-Message-Verify-Andhell-Crypto-IKey,Andhell-Crypto-IHashed- 'Andhell.Crypto.Salty.Message.Verify(Andhell.Crypto.IKey,Andhell.Crypto.IHashed)')
  - [Verify(fingerprint)](#M-Andhell-Crypto-Salty-Message-Verify-Andhell-Crypto-IHashed- 'Andhell.Crypto.Salty.Message.Verify(Andhell.Crypto.IHashed)')
- [Password](#T-Andhell-Crypto-Salty-Password 'Andhell.Crypto.Salty.Password')
  - [#ctor(password)](#M-Andhell-Crypto-Salty-Password-#ctor-System-String- 'Andhell.Crypto.Salty.Password.#ctor(System.String)')
  - [Plaintext](#P-Andhell-Crypto-Salty-Password-Plaintext 'Andhell.Crypto.Salty.Password.Plaintext')
  - [DeriveKey()](#M-Andhell-Crypto-Salty-Password-DeriveKey 'Andhell.Crypto.Salty.Password.DeriveKey')
  - [Storable()](#M-Andhell-Crypto-Salty-Password-Storable 'Andhell.Crypto.Salty.Password.Storable')
- [PrivateSecretKey](#T-Andhell-Crypto-Salty-PrivateSecretKey 'Andhell.Crypto.Salty.PrivateSecretKey')
- [ProtectedKey](#T-Andhell-Crypto-Salty-ProtectedKey 'Andhell.Crypto.Salty.ProtectedKey')
- [PublicKey](#T-Andhell-Crypto-Salty-PublicKey 'Andhell.Crypto.Salty.PublicKey')
- [SecretLocker](#T-Andhell-Crypto-Salty-SecretLocker 'Andhell.Crypto.Salty.SecretLocker')
  - [#ctor(key)](#M-Andhell-Crypto-Salty-SecretLocker-#ctor-Andhell-Crypto-IKey- 'Andhell.Crypto.Salty.SecretLocker.#ctor(Andhell.Crypto.IKey)')
  - [Lock(data)](#M-Andhell-Crypto-Salty-SecretLocker-Lock-System-Byte[]- 'Andhell.Crypto.Salty.SecretLocker.Lock(System.Byte[])')
  - [Lock(data)](#M-Andhell-Crypto-Salty-SecretLocker-Lock-System-String- 'Andhell.Crypto.Salty.SecretLocker.Lock(System.String)')
  - [UnlockBytes(locked)](#M-Andhell-Crypto-Salty-SecretLocker-UnlockBytes-Andhell-Crypto-ILocked- 'Andhell.Crypto.Salty.SecretLocker.UnlockBytes(Andhell.Crypto.ILocked)')
  - [UnlockString(locked)](#M-Andhell-Crypto-Salty-SecretLocker-UnlockString-Andhell-Crypto-ILocked- 'Andhell.Crypto.Salty.SecretLocker.UnlockString(Andhell.Crypto.ILocked)')
- [SecuredPassword](#T-Andhell-Crypto-Salty-SecuredPassword 'Andhell.Crypto.Salty.SecuredPassword')
  - [#ctor(hash)](#M-Andhell-Crypto-Salty-SecuredPassword-#ctor-System-String- 'Andhell.Crypto.Salty.SecuredPassword.#ctor(System.String)')
  - [Hash](#P-Andhell-Crypto-Salty-SecuredPassword-Hash 'Andhell.Crypto.Salty.SecuredPassword.Hash')
  - [Verify(password)](#M-Andhell-Crypto-Salty-SecuredPassword-Verify-Andhell-Crypto-IPassword- 'Andhell.Crypto.Salty.SecuredPassword.Verify(Andhell.Crypto.IPassword)')
- [SharedLocked](#T-Andhell-Crypto-Salty-SharedLocked 'Andhell.Crypto.Salty.SharedLocked')
  - [Cipher](#P-Andhell-Crypto-Salty-SharedLocked-Cipher 'Andhell.Crypto.Salty.SharedLocked.Cipher')
  - [Combined](#P-Andhell-Crypto-Salty-SharedLocked-Combined 'Andhell.Crypto.Salty.SharedLocked.Combined')
  - [Nonce](#P-Andhell-Crypto-Salty-SharedLocked-Nonce 'Andhell.Crypto.Salty.SharedLocked.Nonce')
  - [UnlockBytes(senderPubKey,recieverPrivKey)](#M-Andhell-Crypto-Salty-SharedLocked-UnlockBytes-Andhell-Crypto-IPublicKey,Andhell-Crypto-IPrivateSecretKey- 'Andhell.Crypto.Salty.SharedLocked.UnlockBytes(Andhell.Crypto.IPublicKey,Andhell.Crypto.IPrivateSecretKey)')
  - [UnlockString(senderPubKey,recieverPrivKey)](#M-Andhell-Crypto-Salty-SharedLocked-UnlockString-Andhell-Crypto-IPublicKey,Andhell-Crypto-IPrivateSecretKey- 'Andhell.Crypto.Salty.SharedLocked.UnlockString(Andhell.Crypto.IPublicKey,Andhell.Crypto.IPrivateSecretKey)')
- [SharedLocker](#T-Andhell-Crypto-Salty-SharedLocker 'Andhell.Crypto.Salty.SharedLocker')
  - [#ctor(recieverPubKey,senderPrivKey)](#M-Andhell-Crypto-Salty-SharedLocker-#ctor-Andhell-Crypto-IPublicKey,Andhell-Crypto-IPrivateSecretKey- 'Andhell.Crypto.Salty.SharedLocker.#ctor(Andhell.Crypto.IPublicKey,Andhell.Crypto.IPrivateSecretKey)')
  - [Lock(str)](#M-Andhell-Crypto-Salty-SharedLocker-Lock-System-String- 'Andhell.Crypto.Salty.SharedLocker.Lock(System.String)')
  - [Lock(str)](#M-Andhell-Crypto-Salty-SharedLocker-Lock-System-Byte[]- 'Andhell.Crypto.Salty.SharedLocker.Lock(System.Byte[])')
- [Signature](#T-Andhell-Crypto-Salty-Signature 'Andhell.Crypto.Salty.Signature')
  - [#ctor(signature)](#M-Andhell-Crypto-Salty-Signature-#ctor-System-Byte[]- 'Andhell.Crypto.Salty.Signature.#ctor(System.Byte[])')
  - [Bytes](#P-Andhell-Crypto-Salty-Signature-Bytes 'Andhell.Crypto.Salty.Signature.Bytes')
  - [Verify(data,key)](#M-Andhell-Crypto-Salty-Signature-Verify-System-Byte[],Andhell-Crypto-IPublicKey- 'Andhell.Crypto.Salty.Signature.Verify(System.Byte[],Andhell.Crypto.IPublicKey)')
  - [Verify(data,key)](#M-Andhell-Crypto-Salty-Signature-Verify-System-String,Andhell-Crypto-IPublicKey- 'Andhell.Crypto.Salty.Signature.Verify(System.String,Andhell.Crypto.IPublicKey)')
- [Signer](#T-Andhell-Crypto-Salty-Signer 'Andhell.Crypto.Salty.Signer')
  - [#ctor(privKey)](#M-Andhell-Crypto-Salty-Signer-#ctor-Andhell-Crypto-IPrivateSecretKey- 'Andhell.Crypto.Salty.Signer.#ctor(Andhell.Crypto.IPrivateSecretKey)')
  - [Sign(data)](#M-Andhell-Crypto-Salty-Signer-Sign-System-Byte[]- 'Andhell.Crypto.Salty.Signer.Sign(System.Byte[])')
  - [Sign(data)](#M-Andhell-Crypto-Salty-Signer-Sign-System-String- 'Andhell.Crypto.Salty.Signer.Sign(System.String)')
- [SigningKeyPair](#T-Andhell-Crypto-Salty-SigningKeyPair 'Andhell.Crypto.Salty.SigningKeyPair')
  - [#ctor()](#M-Andhell-Crypto-Salty-SigningKeyPair-#ctor 'Andhell.Crypto.Salty.SigningKeyPair.#ctor')
  - [#ctor(privKey)](#M-Andhell-Crypto-Salty-SigningKeyPair-#ctor-Andhell-Crypto-IPrivateSecretKey- 'Andhell.Crypto.Salty.SigningKeyPair.#ctor(Andhell.Crypto.IPrivateSecretKey)')
  - [#ctor(privKey,pubKey)](#M-Andhell-Crypto-Salty-SigningKeyPair-#ctor-Andhell-Crypto-IPrivateSecretKey,Andhell-Crypto-IPublicKey- 'Andhell.Crypto.Salty.SigningKeyPair.#ctor(Andhell.Crypto.IPrivateSecretKey,Andhell.Crypto.IPublicKey)')
  - [Public](#P-Andhell-Crypto-Salty-SigningKeyPair-Public 'Andhell.Crypto.Salty.SigningKeyPair.Public')
  - [Secret](#P-Andhell-Crypto-Salty-SigningKeyPair-Secret 'Andhell.Crypto.Salty.SigningKeyPair.Secret')
  - [Clear()](#M-Andhell-Crypto-Salty-SigningKeyPair-Clear 'Andhell.Crypto.Salty.SigningKeyPair.Clear')

<a name='T-Andhell-Crypto-Salty-Hash-GenericHash'></a>
## GenericHash `type`

##### Namespace

Andhell.Crypto.Salty.Hash

##### Summary

Represents a Generic Hash

<a name='M-Andhell-Crypto-Salty-Hash-GenericHash-#ctor-System-Byte[]-'></a>
### #ctor(hash) `constructor`

##### Summary

Represents a Generic Hash

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| hash | [System.Byte[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Byte[] 'System.Byte[]') | The hashed bytes |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') |  |
| [System.ArgumentException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentException 'System.ArgumentException') |  |

<a name='M-Andhell-Crypto-Salty-Hash-GenericHash-#ctor-System-String-'></a>
### #ctor(hash) `constructor`

##### Summary

Represents a Generic Hash

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| hash | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Hash as String. Uses the default string encoding from Utils.Secure.KeyEncode |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') |  |

<a name='P-Andhell-Crypto-Salty-Hash-GenericHash-Hash'></a>
### Hash `property`

##### Summary

Hash as String

Uses the default string encoding from Utils.Secure.KeyEncode

<a name='P-Andhell-Crypto-Salty-Hash-GenericHash-HashBytes'></a>
### HashBytes `property`

##### Summary

Hash as Byte[]

<a name='M-Andhell-Crypto-Salty-Hash-GenericHash-Verify-Andhell-Crypto-IHashed-'></a>
### Verify(hash) `method`

##### Summary

Checks is the Hashes are equal

##### Returns

True, if the Hash are equal

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| hash | [Andhell.Crypto.IHashed](#T-Andhell-Crypto-IHashed 'Andhell.Crypto.IHashed') | Hash to compare with |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') |  |

<a name='M-Andhell-Crypto-Salty-Hash-GenericHash-Verify-System-String-'></a>
### Verify(plaintext) `method`

##### Summary

Checks if the Hash of the plaintext equals the Hash

##### Returns

True, if the Hash are equal

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| plaintext | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | String to compare |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') |  |

<a name='M-Andhell-Crypto-Salty-Hash-GenericHash-Verify-System-Byte[]-'></a>
### Verify(plaindata) `method`

##### Summary

Checks if the Hash of the data equals the Hash

##### Returns

True, if the Hash are equal

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| plaindata | [System.Byte[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Byte[] 'System.Byte[]') | Bytes to compare |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') |  |

<a name='M-Andhell-Crypto-Salty-Hash-GenericHash-Verify-System-String,Andhell-Crypto-IKey-'></a>
### Verify(plaintext,key) `method`

##### Summary

Checks if the Keyed Hash of the plaintext equals the hash

##### Returns

true, is the hashed string matches the hash

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| plaintext | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | string to compare |
| key | [Andhell.Crypto.IKey](#T-Andhell-Crypto-IKey 'Andhell.Crypto.IKey') | Key used for hashing |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') |  |

<a name='M-Andhell-Crypto-Salty-Hash-GenericHash-Verify-System-Byte[],Andhell-Crypto-IKey-'></a>
### Verify(plaindata,key) `method`

##### Summary

Checks if the Keyed Hash of the data equals the Hash

##### Returns

True, if the Hash are equal

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| plaindata | [System.Byte[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Byte[] 'System.Byte[]') | Bytes to compare |
| key | [Andhell.Crypto.IKey](#T-Andhell-Crypto-IKey 'Andhell.Crypto.IKey') | Key used for hashing |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') |  |

<a name='T-Andhell-Crypto-Salty-Hash-HMACHashBox'></a>
## HMACHashBox `type`

##### Namespace

Andhell.Crypto.Salty.Hash

##### Summary

HashBox for Keyed Hashing
 
 Primitive: HMAC-SHA512-256 (libsodium crypt_auth)

##### Example

```cs
 string Text = "Hallo Welt!";
 Key key = new Key();
 HMACHashBox hmac = new Hash.HMACHashBox(key);
 Hashed hash = hmac.Compute(Text);
 var signed = hash.Hash;
 //Verify
 Hashed hash = new Hashed(signed);
 if (hash.Verify(Text, key))
     // Authentication OK!
 locker.Clear();
 
```

<a name='M-Andhell-Crypto-Salty-Hash-HMACHashBox-#ctor'></a>
### #ctor() `constructor`

##### Summary

HashBox for Keyed Hashing

Creates a new Key

##### Parameters

This constructor has no parameters.

<a name='M-Andhell-Crypto-Salty-Hash-HMACHashBox-#ctor-Andhell-Crypto-IKey-'></a>
### #ctor(key) `constructor`

##### Summary

HashBox for Keyed Hashing

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| key | [Andhell.Crypto.IKey](#T-Andhell-Crypto-IKey 'Andhell.Crypto.IKey') | The Key |

<a name='M-Andhell-Crypto-Salty-Hash-HMACHashBox-Compute-System-String-'></a>
### Compute(message) `method`

##### Summary

Hashes a Message

Primitive : HMAC-SHA512-256 (libsodium crypt_auth)

##### Returns

Returns the Hash in an IHashed container

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| message | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The message to be hashed. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') |  |

<a name='M-Andhell-Crypto-Salty-Hash-HMACHashBox-Compute-System-Byte[]-'></a>
### Compute(data) `method`

##### Summary

Hashes data

uses libsodiums crypt_auth (HMAC-SHA512-256)

##### Returns

Returns the Hash in an IHashed container

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| data | [System.Byte[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Byte[] 'System.Byte[]') | The data to be hashed. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') |  |
| [System.ArgumentException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentException 'System.ArgumentException') |  |

<a name='T-Andhell-Crypto-Salty-Hash-HashBox'></a>
## HashBox `type`

##### Namespace

Andhell.Crypto.Salty.Hash

##### Summary

Represents a General Hashing function.

##### Example

```cs
 IHashBox hashBox = new HashBox();
 var result = hashBox.Compute(TEST_STRING);
 if(result.Verify(TEST_STRING));
     // Hash matched!
 
```

<a name='M-Andhell-Crypto-Salty-Hash-HashBox-#ctor-System-Boolean-'></a>
### #ctor(generateKey) `constructor`

##### Summary

HashBox for General Hashing

Primitive: BLAKE2b (libsodium crypto_generichash)

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| generateKey | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | (Optional) Create a new random Key that is used for Keyed Hashing |

<a name='M-Andhell-Crypto-Salty-Hash-HashBox-#ctor-Andhell-Crypto-IKey-'></a>
### #ctor(key) `constructor`

##### Summary

HashBox for keyed Hashing

Primitive: BLAKE2b (libsodium crypto_generichash)

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| key | [Andhell.Crypto.IKey](#T-Andhell-Crypto-IKey 'Andhell.Crypto.IKey') | The Key for Keyed Hashing |

<a name='P-Andhell-Crypto-Salty-Hash-HashBox-Key'></a>
### Key `property`

##### Summary

The optional Key used for Keyed Hashing

<a name='M-Andhell-Crypto-Salty-Hash-HashBox-Compute-System-String-'></a>
### Compute(message) `method`

##### Summary

Hashes a Message

Primitive: BLAKE2b (libsodium crypto_generichash)

##### Returns

Returns the Hash in an IHashed container

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| message | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The Message |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') |  |

<a name='M-Andhell-Crypto-Salty-Hash-HashBox-Compute-System-Byte[]-'></a>
### Compute(data) `method`

##### Summary

Hashes data

Primitive: BLAKE2b (libsodium crypto_generichash)

##### Returns

Returns the Hash in an IHashed container

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| data | [System.Byte[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Byte[] 'System.Byte[]') | The Data. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') |  |
| [System.ArgumentException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentException 'System.ArgumentException') |  |

<a name='T-Andhell-Crypto-Salty-Hash-HashedTag'></a>
## HashedTag `type`

##### Namespace

Andhell.Crypto.Salty.Hash

##### Summary

Representes a HMAC Tag

<a name='M-Andhell-Crypto-Salty-Hash-HashedTag-Verify-Andhell-Crypto-IHashed-'></a>
### Verify(hash) `method`

##### Summary

Checks is the Hashes are equal

Compares in constant time

##### Returns

true, is the hashes are equal

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| hash | [Andhell.Crypto.IHashed](#T-Andhell-Crypto-IHashed 'Andhell.Crypto.IHashed') | Hash used for comparing |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') |  |

<a name='M-Andhell-Crypto-Salty-Hash-HashedTag-Verify-System-String-'></a>
### Verify() `method`

##### Summary

NOT DEFINED
To compare a HashTag you always need a key

##### Parameters

This method has no parameters.

<a name='M-Andhell-Crypto-Salty-Hash-HashedTag-Verify-System-Byte[]-'></a>
### Verify() `method`

##### Summary

NOT DEFINED
To compare a HashTag you always need a key

##### Parameters

This method has no parameters.

<a name='M-Andhell-Crypto-Salty-Hash-HashedTag-Verify-System-String,Andhell-Crypto-IKey-'></a>
### Verify(plaintext,key) `method`

##### Summary

Checks if the Keyed Hash of the plaintext equals the hash

##### Returns

true, is the hashed string matches the hash

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| plaintext | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | string to compare |
| key | [Andhell.Crypto.IKey](#T-Andhell-Crypto-IKey 'Andhell.Crypto.IKey') | Key used for hashing |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') |  |

<a name='M-Andhell-Crypto-Salty-Hash-HashedTag-Verify-System-Byte[],Andhell-Crypto-IKey-'></a>
### Verify(plaindata,key) `method`

##### Summary

Checks if the Keyed Hash of the data equals the Hash

##### Returns

True, if the Hash are equal

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| plaindata | [System.Byte[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Byte[] 'System.Byte[]') | Bytes to compare |
| key | [Andhell.Crypto.IKey](#T-Andhell-Crypto-IKey 'Andhell.Crypto.IKey') | Key used for hashing |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') |  |

<a name='T-Andhell-Crypto-Salty-Key'></a>
## Key `type`

##### Namespace

Andhell.Crypto.Salty

##### Summary

Represents a Symmetric Key

<a name='M-Andhell-Crypto-Salty-Key-#ctor-System-Byte[]-'></a>
### #ctor(key) `constructor`

##### Summary

Load a Key from existing bytes.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| key | [System.Byte[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Byte[] 'System.Byte[]') |  |

<a name='M-Andhell-Crypto-Salty-Key-#ctor-Andhell-Crypto-IProtectedKey-'></a>
### #ctor(key) `constructor`

##### Summary

Load a Windows DPAPI Protected Key

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| key | [Andhell.Crypto.IProtectedKey](#T-Andhell-Crypto-IProtectedKey 'Andhell.Crypto.IProtectedKey') |  |

<a name='M-Andhell-Crypto-Salty-Key-#ctor'></a>
### #ctor() `constructor`

##### Summary

Creates a new random Key

##### Parameters

This constructor has no parameters.

<a name='P-Andhell-Crypto-Salty-Key-Bytes'></a>
### Bytes `property`

##### Summary

The Key Bytes

<a name='M-Andhell-Crypto-Salty-Key-Clear'></a>
### Clear() `method`

##### Summary

Override the Key

##### Parameters

This method has no parameters.

<a name='M-Andhell-Crypto-Salty-Key-Storable'></a>
### Storable() `method`

##### Summary

Uses the Windows Data Protection API to encrypt the key

ONLY WORKS ON WINDOWS

##### Returns



##### Parameters

This method has no parameters.

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.NotImplementedException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.NotImplementedException 'System.NotImplementedException') | Thrown if called on Platforms != Windows |

<a name='T-Andhell-Crypto-Salty-KeyPair'></a>
## KeyPair `type`

##### Namespace

Andhell.Crypto.Salty

##### Summary

Represents a Asymmetric KeyPair to be used with SharedLocker

<a name='M-Andhell-Crypto-Salty-KeyPair-#ctor'></a>
### #ctor() `constructor`

##### Summary

Generate a new KeyPair

##### Parameters

This constructor has no parameters.

<a name='M-Andhell-Crypto-Salty-KeyPair-#ctor-Andhell-Crypto-IPrivateSecretKey-'></a>
### #ctor(privKey) `constructor`

##### Summary

Generate a KeyPair from a given Private Key

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| privKey | [Andhell.Crypto.IPrivateSecretKey](#T-Andhell-Crypto-IPrivateSecretKey 'Andhell.Crypto.IPrivateSecretKey') | Secret Private Key |

<a name='M-Andhell-Crypto-Salty-KeyPair-#ctor-Andhell-Crypto-IPrivateSecretKey,Andhell-Crypto-IPublicKey-'></a>
### #ctor(privKey,pubKey) `constructor`

##### Summary

Load a KeyPair

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| privKey | [Andhell.Crypto.IPrivateSecretKey](#T-Andhell-Crypto-IPrivateSecretKey 'Andhell.Crypto.IPrivateSecretKey') | Secret Private Key |
| pubKey | [Andhell.Crypto.IPublicKey](#T-Andhell-Crypto-IPublicKey 'Andhell.Crypto.IPublicKey') | Public Key |

<a name='P-Andhell-Crypto-Salty-KeyPair-Public'></a>
### Public `property`

##### Summary

Public Key

Can be shared

<a name='P-Andhell-Crypto-Salty-KeyPair-Secret'></a>
### Secret `property`

##### Summary

Secret Key

KEEP PRIVATE and NEVER SHARE this key

<a name='T-Andhell-Crypto-Salty-Locked'></a>
## Locked `type`

##### Namespace

Andhell.Crypto.Salty

##### Summary

Repesents Locked Data, that are encrypted with the SecretLocker

<a name='P-Andhell-Crypto-Salty-Locked-Ciphertext'></a>
### Ciphertext `property`

##### Summary

encrypted cipher text

<a name='P-Andhell-Crypto-Salty-Locked-Combined'></a>
### Combined `property`

##### Summary

Combined Nonce and Cipher into a single byte[]

[NonceSize][Nonce][Cipher]
[4 bytes][N - bytes][X - bytes]

<a name='P-Andhell-Crypto-Salty-Locked-Nonce'></a>
### Nonce `property`

##### Summary

Nonce used for encryption

<a name='T-Andhell-Crypto-Salty-Message'></a>
## Message `type`

##### Namespace

Andhell.Crypto.Salty

##### Summary

Represents a Text Message

<a name='P-Andhell-Crypto-Salty-Message-Text'></a>
### Text `property`

##### Summary

The Message Plaintext

<a name='M-Andhell-Crypto-Salty-Message-Authenticate-Andhell-Crypto-IKey-'></a>
### Authenticate(key) `method`

##### Summary

Authenticate the Message

Creates a HMAC

##### Returns

Authenticated HMAC

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| key | [Andhell.Crypto.IKey](#T-Andhell-Crypto-IKey 'Andhell.Crypto.IKey') | Symmetric Key used for the Authentication |

<a name='M-Andhell-Crypto-Salty-Message-Fingerprint'></a>
### Fingerprint() `method`

##### Summary

Fingerprints the Message with a Hash

##### Returns

The hash of the message

##### Parameters

This method has no parameters.

<a name='M-Andhell-Crypto-Salty-Message-Lock-Andhell-Crypto-IKey-'></a>
### Lock(key) `method`

##### Summary

Lock the Message with a Symmetric Key

##### Returns

The Locked Message

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| key | [Andhell.Crypto.IKey](#T-Andhell-Crypto-IKey 'Andhell.Crypto.IKey') | The Symmetric  Key |

<a name='M-Andhell-Crypto-Salty-Message-Sign-Andhell-Crypto-IPrivateSecretKey-'></a>
### Sign(key) `method`

##### Summary

Sign the Message with an Asymmertic Key

##### Returns

The Message Signature (contains the Signatrue together with the Message)

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| key | [Andhell.Crypto.IPrivateSecretKey](#T-Andhell-Crypto-IPrivateSecretKey 'Andhell.Crypto.IPrivateSecretKey') | The Private Key to sign the Message |

<a name='M-Andhell-Crypto-Salty-Message-Unlock-Andhell-Crypto-IKey,Andhell-Crypto-ILocked-'></a>
### Unlock(key,locked) `method`

##### Summary

Unlock the Message with a Symmetric Key

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| key | [Andhell.Crypto.IKey](#T-Andhell-Crypto-IKey 'Andhell.Crypto.IKey') | The Symmetric Key |
| locked | [Andhell.Crypto.ILocked](#T-Andhell-Crypto-ILocked 'Andhell.Crypto.ILocked') | The Locked Message |

<a name='M-Andhell-Crypto-Salty-Message-Verify-Andhell-Crypto-IKey,Andhell-Crypto-IHashed-'></a>
### Verify(key,messageHash) `method`

##### Summary

Verify a Authenticated Message Hash

##### Returns

True, is the MessageHash was created with the given symmetric Key

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| key | [Andhell.Crypto.IKey](#T-Andhell-Crypto-IKey 'Andhell.Crypto.IKey') | Symmetric Key used for Authentication |
| messageHash | [Andhell.Crypto.IHashed](#T-Andhell-Crypto-IHashed 'Andhell.Crypto.IHashed') | Hashed Message |

<a name='M-Andhell-Crypto-Salty-Message-Verify-Andhell-Crypto-IHashed-'></a>
### Verify(fingerprint) `method`

##### Summary

Verify the Fingerprint of a Message

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| fingerprint | [Andhell.Crypto.IHashed](#T-Andhell-Crypto-IHashed 'Andhell.Crypto.IHashed') |  |

<a name='T-Andhell-Crypto-Salty-Password'></a>
## Password `type`

##### Namespace

Andhell.Crypto.Salty

##### Summary

Represents a unsecured Password in plaintext

##### Example

```cs
var password = new Password("Correct Horse Battery Staple");
//use this to store in your Database
ISecuredPassword storeablePassword = password.Storable();
       
//To Verify
if (storeablePassword.Verify(password))
    Console.WriteLine("Password matched");
```

<a name='M-Andhell-Crypto-Salty-Password-#ctor-System-String-'></a>
### #ctor(password) `constructor`

##### Summary



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| password | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='P-Andhell-Crypto-Salty-Password-Plaintext'></a>
### Plaintext `property`

##### Summary

Password in plaintext

<a name='M-Andhell-Crypto-Salty-Password-DeriveKey'></a>
### DeriveKey() `method`

##### Summary

NotImplemented

##### Returns



##### Parameters

This method has no parameters.

<a name='M-Andhell-Crypto-Salty-Password-Storable'></a>
### Storable() `method`

##### Summary

Converts the Password to a format that can be stored and verified.

Primitve: Argon2 (libsodium crypto_pwhash)

##### Returns

SecuredPassword representation of the Password

##### Parameters

This method has no parameters.

<a name='T-Andhell-Crypto-Salty-PrivateSecretKey'></a>
## PrivateSecretKey `type`

##### Namespace

Andhell.Crypto.Salty

##### Summary

Represents a Private Key

KEEP PRIVATE and NEVER SHARE this key

<a name='T-Andhell-Crypto-Salty-ProtectedKey'></a>
## ProtectedKey `type`

##### Namespace

Andhell.Crypto.Salty

##### Summary

Represents a Windows DPAPI Protected Key

<a name='T-Andhell-Crypto-Salty-PublicKey'></a>
## PublicKey `type`

##### Namespace

Andhell.Crypto.Salty

##### Summary

Represents a Public Key

Can be shared

<a name='T-Andhell-Crypto-Salty-SecretLocker'></a>
## SecretLocker `type`

##### Namespace

Andhell.Crypto.Salty

##### Summary

Locks (Encrypt) and Unlocks (Decrypt) Data with a Symmetric/Secret Key

Primitive: XSalsa20 wiht Poly1305 MAC (libsodium crypto_secretbox)

<a name='M-Andhell-Crypto-Salty-SecretLocker-#ctor-Andhell-Crypto-IKey-'></a>
### #ctor(key) `constructor`

##### Summary

Create a Locker for this Key

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| key | [Andhell.Crypto.IKey](#T-Andhell-Crypto-IKey 'Andhell.Crypto.IKey') |  |

<a name='M-Andhell-Crypto-Salty-SecretLocker-Lock-System-Byte[]-'></a>
### Lock(data) `method`

##### Summary

Encrypts the Data (with Authentication)

Primitive: XSalsa20 wiht Poly1305 MAC (libsodium crypto_secretbox)

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| data | [System.Byte[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Byte[] 'System.Byte[]') | Data to be encrypted |

##### Example

```cs
var TEST_STRING = "eine kuh macht muh, viele kühe machen mühe"
// Create a new Symmertic Key
var key = new Key();
// Create a locker with this key
var locker = new SecretLocker(key);
var bytes = Utils.Secure.Encode(TEST_STRING);
// Encrypt the bytes
var ciphertext = locker.Lock(bytes);
// Decrypt the Text
var plaintext = locker.UnlockBytes(ciphertext);
// Clear Keys
locker.Clear();
```

<a name='M-Andhell-Crypto-Salty-SecretLocker-Lock-System-String-'></a>
### Lock(data) `method`

##### Summary

Encrypts the Data (with Authentication)

Primitive: XSalsa20 wiht Poly1305 MAC (libsodium crypto_secretbox)

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| data | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Data to be encrypted |

##### Example

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
// Clear Keys
locker.Clear();
```

<a name='M-Andhell-Crypto-Salty-SecretLocker-UnlockBytes-Andhell-Crypto-ILocked-'></a>
### UnlockBytes(locked) `method`

##### Summary

Decrypts the Data into a byte[]

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| locked | [Andhell.Crypto.ILocked](#T-Andhell-Crypto-ILocked 'Andhell.Crypto.ILocked') | locked Data to be decrypted |

<a name='M-Andhell-Crypto-Salty-SecretLocker-UnlockString-Andhell-Crypto-ILocked-'></a>
### UnlockString(locked) `method`

##### Summary

Decrypts the Data into a string

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| locked | [Andhell.Crypto.ILocked](#T-Andhell-Crypto-ILocked 'Andhell.Crypto.ILocked') | locked Data to be decrypted |

<a name='T-Andhell-Crypto-Salty-SecuredPassword'></a>
## SecuredPassword `type`

##### Namespace

Andhell.Crypto.Salty

##### Summary

Represents a secured password hash that can be stored and verified

<a name='M-Andhell-Crypto-Salty-SecuredPassword-#ctor-System-String-'></a>
### #ctor(hash) `constructor`

##### Summary



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| hash | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | String represenation of an Argon2 Hash |

<a name='P-Andhell-Crypto-Salty-SecuredPassword-Hash'></a>
### Hash `property`

##### Summary

Secure Hash represenation of a Password

Uses the Argon2 Hashing algorithm of libsodium

<a name='M-Andhell-Crypto-Salty-SecuredPassword-Verify-Andhell-Crypto-IPassword-'></a>
### Verify(password) `method`

##### Summary

Compare a Password to the Secured Hash
 
 Uses the Argon2 Hashing algorithm of libsodium

##### Returns

True if the Password matches the Hash, false otherwise

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| password | [Andhell.Crypto.IPassword](#T-Andhell-Crypto-IPassword 'Andhell.Crypto.IPassword') | Password that should be compared to the Hash |

##### Example

```cs
 var password = new Password("Correct Horse Battery Staple");
 // Read the Password from the Database
 string passwordHash = LoadFromDatabase();
 var storedPassword = new SecuredPassword(passwordHash);
 if (storedPassword.Verify(password))
    Console.WriteLine("Password matched");
 
```

<a name='T-Andhell-Crypto-Salty-SharedLocked'></a>
## SharedLocked `type`

##### Namespace

Andhell.Crypto.Salty

##### Summary

Represents Data locked with the SharedLocker

<a name='P-Andhell-Crypto-Salty-SharedLocked-Cipher'></a>
### Cipher `property`

##### Summary

encrypted cipher text

<a name='P-Andhell-Crypto-Salty-SharedLocked-Combined'></a>
### Combined `property`

##### Summary

Combines Nonce and Cipher into a singel byte[]

[NonceSize][Nonce][Cipher]
[4 bytes][N - bytes][X - bytes]

<a name='P-Andhell-Crypto-Salty-SharedLocked-Nonce'></a>
### Nonce `property`

##### Summary

Nonce used for encryption

<a name='M-Andhell-Crypto-Salty-SharedLocked-UnlockBytes-Andhell-Crypto-IPublicKey,Andhell-Crypto-IPrivateSecretKey-'></a>
### UnlockBytes(senderPubKey,recieverPrivKey) `method`

##### Summary

Unlock the Data

##### Returns

The unlocked Data

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| senderPubKey | [Andhell.Crypto.IPublicKey](#T-Andhell-Crypto-IPublicKey 'Andhell.Crypto.IPublicKey') | The Public Key of the Sender |
| recieverPrivKey | [Andhell.Crypto.IPrivateSecretKey](#T-Andhell-Crypto-IPrivateSecretKey 'Andhell.Crypto.IPrivateSecretKey') | The Private Key of the Reciever |

<a name='M-Andhell-Crypto-Salty-SharedLocked-UnlockString-Andhell-Crypto-IPublicKey,Andhell-Crypto-IPrivateSecretKey-'></a>
### UnlockString(senderPubKey,recieverPrivKey) `method`

##### Summary

Unlock the String

##### Returns

The unlocked String

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| senderPubKey | [Andhell.Crypto.IPublicKey](#T-Andhell-Crypto-IPublicKey 'Andhell.Crypto.IPublicKey') | The Public Key of the Sender |
| recieverPrivKey | [Andhell.Crypto.IPrivateSecretKey](#T-Andhell-Crypto-IPrivateSecretKey 'Andhell.Crypto.IPrivateSecretKey') | The Private Key of the Reciever |

<a name='T-Andhell-Crypto-Salty-SharedLocker'></a>
## SharedLocker `type`

##### Namespace

Andhell.Crypto.Salty

##### Summary

Locks Data with a Asymmertic Key

Uses libsodiums crypto_box_*

<a name='M-Andhell-Crypto-Salty-SharedLocker-#ctor-Andhell-Crypto-IPublicKey,Andhell-Crypto-IPrivateSecretKey-'></a>
### #ctor(recieverPubKey,senderPrivKey) `constructor`

##### Summary

Creates a Locker with Asymmertic/Public Keys

Primitive: X25519 + XSalsa20 + Poly1305 MAC  (libsodium crypto_box)

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| recieverPubKey | [Andhell.Crypto.IPublicKey](#T-Andhell-Crypto-IPublicKey 'Andhell.Crypto.IPublicKey') | The Public Key of the Reciever the Data are locked for |
| senderPrivKey | [Andhell.Crypto.IPrivateSecretKey](#T-Andhell-Crypto-IPrivateSecretKey 'Andhell.Crypto.IPrivateSecretKey') | The Private Key of the Sender |

<a name='M-Andhell-Crypto-Salty-SharedLocker-Lock-System-String-'></a>
### Lock(str) `method`

##### Summary

Locks a String

Primitive: X25519 + XSalsa20 + Poly1305 MAC  (libsodium crypto_box)

##### Returns

The locked String

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| str | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The String to lock |

##### Example

```cs
var TEST_STRING = "eine kuh macht muh, viele kühe machen mühe"
// Create a new Symmertic Key
var key = new Key();
// Create a locker with this key
var locker = new SecretLocker(key);
var bytes = Utils.Secure.Encode(TEST_STRING);
// Encrypt the bytes
var ciphertext = locker.Lock(bytes);
// Decrypt the String
var plaintext = locker.UnlockString(ciphertext);
// Clear Keys
locker.Clear();
```

<a name='M-Andhell-Crypto-Salty-SharedLocker-Lock-System-Byte[]-'></a>
### Lock(str) `method`

##### Summary

Locks Data

Primitive: X25519 + XSalsa20 + Poly1305 MAC  (libsodium crypto_box)

##### Returns

The locked Data

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| str | [System.Byte[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Byte[] 'System.Byte[]') | The Data to lock |

##### Example

```cs
var TEST_STRING = "eine kuh macht muh, viele kühe machen mühe"
// Create a new Symmertic Key
var key = new Key();
// Create a locker with this key
var locker = new SecretLocker(key);
// Encrypt the bytes
var ciphertext = locker.Lock(TEST_STRING);
// Decrypt the bytes
var plaintext = locker.UnlockBytes(ciphertext);
// Clear Keys
locker.Clear();
```

<a name='T-Andhell-Crypto-Salty-Signature'></a>
## Signature `type`

##### Namespace

Andhell.Crypto.Salty

##### Summary

Represends a Signature created by the Signer class

<a name='M-Andhell-Crypto-Salty-Signature-#ctor-System-Byte[]-'></a>
### #ctor(signature) `constructor`

##### Summary

Load a Signature for bytes

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| signature | [System.Byte[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Byte[] 'System.Byte[]') | The Signatures Bytes |

<a name='P-Andhell-Crypto-Salty-Signature-Bytes'></a>
### Bytes `property`

##### Summary

The Signature

[Signature || Message]
see libsodiums crypto_sign (combined mode)

<a name='M-Andhell-Crypto-Salty-Signature-Verify-System-Byte[],Andhell-Crypto-IPublicKey-'></a>
### Verify(data,key) `method`

##### Summary

Verify a Signature

##### Returns

True: If the signature is valid and the singed data are equal

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| data | [System.Byte[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Byte[] 'System.Byte[]') | Data that shoud be in the Signature |
| key | [Andhell.Crypto.IPublicKey](#T-Andhell-Crypto-IPublicKey 'Andhell.Crypto.IPublicKey') | Public key of the KeyPair used for the Signature |

<a name='M-Andhell-Crypto-Salty-Signature-Verify-System-String,Andhell-Crypto-IPublicKey-'></a>
### Verify(data,key) `method`

##### Summary

Verify a Signature

##### Returns

True: If the signature is valid and the singed string equals str

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| data | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | String that shoud be in the Signature |
| key | [Andhell.Crypto.IPublicKey](#T-Andhell-Crypto-IPublicKey 'Andhell.Crypto.IPublicKey') | Public key of the KeyPair used for the Signature |

<a name='T-Andhell-Crypto-Salty-Signer'></a>
## Signer `type`

##### Namespace

Andhell.Crypto.Salty

##### Summary

Sign a Message with an Asymmetric Key

Primitive: Ed25519 (libsodium crypto_sign)

<a name='M-Andhell-Crypto-Salty-Signer-#ctor-Andhell-Crypto-IPrivateSecretKey-'></a>
### #ctor(privKey) `constructor`

##### Summary

Create Signer
 
 Primitive: Ed25519 (libsodium crypto_sign)

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| privKey | [Andhell.Crypto.IPrivateSecretKey](#T-Andhell-Crypto-IPrivateSecretKey 'Andhell.Crypto.IPrivateSecretKey') | Private Key used for Signing |

##### Example

```cs
 // Create KeyPair
 var AliceKeys = new SigningKeyPair();
 // Create Sigend with the Private Key
 var pen = new Signer(AliceKeys.Secret);
 // create signature
 var signature = pen.Sign(MESSAGE);
 // Validate with the Public Key
 if(signature.Verify(MESSAGE, AliceKeys.Public))
 //    Singature is Valid!
 
 pen.Clear();
 
```

<a name='M-Andhell-Crypto-Salty-Signer-Sign-System-Byte[]-'></a>
### Sign(data) `method`

##### Summary

Sign Data

Primitive: Ed25519 (libsodium crypto_sign)

##### Returns

The Signature (result contains the signature + the data)

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| data | [System.Byte[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Byte[] 'System.Byte[]') | The Data to Sign |

<a name='M-Andhell-Crypto-Salty-Signer-Sign-System-String-'></a>
### Sign(data) `method`

##### Summary

Sign String

Primitive: Ed25519 (libsodium crypto_sign)

##### Returns

The Signature (result contains the signature + the String)

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| data | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The String to Sign |

<a name='T-Andhell-Crypto-Salty-SigningKeyPair'></a>
## SigningKeyPair `type`

##### Namespace

Andhell.Crypto.Salty

##### Summary

Represents a Asymmetric KeyPair to be used with Signer

<a name='M-Andhell-Crypto-Salty-SigningKeyPair-#ctor'></a>
### #ctor() `constructor`

##### Summary

Generate a new KeyPair

##### Parameters

This constructor has no parameters.

<a name='M-Andhell-Crypto-Salty-SigningKeyPair-#ctor-Andhell-Crypto-IPrivateSecretKey-'></a>
### #ctor(privKey) `constructor`

##### Summary

Generate a KeyPair from a given Private Key

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| privKey | [Andhell.Crypto.IPrivateSecretKey](#T-Andhell-Crypto-IPrivateSecretKey 'Andhell.Crypto.IPrivateSecretKey') | Secret Private Key |

<a name='M-Andhell-Crypto-Salty-SigningKeyPair-#ctor-Andhell-Crypto-IPrivateSecretKey,Andhell-Crypto-IPublicKey-'></a>
### #ctor(privKey,pubKey) `constructor`

##### Summary

Load a KeyPair

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| privKey | [Andhell.Crypto.IPrivateSecretKey](#T-Andhell-Crypto-IPrivateSecretKey 'Andhell.Crypto.IPrivateSecretKey') | Secret Private Key |
| pubKey | [Andhell.Crypto.IPublicKey](#T-Andhell-Crypto-IPublicKey 'Andhell.Crypto.IPublicKey') | Public Key |

<a name='P-Andhell-Crypto-Salty-SigningKeyPair-Public'></a>
### Public `property`

##### Summary

Public Key

Can be shared

<a name='P-Andhell-Crypto-Salty-SigningKeyPair-Secret'></a>
### Secret `property`

##### Summary

Secret Key

KEEP PRIVATE and NEVER SHARE this key

<a name='M-Andhell-Crypto-Salty-SigningKeyPair-Clear'></a>
### Clear() `method`

##### Summary

Override the Keys

##### Parameters

This method has no parameters.
