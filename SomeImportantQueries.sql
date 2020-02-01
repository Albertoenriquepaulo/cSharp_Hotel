Use Hotel;
--SELECT RoomID, RoomNumber, Available FROM Rooms
--DELETE FROM Clients

--Reiniciar AutoIncrement
--DBCC CHECKIDENT (Clients, RESEED, 0)
--Añadir otro campo a la tabla
----ALTER TABLE Rooms ADD RoomNumber INT UNIQUE;

--Cambiar tamaño a campo existente
----ALTER TABLE Clients
----ALTER COLUMN DNI varchar (09)


--INSERT INTO Clients (Name, LastName, DNI) VALUES ('Alberto', 'Paulo', '123456789')
--INSERT INTO Bookings (ClientID, RoomID, CheckIn, CheckOut) VALUES (1, 1, convert(datetime,'18/01/2020',13), convert(datetime,'18/02/2020',13))
SELECT * FROM Clients
SELECT * FROM Rooms
INSERT INTO Bookings (ClientID, RoomID, CheckIn, CheckOut) VALUES (1, 1, '01/18/2020', '02/18/2020')
SELECT * FROM Bookings