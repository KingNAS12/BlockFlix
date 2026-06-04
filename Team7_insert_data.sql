-- Team 7: BlockFlix
    -- Nathan Alex Sequeira (3141620)
    -- Dominic Evans ()
    -- Nima Houshyar ()
    -- Sashwat ()
-- CMPT 291 Lab 10

USE CMPT291_Team7_MovieRental;
GO

--Part E : 

--CUSTOMERS
INSERT INTO Customers ( accountNumber, [password], accountCreationDate, email, firstName,
lastName, gender, dob, houseNumber, street, city, province, postalCode, paymentIdentifier, customerRating)

VALUES

('C000001', 'Pass1234', '2026-06-01', 'john.smith@email.com','John', 'Smith', 'M', '1995-03-15',12345, '98 Ave NW', 'YEG', 'AB', 'T5J1A1', 'VISA1001', 5),
('C000002', 'MovieFan1', '2026-06-01', 'tom.jones@email.com', 'Tom', 'Jones', 'M', '1998-07-22', 54321, '111 St SW', 'YEG', 'AB', 'T6W2B2', 'MC1002', 4),
('C000003', 'Cinema88', '2026-06-01', 'dick.grayson@email.com', 'Dick', 'Grayson', 'M', '1989-11-10', 10001, '50 Ave NW', 'YEG', 'AB', 'T5K3C3', 'AMEX1003', 3),
('C000004', 'DramaKing', '2026-06-01', 'harry.osborn@email.com', 'Harry', 'Osborn', 'M', '2000-05-18', 22222, '75 St NW', 'YEG', 'AB', 'T5N4D4', 'VISA1004', 5),
('C000005', 'ActionGuy', '2026-06-01', 'danny.cross@email.com', 'Daniel', 'Cross', 'M', '1993-09-08', 33333, '82 Ave SW', 'YEG', 'AB', 'T6R5E5', 'MC1005', 4),
('C000006', 'Comedy123', '2026-06-01', 'olivia.octavius@email.com', 'Olivia', 'Octavius', 'F', '1997-01-30', 44444, '170 St NW', 'YEG', 'AB', 'T5T6F6', 'VISA1006', 5),
('C000007', 'Blockflix7', '2026-06-01', 'bond007@email.com', 'James', 'Bond', 'M', '1985-12-12', 55555, '23 Ave NW', 'YEG', 'AB', 'T6K7G7', 'AMEX1007', 2),
('C000008', 'MovieBuff', '2026-06-01', 'ava.ayala@email.com', 'Ava', 'Ayala', 'F', '2001-04-02', 11111, '34 St SW', 'YEG', 'AB', 'T6X8H8', 'MC1008', 4),  
('C000009', 'RentalPro', '2026-06-01', 'ethan.hunt@email.com', 'Ethan', 'Thomas', 'M', '1990-08-25', 66666, '142 St NW', 'YEG', 'AB', 'T5P9J9', 'VISA1009', 3),
('C000010', 'FilmLover', '2026-06-01', 'mia.anderson@email.com', 'Mia', 'Anderson', 'F', '1999-06-14', 77777, '87 Ave NW', 'YEG', 'AB', 'T6E1K1', 'MC1010', 5),

('C000011','xR7!mK92','2025-08-14','liamh94@gmail.com','Liam','McHugh','M','1994-04-11',4821,'45 Ave NW','YEG','AB','T5A1B1','VISA1011',NULL),
('C000012','BlueFox#21','2026-01-22','emma.frost88@yahoo.ca','Emma','Frost','F','1997-09-08',917,'67 St NW','YEG','AB','T5A1B2','MC1012',4),
('C000013','N0va$Tree','2024-11-03','nhelsing13@outlook.com','Noah','Helsing','M','1992-12-03',12844,'89 Ave NW','YEG','AB','T5A1B3','VISA1013',5),
('C000014','Tiger!88A','2025-06-19','sophia.petrillo99@gmail.com','Sophia','Petrillo','F','1999-06-18',350,'90 St NW','YEG','AB','T5A1B4','MC1014',NULL),
('C000015','Jup1ter@55','2026-02-08','lucas.skywalker88@yahoo.ca','Lucas','Skywalker','M','1988-08-25',7856,'34 Ave SW','YEG','AB','T5A1B5','AMEX1015',3),
('C000016','Cedar%26','2024-09-27','isagsn77@hotmail.com','Isabella','Garcia-Shapiro','F','2000-11-14',22017,'75 St SW','YEG','AB','T5A1B6','VISA1016',5),
('C000017','Moon!741','2025-12-02','ethan.winters91@gmail.com','Ethan','Winters','M','1991-01-09',641,'51 Ave NW','YEG','AB','T5A1B7','MC1017',2),
('C000018','River@321','2024-07-15','mia.toretto96@outlook.com','Mia','Toretto','F','1996-07-07',9325,'102 St NW','YEG','AB','T5A1B8','VISA1018',NULL),
('C000019','Maple#908','2025-04-04','jkirk87@yahoo.ca','James','Kirk','M','1987-03-30',18420,'170 St NW','YEG','AB','T5A1B9','MC1019',4),
('C000020','Orbit!45','2026-03-12','ava.sharpe01@gmail.com','Ava','Sharpe','F','2001-10-21',2755,'23 Ave SW','YEG','AB','T5A1C0','VISA1020',5),

