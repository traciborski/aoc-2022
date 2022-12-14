import { readFileSync } from 'fs';

const lines = readFileSync('./input', 'utf-8').split("\n");
let sum = 0;
let index = 1;
for (let i = 0; i < lines.length; i = i + 3) {
    let a1 = eval(lines[i]);
    let a2 = eval(lines[i + 1]);
    if (inOrder(a1, a2)) {
        sum += index;
    }
    index++;
}
console.log(sum);

function inOrder(a1: any, a2: any): boolean {
    for (var i = 0; i < a1.length; i++) {
        var x = a1[i];
        var y = a2[i];
        if (Number.isFinite(x) && Number.isFinite(y)) {
            if (x < y) return true;
            if (x > y) return false;
        } else if (Array.isArray(x) && Array.isArray(y)) {
            if (!inOrder(x, y)) return false;
        } else if (Array.isArray(x) && Number.isFinite(y)) {
            if (!inOrder(x, [y])) return false;
        } else if (Array.isArray(y) && Number.isFinite(x)) {
            if (!inOrder([x], y)) return false;
        } else if (x === undefined) { 
            return true;
        } else if (y === undefined) {
            return true;
        } else {
            return true;
        }
    }
    return true;
}