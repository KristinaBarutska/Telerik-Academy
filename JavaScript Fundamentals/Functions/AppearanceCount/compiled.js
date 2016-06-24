function solve(input) {
    input = input[0].split('\n');
    var numbers = input[1].split(' ');
    var x = input[2];
    var count = 0;

    for (var i = 0; i < numbers.length; i += 1) {
        if (numbers[i] === x) {
            count += 1;
        }
    }

    console.log(count);
}
