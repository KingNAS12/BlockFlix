-- Team 7: BlockFlix
    -- Nathan Alex Sequeira (3141620)
    -- Dominic Evans ()
    -- Nima Houshyar ()
    -- Shashwat Gujjar ()
-- CMPT 291 Lab 10


-- Part C1

USE master;
GO

IF DB_ID('CMPT291_Team7_MovieRental') IS NOT NULL
BEGIN
    ALTER DATABASE CMPT291_Team7_MovieRental SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE CMPT291_Team7_MovieRental;
END;
GO

CREATE DATABASE CMPT291_Team7_MovieRental;
GO

USE CMPT291_Team7_MovieRental;
GO


-- Part C2

-- Strong Entities

CREATE TABLE Customers (
    accountNumber CHAR(7) CHECK(accountNumber LIKE 'C%'),
    [password] VARCHAR(20) NOT NULL,
    accountCreationDate DATE NOT NULL DEFAULT(CURRENT_DATE), 
    email VARCHAR(320) NOT NULL UNIQUE, -- 320 is the maximum length of an email address according to StackOverflow.
    -- Name
    firstName VARCHAR(20) NOT NULL,
    lastName VARCHAR(20) NOT NULL,
    -- Demographic
    gender CHAR(1) NOT NULL CHECK(gender = 'F' OR gender = 'M' OR gender = 'O' OR gender = 'N'), -- 'F' = Female, 'M' = Male, 'O' = Other, 'N' = Prefer Not to say
    dob DATE NOT NULL, 
    -- Address
    houseNumber NUMERIC(5) NOT NULL, -- Canadian house numbers are 5 digits long. 
    street VARCHAR(10) NOT NULL, -- Eg - ' 98 Ave NW' or '111 Str SW'
    city CHAR(3) NOT NULL, -- Using 3 character airport code. Eg- 'yeg'
    province CHAR(2) NOT NULL, -- Using 2 character abbreviation for province. Eg- 'AB'
    postalCode CHAR(6) NOT NULL, -- Canadian postal codes are 6 characters long.
    -- Misc
    paymentIdentifier VARCHAR(20) NOT NULL,
    customerRating INT CHECK(customerRating >= 1 AND customerRating <= 5), -- NULL means no rating yet
    -- Key
    PRIMARY KEY(accountNumber)
);

CREATE TABLE Employee (
    employeeID CHAR(7) CHECK(employeeID LIKE 'E%'),
    [password] VARCHAR(20) NOT NULL,
    [sin] NUMERIC(6) NOT NULL UNIQUE, -- Social insurance numbers are 6 digits long.
    -- Name
    firstName VARCHAR(20) NOT NULL,
    lastName VARCHAR(20) NOT NULL,
    -- Demographic
    gender CHAR(1) NOT NULL CHECK(gender = 'F' OR gender = 'M' OR gender = 'O' OR gender = 'N'), -- 'F' = Female, 'M' = Male, 'O' = Other, 'N' = Prefer Not to say
    dob date NOT NULL, 
    -- Address
    houseNumber NUMERIC(5) NOT NULL, -- Canadian house numbers are 5 digits long. 
    street VARCHAR(10) NOT NULL, -- Eg - ' 98 Ave NW' or '111 Str SW'
    city CHAR(3) NOT NULL, -- Using 3 character airport code. Eg- 'yeg'
    province CHAR(2) NOT NULL, -- Using 2 character abbreviation for province. Eg- 'AB'
    postalCode CHAR(6) NOT NULL, -- Canadian postal codes are 6 characters long.
    -- Misc
    startDate DATE DEFAULT(CURRENT_DATE),
    endDate DATE DEFAULT(NULL), -- Null means not fired/quit yet. 
    employeeRating INT CHECK(employeeRating >= 1 AND employeeRating <= 5), -- NULL means no rating yet
    -- Key
    PRIMARY KEY(employeeID)
);

