-- Team 7: BlockFlix
    -- Nathan Alex Sequeira (3141620)
    -- Dominic Evans (3158097)
    -- Nima Houshyar (1741854)
    -- Sashwat ()
-- CMPT 291 Lab 10

USE CMPT291_Team7_MovieRental;
GO

-- Part G

-- 1. Movie Rental Frequency --
SELECT m.movieID, 
        m.movieName, 
        COUNT(ro.rentalID) AS rentalsCount
    FROM RentalOrder AS ro, Movie AS m
    WHERE ro.movieID = m.movieID 
    GROUP BY m.movieID, m.movieName
    ORDER BY rentalsCount DESC;

-- 2. Genre Rental Frequency  --
SELECT m.genre, 
        COUNT(ro.movieID) AS rentalsCount
    FROM RentalOrder AS ro, Movie AS m
    WHERE ro.movieID = m.movieID 
    GROUP BY m.genre 
    ORDER BY rentalsCount DESC;

-- 3. Rentals by Day of Week --
SELECT DATENAME(WEEKDAY, checkoutDate) AS dayOfWeek, 
        COUNT(movieID) AS numberOfMoviesRented
    FROM RentalOrder
    GROUP BY DATEPART(WEEKDAY, checkoutDate), DATENAME(WEEKDAY, checkoutDate)
    ORDER BY DATEPART(WEEKDAY, checkoutDate);

-- 4. Employee Rental Processing -- 
SELECT e.employeeID, 
        e.firstName + ' ' + e.lastName AS employeeName,
        COUNT(ro.movieID) AS rentalsProcessed
    FROM RentalOrder AS ro, Employee AS e
    WHERE e.employeeID = ro.employeeID
    GROUP BY e.employeeID, e.firstName, e.lastName
    ORDER BY rentalsProcessed DESC;

-- 5. Customer Rental Activity -- 
SELECT c.accountNumber, 
        c.firstName + ' ' + c.lastName AS customerName,
        COUNT(ro.movieID) AS rentalsCount
    FROM Customer AS c, RentalOrder AS ro
    WHERE c.accountNumber = ro.accountNumber
    GROUP BY c.accountNumber, c.firstName, c.lastName
    ORDER BY rentalsCount DESC;

-- 6. Customer Queue Usage --
SELECT c.accountNumber, 
        c.firstName + ' ' + c.lastName AS customerName,
        COUNT(mq.queueIndex) AS numQueueSpots
    FROM Customer AS c, MovieQueue AS mq
    WHERE c.accountNumber = mq.accountNumber
    GROUP BY c.accountNumber, c.firstName, c.lastName
    ORDER BY numQueueSpots DESC;

-- 7. Movie Ratings Report -- 
SELECT m.movieID, 
        m.movieName,
        AVG(ro.movieRating) AS avgRating,
        COUNT(ro.movieID) AS numRatings 
    FROM RentalOrder AS ro, Movie AS m
    WHERE ro.movieID = m.movieID
        AND ro.movieRating IS NOT NULL
    GROUP BY m.movieID, m.movieName
    ORDER BY avgRating DESC, numRatings DESC;

-- 8. Actor Ratings Report --
SELECT a.actorID, 
        a.actorName,  
        AVG(r.actorRating) AS avgRating,
        COUNT(r.actorID) AS numRatings
    FROM ActorRating as r, actor as a
    WHERE r.actorID = a.actorID
    GROUP BY a.actorID, a.actorName
    ORDER BY avgRating DESC, numRatings DESC;

-- 9. Customer Ratings Report --
SELECT accountNumber, 
        firstName + ' ' + lastName AS customerName,
        AVG(customerRating) AS customerRating
    FROM Customer
    GROUP BY accountNumber, firstName, lastName
    ORDER BY customerRating DESC;

-- 10. Movie Preferences by Gender --
SELECT c.gender,
        m.movieID, 
        m.movieName,
        COUNT(ro.rentalID) AS rentals
    FROM Customer AS c, RentalOrder AS ro, Movie AS m
    WHERE c.accountNumber = ro.accountNumber
        AND ro.movieID = m.movieID
    GROUP BY c.gender, m.movieID, m.movieName
    ORDER BY c.gender ASC, rentals DESC;

-- 11. Genre Preferences by Gender --
SELECT c.gender,
        m.genre,
        COUNT(ro.rentalID) AS rentals
    FROM Customer AS c, RentalOrder AS ro, Movie AS m
    WHERE c.accountNumber = ro.accountNumber
        AND ro.movieID = m.movieID
    GROUP BY c.gender, m.genre
    ORDER BY c.gender ASC, m.genre ASC;

-- 12. Actor Popularity by Gender --
SELECT cu.gender,
        a.actorID,
        a.actorName,
        COUNT(*) AS appearancesInRentedMovies
    FROM Customer AS cu, RentalOrder AS ro, [Cast] AS ca, Actor AS a
    WHERE cu.accountNumber = ro.accountNumber
        AND ro.movieID = ca.movieID
        AND ca.actorID = a.actorID
    GROUP BY cu.gender, a.actorID, a.actorName
    ORDER BY cu.gender ASC, appearancesInRentedMovies DESC;

