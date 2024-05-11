// Runs in a shared worker as a work around to a broadcast channel limitation that prevents passing of MessagePort

var messages = {};
var methods = {
    dropOff: function (toInstanceId, fromInstanceInfo, ports) {
        var args = [...arguments];
        console.log('dropOff()', args);
        var instanceMessages = messages[toInstanceId];
        if (!instanceMessages) {
            instanceMessages = [];
            messages[toInstanceId] = instanceMessages;
        }
        // notify the instance there is a message waiting
        var toInstanceChannel = new BroadcastChannel(toInstanceId);
        toInstanceChannel.postMessage(['interconnect']);
        instanceMessages.push({
            data: {
                fromInstanceInfo: fromInstanceInfo,
                time: new Date().getTime(),
            },
            ports: ports,
        });
    },
    pickUp: function (forInstanceId) {
        var args = [...arguments];
        console.log('pickUp()', args);
        var instanceMessages = messages[forInstanceId] ?? [];
        delete messages[forInstanceId];
        return instanceMessages;
    }
};
var instances = {};
self.addEventListener('connect', function (e) {
    console.log('*** connect', e);
    const port = e.ports[0];
    port.addEventListener('message', function (e) {
        console.log('*** message', e);
        var msg = e.data;
        var ports = e.ports;
        if (!msg) return;
        var cmd = msg.shift();
        switch (cmd) {
            case "init":
                var instanceInfo = msg.shift();
                instances[instanceInfo.instanceId] = {
                    instanceInfo: instanceInfo,
                    port: port,
                };
            case "dropOff":
                var toInstanceId = msg.shift();
                var fromInstanceInfo = msg.shift();
                methods.dropOff(toInstanceId, fromInstanceInfo, ports);
                console.log('recvd: dropOff', toInstanceId, fromInstanceInfo, ports);
                break;
            case "pickUp":
                var forInstanceId = msg.shift();
                var messages = methods.pickUp(forInstanceId);
                console.log('recvd: pickUp', forInstanceId, messages);
                if (messages && messages.length) {
                    for (var i = 0; i < messages.length; i++) {
                        var message = messages[i];
                        console.log('Sending stored message to target:', message.data, message.ports);
                        port.postMessage(message.data, message.ports);
                    }
                }
                break;
        }
    });
    port.addEventListener('close', function (e) {
        console.log('*** close', e);

    });
    port.start();
});
