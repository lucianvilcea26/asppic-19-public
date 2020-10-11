function barChart(data, params) {
    $(params.container).empty();
    function comparer(a, b) {
        if (a[params.xField] < b[params.xField]) {
            return -1;
        }
        if (a[params.xField] > b[params.xField]) {
            return 1;
        }
        return 0;
    }

    var margin = { top: 20, right: 20, bottom: 70, left: 100 },
        width = $(params.container).parent().width() - margin.left - margin.right,
        height = $(params.container).parent().width() * 0.5 - margin.top - margin.bottom;

    // set the ranges
    var x = d3.scaleBand()
        .range([0, width])
        .padding(0.1);
    var y = d3.scaleLinear()
        .range([height, 0]);

    // append the svg object to the body of the page
    // append a 'group' element to 'svg'
    // moves the 'group' element to the top left margin
    var svg = d3.select(params.container).append("svg")
        .attr("width", width + margin.left + margin.right)
        .attr("height", height + margin.top + margin.bottom)
        .append("g")
        .attr("transform",
            "translate(" + margin.left + "," + margin.top + ")");

    // format the data
    data.forEach(function (d) {
        d.total_county = parseInt(d[params.yField]);
    });
    data.sort(comparer);

    console.log(data);
    // Scale the range of the data in the domains
    x.domain(data.map(function (d) { return d[params.xField]; }));
    y.domain([0, d3.max(data, function (d) { return d[params.yField]; })]);

    addHorizontalGridLines(svg, width, y)
    // append the rectangles for the bar chart
    svg.selectAll(".bar")
        .data(data)
        .enter().append("rect")
        .attr("class", "bar")
        .attr("fill", params.color)
        .attr("data-toggle", "tooltip")
        .attr("data-placement", "top")
        .attr("title", function (d) { return d[params.yField] })
        .attr("x", function (d) { return x(d[params.xField]); })
        .attr("width", x.bandwidth())
        .attr("y", function (d) { return y(d[params.yField]); })
        .attr("height", function (d) { return height - y(d[params.yField]); });
    

    // add the x Axis
    svg.append("g")

        .attr("transform", "translate(0," + height + ")")
        .call(d3.axisBottom(x))
    rotateXLabels(svg);

    // add the y Axis
    svg.append("g")
        .call(d3.axisLeft(y));
    $('rect').tooltip()
}

