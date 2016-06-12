function Solve(input) {
    'use strict';

    var variables = [];

    function getLeftSide(leftSideUnformatted) {
        var leftSide = leftSideUnformatted.split(' ').filter(function (s) {
            return s !== '';
        });

        return leftSide;
    }

    function getRightSide(rightSideUnformatted) {
        try {
            var pattern = /[\s,\]]/g;
            var list = rightSideUnformatted.split(pattern).filter(function (s) {
                return s !== '';
            });

            return list;
        } catch (e) {
            return null;
        }
    }

    function getNumbersFromList(list) {
        var newList = [];
        var listLength = list.length;

        for (var i = 0; i < listLength; i += 1) {
            var currentElement = list[i];

            if (isNaN(currentElement)) {
                var variableValue = variables[currentElement];

                if (Array.isArray(variableValue)) {
                    variableValue.forEach(function (s) {
                        newList.push(Number(s));
                    });
                } else {
                    newList.push(Number(variableValue));
                }
            } else {
                newList.push(Number(currentElement));
            }
        }

        return newList;
    }

    function getSum(list) {
        var sum = 0;

        list.forEach(function (s) {
            return sum += s;
        });
        return sum;
    }

    function performOperation(operation, list) {
        switch (operation) {
            case 'min':
                return Math.min.apply(null, list);
            case 'max':
                return Math.max.apply(null, list);
            case 'sum':
                return getSum(list);
            case 'avg':
                return getSum(list) / list.length;
        }
    }

    function defineVariable(leftSide, rightSide) {
        var listWithNumbers = getNumbersFromList(rightSide);

        if (leftSide.length === 2) {
            var variableName = leftSide[1];

            variables[variableName] = listWithNumbers;
        } else {
            var _variableName = leftSide[1];
            var operation = leftSide[2];
            var operationResult = performOperation(operation, listWithNumbers);

            variables[_variableName] = operationResult;
        }
    }

    function getValue(leftSide) {
        var value = '';
        var leftSideLength = leftSide[0].length;
        var unformatted = leftSide[0];

        for (var i = 0; i < leftSideLength; i += 1) {
            if (unformatted[i] != '' && unformatted[i] != ']') {
                value += unformatted[i];
            }
        }

        if (isNaN(value)) {
            return variables[value];
        } else {
            return value;
        }
    }

    function executeCommands() {
        var inputLength = input.length;

        for (var i = 0; i < inputLength; i += 1) {
            var currentCommandTokens = input[i].split('[').filter(function (s) {
                return s !== '';
            });
            var leftSide = getLeftSide(currentCommandTokens[0]);
            var rightSide = getRightSide(currentCommandTokens[1]);

            if (leftSide[0] === 'def') {
                defineVariable(leftSide, rightSide);
            } else if (leftSide[0] === 'min' || leftSide[0] === 'max' || leftSide[0] === 'sum' || leftSide[0] === 'avg') {
                var listWithNumbers = getNumbersFromList(rightSide);
                var operation = leftSide[0];
                var operationResult = performOperation(operation, listWithNumbers);

                console.log(operationResult);
            } else {
                var result = getValue(leftSide);
                console.log(result);
            }
        }
    }

    executeCommands();
}