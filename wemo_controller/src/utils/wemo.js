// /*
//     [App] WeMo Controller
//     [Author] Ryan Hotton
//     [Script] src/utils/wemo.js
// */

// /*
//     C# Code:
//     private const string COMMAND_OFF = @"<?xml version=""1.0"" encoding=""utf-8""?><s:Envelope xmlns:s=""http://schemas.xmlsoap.org/soap/envelope/"" s:encodingStyle=""http://schemas.xmlsoap.org/soap/encoding/""><s:Body><u:SetBinaryState xmlns:u=""urn:Belkin:service:basicevent:1""><BinaryState>0</BinaryState></u:SetBinaryState></s:Body></s:Envelope>";
//     private const string COMMAND_ON = @"<?xml version=""1.0"" encoding=""utf-8""?><s:Envelope xmlns:s=""http://schemas.xmlsoap.org/soap/envelope/"" s:encodingStyle=""http://schemas.xmlsoap.org/soap/encoding/""><s:Body><u:SetBinaryState xmlns:u=""urn:Belkin:service:basicevent:1""><BinaryState>1</BinaryState></u:SetBinaryState></s:Body></s:Envelope>";
//     private const string COMMAND_GET = @"<?xml version=""1.0"" encoding=""utf-8""?><s:Envelope xmlns:s=""http://schemas.xmlsoap.org/soap/envelope/"" s:encodingStyle=""http://schemas.xmlsoap.org/soap/encoding/""><s:Body><u:GetBinaryState xmlns:u=""urn:Belkin:service:basicevent:1""></u:GetBinaryState></s:Body></s:Envelope>";
// */

// const axios = require('axios')

// // get soap dependency (npm)
// const soap = require('soap')
// const xmlJS = require('xml-js')

// const { getDefaultWeMoIP } = require('../defaults/wemo_config')

// // list of wemos
// const wemos = []

// const listWeMos = () => {
//     // TODO
//     return wemos
// }

// const getWeMo = (wemo_ip) => {
//     // TODO
//     // console.log(`Getting information about WeMo ${wemo_ip}`)
//     var wemo_url = `http://${wemo_ip}:49153/setup.xml`

//     return new Promise((resolve, reject) => {
//         axios.get(wemo_url).then((response) => {
//             if (!response.data) {
//                 throw new Error('Unable to find that address.')
//             } else {
//                 var wemo_res = JSON.parse(xmlJS.xml2json(response.data, { compact: true, spaces: 0 }))
//                 var wemo_obj = {
//                     type: wemo_res.root.device.deviceType._text,
//                     name: wemo_res.root.device.friendlyName._text,
//                     model: {
//                         name: wemo_res.root.device.modelName._text,
//                         description: wemo_res.root.device.modelDescription._text,
//                         number: Number(wemo_res.root.device.modelNumber._text)
//                     },
//                     mac: wemo_res.root.device.macAddress._text,
//                     firmware: wemo_res.root.device.firmwareVersion._text,
//                     status: wemo_res.root.device.binaryState._text,
//                     icon: wemo_res.root.device.iconList.icon.url._text,
//                     iconPath: `http://${wemo_ip}:49153/${wemo_res.root.device.iconList.icon.url._text}`
//                 }
//                 resolve(wemo_obj)
//             }
//         }).catch((e) => {
//             reject({})
//         })
//     })

// }

// const getStatus = (wemo_ip) => {
//     // TODO
//     return new Promise((response, reject) => {
//         getWeMo(wemo_ip).then((wemo_obj) => {
//             response(Number(wemo_obj.status))
//         }, (err) => {
//             reject({})
//         })
//     })
//     // var url = `http://${wemo_ip}:49153/upnp/control/basicevent1`

    
//     // var args = {};
//     // soap.createClientAsync(url).then((client) => {
//     //     client.addHttpHeader('SOAPAction', "\"urn:Belkin:service:basicevent:1#GetBinaryState\"")
//     //     return client.MyFunctionAsync(args)
//     // }).then((result) => {
//     //     console.log(result)
//     // })

// }

// const turnOn = (wemo_ip) => {
//     // TODO
//     console.log(`Turning WeMo ${wemo_ip} ON`)
// }

// const turnOff = (wemo_ip) => {
//     // TODO
//     console.log(`Turning WeMo ${wemo_ip} OFF`)
// }

// const toggle = (wemo_ip) => {
//     // TODO
//     // 0: off, 1: on
//     getStatus(wemo_ip).then((status) => {
//         console.log(typeof status, status)
//         if (status === 0) {
//             turnOn(wemo_ip)
//         } else {
//             turnOff(wemo_ip)
//         }
//     }, (err) => {
//         console.log('Error: Could not toggle', err)
//     })
// }

// const wemo_ip = getDefaultWeMoIP()

// // getStatus(wemo_ip)