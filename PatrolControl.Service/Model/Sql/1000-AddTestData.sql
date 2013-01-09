INSERT INTO Streets (Name, Geography)
VALUES 
(N'Куликовская', geography::Parse('LINESTRING (34.780716 50.912897, 34.783505 50.918635)'));

INSERT INTO Buildings (StreetId, Number, Geography, Tags)
VALUES 
(SCOPE_IDENTITY(), '1', geography::Parse('POINT(34.78358  50.918387)'), 0),
(SCOPE_IDENTITY(), '2', geography::Parse('POINT(34.783162 50.91836 )'), 0),
(SCOPE_IDENTITY(), '3', geography::Parse('POINT(34.783527 50.918218)'), 0),
(SCOPE_IDENTITY(), '4', geography::Parse('POINT(34.782915 50.917892)'), 0),
(SCOPE_IDENTITY(), '5', geography::Parse('POINT(34.783398 50.917987)'), 0),
(SCOPE_IDENTITY(), '6', geography::Parse('POINT(34.782733 50.917587)'), 0),
(SCOPE_IDENTITY(), '7', geography::Parse('POINT(34.783269 50.917858)'), 0),
(SCOPE_IDENTITY(), '8', geography::Parse('POINT(34.7824   50.916916)'), 0),
(SCOPE_IDENTITY(), '9', geography::Parse('POINT(34.783226 50.917682)'), 0),
(SCOPE_IDENTITY(),'10', geography::Parse('POINT(34.782357 50.916814)'), 0),
(SCOPE_IDENTITY(),'11', geography::Parse('POINT(34.783173 50.917567)'), 0),
(SCOPE_IDENTITY(),'12', geography::Parse('POINT(34.782229 50.916563)'), 0),
(SCOPE_IDENTITY(),'13', geography::Parse('POINT(34.782722 50.916665)'), 0),
(SCOPE_IDENTITY(),'15', geography::Parse('POINT(34.782701 50.916482)'), 0),
(SCOPE_IDENTITY(),'17', geography::Parse('POINT(34.782561 50.916224)'), 0),
(SCOPE_IDENTITY(),'19', geography::Parse('POINT(34.782422 50.916061)'), 0);

