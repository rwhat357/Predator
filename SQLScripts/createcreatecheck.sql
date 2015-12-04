DELIMITER $$
CREATE DEFINER=`koopa`@`%` PROCEDURE `CreateCheck`(in storeNUM INT, in bankName varchar(45), in rNUM INT(9), in aNUM INT, in cNUM INT, in firstName VARCHAR(60),
in lastName VARCHAR(60), in firstName2 VARCHAR(60), in lastName2 VARCHAR(60), in inAddress VARCHAR(255),
in inCity VARCHAR(25), in inState VARCHAR(2), in inZipCode INT(5), in phone CHAR(25), in checkAmount FLOAT, in checkDate DATE)
BEGIN
	DECLARE accountNUMBER INT DEFAULT FALSE;
	IF ( SELECT EXISTS (SELECT * FROM bank WHERE routingNum = rNUM )) THEN 
        SELECT 'EXISTS';
		#UPDATE TEST SET testFlag=1 WHERE id=searchId;
        #SET result=1;
    ELSE
        SELECT 'DOES NOT EXISTS';
        INSERT INTO bank (routingNum, bName, address, city, state, zipcode) VALUES (rNUM, bankName, '', '', '', '12345');
        SELECT rNUM;
    END IF; 
	
    #Create Account
    IF ( SELECT EXISTS (SELECT * FROM account WHERE routingNum = rNUM AND accountNum = aNUM)) THEN 
        SET accountNUMBER = (SELECT 'Account EXISTS Just select the ID of the Account');
        #We Need a way to update things
        
		#UPDATE TEST SET testFlag=1 WHERE id=searchId;
        #SET result=1;
    ELSE
        INSERT INTO account (routingNum, accountNum, fName, lName, fName2, lName2, address, city, state, zipCode, phoneNum) VALUES (rNUM, aNUM, firstName, lastName, firstName2, lastName2, inAddress, inCity, inState, inZipCode, phone);
        SELECT 'Account Created', rNUM;
    END IF;
    
    #Create Check 
    INSERT INTO chekue (idAccount, idStore, checkNum, amount, dateWritten) VALUES (accountNUMBER, storeNUM, cNum, checkAmount, checkDate);
    SELECT 'Check Created';
END$$
DELIMITER ;
SELECT * FROM checkdb.checkdisplayrow;