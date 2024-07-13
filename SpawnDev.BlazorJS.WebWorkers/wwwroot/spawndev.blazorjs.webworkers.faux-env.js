'use strict';

// Todd Tanner
// 2022 - 2023
// built as part of SpawnDev.BlazorJS.WebWorkers
// This script creates a minimal Window scope environment to allow Blazor to boot up

var undefinedGets = {};
// https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Proxy
function createProxiedObject(obj, useIfDefined) {
    var ret = new Proxy(obj, {
        get(target, key) {
            if (useIfDefined && typeof useIfDefined[key] !== 'undefined') {
                return useIfDefined[key];
            }
            var ret = target[key];
            var typeofProp = typeof ret;
            var propIsUndefined = typeofProp === 'undefined';
            var typeofKey = typeof key;
            var keyIsSymbolIterator = key == Symbol.iterator;
            var keyIsSymbol = typeofKey === 'symbol';
            var keyStr = keyIsSymbol ? key.toString() : key;
            //consoleLog('get', target.constructor.name, keyStr, ret && ret.constructor ? ret.constructor.name : typeofProp, typeofProp !== 'function' ? ret : '(){ ... }');
            if (propIsUndefined) {
                var getKey = target.constructor.name + '.' + keyStr;
                if (!undefinedGets[getKey]) {
                    undefinedGets[getKey] = {};
                    consoleLog('undefined: ', getKey);
                }
            }
            return ret;
        },
        set(target, key, value) {
            if (typeof target[key] === 'undefined') {
                consoleLog('set', target.constructor.name, key);
            }
            target[key] = value;
            return true;
        },
        deleteProperty(target, key) {
            consoleLog('deleteProperty', target.constructor.name, key);
            if (!(key in target)) {
                return false;
            }
            delete target[key];
            return true;
        },
        ownKeys(target) {
            consoleLog('ownKeys', target.constructor.name);
            return Reflect.ownKeys(target);
        },
        has(target, key) {
            consoleLog('has', target.constructor.name, key);
            var ret = key in target || target[key];
            if (key === 'Blazor') {
                consoleLog('has"key") ==', ret);
            }
            return ret;
        },
        defineProperty(target, key, descriptor) {
            consoleLog('defineProperty', target, key, descriptor);
            if (descriptor && "value" in descriptor) {
                target[key] = descriptor.value;
            }
            return target;
        },
        getOwnPropertyDescriptor(target, key) {
            consoleLog('getOwnPropertyDescriptor', target, key);
            const value = target[key];
            return value
                ? {
                    value,
                    writable: true,
                    enumerable: true,
                    configurable: false,
                }
                : undefined;
        },
    });
    return ret;
}

class WebStorage {
    constructor() {
        this._store = {};
    }
    getItem(key) {
        consoleLog(this.constructor.name, 'getItem', key);
        return typeof this._store[key] === 'undefined' ? null : this._store[key];
    }
    setItem(key, value) {
        consoleLog(this.constructor.name, 'setItem', key);
        this._store[key] = value;
    }
    removeItem(key) {
        consoleLog(this.constructor.name, 'removeItem', key);
        delete this._store[key];
    }
}

class EventTargetFake {
    constructor() {
        this.listeners = {};
        consoleLog(this.constructor.name, 'new');
    }
    addEventListener(type, callback, options) {
        consoleLog(this.constructor.name, 'addEventListener', type);
        var callbacks = this.listeners[type];
        if (typeof callbacks === 'undefined') {
            callbacks = [];
            this.listeners[type] = callbacks;
        }
        callbacks.push({
            callback: callback,
            options: options,
        });
        return true;
    }
    removeEventListener(type, callback, options) {
        consoleLog(this.constructor.name, 'removeEventListener', type);
        var callbacks = this.listeners[type];
        if (typeof callbacks === 'undefined') {
            return false;
        }
        if (callback) {
            for (var i = 0; i < callbacks.length; i++) {
                var listener = callbacks[i];
                if (listener.callback === callback) {
                    delete callbacks[i];
                    return true;
                }
            }
        } else {
            delete this.listeners[type];
            return true;
        }
        return false;
    }
    dispatchEvent(event) {
        var type = event.type;
        consoleLog(this.constructor.name, 'dispatchEvent', event);
        if (typeof type !== 'string') {
            return false;
        }
        var listeners = this.listeners[type];
        if (typeof listeners === 'undefined') {
            return true;
        }
        for (var listener of listeners) {
            listener.callback(event);
        }
        return true;
    }
}

