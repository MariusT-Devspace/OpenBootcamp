class Student{
    #name;
    #subjects;

    constructor(name, subjects){
        this.#name = name;
        this.#subjects = subjects;
    }

     getPersonalData(){
        return {
            name: this.#name,
            subjects: this.#subjects
        }
    }
}

export default Student;