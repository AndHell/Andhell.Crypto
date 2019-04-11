# Password

Password should never be stored as plaintext, instead use a secured hash. The `Password` class should be used to compute and verify storable password hashes.

## Store
To store a password in a secure manner (for example in a database) the `Password` class can be used.

```cs
var password = new Password("Correct Horse Battery Staple");

ISecuredPassword storeablePassword = password.Storable();

// Write the Hash to the Database
Store(storeablePassword.Hash)
```

## Verify
To verify a password against a stored one, load the stored pw-hash into the `SecuredPassword` class and use the `Verify` method.

```cs
var password = new Password("Correct Horse Battery Staple");

// Read the Password from the Database
string passwordHash = LoadFromDatabase();

var storedPassword = new SecuredPassword(passwordHash);

if (storedPassword.Verify(password))
    Console.WriteLine("Password matched");
```

## Derive Key
*Password Based Key Derivation is not available yet.*