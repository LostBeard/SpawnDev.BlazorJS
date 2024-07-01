using SpawnDev.Blazor.UnitTesting;
using SpawnDev.BlazorJS.JSObjects;
using System.Security.Cryptography.X509Certificates;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SpawnDev.BlazorJS.Test.UnitTests
{
    public class CryptoService
    {
        BlazorJSRuntime JS;
        Crypto Crypto;
        SubtleCrypto SubtleCrypto;

        byte[] TestData = new byte[] { 1, 3, 5, 7, 9 };
        public CryptoService(BlazorJSRuntime js)
        {
            JS = js;
            Crypto = new Crypto();
            SubtleCrypto = Crypto.Subtle;
        }

        /// <summary>
        /// Tests ECDSA GenerateKey, Sign, and Verify
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task ECDSASignAndVerifyExample()
        {
            // create signing key pair
            using var signingKeys = await GenerateECDSASigningKey();
            // sign TestData using signing private key
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
            // create signing key pair
            using var signingKeys = await GenerateRSAPSSSigningKey();
            // sign TestData using signing private key
            using var signature = await SubtleCrypto!.Sign(new RsaPssParams { SaltLength = 32 }, signingKeys.PrivateKey!, TestData);
            // verify signature using signing public key
            var verified = await SubtleCrypto!.Verify(new RsaPssParams { SaltLength = 32 }, signingKeys.PublicKey!, signature, TestData);
            // assert expected value
            if (!verified) throw new Exception("Failed");
        }

        /// <summary>
        /// Tests ECDH GenerateKey, Derive, Encrypt, and Decrypt<br/>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task ECDHEncryptionExample()
        {
            // create ECDH key pair for Alice
            using var ecdhKeysAlice = await GenerateECDHEncryptionKey();
            // create ECDH key pair for Bob
            using var ecdhKeysBob = await GenerateECDHEncryptionKey();
            // derive shared encryption key pair for Alice using Alice's private key and Bob's public key
            using var encryptionKeyAlice = await DeriveAesGcmEncryptionKey(ecdhKeysAlice.PrivateKey!, ecdhKeysBob.PublicKey!);
            // derive shared encryption key pair for Bob using Bob's private key and Alice's public key
            using var encryptionKeyBob = await DeriveAesGcmEncryptionKey(ecdhKeysBob.PrivateKey!, ecdhKeysAlice.PublicKey!);
            // Alice can now encrypt messages that only Bob can decrypt and vice versa
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

        /***
         * Helper methods
         */

        /// <summary>
        /// Generates a new ECDH key pair that can be used to derive a shared AES encryption key
        /// </summary>
        /// <param name="extractable">A boolean value indicating whether it will be possible to export the key using SubtleCrypto.exportKey() or SubtleCrypto.wrapKey().</param>
        /// <returns></returns>
        public async Task<CryptoKeyPair> GenerateECDHEncryptionKey(bool extractable = false)
        {
            var keys = await SubtleCrypto!.GenerateKey<CryptoKeyPair>(new EcKeyGenParams
            {
                Name = "ECDH",
                NamedCurve = "P-384"
            }, extractable, new string[] { "deriveKey" });
            return keys;
        }
        /// <summary>
        /// Generates an ECDSA signing key pair
        /// </summary>
        /// <param name="extractable">A boolean value indicating whether it will be possible to export the key using SubtleCrypto.exportKey() or SubtleCrypto.wrapKey().</param>
        /// <returns></returns>
        public async Task<CryptoKeyPair> GenerateECDSASigningKey(bool extractable = false)
        {
            var keys = await SubtleCrypto!.GenerateKey<CryptoKeyPair>(new EcKeyGenParams
            {
                Name = "ECDSA",
                NamedCurve = "P-384"
            }, extractable, new string[] { "sign", "verify" });
            return keys;
        }
        /// <summary>
        /// Generates an RSA-PSS signing key pair
        /// </summary>
        /// <param name="extractable">A boolean value indicating whether it will be possible to export the key using SubtleCrypto.exportKey() or SubtleCrypto.wrapKey().</param>
        /// <returns></returns>
        public async Task<CryptoKeyPair> GenerateRSAPSSSigningKey(bool extractable = false)
        {
            var keys = await SubtleCrypto!.GenerateKey<CryptoKeyPair>(new RsaHashedKeyGenParams
            {
                Name = "RSA-PSS",
                ModulusLength = 4096,
                PublicExponent = new byte[] { 1, 0, 1 },
                Hash = "SHA-256"
            }, extractable, new string[] { "sign", "verify" });
            return keys;
        }
        /// <summary>
        /// Generates a shared encryption key from this user's ECDH privateKey and the other user's ECDH publicKey<br/>
        /// </summary>
        /// <param name="privateKey"></param>
        /// <param name="publicKey"></param>
        /// <returns></returns>
        public Task<CryptoKey> DeriveAesGcmEncryptionKey(CryptoKey privateKey, CryptoKey publicKey, bool extractable = false)
        {
            return SubtleCrypto!.DeriveKey(new EcdhKeyDeriveParams { Public = publicKey },
                privateKey,
                new AesKeyGenParams { Name = "AES-GCM", Length = 256 },
                extractable,
                new string[] { "encrypt", "decrypt" }
            );
        }
    }
}
