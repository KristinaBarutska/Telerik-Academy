/* Task description */
/*
	Write a function that finds all the prime numbers in a range
		1) it should return the prime numbers in an array
		2) it must throw an Error if any on the range params is not convertible to `Number`
		3) it must throw an Error if any of the range params is missing
*/

function solve(start, end) {
  'use strict';

  function checkIfNumberIsPrime(number) {
    if (number < 2) {
      return false;
    } else if (number !== Math.round(number)) {
      return false;
    } else {
      let isPrime = true;

      for (let i = 2, squareRoot = Math.sqrt(number); i <= squareRoot; i += 1) {
        if (number % i === 0) {
          isPrime = false;
          break;
        }
      }

      return isPrime;
    }
  }

  if (isNaN(start) || isNaN(end)) {
    throw new Error('Parameters must be convertible to number!');
  } else if (arguments.length !== 2) {
    throw new Error('Two parameters must be provided!');
  } else {
    let primeNumbers = [];

    start = Number(start);
    end = Number(end);

    for (let i = start; i <= end; i += 1) {
      if (checkIfNumberIsPrime(i)) {
        primeNumbers.push(i);
      }
    }

    return primeNumbers;
  }
}

module.exports = solve;
