using SpawnDev.Blazor.UnitTesting;
using SpawnDev.BlazorJS.JSObjects;

namespace SpawnDev.BlazorJS.Demo.UnitTests
{
    public class CryptoService
    {
        /// <summary>
        /// Tests ECDSA GenerateKey, Sign, and Verify
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task ECDSASignAndVerifyExample()
        {
            byte[] TestData = new byte[] { 1, 3, 5, 7, 9 };
            using var Crypto = new Crypto();
            using var SubtleCrypto = Crypto.Subtle;
            // create signing key pair
            using var signingKeys = await SubtleCrypto!.GenerateKey<CryptoKeyPair>(new EcKeyGenParams
            {
                Name = "ECDSA",
                NamedCurve = "P-384"
            }, false, new string[] { "sign", "verify" });
            // create TestData signature using signing private key
            using var signature = await SubtleCrypto!.Sign(new EcdsaParams { Hash = "SHA-384" }, signingKeys.PrivateKey!, TestData);
            // verify signature using signing public key
            var verified = await SubtleCrypto!.Verify(new EcdsaParams { Hash = "SHA-384" }, signingKeys.PublicKey!, signature, TestData);
            // assert expected value
            if (!verified) throw new Exception("Failed");
        }

        /// <summary>
        /// Tests RSAPSS GenerateKey, Sign, and Verify
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task RSAPSSSignAndVerifyExample()
        {
            byte[] TestData = new byte[] { 1, 3, 5, 7, 9 };
            using var Crypto = new Crypto();
            using var SubtleCrypto = Crypto.Subtle;
            // create signing key pair
            using var signingKeys = await SubtleCrypto!.GenerateKey<CryptoKeyPair>(new RsaHashedKeyGenParams
            {
                Name = "RSA-PSS",
                ModulusLength = 4096,
                PublicExponent = new byte[] { 1, 0, 1 },
                Hash = "SHA-256"
            }, false, new string[] { "sign", "verify" });
            // create TestData signature using signing private key
            using var signature = await SubtleCrypto!.Sign(new RsaPssParams { SaltLength = 32 }, signingKeys.PrivateKey!, TestData);
            // verify signature using signing public key
            var verified = await SubtleCrypto!.Verify(new RsaPssParams { SaltLength = 32 }, signingKeys.PublicKey!, signature, TestData);
            // assert expected value
            if (!verified) throw new Exception("Failed");
        }

        /// <summary>
        /// Tests ECDH GenerateKey, Derive, Encrypt, and Decrypt<br/>
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task ECDHEncryptionExample()
        {
            byte[] TestData = new byte[] { 1, 3, 5, 7, 9 };
            using var Crypto = new Crypto();
            using var SubtleCrypto = Crypto.Subtle;
            // create ECDH key pair for Alice
            using var ecdhKeysAlice = await SubtleCrypto!.GenerateKey<CryptoKeyPair>(new EcKeyGenParams
            {
                Name = "ECDH",
                NamedCurve = "P-384"
            }, false, new string[] { "deriveKey" });
            // create ECDH key pair for Bob
            using var ecdhKeysBob = await SubtleCrypto!.GenerateKey<CryptoKeyPair>(new EcKeyGenParams
            {
                Name = "ECDH",
                NamedCurve = "P-384"
            }, false, new string[] { "deriveKey" });
            // derive shared encryption key for Alice using Alice's private key and Bob's public key
            using var encryptionKeyAlice = await SubtleCrypto!.DeriveKey(new EcdhKeyDeriveParams { Public = ecdhKeysBob.PublicKey! },
                ecdhKeysAlice.PrivateKey!,
                new AesKeyGenParams { Name = "AES-GCM", Length = 256 },
                false,
                new string[] { "encrypt", "decrypt" }
            );
            // derive shared encryption key for Bob using Bob's private key and Alice's public key
            using var encryptionKeyBob = await SubtleCrypto!.DeriveKey(new EcdhKeyDeriveParams { Public = ecdhKeysAlice.PublicKey! },
                ecdhKeysBob.PrivateKey!,
                new AesKeyGenParams { Name = "AES-GCM", Length = 256 },
                false,
                new string[] { "encrypt", "decrypt" }
            );
            // Alice and Bob now have the same encryption key that can be used to encrypt messages only they can decrypt
            // Create a new IV for use in encrypting (each message should use a new iv)
            // https://developer.mozilla.org/en-US/docs/Web/API/AesGcmParams#iv
            using var iv = new Uint8Array(12);
            // use Crypto to fill the Uint8Array with random data
            Crypto!.GetRandomValues(iv);
            // Encrypt using Alice's shared encryption key
            using var encryptedData = await SubtleCrypto!.Encrypt(new AesGcmParams { Iv = iv }, encryptionKeyAlice, TestData);
            // Alice can now send encryptedData (and the iv) to Bob
            // Bob can decrypt the message using his shared encryption key and the message iv
            using var decryptedData = await SubtleCrypto!.Decrypt(new AesGcmParams { Iv = iv }, encryptionKeyBob, encryptedData);
            // convert the ArrayBuffer to byte[] for easy comparison with the source data
            var decryptedDataBytes = (byte[])decryptedData!;
            // assert expected value
            if (!decryptedDataBytes.SequenceEqual(TestData)) throw new Exception("Failed");
        }

        /// <summary>
        /// Demonstrates the saving and retrieval of a KeyPair in an IndexedDB
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task KeyStorageExample()
        {
            var keyStoreDBName = "MyKeysDB";
            var keyStoreName = "MyKeyStore";
            var myKeysKeyName = "mySigningKeys";
            // initialize IndexedDB and create the key store if needed
            using var idbFactory = new IDBFactory();
            using var idb = await idbFactory.OpenAsync(keyStoreDBName, 1, (evt) =>
            {
                // upgrade needed
                using var request = evt.Target;
                using var db = request.Result;
                var stores = db.ObjectStoreNames;
                if (!stores.Contains(keyStoreName))
                {
                    using var myKeysStore = db.CreateObjectStore<string, CryptoKeyPair>(keyStoreName);
                }
            });
            // create a keypair to store
            using var Crypto = new Crypto();
            using var SubtleCrypto = Crypto.Subtle;
            // create signing key pair
            using var signingKeys = await SubtleCrypto!.GenerateKey<CryptoKeyPair>(new EcKeyGenParams
            {
                Name = "ECDSA",
                NamedCurve = "P-384"
            }, false, new string[] { "sign", "verify" });
            // save the key pair in the key store
            {
                // start the IndexedDB transaction in read and write mode
                using var tx = idb.Transaction(keyStoreName, true);
                // get the key store
                using var objectStore = tx.ObjectStore<string, CryptoKeyPair>(keyStoreName);
                // put the keys into the key store
                await objectStore.PutAsync(signingKeys, myKeysKeyName);
            }
            // ...
            // load the key pair from the key store
            {
                // start the IndexedDB transaction in read only mode
                using var tx = idb.Transaction(keyStoreName);
                // get the key store
                using var objectStore = tx.ObjectStore<string, CryptoKeyPair>(keyStoreName);
                // get the keys from the key store or null if not found
                using var loadedKeys = await objectStore.GetAsync(myKeysKeyName);
                // compare with original keys to prove keys were saved and loaded as expected (just comparing algorithm names here for simplicity)
                if (signingKeys.PrivateKey!.AlgorithmName != loadedKeys.PrivateKey!.AlgorithmName) throw new Exception("Failed");
            }
        }
    }
}
