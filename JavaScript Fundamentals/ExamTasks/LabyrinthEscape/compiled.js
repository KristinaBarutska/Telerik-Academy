function Solve(input) {
    'use strict';

    var N, M, R, C;
    var labyrinthDirections;
    var labyrinth;

    function getDimensionsAndStartPos() {
        var nAndM = input[0].split(' ').map(Number);
        var rAndC = input[1].split(' ').map(Number);

        N = nAndM[0];
        M = nAndM[1];
        R = rAndC[0];
        C = rAndC[1];
    }

    function getLabyrinth() {
        labyrinthDirections = [];
        labyrinth = [];

        var index = 0;
        var cellValue = 1;

        for (var i = 2, len = input.length; i < len; i += 1, index += 1) {
            var currentRow = input[i];

            labyrinthDirections[index] = [];
            labyrinth[index] = [];

            for (var j = 0, len2 = currentRow.length; j < len2; j += 1, cellValue += 1) {
                labyrinthDirections[index].push(currentRow[j]);
                labyrinth[index].push(cellValue);
            }
        }
    }

    function findExit() {
        getDimensionsAndStartPos();
        getLabyrinth();

        var row = R;
        var col = C;
        var sumOfCells = 0;
        var cellsCount = 0;
        var isOutside = false;
        var isOnVisited = false;

        while (true) {
            if (row < 0 || row >= N || col < 0 || col >= M) {
                isOutside = true;
                break;
            } else if (labyrinthDirections[row][col] === 'v') {
                isOnVisited = true;
                break;
            }

            sumOfCells += labyrinth[row][col];
            cellsCount += 1;

            if (labyrinthDirections[row][col] === 'l') {
                labyrinthDirections[row][col] = 'v';
                col -= 1;
            } else if (labyrinthDirections[row][col] === 'r') {
                labyrinthDirections[row][col] = 'v';
                col += 1;
            } else if (labyrinthDirections[row][col] === 'u') {
                labyrinthDirections[row][col] = 'v';
                row -= 1;
            } else if (labyrinthDirections[row][col] === 'd') {
                labyrinthDirections[row][col] = 'v';
                row += 1;
            }
        }

        if (isOutside) {
            console.log('out ' + sumOfCells);
        } else if (isOnVisited) {
            console.log('lost ' + cellsCount);
        }
    }

    findExit();
}