
const packageInfo = require('../package.json')

const provider = {
  type: 'provider',
  name: 'judete-provider',
  version: packageInfo.version,
  hosts: true,
  disableIdParam: true,
  Model: require('./model')
}

module.exports = provider
