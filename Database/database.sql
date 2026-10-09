CREATE DATABASE IF NOT EXISTS conquer3d_7500;
USE conquer3d_7500;

CREATE TABLE accounts (
  id INT AUTO_INCREMENT PRIMARY KEY,
  username VARCHAR(32) UNIQUE,
  password VARCHAR(32)
);

CREATE TABLE characters_3d (
  uid INT PRIMARY KEY,
  name VARCHAR(16),
  x FLOAT DEFAULT 430,
  y FLOAT DEFAULT 380,
  z FLOAT DEFAULT 0,
  map_id INT DEFAULT 1002
);

INSERT INTO accounts (username, password) VALUES ('admin','admin');
