-- Team 7: BlockFlix
    -- Nathan Alex Sequeira (3141620)
    -- Dominic Evans ()
    -- Nima Houshyar ()
    -- Sashwat Gujjar ()
-- CMPT 291 Lab 10

USE CMPT291_Team7_MovieRental;
GO

--Part E : 

--CUSTOMERS
INSERT INTO Customers ( accountNumber, [password], accountCreationDate, email, firstName,
lastName, gender, dob, houseNumber, street, city, province, postalCode, paymentIdentifier, customerRating)

VALUES

('C000001', 'Pass1234', '2026-06-01', 'john.smith@email.com','John', 'Smith', 'M', '1995-03-15',12345, '98 Ave NW', 'YEG', 'AB', 'T5J1A1', 'VISA1001', 5),
('C000002', 'MovieFan1', '2026-06-01', 'tom.jasper@email.com', 'Tom', 'Jasper', 'M', '1998-07-22', 54321, '111 St SW', 'YEG', 'AB', 'T6W2B2', 'MC1002', 4),
('C000003', 'Cinema88', '2026-06-01', 'dick.grayson@email.com', 'Dick', 'Grayson', 'M', '1989-11-10', 10001, '50 Ave NW', 'YEG', 'AB', 'T5K3C3', 'AMEX1003', 3),
('C000004', 'DramaKing', '2026-06-01', 'harry.osborn@email.com', 'Harry', 'Osborn', 'M', '2000-05-18', 22222, '75 St NW', 'YEG', 'AB', 'T5N4D4', 'VISA1004', 5),
('C000005', 'ActionGuy', '2026-06-01', 'danny.cross@email.com', 'Daniel', 'Cross', 'M', '1993-09-08', 33333, '82 Ave SW', 'YEG', 'AB', 'T6R5E5', 'MC1005', 4),
('C000006', 'Comedy123', '2026-06-01', 'olivia.octavius@email.com', 'Olivia', 'Octavius', 'F', '1997-01-30', 44444, '170 St NW', 'YEG', 'AB', 'T5T6F6', 'VISA1006', 5),
('C000007', 'Blockflix7', '2026-06-01', 'bond007@email.com', 'James', 'Bond', 'M', '1985-12-12', 55555, '23 Ave NW', 'YEG', 'AB', 'T6K7G7', 'AMEX1007', 2),
('C000008', 'MovieBuff', '2026-06-01', 'ava.ayala@email.com', 'Ava', 'Ayala', 'F', '2001-04-02', 11111, '34 St SW', 'YEG', 'AB', 'T6X8H8', 'MC1008', 4),  
('C000009', 'RentalPro', '2026-06-01', 'ethan.hunt@email.com', 'Ethan', 'Thomas', 'M', '1990-08-25', 66666, '142 St NW', 'YEG', 'AB', 'T5P9J9', 'VISA1009', 3),
('C000010', 'FilmLover', '2026-06-01', 'mia.queen@email.com', 'Mia', 'Queen', 'F', '1999-06-14', 77777, '87 Ave NW', 'YEG', 'AB', 'T6E1K1', 'MC1010', 5),

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
 'Sashwat','Gujjar','M','1999-02-08',
 905,'111 Ave NW','YEG','AB','T5A1A4',
 '2025-01-08',NULL,4),

('E000005','Rental$88',567890,
 'Sheikh','Abdullah','M','1986-09-17',
 15643,'23 St SW','YEG','AB','T5A1A5',
 '2025-04-20',NULL,NULL);

 SELECT * FROM Employee;

 --Movies

 INSERT INTO Movie
(movieID, movieName, genre, rentalFee, replacementFee, numberReplaced, numberRented)
VALUES
--Generated from AI
-- ACTION
('M000001','The Dark Knight','A',4.99,29.99,0,8),
('M000002','Mad Max Fury Road','A',4.49,24.99,1,10),
('M000003','John Wick','A',3.99,19.99,0,6),
('M000004','Mission Impossible Fallout','A',4.99,29.99,0,4),
('M000017','Gladiator','A',4.99,29.99,0,7),
('M000018','Die Hard','A',3.99,24.99,1,6),
('M000019','The Matrix','A',4.49,29.99,0,10),
('M000020','Superman','A',4.99,34.99,0,8),
('M000021','Black Panther','A',4.49,29.99,0,5),
('M000037','Avengers Endgame','A',4.99,34.99,0,10),

