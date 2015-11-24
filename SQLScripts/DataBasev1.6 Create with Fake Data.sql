CREATE DATABASE  IF NOT EXISTS `checkdb` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `checkdb`;
-- MySQL dump 10.13  Distrib 5.6.19, for osx10.7 (i386)
--
-- Host: 158.158.143.144    Database: checkdb
-- ------------------------------------------------------
-- Server version	5.6.27-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `account`
--

DROP TABLE IF EXISTS `account`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `account` (
  `idAccount` int(11) NOT NULL AUTO_INCREMENT,
  `routingNum` int(9) NOT NULL,
  `accountNum` int(11) NOT NULL,
  `fName` varchar(60) NOT NULL,
  `lName` varchar(60) NOT NULL,
  `fName2` varchar(60) DEFAULT NULL,
  `lName2` varchar(60) DEFAULT NULL,
  `address` varchar(255) NOT NULL,
  `city` varchar(45) NOT NULL,
  `state` varchar(2) NOT NULL,
  `zipcode` int(5) NOT NULL,
  `phoneNum` char(25) DEFAULT NULL,
  PRIMARY KEY (`idAccount`),
  UNIQUE KEY `idAccount_UNIQUE` (`idAccount`),
  KEY `fk_Account_Bank1_idx` (`routingNum`),
  CONSTRAINT `fk_Account_Bank1` FOREIGN KEY (`routingNum`) REFERENCES `bank` (`routingNum`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `account`
--

LOCK TABLES `account` WRITE;
/*!40000 ALTER TABLE `account` DISABLE KEYS */;
INSERT INTO `account` VALUES (1,122345678,3736,'Bob','Lastname','Sencond Name',' LastName2','Po 28392','Greenville','SC',29617,''),(2,123456789,3293472,'Bob','Bank','','','5 Green St.','Greenville','SC',29617,'888-888-8888'),(3,122345678,3293472,'Mike','Bank','','','5 Green St.','Greenville','SC',29617,'888-888-8888'),(4,122345678,2029281,'Mike','Bank','','','5 Green St.','Greenville','SC',29617,'888-888-8888'),(5,122345678,23421,'Mike','Bank','','','5 Green St.','Greenville','SC',29617,'888-888-8888'),(6,122345678,9989731,'Leanora','Price','','','1751 Cinder Zephyr Corners',' Village Five','VA',22159,' (571) 858-1989'),(7,123456789,9989408,'Mathilda','Woodard','','','5302 Hazy Valley',' Kokruagarok','OR',97216,' (971) 508-5119'),(8,122345678,9988849,'Kecia','Bailey','','','1894 Lazy Mountain Campus',' Unalakleet','GA',39905,' (762) 515-7413'),(9,122345678,9989338,'Aldo','Baker','','','3816 Rustic Pines',' Jackpot','WI',53586,' (920) 744-2613'),(10,122345678,9989939,'Ahmad','Ball','','','8320 Thunder Point',' Planet','MA',1719,' (617) 048-3389'),(11,122345678,9989097,'Iluminada','Bell','','','1685 Tawny Branch Inlet',' Washakie Ten','GA',39930,' (770) 043-9750'),(12,123456789,9989436,'Yetta','Berry','','','4184 Clear Quay',' Frog Eye','WI',54346,' (414) 420-4963'),(13,122345678,9989786,'Kaleigh','Black','','','5174 Umber Moor',' Cash','CT',6663,' (203) 718-3528'),(14,122345678,9988989,'Lindsey','Blake','','','2319 Wishing Ledge',' Nebraska','MI',48415,' (989) 548-5994'),(15,122345678,9989889,'Buster','Bond','','','5800 Dusty Wharf',' Twentythree','NH',3275,' (603) 062-6981'),(16,122345678,9988870,'Antione','Bower','','','2411 Cotton Avenue',' Zook','SD',57030,' (605) 236-4831'),(17,123456789,9988770,'Katie','Brown','','','5180 Quaking Gate Row',' Study Butte','CT',6656,' (475) 722-7127'),(18,122345678,9989198,'Pia','Buckland','','','1429 Silent Isle',' Hooker Point','NC',28365,' (334) 952-9676'),(19,122345678,9989712,'Kelley','Burgess','','','1336 Hidden Crest',' Howey in the Hills','WI',54542,' (262) 474-2883'),(20,122345678,9989782,'Dorothea','Butler','','','3464 Easy Lake Road',' Shiney Town','WI',54231,' (608) 255-6867');
/*!40000 ALTER TABLE `account` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `bank`
--

DROP TABLE IF EXISTS `bank`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `bank` (
  `routingNum` int(9) NOT NULL,
  `bName` varchar(45) NOT NULL,
  `address` varchar(45) NOT NULL,
  `city` varchar(45) NOT NULL,
  `state` varchar(2) NOT NULL,
  `zipcode` int(5) NOT NULL,
  PRIMARY KEY (`routingNum`),
  UNIQUE KEY `routingNum_UNIQUE` (`routingNum`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `bank`
--

LOCK TABLES `bank` WRITE;
/*!40000 ALTER TABLE `bank` DISABLE KEYS */;
INSERT INTO `bank` VALUES (122345678,'Bank of Greenville','','','',12345),(123456789,'Bank of BJU','','','',12345);
/*!40000 ALTER TABLE `bank` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `checktracking`
--

DROP TABLE IF EXISTS `checktracking`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `checktracking` (
  `idCheck` int(11) NOT NULL,
  `idStaff` int(11) NOT NULL,
  `editDate` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `type` int(11) NOT NULL,
  PRIMARY KEY (`idCheck`,`idStaff`),
  KEY `idStaff_idx` (`idStaff`),
  KEY `idCheck_idx` (`idCheck`),
  CONSTRAINT `idCheck` FOREIGN KEY (`idCheck`) REFERENCES `chekue` (`idCheck`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `idStaff` FOREIGN KEY (`idStaff`) REFERENCES `staff` (`idStaff`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `checktracking`
--

LOCK TABLES `checktracking` WRITE;
/*!40000 ALTER TABLE `checktracking` DISABLE KEYS */;
/*!40000 ALTER TABLE `checktracking` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `chekue`
--

DROP TABLE IF EXISTS `chekue`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `chekue` (
  `idCheck` int(11) NOT NULL AUTO_INCREMENT,
  `idAccount` int(11) NOT NULL,
  `idStore` int(11) NOT NULL,
  `checkNum` int(11) NOT NULL,
  `amount` float NOT NULL,
  `dateWritten` date NOT NULL,
  `amountPaid` float DEFAULT NULL,
  `paidDate` datetime DEFAULT NULL,
  PRIMARY KEY (`idCheck`),
  UNIQUE KEY `idCheck_UNIQUE` (`idCheck`),
  KEY `fk_Check_Account_idx` (`idAccount`),
  KEY `fk_Check_Store1_idx` (`idStore`),
  CONSTRAINT `fk_Check_Account` FOREIGN KEY (`idAccount`) REFERENCES `account` (`idAccount`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_Check_Store1` FOREIGN KEY (`idStore`) REFERENCES `store` (`idStore`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=33 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `chekue`
--

LOCK TABLES `chekue` WRITE;
/*!40000 ALTER TABLE `chekue` DISABLE KEYS */;
INSERT INTO `chekue` VALUES (1,1,1,9,23.09,'2014-10-12',NULL,NULL),(2,1,1,9,23.09,'2014-10-12',NULL,NULL),(6,2,2,29,89,'2015-09-14',NULL,NULL),(7,3,2,99,902.2,'2015-09-19',NULL,NULL),(8,5,1,32,233.21,'2015-08-23',NULL,NULL),(9,6,1,76,643.92,'2014-10-12',NULL,NULL),(10,3,1,90,773.86,'2014-10-12',NULL,NULL),(11,2,2,103,903.79,'2015-09-14',NULL,NULL),(12,3,2,117,1033.73,'2015-09-19',NULL,NULL),(13,4,1,130,1163.66,'2015-08-23',NULL,NULL),(14,6,1,144,1293.6,'2014-10-12',NULL,NULL),(15,2,1,158,1423.53,'2014-10-12',NULL,NULL),(16,8,2,17,1553.47,'2015-09-14',NULL,NULL),(17,6,2,185,1683.4,'2015-09-19',NULL,NULL),(18,5,1,198,1813.34,'2015-08-23',NULL,NULL),(19,2,1,212,1943.27,'2014-10-12',NULL,NULL),(20,1,1,226,2073.21,'2014-10-12',NULL,NULL),(21,9,2,239,2203.14,'2015-09-14',NULL,NULL),(22,10,2,253,2333.08,'2015-09-19',NULL,NULL),(23,16,1,2,2463.01,'2015-08-23',NULL,NULL),(24,17,1,33,2592.95,'2014-10-12',NULL,NULL),(25,18,1,294,2722.88,'2014-10-12',NULL,NULL),(26,11,2,307,2852.82,'2015-09-14',NULL,NULL),(27,12,2,321,2982.75,'2015-09-19',NULL,NULL),(28,13,1,334,3112.69,'2015-08-23',NULL,NULL),(29,20,1,232,34.33,'2015-08-23',NULL,NULL),(30,19,2,123,23.21,'2014-10-12',NULL,NULL),(31,15,2,234,211.2,'2014-10-12',NULL,NULL),(32,14,2,532,32.66,'2015-08-23',NULL,NULL);
/*!40000 ALTER TABLE `chekue` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `letter`
--

DROP TABLE IF EXISTS `letter`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `letter` (
  `idLetter` int(11) NOT NULL AUTO_INCREMENT,
  `datePrinted` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `dateRecieved` date NOT NULL,
  `letterNum` int(11) NOT NULL,
  `idCheck` int(11) NOT NULL,
  PRIMARY KEY (`idLetter`),
  UNIQUE KEY `idLetter_UNIQUE` (`idLetter`),
  KEY `fk_Letter_Check1_idx` (`idCheck`),
  CONSTRAINT `fk_Letter_Check1` FOREIGN KEY (`idCheck`) REFERENCES `chekue` (`idCheck`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `letter`
--

LOCK TABLES `letter` WRITE;
/*!40000 ALTER TABLE `letter` DISABLE KEYS */;
/*!40000 ALTER TABLE `letter` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `staff`
--

DROP TABLE IF EXISTS `staff`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `staff` (
  `idStaff` int(11) NOT NULL AUTO_INCREMENT,
  `fName` varchar(60) NOT NULL,
  `lName` varchar(60) NOT NULL,
  `username` varchar(45) NOT NULL,
  `password` char(60) NOT NULL,
  `email` varchar(255) NOT NULL,
  `accessLevel` int(11) NOT NULL,
  `creationDate` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`idStaff`),
  UNIQUE KEY `idStaff_UNIQUE` (`idStaff`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `staff`
--

LOCK TABLES `staff` WRITE;
/*!40000 ALTER TABLE `staff` DISABLE KEYS */;
INSERT INTO `staff` VALUES (1,'Nathan','Babcock','nbabcock','password','natecomp@gmail.com',1,'2015-10-10 04:00:00'),(4,'Ashley','Lane','alane','password','alane@bju.edu',1,'2015-10-13 04:00:00'),(5,'Fredy','Whatley','fwhatley','password','fwhatley@bju.edu',1,'2015-10-14 04:00:00'),(6,'Joel','Sampson​','jsamson','password','jsamson@bju.edu',1,'2015-10-16 04:00:00');
/*!40000 ALTER TABLE `staff` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `store`
--

DROP TABLE IF EXISTS `store`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `store` (
  `idStore` int(11) NOT NULL AUTO_INCREMENT,
  `idStoreGroup` int(11) NOT NULL,
  `sName` varchar(45) NOT NULL,
  `address` varchar(255) NOT NULL,
  `city` varchar(45) NOT NULL,
  `state` varchar(2) NOT NULL,
  `zipcode` int(5) NOT NULL,
  PRIMARY KEY (`idStore`),
  UNIQUE KEY `idStore_UNIQUE` (`idStore`),
  KEY `fk_Store_StoreGroup1_idx` (`idStoreGroup`),
  CONSTRAINT `fk_Store_StoreGroup1` FOREIGN KEY (`idStoreGroup`) REFERENCES `storegroup` (`idStoreGroup`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `store`
--

LOCK TABLES `store` WRITE;
/*!40000 ALTER TABLE `store` DISABLE KEYS */;
INSERT INTO `store` VALUES (1,1,'Greenville 1','Test','Greenville','SC',29617),(2,1,'Greer 1','Test','Greer','SC',29614);
/*!40000 ALTER TABLE `store` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `storegroup`
--

DROP TABLE IF EXISTS `storegroup`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `storegroup` (
  `idStoreGroup` int(11) NOT NULL AUTO_INCREMENT,
  `region` varchar(45) NOT NULL,
  `serviceCharge` float NOT NULL,
  PRIMARY KEY (`idStoreGroup`),
  UNIQUE KEY `idStoreGroup_UNIQUE` (`idStoreGroup`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `storegroup`
--

LOCK TABLES `storegroup` WRITE;
/*!40000 ALTER TABLE `storegroup` DISABLE KEYS */;
INSERT INTO `storegroup` VALUES (1,'South Carolina',15);
/*!40000 ALTER TABLE `storegroup` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2015-10-30 19:43:14
