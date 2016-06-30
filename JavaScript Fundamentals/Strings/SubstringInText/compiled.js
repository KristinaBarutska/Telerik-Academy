function solve(input) {
    var target = input[0];
    var text = input[1];
    var pattern = new RegExp(target, 'ig');

    console.log(text.match(pattern).length);
}
