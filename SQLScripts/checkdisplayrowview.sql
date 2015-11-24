CREATE VIEW `checkdisplayrow` AS
SELECT checks.idCheck, checks.idAccount, checks.idStore, checks.checkNum, checks.amount, checks.dateWritten, checks.amountPaid, checks.paidDate, accounts.routingNum, accounts.accountNum, accounts.fName, accounts.lName, accounts.fName2, accounts.lName2, accounts.address, accounts.city, accounts.state, accounts.zipcode, accounts.phoneNum, banks.bName, banks.address AS bAddress, banks.city AS bCity, banks.state AS bState, banks.zipcode AS bZipcode, stores.idStoreGroup, stores.sName, stores.address AS sAddress, stores.city AS sCity, stores.state as sState, stores.zipcode AS sZipcode
FROM chekue AS checks 
LEFT JOIN account AS accounts ON checks.idAccount = accounts.idAccount
LEFT JOIN bank as banks ON accounts.routingNum = banks.routingNum
LEFT JOIN store as stores ON checks.idStore = stores.idStore