# PublicKeyCredentialParameter

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/PublicKeyCredentialParameter.cs`  
**MDN Reference:** [PublicKeyCredentialParameter on MDN](https://developer.mozilla.org/en-US/docs/Web/API/CredentialsContainer/create#pubkeycredparams)

> Used for property CredentialCreatePublicKey.PubKeyCredParams https://developer.mozilla.org/en-US/docs/Web/API/CredentialsContainer/create#pubkeycredparams

## Constructors

| Signature | Description |
|---|---|
| `PublicKeyCredentialParameter()` | Default constructor |
| `PublicKeyCredentialParameter(int alg)` | Creates a new instance with the specified algorithm |
| `PublicKeyCredentialParameter(int alg, string type)` | Creates a new instance with the specified algorithm and type |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `PublicKeyCredentialParameter` | `class` | get | Used for property CredentialCreatePublicKey.PubKeyCredParams https://developer.mozilla.org/en-US/docs/Web/API/CredentialsContainer/create#pubkeycredparams |
| `Alg` | `int` | get | A number that is equal to a COSE Algorithm Identifier, representing the cryptographic algorithm to use for this credential type. It is recommended that relying parties that wish to support a wide range of authenticators should include at least the following values in the provided choices: -8: Ed25519 -7: ES256 -257: RS256 |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `int(PublicKeyCredentialParameter obj)` | `implicit operator` | Implicit operator to get the algorithm from a PublicKeyCredentialParameter |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<PublicKeyCredentialParameter>(...)` or constructor `new PublicKeyCredentialParameter(...)`

### Creating a password credential

```js
const credInit = {
  id: "serpent1234", // "username" in a typical username/password pair
  name: "Serpentina", // display name for credential
  origin: "https://example.org",
  password: "the last visible dog",
};

const makeCredential = document.querySelector("#make-credential");

makeCredential.addEventListener("click", async () => {
  const cred = await navigator.credentials.create({
    password: credInit,
  });
  console.log(cred.name);
  // Serpentina
  console.log(cred.id);
  // serpent1234
  console.log(cred.password);
  // the last visible dog
});
```

### Creating a federated credential

```js
const credInit = {
  id: "1234",
  name: "Serpentina",
  origin: "https://example.org",
  protocol: "openidconnect",
  provider: "https://provider.example.org",
};

const makeCredential = document.querySelector("#make-credential");

makeCredential.addEventListener("click", async () => {
  const cred = await navigator.credentials.create({
    federated: credInit,
  });
  console.log(cred.name);
  console.log(cred.provider);
});
```

### Creating a public key credential

```js
const publicKey = {
  challenge: challengeFromServer,
  rp: { id: "acme.com", name: "ACME Corporation" },
  user: {
    id: new Uint8Array([79, 252, 83, 72, 214, 7, 89, 26]),
    name: "jamiedoe",
    displayName: "Jamie Doe",
  },
  pubKeyCredParams: [{ type: "public-key", alg: -7 }],
};

const publicKeyCredential = await navigator.credentials.create({ publicKey });
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/CredentialsContainer/create)*

