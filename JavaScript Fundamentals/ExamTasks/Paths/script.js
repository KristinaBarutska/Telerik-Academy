function Solve(input) {
    'use strict';

    let dimensions = input[0].split(' ').map(Number);
    let rows = dimensions[0];
    let cols = dimensions[1];
    let numberMatrix = [];
    let movesMatrix = [];

    function fillNumberMatrix() {
        let startNumber = 1;

        for (let i = 0; i < rows; i += 1) {
            let number = startNumber;
            numberMatrix.push([]);

            for (let j = 0; j < cols; j += 1, number += 1) {
                numberMatrix[i].push(number);
            }

            startNumber *= 2;
        }
    }

    function fillMovesMatrix() {
        for (let i = 1, len = input.length; i < len; i += 1) {
            let currentRow = input[i].split(' ');
            movesMatrix.push([]);

            for (let j = 0, len = currentRow.length; j < len; j += 1) {
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
        let currentRow = 0;
        let currentCol = 0;
        let pathSum = 0;

        fillMovesMatrix();
        fillNumberMatrix();

        while (true) {
            let currentCell = movesMatrix[currentRow][currentCol];
            let nextRowAndCol = getNextRowAndCol(currentRow, currentCol, currentCell);
            let nextRow = nextRowAndCol[0];
            let nextCol = nextRowAndCol[1];

            movesMatrix[currentRow][currentCol] = 'v';
            pathSum += numberMatrix[currentRow][currentCol];

            if (isOutside(nextRow, nextCol)) {
                console.log(`successed with ${pathSum}`);
                return;
            } else if(movesMatrix[nextRow][nextCol] === 'v'){
                console.log(`failed at (${nextRow}, ${nextCol})`);
                return;
            } else {
                currentRow = nextRow;
                currentCol = nextCol;
            }
        }
    }
    
    performMoves();
}