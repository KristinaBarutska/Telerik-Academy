/*
    Problem 6. Group people
    Write a function that groups an array of persons by first letter of first name and returns the groups as a JavaScript Object
    Use Array#reduce
    Use only array methods and no regular loops (for, while)
*/

(function () {
    function groupPeople(people) {
        var groupedPeople = people.sort(function (a, b) {
            if (a.name[0] < b.name[0]) {
                return -1;
            } else if (a.name[0] > b.name[0]) {
                return 1;
            } else {
                return 0;
            }
        });
        var result = {
            a: groupedPeople
        };

        return result;
    }

    let people = [
       { name: 'Maria', age: 20, gender: 'female' },
       { name: 'Joro', age: 10, gender: 'male' },
       { name: 'Ivana', age: 30, gender: 'female' },
       { name: 'Pencho', age: 19, gender: 'male' },
       { name: 'Yaga', age: 94, gender: 'female' }
    ];
    let groupedPeople = groupPeople(people);

    console.log(groupedPeople);
})();