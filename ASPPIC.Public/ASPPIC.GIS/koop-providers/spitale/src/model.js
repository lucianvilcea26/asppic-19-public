function Model(koop) { }

// each model should have a getData() function to fetch the geo data
// and format it into a geojson
Model.prototype.getData = async function (req, callback) {
  // var geojson = {
  //   type: 'FeatureCollection',
  //   features: []
  // }

  try {
    var geojson = await query_postgis();
    // console.log("Aici: ", geojson);
    // console.log("Geosjon: ", geojson)
    geojson.metadata = {};
    geojson.metadata.idField = "f1";
    // geojson.metadata.maxRecordCount = 50;
    geojson.metadata.geometryType = 'Point';
    geojson.metadata.fields = [{"name":"f1", type:"Integer"}, {"name":"f2", type:"String"} ];


    var fs = require('fs');
    fs.writeFileSync("c:/koopsrv/demogis/data/spitale.json", JSON.stringify(geojson), (err) =>
    {
      if(err)
      console.log("Error write geojson");

    });
    
    callback(null, geojson)
  }
  catch (err) {
    callback(err, null);
  }
}

async function query_postgis() {
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
  var hospitals_query = "SELECT row_to_json(fc) FROM ( SELECT 'FeatureCollection' As type, array_to_json(array_agg(f)) As features FROM (SELECT 'Feature' As type, ST_AsGeoJSON(h.geom)::json As geometry, row_to_json((\"h\".\"objectid\", \"h\".\"HospitalName\")) As properties FROM \"Hospitals\" As h) As f) As fc;";
  
  var hospitals_fc = await client.query(hospitals_query).then(res => {
    return res.rows[0].row_to_json;
  }).catch(err => console.log(err));

  client.release();

  // Wrap features in Feature Collection object
  return hospitals_fc;
}

module.exports = Model