CREATE TABLE Movie (
    movieID CHAR(7) CHECK(movieID LIKE 'M%'),
    movieName VARCHAR(179) NOT NULL, -- Guinness world record for longest movie title is 179
    genre CHAR(1) NOT NULL CHECK(genre = 'A' OR genre = 'C' OR genre = 'D' OR genre = 'F'), -- 'A'='Action','C'='Comedy','D'='Drama','F'='Foreign'
    rentalFee NUMERIC(4, 2) NOT NULL CHECK(rentalFee > 0),
    replacementFee NUMERIC(4, 2) NOT NULL CHECK(replacementFee > 0),
    numberReplaced INT NOT NULL DEFAULT(0) CHECK(numberReplaced >= 0),
    numberRented INT NOT NULL DEFAULT(0) CHECK(numberRented >= 0 AND numberRented <= 10),
    PRIMARY KEY(movieID)
);

CREATE TABLE Actor (
    actorID CHAR(7) CHECK(actorID LIKE 'A%'),
    actorName VARCHAR(40) NOT NULL,
    gender CHAR(1) NOT NULL CHECK(gender = 'F' OR gender = 'M' OR gender = 'O' OR gender = 'N'), -- 'F' = Female, 'M' = Male, 'O' = Other, 'N' = Prefer Not to say
    dob DATE NOT NULL, 
    PRIMARY KEY(actorID)
); 

-- Multivalued Attributes

CREATE TABLE CustomerPhoneNumber(
    accountNumber CHAR(7) CHECK(accountNumber LIKE 'C%'),
    phoneNumber NUMERIC(10), 
    PRIMARY KEY(accountNumber, phoneNumber),
    FOREIGN KEY (accountNumber) REFERENCES Customers(accountNumber)
);

CREATE TABLE EmployeePhoneNumber(
    employeeID CHAR(7) CHECK(employeeID LIKE 'E%'),
    phoneNumber NUMERIC(10), 
    PRIMARY KEY(employeeID, phoneNumber),
    FOREIGN KEY (employeeID) REFERENCES Employee(employeeID)
);

CREATE TABLE [Cast] (
    actorID CHAR(7) CHECK(actorID LIKE 'A%'),
    movieID CHAR(7) CHECK(movieID LIKE 'M%'),
    PRIMARY KEY(actorID, movieID),
    FOREIGN KEY (actorID) REFERENCES Actor(actorID), 
    FOREIGN KEY (movieID) REFERENCES Movie(movieID)
); 

-- Total Participation

CREATE TABLE RentalOrder (
    rentalID CHAR(7) CHECK(rentalID LIKE 'R%'),
    accountNumber CHAR(7) CHECK(accountNumber LIKE 'C%'),
    movieID CHAR(7) CHECK(movieID LIKE 'M%'),
    employeeID CHAR(7) CHECK(employeeID LIKE 'E%'),
    movieRating INT CHECK(movieRating >= 1 AND movieRating <= 5), -- NULL means no rating yet
    [status] BIT NOT NULL DEFAULT(1), -- 0 = Rented, 1 = Returned
    checkoutDate DATE NOT NULL DEFAULT(CURRENT_DATE), 
    returnDate DATE NOT NULL DEFAULT(DATEADD(week, 1, CURRENT_DATE)),
    CONSTRAINT returnDate CHECK (returnDate = DATEADD(week, 1, checkoutDate)),
    PRIMARY KEY(rentalID),
    FOREIGN KEY (accountNumber) REFERENCES Customers(accountNumber),
    FOREIGN KEY (employeeID) REFERENCES Employee(employeeID), 
    FOREIGN KEY (movieID) REFERENCES Movie(movieID)
); 

-- Relationships

CREATE TABLE MovieQueue (
    queueIndex INT CHECK(queueIndex >= 0), 
    accountNumber CHAR(7) CHECK(accountNumber LIKE 'C%'),
    movieID CHAR(7) CHECK(movieID LIKE 'M%'),
    PRIMARY KEY(queueIndex),
    FOREIGN KEY (accountNumber) REFERENCES Customers(accountNumber),
    FOREIGN KEY (movieID) REFERENCES Movie(movieID)
); 

CREATE TABLE ActorRating (
    actorID CHAR(7) CHECK(actorID LIKE 'A%'),
    rentalID CHAR(7) CHECK(rentalID LIKE 'R%'),
    actorRating INT CHECK(actorRating >= 1 AND actorRating <= 5), -- NULL means no rating yet
    PRIMARY KEY(actorID, rentalID),
    FOREIGN KEY (actorID) REFERENCES Actor(actorID),
    FOREIGN KEY (rentalID) REFERENCES RentalOrder(rentalID)
); 