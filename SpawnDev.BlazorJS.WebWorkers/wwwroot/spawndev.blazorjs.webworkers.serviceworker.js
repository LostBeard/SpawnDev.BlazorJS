


console.log('BlazorJS.WebWorkers.ServiceWorker');
// NOTE - This is not likely feasible as service workers should start up quickly and can be shut down immediately after they are no longer needed for fetch calls
// .Net's startup time makes this it a poor fit for service workers... at least with my current implmentation

addEventListener('install', (event) => {
    event.waitUntil(async () => {

    });
});

addEventListener('fetch', (event) => {
    event.respondWith((async () => {

    })());
});
