/* Task Description */
/*
	Write a function that sums an array of numbers:
		numbers must be always of type Number
		returns `null` if the array is empty
		throws Error if the parameter is not passed (undefined)
		throws if any of the elements is not convertible to Number
*/

function sum(numbers) {
  'use strict';

  if (numbers.length === 0) {
    return null;
  } else if (arguments.length === 0) {
    throw new Error('Error must be passed!');
  } else {
    let sum = 0;

    for (let i = 0, len = numbers.length; i < len; i += 1) {
      if (isNaN(numbers[i])) {
        throw new Error(`${numbers[i]} is not convertible to number!`);
      }

      sum += Number(numbers[i]);
    }

    return sum;
  }
}

module.exports = sum;
