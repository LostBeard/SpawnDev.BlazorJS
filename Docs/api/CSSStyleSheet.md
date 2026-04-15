# CSSStyleSheet

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `StyleSheet`  
**Source:** `JSObjects/CSSStyleSheet.cs`  
**MDN Reference:** [CSSStyleSheet on MDN](https://developer.mozilla.org/en-US/docs/Web/API/CSSStyleSheet)

> The CSSStyleSheet interface represents a single CSS stylesheet, and lets you inspect and modify the list of rules contained in the stylesheet. It inherits properties and methods from its parent, StyleSheet. https://developer.mozilla.org/en-US/docs/Web/API/CSSStyleSheet

## Constructors

| Signature | Description |
|---|---|
| `CSSStyleSheet(IJSInProcessObjectReference _ref)` | Deserialization constructor |
| `CSSStyleSheet()` | Creates a new instance of CSSStyleSheet |
| `CSSStyleSheet(CSSStyleSheetOptions options)` | Creates a new instance of CSSStyleSheet |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `CSSRules` | `CSSRuleList` | get | Returns a live CSSRuleList which maintains an up-to-date list of the CSSRule objects that comprise the stylesheet. |
| `OwnerRule` | `CSSRuleList` | get | If this stylesheet is imported into the document using an @import rule, the ownerRule property returns the corresponding CSSImportRule; otherwise, this property's value is null. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `InsertRule(string rule, int index)` | `int` | Inserts a new rule into the stylesheet. The rule to be inserted. The index at which to insert the rule. The index within the stylesheet's rule list of the newly inserted rule. |
| `DeleteRule(int index)` | `void` | Deletes the rule at the specified index into the stylesheet's rule list. The index of the rule to be deleted. |
| `Replace(string text)` | `Task<CSSStyleSheet>` | Asynchronously replaces the content of the stylesheet and returns a Promise that resolves with the updated CSSStyleSheet. A string containing the style rules to replace the content of the stylesheet. If the string does not contain a parsable list of rules, then the value will be set to an empty string. A Promise that resolves with the CSSStyleSheet. |
| `ReplaceSync(string text)` | `void` | Synchronously replaces the content of the stylesheet. A string containing the style rules to replace the content of the stylesheet. If the string does not contain a parsable list of rules, then the value will be set to an empty string. |

