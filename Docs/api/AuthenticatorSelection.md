# AuthenticatorSelection

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/AuthenticatorSelection.cs`  
**MDN Reference:** [AuthenticatorSelection on MDN](https://developer.mozilla.org/en-US/docs/Web/API/CredentialsContainer/create#authenticatorselection)

> Used in CredentialCreatePublicKey https://developer.mozilla.org/en-US/docs/Web/API/CredentialsContainer/create#authenticatorselection

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `AuthenticatorSelection` | `class` | get/set | Used in CredentialCreatePublicKey https://developer.mozilla.org/en-US/docs/Web/API/CredentialsContainer/create#authenticatorselection |
| `RequireResidentKey` | `bool?` | get |  |
| `ResidentKey` | `string?` | get |  |
| `UserVerification` | `string?` | get |  |
| `AuthenticatorAttachment` | `string?` | get/set | A string indicating which authenticator attachment type should be permitted for the chosen authenticator. Possible values are: "platform" - The authenticator is part of the device WebAuthn is running on (termed a platform authenticator), therefore WebAuthn will communicate with it using a transport available to that platform, such as a platform-specific API. A public key credential bound to a platform authenticator is called a platform credential. "cross-platform" - The authenticator is not a part of the device WebAuthn is running on (termed a roaming authenticator as it can roam between different devices), therefore WebAuthn will communicate with it using a cross-platform transport protocol such as Bluetooth or NFC. A public key credential bound to a roaming authenticator is called a roaming credential. If omitted, any type of authenticator, either platform or cross-platform, can be selected for the credential creation operation. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<AuthenticatorSelection>(...)` or constructor `new AuthenticatorSelection(...)`

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