('C000021','Raven$19','2025-01-05','ben.parker95@hotmail.com','Ben','Parker','M','1995-02-17',8643,'91 St NW','YEG','AB','T5B2C1','MC1021',3),
('C000022','Pixel#72','2024-12-11','chloe.sullivan98@gmail.com','Chloe','Sullivan','F','1998-05-06',571,'40 Ave NW','YEG','AB','T5B2C2','VISA1022',NULL),
('C000023','Falcon@3','2025-09-30','logan.howlett89@outlook.com','Logan','Howlett','M','1989-12-19',14788,'63 St SW','YEG','AB','T5B2C3','AMEX1023',2),
('C000024','Snow!884','2026-04-01','grace.ashcroft02@yahoo.ca','Grace','Ashcroft','F','2002-03-04',982,'12 Ave NW','YEG','AB','T5B2C4','MC1024',5),
('C000025','Echo%615','2024-08-22','henry.turner90@gmail.com','Henry','Turner','M','1990-07-29',22345,'99 St NW','YEG','AB','T5B2C5','VISA1025',4),
('C000026','Blaze#44','2025-02-16','zoe.nightshade97@hotmail.com','Zoe','Nightshade','F','1997-09-13',4402,'36 Ave SW','YEG','AB','T5B2C6','MC1026',NULL),
('C000027','Mint@202','2026-05-07','owen.grady93@outlook.com','Owen','Grady','M','1993-06-20',1777,'84 St NW','YEG','AB','T5B2C7','VISA1027',1),
('C000028','Cloud!76','2025-10-18','lily.potter00@gmail.com','Lily','Potter','F','2000-01-15',30111,'28 Ave NW','YEG','AB','T5B2C8','AMEX1028',4),
('C000029','Wolf$509','2024-06-09','mason.marmaduke86@yahoo.ca','Mason','Marmaduke','M','1986-11-02',664,'57 St SW','YEG','AB','T5B2C9','MC1029',NULL),
('C000030','Nova!333','2025-07-27','ella.ward03@gmail.com','Ella','Lopez','F','2003-04-09',11897,'15 Ave NW','YEG','AB','T5B2D0','VISA1030',5),

('C000031','Sky@741','2024-10-13','jack.frost91@hotmail.com','Jack','Frost','M','1991-08-08',2222,'44 St NW','YEG','AB','T5C3D1','MC1031',3),
('C000032','Storm#17','2025-03-05','hannah.montana99@gmail.com','Hannah','Montana','F','1999-09-21',9345,'72 Ave SW','YEG','AB','T5C3D2','VISA1032',5),
('C000033','Iron!88','2026-02-20','aiden.pearce94@outlook.com','Aiden','Pearce','M','1994-12-11',120,'108 St NW','YEG','AB','T5C3D3','AMEX1033',NULL),
('C000034','Drift@52','2025-11-09','scarlett.ohara01@yahoo.ca','Scarlett','OHara','F','2001-06-07',44117,'19 Ave SW','YEG','AB','T5C3D4','MC1034',2),
('C000035','Peak$610','2024-05-17','gabriel.iglesias88@gmail.com','Gabriel','Iglesias','M','1988-10-25',7891,'33 St NW','YEG','AB','T5C3D5','VISA1035',4),
('C000036','Frost#94','2026-01-14','nora.allen97@hotmail.com','Nora','Allen','F','1997-07-18',5022,'88 Ave NW','YEG','AB','T5C3D6','MC1036',5),
('C000037','Flash!12','2025-08-30','caleb.summers92@gmail.com','Caleb','Summers','M','1992-05-02',31765,'121 St SW','YEG','AB','T5C3D7','VISA1037',1),
('C000038','Quest@66','2024-09-11','victoria.justice00@outlook.com','Victoria','Justice','F','2000-08-12',611,'54 Ave NW','YEG','AB','T5C3D8','AMEX1038',NULL),
('C000039','Ruby#802','2025-04-22','leo.valdez95@yahoo.ca','Leo','Valdez','M','1995-11-28',10455,'14 St NW','YEG','AB','T5C3D9','MC1039',3),
('C000040','Oak!491','2026-03-18','ruby.hale02@gmail.com','Ruby','Hale','F','2002-01-30',776,'97 Ave SW','YEG','AB','T5C3E0','VISA1040',5),

