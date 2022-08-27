
const today = new Date();
const dateOfBirth = new Date(1990, 05, 16);
const isTodayLaterThanDateOfBirth = today > dateOfBirth;
const dayOfBirth = dateOfBirth.getDate();
const monthOfMonth = dateOfBirth.getMonth()+1;
const yearOfBirth = dateOfBirth.getFullYear();

console.log("Today: " + today);
console.log("Date of birth: " + dateOfBirth);
console.log("Is today later than date of birth: " + isTodayLaterThanDateOfBirth);
console.log("Day of birth: " + dayOfBirth);
console.log("Month of birth: " + monthOfMonth);
console.log("Year of birth: " + yearOfBirth);
