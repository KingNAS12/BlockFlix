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
('C000002', 'MovieFan1', '2026-06-01', 'sarah.jones@email.com', 'Sarah', 'Jones', 'F', '1998-07-22', 54321, '111 St SW', 'YEG', 'AB', 'T6W2B2', 'MC1002', 4),
('C000003', 'Cinema88', '2026-06-01', 'michael.lee@email.com', 'Michael', 'Lee', 'M', '1989-11-10', 10001, '50 Ave NW', 'YEG', 'AB', 'T5K3C3', 'AMEX1003', 3),
('C000004', 'DramaKing', '2026-06-01', 'emily.davis@email.com', 'Emily', 'Davis', 'F', '2000-05-18', 22222, '75 St NW', 'YEG', 'AB', 'T5N4D4', 'VISA1004', 5),
('C000005', 'ActionGuy', '2026-06-01', 'daniel.brown@email.com', 'Daniel', 'Brown', 'M', '1993-09-08', 33333, '82 Ave SW', 'YEG', 'AB', 'T6R5E5', 'MC1005', 4),
('C000006', 'Comedy123', '2026-06-01', 'olivia.wilson@email.com', 'Olivia', 'Wilson', 'F', '1997-01-30', 44444, '170 St NW', 'YEG', 'AB', 'T5T6F6', 'VISA1006', 5),
('C000007', 'Blockflix7', '2026-06-01', 'james.taylor@email.com', 'James', 'Taylor', 'M', '1985-12-12', 55555, '23 Ave NW', 'YEG', 'AB', 'T6K7G7', 'AMEX1007', 2),
('C000008', 'MovieBuff', '2026-06-01', 'ava.martin@email.com', 'Ava', 'Martin', 'F', '2001-04-02', 11111, '34 St SW', 'YEG', 'AB', 'T6X8H8', 'MC1008', 4),  
('C000009', 'RentalPro', '2026-06-01', 'ethan.thomas@email.com', 'Ethan', 'Thomas', 'M', '1990-08-25', 66666, '142 St NW', 'YEG', 'AB', 'T5P9J9', 'VISA1009', 3),
('C000010', 'FilmLover', '2026-06-01', 'mia.anderson@email.com', 'Mia', 'Anderson', 'F', '1999-06-14', 77777, '87 Ave NW', 'YEG', 'AB', 'T6E1K1', 'MC1010', 5),

('C000011','xR7!mK92','2025-08-14','liamw94@gmail.com','Liam','Walker','M','1994-04-11',4821,'45 Ave NW','YEG','AB','T5A1B1','VISA1011',NULL),
('C000012','BlueFox#21','2026-01-22','emma.hall88@yahoo.ca','Emma','Hall','F','1997-09-08',917,'67 St NW','YEG','AB','T5A1B2','MC1012',4),
('C000013','N0va$Tree','2024-11-03','nyoung13@outlook.com','Noah','Young','M','1992-12-03',12844,'89 Ave NW','YEG','AB','T5A1B3','VISA1013',5),
('C000014','Tiger!88A','2025-06-19','soph.king99@gmail.com','Sophia','King','F','1999-06-18',350,'90 St NW','YEG','AB','T5A1B4','MC1014',NULL),
('C000015','Jup1ter@55','2026-02-08','lucas.scott88@yahoo.ca','Lucas','Scott','M','1988-08-25',7856,'34 Ave SW','YEG','AB','T5A1B5','AMEX1015',3),
('C000016','Cedar%26','2024-09-27','isagreen77@hotmail.com','Isabella','Green','F','2000-11-14',22017,'75 St SW','YEG','AB','T5A1B6','VISA1016',5),
('C000017','Moon!741','2025-12-02','ethan.adams91@gmail.com','Ethan','Adams','M','1991-01-09',641,'51 Ave NW','YEG','AB','T5A1B7','MC1017',2),
('C000018','River@321','2024-07-15','mia.baker96@outlook.com','Mia','Baker','F','1996-07-07',9325,'102 St NW','YEG','AB','T5A1B8','VISA1018',NULL),
('C000019','Maple#908','2025-04-04','jcarter87@yahoo.ca','James','Carter','M','1987-03-30',18420,'170 St NW','YEG','AB','T5A1B9','MC1019',4),
('C000020','Orbit!45','2026-03-12','ava.mitchell01@gmail.com','Ava','Mitchell','F','2001-10-21',2755,'23 Ave SW','YEG','AB','T5A1C0','VISA1020',5),

