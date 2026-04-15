# RelyingParty

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/RelyingParty.cs`  
**MDN Reference:** [RelyingParty on MDN](https://developer.mozilla.org/en-US/docs/Web/API/CredentialsContainer/create#rp)

> An object describing the relying party that requested the credential creation. Used for property CredentialCreatePublicKey.Rp https://developer.mozilla.org/en-US/docs/Web/API/CredentialsContainer/create#rp

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `RelyingParty` | `class` | get | An object describing the relying party that requested the credential creation. Used for property CredentialCreatePublicKey.Rp https://developer.mozilla.org/en-US/docs/Web/API/CredentialsContainer/create#rp |
| `Id` | `string?` | get |  |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `party(as identified by the publicKey.rpId in a navigator.credentials.get()` | `key credential can only be used for authentication with the same relying` |  |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<RelyingParty>(...)` or constructor `new RelyingParty(...)`

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

