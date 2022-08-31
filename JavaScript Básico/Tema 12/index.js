function getFibonacci(max){
    const fibSequence = [1, 1];
    for(let i = 0; i < max - 2; i++){
        fibSequence.push(fibSequence[i] + fibSequence[i+1]);
    }
    return fibSequence;
}

const max = 6;
const fibonacci = getFibonacci(max);

console.log(`First ${max} numbers of the fibonacci sequence:`);
console.log(...fibonacci);