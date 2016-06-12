function Solve(input) {
    var numbers = input.map(Number);
    var n = numbers[0];
    var answer = numbers[1];
    var currentSum = 0;
    var i, j;

    for (i = 1; i < numbers.length; i += 1) {
        currentSum = numbers[i];
        answer = currentSum > answer ? currentSum : answer;

        for (j = i + 1; j < numbers.length; j += 1) {
            currentSum += numbers[j];
            answer = currentSum > answer ? currentSum : answer;
        }
    }

    return answer;
}