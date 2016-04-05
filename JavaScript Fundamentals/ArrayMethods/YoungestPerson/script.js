/*
    Problem 5. Youngest person
    Write a function that finds the youngest male person in a given array of people and prints his full name
    Use only array methods and no regular loops (for, while)
    Use Array#find
*/

(function () {
    var people = [
        { name: 'Maria', age: 20, gender: 'female' },
        { name: 'Joro', age: 10, gender: 'male' },
        { name: 'Ivana', age: 30, gender: 'female' },
        { name: 'Pencho', age: 19, gender: 'male' },
        { name: 'Yaga', age: 94, gender: 'female' }
    ];
    var males = people
        .filter(p => p.gender === 'male')
        .sort(function (a, b) {
            if (a.age < b.age) {
                return -1;
            } else if (a.age > b.age) {
                return 1;
            } else {
                return 0;
            }
        });
    var youngestMale = males[0];

    console.log(`Youngest male: ${youngestMale.name} ${youngestMale.age} years old`);
})();