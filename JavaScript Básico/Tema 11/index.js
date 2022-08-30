import Student from "./Student.js";

var student = new Student("John Doe", ["Javascript", "HTML", "CSS"]);
var studentData = student.getPersonalData();

console.log(`Name: ${studentData.name}`);
console.log(`Subjects: ${studentData.subjects}`);