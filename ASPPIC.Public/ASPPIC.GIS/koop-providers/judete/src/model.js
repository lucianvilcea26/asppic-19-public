function Model(koop) { }

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
    geojson.metadata.fields = [{ "name": "f1", type: "Integer" }, { "name": "f2", type: "String" }];
    // geojson.ttl = _.get(metadataCopy, 'ttl', 10)

    callback(null, geojson)
  }
  catch (err) {
    callback(err, null);
  }
}

async function query_postgis_judete() {
  // Setup connection
  var username = ""; // Username
  var password = "" // Password
  var host = "" //Server name and port
  var database = "" // Database name
  //Database connection string
  var conString = "postgres://" + username + ":" + password + "@" + host + "/" + database;

  // Create a connection pool
  const { Pool } = require('pg');
  const pool = new Pool({
    connectionString: conString,
    max: 150,
    idleTimeoutMillis: 30000,
    connectionTimeoutMillis: 2000
  });
  // Create the client for PG connection
  const client = await pool.connect();

  // Set up your database query to display GeoJSON
  const query_counties_stats = "select json_build_object('type', 'FeatureCollection', 'features', json_agg(ST_AsGeoJSON(t.*)::json)) from public.\"CountiesStats\" as t(county, last_day, last_week, last_month, geom);"


  var counties_stats_results = await client.query(query_counties_stats).then(res => {
    return res.rows[0].json_build_object;
  }).catch(err => console.log(err));

  client.release();
  client.end();
  

  var fs = require('fs');
  fs.writeFileSync("c:/koopsrv/demogis/data/judete_stats.geojson", JSON.stringify(counties_stats_results), (err) => {
    if (err)
      console.log("Error write geojson");

  });

  // Wrap features in Feature Collection object
  return counties_stats_results;
}

module.exports = Model
