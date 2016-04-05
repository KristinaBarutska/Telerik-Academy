/*
    Problem 1. Make person
    Write a function for creating persons.
    Each person must have firstname, lastname, age and gender (true is female, false is male)
    Generate an array with ten person with different names, ages and genders
*/

(function () {
    function makePerson(firstName, lastname, age, gender) {
        var person = {
            firstName: firstName,
            lastname: lastname,
            age: age,
            gender: gender
        };

        return person;
    }

    function generateName() {
        var name = '',
            letters = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz';

        for (var i = 0; i < 5; i += 1) {
            name += letters.charAt(Math.floor(Math.random() * letters.length));
        }

        return name;
    }

    let people = [];

    for (let i = 20; i < 50; i += 3) {
        let genders = ['Male', 'Female'];
        let firstName = generateName();
        let lastName = generateName();
        let age = i;
        let gender = genders[i % 2];
        let person = makePerson(firstName, lastName, age, gender);

        people.push(person);
    }

    people.forEach(p => console.log(`${p.firstName} ${p.lastname} ${p.age} ${p.gender}`));
})();