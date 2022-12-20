BEGIN TRANSACTION;
CREATE TABLE IF NOT EXISTS "ZooAnimal" (
	"Id"	INTEGER NOT NULL,
	"ZooId"	INTEGER NOT NULL,
	"AnimalId"	INTEGER NOT NULL,
	CONSTRAINT "ZooFK" FOREIGN KEY("ZooId") REFERENCES "Zoo"("Id") ON DELETE CASCADE,
	CONSTRAINT "AnimalFK" FOREIGN KEY("AnimalId") REFERENCES "Animal"("Id") ON DELETE CASCADE,
	PRIMARY KEY("Id" AUTOINCREMENT)
);
INSERT INTO "ZooAnimal" ("Id","ZooId","AnimalId") VALUES (3,1,1);
INSERT INTO "ZooAnimal" ("Id","ZooId","AnimalId") VALUES (4,1,2);
INSERT INTO "ZooAnimal" ("Id","ZooId","AnimalId") VALUES (5,2,3);
INSERT INTO "ZooAnimal" ("Id","ZooId","AnimalId") VALUES (6,2,4);
INSERT INTO "ZooAnimal" ("Id","ZooId","AnimalId") VALUES (7,3,5);
INSERT INTO "ZooAnimal" ("Id","ZooId","AnimalId") VALUES (8,3,6);
INSERT INTO "ZooAnimal" ("Id","ZooId","AnimalId") VALUES (9,4,7);
INSERT INTO "ZooAnimal" ("Id","ZooId","AnimalId") VALUES (10,4,8);
INSERT INTO "ZooAnimal" ("Id","ZooId","AnimalId") VALUES (11,5,1);
INSERT INTO "ZooAnimal" ("Id","ZooId","AnimalId") VALUES (12,5,2);
INSERT INTO "ZooAnimal" ("Id","ZooId","AnimalId") VALUES (13,5,3);
INSERT INTO "ZooAnimal" ("Id","ZooId","AnimalId") VALUES (14,5,4);
INSERT INTO "ZooAnimal" ("Id","ZooId","AnimalId") VALUES (15,5,5);
INSERT INTO "ZooAnimal" ("Id","ZooId","AnimalId") VALUES (16,5,6);
INSERT INTO "ZooAnimal" ("Id","ZooId","AnimalId") VALUES (17,5,7);
INSERT INTO "ZooAnimal" ("Id","ZooId","AnimalId") VALUES (18,5,8);
COMMIT;
