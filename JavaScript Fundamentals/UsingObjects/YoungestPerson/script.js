/*
    Problem 5. Youngest person
    Write a function that finds the youngest person in a given array of people and prints his/hers full name
    Each person has properties firstname, lastname and age.
*/

(function () {
    function Person(name, age) {
        this.name = name;
        this.age = age;
    }

    let people = [
        new Person("Gosho", 10),
        new Person("Vuna", 20),
        new Person("Bay Vute", 5)
    ];

    function findYoungestPerson(arrayOfPeople) {
        var youngestPerson = arrayOfPeople[0],
            len = arrayOfPeople.length;

        for (let i = 1; i < len; i += 1) {
            if (arrayOfPeople[i].age < youngestPerson.age) {
                youngestPerson = arrayOfPeople[i];
            }
        }

        return youngestPerson;
    }

    let youngestPerson = findYoungestPerson(people);

    console.log(`Youngest person: ${youngestPerson.name} ${youngestPerson.age} years old.`);
})();