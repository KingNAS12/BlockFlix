-- Team 7: BlockFlix
    -- Nathan Alex Sequeira (3141620)
    -- Dominic Evans (3158097)
    -- Nima Houshyar (1741854)
    -- Sashwat ()
-- CMPT 291 Lab 10


-- Part F

-- Show all customers --
SELECT *
FROM Customers;

-- Show all movies with type and copy/availability data --
SELECT movieID, movieName, genre, (10 - numberRented) AS copiesAvailable
FROM Movie;

-- Show actors for a selected movie --
SELECT a.actorID, a.actorName, a.gender, a.dob
FROM Actor AS a, [Cast] AS c, Movie AS m
WHERE a.actorID = c.actorID AND m.movieID = c.movieID;

-- Show a selected customer's queue --
SELECT mq.queueIndex
FROM MovieQueue AS mq, Customers AS c
WHERE c.accountNumber = mq.accountNumber;

-- Show active rentals --
SELECT rentalID
FROM RentalOrder
WHERE [status] = 0;

-- Show rental history for a selected customer --
SELECT rentalID
FROM RentalOrder AS ro, Customers AS c
WHERE [status] = 1 AND ro.accountNumber = c.accountNumber;

-- Show movie availability --
SELECT (10 - numberRented) AS availableMovies
FROM Movie;

-- Show at least one constraint test in comments --
-- INSERT INTO Movie (movieID, movieName, genre, rentalFee, replacementFee,
-- numberReplaced, numberRented)
-- VALUES
-- ('F123456', 'The Clockwork Violin', 'Adventure', 20.00, -5.00, 0, 11);
