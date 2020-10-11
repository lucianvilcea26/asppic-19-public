// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function formatDate(date) {
    const dateTimeFormat = new Intl.DateTimeFormat('en', { year: 'numeric', month: '2-digit', day: '2-digit' })
    const [{ value: month }, , { value: day }, , { value: year }] = dateTimeFormat.formatToParts(date)

    return `${day}.${month}.${year}`;
}
function addHorizontalGridLines(svg, width, y) {
    function make_y_gridlines() {
        return d3.axisLeft(y)
            .ticks(10)
    }
    svg.append("g")
        .attr("class", "grid")
        .call(make_y_gridlines()
            .tickSize(-width)
            .tickFormat("")
        )
}

function addVerticalGridLines(svg, height, x) {
    function make_x_gridlines() {
        return d3.axisBottom(x)
            .ticks(10)
    }
    svg.append("g")
        .attr("class", "grid")
        .attr("transform", "translate(0," + (height) + ")")
        .call(make_x_gridlines()
            .tickSize(-height)
            .tickFormat("")
        )
}

function rotateXLabels(svg) {
    svg.selectAll("text").attr("y", 0)
        .attr("x", 9)
        .attr("dy", ".35em")
        .attr("transform", "rotate(90)")
        .style("text-anchor", "start")
}

function ascendingComparer(a, b) {
    if (a["Data"] < b["Data"]) {
        return -1;
    }
    if (a["Data"] > ["Data"]) {
        return 1;
    }
    return 0;
}

function descendingComparer(a, b) {
    if (a["Data"] > b["Data"]) {
        return -1;
    }
    if (a["Data"] < ["Data"]) {
        return 1;
    }
    return 0;
}