-- COMEDY
('M000005','Superbad','C',3.49,19.99,0,5),
('M000006','Step Brothers','C',3.99,24.99,0,7),
('M000007','The Hangover','C',4.49,24.99,0,9),
('M000008','21 Jump Street','C',3.99,19.99,0,3),
('M000022','Mean Girls','C',3.99,19.99,0,6),
('M000023','The Truman Show','C',4.49,24.99,0,4),
('M000024','Bridesmaids','C',3.99,19.99,0,7),
('M000025','Dumb and Dumber','C',3.49,19.99,1,5),
('M000026','School of Rock','C',3.99,24.99,0,3),
('M000038','Anchorman','C',3.99,24.99,0,6),

-- DRAMA
('M000009','The Shawshank Redemption','D',4.99,29.99,0,10),
('M000010','Forrest Gump','D',4.49,24.99,1,7),
('M000011','The Green Mile','D',3.99,19.99,0,4),
('M000012','A Beautiful Mind','D',3.99,19.99,0,2),
('M000027','Good Will Hunting','D',4.49,24.99,0,8),
('M000028','The Godfather','D',4.99,34.99,0,10),
('M000029','Fight Club','D',4.49,29.99,0,6),
('M000030','The Social Network','D',3.99,24.99,0,4),
('M000031','Interstellar','D',4.99,34.99,1,9),
('M000039','The Pursuit of Happyness','D',4.49,29.99,0,7),

-- FOREIGN
('M000013','Parasite','F',4.99,29.99,0,10),
('M000014','Amelie','F',3.99,24.99,0,3),
('M000015','Pan''s Labyrinth','F',4.49,24.99,0,5),
('M000016','Life Is Beautiful','F',4.99,29.99,0,8),
('M000032','Roma','F',4.49,24.99,0,3),
('M000033','Train to Busan','F',4.99,29.99,0,7),
('M000034','Crouching Tiger Hidden Dragon','F',4.49,29.99,0,5),
('M000035','The Lives of Others','F',3.99,24.99,0,2),
('M000036','City of God','F',4.99,29.99,0,6),
('M000040','Spirited Away','F',4.99,34.99,0,9);


SELECT genre, COUNT(*) AS NumberOfMovies
FROM Movie
GROUP BY genre;


--Actors
INSERT INTO Actor
(actorID, actorName, gender, dob)
VALUES
--Generated from AI

