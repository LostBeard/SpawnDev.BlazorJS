using SpawnDev.BlazorJS.JSObjects;

namespace SpawnDev.BlazorJS.RemoteJSRuntime.AsyncObjects
{
    public class SubtleCryptoAsync
    {
        BlazorJSRuntimeAsync JSA;
        public SubtleCryptoAsync(BlazorJSRuntimeAsync jsa)
        {
            JSA = jsa;
        }
        public Task<ArrayBufferAsync> Decrypt(EncryptParams algorithm, CryptoKeyAsync key, byte[] data) => JSA.CallAsync<ArrayBufferAsync>("crypto.subtle.decrypt", algorithm, key, data);
        public Task<ArrayBufferAsync> DeriveBits(KeyDeriveParams algorithm, CryptoKeyAsync baseKey, int length) => JSA.CallAsync<ArrayBufferAsync>("crypto.subtle.deriveBits", algorithm, baseKey, length);
        public Task<CryptoKeyAsync> DeriveKey(KeyDeriveParams algorithm, CryptoKeyAsync baseKey, HmacKeyGenParams derivedKeyAlgorithm, bool extractable, string[] keyUsages) => JSA.CallAsync<CryptoKeyAsync>("crypto.subtle.deriveKey", algorithm, baseKey, derivedKeyAlgorithm, extractable, keyUsages);
        public Task<CryptoKeyAsync> DeriveKey(KeyDeriveParams algorithm, CryptoKeyAsync baseKey, AesKeyGenParams derivedKeyAlgorithm, bool extractable, string[] keyUsages) => JSA.CallAsync<CryptoKeyAsync>("crypto.subtle.deriveKey", algorithm, baseKey, derivedKeyAlgorithm, extractable, keyUsages);
        public Task<CryptoKeyAsync> DeriveKey(KeyDeriveParams algorithm, CryptoKeyAsync baseKey, HkdfParams derivedKeyAlgorithm, bool extractable, string[] keyUsages) => JSA.CallAsync<CryptoKeyAsync>("crypto.subtle.deriveKey", algorithm, baseKey, derivedKeyAlgorithm, extractable, keyUsages);
        public Task<CryptoKeyAsync> DeriveKey(KeyDeriveParams algorithm, CryptoKeyAsync baseKey, Pbkdf2Params derivedKeyAlgorithm, bool extractable, string[] keyUsages) => JSA.CallAsync<CryptoKeyAsync>("crypto.subtle.deriveKey", algorithm, baseKey, derivedKeyAlgorithm, extractable, keyUsages);
        public Task<ArrayBufferAsync> Digest(string algorithm, byte[] data) => JSA.CallAsync<ArrayBufferAsync>("crypto.subtle.digest", algorithm, data);
        public Task<ArrayBufferAsync> Encrypt(EncryptParams algorithm, CryptoKeyAsync key, byte[] data) => JSA.CallAsync<ArrayBufferAsync>("crypto.subtle.encrypt", algorithm, key, data);
        public Task<T> ExportKey<T>(string format, CryptoKeyAsync key) => JSA.CallAsync<T>("crypto.subtle.exportKey", format, key);
        public Task<JSObjectAsync> ExportKeyJwk(CryptoKeyAsync key) => JSA.CallAsync<JSObjectAsync>("crypto.subtle.exportKey", "jwk", key);
        public Task<ArrayBufferAsync> ExportKeyPkcs8(CryptoKeyAsync key) => JSA.CallAsync<ArrayBufferAsync>("crypto.subtle.exportKey", "pkcs8", key);
        public Task<ArrayBufferAsync> ExportKeyRaw(CryptoKeyAsync key) => JSA.CallAsync<ArrayBufferAsync>("crypto.subtle.exportKey", "raw", key);
        public Task<ArrayBufferAsync> ExportKeySpki(CryptoKeyAsync key) => JSA.CallAsync<ArrayBufferAsync>("crypto.subtle.exportKey", "spki", key);
        public Task<T> GenerateKey<T>(RsaHashedKeyGenParams algorithm, bool extractable, IEnumerable<string> keyUsages) where T : CryptoKeyBaseAsync => JSA.CallAsync<T>("crypto.subtle.generateKey", algorithm, extractable, keyUsages);
        public Task<T> GenerateKey<T>(EcKeyGenParams algorithm, bool extractable, IEnumerable<string> keyUsages) where T : CryptoKeyBaseAsync => JSA.CallAsync<T>("crypto.subtle.generateKey", algorithm, extractable, keyUsages);
        public Task<T> GenerateKey<T>(HmacKeyGenParams algorithm, bool extractable, IEnumerable<string> keyUsages) where T : CryptoKeyBaseAsync => JSA.CallAsync<T>("crypto.subtle.generateKey", algorithm, extractable, keyUsages);
        public Task<T> GenerateKey<T>(AesKeyGenParams algorithm, bool extractable, IEnumerable<string> keyUsages) where T : CryptoKeyBaseAsync => JSA.CallAsync<T>("crypto.subtle.generateKey", algorithm, extractable, keyUsages);
        public Task<CryptoKeyAsync> ImportKey(string format, byte[] keyData, CryptoImportParams algorithm, bool extractable, IEnumerable<string> keyUsages) => JSA.CallAsync<CryptoKeyAsync>("crypto.subtle.importKey", format, keyData, algorithm, extractable, keyUsages);
        public Task<CryptoKeyAsync> ImportKey(string format, byte[] keyData, string algorithm, bool extractable, IEnumerable<string> keyUsages) => JSA.CallAsync<CryptoKeyAsync>("crypto.subtle.importKey", format, keyData, algorithm, extractable, keyUsages);
        public Task<T> ImportKey<T>(string format, byte[] keyData, CryptoImportParams algorithm, bool extractable, IEnumerable<string> keyUsages) where T : CryptoKeyBaseAsync => JSA.CallAsync<T>("crypto.subtle.importKey", format, keyData, algorithm, extractable, keyUsages);
        public Task<T> ImportKey<T>(string format, byte[] keyData, string algorithm, bool extractable, IEnumerable<string> keyUsages) where T : CryptoKeyBaseAsync => JSA.CallAsync<T>("crypto.subtle.importKey", format, keyData, algorithm, extractable, keyUsages);
        public Task<ArrayBufferAsync> Sign(CryptoSignParams algorithm, CryptoKeyAsync key, byte[] data) => JSA.CallAsync<ArrayBufferAsync>("crypto.subtle.sign", algorithm, key, data);
        public Task<ArrayBufferAsync> Sign(string algorithm, CryptoKeyAsync key, byte[] data) => JSA.CallAsync<ArrayBufferAsync>("crypto.subtle.sign", algorithm, key, data);
        public Task<CryptoKeyAsync> UnwrapKey(string format, ArrayBufferAsync wrappedKey, CryptoKeyAsync unwrappingKey, EncryptParams unwrapAlgo, CryptoImportParams unwrappedKeyAlgo, bool extractable, IEnumerable<string> keyUsages) => JSA.CallAsync<CryptoKeyAsync>("crypto.subtle.unwrapKey", format, wrappedKey, unwrappingKey, unwrapAlgo, unwrappedKeyAlgo, extractable, keyUsages);
        public Task<bool> Verify(CryptoSignParams algorithm, CryptoKeyAsync key, ArrayBufferAsync signature, byte[] data) => JSA.CallAsync<bool>("crypto.subtle.verify", algorithm, key, signature, data);
        public Task<bool> Verify(string algorithm, CryptoKeyAsync key, ArrayBufferAsync signature, byte[] data) => JSA.CallAsync<bool>("crypto.subtle.verify", algorithm, key, signature, data);
        public Task<ArrayBufferAsync> WrapKey(string format, CryptoKeyAsync key, CryptoKeyAsync wrappingKey, EncryptParams wrapAlgo) => JSA.CallAsync<ArrayBufferAsync>("crypto.subtle.wrapKey", format, key, wrappingKey, wrapAlgo);
    }
}
