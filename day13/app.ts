import { readFileSync } from 'fs';

const lines = readFileSync('./input', 'utf-8').split("\n");

for (let i = 1; i < lines.length; i = i + 3) {
    let line = lines[i]
    // console.log(line);
    let a1 = eval(line);
    let a2 = eval(lines[i + 1]);

    for (var j = 0; j < a1.length; j++) {
        console.log(a1[j]+' '+a2[j]);
    }

    // console.log(a1[0]);
}