('A000001','Christian Bale','M','1974-01-30'),
('A000002','Heath Ledger','M','1979-04-04'),
('A000003','Tom Hardy','M','1977-09-15'),
('A000004','Charlize Theron','F','1975-08-07'),
('A000005','Keanu Reeves','M','1964-09-02'),
('A000006','Michael Nyqvist','M','1960-11-08'),
('A000007','Tom Cruise','M','1962-07-03'),
('A000008','Henry Cavill','M','1983-05-05'),
('A000009','Russell Crowe','M','1964-04-07'),
('A000010','Joaquin Phoenix','M','1974-10-28'),
('A000011','Bruce Willis','M','1955-03-19'),
('A000012','Alan Rickman','M','1946-02-21'),
('A000013','Laurence Fishburne','M','1961-07-30'),
('A000014','Christopher Reeve','M','1952-09-25'),
('A000015','Margot Kidder','F','1948-10-17'),
('A000016','Chadwick Boseman','M','1976-11-29'),
('A000017','Michael B. Jordan','M','1987-02-09'),
('A000018','Robert Downey Jr.','M','1965-04-04'),
('A000019','Chris Evans','M','1981-06-13'),
('A000020','Jonah Hill','M','1983-12-20'),
('A000021','Michael Cera','M','1988-06-07'),
('A000022','Will Ferrell','M','1967-07-16'),
('A000023','John C. Reilly','M','1965-05-24'),
('A000024','Bradley Cooper','M','1975-01-05'),
('A000025','Zach Galifianakis','M','1969-10-01'),
('A000026','Channing Tatum','M','1980-04-26'),
('A000027','Lindsay Lohan','F','1986-07-02'),
('A000028','Rachel McAdams','F','1978-11-17'),
('A000029','Jim Carrey','M','1962-01-17'),
('A000030','Laura Linney','F','1964-02-05'),
('A000031','Kristen Wiig','F','1973-08-22'),
('A000032','Melissa McCarthy','F','1970-08-26'),
('A000033','Jeff Daniels','M','1955-02-19'),
('A000034','Jack Black','M','1969-08-28'),
('A000035','Joan Cusack','F','1962-10-11'),
('A000036','Christina Applegate','F','1971-11-25'),
('A000037','Tim Robbins','M','1958-10-16'),
('A000038','Morgan Freeman','M','1937-06-01'),
('A000039','Tom Hanks','M','1956-07-09'),
('A000040','Robin Wright','F','1966-04-08'),
('A000041','Michael Clarke Duncan','M','1957-12-10'),
('A000042','Jennifer Connelly','F','1970-12-12'),
('A000043','Matt Damon','M','1970-10-08'),
('A000044','Robin Williams','M','1951-07-21'),
('A000045','Marlon Brando','M','1924-04-03'),
('A000046','Al Pacino','M','1940-04-25'),
('A000047','Brad Pitt','M','1963-12-18'),
('A000048','Edward Norton','M','1969-08-18'),
('A000049','Jesse Eisenberg','M','1983-10-05'),
('A000050','Andrew Garfield','M','1983-08-20'),
('A000051','Matthew McConaughey','M','1969-11-04'),
('A000052','Anne Hathaway','F','1982-11-12'),
('A000053','Will Smith','M','1968-09-25'),
('A000054','Jaden Smith','M','1998-07-08'),
('A000055','Song Kang-ho','M','1967-01-17'),
('A000056','Cho Yeo-jeong','F','1981-02-10'),
('A000057','Audrey Tautou','F','1976-08-09'),
('A000058','Mathieu Kassovitz','M','1967-08-03'),
('A000059','Ivana Baquero','F','1994-06-11'),
('A000060','Sergi Lopez','M','1965-12-22'),
('A000061','Roberto Benigni','M','1952-10-27'),
('A000062','Nicoletta Braschi','F','1960-04-19'),
('A000063','Yalitza Aparicio','F','1993-12-11'),
('A000064','Marina de Tavira','F','1974-11-21'),
('A000065','Gong Yoo','M','1979-07-10'),
('A000066','Jung Yu-mi','F','1983-01-18'),
('A000067','Chow Yun-fat','M','1955-05-18'),
('A000068','Michelle Yeoh','F','1962-08-06'),
('A000069','Ulrich Muhe','M','1953-06-20'),
('A000070','Martina Gedeck','F','1961-09-14'),
('A000071','Alexandre Rodrigues','M','1983-05-21'),
('A000072','Seu Jorge','M','1970-06-08'),
('A000073','Rumi Hiiragi','F','1987-08-01'),
('A000074','Miyu Irino','M','1988-02-19');


--CAST
INSERT INTO [Cast] (actorID, movieID)
VALUES
('A000001','M000001'),('A000002','M000001'),
('A000003','M000002'),('A000004','M000002'),
('A000005','M000003'),('A000006','M000003'),
('A000007','M000004'),('A000008','M000004'),
('A000009','M000017'),('A000010','M000017'),
('A000011','M000018'),('A000012','M000018'),
('A000005','M000019'),('A000013','M000019'),
('A000014','M000020'),('A000015','M000020'),
('A000016','M000021'),('A000017','M000021'),
('A000018','M000037'),('A000019','M000037'),

