# AesCtrParams

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `EncryptParams`  
**Source:** `JSObjects/Cryptography/AesCtrParams.cs`  
**MDN Reference:** [AesCtrParams on MDN](https://developer.mozilla.org/en-US/docs/Web/API/AesCtrParams)

> The AesCtrParams dictionary of the Web Crypto API represents the object that should be passed as the algorithm parameter into SubtleCrypto.encrypt(), SubtleCrypto.decrypt(), SubtleCrypto.wrapKey(), or SubtleCrypto.unwrapKey(), when using the AES-CTR algorithm. https://developer.mozilla.org/en-US/docs/Web/API/AesCtrParams

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Name` | `override string` | get | A string. This should be set to AES-CTR. |
| `Counter` | `Union<ArrayBuffer, TypedArray, DataView>?` | get | An ArrayBuffer, a TypedArray, or a DataView - the initial value of the counter block. This must be 16 bytes long (the AES block size). The rightmost length bits of this block are used for the counter, and the rest is used for the nonce. For example, if length is set to 64, then the first half of counter is the nonce and the second half is used for the counter. |
| `Length` | `int` | get | A Number - the number of bits in the counter block that are used for the actual counter. The counter must be big enough that it doesn't wrap: if the message is n blocks and the counter is m bits long, then the following must be true: n &lt;= 2^m. The NIST SP800-38A standard, which defines CTR, suggests that the counter should occupy half of the counter block (see Appendix B.2), so for AES it would be 64. |

