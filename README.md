# Datenbank
for each table:
- createdAt: Automatically after adding the datetime stores
- updatedAt: Automatically after changing the datetime of a record.
e.g: 
- ALTER TABLE Employee
ADD createdAt DATETIME NOT NULL DEFAULT GETDATE(),
updatedAt DATETIME NOT NULL DEFAULT GETDATE();
- Implement triggers for updatedAt:
- Für die Table Password
CREATE TRIGGER trg_UpdatePasswordTimestamp
ON Password
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE Password
    SET updatedAt = GETDATE()
    WHERE Id IN (SELECT DISTINCT Id FROM Inserted);
END;
- Für die Tabele Employee
CREATE TRIGGER trg_UpdateEmployeeTimestamp
ON Employee
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE Employee
    SET updatedAt = GETDATE()
    WHERE Id IN (SELECT DISTINCT Id FROM Inserted);
END;