('A000020','M000005'),('A000021','M000005'),
('A000022','M000006'),('A000023','M000006'),
('A000024','M000007'),('A000025','M000007'),
('A000020','M000008'),('A000026','M000008'),
('A000027','M000022'),('A000028','M000022'),
('A000029','M000023'),('A000030','M000023'),
('A000031','M000024'),('A000032','M000024'),
('A000029','M000025'),('A000033','M000025'),
('A000034','M000026'),('A000035','M000026'),
('A000022','M000038'),('A000036','M000038'),

('A000037','M000009'),('A000038','M000009'),
('A000039','M000010'),('A000040','M000010'),
('A000039','M000011'),('A000041','M000011'),
('A000009','M000012'),('A000042','M000012'),
('A000043','M000027'),('A000044','M000027'),
('A000045','M000028'),('A000046','M000028'),
('A000047','M000029'),('A000048','M000029'),
('A000049','M000030'),('A000050','M000030'),
('A000051','M000031'),('A000052','M000031'),
('A000053','M000039'),('A000054','M000039'),

('A000055','M000013'),('A000056','M000013'),
('A000057','M000014'),('A000058','M000014'),
('A000059','M000015'),('A000060','M000015'),
('A000061','M000016'),('A000062','M000016'),
('A000063','M000032'),('A000064','M000032'),
('A000065','M000033'),('A000066','M000033'),
('A000067','M000034'),('A000068','M000034'),
('A000069','M000035'),('A000070','M000035'),
('A000071','M000036'),('A000072','M000036'),
('A000073','M000040'),('A000074','M000040');


SELECT
    Movie.movieID,
    Movie.movieName,
    Actor.actorID,
    Actor.actorName
FROM [Cast], Movie, Actor
WHERE [Cast].movieID = Movie.movieID
AND [Cast].actorID = Actor.actorID
ORDER BY Movie.movieID, Actor.actorName;





--Rental Orders

INSERT INTO RentalOrder
(rentalID, accountNumber, movieID, employeeID, movieRating, [status], checkoutDate, returnDate)
VALUES
('R000001','C000004','M000001','E000003',5,0,'2026-04-01','2026-04-08'),
('R000002','C000019','M000003','E000001',NULL,1,'2026-04-03','2026-04-10'),
('R000003','C000047','M000005','E000005',3,0,'2026-04-05','2026-04-12'),
('R000004','C000002','M000010','E000002',5,0,'2026-04-07','2026-04-14'),
('R000005','C000038','M000013','E000004',4,1,'2026-04-09','2026-04-16'),
('R000006','C000015','M000017','E000001',5,0,'2026-04-11','2026-04-18'),
('R000007','C000049','M000021','E000003',4,1,'2026-04-13','2026-04-20'),
('R000008','C000008','M000022','E000005',2,0,'2026-04-15','2026-04-22'),
('R000009','C000042','M000027','E000002',5,1,'2026-04-17','2026-04-24'),
('R000010','C000017','M000031','E000004',4,0,'2026-04-19','2026-04-26'),
('R000011','C000045','M000037','E000001',5,1,'2026-05-01','2026-05-08'),
('R000012','C000024','M000038','E000003',3,0,'2026-05-03','2026-05-10'),
('R000013','C000036','M000040','E000005',5,1,'2026-05-05','2026-05-12'),
('R000014','C000012','M000028','E000002',NULL,0,'2026-05-07','2026-05-14'),
('R000015','C000050','M000033','E000004',4,1,'2026-05-09','2026-05-16'),
('R000016','C000001','M000006','E000005',4,0,'2026-05-11','2026-05-18'),
('R000017','C000027','M000018','E000001',3,1,'2026-05-13','2026-05-20'),
('R000018','C000033','M000024','E000002',5,0,'2026-05-15','2026-05-22'),
('R000019','C000009','M000029','E000003',4,1,'2026-05-17','2026-05-24'),
('R000020','C000041','M000034','E000004',NULL,0,'2026-05-19','2026-05-26');
GO

