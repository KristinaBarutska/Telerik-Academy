function solve(input) {
    let number = Number(input[0]);

    function getDigitsFromZeroToNine(number) {
        switch (number) {
            case 0:
                return 'zero';
            case 1:
                return 'one';
            case 2:
                return 'two';
            case 3:
                return 'three';
            case 4:
                return 'four';
            case 5:
                return 'five';
            case 6:
                return 'six';
            case 7:
                return 'seven';
            case 8:
                return 'eight';
            case 9:
                return 'nine';
        }
    }

    function getNumbersFromTenToNineteen(number) {
        switch (number) {
            case 10:
                return 'ten';
            case 11:
                return 'eleven';
            case 12:
                return 'twelve';
            case 13:
                return 'thirteen';
            case 14:
                return 'fourteen';
            case 15:
                return 'fifteen';
            case 16:
                return 'sixteen';
            case 17:
                return 'seventeen';
            case 18:
                return 'eighteen';
            case 19:
                return 'nineteen';
        }
    }

    function getNumbersFromTwentyToNinety(number) {
        switch (number) {
            case 2:
                return 'twenty';
            case 3:
                return 'thirty';
            case 4:
                return 'forty';
            case 5:
                return 'fifty';
            case 6:
                return 'sixty';
            case 7:
                return 'seventy';
            case 8:
                return 'eighty';
            case 9:
                return 'ninety';
        }
    }

    function getNumberAsWords() {
        let result = '';

        if (number >= 100) {
            result += getDigitsFromZeroToNine(Math.floor(number / 100));
            result += ' hundred and ';
            number %= 100;
        }
        if (number > 19) {
            result += getNumbersFromTwentyToNinety(Math.floor(number / 10));
            result += ' ';
            number %= 10;
        }
        else if (number > 9) {
            result += getNumbersFromTenToNineteen(number);
            result += ' ';
            number = 0
        }
        if (number > 0) {
            result += getDigitsFromZeroToNine(number);
            result += ' ';
            number = 0;
        }
        if (number === 0) {
            if (result.length === 0) {
                result += 'zero';
            }
        }

        return result;
    }

    function capitalizeFirstLetter(string) {
        return string.charAt(0).toUpperCase() + string.slice(1);
    }

    let result = capitalizeFirstLetter(getNumberAsWords(number));

    console.log(result)
}