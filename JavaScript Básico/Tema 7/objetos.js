
const personalData = {
    firstName: "Bob",
    lastName: "Pearson",
    age: 33,
    height: 1.72,
    isDeveloper: true
}

const friends = [
    {
        firstName: "Wayne",
        lastName: "Rocha",
        age: 27,
        height: 1.78,
        isDeveloper: false
    }, 
    {
        firstName: "Stephen",
        lastName: "Huston",
        age: 29,
        height: 1.68,
        isDeveloper: false
    }
];

const age = personalData.age;
const friendGroup = [personalData, ...friends];

const friendGroupSortedByAge = friendGroup.sort((a, b) => a.age - b.age);

console.log("Friend group sorted by age: ", friendGroupSortedByAge);