class Node extends EventTargetFake {
    constructor() {
        super();
        this._nodes = [];
        this._parent = null;
        this._baseURI = '';
        this.nodeType = 0;
        this.textContent = '';
    }
    static get ELEMENT_NODE() { return 1; }
    static get ATTRIBUTE_NODE() { return 2; }
    static get TEXT_NODE() { return 3; }
    static get CDATA_SECTION_NODE() { return 4; }
    static get PROCESSING_INSTRUCTION_NODE() { return 7; }
    static get COMMENT_NODE() { return 8; }
    static get DOCUMENT_NODE() { return 9; }
    static get DOCUMENT_TYPE_NODE() { return 10; }
    static get DOCUMENT_FRAGMENT_NODE() { return 11; }
    getChildNodeIndex(node) {
        return this.childNodes.indexOf(node);
    }
    get previousSibling() {
        var p = this.parentNode;
        if (!p) return null;
        var i = p.childNodes.indexOf(this);
        if (i < 1) return null;
        return i - 1;
    }
    get nextSibling() {
        var p = this.parentNode;
        if (!p) return null;
        var i = p.childNodes.indexOf(this);
        if (i == -1 || i == p.childNodes.length - 1) return null;
        return i + 1;
    }
    insertBefore(newNode, referenceNode) {
        var refI = this.getChildNodeIndex(referenceNode);
        if (refI == -1) return;
        this.childNodes.splice(refI, 0, newNode);
    }
    insertAfter(newNode, referenceNode) {
        var refI = this.getChildNodeIndex(referenceNode);
        if (refI == -1) return;
        this.childNodes.splice(refI + 1, 0, newNode);
    }
    get baseURI() {
        return this._baseURI;
    }
    set baseURI(value) {
        this._baseURI = value;
    }
    get childNodes() {
        return this._nodes;
    }
    get parentNode() {
        return this._parent;
    }
    set parentNode(value) {
        this._parent = value;
    }
    get firstChild() {
        return this.childNodes.length == 0 ? null : this.childNodes[0];
    }
    appendChild(node) {
        node.parentNode = this;
        this._nodes.push(node);
        var nodeType = node.constructor.name;
        var thisType = this.constructor.name;
        consoleLog(`appendChild: ${nodeType} to ${thisType}`);
        document._nodeAppended(node);
        return node;
    }
    hasChildNodes() {
        return this._nodes.length > 0;
    }
    getRootNode() {
        return document;
    }
    removeChild(node) {
        var i = this.childNodes.indexOf(node);
        if (i > -1) {
            this.childNodes.splice(i, 1);
        }
    }
    descendants() {
        var ret = [];
        var search = function (nodes) {
            nodes.forEach((node) => {
                ret.push(node);
                if (node.hasChildNodes()) search(node.childNodes);
            });
        };
        search(this.childNodes);
        return ret;
    }
}

