# Encryptors
## What is it

**Encryptors** - is a library with the ability to encrypt and decrypt data using a complex of various encryptors.

## How it use

1. Create cryptographer and encrypt-algorithms

```C#
var aes256Enc = new Aes256Encryptor();
aes256Enc.GenerateKeysBag();
```

2. Create cryptographer pipeline and seal it

```C#
var cryptographer = Cryptographer.New();
var sealedPipeline = cryptographer.GetPipeline()
                                  .Use(aes256Enc)
                                  .Seal();
```

3. Use created cryptographer to encrypt or decrypt your secret data

```C#
var message = "This is Top secret information";
var messageInBytes = Encoding.UTF8.GetBytes(message);

// Encrypt
var cryptoResult = cryptographer.Run(sealedPipe, messageInBytes).GetResult();
var bytes = cryptoResult.ToBytes(); // encrypted data

// Decript
cryptoResult = _cryptographer.RunBack(sealedPipe, bytes).GetResult();
string resultMessage = Encoding.UTF8.GetString(cryptoResult.ToBytes());
```