--Movie Queue
INSERT INTO MovieQueue
(queueIndex, accountNumber, movieID)
VALUES
-- Customer with 3 queue spots
(1, 'C000001', 'M000002'),
(2, 'C000001', 'M000019'),
(3, 'C000001', 'M000037'),

-- Customer with 2 queue spots
(4, 'C000004', 'M000009'),
(5, 'C000004', 'M000013'),

-- Customers with 1 queue spot
(6, 'C000008', 'M000028'),
(7, 'C000012', 'M000002'),
(8, 'C000017', 'M000019'),
(9, 'C000022', 'M000037'),
(10, 'C000027', 'M000009'),
(11, 'C000033', 'M000013'),
(12, 'C000041', 'M000028');

SELECT queueIndex,
       Customers.accountNumber,
       firstName,
       lastName,
       Movie.movieID,
       movieName
FROM MovieQueue, Customers, Movie
WHERE MovieQueue.accountNumber = Customers.accountNumber
AND MovieQueue.movieID = Movie.movieID
ORDER BY queueIndex;

SELECT accountNumber, COUNT(*) AS QueueCount
FROM MovieQueue
GROUP BY accountNumber
HAVING COUNT(*) > 3;



--Actor Rating 
INSERT INTO ActorRating
(actorID, rentalID, actorRating)
VALUES

-- Dark Knight
('A000001','R000001',5),
('A000002','R000001',5),

-- Superbad
('A000020','R000003',3),
('A000021','R000003',4),

-- Forrest Gump
('A000039','R000004',5),
('A000040','R000004',5),

-- Parasite
('A000055','R000005',5),
('A000056','R000005',4),

-- Gladiator
('A000009','R000006',5),
('A000010','R000006',5),

-- Mean Girls
('A000027','R000008',4),
('A000028','R000008',3),

-- Good Will Hunting
('A000043','R000009',5),
('A000044','R000009',5),

-- Avengers Endgame
('A000018','R000011',5),
('A000019','R000011',5),

-- Spirited Away
('A000073','R000013',5),
('A000074','R000013',5),

-- Train to Busan
('A000065','R000015',5),
('A000066','R000015',4),

-- Bridesmaids
('A000031','R000018',5),
('A000032','R000018',4),

-- Crouching Tiger Hidden Dragon
('A000067','R000020',5),
('A000068','R000020',4);
GO

SELECT RentalOrder.rentalID,
       Movie.movieName,
       Actor.actorName,
       ActorRating.actorRating
FROM ActorRating, Actor, RentalOrder, Movie
WHERE ActorRating.actorID = Actor.actorID
AND ActorRating.rentalID = RentalOrder.rentalID
AND RentalOrder.movieID = Movie.movieID
ORDER BY RentalOrder.rentalID;

-- Customer Phone Numbers

INSERT INTO CustomerPhoneNumber
(accountNumber, phoneNumber)
VALUES
--GENERATED AI Phone Numbers
('C000001',7804215837),
('C000002',5879321458),
('C000003',4037619245),
('C000004',7805558123),
('C000005',5872147789),
('C000006',4038891254),
('C000007',7803276419),
('C000008',5874567821),
('C000009',4036742318),
('C000010',7809984125),
('C000011',5877832194),
('C000012',4035217648),
('C000013',7803467821),
('C000014',5879654123),
('C000015',4038146725),
('C000016',7806231847),
('C000017',5877419528),
('C000018',4033927184),
('C000019',7808514629),
('C000020',5872748193),
('C000021',4036812475),
('C000022',7807149582),
('C000023',5876384175),
('C000024',4032958417),
('C000025',7804629175),
--
('C000001',4037426185),
('C000015',5876281493),
('C000028',7803149526),
('C000034',4039517284),
('C000047',5874173852);


INSERT INTO EmployeePhoneNumber
(employeeID, phoneNumber)
VALUES
--GENERATED AI Phone Numbers
('E000001',7804419285),
('E000002',5877521849),
('E000003',4036819472),
('E000004',7802395174),
('E000005',5878451936),
--
('E000001',4035182746),
('E000003',7806924518);