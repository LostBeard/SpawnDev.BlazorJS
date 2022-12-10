'use strict';

// https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Proxy

var undefinedGets = {};

function createProxiedObject(obj) {
    var ret = new Proxy(obj, {
        get(target, key) {
            var ret = target[key];
            var typeofProp = typeof ret;
            var propIsUndefined = typeofProp === 'undefined';
            var typeofKey = typeof key;
            var keyIsSymbolIterator = key == Symbol.iterator;
            var keyIsSymbol = typeofKey === 'symbol';
            var keyStr = keyIsSymbol ? key.toString() : key;
            //consoleLog('get', target.constructor.name, keyStr, typeofProp === 'object' && typeofProp.constructor ? typeofProp.constructor.name : typeofProp, typeofProp !== 'function' ? ret : '(){ ... }');
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
            //consoleLog('set', target.constructor.name, key);
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
            return Object.keys(target);
        },
        has(target, key) {
            consoleLog('has', target.constructor.name, key);
            return key in target || target[key];
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
        consoleLog(this.constructor.name, 'new');
    }
    addEventListener(type, listener, options) {
        consoleLog(this.constructor.name, 'addEventListener', type);
    }
    removeEventListener(type, listener, options) {
        consoleLog(this.constructor.name, 'removeEventListener', type);
    }
    dispatchEvent(event) {
        consoleLog(this.constructor.name, 'dispatchEvent', event);
    }
}

//class Window extends EventTargetFake {
//    constructor() {
//        super();
//        this._localStorage = new WebStorage();
//        this._sessionStorage = new WebStorage();
//    }
//    get isSecureContext() { return true; }
//    get localStorage() { return this._localStorage; }
//    get sessionStorage() { return this._sessionStorage; }
//}

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

// https://developer.mozilla.org/en-US/docs/Web/API/Document
class HTMLDocument extends Node {
    constructor() {
        super();
        this._currentScript = null;
        this._head = null;
        this._body = null;
        this.nodeType = Node.DOCUMENT_NODE;
        this.activeElement = null;
    }
    get documentElement() {
        return this._nodes.length == 0 ? null : this._nodes[0]
    }
    //appendChild(node) {
    //    node.parentNode = this;
    //    this._nodes.push(node);
    //    var nodeType = node.constructor.name;
    //    var thisType = this.constructor.name;
    //    consoleLog(`appendChild: ${nodeType} to ${thisType}`);
    //    if (node instanceof HTMLHeadElement) {
    //        this._head = node;
    //    } else if (node instanceof HTMLBodyElement) {
    //        this._body = node;
    //    }
    //    return node;
    //}
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
                default: return new HTMLUnknownElement();
            }
        }
        var ret = createProxiedObject(makeEl());
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
        if (selector === 'body') return this.body;
        return null;
    }
    querySelectorAll(selector) {
        consoleLog(this.constructor.name, 'querySelectorAll', selector);
        return [];
    }
    addGlobalListener() {
        consoleLog(this.constructor.name, 'addGlobalListener');

    }
    get currentScript() {
        consoleLog(this.constructor.name, 'currentScript');
        // To start blazor it needs to think the currentScript is it's own script tag
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
        if (this.childNodes.length > 0) {
            var rootNode = this.childNodes[0];
            if (rootNode instanceof HTMLHtmlElement && rootNode.hasChildNodes()) {
                var head = null;
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
        consoleLog('!!! document ready !!!');
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
        consoleLog(this.constructor.name, 'getProperty', key);
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
        this._attributes = {};
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
        tagName = tagName.toUpperCase();    // When called on an HTML element in an HTML document, getElementsByTagName lower-cases the argument before searching for it.
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
        localName = localName.toUpperCase();    // When called on an HTML element in an HTML document, getElementsByTagName lower-cases the argument before searching for it.
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
        //this._attributes[attributeName] = value;
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
    }
    get src() { return this._src; }
    set src(value) {
        consoleLog(this.constructor.name, 'src');
        this._src = value;
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
class IntersectionObserver { }
class MutationObserver { }
class Comment extends HTMLElement {
    constructor() {
        super();
        this.nodeType = Node.COMMENT_NODE;
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

(function () {
    if (typeof globalThisObj.document !== 'undefined') {
        return;
    }
    var history = createProxiedObject(new History());
    var document = createProxiedObject(new HTMLDocument());
    // assign to global object
    globalThisObj.window = createProxiedObject(new Proxy(self, {
        get(target, key) {
            var ret = target[key];
            if (key == 'addEventListener') {
                ret = function (eventName) {
                    consoleLog('window.addEventListener', eventName);
                };
            }
            return ret;
        },
    }));
    globalThisObj.window.parent = globalThisObj.window;
    globalThisObj.history = history;
    globalThisObj.document = document;
    globalThisObj.localStorage = createProxiedObject(new WebStorage());
    globalThisObj.sessionStorage = createProxiedObject(new WebStorage());
    // document.baseURI
    var href = globalThisObj.location.href;
    var webWorkerContentDir = href.substring(0, href.lastIndexOf('/') + 1);
    if (webWorkerContentDir.indexOf('_content/') > 0) {
        webWorkerContentDir = new URL(webWorkerContentDir + '../../').toString();
    }
    document.baseURI = webWorkerContentDir;
    consoleLog('document.baseURI', document.baseURI);
    // setup standard document
    var htmlEl = document.appendChild(document.createElement('html'));
    var headEl = htmlEl.appendChild(document.createElement('head'));
    var bodyEl = htmlEl.appendChild(document.createElement('body'));
    // add page specific stuff
    // <div id="app">
    var appDiv = bodyEl.appendChild(document.createElement('div'));
    appDiv.setAttribute('id', 'app');
    // <div id="blazor-error-ui">
    var errorDiv = bodyEl.appendChild(document.createElement('div'));
    errorDiv.setAttribute('id', 'blazor-error-ui');
    // <script src="_framework/blazor.webassembly.js" autostart="false"></script>
    var blazorWASMScriptEl = bodyEl.appendChild(document.createElement('script'));
    blazorWASMScriptEl.setAttribute('autostart', "false");
    blazorWASMScriptEl.setAttribute('src', '_framework/blazor.webassembly.js');
    // the inital document is now added to the DOM and ready to be initialized
    // essentially at the state when the html page has been loaded but no elements have been parsed (no scripts loaded yet)
    document.initDocument();
    // blazor checks the currentScript for an attribute names "autostart"
    // TODO - handle below cleaner. init doc shuld iterate and load scripts
    document.currentScript = blazorWASMScriptEl;
})();

