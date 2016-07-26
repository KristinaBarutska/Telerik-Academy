function createCalendar(selector, events) {
    let selectedElement = document.querySelector(selector),
        days = ['Sun', 'Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat'],
        table = document.createElement('table')

    function buildCalendar() {
        let cell = document.createElement('td'),
            row = document.createElement('tr'),
            cellHeader = document.createElement('h4'),
            contentHolder = document.createElement('div'),
            dayIndex = 0,
            elementsOnRow = 0,
            daysCount = 0;

        table.style.cssText = 'border-collapse: collapse;';
        cell.style.cssText = 'border: 1px solid black;';
        cellHeader.style.cssText = 'background-color: lightgray; margin: 0; padding: 0 5px 0 5px;';
        contentHolder.style.cssText = 'height: 90px; background-color: white;';

        for (let i = 0; i < 5; i += 1) {
            let currentRow = row.cloneNode(true);

            for (let i = 0; i < 7; i += 1) {
                let currentCell = cell.cloneNode(true),
                    currentHeader = cellHeader.cloneNode(true),
                    currentContentHolder = contentHolder.cloneNode(true);

                dayIndex = dayIndex === 7 ? 0 : dayIndex;
                currentHeader.innerHTML = `${days[dayIndex]} ${daysCount + 1} July 2014`;
                currentCell.setAttribute('data-info', daysCount + 1);
                currentCell.appendChild(currentHeader);
                currentCell.appendChild(currentContentHolder);
                currentRow.appendChild(currentCell);
                dayIndex += 1;
                daysCount += 1;

                if (daysCount === 30) {
                    table.appendChild(currentRow);
                    return;
                }
            }

            table.appendChild(currentRow);
        }
    }

    function appendEvents() {
        let container = document.createElement('div');

        events = events.sort((a, b) => a.date - b.date);

        for (let i = 0; i < events.length; i += 1) {
            let title = events[i].title || '',
                date = events[i].date || '',
                time = events[i].time || '',
                duration = events[i].duration || '',
                cell = document.querySelector(`td[data-info="${date}"]`);

            cell.lastChild.innerHTML += `${title} ${date} ${time} ${duration}<br/>`;

            if (i < events.length - 1 && events[i + 1].date !== events[i].date) {
                cell.appendChild(container);
            } else if (i === events.length - 1) {
                cell.appendChild(container);
            }
        }
    }

    function attachEffectEvents() {
        table.addEventListener('mouseover', function (event) {
            let target = event.target;

            if (target.nodeName === 'TD') {
                target.firstChild.style.backgroundColor = 'gray';
            } else if (target.nodeName === 'H4') {
                target.style.backgroundColor = 'gray';
            } else if (target.nodeName === 'DIV') {
                target.previousElementSibling.style.backgroundColor = 'gray';
            }
        });

        table.addEventListener('mouseout', function (event) {
            let target = event.target;

            if (target.nodeName === 'TD') {
                target.firstChild.style.backgroundColor = 'lightgray';
            } else if (target.nodeName === 'H4') {
                target.style.backgroundColor = 'lightgray';
            } else if (target.nodeName === 'DIV') {
                target.previousElementSibling.style.backgroundColor = 'lightgray';
            }
        });

        table.addEventListener('click', function (event) {
            let target = event.target,
                element;

            if (target.nodeName === 'DIV' || target.nodeName === 'H4') {
                element = target.parentNode;
            } else if (target.nodeName === 'TD') {
                element = target;
            }

            if (element.lastChild.style.backgroundColor === 'white') {
                console.log('fired');
                element.firstChild.style.backgroundColor = 'gray';
                element.lastChild.style.backgroundColor = 'gray';
            } else if (element.lastChild.style.backgroundColor === 'gray') {
                element.firstChild.style.backgroundColor = 'lightgray';
                element.lastChild.style.backgroundColor = 'white';
            }
        });
    }

    buildCalendar();
    selectedElement.appendChild(table);
    appendEvents();
    attachEffectEvents();
}