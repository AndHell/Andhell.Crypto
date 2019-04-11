

<!-- 1. I am a file, and I want to
    - be transmitted securely
    - be signed
    - be authenticated
    - be protected

1. I am a [Message](UseCase/Message.md), and I want to
    - be transmitted securely
    - be signed
    - be authenticated
    - be protected -->

1. I am Alice, and I want to
    - Send a Message, to Bob
        - With a [Shared Key](UseCase/Symmetric.md/#encrypt)
        - With Bobs [Public Key](UseCase/Asymmetric.md/#encrypt)
    - Sign/Authenticate a Message for Bob
        - With a [Shared Key](UseCase/Symmetric.md/#authenticate)
        - With Bobs [Public Key](UseCase/Asymmetric.md/#sign)
    - Read a Message from Bob
        - With a [Shared Key](UseCase/Symmetric.md/#encrypt)
        - With Bobs [Public Key](UseCase/Asymmetric.md/#encrypt)
    - Verify a Message from Bob
        - With a [Shared Key](UseCase/Symmetric.md/#authenticate)
        - With Bobs [Public Key](UseCase/Asymmetric.md/#sign)

1. I am a [Password](UseCase/Password.md), and I want to
    - be [Stored](UseCase/Password.md/#store)
    - be [Verified](UseCase/Password.md/#verify)
    - be a [Key](UseCase/Key.md) 

1. I am a [Key](UseCase/Key.md), and I want to
    - be [Stored](UseCase/Key.md/#store)
    - be [Created](UseCase/Key.md/#create)

1. I am a [Database Key](UseCase/AccessKey.md), and I want to
1. I am a [API Key](UseCase/AccessKey.md), and I want to
    - be [Stored](UseCase/AccessKey.md/#store)