/*
    Problem 2. People of age
    Write a function that checks if an array of person contains only people of age (with age 18 or greater)
    Use only array methods and no regular loops (for, while)
*/

(function () {
    var people = [
        { name: 'John', age: 17 },
        { name: 'Mellissa', age: 19 },
        { name: 'Joan', age: 30}
    ];
    var areAllWithValidAge = true;

    people.forEach(function (person) {
        if(person.age < 18){
            areAllWithValidAge = false;
        }
    });

    console.log(`All people have age greater than 18 ? ${areAllWithValidAge}`);
})();