class Document extends Node {
    constructor() {
        super();
        this._currentScript = null;
        this._head = null;
        this._body = null;
        this.nodeType = Node.DOCUMENT_NODE;
        this.activeElement = null;
        this._beenInit = false;
        this._importScriptsOnInit = true;
        this._readyState = '';
    }
    _nodeAppended(node) {
        // if the dom hasn't been init yet do nothing here. the node will be init whe nthe doucment is
        if (this._beenInit) {
            if (node instanceof HTMLScriptElement) {
                this.initScriptElement(node);
            }
        }
    }
    initScriptElement(node) {
        this.currentScript = node;
        // behaves differently than a standard script loader...
        // uses the text attribute if available instead of the src (to allow using modified script in text)
        if (node.text) {
            consoleLog('Loading script text');
            try {
                let fn = new Function(node.text);
                fn.apply(self, []);
                if (node.onload) node.onload();
            } catch (ex) {
                console.error('ERROR loading document script', href, ex);
                if (node.onerror) node.onerror();
            }
        } else if (node.src) {
            consoleLog('Loading script src');
            var href = new URL(node.src, this.baseURI).toString();
            try {
                importScripts(href);
                if (node.onload) node.onload();
            } catch (ex) {
                console.error('ERROR loading document script', href, ex);
                if (node.onerror) node.onerror();
            }
        }
        this.currentScript = null;
    }
    get readyState() {
        return this._readyState;
    }
    setReadyState(state) {
        if (this._readyState == state) return false;
        this._readyState = state;
        consoleLog('document readystatechanged', state);
        // if events are enabled ...
        this.dispatchEvent(new Event('readystatechange'));
    }
    get documentElement() {
        return this._nodes.length == 0 ? null : this._nodes[0]
    }
    get head() {
        return this._head;
    }
    get body() {
        return this._body;
    }
    createComment(data) {
        return createProxiedObject(new Comment(data));
    }
    createTextNode(data) {
        return createProxiedObject(new Text(data));
    }
    createElement(tagName) {
        var proxyWrap = false;
        var makeEl = function () {
            switch (tagName) {
                case 'html': return new HTMLHtmlElement();
                case 'head': return new HTMLHeadElement();
                case 'body': return new HTMLBodyElement();
                case 'link': return new HTMLLinkElement();
                case 'div': return new HTMLDivElement();
                case 'a': return new HTMLAnchorElement();
                case 'script': return new HTMLScriptElement();
                case 'template': return new HTMLTemplateElement();
                case 'svg': return new SVGElement();
                case 'title': return new HTMLTitleElement();
                case 'canvas': return new HTMLCanvasElement();
                default: return new HTMLUnknownElement();
            }
        }
        var ret = makeEl();
        if (proxyWrap) ret = createProxiedObject(ret);
        consoleLog(this.constructor.name, 'createElement', tagName, ret.constructor.name);
        ret.tagName = tagName.toUpperCase();
        return ret;
    }
    createElementNS(namespaceURI, qualifiedName) {
        consoleLog(this.constructor.name, 'createElementNS', namespaceURI, qualifiedName);
        var ret = this.createElement(qualifiedName);
        ret.namespaceURI = namespaceURI;
        return ret;
    }
    querySelector(selector) {
        consoleLog(this.constructor.name, 'querySelector', selector);
        var nodes = this.descendants();
        // id search
        var idPatt = new RegExp('^#([a-z][a-z0-9_-]*)$');
        var m = idPatt.exec(selector);
        if (m) {
            var id = m[1];
            for (var i = 0; i < nodes.length; i++) {
                var n = nodes[i];
                if (n.getAttribute('id') === id) return n;
            }
            return null;
        }
        if (selector === 'head') return this.head;
        else if (selector === 'body') return this.body;
        return null;
    }
    querySelectorAll(selector) {
        // this method is not expeceted to work 100% as it is needed to just fake a document not truly implememnt one perfectly
        var ret = [];
        consoleLog(this.constructor.name, 'querySelectorAll', selector);
        var nodes = this.descendants();
        if (selector === '*') {
            return descendants;
        }
        // id search
        var idPatt = new RegExp('^#([a-z][a-z0-9_-]*)$');
        var m = idPatt.exec(selector);
        if (m) {
            var id = m[1];
            for (var i = 0; i < nodes.length; i++) {
                var n = nodes[i];
                if (n.getAttribute('id') === id) {
                    ret.push(n);
                }
            }
        }
        if (selector === 'head') ret.push(this.head);
        else if (selector === 'body') ret.push(this.body);
        return ret;
    }
    addGlobalListener() {
        consoleLog(this.constructor.name, 'addGlobalListener');

    }
    get scripts() {
        var nodes = this.descendants().filter(o => o.constructor.name === 'HTMLScriptElement');
        return nodes;
    }
    get currentScript() {
        consoleLog(this.constructor.name, 'currentScript');
        return this._currentScript;
    }
    set currentScript(value) {
        this._currentScript = value;
    }
    get location() {
        return location;
    }
    createRange() {
        consoleLog(this.constructor.name, 'createRange');
        var ret = createProxiedObject(new Range());
        return ret;
    }
    initDocument() {
        if (this._beenInit) {
            console.error('document has already been initialized');
            return;
        }
        this._beenInit = true;
        this.setReadyState('loading');
        if (this.childNodes.length > 0) {
            var rootNode = this.childNodes[0];
            if (rootNode instanceof HTMLHtmlElement && rootNode.hasChildNodes()) {
                rootNode.childNodes.forEach((n) => {
                    if (n instanceof HTMLHeadElement) {
                        this._head = n;
                    } else if (n instanceof HTMLBodyElement) {
                        this._body = n;
                    }
                });
            }
        }
        this.activeElement = this.body;
        //document.dispatchEvent(new Event('DOMContentLoaded'));
        //consoleLog("document.dispatchEvent('DOMContentLoaded')");
        //this.setReadyState('interactive');
        if (this._importScriptsOnInit) {
            consoleLog("importing scripts from all script elements in document");
            var nodes = this.descendants();
            for (var node of nodes) {
                if (node instanceof HTMLScriptElement) {
                    this.initScriptElement(node);
                }
            }
        }
        this.setReadyState('interactive');

        this.dispatchEvent(new Event('DOMContentLoaded'));
        consoleLog("document.dispatchEvent('DOMContentLoaded')");

        consoleLog("window.dispatchEvent('load')");
        window.dispatchEvent(new Event('load'));
        this.setReadyState('complete');
    }
}

