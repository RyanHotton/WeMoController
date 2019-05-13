/*
    [App] WeMo Controller
    [Author] Ryan Hotton
    [Script] src/index.js
*/

// get dependecies
const path = require('path')
const url = require('url')
const { app, BrowserWindow, ipcMain } = require('electron')

// get defaults
const { getDefaultWeMoIP } = require('./src/defaults/wemo_config')

// TODO: Connect to WeMo IP
var wemo_ip = getDefaultWeMoIP()
console.log(`The WeMo selected has an IP of ${wemo_ip}`)

// Reference: https://electronjs.org/docs/tutorial/first-app
let win

const createWindow = () => {
    // Create the browser window.
    win = new BrowserWindow({ width: 350, height: 500, resizable: false })

    // and load the index.html of the app.
    win.loadFile(path.join(__dirname, './html/toggle.html'))

    // Emitted when the window is closed.
    win.on('closed', () => {
        win = null
    })
}

// This method will be called when Electron has finished
// initialization and is ready to create browser windows.
// Some APIs can only be used after this event occurs.
app.on('ready', createWindow)

// Quit when all windows are closed.
app.on('window-all-closed', () => {
    // if (process.platform !== 'darwin') {
    //     app.quit()
    // }
    app.quit()
})

app.on('activate', () => {
    // On macOS it's common to re-create a window in the app when the
    // dock icon is clicked and there are no other windows open.
    if (win === null) {
        createWindow()
    }
})
