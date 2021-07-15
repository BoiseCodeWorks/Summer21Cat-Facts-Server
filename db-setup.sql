-- CREATE table Theories(
--   id INT NOT NULL AUTO_INCREMENT,
--   body VARCHAR(255) NOT NULL,
--   result VARCHAR(255),
--   imgUrl VARCHAR(255),
--   PRIMARY KEY (id)
-- )


ALTER TABLE Theories  ALTER result DEFAULT "Data Inconclusive";


-- DROP TABLE IF EXISTS Theories


-- CREATE TABLE Studies(
--   id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
--   theoryId INT NOT NULL,
--   test TINYINT NOT NULL,
--   body VARCHAR(255),
--   imgUrl VARCHAR (255),
  
--   FOREIGN KEY (theoryId)
--   REFERENCES Theories(id)
--   ON DELETE CASCADE
-- )