// https://developer.mozilla.org/en-US/docs/Web/API/Document
class HTMLDocument extends Document {
    constructor() {
        super();
    }

}

class CSSStyleDeclaration {
    constructor() {
        this._styles = {};
    }
    setProperty(key, value) {
        //consoleLog(this.constructor.name, 'setProperty', key);
        this._styles[key] = value;
    }
    getProperty(key) {
        //consoleLog(this.constructor.name, 'getProperty', key);
        return this._styles[key];
    }
}

class DocumentFragment extends Node {
    constructor() {
        super();
        this.nodeType = Node.DOCUMENT_FRAGMENT_NODE;
    }
}

class Element extends Node {
    constructor() {
        super();
        this.tagName = '';
        this.namespaceURI = null;
        this._innerHTML = '';
        this.id = '';
        this.nodeType = Node.ELEMENT_NODE;
    }
    get innerHTML() {
        return this._innerHTML;
    }
    set innerHTML(data) {
        this._innerHTML = data;
    }
    getElementsByTagName(tagName) {
        //consoleLog(this.constructor.name, 'getElementsByTagName', tagName);
        var ret = [];
        tagName = tagName.toUpperCase();
        var nodes = this.descendants();
        for (const node of nodes) {
            if (!(node instanceof HTMLElement)) continue;
            if (node.tagName && node.tagName.toUpperCase() === tagName) {
                ret.push(node);
            }
        }
        consoleLog(this.constructor.name, 'getElementsByTagName', tagName, ret);
        return ret;
    }
    getElementsByTagNameNS(namespaceURI, localName) {
        consoleLog(this.constructor.name, 'getElementsByTagNameNS', namespaceURI, localName);
        var ret = [];
        localName = localName.toUpperCase();
        var nodes = this.descendants();
        for (const node of nodes) {
            if (!(node instanceof HTMLElement)) continue;
            if (node.tagName && node.tagName.toUpperCase() === localName && node.namespaceURI === namespaceURI) {
                ret.push(node);
            }
        }
        return ret;
    }
    getAttribute(attributeName) {
        consoleLog(this.constructor.name, 'getAttribute', attributeName);
        return this[attributeName];
    }
    setAttribute(attributeName, value) {
        consoleLog(this.constructor.name, 'setAttribute', attributeName);
        this[attributeName] = value;
    }
    removeAttribute(attributeName) {
        consoleLog(this.constructor.name, 'removeAttribute', attributeName);
        return delete this[attributeName];
    }
    get attributes() { return this; };
}

class SVGElement extends Element {
    constructor() {
        super();
    }
}
class HTMLElement extends Element {
    constructor() {
        super();
        this._style = createProxiedObject(new CSSStyleDeclaration());
    }
    get style() {
        return this._style;
    }
}

class HTMLLinkElement extends HTMLElement {
    constructor() {
        super();
    }
}
class HTMLDivElement extends HTMLElement {
    constructor() {
        super();
    }
}
class HTMLTemplateElement extends HTMLElement {
    constructor() {
        super();
        this._content = createProxiedObject(new DocumentFragment());
    }
    get content() {
        return this._content;
    }
}
class HTMLTitleElement extends HTMLElement {
    constructor() {
        super();
    }
}
class HTMLAnchorElement extends HTMLElement {
    constructor() {
        super();
    }

}
class HTMLUnknownElement extends HTMLElement {
    constructor() {
        super();
    }
}
class HTMLHtmlElement extends HTMLElement {
    constructor() {
        super();
    }
}
class HTMLHeadElement extends HTMLElement {
    constructor() {
        super();
    }
}
class HTMLBodyElement extends HTMLElement {
    constructor() {
        super();
    }
}

