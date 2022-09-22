const heightInCm = 172;
const heightInM = 1.72;
const weightInKg = 65.3;
const heightInMCeil = Math.ceil(heightInM);
const weightInKgFloor = Math.floor(weightInKg);
const isEqualMaxValueToMaxPlusOne = Number.MAX_VALUE == Number.MAX_VALUE+1;

console.log("Height in cm: " + heightInCm);
console.log("Height in m: " + heightInM);
console.log("Weight in kg: " + weightInKg);
console.log("Height in m rounded up: " + heightInMCeil);
console.log("Weight in kg rounded down: " + weightInKgFloor);
console.log("Is the maximum value in javascript equal to the maximum value + 1?: " + isEqualMaxValueToMaxPlusOne);
console.log(Number.MAX_VALUE)