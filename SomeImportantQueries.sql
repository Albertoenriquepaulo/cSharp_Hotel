Use Hotel;
--SELECT RoomID, RoomNumber, Available FROM Rooms
--DELETE FROM Clients

--Reiniciar AutoIncrement
----DBCC CHECKIDENT (Clients, RESEED, 0)
--A�adir otro campo a la tabla
----ALTER TABLE Rooms ADD RoomNumber INT UNIQUE;

--Cambiar tama�o a campo existente
----ALTER TABLE Clients
----ALTER COLUMN DNI varchar (09)


--INSERT INTO Clients (Name, LastName, DNI) VALUES ('Alberto', 'Paulo', '123456789')
--SELECT * FROM Clients