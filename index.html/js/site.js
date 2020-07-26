// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//***********search filter**********
var elId = document.getElementsByTagName('tbody')[0].id;
var searchInputId = document.getElementsByTagName('form')[0].id;
var el = document.getElementById(elId);
var searchInput = document.querySelector('#' + searchInputId + ' input');

searchInput.addEventListener('keyup', function (e) {
    var rows = el.rows;
    var tableArray = new Array();

    for (var i = 0; i < rows.length; i++) {
        var row = rows[i];
        tableArray.push(row);
    }
    var searchChar = e.target.value.toUpperCase();
    var i = 0;
    tableArray.forEach(function (row) {
        var parText = rows[i].textContent;       
        if (parText.toUpperCase().indexOf(searchChar) == -1) {
            row.style.display = 'none';
        } else {
            row.style.display = 'table-row';
        }
        i++;
    })
});
////***************Table Sort************************
function sortTable(column, id) {
    var rows;
    var tableId = document.getElementsByTagName('table')[0].id;
    var table = document.getElementById(tableId);
    var switching = true;
    // Set the sorting direction to ascending:
    var dir = "asc";
    var i;
    var x;
    var y;
    var shouldSwitch;
    var switchCount = 0;
    /* Make a loop that will continue until
    no switching has been done: */
    while (switching) {
        // Start by saying: no switching is done:
        switching = false;
        rows = table.rows;
        /* Loop through all table rows (except the
        first, which contains table headers): */
        for (i = 1; i < (rows.length - 1); i++) {
            // Start by saying there should be no switching:
            shouldSwitch = false;
            /* Get the two elements you want to compare,
            one from current row and one from the next: */
            x = rows[i].getElementsByTagName("TD")[column];
            y = rows[i + 1].getElementsByTagName("TD")[column];
            /* Check if the two rows should switch place,
            based on the direction, asc or desc: */
            //Determines if selection is int/date/string
            if (id == 'int') {
                x = parseInt(x.innerHTML);
                y = parseInt(y.innerHTML);

                if (dir == "asc") {
                    if (x > y) {
                        // If so, mark as a switch and break the loop:
                        shouldSwitch = true;
                        break;
                    }
                } else if (dir == "desc") {
                    if (x < y) {
                        // If so, mark as a switch and break the loop:
                        shouldSwitch = true;
                        break;
                    }
                }
            }
            else if (id == 'date' || id == 'data2')  // customerOrders - date sorting has bug
            {
                var xdate = new Date(x.innerHTML);
                var ydate = new Date(y.innerHTML);

                if (dir == "asc") {
                    if (xdate.getDate() > ydate.getDate()) {
                        // If so, mark as a switch and break the loop:
                        shouldSwitch = true;
                        break;
                    }
                } else if (dir == "desc") {
                    if (xdate.getDate() < ydate.getDate()) {
                        // If so, mark as a switch and break the loop:
                        shouldSwitch = true;
                        break;
                    }
                }
            }
            else
            {
                if (dir == "asc") {
                    if (x.innerHTML.toLowerCase() > y.innerHTML.toLowerCase()) {
                        // If so, mark as a switch and break the loop:
                        shouldSwitch = true;
                        break;
                    }
                } else if (dir == "desc") {
                    if (x.innerHTML.toLowerCase() < y.innerHTML.toLowerCase()) {
                        // If so, mark as a switch and break the loop:
                        shouldSwitch = true;
                        break;
                    }
                }
            }
        }
        if (shouldSwitch) {
            /* If a switch has been marked, make the switch
            and mark that a switch has been done: */
            rows[i].parentNode.insertBefore(rows[i + 1], rows[i]);
            switching = true;
            // Each time a switch is done, increase this count by 1:
            switchCount++;
        } else {
            /* If no switching has been done AND the direction is "asc",
            set the direction to "desc" and run the while loop again. */
            if (switchCount == 0 && dir == "asc") {
                dir = "desc";
                switching = true;
            }
        }
    }
};