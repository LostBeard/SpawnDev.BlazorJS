# CookieStore

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `EventTarget`  
**Source:** `JSObjects/CookieStore.cs`  
**MDN Reference:** [CookieStore on MDN](https://developer.mozilla.org/en-US/docs/Web/API/CookieStore)

> The CookieStore interface of the Cookie Store API provides methods for getting and setting cookies asynchronously from either a page or a service worker. The CookieStore is accessed via attributes in the global scope in a Window or ServiceWorkerGlobalScope context. Therefore there is no constructor. https://developer.mozilla.org/en-US/docs/Web/API/CookieStore

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Delete(string name)` | `Task` | The delete() method deletes a cookie with the given name or options object. It returns a Promise that resolves when the deletion completes or if no cookies are matched. |
| `Delete(CookieSelectOptions options)` | `Task` | The delete() method deletes a cookie with the given name or options object. It returns a Promise that resolves when the deletion completes or if no cookies are matched. |
| `Get(string name)` | `Task<Cookie?>` | The get() method gets a single cookie with the given name or options object. It returns a Promise that resolves with details of a single cookie. |
| `Get(CookieSelectOptions options)` | `Task<Cookie?>` | The get() method gets a single cookie with the given name or options object. It returns a Promise that resolves with details of a single cookie. |
| `GetAll()` | `Task<Cookie[]>` | The getAll() method gets all matching cookies. It returns a Promise that resolves with a list of cookies. |
| `GetAll(string name)` | `Task<Cookie[]>` | The getAll() method gets all matching cookies. It returns a Promise that resolves with a list of cookies. |
| `GetAll(CookieSelectOptions options)` | `Task<Cookie[]>` | The getAll() method gets all matching cookies. It returns a Promise that resolves with a list of cookies. |
| `Set(string name, string value)` | `Task` | The set() method sets a cookie with the given name and value or options object. It returns a Promise that resolves when the cookie is set. |
| `Set(Cookie options)` | `Task` | The set() method sets a cookie with the given name and value or options object. It returns a Promise that resolves when the cookie is set. |

## Events

| Event | Type | Description |
|---|---|---|
| `OnChange` | `ActionEvent<CookieChangeEvent>` | The change event fires when a change is made to any cookie. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<CookieStore>(...)` or constructor `new CookieStore(...)`

### Setting cookies

```js
async function cookieTest() {
  // Set cookie: passing name and value
  try {
    await cookieStore.set("cookie1", "cookie1-value");
  } catch (error) {
    console.log(`Error setting cookie1: ${error}`);
  }

  // Set cookie: passing options
  const day = 24 * 60 * 60 * 1000;

  try {
    await cookieStore.set({
      name: "cookie2",
      value: "cookie2-value",
      expires: Date.now() + day,
      partitioned: true,
    });
  } catch (error) {
    log(`Error setting cookie2: ${error}`);
  }

  // Get named cookies and log their properties
  const cookie1 = await cookieStore.get("cookie1");
  console.log(cookie1);

  const cookie2 = await cookieStore.get("cookie2");
  console.log(cookie2);
}

cookieTest();
```

### Getting cookies

```js
async function cookieTest() {
  // Set a cookie passing name and value
  try {
    await cookieStore.set("cookie1", "cookie1-value");
  } catch (error) {
    console.log(`Error setting cookie1: ${error}`);
  }

  // Set a cookie passing an options object
  const day = 24 * 60 * 60 * 1000;
  try {
    await cookieStore.set({
      name: "cookie2",
      value: `cookie2-value`,
      expires: Date.now() + day,
      partitioned: true,
    });
  } catch (error) {
    console.log(`Error setting cookie2: ${error}`);
  }

  // Set cookie using document.cookie
  // (to demonstrate these are fetched too)
  document.cookie = "favorite_food=tripe; SameSite=None; Secure";

  // Get named cookie and log properties
  const cookie1 = await cookieStore.get("cookie1");
  console.log(cookie1);

  // Get all cookies and log each
  const cookies = await cookieStore.getAll();
  if (cookies.length > 0) {
    console.log(`getAll(): ${cookies.length}:`);
    cookies.forEach((cookie) => console.log(cookie));
  } else {
    console.log("Cookies not found");
  }
}

cookieTest();
```

### Delete a named cookie

```js
async function cookieTest() {
  // Set two cookies
  try {
    await cookieStore.set("cookie1", "cookie1-value");
  } catch (error) {
    console.log(`Error setting cookie1: ${error}`);
  }

  try {
    await cookieStore.set("cookie2", "cookie2-value");
  } catch (error) {
    console.log(`Error setting cookie2: ${error}`);
  }

  // Log cookie names
  let cookieNames = (await cookieStore.getAll())
    .map((cookie) => cookie.name)
    .join(" ");
  console.log(`Initial cookies: ${cookieNames}`);

  // Delete cookie1
  await cookieStore.delete("cookie1");

  // Log cookies again (to show cookie1 deleted)
  cookieNames = (await cookieStore.getAll())
    .map((cookie) => cookie.name)
    .join(" ");
  console.log(
    `Cookies remaining after attempted deletions (cookie1 should be deleted): ${cookieNames}`,
  );
}

cookieTest();
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/CookieStore)*

