-- Team 7: BlockFlix
    -- Nathan Alex Sequeira (3141620)
    -- Dominic Evans (3158097)
    -- Nima Houshyar (1741854)
    -- Sashwat ()
-- CMPT 291 Lab 10

-- Part G

-- Most common movie rented. --
SELECT m.movieID, COUNT(ro.rentalID) AS moviesRented
FROM RentalOrder AS ro, Movie AS m
WHERE ro.movieID = m.movieID 
GROUP BY m.movieID
ORDER BY m.movieID ASC;

-- least common movie rented. --
SELECT m.movieID, COUNT(ro.rentalID) AS moviesRented
FROM RentalOrder AS ro, Movie AS m
WHERE ro.movieID = m.movieID 
GROUP BY m.movieID
ORDER BY m.movieID ASC;

-- Most common genre rented --
SELECT m.genre, COUNT(m.movieID) AS movieCount
FROM RentalOrder AS ro, Movie AS m
WHERE ro.movieID = m.movieID 
GROUP BY m.genre 
ORDER BY m.genre ASC;

-- least common genre rented --
SELECT m.genre, COUNT(m.movieID) AS movieCount
FROM RentalOrder AS ro, Movie AS m
WHERE ro.movieID = m.movieID 
GROUP BY m.genre 
ORDER BY m.genre DESC;

-- Days of the week when most movies are rented. --
SELECT checkoutDate, COUNT(movieID) AS movieCount
FROM RentalOrder
GROUP BY checkoutDate
ORDER BY checkoutDate ASC;

-- Days of the week when least movies are rented. --
SELECT checkoutDate, COUNT(movieID) AS movieCount
FROM RentalOrder
GROUP BY checkoutDate
ORDER BY checkoutDate DESC;

-- Employee with the most orders. -- 
SELECT e.employeeID, COUNT(ro.movieID) AS movieCount
FROM RentalOrder AS ro, Employee AS e
WHERE e.employeeID = ro.employeeID
GROUP BY e.employeeID
ORDER BY e.employeeID ASC;


-- Employee with the least orders. -- 
SELECT e.employeeID, COUNT(ro.movieID) AS movieCount
FROM RentalOrder AS ro, Employee AS e
WHERE e.employeeID = ro.employeeID
GROUP BY e.employeeID
ORDER BY e.employeeID DESC;

-- Customer with the most orders. -- 
SELECT c.accountNumber, COUNT(ro.movieID) AS movieCount
FROM Customer AS c, RentalOrder AS ro
WHERE c.accountNumber = ro.accountNumber
GROUP BY accountNumber
ORDER BY accountNumber ASC;

-- Customer with the least orders. -- 
SELECT c.accountNumber, COUNT(ro.movieID) AS movieCount
FROM Customer AS c, RentalOrder AS ro
WHERE c.accountNumber = ro.accountNumber
GROUP BY accountNumber
ORDER BY accountNumber DESC;

-- Customer with the most spots in queue. --
SELECT c.accountNumber, COUNT(mq.queueIndex) AS queuePosition
FROM Customer AS c, MovieQueue AS mq
WHERE c.accountNumber = mq.accountNumber
GROUP BY c.accountNumber
ORDER BY c.accountNumber ASC;

-- Customer with the least spots in queue. --
SELECT c.accountNumber, COUNT(mq.queueIndex) AS queuePosition
FROM Customer AS c, MovieQueue AS mq
WHERE c.accountNumber = mq.accountNumber
GROUP BY c.accountNumber
ORDER BY c.accountNumber DESC;

-- Movie with highest rating -- 
SELECT m.movieID, AVG(rating) AS rating
FROM RentalOrder AS ro, Movie AS m
WHERE ro.movieID = m.movieID
GROUP BY m.movieID
ORDER BY AVG(rating) ASC;

-- Movie with lowest rating -- 
SELECT m.movieID, AVG(rating) AS rating
FROM RentalOrder AS ro, Movie AS m
WHERE ro.movieID = m.movieID
GROUP BY m.movieID
ORDER BY AVG(rating) DESC;

-- Actor with highest rating --
SELECT actorID, AVG(rating) AS rating
FROM ActorRating
GROUP BY actorID
ORDER BY actorID ASC;

