function solve(input) {
    input = input[0].split('\n');
    let count = 0;
    let numbers = input[1].split(' ').map(Number);

    for (let i = 1; i < numbers.length - 1; i += 1) {
        if (numbers[i] > numbers[i - 1] && numbers[i] > numbers[i + 1]) {
            count += 1;
        }
    }

    console.log(count);
}