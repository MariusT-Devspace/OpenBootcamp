
let factorial = 1;
let count = 1;
while(true){
    if(count > 10){
        break;
    }
    factorial *= count;
    count++;
}

console.log("El factorial de 10 es: " + factorial);