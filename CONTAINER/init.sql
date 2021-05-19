-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema hollowminds_database
-- -----------------------------------------------------
DROP SCHEMA IF EXISTS `hollowminds_database` ;

-- -----------------------------------------------------
-- Schema hollowminds_database
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `hollowminds_database` DEFAULT CHARACTER SET utf8 ;
USE `hollowminds_database` ;

-- -----------------------------------------------------
-- Table `hollowminds_database`.`limit_silo`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `hollowminds_database`.`limit_silo` (
  `idLimit` INT NOT NULL AUTO_INCREMENT,
  `temperature` FLOAT NOT NULL,
  `umidity` FLOAT NOT NULL,
  `pressure` FLOAT NOT NULL,
  `level_max` INT NOT NULL,
  `level_min` INT NOT NULL,
  `material` VARCHAR(50) NOT NULL,
  PRIMARY KEY (`idLimit`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `hollowminds_database`.`block`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `hollowminds_database`.`block` (
  `idBlock` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(50) NOT NULL,
  PRIMARY KEY (`idBlock`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `hollowminds_database`.`silo`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `hollowminds_database`.`silo` (
  `idSilo` INT NOT NULL AUTO_INCREMENT,
  `idLimit` INT NOT NULL,
  `idBlock` INT NOT NULL,
  `height` FLOAT NOT NULL,
  `diameter` FLOAT NOT NULL,
  `capacity` FLOAT NOT NULL,
  `year` INT NOT NULL,
  `location` VARCHAR(50) NOT NULL,
  PRIMARY KEY (`idSilo`),
  INDEX `idBlock_idx` (`idBlock` ASC) VISIBLE,
  INDEX `idLimit_idx` (`idLimit` ASC) VISIBLE,
  CONSTRAINT `idBlock`
    FOREIGN KEY (`idBlock`)
    REFERENCES `hollowminds_database`.`block` (`idBlock`)
    ON DELETE RESTRICT
    ON UPDATE CASCADE,
  CONSTRAINT `idLimit`
    FOREIGN KEY (`idLimit`)
    REFERENCES `hollowminds_database`.`limit_silo` (`idLimit`)
    ON DELETE RESTRICT
    ON UPDATE CASCADE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `hollowminds_database`.`measurement`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `hollowminds_database`.`measurement` (
  `idMeasurement` INT NOT NULL AUTO_INCREMENT,
  `idSilo` INT NOT NULL,
  `sensor0` TINYINT(1) NOT NULL,
  `sensor1` TINYINT(1) NOT NULL,
  `sensor2` TINYINT(1) NOT NULL,
  `sensor3` TINYINT(1) NOT NULL,
  `sensor4` TINYINT(1) NOT NULL,
  `sensor5` TINYINT(1) NOT NULL,
  `sensor6` TINYINT(1) NOT NULL,
  `sensor7` TINYINT(1) NOT NULL,
  `pressure` FLOAT NOT NULL,
  `density` FLOAT NULL,
  `temperature_top` FLOAT NOT NULL,
  `temperature_bottom` FLOAT NOT NULL,
  `umidity_top` FLOAT NOT NULL,
  `umidity_bottom` FLOAT NOT NULL,
  `timeInsert` DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `dropcheck` TINYINT(1) NOT NULL,
  PRIMARY KEY (`idMeasurement`),
  INDEX `idSilo_idx` (`idSilo` ASC) VISIBLE,
  CONSTRAINT `idSilo`
    FOREIGN KEY (`idSilo`)
    REFERENCES `hollowminds_database`.`silo` (`idSilo`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `hollowminds_database`.`User`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `hollowminds_database`.`User` (
  `idUser` INT NOT NULL AUTO_INCREMENT,
  `mail` VARCHAR(100) NOT NULL,
  `password` VARCHAR(100) NOT NULL,
  `isAdmin` TINYINT(1) NOT NULL,
  `name` VARCHAR(100) NOT NULL,
  `surname` VARCHAR(100) NOT NULL,
  PRIMARY KEY (`idUser`))
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;