const dbcPool = require('./db');

let Licensee = {};

Licensee.list = async function(order = "expiry", desc = true) {

    // SELECT `licenseeId`,`first`,`last`,expiry from licensee ORDER BY expiry desc

    let dbConn = await dbcPool.getConnection();
    const rows = await dbConn.query("SELECT `licenseeId`,`first`,`last`,expiry from licensee ORDER BY ? ?", [order, desc ? 'desc' : 'asc']);
    dbConn.end();
    //console.log(rows);
    return rows;
}

Licensee.filterByDate = async function(date) {

    // SELECT `licenseeId`,`first`,`last`,expiry from licensee ORDER BY expiry desc

    let dbConn = await dbcPool.getConnection();
    const rows = await dbConn.query("SELECT `licenseeId`,`first`,`last`,expiry from licensee WHERE expiry < ?", [date]);
    dbConn.end();
    //console.log(rows);
    return rows;
}

Licensee.insert = async function(licenseeData) {

    //console.log(licenseeData);
    //INSERT INTO `license`.`licensee` (`first`, `last`, `expiry`) VALUES ('bob', 'robertson', '2022-03-18')

    let resultData = { status: false };
    let dbConn = await dbcPool.getConnection();
    try {
        results = await dbConn.query("INSERT INTO `licensee` (`first`, `last`, `expiry`) VALUES (?, ?, ?)", [licenseeData.first, licenseeData.last, licenseeData.expiry]);
        resultData.message = "data added";
        resultData.status = true;
        resultData.insertId = Number(results.insertId);

    } catch (err) {
        resultData.message = "could not add data: " + err.message;
    }
    dbConn.end();
    //console.log(rows);
    return resultData;
}


module.exports = Licensee;