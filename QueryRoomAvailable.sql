----DECLARE @datetime2 datetime2 = '2007-01-01 13:10:10.1111111';  

----set @fecha1 = STR_TO_DATE('2017/12/09','%Y/%m/%d');
----set @fecha2 = STR_TO_DATE('2017/12/11','%Y/%m/%d');
--SELECT * FROM reservas
----mm/dd/yyyy
--DECLARE @fecha1 datetime = '12/09/2017';
--DECLARE @fecha2 datetime = '12/11/2017';

--SELECT h.habitacion_numero as 'Habitaciónes Disponibles'
--  FROM habitaciones h
-- WHERE NOT EXISTS (
--         SELECT NULL
--           FROM reservas r
--          WHERE r.habitacion = h.habitacion_numero
--            AND @fecha1 <= r.fin_fecha
--            AND @fecha2 >= r.inicio_fecha)
-- ORDER BY h.habitacion_numero;


USE Hotel;  
GO  
--CREATE PROCEDURE AvailableRooms
--    @fecha1 datetime,   
--    @fecha2 datetime
--AS   

--    SET NOCOUNT ON;  
--    SELECT R.RoomID AS 'AvailableRoomID'
--	FROM Rooms R
--	WHERE NOT EXISTS (
--         SELECT NULL
--           FROM Bookings B
--          WHERE B.RoomID = R.RoomID
--            AND @fecha1 <= B.CheckIn
--            AND @fecha2 <= B.CheckOut)
--	ORDER BY R.RoomID;
--GO 

EXECUTE AvailableRooms '01/09/2020', '02/16/2020';

SELECT * FROM Bookings
SELECT * FROM Rooms

EXECUTE AvailableRooms '02/05/2019', '02/18/2019'