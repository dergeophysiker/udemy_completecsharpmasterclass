BEGIN TRANSACTION;
CREATE TABLE IF NOT EXISTS "ZooAnimal" (
	"Id"	INTEGER NOT NULL,
	"ZooId"	INTEGER NOT NULL,
	"AnimalId"	INTEGER NOT NULL,
	CONSTRAINT "AnimalFK" FOREIGN KEY("AnimalId") REFERENCES "Animal"("Id"),
	CONSTRAINT "ZooFK" FOREIGN KEY("ZooId") REFERENCES "Zoo"("Id"),
	PRIMARY KEY("Id" AUTOINCREMENT)
);
INSERT INTO "ZooAnimal" ("Id","ZooId","AnimalId") VALUES (5,2,3),
 (6,2,4),
 (7,3,5),
 (8,3,6),
 (9,4,7),
 (10,4,8),
 (11,5,1),
 (12,5,2),
 (13,5,3),
 (14,5,4),
 (15,5,5),
 (16,5,6),
 (17,5,7),
 (18,5,8),
 (19,5,8),
 (20,2,8);
COMMIT;
