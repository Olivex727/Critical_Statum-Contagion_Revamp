//Initialise all node modules required
var express = require('express')
const { spawn } = require('child_process');
var app = express()
const port = 3000
var fs = require("fs");

//Get the path of the server and host a static
var path = require('path');
const dir = path.join(__dirname, 'public');
app.use(express.static(dir));

console.log("Static directory setup at: " + dir);

//Send the html file
app.get('/', function (req, res) {
    res.sendfile("index.html");
});

/* What needs to Happen:
 * 
 * 1. server.js is called from npm start
 * 2. The server will read script.py line by line, all of the objects nee
 * 
 * https://programminghistorian.org/en/lessons/output-data-as-html-file
 * 
 * Somehow, the python console output needs to be transferred to HTML. This needs to happen line by line
 */
//

app.get('/py', (req, res) => {

    var dataToSend;
    // spawn new child process to call the python script
    const python = spawn('python', ['script.py']);
    // collect data from script
    python.stdout.on('data', function (data) {
        console.log('Pipe data from python script ...');
        dataToSend = data.toString();
    });
    // in close event we are sure that stream from child process is closed
    python.on('close', (code) => {
        console.log(`child process close all stdio with code ${code}`);
        // send data to browser
        res.send(dataToSend)
    });

})
app.listen(port, () => console.log(`Example app listening on port 
${port}`))