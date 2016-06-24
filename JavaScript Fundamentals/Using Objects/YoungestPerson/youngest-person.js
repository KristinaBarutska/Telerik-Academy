function solve(input) {
    'use strict';

    let person = (function () {
        let person = Object.create({});

        Object.defineProperty(person, 'init', {
            value: function (firstName, lastName, age) {
                this.firstName = firstName;
                this.lastName = lastName;
                this.age = age;
                return this;
            }
        });

        Object.defineProperty(person, 'firstName', {
            get: function () {
                return this._firstName;
            },
            set: function (value) {
                this._firstName = value;
            }
        });

        Object.defineProperty(person, 'lastName', {
            get: function () {
                return this._lastName;
            },
            set: function (value) {
                this._lastName = value;
            }
        });

        Object.defineProperty(person, 'age', {
            get: function () {
                return this._age;
            },
            set: function (value) {
                this._age = value;
            }
        });

        return person;
    } ());

    function getPeopleAsArray() {
        let people = [];

        for (let i = 0; i < input.length - 3; i += 3) {
            people.push(Object.create(person).init(input[i], input[i + 1], Number(input[i + 2])));
        }

        return people;
    }

    let people = getPeopleAsArray();

    people.sort((a, b) => a.age - b.age);

    let youngestPerson = people[0];
    console.log(`${youngestPerson.firstName} ${youngestPerson.lastName}`);
}

solve([
    'Penka', 'Hristova', '61',
    'System', 'Failiure', '88',
    'Bat', 'Man', '16',
    'Malko', 'Kote', '72']);