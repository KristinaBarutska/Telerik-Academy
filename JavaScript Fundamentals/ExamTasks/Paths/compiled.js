function Solve(input) {
    'use strict';
    
    var dimensions = input[0].split(' ').map(Number);
    var rows = dimensions[0];
    var cols = dimensions[1];
    var numberMatrix = [];
    var movesMatrix = [];

    function fillNumberMatrix() {
        var startNumber = 1;

        for (var i = 0; i < rows; i += 1) {
            var number = startNumber;
            numberMatrix.push([]);

            for (var j = 0; j < cols; j += 1, number += 1) {
                numberMatrix[i].push(number);
            }

            startNumber *= 2;
        }
    }

    function fillMovesMatrix() {
        for (var i = 1, len = input.length; i < len; i += 1) {
            var currentRow = input[i].split(' ');
            movesMatrix.push([]);

            for (var j = 0, _len = currentRow.length; j < _len; j += 1) {
                movesMatrix[i - 1].push(currentRow[j]);
            }
        }
    }

    function getNextRowAndCol(currentRow, currentCol, cell) {
        switch (cell) {
            case 'dr':
                return [currentRow + 1, currentCol + 1];
            case 'ur':
                return [currentRow - 1, currentCol + 1];
            case 'dl':
                return [currentRow + 1, currentCol - 1];
            case 'ul':
                return [currentRow - 1, currentCol - 1];

        }
    }

    function isOutside(row, col) {
        if (row < 0 || row >= rows || col < 0 || col >= cols) {
            return true;
        } else {
            return false;
        }
    }

    function performMoves() {
        var currentRow = 0;
        var currentCol = 0;
        var pathSum = 0;

        fillMovesMatrix();
        fillNumberMatrix();

        while (true) {
            var currentCell = movesMatrix[currentRow][currentCol];
            var nextRowAndCol = getNextRowAndCol(currentRow, currentCol, currentCell);
            var nextRow = nextRowAndCol[0];
            var nextCol = nextRowAndCol[1];

            movesMatrix[currentRow][currentCol] = 'v';
            pathSum += numberMatrix[currentRow][currentCol];

            if (isOutside(nextRow, nextCol)) {
                console.log('successed with ' + pathSum);
                return;
            } else if (movesMatrix[nextRow][nextCol] === 'v') {
                console.log('failed at (' + nextRow + ', ' + nextCol + ')');
                return;
            } else {
                currentRow = nextRow;
                currentCol = nextCol;
            }
        }
    }

    performMoves();
}
