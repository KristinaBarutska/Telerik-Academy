/*
    Problem 4. Has property
    Write a function that checks if a given object contains a given property.
    var obj  = …;
    var hasProp = hasProperty(obj, 'length');
*/

(function (undefined) {
    function hasProperty(object, propertyToCheckFor) {
        if (object[propertyToCheckFor] !== undefined) {
            return true;
        }

        return false;
    }

    let person = {
        name: 'Person'
    };
    let hasProp = hasProperty(person, 'age');

    console.log(`person has property age ? ${hasProp}`);
})();