-- 13. Actor Preferences by Customer Gender --
SELECT c.gender,
        a.actorID,
        a.actorName,
        COUNT(ro.rentalID) AS rentals
    FROM Actor AS a, [Cast] AS ca, RentalOrder AS ro, Customer AS c
    WHERE a.actorID = ca.actorID
        AND ca.movieID = ro.movieID
        AND ro.accountNumber = c.accountNumber
    GROUP BY c.gender, a.actorID, a.actorName
    ORDER BY c.gender ASC, rentals DESC, a.actorID ASC;

-- 14. Actor Preferences by Customer Age Group --
SELECT CASE
            WHEN DATEDIFF(YEAR, c.dob, GETDATE()) < 18 THEN '18-'
            WHEN DATEDIFF(YEAR, c.dob, GETDATE()) BETWEEN 18 AND 29 THEN '18-29'
            WHEN DATEDIFF(YEAR, c.dob, GETDATE()) BETWEEN 30 AND 49 THEN '30-49'
            ELSE '50+'
        END AS ageGroup,
        a.actorID,
        a.actorName,
        COUNT(ro.rentalID) AS rentals
    FROM Actor AS a, [Cast] AS ca, RentalOrder AS ro, Customer AS c
    WHERE a.actorID = ca.actorID
        AND ca.movieID = ro.movieID
        AND ro.accountNumber = c.accountNumber
    GROUP BY a.actorID, a.actorName, CASE
            WHEN DATEDIFF(YEAR, c.dob, GETDATE()) < 18 THEN '18-'
            WHEN DATEDIFF(YEAR, c.dob, GETDATE()) BETWEEN 18 AND 29 THEN '18-29'
            WHEN DATEDIFF(YEAR, c.dob, GETDATE()) BETWEEN 30 AND 49 THEN '30-49'
            ELSE '50+'
        END
    ORDER BY ageGroup ASC, rentals DESC, a.actorID ASC;

-- 15. Actor Genre Frequency --
SELECT m.genre,
        a.actorID, 
        a.actorName,
        COUNT(*) AS appearances
    FROM Actor AS a, [Cast] AS c, Movie AS m
    WHERE a.actorID = c.actorID
        AND c.movieID = m.movieID
    GROUP BY a.actorID, a.actorName, m.genre
    ORDER BY m.genre ASC, appearances DESC, a.actorID ASC;

-- 16. Movie Replacement Frequency -- 
SELECT m.movieID,
        m.movieName,
        COUNT(ro.rentalID) AS timesReplaced
    FROM Movie AS m, RentalOrder AS ro
    WHERE m.movieID = ro.movieID
        AND ro.replacementFeeCharged = 1
    GROUP BY m.movieID, m.movieName
    ORDER BY timesReplaced DESC;

-- 17. Overdue Rentals by Customer --
SELECT c.accountNumber,
        c.firstName + ' ' + c.lastName AS customerName,
        COUNT(ro.rentalID) AS overdueRentals
    FROM Customer AS c, RentalOrder AS ro
    WHERE c.accountNumber = ro.accountNumber
        AND ro.returnDate IS NULL
        AND GETDATE() > DATEADD(WEEK, 1, ro.checkoutDate)
    GROUP BY c.accountNumber, c.firstName, c.lastName
    ORDER BY overdueRentals DESC, c.accountNumber ASC;

-- 18. Movies Never Rented Out --
SELECT movieID,
        movieName
    FROM Movie
    WHERE movieID NOT IN (
        SELECT movieID
            FROM RentalOrder
    );

-- 19. Above-Average Rated Movies --
SELECT m.movieID,
        m.movieName,
        AVG(ro.movieRating) AS avgRating, 
        COUNT(ro.movieID) AS numRatings
    FROM Movie AS m, RentalOrder AS ro
    WHERE m.movieID = ro.movieID
        AND ro.movieRating IS NOT NULL
    GROUP BY m.movieID, m.movieName
    HAVING AVG(ro.movieRating) > (
        SELECT AVG(movieRating)
            FROM RentalOrder
            WHERE movieRating IS NOT NULL
    )
    ORDER BY avgRating DESC, numRatings DESC, m.movieID ASC;

-- 20. Monthly Income Report --
SELECT YEAR(ro.checkoutDate) AS rentalYear,
        DATEPART(MONTH, ro.checkoutDate) AS numMonth,
        DATENAME(MONTH, ro.checkoutDate) AS rentalMonth,
        SUM(m.rentalFee) AS rentalIncome,
        SUM(CASE 
            WHEN ro.replacementFeeCharged = 1 THEN m.replacementFee 
            ELSE 0 
            END) AS replacementIncome,
        SUM(m.rentalFee) + SUM(CASE 
            WHEN ro.replacementFeeCharged = 1 THEN m.replacementFee 
            ELSE 0 
            END) AS totalIncome
    FROM RentalOrder AS ro, Movie AS m
    WHERE ro.movieID = m.movieID
    GROUP BY YEAR(ro.checkoutDate), DATEPART(MONTH, ro.checkoutDate), DATENAME(MONTH, ro.checkoutDate)
    ORDER BY rentalYear ASC, numMonth ASC;

