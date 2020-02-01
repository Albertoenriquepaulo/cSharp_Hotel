Use Hotel;
--SELECT RoomID, RoomNumber, Available FROM Rooms
--DELETE FROM Clients

--Reiniciar AutoIncrement
----DBCC CHECKIDENT (Clients, RESEED, 0)
--Añadir otro campo a la tabla
----ALTER TABLE Rooms ADD RoomNumber INT UNIQUE;

--Cambiar tamaño a campo existente
----ALTER TABLE Clients
----ALTER COLUMN DNI varchar (09)


--INSERT INTO Clients (Name, LastName, DNI) VALUES ('Alberto', 'Paulo', '123456789')
--SELECT * FROM Clients