class HTMLScriptElement extends HTMLElement {
    constructor() {
        super();
        this._src = '';
        this._text = '';
        this.onload = null;
        this.onerror = null;
    }
    get src() { return this._src; }
    set src(value) {
        consoleLog(this.constructor.name, 'src');
        this._src = value;
    }
    get text() { return this._text; }
    set text(value) {
        consoleLog(this.constructor.name, 'text');
        this._text = value;
    }
}
class HTMLButtonElement extends HTMLElement {
    constructor() {
        super();
    }
}
class HTMLTextAreaElement extends HTMLElement {
    constructor() {
        super();
    }
}
class HTMLInputElement extends HTMLElement {
    constructor() {
        super();
    }
}
class HTMLOptionElement extends HTMLElement {
    constructor() {
        super();
    }
}
class HTMLSelectElement extends HTMLElement {
    constructor() {
        super();
    }
}
class HTMLTableElement extends HTMLElement {
    constructor() {
        super();
    }
}
class HTMLTableSectionElement extends HTMLElement {
    constructor() {
        super();
    }
}
class HTMLImageElement extends HTMLElement {
    constructor() {
        super();
    }
}
class HTMLVideoElement extends HTMLElement {
    constructor() {
        super();
    }
}
class HTMLCanvasElement extends OffscreenCanvas {
    constructor() {
        super(1, 1);
    }
}
class CanvasRenderingContext2D extends OffscreenCanvasRenderingContext2D {
    constructor() {
        super();
    }
}
class IntersectionObserver { }
class MutationObserver { }
class Comment extends HTMLElement {
    constructor() {
        super();
        this.nodeType = Node.COMMENT_NODE;
    }
    Symbol() {
        return Symbol('comment_symbol');
    }
}

class CharacterData extends Node {
    constructor() {
        super();
        this.data = '';
    }
    get length() {
        return this.data.length;
    }
}

class Text extends CharacterData {
    constructor(data) {
        super();
        this.nodeType = Node.TEXT_NODE;
    }
    Symbol() {
        return Symbol('text_symbol');
    }
}

class History {
    constructor() {

    }
    get state() {
        return null;
    }
    go() {

    }
    replaceState() {

    }
    pushState() {

    }
}

class WindowFake extends EventTargetFake {
    constructor() {
        super();

    }
}
class NavigationFake extends EventTargetFake {
    constructor() {
        super();

    }
}


(function () {
    if (typeof self.document !== 'undefined') {
        return;
    }
    var history = createProxiedObject(new History());
    var document = createProxiedObject(new HTMLDocument());
    // assign a proxied globaThis to window
    self.window = createProxiedObject(self, new WindowFake());
    self.navigation = createProxiedObject(self, new NavigationFake());
    self.window.parent = self.window;
    self.history = history;
    self.document = document;
    self.localStorage = createProxiedObject(new WebStorage());
    self.sessionStorage = createProxiedObject(new WebStorage());
    self.devicePixelRatio = 1;
    self.screen = {
        availHeight: 1050,
        availLeft: 3840,
        availTop: 0,
        availWidth: 1920,
        colorDepth: 24,
        height: 1080,
        isExtended: true,
        onchange: null,
        orientation: {
            angle: 0,
            type: 'landscape-primary',
            onchange: null
        },
        pixelDepth: 24,
        width: 1920,
    };
    self.customElements = createProxiedObject({
        elements: {},
        define: function (name, constructor, options) {
            consoleLog('customElements.define:', name);
            this.elements[name] = {
                constructor: constructor,
                options: options,
            };
        }
    });
    // document.baseURI (defaults to worker directory here, can be set later)
    var href = self.location.href;
    var webWorkerContentDir = href.substring(0, href.lastIndexOf('/') + 1);
    document.baseURI = webWorkerContentDir;
})();

// *********** Fake Window scope environment is built ***********
// - add needed elements like html, head, body, script
// - adjust the document baseURI (if needed)
// - finally: call document.initDocument() to initialize the document
//
// Example:
//var htmlEl = document.appendChild(document.createElement('html'));
//var headEl = htmlEl.appendChild(document.createElement('head'));
//var bodyEl = htmlEl.appendChild(document.createElement('body'));
//var blazorWASMScriptEl = bodyEl.appendChild(document.createElement('script'));
//blazorWASMScriptEl.setAttribute('src', '_framework/blazor.webassembly.js');
//...
//document.initDocument();