-- Actor with lowest rating --
SELECT actorID, AVG(rating) AS rating
FROM ActorRating
GROUP BY actorID
ORDER BY actorID DESC;

-- Customer with highest rating --
SELECT AVG(customerRating) AS customerRating
FROM Customer AS A, Customer AS B
WHERE A.AVG(customerRating) > B.AVG(customerRating);

-- Customer with lowest rating --
SELECT AVG(customerRating) AS customerRating
FROM Customer AS A, Customer AS B
WHERE A.AVG(customerRating) < B.AVG(customerRating);

-- Movies rented out most often by specific demographic (Male). --
SELECT COUNT(ro.rentalID) AS moviesRented
FROM Customer AS c, RentalOrder AS ro, Movie AS m, RentalOrder AS ro2
WHERE c.accountNumber = ro.accountNumber 
    AND m.movieID = ro.movieID 
    AND c.gender = 'M'
    AND COUNT(ro.rentalID) > COUNT(ro2.rentalID)
GROUP BY movieID;

-- Movies rented out most often by specific demographic (Female). --
SELECT COUNT(ro.rentalID) AS moviesRented
FROM Customer AS c, RentalOrder AS ro, Movie AS m, RentalOrder AS ro2
WHERE c.accountNumber = ro.accountNumber 
    AND m.movieID = ro.movieID 
    AND c.gender = 'F'
    AND COUNT(ro.rentalID) > COUNT(ro2.rentalID)
GROUP BY movieID;

-- Movies rented out most often by specific demographic (Other). --
SELECT COUNT(ro.rentalID) AS moviesRented
FROM Customer AS c, RentalOrder AS ro, Movie AS m, RentalOrder AS ro2
WHERE c.accountNumber = ro.accountNumber 
    AND m.movieID = ro.movieID 
    AND c.gender = 'O'
    AND COUNT(ro.rentalID) > COUNT(ro2.rentalID)
GROUP BY movieID;

-- Movies rented out most often by specific demographic (Prefer Not To Say). --
SELECT COUNT(ro.rentalID) AS moviesRented
FROM Customer AS c, RentalOrder AS ro, Movie AS m, RentalOrder AS ro2
WHERE c.accountNumber = ro.accountNumber 
    AND m.movieID = ro.movieID 
    AND c.gender = 'N'
    AND COUNT(ro.rentalID) > COUNT(ro2.rentalID)
GROUP BY movieID;

-- Movies rented out least often by specific demographic (Male). --
SELECT COUNT(ro.rentalID) AS moviesRented
FROM Customer AS c, RentalOrder AS ro, Movie AS m, RentalOrder AS ro2
WHERE c.accountNumber = ro.accountNumber 
    AND m.movieID = ro.movieID 
    AND c.gender = 'M'
    AND COUNT(ro.rentalID) < COUNT(ro2.rentalID)
GROUP BY movieID;

-- Movies rented out least often by specific demographic (Female). --
SELECT COUNT(ro.rentalID) AS moviesRented
FROM Customer AS c, RentalOrder AS ro, Movie AS m, RentalOrder AS ro2
WHERE c.accountNumber = ro.accountNumber 
    AND m.movieID = ro.movieID 
    AND c.gender = 'F'
    AND COUNT(ro.rentalID) < COUNT(ro2.rentalID)
GROUP BY movieID;

-- Movies rented out least often by specific demographic (Other). --
SELECT COUNT(ro.rentalID) AS moviesRented
FROM Customer AS c, RentalOrder AS ro, Movie AS m, RentalOrder AS ro2
WHERE c.accountNumber = ro.accountNumber 
    AND m.movieID = ro.movieID 
    AND c.gender = 'O'
    AND COUNT(ro.rentalID) < COUNT(ro2.rentalID)
GROUP BY movieID;

-- Movies rented out least often by specific demographic (Prefer Not To Say). --
SELECT COUNT(ro.rentalID) AS moviesRented
FROM Customer AS c, RentalOrder AS ro, Movie AS m, RentalOrder AS ro2
WHERE c.accountNumber = ro.accountNumber 
    AND m.movieID = ro.movieID 
    AND c.gender = 'N'
    AND COUNT(ro.rentalID) < COUNT(ro2.rentalID)
GROUP BY movieID;

