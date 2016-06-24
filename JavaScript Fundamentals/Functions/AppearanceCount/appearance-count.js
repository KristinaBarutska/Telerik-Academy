function solve(input) {
    input = input[0].split('\n');
    let numbers = input[1].split(' ');
    let x = input[2];
    let count = 0;

    for (let i = 0; i < numbers.length; i += 1) {
        if (numbers[i] === x) {
            count += 1;
        }
    }

    console.log(count);
}