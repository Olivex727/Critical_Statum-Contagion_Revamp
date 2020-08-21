#! /usr/bin/env node

console.log('Hello CLI', process.argv);

const readline = require('readline');

const rl = readline.createInterface({
    input: process.stdin,
    output: process.stdout,
});
console.clear();

const callback = (input) => {
    console.log(input);
}

rl.question("Lol?  ", callback);