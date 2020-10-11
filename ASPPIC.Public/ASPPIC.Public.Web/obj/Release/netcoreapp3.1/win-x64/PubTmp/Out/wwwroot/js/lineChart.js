function lineChart(data, params) {// set the dimensions and margins of the graph
    
    $(params.container).empty();
        var parentWidth = $(params.container).parent().width()
        var margin = { top: 10, right: 30, bottom: 30, left: 60 },
            width = parentWidth - margin.left - margin.right,
            height = parentWidth * 0.5 - margin.top - margin.bottom;
        var svg = d3.select(params.container)
            .append("svg")
            .attr("width", width + margin.left + margin.right)
            .attr("height", height + margin.top + margin.bottom)
            .append("g")
            .attr("transform",
                "translate(" + margin.left + "," + margin.top + ")");
        // offset = height - 80;

        var x = d3.scaleTime()
            .domain(d3.extent(data, function (d) { return Date.parse(d[params.xField]); }))
            .range([0, width]);
        svg.append("g")
            .attr("transform", "translate(0," + (height) + ")")
            .call(d3.axisBottom(x));

        var y = d3.scaleLinear()
            .domain([0, d3.max(data, function (d) {
                return d[params.yField];
            })]).range([height, 0]);
        svg.append("g")
            .call(d3.axisLeft(y));
        

        svg.append("path")
            .datum(data)
            .attr("fill", "none")
            .attr("stroke", params.color)
            .attr("stroke-width", params.strokeWidth)
            .attr("d", d3.line()
                .x(function (d) { return x(Date.parse(d[params.xField])) })
                .y(function (d) { return y(d[params.yField]) })
            );

    addHorizontalGridLines(svg, width, y)
        svg.selectAll("line-circle")
            .data(data)
            .enter().append("circle")
            .attr("style", "fill: " + params.color)
            .attr("data-toggle", "tooltip")
            .attr("data-placement", "top")
            .attr("r", params.pointRadius)
            .attr("cx", function (d) { return x(Date.parse(d[params.xField])); })
            .attr("cy", function (d) { return y(d[params.yField]); })
            .attr("title", function (d) { return d[params.yField] + " (" + formatDate(Date.parse(d[params.xField])) + ")" });

        $('circle').tooltip()    
}
