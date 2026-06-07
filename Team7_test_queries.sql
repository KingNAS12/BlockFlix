-- Team 7: BlockFlix
    -- Nathan Alex Sequeira (3141620)
    -- Dominic Evans (3158097)
    -- Nima Houshyar (1741854)
    -- Shashwat Gujjar (3151998)
-- CMPT 291 Lab 10

USE CMPT291_Team7_MovieRental;
GO

-- Part F

-- Show all Customer --
SELECT *
    FROM Customer;

-- Show all movies with type and copy/availability data --
SELECT movieID, 
        movieName, 
        genre, 
        copiesAvailable
    FROM Movie;

-- Show actors for a selected movie --
SELECT m.movieID, 
        m.movieName, 
        a.actorID, 
        a.actorName
    FROM Actor AS a, [Cast] AS c, Movie AS m
    WHERE a.actorID = c.actorID 
        AND c.movieID = m.movieID
        AND c.movieID = 'M000020';

-- Show a selected customer's queue --
SELECT mq.queueIndex, mq.movieID, m.movieName
    FROM MovieQueue AS mq, Customer AS c, Movie AS m
    WHERE c.accountNumber = mq.accountNumber
        AND c.accountNumber = 'C000001'
        AND m.movieID = mq.movieID;

-- Show active rentals --
-- Active: returnDate IS NULL AND GETDATE() <= DATEADD(WEEK, 1, checkoutDate) AND replacementFeeCharge = 0
-- Overdue: returnDate IS NULL AND GETDATE() > DATEADD(WEEK, 1, checkoutDate) AND replacementFeeCharge = 0
SELECT ro.rentalID, 
        ro.accountNumber,
        c.firstName + ' ' + c.lastName AS customerName,
        ro.movieID,
        m.movieName,
        checkoutDate, 
        DATEADD(WEEK, 1, checkoutDate) AS dueDate,
        CASE WHEN GETDATE() > DATEADD(WEEK, 1, checkoutDate) THEN 'Overdue'
            ELSE 'Active'
        END AS rentalStatus
    FROM RentalOrder AS ro, Customer AS c, Movie AS m
    WHERE ro.accountNumber = c.accountNumber
        AND ro.movieID = m.movieID
        AND returnDate IS NULL; 

-- Show rental history for a selected customer --
-- Returned on time: returnDate <= DATEADD(WEEK, 1, checkoutDate) AND replacementFeeCharge = 0
-- Returned late but not charged replacement fee: DATEADD(WEEK, 1, checkoutDate) < returnDate < DATEADD(WEEK, 2, checkoutDate) AND replacementFeeCharge = 0
-- Overdue and needs to be charged replacement fee: returnDate IS NULL AND GETDATE() > DATEADD(WEEK, 2, checkoutDate) AND replacementFeeCharge = 0
-- Overdue and replacement fee charged: returnDate IS NULL AND GETDATE() > DATEADD(WEEK, 2, checkoutDate) AND replacementFeeCharge = 1
-- Replacement fee already charged but returned later: returnDate >= DATEADD(WEEK, 2, checkoutDate) AND replacementFeeCharge = 1
SELECT rentalID,
        ro.movieID,
        movieName, 
        checkoutDate, 
        returnDate, 
        CASE WHEN returnDate <= DATEADD(WEEK, 1, checkoutDate) THEN 'Returned on time'
            WHEN returnDate > DATEADD(WEEK, 1, checkoutDate) AND returnDate < DATEADD(WEEK, 2, checkoutDate) THEN 'Returned late but not charged'
            WHEN returnDate IS NULL AND GETDATE() > DATEADD(WEEK, 2, checkoutDate) AND replacementFeeCharged = 0 THEN 'Overdue and needs to be charged'
            WHEN returnDate IS NULL AND replacementFeeCharged = 1 THEN 'Overdue and replacement fee charged'
            WHEN returnDate >= DATEADD(WEEK, 2, checkoutDate) AND replacementFeeCharged = 1 THEN 'Replacement fee already charged but returned later'
        END AS rentalStatus
    FROM RentalOrder AS ro, Customer AS c, Movie AS m
    WHERE ro.accountNumber = c.accountNumber
        AND ro.movieID = m.movieID
        AND c.accountNumber = 'C000019';

-- Show movie availability --
SELECT movieID, 
        movieName, 
        copiesAvailable
    FROM Movie;

-- Show at least one constraint test in comments --
-- INSERT INTO Movie (movieID, movieName, genre, rentalFee, replacementFee, copiesAvailable) VALUES
-- ('F123456', 'The Clockwork Violin', 'Adventure', 20.00, -5.00, -1);