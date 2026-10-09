CREATE DATABASE IF NOT EXISTS conquer3d_7500;
USE conquer3d_7500;

CREATE TABLE accounts (
  id INT AUTO_INCREMENT PRIMARY KEY,
  username VARCHAR(32) UNIQUE,
  password VARCHAR(32),
  email VARCHAR(64)
);

CREATE TABLE characters_3d (
  uid INT PRIMARY KEY,
  account_id INT,
  name VARCHAR(16),
  x FLOAT DEFAULT 430,
  y FLOAT DEFAULT 380,
  z FLOAT DEFAULT 0,
  map_id INT DEFAULT 1002,
  hp INT DEFAULT 5000
);

-- أكونت الدخول
DELETE FROM accounts WHERE username='admin';
INSERT INTO accounts (id, username, password, email) VALUES (1, 'admin', 'admin', 'admin@conquer3d.com');

-- الشخصية الجاهزة
DELETE FROM characters_3d WHERE name='Ahmed3D';
INSERT INTO characters_3d (uid, account_id, name, x, y, z, map_id, hp) VALUES (1000001, 1, 'Ahmed3D', 430, 380, 0, 1002, 5000);
