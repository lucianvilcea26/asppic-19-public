function Model(koop) { }

// each model should have a getData() function to fetch the geo data
// and format it into a geojson
Model.prototype.getData = async function (req, callback) {

  try {
    var geojson = await query_postgis();
    geojson.metadata = {};
    geojson.metadata.idField = "f1";
    geojson.metadata.geometryType = 'Point';
    geojson.metadata.fields = [{"name":"f1", type:"Integer"}, {"name":"f2", type:"String"} ];
    
    callback(null, geojson)
  }
  catch (err) {
    callback(err, null);
  }
}

async function query_postgis() {
  // Setup connection
  var username = "" // sandbox username
  var password = "" // read only privileges on our table
  var host = ""
  var database = "" // database name
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
  var hospitals_query = "select json_build_object('type', 'FeatureCollection', 'features', json_agg(ST_AsGeoJSON(t.*)::json)) from public.\"HospitalsView\" as t(\"HospitalName\",\"Abbreviation\",\"Address\",\"Uat\",\"County\",\"AdditionalData\",\"Category\",\"StatePrivate\",\"Email\",\"Phone\",\"FullLink\",\"GpsRoute\",geom);";
  
  var hospitals_fc = await client.query(hospitals_query).then(res => {
    return res.rows[0].json_build_object;
  }).catch(err => console.log("Eroare", err));

  client.end();
  client.release();

  var fs = require('fs');
  fs.writeFileSync("c:/koopsrv/demogis/data/spitale.geojson", JSON.stringify(hospitals_fc), (err) =>
  {
    if(err)
    console.log("Error write geojson");

  });

  // Wrap features in Feature Collection object
  return hospitals_fc;
}

module.exports = Model
