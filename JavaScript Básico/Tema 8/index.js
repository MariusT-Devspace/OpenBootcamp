
function noParamFunction(){
    return true;
}

async function myPromise(){
    setTimeout(() => console.log("Hi I'm a promise"), 5000);
}

function* generateEvenIndex(){
    let i = 0;
    while(true){
        
        if(i == 50){
        return;
        }
        yield i;
        i += 2;
    }
    
}

myPromise();

const indexGenerator = generateEvenIndex();

for(let i of indexGenerator){
    console.log("Generated index: " + i);
}
/*

console.log("Generated index: " + indexGenerator.next().value);
console.log("Generated index: " + indexGenerator.next().value);
console.log("Generated index: " + indexGenerator.next().value);
console.log("Generated index: " + indexGenerator.next().value);
console.log("Generated index: " + indexGenerator.next().value);
*/