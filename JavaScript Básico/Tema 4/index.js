
const firstName = "Marius";
const lastName = "Tichieru";
const student = firstName + " " + lastName;
const studentUpper = student.toUpperCase();
const studentLower = student.toLowerCase();
const studentStringLength = student.length;
const firstNameFirstLetter = firstName.charAt(0);
const lastNameLastLetter = lastName.charAt(lastName.length-1);
const studentNoSpace = student.replace(" ", "");
const isFirstNameInStudent = student.includes(firstName);

console.log("First Name: " + firstName);
console.log("Last Name: " + lastName);
console.log("Full name: " + student);
console.log("Full name in upper case: " + studentUpper);
console.log("Full name in lower case: " + studentLower);
console.log("Full name string length: " + studentStringLength);
console.log("First letter of first name: " + firstNameFirstLetter);
console.log("Last letter of last name: " + lastNameLastLetter);
console.log("Full name with no space: " + studentNoSpace);
console.log("First name is in student string: " + isFirstNameInStudent);