-- Actors found in movies rented out most often by specific demographic (Male). --
SELECT a.actorID, COUNT(rentalID) AS moviesRented
FROM Customer AS cu, RentalOrder AS ro, Movie AS m, [Cast] AS ca, Actor AS a
WHERE cu.gender = 'M' 
    AND cu.accountNumber = ro.accountNumber
    AND m.movieID = ro.movieID
    AND a.actorID = ca.actorID
    AND m.movieID = ca.movieID
GROUP BY a.actorID;
ORDER BY COUNT(rentalID) ASC;

-- Actors found in movies rented out most often by specific demographic (Female). --
SELECT a.actorID, COUNT(rentalID) AS moviesRented
FROM Customer AS cu, RentalOrder AS ro, Movie AS m, [Cast] AS ca, Actor AS a
WHERE cu.gender = 'F' 
    AND cu.accountNumber = ro.accountNumber
    AND m.movieID = ro.movieID
    AND a.actorID = ca.actorID
    AND m.movieID = ca.movieID
GROUP BY a.actorID;
ORDER BY COUNT(rentalID) ASC;

-- Actors found in movies rented out most often by specific demographic (Other). --
SELECT a.actorID, COUNT(rentalID) AS moviesRented
FROM Customer AS cu, RentalOrder AS ro, Movie AS m, [Cast] AS ca, Actor AS a
WHERE cu.gender = 'O' 
    AND cu.accountNumber = ro.accountNumber
    AND m.movieID = ro.movieID
    AND a.actorID = ca.actorID
    AND m.movieID = ca.movieID
GROUP BY a.actorID;
ORDER BY COUNT(rentalID) ASC;

-- Actors found in movies rented out most often by specific demographic (Prefer Not To Say). --
SELECT a.actorID, COUNT(rentalID) AS moviesRented
FROM Customer AS cu, RentalOrder AS ro, Movie AS m, [Cast] AS ca, Actor AS a
WHERE cu.gender = 'N' 
    AND cu.accountNumber = ro.accountNumber
    AND m.movieID = ro.movieID
    AND a.actorID = ca.actorID
    AND m.movieID = ca.movieID
GROUP BY a.actorID;
ORDER BY COUNT(rentalID) ASC;

-- Actors found in movies rented out least often by specific demographic (Male). --
SELECT a.actorID, COUNT(rentalID) AS moviesRented
FROM Customer AS cu, RentalOrder AS ro, Movie AS m, [Cast] AS ca, Actor AS a
WHERE cu.gender = 'M' 
    AND cu.accountNumber = ro.accountNumber
    AND m.movieID = ro.movieID
    AND a.actorID = ca.actorID
    AND m.movieID = ca.movieID
GROUP BY a.actorID
ORDER BY COUNT(rentalID) DESC;

-- Actors found in movies rented out least often by specific demographic (Female). --
SELECT a.actorID, COUNT(rentalID) AS moviesRented
FROM Customer AS cu, RentalOrder AS ro, Movie AS m, [Cast] AS ca, Actor AS a
WHERE cu.gender = 'F' 
    AND cu.accountNumber = ro.accountNumber
    AND m.movieID = ro.movieID
    AND a.actorID = ca.actorID
    AND m.movieID = ca.movieID
GROUP BY a.actorID
ORDER BY COUNT(rentalID) DESC;

-- Actors found in movies rented out least often by specific demographic (Other). --
SELECT a.actorID, COUNT(rentalID) AS moviesRented
FROM Customer AS cu, RentalOrder AS ro, Movie AS m, [Cast] AS ca, Actor AS a
WHERE cu.gender = 'O' 
    AND cu.accountNumber = ro.accountNumber
    AND m.movieID = ro.movieID
    AND a.actorID = ca.actorID
    AND m.movieID = ca.movieID
GROUP BY a.actorID
ORDER BY COUNT(rentalID) DESC;

-- Actors found in movies rented out least often by specific demographic (Prefer Not To Say). --
SELECT a.actorID, COUNT(rentalID) AS moviesRented
FROM Customer AS cu, RentalOrder AS ro, Movie AS m, [Cast] AS ca, Actor AS a
WHERE cu.gender = 'N' 
    AND cu.accountNumber = ro.accountNumber
    AND m.movieID = ro.movieID
    AND a.actorID = ca.actorID
    AND m.movieID = ca.movieID
GROUP BY a.actorID
ORDER BY COUNT(rentalID) DESC;

