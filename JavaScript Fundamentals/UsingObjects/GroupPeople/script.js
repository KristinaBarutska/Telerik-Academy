/*
    Problem 6.
    Write a function that groups an array of people by age, first or last name.
    The function must return an associative array, with keys - the groups, and values - arrays with people in this groups
    Use function overloading (i.e. just one function)
 */

(function (undefined) {
    function Person(firstName, lastName, age) {
        this.firstName = firstName;
        this.lastName = lastName;
        this.age = age;
    }

    function groupPeople(arrayOfPeople, propertyToGroupBy) {
        arrayOfPeople.sort(function (a, b) {
            if (a[propertyToGroupBy] < b[propertyToGroupBy]) {
                return -1;
            } else if (a[propertyToGroupBy] > b[propertyToGroupBy]) {
                return 1;
            } else {
                return 0;
            }
        });

        return arrayOfPeople;
    }

    let people = [
        new Person('Ivan', 'Ivanov', 20),
        new Person('Georgi', 'Georgiev', 30),
        new Person('Evgeni', 'Evgeniev', 25)
    ];
    let groupedByFirstName = groupPeople(people, 'firstName');
    let groupedByLastName = groupPeople(people, 'lastName');
    let groupedByAge = groupPeople(people, 'age');

    console.log('By first name: ');
    groupedByFirstName.forEach(p => console.log(`${p.firstName} ${p.lastName} ${p.age}`));
    console.log('-------------------------------------------------');
    console.log('By last name: ' + groupedByLastName);
    groupedByLastName.forEach(p => console.log(`${p.firstName} ${p.lastName} ${p.age}`));
    console.log('-------------------------------------------------');
    console.log('By age: ' + groupedByAge);
    groupedByAge.forEach(p => console.log(`${p.firstName} ${p.lastName} ${p.age}`));
})();