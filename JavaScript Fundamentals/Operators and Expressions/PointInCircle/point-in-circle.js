function solve(input) {
    let x = Number(input[0]);
    let y = Number(input[1]);
    let isInside = x * x + y * y <= 4;
    let distance = Math.sqrt((x * x) + (y * y));

    console.log(isInside ? `yes ${distance.toFixed(2)}` : `no ${distance.toFixed(2)}`);
}