('C000021','Raven$19','2025-01-05','ben.parker95@hotmail.com','Ben','Parker','M','1995-02-17',8643,'91 St NW','YEG','AB','T5B2C1','MC1021',3),
('C000022','Pixel#72','2024-12-11','chloe.morris98@gmail.com','Chloe','Morris','F','1998-05-06',571,'40 Ave NW','YEG','AB','T5B2C2','VISA1022',NULL),
('C000023','Falcon@3','2025-09-30','logan.reed89@outlook.com','Logan','Reed','M','1989-12-19',14788,'63 St SW','YEG','AB','T5B2C3','AMEX1023',2),
('C000024','Snow!884','2026-04-01','grace.turner02@yahoo.ca','Grace','Turner','F','2002-03-04',982,'12 Ave NW','YEG','AB','T5B2C4','MC1024',5),
('C000025','Echo%615','2024-08-22','henry.cooper90@gmail.com','Henry','Cooper','M','1990-07-29',22345,'99 St NW','YEG','AB','T5B2C5','VISA1025',4),
('C000026','Blaze#44','2025-02-16','zoe.bailey97@hotmail.com','Zoe','Bailey','F','1997-09-13',4402,'36 Ave SW','YEG','AB','T5B2C6','MC1026',NULL),
('C000027','Mint@202','2026-05-07','owen.foster93@outlook.com','Owen','Foster','M','1993-06-20',1777,'84 St NW','YEG','AB','T5B2C7','VISA1027',1),
('C000028','Cloud!76','2025-10-18','lily.bennett00@gmail.com','Lily','Bennett','F','2000-01-15',30111,'28 Ave NW','YEG','AB','T5B2C8','AMEX1028',4),
('C000029','Wolf$509','2024-06-09','mason.hughes86@yahoo.ca','Mason','Hughes','M','1986-11-02',664,'57 St SW','YEG','AB','T5B2C9','MC1029',NULL),
('C000030','Nova!333','2025-07-27','ella.ward03@gmail.com','Ella','Ward','F','2003-04-09',11897,'15 Ave NW','YEG','AB','T5B2D0','VISA1030',5),

('C000031','Sky@741','2024-10-13','jack.brooks91@hotmail.com','Jack','Brooks','M','1991-08-08',2222,'44 St NW','YEG','AB','T5C3D1','MC1031',3),
('C000032','Storm#17','2025-03-05','hannah.price99@gmail.com','Hannah','Price','F','1999-09-21',9345,'72 Ave SW','YEG','AB','T5C3D2','VISA1032',5),
('C000033','Iron!88','2026-02-20','aiden.long94@outlook.com','Aiden','Long','M','1994-12-11',120,'108 St NW','YEG','AB','T5C3D3','AMEX1033',NULL),
('C000034','Drift@52','2025-11-09','scarlett.ross01@yahoo.ca','Scarlett','Ross','F','2001-06-07',44117,'19 Ave SW','YEG','AB','T5C3D4','MC1034',2),
('C000035','Peak$610','2024-05-17','gabriel.gray88@gmail.com','Gabriel','Gray','M','1988-10-25',7891,'33 St NW','YEG','AB','T5C3D5','VISA1035',4),
('C000036','Frost#94','2026-01-14','nora.bell97@hotmail.com','Nora','Bell','F','1997-07-18',5022,'88 Ave NW','YEG','AB','T5C3D6','MC1036',5),
('C000037','Flash!12','2025-08-30','caleb.cook92@gmail.com','Caleb','Cook','M','1992-05-02',31765,'121 St SW','YEG','AB','T5C3D7','VISA1037',1),
('C000038','Quest@66','2024-09-11','victoria.reid00@outlook.com','Victoria','Reid','F','2000-08-12',611,'54 Ave NW','YEG','AB','T5C3D8','AMEX1038',NULL),
('C000039','Ruby#802','2025-04-22','leo.hayes95@yahoo.ca','Leo','Hayes','M','1995-11-28',10455,'14 St NW','YEG','AB','T5C3D9','MC1039',3),
('C000040','Oak!491','2026-03-18','ruby.hunt02@gmail.com','Ruby','Hunt','F','2002-01-30',776,'97 Ave SW','YEG','AB','T5C3E0','VISA1040',5),

('C000041','Delta@77','2025-02-11','julian.perry89@hotmail.com','Julian','Perry','M','1989-04-14',19874,'61 St NW','YEG','AB','T5D4E1','MC1041',4),
('C000042','Swift#23','2024-11-25','layla.kelly01@gmail.com','Layla','Kelly','F','2001-09-05',3450,'82 Ave NW','YEG','AB','T5D4E2','VISA1042',NULL),
('C000043','Comet!71','2025-06-02','connor.russell93@outlook.com','Connor','Russell','M','1993-07-22',827,'20 Ave SW','YEG','AB','T5D4E3','AMEX1043',2),
('C000044','Wave$88','2026-04-17','stella.wood99@yahoo.ca','Stella','Wood','F','1999-10-16',24561,'47 St NW','YEG','AB','T5D4E4','MC1044',5),
('C000045','Forge@51','2025-09-08','nathan.mills90@gmail.com','Nathan','Mills','M','1990-03-08',950,'73 Ave NW','YEG','AB','T5D4E5','VISA1045',3),
('C000046','Aurora#9','2024-07-29','madison.fisher98@hotmail.com','Madison','Fisher','F','1998-12-27',11800,'11 St SW','YEG','AB','T5D4E6','MC1046',NULL),
('C000047','Shadow!4','2026-01-03','carter.west94@gmail.com','Carter','West','M','1994-08-15',6654,'38 Ave NW','YEG','AB','T5D4E7','VISA1047',5),
('C000048','Zen@731','2025-05-12','penelope.bryant00@outlook.com','Penelope','Bryant','F','2000-05-03',29991,'93 St NW','YEG','AB','T5D4E8','AMEX1048',1),
('C000049','Pine#801','2024-10-08','isaac.hamilton91@yahoo.ca','Isaac','Hamilton','M','1991-02-24',177,'64 Ave SW','YEG','AB','T5D4E9','MC1049',4),
('C000050','Rocket!92','2026-05-28','zoey.ramirez03@gmail.com','Zoey','Ramirez','F','2003-11-10',4127,'24 St NW','YEG','AB','T5D4F0','VISA1050',5);

GO

SELECT * FROM Customers;