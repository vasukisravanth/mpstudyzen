/*
SQLyog Ultimate v8.55 
MySQL - 5.1.36-community : Database - materialboard
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`materialboard` /*!40100 DEFAULT CHARACTER SET latin1 */;

USE `materialboard`;

/*Table structure for table `deptadmin` */

DROP TABLE IF EXISTS `deptadmin`;

CREATE TABLE `deptadmin` (
  `DAId` varchar(10) NOT NULL,
  `DeptId` int(11) DEFAULT NULL,
  `Password` varchar(10) DEFAULT NULL,
  PRIMARY KEY (`DAId`),
  KEY `FK_deptadmin` (`DeptId`),
  CONSTRAINT `FK_deptadmin` FOREIGN KEY (`DeptId`) REFERENCES `deptmaster` (`DeptId`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `deptadmin` */

insert  into `deptadmin`(`DAId`,`DeptId`,`Password`) values ('BECS7543',1,'123'),('BEIS0802',2,'BEIS123');

/*Table structure for table `deptmaster` */

DROP TABLE IF EXISTS `deptmaster`;

CREATE TABLE `deptmaster` (
  `DeptId` int(11) NOT NULL AUTO_INCREMENT,
  `DeptName` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`DeptId`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;

/*Data for the table `deptmaster` */

insert  into `deptmaster`(`DeptId`,`DeptName`) values (1,'BE-CS'),(2,'BE-IS'),(3,'BE-EE'),(4,'BE-EC');

/*Table structure for table `generalquestion` */

DROP TABLE IF EXISTS `generalquestion`;

CREATE TABLE `generalquestion` (
  `GQId` int(11) NOT NULL AUTO_INCREMENT,
  `UId` varchar(100) DEFAULT NULL,
  `QuestionName` varchar(1000) DEFAULT NULL,
  `UserType` varchar(100) DEFAULT NULL,
  `PostDate` varchar(20) DEFAULT NULL,
  `Status` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`GQId`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

/*Data for the table `generalquestion` */

insert  into `generalquestion`(`GQId`,`UId`,`QuestionName`,`UserType`,`PostDate`,`Status`) values (1,'4ni19cs060','General Question 1','Student','2023-05-19 18:39:02','Active');

/*Table structure for table `gqreply` */

DROP TABLE IF EXISTS `gqreply`;

CREATE TABLE `gqreply` (
  `GQRId` int(11) NOT NULL AUTO_INCREMENT,
  `GQId` int(11) DEFAULT NULL,
  `UId` varchar(100) DEFAULT NULL,
  `QuestionReply` varchar(8000) DEFAULT NULL,
  `UserType` varchar(100) DEFAULT NULL,
  `ReplyDate` varchar(20) DEFAULT NULL,
  `Status` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`GQRId`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

/*Data for the table `gqreply` */

insert  into `gqreply`(`GQRId`,`GQId`,`UId`,`QuestionReply`,`UserType`,`ReplyDate`,`Status`) values (1,1,'BECS2022101','General Question Reply','Student','19-05-2023 19:00:24','Active');

/*Table structure for table `lecturemaster` */

DROP TABLE IF EXISTS `lecturemaster`;

CREATE TABLE `lecturemaster` (
  `LectureId` int(11) NOT NULL AUTO_INCREMENT,
  `DeptId` int(11) DEFAULT NULL,
  `LectureName` varchar(100) DEFAULT NULL,
  `Password` varchar(2000) DEFAULT NULL,
  `EmailId` varchar(100) DEFAULT NULL,
  `Status` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`LectureId`),
  KEY `FK_lecturemaster` (`DeptId`),
  CONSTRAINT `FK_lecturemaster` FOREIGN KEY (`DeptId`) REFERENCES `deptmaster` (`DeptId`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;

/*Data for the table `lecturemaster` */

insert  into `lecturemaster`(`LectureId`,`DeptId`,`LectureName`,`Password`,`EmailId`,`Status`) values (1,1,'Suhasini','WoSPm3gFBYHNKIi3HIWg2g==','Suhasini@nie.ac.in','Approve'),(3,2,'Vasu','6673','4ni19cs060_a@nie.ac.in','Pending'),(4,1,'Adana','2002','4ni19cs011_a@nie.ac.in','Approve');

/*Table structure for table `materialmaster` */

DROP TABLE IF EXISTS `materialmaster`;

CREATE TABLE `materialmaster` (
  `MMId` int(11) NOT NULL AUTO_INCREMENT,
  `UId` varchar(100) DEFAULT NULL,
  `SubjectId` int(11) DEFAULT NULL,
  `UserType` varchar(50) DEFAULT NULL,
  `MaterialName` varchar(1000) DEFAULT NULL,
  `Description` varchar(2000) DEFAULT NULL,
  `FilePath` varchar(1000) DEFAULT NULL,
  `UploadDate` varchar(100) DEFAULT NULL,
  `ViewCount` int(11) DEFAULT NULL,
  `SpamCount` int(11) DEFAULT NULL,
  `RatePoint` varchar(10) DEFAULT NULL,
  `Status` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`MMId`),
  KEY `FK_materialmaster` (`SubjectId`),
  CONSTRAINT `FK_materialmaster` FOREIGN KEY (`SubjectId`) REFERENCES `subjectmaster` (`SubjectId`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

/*Data for the table `materialmaster` */

insert  into `materialmaster`(`MMId`,`UId`,`SubjectId`,`UserType`,`MaterialName`,`Description`,`FilePath`,`UploadDate`,`ViewCount`,`SpamCount`,`RatePoint`,`Status`) values (1,'4ni19cs060',4,'Student','DBMS Notes','Database management system is a software which is used to manage the database.','~/MaterialFiles/DBMS Notes_8747.txt','17-05-2023',2,1,'3.75','Active'),(2,'4ni19cs060',2,'Student','C Program','C is a general-purpose computer programming language','~/MaterialFiles/C Program_4664.jpg','17-05-2023',0,0,'0','Active');

/*Table structure for table `materialquery` */

DROP TABLE IF EXISTS `materialquery`;

CREATE TABLE `materialquery` (
  `MQId` int(11) NOT NULL AUTO_INCREMENT,
  `MMId` int(11) DEFAULT NULL,
  `UId` varchar(100) DEFAULT NULL,
  `UserType` varchar(50) DEFAULT NULL,
  `PostQuery` varchar(1000) DEFAULT NULL,
  `PostDate` datetime DEFAULT NULL,
  `Status` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`MQId`),
  KEY `FK_materialquery` (`MMId`),
  CONSTRAINT `FK_materialquery` FOREIGN KEY (`MMId`) REFERENCES `materialmaster` (`MMId`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

/*Data for the table `materialquery` */

insert  into `materialquery`(`MQId`,`MMId`,`UId`,`UserType`,`PostQuery`,`PostDate`,`Status`) values (1,1,'BECS2022101','Student','Query 1','2023-05-17 13:52:20','Active');

/*Table structure for table `materialqueryreply` */

DROP TABLE IF EXISTS `materialqueryreply`;

CREATE TABLE `materialqueryreply` (
  `MQRId` int(11) NOT NULL AUTO_INCREMENT,
  `MQId` int(11) DEFAULT NULL,
  `UId` varchar(100) DEFAULT NULL,
  `UserType` varchar(50) DEFAULT NULL,
  `ReplyQuery` varchar(8000) DEFAULT NULL,
  `ReplyDate` varchar(50) DEFAULT NULL,
  `FilePath` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`MQRId`),
  KEY `FK_materialqueryreply` (`MQId`),
  CONSTRAINT `FK_materialqueryreply` FOREIGN KEY (`MQId`) REFERENCES `materialquery` (`MQId`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

/*Data for the table `materialqueryreply` */

insert  into `materialqueryreply`(`MQRId`,`MQId`,`UId`,`UserType`,`ReplyQuery`,`ReplyDate`,`FilePath`) values (1,1,'BECS2022102','Student','Query 1 Reply','17-05-2023 14:12:31','');

/*Table structure for table `materialrate` */

DROP TABLE IF EXISTS `materialrate`;

CREATE TABLE `materialrate` (
  `MRId` int(11) NOT NULL AUTO_INCREMENT,
  `MMId` int(11) DEFAULT NULL,
  `UId` varchar(100) DEFAULT NULL,
  `UserType` varchar(50) DEFAULT NULL,
  `MRate` varchar(10) DEFAULT NULL,
  `RateDate` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`MRId`),
  KEY `FK_materialrate` (`MMId`),
  CONSTRAINT `FK_materialrate` FOREIGN KEY (`MMId`) REFERENCES `materialmaster` (`MMId`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

/*Data for the table `materialrate` */

insert  into `materialrate`(`MRId`,`MMId`,`UId`,`UserType`,`MRate`,`RateDate`) values (1,1,'BECS2022101','Student','4','24/05/2023'),(2,1,'BECS2022102','Student','3.5','24/05/2023');

/*Table structure for table `materialuserspam` */

DROP TABLE IF EXISTS `materialuserspam`;

CREATE TABLE `materialuserspam` (
  `MSUId` int(11) NOT NULL AUTO_INCREMENT,
  `MMId` int(11) DEFAULT NULL,
  `UId` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`MSUId`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

/*Data for the table `materialuserspam` */

insert  into `materialuserspam`(`MSUId`,`MMId`,`UId`) values (1,1,'BECS2022101');

/*Table structure for table `studentmaster` */

DROP TABLE IF EXISTS `studentmaster`;

CREATE TABLE `studentmaster` (
  `SUSN` varchar(20) NOT NULL,
  `StudentName` varchar(100) DEFAULT NULL,
  `Password` varchar(2000) DEFAULT NULL,
  `EmailId` varchar(100) DEFAULT NULL,
  `MUCount` int(11) DEFAULT NULL,
  `MRCount` int(11) DEFAULT NULL,
  `Status` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`SUSN`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `studentmaster` */

insert  into `studentmaster`(`SUSN`,`StudentName`,`Password`,`EmailId`,`MUCount`,`MRCount`,`Status`) values ('4ni19cs011','Adana','9615','4ni19cs011_a@nie.ac.in',0,0,'Active'),('4ni19cs060','Vasuki','WoSPm3gFBYHNKIi3HIWg2g==','4ni19cs060_a@nie.ac.in',2,0,'Active'),('BECS2022101','Kruthan','WoSPm3gFBYHNKIi3HIWg2g==','BECS2022101@nie.ac.in',0,0,'Active'),('BECS2022102','Suhasini','WoSPm3gFBYHNKIi3HIWg2g==','BECS2022102@nie.ac.in',0,1,'Active'),('BECS2022103','Guru','WoSPm3gFBYHNKIi3HIWg2g==','BECS2022103@nie.ac.in',0,0,'Active'),('BECS2022104','Veena','123','BECS2022104@nie.ac.in',0,0,'Active'),('BECS2022105','Vidya','123','BECS2022105@nie.ac.in',0,0,'Active'),('BECS2022106','Sachin','123','BECS2022106@nie.ac.in',0,0,'Active');

/*Table structure for table `subjectmaster` */

DROP TABLE IF EXISTS `subjectmaster`;

CREATE TABLE `subjectmaster` (
  `SubjectId` int(11) NOT NULL AUTO_INCREMENT,
  `DeptId` int(11) DEFAULT NULL,
  `SubjectName` varchar(100) DEFAULT NULL,
  `Sem` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`SubjectId`),
  KEY `FK_subjectmaster` (`DeptId`),
  CONSTRAINT `FK_subjectmaster` FOREIGN KEY (`DeptId`) REFERENCES `deptmaster` (`DeptId`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;

/*Data for the table `subjectmaster` */

insert  into `subjectmaster`(`SubjectId`,`DeptId`,`SubjectName`,`Sem`) values (1,1,'Data Structures','1'),(2,1,'Programming C','2'),(3,2,'CG','1'),(4,1,'DBMS','3');

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
