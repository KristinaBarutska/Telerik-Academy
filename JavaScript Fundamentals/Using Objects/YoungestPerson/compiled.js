'use strict';

function solve(input) {
    'use strict';

    var person = function () {
        var person = Object.create({});

        Object.defineProperty(person, 'init', {
            value: function value(firstName, lastName, age) {
                this.firstName = firstName;
                this.lastName = lastName;
                this.age = age;
                return this;
            }
        });

        Object.defineProperty(person, 'firstName', {
            get: function get() {
                return this._firstName;
            },
            set: function set(value) {
                this._firstName = value;
            }
        });

        Object.defineProperty(person, 'lastName', {
            get: function get() {
                return this._lastName;
            },
            set: function set(value) {
                this._lastName = value;
            }
        });

        Object.defineProperty(person, 'age', {
            get: function get() {
                return this._age;
            },
            set: function set(value) {
                this._age = value;
            }
        });

        return person;
    }();

    function getPeopleAsArray() {
        var people = [];

        for (var i = 0; i < input.length - 3; i += 3) {
            people.push(Object.create(person).init(input[i], input[i + 1], Number(input[i + 2])));
        }

        return people;
    }

    var people = getPeopleAsArray();

    people.sort(function (a, b) {
        return a.age - b.age;
    });

    var youngestPerson = people[0];
    console.log(youngestPerson.firstName + ' ' + youngestPerson.lastName);
}

solve(['Penka', 'Hristova', '61', 'System', 'Failiure', '88', 'Bat', 'Man', '16', 'Malko', 'Kote', '72']);