('C000041','Delta@77','2025-02-11','julian.luthor89@hotmail.com','Julian','Luthor','M','1989-04-14',19874,'61 St NW','YEG','AB','T5D4E1','MC1041',4),
('C000042','Swift#23','2024-11-25','layla.hassan01@gmail.com','Layla','Hassan','F','2001-09-05',3450,'82 Ave NW','YEG','AB','T5D4E2','VISA1042',NULL),
('C000043','Comet!71','2025-06-02','connor.connor93@outlook.com','Connor','Kenway','M','1993-07-22',827,'20 Ave SW','YEG','AB','T5D4E3','AMEX1043',2),
('C000044','Wave$88','2026-04-17','stella.kowalski99@yahoo.ca','Stella','Kowalski','F','1999-10-16',24561,'47 St NW','YEG','AB','T5D4E4','MC1044',5),
('C000045','Forge@51','2025-09-08','nathan.summers90@gmail.com','Nathan','Summers','M','1990-03-08',950,'73 Ave NW','YEG','AB','T5D4E5','VISA1045',3),
('C000046','Aurora#9','2024-07-29','madison.rooney98@hotmail.com','Madison','Rooney','F','1998-12-27',11800,'11 St SW','YEG','AB','T5D4E6','MC1046',NULL),
('C000047','Shadow!4','2026-01-03','carter.kane94@gmail.com','Carter','Kane','M','1994-08-15',6654,'38 Ave NW','YEG','AB','T5D4E7','VISA1047',5),
('C000048','Zen@731','2025-05-12','penelope.cruz00@outlook.com','Penelope','Cruz','F','2000-05-03',29991,'93 St NW','YEG','AB','T5D4E8','AMEX1048',1),
('C000049','Pine#801','2024-10-08','isaac.lahey91@yahoo.ca','Isaac','Lahey','M','1991-02-24',177,'64 Ave SW','YEG','AB','T5D4E9','MC1049',4),
('C000050','Rocket!92','2026-05-28','zoey.howzer03@gmail.com','Zoey','Howzer','F','2003-11-10',4127,'24 St NW','YEG','AB','T5D4F0','VISA1050',5);


SELECT * FROM Customers;

--Employees

INSERT INTO Employee
(employeeID, [password], [sin],
 firstName, lastName, gender, dob,
 houseNumber, street, city, province, postalCode,
 startDate, endDate, employeeRating)
VALUES

('E000001','Admin#42',123456,
 'Nathan','Sequeira','M','1998-05-14',
 8421,'98 Ave NW','YEG','AB','T5A1A1',
 '2024-01-15',NULL,5),

('E000002','Block!77',234567,
 'Dominic','Evans','M','1997-08-22',
 1175,'75 St NW','YEG','AB','T5A1A2',
 '2024-03-01',NULL,4),

('E000003','Movie@91',345678,
 'Nima','Houshyar','M','1993-11-14',
 22217,'170 St SW','YEG','AB','T5A1A3',
 '2024-06-10',NULL,5),

('E000004','Cinema#55',456789,
 'Sashwat','Patel','M','1999-02-08',
 905,'111 Ave NW','YEG','AB','T5A1A4',
 '2025-01-08',NULL,4),

('E000005','Rental$88',567890,
 'Sheikh','Abdullah','M','1986-09-17',
 15643,'23 St SW','YEG','AB','T5A1A5',
 '2025-04-20',NULL,NULL);

 SELECT * FROM Employee;


