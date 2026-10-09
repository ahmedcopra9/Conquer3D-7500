-- Conquer3D 7500 3D Base
CREATE DATABASE IF NOT EXISTS conquer3d_7500;
USE conquer3d_7500;

CREATE TABLE IF NOT EXISTS accounts (
  id INT AUTO_INCREMENT PRIMARY KEY,
  username VARCHAR(32) NOT NULL,
  password VARCHAR(32) NOT NULL,
  uid INT NOT NULL
);

INSERT INTO accounts (username, password, uid) VALUES ('admin', 'admin', 1000001)
ON DUPLICATE KEY UPDATE username=username;

CREATE TABLE IF NOT EXISTS characters (
  uid INT PRIMARY KEY,
  name VARCHAR(32) NOT NULL,
  map INT DEFAULT 1002,
  x FLOAT DEFAULT 430,
  y FLOAT DEFAULT 380,
  z FLOAT DEFAULT 0,
  hp INT DEFAULT 5000,
  maxhp INT DEFAULT 5000
);

INSERT INTO characters (uid, name, map, x, y, z, hp, maxhp)
VALUES (1000001, 'Ahmed3D', 1002, 430, 380, 0, 5000, 5000)
ON DUPLICATE KEY UPDATE name=name;
