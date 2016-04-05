/*
    Problem 4. Average age of females
    Write a function that calculates the average age of all females, extracted from an array of persons
    Use Array#filter
    Use only array methods and no regular loops (for, while)
*/

(function () {
    var people = [
        { name: 'Maria', age: 20, gender: 'female' },
        { name: 'Joro', gender: 'male' },
        { name: 'Ivana', age: 30, gender: 'female' },
        { name: 'Pencho', gender: 'male' },
        { name: 'Yaga', age: 94, gender: 'female' }
    ];

    var sumOfAges = 0,
        females = people.filter(p => p.gender === 'female');

    females.forEach(p => sumOfAges += p.age);

    let averageAge = sumOfAges / females.length;

    console.log(`Average age of all females: ${averageAge}`);
})();