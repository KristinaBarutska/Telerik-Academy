/*
    Problem 3. Deep copy
    Write a function that makes a deep copy of an object.
    The function should work for both primitive and reference types.
*/

(function () {
    Object.prototype.makeDeepCopy = function (objectToCopy) {
        for (let property in objectToCopy) {
            this[property] = objectToCopy[property];
        }
    }

    let firstPerson = {
        name: 'Doggy',
        age: 5
    };
    let secondPerson = {};

    secondPerson.makeDeepCopy(firstPerson);
    console.log(secondPerson);
})();