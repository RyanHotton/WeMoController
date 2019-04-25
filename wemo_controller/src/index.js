/*
    [App] WeMo Controller
    [Author] Ryan Hotton
    [Script] index.js
*/

// get dependecies
const path = require('path')
const http = require('http')
const express = require('express')
const socketio = require('socket.io')
const soap = require('soap')

const app = express()
const server = http.createServer(app)
const io = socketio(server)

const port = process.env.PORT || 3000
const publicDirectoryPath = path.join(__dirname, '../public')

// Clear console
console.clear()

app.use(express.static(publicDirectoryPath))

// TODO: Connect to WeMo IP

server.listen(port, () => {
    console.log(`Server is up on port ${port}!`)
})