-- Actor most common in specific genres (Action) --
SELECT actorID
FROM Movie AS m, [Cast] AS c, Actor AS a, Movie AS m2
WHERE m.genre = 'A' 
    AND COUNT(m.movieID) > COUNT(m2.movieID)
    AND m.movieID = c.movieID 
    AND a.actorID = c.actorID
GROUP BY actorID;

-- Actor most common in specific genres (Comedy) --
SELECT actorID
FROM Movie AS m, [Cast] AS c, Actor AS a, Movie AS m2
WHERE m.genre = 'C' 
    AND COUNT(m.movieID) > COUNT(m2.movieID)
    AND m.movieID = c.movieID 
    AND a.actorID = c.actorID
GROUP BY actorID;

-- Actor most common in specific genres (Drama) --
SELECT actorID
FROM Movie AS m, [Cast] AS c, Actor AS a, Movie AS m2
WHERE m.genre = 'D' 
    AND COUNT(m.movieID) > COUNT(m2.movieID)
    AND m.movieID = c.movieID 
    AND a.actorID = c.actorID
GROUP BY actorID;

-- Actor most common in specific genres (Foreign) --
SELECT actorID
FROM Movie AS m, [Cast] AS c, Actor AS a, Movie AS m2
WHERE m.genre = 'F' 
    AND COUNT(m.movieID) > COUNT(m2.movieID)
    AND m.movieID = c.movieID 
    AND a.actorID = c.actorID
GROUP BY actorID;

-- Actor least common in specific genres (Action) --
SELECT actorID
FROM Movie AS m, [Cast] AS c, Actor AS a, Movie AS m2
WHERE m.genre = 'A' 
    AND COUNT(m.movieID) < COUNT(m2.movieID)
    AND m.movieID = c.movieID 
    AND a.actorID = c.actorID
GROUP BY actorID;

-- Actor least common in specific genres (Comedy) --
SELECT actorID
FROM Movie AS m, [Cast] AS c, Actor AS a, Movie AS m2
WHERE m.genre = 'C' 
    AND COUNT(m.movieID) < COUNT(m2.movieID)
    AND m.movieID = c.movieID 
    AND a.actorID = c.actorID
GROUP BY actorID;

-- Actor least common in specific genres (Drama) --
SELECT actorID
FROM Movie AS m, [Cast] AS c, Actor AS a, Movie AS m2
WHERE m.genre = 'D' 
    AND COUNT(m.movieID) < COUNT(m2.movieID)
    AND m.movieID = c.movieID 
    AND a.actorID = c.actorID
GROUP BY actorID;

-- Actor least common in specific genres (Foreign) --
SELECT actorID
FROM Movie AS m, [Cast] AS c, Actor AS a, Movie AS m2
WHERE m.genre = 'F' 
    AND COUNT(m.movieID) < COUNT(m2.movieID)
    AND m.movieID = c.movieID 
    AND a.actorID = c.actorID
GROUP BY actorID;

-- Most replaced movies -- 
SELECT COUNT(numberReplaced) AS moviesReplaced
FROM Movie
GROUP BY movieID 
ORDER movieID ASC;

-- least replaced movies -- 
SELECT COUNT(numberReplaced) AS moviesReplaced
FROM Movie
GROUP BY movieID 
ORDER movieID DESC;

-- Customer that did not return most number of movies --
SELECT c.accountNumber, COUNT(m.movieID) AS movieCount
FROM Customer AS c, RentalOrder AS ro, Movie AS m, RentalOrder AS ro2
WHERE ro.[status] = 0 AND ro.returnDate > CURRENT_DATE
    AND c.accountNumber = ro.accountNumber
    AND m.movieID = ro.movieID
    AND COUNT(ro.rentalID) > COUNT(ro2.rentalID)
GROUP BY c.customerID;

-- Customer that did not return least number of movies --
SELECT c.accountNumber, COUNT(m.movieID) AS movieCount
FROM Customer AS c, RentalOrder AS ro, Movie AS m, RentalOrder AS ro2
WHERE ro.[status] = 0 AND ro.returnDate > CURRENT_DATE
    AND c.accountNumber = ro.accountNumber
    AND m.movieID = ro.movieID
    AND COUNT(ro.rentalID) < COUNT(ro2.rentalID)
GROUP BY c.customerID;