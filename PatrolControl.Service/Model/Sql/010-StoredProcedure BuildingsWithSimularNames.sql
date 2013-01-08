CREATE PROCEDURE BuildingsWithSimularNames
	@request varchar(500) 
AS 
 	SELECT * FROM Buildings 
 	WHERE Id IN (SELECT BuildingId FROM FullTextBuildings WHERE Address Like(@request))