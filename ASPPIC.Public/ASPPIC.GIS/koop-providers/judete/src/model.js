function Model (koop) {}

// each model should have a getData() function to fetch the geo data
// and format it into a geojson
Model.prototype.getData = async function (req, callback) {
  // const geojson = {
  //   type: 'FeatureCollection',
  //   features: []
  // }

  try {
    var geojson = await query_postgis_judete();
    // console.log("Aici: ", geojson);
    // console.log("Geosjon: ", geojson)
    geojson.metadata = {}
    geojson.metadata.geometryType = 'MultiPolygon';
    geojson.metadata.idField = "f1";
    // geojson.metadata.maxRecordCount = 50;
    geojson.metadata.fields = [{"name":"f1", type:"Integer"}, {"name":"f2", type:"String"} ];
    // geojson.ttl = _.get(metadataCopy, 'ttl', 10)

    // var fs = require('fs');
    // fs.writeFileSync("c:/koopsrv/demogis/data/judete.json", JSON.stringify(geojson), (err) =>
    // {
    //   if(err)
    //   console.log("Error write geojson");

    // });

    callback(null, geojson)
  }
  catch (err) {
    callback(err, null);
  } 
}

async function query_postgis_judete() {
  // Setup connection
  var username = username
  var password = password
  var host = host
  var database = database name
  var conString = "postgres://" + username + ":" + password + "@" + host + "/" + database;
  // Your Database Connection

  const { Pool } = require('pg');
  const pool = new Pool({
    connectionString: conString,
    max: 150,
    idleTimeoutMillis: 30000,
    connectionTimeoutMillis: 2000
  });
  const client = await pool.connect();

  // Set up your database query to display GeoJSON

  const counties_query = "SELECT row_to_json(fc) FROM ( SELECT 'FeatureCollection' As type, array_to_json(array_agg(f)) As features FROM (SELECT 'Feature' As type, ST_AsGeoJSON(h.geom)::json As geometry, row_to_json((\"h\".\"objectid\", \"h\".\"Name\")) As properties FROM \"Counties\" As h) As f) As fc"
  
  var counties_fc = await client.query(counties_query).then(res => {
    return res.rows[0].row_to_json;
  }).catch(err => console.log(err));

  client.release();

  // Wrap features in Feature Collection object
  return counties_fc;
}

module.exports = Model
