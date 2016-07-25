/// <reference path="../typings/globals/jquery/index.d.ts" />

function solve() {
    $.fn.datepicker = function (dateObject) {
        var MONTH_NAMES = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];
        var WEEK_DAY_NAMES = ['Su', 'Mo', 'Tu', 'We', 'Th', 'Fr', 'Sa'];

        Date.prototype.getMonthName = function () {
            return MONTH_NAMES[this.getMonth()];
        };

        Date.prototype.getDayName = function () {
            return WEEK_DAY_NAMES[this.getDay()];
        };

        var $root = this;
        var $wrapper = $('<div />').addClass('datepicker-wrapper');
        var date = dateObject || new Date();
        var currentDate = new Date();
        var matrix = [];
        var rows = 7;
        var cols = 7;
        var calendarCells = 42;

        $root.wrap($wrapper);
        $root.addClass('datepicker');
        $root = $('.datepicker-wrapper');

        var $picker = $('<div />').addClass('picker');
        var $header = $('<div />').addClass('controls');

        function buildHeader(date) {
            $('<button />').text('<').addClass('btn previous-month').appendTo($header);
            $('<div />')
                .addClass('current-month')
                .text(MONTH_NAMES[date.getMonth()] + ' ' + date.getFullYear())
                .appendTo($header);
            $('<button />').text('>').addClass('btn next-month').appendTo($header);
            $header.appendTo($picker);
        }

        function fillCalendarMatrix(date) {
            for (i = 0; i < 6; i += 1) {
                matrix.push([]);
            }

            var currentMonthFirstDay = new Date(date.getFullYear(), date.getMonth(), 1);
            var prevMonthLastDay = new Date(date.getFullYear(), date.getMonth(), 0);
            var nextMonthFirstDay = new Date(date.getFullYear(), date.getMonth() + 1, 1);
            var currMonthDays = new Date(date.getFullYear(), date.getMonth() + 1, 0).getDate();
            var prevMonthDays = currentMonthFirstDay.getDay();
            var nextMonthDays = calendarCells - (currMonthDays + prevMonthDays);
            var row = 0;

            for (i = 1; i <= prevMonthDays; i += 1) {
                matrix[row].push(((prevMonthLastDay.getDate() - prevMonthDays) + i) + '');
            }

            for (i = 1; i <= currMonthDays; i += 1) {
                if (matrix[row].length === 7) {
                    row += 1;
                }

                matrix[row].push(i);
            }

            for (i = 1; i <= nextMonthDays; i += 1) {
                if (matrix[row].length === 7) {
                    row += 1;
                }

                matrix[row].push(i + '');
            }
        }

        function buildCalendar(date) {
            matrix = [];
            fillCalendarMatrix(date);
            var $table = $('<table />').addClass('calendar').css('cursor', 'pointer');

            for (var row = 0; row < rows; row += 1) {
                var $currentRow = $('<tr />');

                for (var col = 0; col < cols; col += 1) {
                    if (row === 0) {
                        $('<th />').text(WEEK_DAY_NAMES[col]).appendTo($currentRow);
                    } else {
                        if (typeof matrix[row - 1][col] === 'string') {
                            $('<td />').text(matrix[row - 1][col]).addClass('another-month').appendTo($currentRow);
                        } else {
                            $('<td />').text(matrix[row - 1][col]).appendTo($currentRow);
                        }
                    }
                }

                $table.append($currentRow.clone());
                $currentRow.empty();
            }

            return $table;
        }

        function buildFooter(date) {
            $('<div />')
                .addClass('current-date')
                .append(
                $('<a />')
                    .addClass('current-date-link')
                    .text(date.getDate() + ' ' + date.getMonthName() + ' ' + date.getFullYear())
                )
                .appendTo($picker);
        }

        $root.on('click', '#date', function () {
            var pickerCalendar = $picker.find('.calendar');

            if (!pickerCalendar.length) {
                buildHeader(date);
                $picker.append(buildCalendar(date));
                buildFooter(date);
            }

            togglePicker();
        });

        $picker.on('click', '.previous-month', function () {
            date = new Date(date.getFullYear(), date.getMonth() - 1, 1);
            buildCalendar(date).replaceAll('.calendar');
            $header.find('.current-month').text(MONTH_NAMES[date.getMonth()] + ' ' + date.getFullYear());
        });

        $picker.on('click', '.next-month', function () {
            date = new Date(date.getFullYear(), date.getMonth() + 1, 1);
            buildCalendar(date).replaceAll('.calendar');
            $header.find('.current-month').text(MONTH_NAMES[date.getMonth()] + ' ' + date.getFullYear());
        });

        $picker.on('click', 'td', function () {
            var day = $(this).text();
            var month = date.getMonth() + 1;
            var year = date.getFullYear();

            togglePicker();
            $root.find('#date').val(day + '/' + month + '/' + year);
        });

        $picker.on('click', '.current-date', function () {
            var day = currentDate.getDate();
            var month = currentDate.getMonth() + 1;
            var year = currentDate.getFullYear();

            console.log(currentDate);
            togglePicker();
            $root.find('#date').val(day + '/' + month + '/' + year);
        });

        function togglePicker() {
            $picker.toggleClass('picker-visible');
        }

        $root.append($picker);
    };
}