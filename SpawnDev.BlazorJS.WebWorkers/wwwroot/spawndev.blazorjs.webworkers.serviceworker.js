


console.log('blazorjs erviceworker');

addEventListener('install', (event) => {
    event.waitUntil(async () => {

    });
});

addEventListener('fetch', (event) => {
    event.respondWith((async () => {
        if (whatever) {
            const { complicatedThing } = await import('./big-script.js');
            // …etc…
        }
    })());
});