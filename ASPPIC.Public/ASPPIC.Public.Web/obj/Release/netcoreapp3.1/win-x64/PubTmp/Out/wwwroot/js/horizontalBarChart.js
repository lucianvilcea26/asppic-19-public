function horizontalBarChart(data, params) {
    $(params.container).empty();
    function descendingComparer(a, b) {
        if (a["county"] > b["county"]) {
            return -1;
        }
        if (a["county"] < ["county"]) {
            return 1;
        }
        return 0;
    }

    var parentWidth = $(params.container).parent().width()
    //set up svg using margin conventions - we'll need plenty of room on the left for labels
    var margin = { top: 10, right: 30, bottom: 30, left: 130 },
        width = parentWidth - margin.left - margin.right,
        height = parentWidth - margin.top - margin.bottom;

    
    data.sort(descendingComparer);

    var y = d3.scaleBand()
        .range([height, 0])
        .padding(0.1);

    var x = d3.scaleLinear()
        .range([0, width]);

    // append the svg object to the body of the page
    // append a 'group' element to 'svg'
    // moves the 'group' element to the top left margin
    var svg = d3.select(params.container).append("svg")
        .attr("width", width + margin.left + margin.right)
        .attr("height", height + margin.top + margin.bottom)
        .append("g")
        .attr("transform",
            "translate(" + margin.left + "," + margin.top + ")");


    // Scale the range of the data in the domains
    x.domain([0, d3.max(data, function (d) { return d[params.xField]; })])
    y.domain(data.map(function (d) { return d[params.yField]; }));
    //y.domain([0, d3.max(data, function(d) { return d.sales; })]);
    addVerticalGridLines(svg, height, x);
    // append the rectangles for the bar chart
    svg.selectAll(".bar")
        .data(data)
        .enter().append("rect")
        .attr("class", "bar")
        .attr("fill", params.color)
        .attr("data-toggle", "tooltip")
        .attr("data-placement", "right")
        .attr("title", function (d) { return d[params.xField] })
        .attr("width", function (d) { return x(d[params.xField]); })
        .attr("y", function (d) { return y(d[params.yField]); })
        .attr("height", y.bandwidth());

    // add the x Axis
    svg.append("g")
        .attr("transform", "translate(0," + height + ")")
        .call(d3.axisBottom(x));

    // add the y Axis
    svg.append("g")
        .call(d3.axisLeft(y));
    $('rect').tooltip()
}
