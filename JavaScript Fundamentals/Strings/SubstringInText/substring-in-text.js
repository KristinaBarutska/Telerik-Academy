function solve(input) {
    let target = input[0];
    let text = input[1];
    let pattern = new RegExp(target, 'ig');

    console.log(text.match(pattern).length);
}
