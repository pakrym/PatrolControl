CREATE VIEW FullTextBuildings WITH SCHEMABINDING
AS
SELECT 
	dbo.Buildings.Id AS BuildingId,
	dbo.Streets.Name + ' '+ dbo.Buildings.Number AS Address
FROM	
	dbo.Streets, 
	dbo.Buildings
WHERE 
	dbo.Streets.Id = dbo.Buildings.StreetId