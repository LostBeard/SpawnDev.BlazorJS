# CookieSelectOptions

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/CookieSelectOptions.cs`  
**MDN Reference:** [CookieSelectOptions on MDN](https://developer.mozilla.org/en-US/docs/Web/API/CookieStore/delete#options)

> https://developer.mozilla.org/en-US/docs/Web/API/CookieStore/delete#options

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `CookieSelectOptions` | `class` | get/set | https://developer.mozilla.org/en-US/docs/Web/API/CookieStore/delete#options |
| `Domain` | `string?` | get/set | A string with the domain of a cookie. Defaults to null. |
| `Path` | `string?` | get | A string containing a path. Defaults to /. |
| `Partitioned` | `bool?` | get | A boolean value that defaults to false. Setting it to true specifies that the cookie to delete will be a partitioned cookie. See Cookies Having Independent Partitioned State (CHIPS) for more information. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<CookieSelectOptions>(...)` or constructor `new CookieSelectOptions(...)`

### Delete a named cookie

```js
async function setTestCookies() {
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
  const cookieNames = (await cookieStore.getAll())
    .map((cookie) => cookie.name)
    .join(" ");
  console.log(`Initial cookies: ${cookieNames}`);
}
```

### Delete a named cookie

```js
async function cookieTest() {
  // Create our test cookies
  await setTestCookies();

  // Delete cookie1
  try {
    await cookieStore.delete("cookie1");
  } catch (error) {
    console.log(`Error deleting cookie1: ${error}`);
  }

  // Log cookie names again (to show cookie1 deleted)
  const cookieNames = (await cookieStore.getAll())
    .map((cookie) => cookie.name)
    .join(" ");
  console.log(
    `Cookies remaining after attempting to delete cookie1: ${cookieNames}`,
  );
}

cookieTest();
```

### Delete a cookie with options

```js
async function setTestCookies() {
  // Set two cookies
  try {
    await cookieStore.set({
      name: "cookie1",
      value: `cookie1-value`,
      partitioned: true,
    });
  } catch (error) {
    console.log(`Error setting cookie1: ${error}`);
  }

  try {
    await cookieStore.set({
      name: "cookie2",
      value: `cookie2-value`,
      partitioned: true,
    });
  } catch (error) {
    console.log(`Error setting cookie2: ${error}`);
  }

  // Log cookie names
  const cookieNames = (await cookieStore.getAll())
    .map((cookie) => cookie.name)
    .join(" ");
  console.log(`Initial cookies: ${cookieNames}`);
}
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/CookieStore/delete)*

