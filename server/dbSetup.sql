CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8mb4 COMMENT '';


CREATE TABLE cars(
  id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP,
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  make VARCHAR(60) NOT NULL,
  model VARCHAR(110) NOT NULL,
  year SMALLINT UNSIGNED NOT NULL,
  price MEDIUMINT UNSIGNED DEFAULT 0,
  imgUrl VARCHAR(1000) NOT NULL,
  description VARCHAR(500),
  engineType ENUM("unknown", "2 stroke", "4 stroke", "6 cylinder", "8 cylinder", "10 cylinder", "12 cylinder") DEFAULT "unknown",
  color VARCHAR(10),
  hasSalvagedTitle BOOLEAN DEFAULT FALSE,
  creatorId VARCHAR(255) NOT NULL,
  FOREIGN KEY(creatorId) REFERENCES accounts(id) ON DELETE CASCADE
)


DROP TABLE cars;


SELECT id, name FROM accounts;

INSERT INTO 
cars
(make, model, year, price, imgUrl, description, engineType, color, creatorId, hasSalvagedTitle)
VALUES
("Mazda", "Miata", 1997, 4000, "https://images.unsplash.com/photo-1610884447640-42b8ec61a933?q=80&w=2226&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", "Broken car", "4 stroke", "red", "6602f6b35524751e79041b7e", true);