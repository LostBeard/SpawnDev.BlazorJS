# CredentialGetIdentityOptions

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `CredentialGetOptions`  
**Source:** `JSObjects/CredentialGetIdentityOptions.cs`  
**MDN Reference:** [CredentialGetIdentityOptions on MDN](https://developer.mozilla.org/en-US/docs/Web/API/CredentialsContainer/get#options)

> If used for CredentialsContainer.Get() an IdentityCredential will be returned https://developer.mozilla.org/en-US/docs/Web/API/CredentialsContainer/get#options

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Identity` | `CredentialRequestOptions?` | get | An object containing details of federated identity providers (IdPs) that a relying party (RP) website can use for purposes such as signing in or signing up on a website. It causes the get() call to initiate a request for a user to sign in to an RP with an IdP. See the Federated Credential Management API section below for more details. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<CredentialGetIdentityOptions>(...)` or constructor `new CredentialGetIdentityOptions(...)`

### Retrieving a federated identity credential

```js
async function signIn() {
  const identityCredential = await navigator.credentials.get({
    identity: {
      providers: [
        {
          configURL: "https://accounts.idp.example/config.json",
          clientId: "********",
          params: {
            /* IdP-specific parameters */
          },
        },
      ],
    },
  });
}
```

### Retrieving a federated identity credential

```js
async function signIn() {
  const identityCredential = await navigator.credentials.get({
    identity: {
      context: "signup",
      providers: [
        {
          configURL: "https://accounts.idp.example/config.json",
          clientId: "********",
          params: {
            /* IdP-specific parameters */
          },
          loginHint: "user1@example.com",
        },
      ],
    },
  });
}
```

### Retrieving a federated identity credential

```js
async function signIn() {
  try {
    const identityCredential = await navigator.credentials.get({
      identity: {
        providers: [
          {
            configURL: "https://accounts.idp.example/config.json",
            clientId: "********",
            params: {
              /* IdP-specific parameters */
            },
          },
        ],
      },
    });
  } catch (e) {
    // Handle the error in some way, for example provide information
    // to help the user succeed in a future sign-in attempt
    console.error(e);
  }
}
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/CredentialsContainer/get)*

## Examples

### Retrieving a federated identity credential

Relying parties can call `get()` with the `identity` option to make a request for users to sign in to the relying party via an identity provider (IdP), using identity federation. A typical request would look like this:

```js
async function signIn() {
  const identityCredential = await navigator.credentials.get({
    identity: {
      providers: [
        {
          configURL: "https://accounts.idp.example/config.json",
          clientId: "********",
          params: {
            /* IdP-specific parameters */
          },
        },
      ],
    },
  });
}
```

Check out [Federated Credential Management (FedCM) API](/en-US/docs/Web/API/FedCM_API) for more details on how this works. This call will start off the sign-in flow described in [FedCM sign-in flow](/en-US/docs/Web/API/FedCM_API/RP_sign-in#fedcm_sign-in_flow).

A similar call including the `context` and `loginHint` extensions would look like so:

```js
async function signIn() {
  const identityCredential = await navigator.credentials.get({
    identity: {
      context: "signup",
      providers: [
        {
          configURL: "https://accounts.idp.example/config.json",
          clientId: "********",
          params: {
            /* IdP-specific parameters */
          },
          loginHint: "user1@example.com",
        },
      ],
    },
  });
}
```

If the IdP is unable to validate a request to the [ID assertion endpoint](/en-US/docs/Web/API/FedCM_API/IDP_integration#the_id_assertion_endpoint) it will reject the promise returned from `CredentialsContainer.get()`:

```js
async function signIn() {
  try {
    const identityCredential = await navigator.credentials.get({
      identity: {
        providers: [
          {
            configURL: "https://accounts.idp.example/config.json",
            clientId: "********",
            params: {
              /* IdP-specific parameters */
            },
          },
        ],
      },
    });
  } catch (e) {
    // Handle the error in some way, for example provide information
    // to help the user succeed in a future sign-in attempt
    console.error(e);
  }
}
```

### Retrieving a public key credential

The following snippet shows a typical `get()` call with the WebAuthn `publicKey` option:

```js
const publicKey = {
  challenge: new Uint8Array([139, 66, 181, 87, 7, 203 /* ,… */]),
  rpId: "acme.com",
  allowCredentials: [
    {
      type: "public-key",
      id: new Uint8Array([64, 66, 25, 78, 168, 226, 174 /* ,… */]),
    },
  ],
  userVerification: "required",
};

navigator.credentials.get({ publicKey });
```

A successful `get()` call returns a promise that resolves with a {{domxref("PublicKeyCredential")}} object instance, representing a public key credential previously created via a WebAuthn {{domxref("CredentialsContainer.create()", "create()")}} that has now been used to authenticate a user. Its {{domxref("PublicKeyCredential.response")}} property contains an {{domxref("AuthenticatorAssertionResponse")}} object providing access to several useful pieces of information including the authenticator data, signature, and user handle.

```js
navigator.credentials.get({ publicKey }).then((publicKeyCredential) => {
  const response = publicKeyCredential.response;

  // Access authenticator data ArrayBuffer
  const authenticatorData = response.authenticatorData;

  // Access client JSON
  const clientJSON = response.clientDataJSON;

  // Access signature ArrayBuffer
  const signature = response.signature;

  // Access userHandle ArrayBuffer
  const userHandle = response.userHandle;
});
```

Some of this data will need to be stored on the server — for example the `signature` to provide proof that authenticator possesses the genuine private key used to create the credential, and the `userHandle` to link the user with the credential, sign in attempt, and other data.

See [Authenticating a user](/en-US/docs/Web/API/Web_Authentication_API#authenticating_a_user) for more information about how the overall flow works.

### Retrieving a one-time password

The code below triggers the browser's permission flow when an SMS message arrives. If permission is granted, then the promise resolves with an `OTPCredential` object. The contained `code` value is then set as the value of an {{htmlelement("input")}} form element, which is then submitted.

```js
navigator.credentials
  .get({
    otp: { transport: ["sms"] },
    signal: ac.signal,
  })
  .then((otp) => {
    input.value = otp.code;
    if (form) form.submit();
  })
  .catch((err) => {
    console.error(err);
  });
```

### Implementing a timeout

In this example, we use {{domxref("AbortSignal.timeout_static", "AbortSignal.timeout()")}} to automatically abort the request if it takes longer than 10 seconds.

**JavaScript (MDN):**

```js
async function authenticateUser() {
  const publicKey = {
    challenge: new Uint8Array([139, 66, 181, 87, 7, 203 /* ,… */]),
    rpId: "acme.com",
    allowCredentials: [
      {
        type: "public-key",
        id: new Uint8Array([64, 66, 25, 78, 168, 226, 174 /* ,… */]),
      },
    ],
    userVerification: "required",
  };

  try {
    const credential = await navigator.credentials.get({
      publicKey,
      signal: AbortSignal.timeout(10000), // Abort after 10 seconds
    });
    console.log("Authentication successful:", credential);
  } catch (err) {
    if (err.name === "TimeoutError") {
      console.error("The authentication request timed out.");
    } else if (err.name === "AbortError") {
      console.log("The request was cancelled by the user.");
    } else {
      console.error("An unexpected error occurred:", err);
    }
  }
}
```

**C# (SpawnDev.BlazorJS):**

```csharp
// Requires: builder.Services.AddBlazorJSRuntime();
// Inject BlazorJSRuntime in your component or service:
// [Inject] BlazorJSRuntime JS { get; set; }

async Task authenticateUser()
{
var publicKey = {
challenge: new Uint8Array([139, 66, 181, 87, 7, 203 /* ,… */]),
rpId: "acme.com",
allowCredentials: [
{
type: "public-key",
id: new Uint8Array([64, 66, 25, 78, 168, 226, 174 /* ,… */]),
},
],
userVerification: "required",
};

try {
using var credential = await navigator.credentials.get({
publicKey,
signal: AbortSignal.timeout(10000), // Abort after 10 seconds
});
Console.WriteLine("Authentication successful:", credential);
} catch (err) {
if (err.name == "TimeoutError") {
Console.Error.WriteLine("The authentication request timed out.");
} else if (err.name == "AbortError") {
Console.WriteLine("The request was cancelled by the user.");
} else {
Console.Error.WriteLine("An unexpected error occurred:", err);
}
}
}
```

