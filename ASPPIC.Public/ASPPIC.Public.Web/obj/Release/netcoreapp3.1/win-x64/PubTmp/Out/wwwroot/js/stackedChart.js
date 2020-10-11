function stackedChart(data, params) {
    $(params.container).empty();
    const causes = params.yField
    var margin = { top: 20, right: 20, bottom: 70, left: 100 },
        width = $(params.container).parent().width() - margin.left - margin.right,
        height = $(params.container).parent().width() * 0.5 - margin.top - margin.bottom;

    var x = d3.scaleBand()
        .range([0, width])
        .padding(0.1);
    var y = d3.scaleLinear()
        .range([height, 0]);

    const z = d3.scaleOrdinal(d3.schemeCategory10)

    var svg = d3.select(params.container).append("svg")
        .attr("width", width + margin.left + margin.right)
        .attr("height", height + margin.top + margin.bottom)
        .append("g")
        .attr("transform",
            "translate(" + margin.left + "," + margin.top + ")");


    const layers = d3.stack()
        .keys(causes)
        (data)
    addHorizontalGridLines(svg, width, y)
    x.domain(layers[0].map(d => d.data[params.xField]))

    y.domain([0, d3.max(layers[layers.length - 1], d => (d[0] + d[1]))]).nice()

    const layer = svg.selectAll('layer')
        .data(layers)
        .enter()
        .append('g')
        .attr('class', 'layer')
        .style('fill', (d, i) => (z(i)))   

    layer.selectAll('rect')
        .data(d => d)
        .enter()
        .append('rect')
        .attr("data-toggle", "tooltip")
        .attr("data-placement", "top")
        .attr("title", function (d) { return d[1] + " ( " + d.data[params.xField] + " )" })
        .attr('x', d => x(d.data[params.xField]))
        .attr('y', d => y(d[0] + d[1]))
        .attr('height', d => y(d[0]) - y(d[1] + d[0]))
        .attr('width', x.bandwidth() - 1)

    svg.append('g')
        .attr('transform', `translate(0,${height})`)
        .call(d3.axisBottom(x))
        .selectAll("text");
    rotateXLabels(svg);


    svg.append('g')
        .call(d3.axisLeft(y))
}

function lineChart(data, params) {

    //var margin = { top: 20, right: 20, bottom: 30, left: 40 },
    //    //width = $(params.container).parent().width() - margin.left - margin.right,
    //    //height = $(params.container).parent().width()  - margin.top - margin.bottom;    
    //    width = 800;
    //height = 600;



    ////scales
    //var xExtent = d3.extent(data, d => d[params.xField]);
    //var xScale = d3.scaleTime()
    //    .domain(xExtent).range([0, width - margin.right]);
    //var xAxis = d3.axisBottom().scale(xScale);

    //var yMax = d3.max(data, d => d[params.yField]);
    //var yScale = d3.scaleLinear()
    //    .domain([0, yMax]).range([height, 0]);
    //var yAxis = d3.axisLeft().scale(yScale);

    //var svg = d3.select(params.container).append('svg').append('g')
    //    .attr('transform', 'translate(40,20)');

    //var line = d3.line()
    //    .x(d => xScale(d[params.xField]))
    //    .y(d => yScale(d[params.yField]));

    //svg.selectAll('path')
    //    .data([data]).enter().append('path')
    //    .attr('d', line)
    //    .attr('fill', 'none')
    //    .attr('stroke', 'blue');

    //// axis
    //svg.append('g')
    //    .attr('class', 'xAxis')
    //    .call(xAxis)
    //    .attr('transform', 'translate(' + [0, height] + ')');

    //svg.append('g')
    //    .attr('class', 'yAxis')
    //    .call(yAxis);

    //// 2. Use the margin convention practice
    //var margin = { top: 20, right: 20, bottom: 30, left: 40 },
    //    width = $(params.container).parent().width() - margin.left - margin.right,
    //    height = $(params.container).parent().width() * 0.5 - margin.top - margin.bottom;

    //// The number of datapoints
    //var n = 21;

    //// 5. X scale will use the index of our data
    //var xScale = d3.scaleLinear()
    //    .domain([0, n - 1]) // input
    //    .range([0, width]); // output

    //// 6. Y scale will use the randomly generate number
    //var yScale = d3.scaleLinear()
    //    .domain([0, 1]) // input
    //    .range([height, 0]); // output

    //// 7. d3's line generator
    //var line = d3.line()
    //    .x(function (d, i) { return xScale(i); }) // set the x values for the line generator
    //    .y(function (d) { return yScale(d.y); }) // set the y values for the line generator
    //    .curve(d3.curveMonotoneX) // apply smoothing to the line

    //// 8. An array of objects of length N. Each object has key -> value pair, the key being "y" and the value is a random number
    //var dataset = d3.range(n).map(function (d) { return { "y": d3.randomUniform(1)() } })

    //// 1. Add the SVG to the page and employ #2
    //var svg = d3.select("body").append("svg")
    //    .attr("width", width + margin.left + margin.right)
    //    .attr("height", height + margin.top + margin.bottom)
    //    .append("g")
    //    .attr("transform", "translate(" + margin.left + "," + margin.top + ")");

    //// 3. Call the x axis in a group tag
    //svg.append("g")
    //    .attr("class", "x axis")
    //    .attr("transform", "translate(0," + height + ")")
    //    .call(d3.axisBottom(xScale)); // Create an axis component with d3.axisBottom

    //// 4. Call the y axis in a group tag
    //svg.append("g")
    //    .attr("class", "y axis")
    //    .call(d3.axisLeft(yScale)); // Create an axis component with d3.axisLeft

    //// 9. Append the path, bind the data, and call the line generator
    //svg.append("path")
    //    .datum(dataset) // 10. Binds data to the line
    //    .attr("class", "line") // Assign a class for styling
    //    .attr("d", line); // 11. Calls the line generator

    //// 12. Appends a circle for each datapoint
    //svg.selectAll(".dot")
    //    .data(dataset)
    //    .enter().append("circle") // Uses the enter().append() method
    //    .attr("class", "dot") // Assign a class for styling
    //    .attr("cx", function (d, i) { return xScale(i) })
    //    .attr("cy", function (d) { return yScale(d.y) })
    //    .attr("r", 5);
}