using SpawnDev.Blazor.UnitTesting;
using SpawnDev.BlazorJS.JSObjects;

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
            using var signature = await Sign(signingKeys.PrivateKey!, TestData);
            // verify signature using signing public key
            var verified = await Verify(signingKeys.PublicKey!, signature, TestData);
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
            using var signature = await Sign(signingKeys.PrivateKey!, TestData);
            // verify signature using signing public key
            var verified = await Verify(signingKeys.PublicKey!, signature, TestData);
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
            using var encryptionKeyBob = await DeriveAesGcmEncryptionKey(ecdhKeysAlice.PrivateKey!, ecdhKeysBob.PublicKey!);
            // Alice can now encrypt messages that only Bob can decrypt and vice versa
            // Create a new IV for use in encrypting (each message should use a new iv)
            // https://developer.mozilla.org/en-US/docs/Web/API/AesGcmParams#iv
            using var iv = GenerateAesGcmIV();
            using var encryptedData = await EncryptAesGcm(encryptionKeyAlice, TestData, iv);
            // Alice can now safely send encryptedData (and the iv) to Bob
            // Bob can decrypt the message using his shared encryption key and the message iv
            using var decryptedData = await DecryptAesGcm(encryptionKeyBob, encryptedData, iv);
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
        EcdsaParams DefaultEcdsaParams = new EcdsaParams { Hash = "SHA-384" };
        RsaPssParams DefaultRsaPssParams = new RsaPssParams { SaltLength = 32 };
        /// <summary>
        /// 
        /// </summary>
        /// <param name="privateKey"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<ArrayBuffer> Sign(CryptoKey privateKey, Union<ArrayBuffer, TypedArray, DataView, byte[]> data)
        {
            switch (privateKey.AlgorithmName)
            {
                case "ECDSA":
                    return await SubtleCrypto!.Sign(DefaultEcdsaParams, privateKey, data);
                case "RSA-PSS":
                    return await SubtleCrypto!.Sign(DefaultRsaPssParams, privateKey, data);
                default:
                    throw new Exception("Invalid keys");
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="publicKey"></param>
        /// <param name="data"></param>
        /// <param name="signature"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Verify(CryptoKey publicKey, ArrayBuffer signature, Union<ArrayBuffer, TypedArray, DataView, byte[]> data)
        {
            switch (publicKey.AlgorithmName)
            {
                case "ECDSA":
                    return await SubtleCrypto!.Verify(DefaultEcdsaParams, publicKey, signature, data);
                case "RSA-PSS":
                    return await SubtleCrypto!.Verify(DefaultRsaPssParams, publicKey, signature, data);
                default:
                    throw new Exception("Invalid keys");
            }
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
        /// <summary>
        /// Generates an IV for use in AesGcmEncryption
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public Uint8Array GenerateAesGcmIV(int size = 12)
        {
            using var iv = new Uint8Array(size);
            // use Crypto to fill the Uint8Array with random data
            return Crypto!.GetRandomValues(iv);
        }
        /// <summary>
        /// Encrypts using AES in GCM mode.<br/>
        /// https://developer.mozilla.org/en-US/docs/Web/API/SubtleCrypto/encrypt#aes-gcm_2
        /// </summary>
        /// <returns></returns>
        public async Task<ArrayBuffer> EncryptAesGcm(CryptoKey aesGcmKey, Union<ArrayBuffer, TypedArray, DataView, byte[]> data, Union<ArrayBuffer, TypedArray, DataView, byte[]> iv)
        {
            var ret = await SubtleCrypto!.Encrypt(new AesGcmParams { Iv = iv }, aesGcmKey, data);
            return ret;
        }
        /// <summary>
        /// Decrypts using AES in GCM mode.
        /// </summary>
        /// <param name="aesGcmKey"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public async Task<ArrayBuffer> DecryptAesGcm(CryptoKey aesGcmKey, Union<ArrayBuffer, TypedArray, DataView, byte[]> cipherData, Union<ArrayBuffer, TypedArray, DataView, byte[]> iv)
        {
            var ret = await SubtleCrypto!.Decrypt(new AesGcmParams { Iv = iv }, aesGcmKey, cipherData);
            return ret;
        }
    }
}
