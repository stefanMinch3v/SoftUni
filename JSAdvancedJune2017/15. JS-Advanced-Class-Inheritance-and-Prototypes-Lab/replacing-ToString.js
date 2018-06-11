function solve() {
    class Person {
        constructor(name, email){
            this.name = name;
            this.email = email;
        }

        toString() {
            let className = this.constructor.name;
            let props = Object.getOwnPropertyNames(this);
            return `${className} (${props.map(p => `${p}: ${this[p]}`).join(', ')})`;
        }
    }

    class Teacher extends Person {
        constructor(name, email, subject){
            super(name, email);
            this.subject = subject;
        }
    }

    class Student extends Person {
        constructor(name, email, course){
            super(name, email);
            this.course = course;
        }
    }

    return {
        Person,
        Teacher,
        Student
    }
}

let Student = solve().Student;
let Teacher = solve().Teacher;
let Person =  solve().Person;

Student = new Student('ivan', 'ivan@abv.bg', 'c#');
console.log(Student.toString());
Teacher = new Teacher('gosho', 'gg@abv.bg', 'php');
console.log(Teacher.toString());
Person = new Person('personn', 'pp@abv.bg');
console.log(Person.toString());