const _ = require('lodash')
const Wemo = require('wemo-client');
var wemo = new Wemo();

const wemos = []

wemo.discover((err, device) => {
    // only get switches and light switches
    if (device.deviceType === Wemo.DEVICE_TYPE.LightSwitch || device.deviceType === Wemo.DEVICE_TYPE.Switch) {
        var newWemo = {
            name: device.friendlyName,
            type: device.deviceType,
            host: device.host,
            port: device.port,
            mac: device.macAddress,
            icon: device.iconList.icon.url,
            iconPath: `http://${device.host}:${device.port}/${device.iconList.icon.url}`,
            deviceInfo: device
        }
        wemos.push(newWemo)

        if (newWemo.name === 'Ryan Room WeMo') {
            toggle(newWemo.deviceInfo)
        }
    }
})

const toggle = (wemoDevice) => {
    var client = wemo.client(wemoDevice)
    console.log('toggle')
    client.getBinaryState((err, state) => {
        if (Number(state) === 0) {
            console.log('turning on')
            client.setBinaryState(1)
        } else {
            console.log('turning off')
            client.setBinaryState(0)
        }
        return
    })
}
