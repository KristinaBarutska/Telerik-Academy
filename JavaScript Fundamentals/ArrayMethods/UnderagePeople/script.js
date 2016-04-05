/*
    Problem 3. Underage people
    Write a function that prints all underaged persons of an array of person
    Use Array#filter and Array#forEach
    Use only array methods and no regular loops (for, while)
*/

(function () {
    var people = [
        { name: 'John', age: 17 },
        { name: 'Mellissa', age: 19 },
        { name: 'Joan', age: 30 },
        { name: 'Maria', age: 15 }
    ];
    
    people
        .filter(p => p.age < 18)
        .forEach(p => console.log(`${p.name} ${p.age} years old.`));
})();