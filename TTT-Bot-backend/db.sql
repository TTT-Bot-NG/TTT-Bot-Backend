-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema TTT-Bot
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema TTT-Bot
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `TTT-Bot` DEFAULT CHARACTER SET utf8 ;
USE `TTT-Bot` ;

-- -----------------------------------------------------
-- Table `TTT-Bot`.`CatVsDog`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `TTT-Bot`.`CatVsDog` (
                                                    `Id` INT NOT NULL AUTO_INCREMENT,
                                                    `cat` INT NOT NULL,
                                                    `dog` INT NOT NULL,
                                                    PRIMARY KEY (`Id`))
    ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `TTT-Bot`.`Lottery`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `TTT-Bot`.`Lottery` (
                                                   `Id` BIGINT NOT NULL AUTO_INCREMENT,
                                                   `EndTime` DATETIME NOT NULL,
                                                   PRIMARY KEY (`Id`))
    ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `TTT-Bot`.`Guild`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `TTT-Bot`.`Guild` (
                                                 `Id` INT NOT NULL AUTO_INCREMENT,
                                                 `ExtraIdentifier` BIGINT NULL,
                                                 `CatVsDogId` INT NOT NULL,
                                                 `LotteryId` BIGINT NOT NULL,
                                                 PRIMARY KEY (`Id`, `CatVsDogId`, `LotteryId`),
                                                 INDEX `fk_Guild_catvsdog_idx` (`CatVsDogId` ASC) VISIBLE,
                                                 INDEX `fk_Guild_Lottery1_idx` (`LotteryId` ASC) VISIBLE,
                                                 CONSTRAINT `fk_Guild_catvsdog`
                                                     FOREIGN KEY (`CatVsDogId`)
                                                         REFERENCES `TTT-Bot`.`CatVsDog` (`Id`)
                                                         ON DELETE NO ACTION
                                                         ON UPDATE NO ACTION,
                                                 CONSTRAINT `fk_Guild_Lottery1`
                                                     FOREIGN KEY (`LotteryId`)
                                                         REFERENCES `TTT-Bot`.`Lottery` (`Id`)
                                                         ON DELETE NO ACTION
                                                         ON UPDATE NO ACTION)
    ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `TTT-Bot`.`Settings`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `TTT-Bot`.`Settings` (
                                                    `Id` INT NOT NULL AUTO_INCREMENT,
                                                    `PrivateLevelUpNotifications` TINYINT NOT NULL,
                                                    `DailyNotifications` TINYINT NOT NULL,
                                                    `WeeklyNotifications` TINYINT NOT NULL,
                                                    `HoroscopeNotifications` TINYINT NOT NULL,
                                                    PRIMARY KEY (`Id`))
    ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `TTT-Bot`.`Statistics`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `TTT-Bot`.`Statistics` (
                                                      `Id` INT NOT NULL AUTO_INCREMENT,
                                                      `MaxDailyStreak` INT NOT NULL,
                                                      `MaxWeeklyStreak` INT NOT NULL,
                                                      PRIMARY KEY (`Id`))
    ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `TTT-Bot`.`Inventory`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `TTT-Bot`.`Inventory` (
                                                     `Id` INT NOT NULL AUTO_INCREMENT,
                                                     PRIMARY KEY (`Id`))
    ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `TTT-Bot`.`UpgradesStatus`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `TTT-Bot`.`UpgradesStatus` (
                                                          `Id` INT NOT NULL AUTO_INCREMENT,
                                                          `XpBoostSlot2` TINYINT NOT NULL,
                                                          `MultiChance2` INT NOT NULL,
                                                          `MultiChance4` INT NOT NULL,
                                                          PRIMARY KEY (`Id`))
    ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `TTT-Bot`.`Garden`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `TTT-Bot`.`Garden` (
                                                  `Id` INT NOT NULL AUTO_INCREMENT,
                                                  PRIMARY KEY (`Id`))
    ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `TTT-Bot`.`Pokemon_Evolution_Group`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `TTT-Bot`.`Pokemon_Evolution_Group` (
                                                                   `Id` INT NOT NULL AUTO_INCREMENT,
                                                                   PRIMARY KEY (`Id`))
    ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `TTT-Bot`.`Pokemon`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `TTT-Bot`.`Pokemon` (
                                                   `Id` INT NOT NULL AUTO_INCREMENT,
                                                   `PokemonEvolutionGroupId` INT NOT NULL,
                                                   `CurrentEvolution` INT NOT NULL,
                                                   `Xp` DOUBLE NOT NULL,
                                                   `CooldownEndTime` DATETIME NULL,
                                                   `CurrentHp` DOUBLE NOT NULL,
                                                   `MaxHp` DOUBLE NOT NULL,
                                                   `Attack` DOUBLE NOT NULL,
                                                   `Defense` DOUBLE NOT NULL,
                                                   `SpAttack` DOUBLE NOT NULL,
                                                   `SpDefense` DOUBLE NOT NULL,
                                                   `Speed` DOUBLE NOT NULL,
                                                   `HpIV` INT NOT NULL,
                                                   `AttackIV` INT NOT NULL,
                                                   `DefenseIV` INT NOT NULL,
                                                   `SpAttackIV` INT NOT NULL,
                                                   `SpDefenseIV` INT NOT NULL,
                                                   `SpeedIV` INT NOT NULL,
                                                   PRIMARY KEY (`Id`, `PokemonEvolutionGroupId`),
                                                   INDEX `fk_Pokemon_Pokemon_Evolution_Group1_idx` (`PokemonEvolutionGroupId` ASC) VISIBLE,
                                                   CONSTRAINT `fk_Pokemon_Pokemon_Evolution_Group1`
                                                       FOREIGN KEY (`PokemonEvolutionGroupId`)
                                                           REFERENCES `TTT-Bot`.`Pokemon_Evolution_Group` (`Id`)
                                                           ON DELETE NO ACTION
                                                           ON UPDATE NO ACTION)
    ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `TTT-Bot`.`User_Has_Pokemon`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `TTT-Bot`.`User_Has_Pokemon` (
                                                            `Id` INT NOT NULL AUTO_INCREMENT,
                                                            `UserId` INT NOT NULL,
                                                            `PokemonId` INT NOT NULL,
                                                            PRIMARY KEY (`Id`, `UserId`, `PokemonId`),
                                                            INDEX `fk_User_has_Pokemon_Pokemon1_idx` (`PokemonId` ASC) VISIBLE,
                                                            INDEX `fk_User_has_Pokemon_User1_idx` (`UserId` ASC) VISIBLE,
                                                            CONSTRAINT `fk_User_has_Pokemon_User1`
                                                                FOREIGN KEY (`UserId`)
                                                                    REFERENCES `TTT-Bot`.`User` (`Id`)
                                                                    ON DELETE NO ACTION
                                                                    ON UPDATE NO ACTION,
                                                            CONSTRAINT `fk_User_has_Pokemon_Pokemon1`
                                                                FOREIGN KEY (`PokemonId`)
                                                                    REFERENCES `TTT-Bot`.`Pokemon` (`Id`)
                                                                    ON DELETE NO ACTION
                                                                    ON UPDATE NO ACTION)
    ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `TTT-Bot`.`User`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `TTT-Bot`.`User` (
                                                `Id` INT NOT NULL AUTO_INCREMENT,
                                                `ExtraIdentifier` BIGINT NULL,
                                                `Xp` DOUBLE NOT NULL,
                                                `ActionCooldown` BIGINT NULL,
                                                `XpBoostMax` INT NULL,
                                                `currency` INT NOT NULL,
                                                `SettingsId` INT NOT NULL,
                                                `Upvotes` BIGINT NULL,
                                                `UpvoteInterval` INT NULL,
                                                `LastDailyClaim` DATETIME NULL,
                                                `LastWeeklyClaim` DATETIME NULL,
                                                `DailyStreak` INT NULL,
                                                `WeeklyStreak` INT NULL,
                                                `StatisticsId` INT NOT NULL,
                                                `InventoryId` INT NOT NULL,
                                                `UpgradesStatusId` INT NOT NULL,
                                                `GardenId` INT NOT NULL,
                                                `AvtivePokemonId` INT NOT NULL,
                                                PRIMARY KEY (`Id`, `SettingsId`, `StatisticsId`, `InventoryId`, `UpgradesStatusId`, `GardenId`, `AvtivePokemonId`),
                                                INDEX `fk_User_Settings1_idx` (`SettingsId` ASC) VISIBLE,
                                                INDEX `fk_User_Statistics1_idx` (`StatisticsId` ASC) VISIBLE,
                                                INDEX `fk_User_Inventory1_idx` (`InventoryId` ASC) VISIBLE,
                                                INDEX `fk_User_UpgradesStatus1_idx` (`UpgradesStatusId` ASC) VISIBLE,
                                                INDEX `fk_User_Garden1_idx` (`GardenId` ASC) VISIBLE,
                                                INDEX `fk_User_User_has_Pokemon1_idx` (`AvtivePokemonId` ASC) VISIBLE,
                                                CONSTRAINT `fk_User_Settings1`
                                                    FOREIGN KEY (`SettingsId`)
                                                        REFERENCES `TTT-Bot`.`Settings` (`Id`)
                                                        ON DELETE NO ACTION
                                                        ON UPDATE NO ACTION,
                                                CONSTRAINT `fk_User_Statistics1`
                                                    FOREIGN KEY (`StatisticsId`)
                                                        REFERENCES `TTT-Bot`.`Statistics` (`Id`)
                                                        ON DELETE NO ACTION
                                                        ON UPDATE NO ACTION,
                                                CONSTRAINT `fk_User_Inventory1`
                                                    FOREIGN KEY (`InventoryId`)
                                                        REFERENCES `TTT-Bot`.`Inventory` (`Id`)
                                                        ON DELETE NO ACTION
                                                        ON UPDATE NO ACTION,
                                                CONSTRAINT `fk_User_UpgradesStatus1`
                                                    FOREIGN KEY (`UpgradesStatusId`)
                                                        REFERENCES `TTT-Bot`.`UpgradesStatus` (`Id`)
                                                        ON DELETE NO ACTION
                                                        ON UPDATE NO ACTION,
                                                CONSTRAINT `fk_User_Garden1`
                                                    FOREIGN KEY (`GardenId`)
                                                        REFERENCES `TTT-Bot`.`Garden` (`Id`)
                                                        ON DELETE NO ACTION
                                                        ON UPDATE NO ACTION,
                                                CONSTRAINT `fk_User_User_has_Pokemon1`
                                                    FOREIGN KEY (`AvtivePokemonId`)
                                                        REFERENCES `TTT-Bot`.`User_Has_Pokemon` (`Id`)
                                                        ON DELETE NO ACTION
                                                        ON UPDATE NO ACTION)
    ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `TTT-Bot`.`LotteryParticipant`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `TTT-Bot`.`LotteryParticipant` (
                                                              `Id` INT NOT NULL AUTO_INCREMENT,
                                                              `UserId` INT NOT NULL,
                                                              `Tickets` INT NOT NULL,
                                                              PRIMARY KEY (`Id`, `UserId`),
                                                              INDEX `fk_LotteryParticipant_User1_idx` (`UserId` ASC) VISIBLE,
                                                              CONSTRAINT `fk_LotteryParticipant_User1`
                                                                  FOREIGN KEY (`UserId`)
                                                                      REFERENCES `TTT-Bot`.`User` (`Id`)
                                                                      ON DELETE NO ACTION
                                                                      ON UPDATE NO ACTION)
    ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `TTT-Bot`.`XpBoost`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `TTT-Bot`.`XpBoost` (
                                                   `Id` INT NOT NULL AUTO_INCREMENT,
                                                   `Name` TEXT NOT NULL,
                                                   `multiplier` INT NOT NULL,
                                                   `Duration` TIME NOT NULL,
                                                   PRIMARY KEY (`Id`))
    ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `TTT-Bot`.`ActiveXpBoost`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `TTT-Bot`.`ActiveXpBoost` (
                                                         `Id` INT NOT NULL AUTO_INCREMENT,
                                                         `EndTime` DATETIME NOT NULL,
                                                         `XpBoostId` INT NOT NULL,
                                                         PRIMARY KEY (`Id`, `XpBoostId`),
                                                         INDEX `fk_ActiveXpBoost_XpBoost1_idx` (`XpBoostId` ASC) VISIBLE,
                                                         CONSTRAINT `fk_ActiveXpBoost_XpBoost1`
                                                             FOREIGN KEY (`XpBoostId`)
                                                                 REFERENCES `TTT-Bot`.`XpBoost` (`Id`)
                                                                 ON DELETE NO ACTION
                                                                 ON UPDATE NO ACTION)
    ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `TTT-Bot`.`Guild_Has_User`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `TTT-Bot`.`Guild_Has_User` (
                                                          `GuildId` INT NOT NULL,
                                                          `UserId` INT NOT NULL,
                                                          `NickName` TEXT NULL,
                                                          PRIMARY KEY (`GuildId`, `UserId`),
                                                          INDEX `fk_Guild_has_User_User1_idx` (`UserId` ASC) VISIBLE,
                                                          INDEX `fk_Guild_has_User_Guild1_idx` (`GuildId` ASC) VISIBLE,
                                                          CONSTRAINT `fk_Guild_has_User_Guild1`
                                                              FOREIGN KEY (`GuildId`)
                                                                  REFERENCES `TTT-Bot`.`Guild` (`Id`)
                                                                  ON DELETE NO ACTION
                                                                  ON UPDATE NO ACTION,
                                                          CONSTRAINT `fk_Guild_has_User_User1`
                                                              FOREIGN KEY (`UserId`)
                                                                  REFERENCES `TTT-Bot`.`User` (`Id`)
                                                                  ON DELETE NO ACTION
                                                                  ON UPDATE NO ACTION)
    ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `TTT-Bot`.`Lottery_Has_LotteryParticipant`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `TTT-Bot`.`Lottery_Has_LotteryParticipant` (
                                                                          `LotteryId` BIGINT NOT NULL,
                                                                          `LotteryParticipantId` INT NOT NULL,
                                                                          PRIMARY KEY (`LotteryId`, `LotteryParticipantId`),
                                                                          INDEX `fk_Lottery_has_LotteryParticipant_LotteryParticipant1_idx` (`LotteryParticipantId` ASC) VISIBLE,
                                                                          INDEX `fk_Lottery_has_LotteryParticipant_Lottery1_idx` (`LotteryId` ASC) VISIBLE,
                                                                          CONSTRAINT `fk_Lottery_has_LotteryParticipant_Lottery1`
                                                                              FOREIGN KEY (`LotteryId`)
                                                                                  REFERENCES `TTT-Bot`.`Lottery` (`Id`)
                                                                                  ON DELETE NO ACTION
                                                                                  ON UPDATE NO ACTION,
                                                                          CONSTRAINT `fk_Lottery_has_LotteryParticipant_LotteryParticipant1`
                                                                              FOREIGN KEY (`LotteryParticipantId`)
                                                                                  REFERENCES `TTT-Bot`.`LotteryParticipant` (`Id`)
                                                                                  ON DELETE NO ACTION
                                                                                  ON UPDATE NO ACTION)
    ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `TTT-Bot`.`User_Has_ActiveXpBoost`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `TTT-Bot`.`User_Has_ActiveXpBoost` (
                                                                  `UserId` INT NOT NULL,
                                                                  `ActiveXpBoostId` INT NOT NULL,
                                                                  PRIMARY KEY (`UserId`, `ActiveXpBoostId`),
                                                                  INDEX `fk_User_has_ActiveXpBoost_ActiveXpBoost1_idx` (`ActiveXpBoostId` ASC) VISIBLE,
                                                                  INDEX `fk_User_has_ActiveXpBoost_User1_idx` (`UserId` ASC) VISIBLE,
                                                                  CONSTRAINT `fk_User_has_ActiveXpBoost_User1`
                                                                      FOREIGN KEY (`UserId`)
                                                                          REFERENCES `TTT-Bot`.`User` (`Id`)
                                                                          ON DELETE NO ACTION
                                                                          ON UPDATE NO ACTION,
                                                                  CONSTRAINT `fk_User_has_ActiveXpBoost_ActiveXpBoost1`
                                                                      FOREIGN KEY (`ActiveXpBoostId`)
                                                                          REFERENCES `TTT-Bot`.`ActiveXpBoost` (`Id`)
                                                                          ON DELETE NO ACTION
                                                                          ON UPDATE NO ACTION)
    ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `TTT-Bot`.`Role`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `TTT-Bot`.`Role` (
                                                `Id` INT NOT NULL AUTO_INCREMENT,
                                                `ExtraIdentifier` BIGINT NULL,
                                                `Name` TEXT NOT NULL,
                                                PRIMARY KEY (`Id`))
    ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `TTT-Bot`.`Guild_Has_User_Has_Role`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `TTT-Bot`.`Guild_Has_User_Has_Role` (
                                                                   `GuildHasUserUserId` INT NOT NULL,
                                                                   `RoleId` INT NOT NULL,
                                                                   PRIMARY KEY (`GuildHasUserUserId`, `RoleId`),
                                                                   INDEX `fk_Guild_has_User_has_Role_Role1_idx` (`RoleId` ASC) VISIBLE,
                                                                   INDEX `fk_Guild_has_User_has_Role_Guild_has_User1_idx` (`GuildHasUserUserId` ASC) VISIBLE,
                                                                   CONSTRAINT `fk_Guild_has_User_has_Role_Guild_has_User1`
                                                                       FOREIGN KEY (`GuildHasUserUserId`)
                                                                           REFERENCES `TTT-Bot`.`Guild_Has_User` (`UserId`)
                                                                           ON DELETE NO ACTION
                                                                           ON UPDATE NO ACTION,
                                                                   CONSTRAINT `fk_Guild_has_User_has_Role_Role1`
                                                                       FOREIGN KEY (`RoleId`)
                                                                           REFERENCES `TTT-Bot`.`Role` (`Id`)
                                                                           ON DELETE NO ACTION
                                                                           ON UPDATE NO ACTION)
    ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `TTT-Bot`.`Item`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `TTT-Bot`.`Item` (
                                                `Id` INT NOT NULL AUTO_INCREMENT,
                                                `Name` TEXT NOT NULL,
                                                PRIMARY KEY (`Id`))
    ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `TTT-Bot`.`Item_Has_Inventory`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `TTT-Bot`.`Item_Has_Inventory` (
                                                              `ItemId` INT NOT NULL,
                                                              `InventoryId` INT NOT NULL,
                                                              `count` INT NOT NULL,
                                                              PRIMARY KEY (`ItemId`, `InventoryId`),
                                                              INDEX `fk_Item_has_Inventory_Inventory1_idx` (`InventoryId` ASC) VISIBLE,
                                                              INDEX `fk_Item_has_Inventory_Item1_idx` (`ItemId` ASC) VISIBLE,
                                                              CONSTRAINT `fk_Item_has_Inventory_Item1`
                                                                  FOREIGN KEY (`ItemId`)
                                                                      REFERENCES `TTT-Bot`.`Item` (`Id`)
                                                                      ON DELETE NO ACTION
                                                                      ON UPDATE NO ACTION,
                                                              CONSTRAINT `fk_Item_has_Inventory_Inventory1`
                                                                  FOREIGN KEY (`InventoryId`)
                                                                      REFERENCES `TTT-Bot`.`Inventory` (`Id`)
                                                                      ON DELETE NO ACTION
                                                                      ON UPDATE NO ACTION)
    ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `TTT-Bot`.`Marriage`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `TTT-Bot`.`Marriage` (
                                                    `Id` INT NOT NULL AUTO_INCREMENT,
                                                    `StartTIme` DATETIME NULL,
                                                    PRIMARY KEY (`Id`))
    ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `TTT-Bot`.`User_Has_Marriage`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `TTT-Bot`.`User_Has_Marriage` (
                                                             `UserId` INT NOT NULL,
                                                             `MarriageId` INT NOT NULL,
                                                             `JoinTime` DATETIME NULL,
                                                             PRIMARY KEY (`UserId`, `MarriageId`),
                                                             INDEX `fk_User_has_Marriage_Marriage1_idx` (`MarriageId` ASC) VISIBLE,
                                                             INDEX `fk_User_has_Marriage_User1_idx` (`UserId` ASC) VISIBLE,
                                                             CONSTRAINT `fk_User_has_Marriage_User1`
                                                                 FOREIGN KEY (`UserId`)
                                                                     REFERENCES `TTT-Bot`.`User` (`Id`)
                                                                     ON DELETE NO ACTION
                                                                     ON UPDATE NO ACTION,
                                                             CONSTRAINT `fk_User_has_Marriage_Marriage1`
                                                                 FOREIGN KEY (`MarriageId`)
                                                                     REFERENCES `TTT-Bot`.`Marriage` (`Id`)
                                                                     ON DELETE NO ACTION
                                                                     ON UPDATE NO ACTION)
    ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `TTT-Bot`.`MarriageJoinRequest`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `TTT-Bot`.`MarriageJoinRequest` (
                                                               `Id` BIGINT NOT NULL AUTO_INCREMENT,
                                                               `UserId` INT NOT NULL,
                                                               `MarriageId` INT NOT NULL,
                                                               PRIMARY KEY (`Id`, `UserId`, `MarriageId`),
                                                               INDEX `fk_MarrigaeJoinRequest_User1_idx` (`UserId` ASC) VISIBLE,
                                                               INDEX `fk_MarrigaeJoinRequest_Marriage1_idx` (`MarriageId` ASC) VISIBLE,
                                                               CONSTRAINT `fk_MarrigaeJoinRequest_User1`
                                                                   FOREIGN KEY (`UserId`)
                                                                       REFERENCES `TTT-Bot`.`User` (`Id`)
                                                                       ON DELETE NO ACTION
                                                                       ON UPDATE NO ACTION,
                                                               CONSTRAINT `fk_MarrigaeJoinRequest_Marriage1`
                                                                   FOREIGN KEY (`MarriageId`)
                                                                       REFERENCES `TTT-Bot`.`Marriage` (`Id`)
                                                                       ON DELETE NO ACTION
                                                                       ON UPDATE NO ACTION)
    ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `TTT-Bot`.`User_Has_Marriage_Must_Process_MarriageJoinRequest`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `TTT-Bot`.`User_Has_Marriage_Must_Process_MarriageJoinRequest` (
                                                                                              `MarriageHasMarriageJoinRequestId` INT NOT NULL,
                                                                                              `UserHasMarriageUserId` INT NOT NULL,
                                                                                              `IsAccepted` TINYINT NULL,
                                                                                              PRIMARY KEY (`MarriageHasMarriageJoinRequestId`, `UserHasMarriageUserId`),
                                                                                              INDEX `fk_Marriage_has_MarrigaeJoinRequest_has_User_has_Marriage_U_idx` (`UserHasMarriageUserId` ASC) VISIBLE,
                                                                                              CONSTRAINT `fk_Marriage_has_MarrigaeJoinRequest_has_User_has_Marriage_Use1`
                                                                                                  FOREIGN KEY (`UserHasMarriageUserId`)
                                                                                                      REFERENCES `TTT-Bot`.`User_Has_Marriage` (`UserId`)
                                                                                                      ON DELETE NO ACTION
                                                                                                      ON UPDATE NO ACTION)
    ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `TTT-Bot`.`PlantType`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `TTT-Bot`.`PlantType` (
                                                     `Id` INT NOT NULL AUTO_INCREMENT,
                                                     `Name` TEXT NOT NULL,
                                                     `TimeToGrow` TIME NOT NULL,
                                                     PRIMARY KEY (`Id`))
    ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `TTT-Bot`.`Plant`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `TTT-Bot`.`Plant` (
                                                 `Id` INT NOT NULL AUTO_INCREMENT,
                                                 `PlantedTime` DATETIME NULL,
                                                 `PlantTypeId` INT NOT NULL,
                                                 PRIMARY KEY (`Id`, `PlantTypeId`),
                                                 INDEX `fk_Plant_PlantType1_idx` (`PlantTypeId` ASC) VISIBLE,
                                                 CONSTRAINT `fk_Plant_PlantType1`
                                                     FOREIGN KEY (`PlantTypeId`)
                                                         REFERENCES `TTT-Bot`.`PlantType` (`Id`)
                                                         ON DELETE NO ACTION
                                                         ON UPDATE NO ACTION)
    ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `TTT-Bot`.`GardenPlot`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `TTT-Bot`.`GardenPlot` (
                                                      `Id` INT NOT NULL,
                                                      `PlantId` INT NOT NULL,
                                                      `IsLocked` TINYINT NOT NULL,
                                                      PRIMARY KEY (`Id`, `PlantId`),
                                                      INDEX `fk_GardenPlot_Plant1_idx` (`PlantId` ASC) VISIBLE,
                                                      CONSTRAINT `fk_GardenPlot_Plant1`
                                                          FOREIGN KEY (`PlantId`)
                                                              REFERENCES `TTT-Bot`.`Plant` (`Id`)
                                                              ON DELETE NO ACTION
                                                              ON UPDATE NO ACTION)
    ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `TTT-Bot`.`PlantYield`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `TTT-Bot`.`PlantYield` (
                                                      `Id` INT NOT NULL AUTO_INCREMENT,
                                                      `MinAmount` INT NOT NULL,
                                                      `MaxAmount` INT NOT NULL,
                                                      `ItemId` INT NOT NULL,
                                                      PRIMARY KEY (`Id`, `ItemId`),
                                                      INDEX `fk_PlantYield_Item1_idx` (`ItemId` ASC) VISIBLE,
                                                      CONSTRAINT `fk_PlantYield_Item1`
                                                          FOREIGN KEY (`ItemId`)
                                                              REFERENCES `TTT-Bot`.`Item` (`Id`)
                                                              ON DELETE NO ACTION
                                                              ON UPDATE NO ACTION)
    ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `TTT-Bot`.`PlantType_Has_PlantYield`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `TTT-Bot`.`PlantType_Has_PlantYield` (
                                                                    `PlantTypeId` INT NOT NULL,
                                                                    `PlantYieldId` INT NOT NULL,
                                                                    PRIMARY KEY (`PlantTypeId`, `PlantYieldId`),
                                                                    INDEX `fk_PlantType_has_PlantYield_PlantYield1_idx` (`PlantYieldId` ASC) VISIBLE,
                                                                    INDEX `fk_PlantType_has_PlantYield_PlantType1_idx` (`PlantTypeId` ASC) VISIBLE,
                                                                    CONSTRAINT `fk_PlantType_has_PlantYield_PlantType1`
                                                                        FOREIGN KEY (`PlantTypeId`)
                                                                            REFERENCES `TTT-Bot`.`PlantType` (`Id`)
                                                                            ON DELETE NO ACTION
                                                                            ON UPDATE NO ACTION,
                                                                    CONSTRAINT `fk_PlantType_has_PlantYield_PlantYield1`
                                                                        FOREIGN KEY (`PlantYieldId`)
                                                                            REFERENCES `TTT-Bot`.`PlantYield` (`Id`)
                                                                            ON DELETE NO ACTION
                                                                            ON UPDATE NO ACTION)
    ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `TTT-Bot`.`Garden_Has_GardenPlot`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `TTT-Bot`.`Garden_Has_GardenPlot` (
                                                                 `GardenId` INT NOT NULL,
                                                                 `GardenPlotId` INT NOT NULL,
                                                                 PRIMARY KEY (`GardenId`, `GardenPlotId`),
                                                                 INDEX `fk_Garden_has_GardenPlot_GardenPlot1_idx` (`GardenPlotId` ASC) VISIBLE,
                                                                 INDEX `fk_Garden_has_GardenPlot_Garden1_idx` (`GardenId` ASC) VISIBLE,
                                                                 CONSTRAINT `fk_Garden_has_GardenPlot_Garden1`
                                                                     FOREIGN KEY (`GardenId`)
                                                                         REFERENCES `TTT-Bot`.`Garden` (`Id`)
                                                                         ON DELETE NO ACTION
                                                                         ON UPDATE NO ACTION,
                                                                 CONSTRAINT `fk_Garden_has_GardenPlot_GardenPlot1`
                                                                     FOREIGN KEY (`GardenPlotId`)
                                                                         REFERENCES `TTT-Bot`.`GardenPlot` (`Id`)
                                                                         ON DELETE NO ACTION
                                                                         ON UPDATE NO ACTION)
    ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `TTT-Bot`.`Pokemon_Evolution`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `TTT-Bot`.`Pokemon_Evolution` (
                                                             `PokedexId` INT NOT NULL,
                                                             `Name` TEXT NOT NULL,
                                                             `BaseHp` INT NOT NULL,
                                                             `BaseAttack` INT NOT NULL,
                                                             `BaseDefense` INT NOT NULL,
                                                             `BaseSpAttack` INT NOT NULL,
                                                             `BaseSpDefense` INT NOT NULL,
                                                             PRIMARY KEY (`PokedexId`))
    ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `TTT-Bot`.`PokemonType`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `TTT-Bot`.`PokemonType` (
                                                       `Id` INT NOT NULL AUTO_INCREMENT,
                                                       `Name` TEXT NOT NULL,
                                                       PRIMARY KEY (`Id`))
    ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `TTT-Bot`.`PokemonType_Is_Weak_Against_PokemonType`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `TTT-Bot`.`PokemonType_Is_Weak_Against_PokemonType` (
                                                                                   `PokemonTypeId` INT NOT NULL,
                                                                                   `WeakAgainstPokemonTypeId` INT NOT NULL,
                                                                                   `DamageMultiplier` DOUBLE NOT NULL,
                                                                                   PRIMARY KEY (`PokemonTypeId`, `WeakAgainstPokemonTypeId`),
                                                                                   INDEX `fk_PokemonType_has_PokemonType_PokemonType2_idx` (`WeakAgainstPokemonTypeId` ASC) VISIBLE,
                                                                                   INDEX `fk_PokemonType_has_PokemonType_PokemonType1_idx` (`PokemonTypeId` ASC) VISIBLE,
                                                                                   CONSTRAINT `fk_PokemonType_has_PokemonType_PokemonType1`
                                                                                       FOREIGN KEY (`PokemonTypeId`)
                                                                                           REFERENCES `TTT-Bot`.`PokemonType` (`Id`)
                                                                                           ON DELETE NO ACTION
                                                                                           ON UPDATE NO ACTION,
                                                                                   CONSTRAINT `fk_PokemonType_has_PokemonType_PokemonType2`
                                                                                       FOREIGN KEY (`WeakAgainstPokemonTypeId`)
                                                                                           REFERENCES `TTT-Bot`.`PokemonType` (`Id`)
                                                                                           ON DELETE NO ACTION
                                                                                           ON UPDATE NO ACTION)
    ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `TTT-Bot`.`PokemonType_Is_Strong_Against_PokemonType`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `TTT-Bot`.`PokemonType_Is_Strong_Against_PokemonType` (
                                                                                     `PokemonTypeId` INT NOT NULL,
                                                                                     `StrongAgainstPokemonTypeId` INT NOT NULL,
                                                                                     `DamageMultiplier` DOUBLE NOT NULL,
                                                                                     PRIMARY KEY (`PokemonTypeId`, `StrongAgainstPokemonTypeId`),
                                                                                     INDEX `fk_PokemonType_has_PokemonType_PokemonType4_idx` (`StrongAgainstPokemonTypeId` ASC) VISIBLE,
                                                                                     INDEX `fk_PokemonType_has_PokemonType_PokemonType3_idx` (`PokemonTypeId` ASC) VISIBLE,
                                                                                     CONSTRAINT `fk_PokemonType_has_PokemonType_PokemonType3`
                                                                                         FOREIGN KEY (`PokemonTypeId`)
                                                                                             REFERENCES `TTT-Bot`.`PokemonType` (`Id`)
                                                                                             ON DELETE NO ACTION
                                                                                             ON UPDATE NO ACTION,
                                                                                     CONSTRAINT `fk_PokemonType_has_PokemonType_PokemonType4`
                                                                                         FOREIGN KEY (`StrongAgainstPokemonTypeId`)
                                                                                             REFERENCES `TTT-Bot`.`PokemonType` (`Id`)
                                                                                             ON DELETE NO ACTION
                                                                                             ON UPDATE NO ACTION)
    ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `TTT-Bot`.`Pokemon_Has_PokemonType`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `TTT-Bot`.`Pokemon_Has_PokemonType` (
                                                                   `PokemonPokedexId` INT NOT NULL,
                                                                   `PokemonTypeId` INT NOT NULL,
                                                                   PRIMARY KEY (`PokemonPokedexId`, `PokemonTypeId`),
                                                                   INDEX `fk_Pokemon_has_PokemonType_PokemonType1_idx` (`PokemonTypeId` ASC) VISIBLE,
                                                                   INDEX `fk_Pokemon_has_PokemonType_Pokemon1_idx` (`PokemonPokedexId` ASC) VISIBLE,
                                                                   CONSTRAINT `fk_Pokemon_has_PokemonType_Pokemon1`
                                                                       FOREIGN KEY (`PokemonPokedexId`)
                                                                           REFERENCES `TTT-Bot`.`Pokemon_Evolution` (`PokedexId`)
                                                                           ON DELETE NO ACTION
                                                                           ON UPDATE NO ACTION,
                                                                   CONSTRAINT `fk_Pokemon_has_PokemonType_PokemonType1`
                                                                       FOREIGN KEY (`PokemonTypeId`)
                                                                           REFERENCES `TTT-Bot`.`PokemonType` (`Id`)
                                                                           ON DELETE NO ACTION
                                                                           ON UPDATE NO ACTION)
    ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `TTT-Bot`.`Pokemon_Evolution_Group_Has_Pokemon_Evolution`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `TTT-Bot`.`Pokemon_Evolution_Group_Has_Pokemon_Evolution` (
                                                                                         `PokemonEvolutionGroupId` INT NOT NULL,
                                                                                         `PokemonEvolutionPokedexId` INT NOT NULL,
                                                                                         `CurrentEvolution` INT NOT NULL,
                                                                                         PRIMARY KEY (`PokemonEvolutionGroupId`, `PokemonEvolutionPokedexId`),
                                                                                         INDEX `fk_Pokemon_Evolution_Group_has_Pokemon_Evolution_Pokemon_Ev_idx` (`PokemonEvolutionPokedexId` ASC) VISIBLE,
                                                                                         INDEX `fk_Pokemon_Evolution_Group_has_Pokemon_Evolution_Pokemon_Ev_idx1` (`PokemonEvolutionGroupId` ASC) VISIBLE,
                                                                                         CONSTRAINT `fk_Pokemon_Evolution_Group_has_Pokemon_Evolution_Pokemon_Evol1`
                                                                                             FOREIGN KEY (`PokemonEvolutionGroupId`)
                                                                                                 REFERENCES `TTT-Bot`.`Pokemon_Evolution_Group` (`Id`)
                                                                                                 ON DELETE NO ACTION
                                                                                                 ON UPDATE NO ACTION,
                                                                                         CONSTRAINT `fk_Pokemon_Evolution_Group_has_Pokemon_Evolution_Pokemon_Evol2`
                                                                                             FOREIGN KEY (`PokemonEvolutionPokedexId`)
                                                                                                 REFERENCES `TTT-Bot`.`Pokemon_Evolution` (`PokedexId`)
                                                                                                 ON DELETE NO ACTION
                                                                                                 ON UPDATE NO ACTION)
    ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `TTT-Bot`.`Notifications`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `TTT-Bot`.`Notifications` (
                                                         `Id` BIGINT NOT NULL AUTO_INCREMENT,
                                                         `Message` TEXT NOT NULL,
                                                         `NotifyTime` DATETIME NOT NULL,
                                                         PRIMARY KEY (`Id`))
    ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `TTT-Bot`.`Notifications_Has_User`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `TTT-Bot`.`Notifications_Has_User` (
                                                                  `NotificationsId` BIGINT NOT NULL,
                                                                  `UserId` INT NOT NULL,
                                                                  PRIMARY KEY (`NotificationsId`, `UserId`),
                                                                  INDEX `fk_Notifications_has_User_User1_idx` (`UserId` ASC) VISIBLE,
                                                                  INDEX `fk_Notifications_has_User_Notifications1_idx` (`NotificationsId` ASC) VISIBLE,
                                                                  CONSTRAINT `fk_Notifications_has_User_Notifications1`
                                                                      FOREIGN KEY (`NotificationsId`)
                                                                          REFERENCES `TTT-Bot`.`Notifications` (`Id`)
                                                                          ON DELETE NO ACTION
                                                                          ON UPDATE NO ACTION,
                                                                  CONSTRAINT `fk_Notifications_has_User_User1`
                                                                      FOREIGN KEY (`UserId`)
                                                                          REFERENCES `TTT-Bot`.`User` (`Id`)
                                                                          ON DELETE NO ACTION
                                                                          ON UPDATE NO ACTION)
    ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `TTT-Bot`.`User_Marriage_Proposal`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `TTT-Bot`.`User_Marriage_Proposal` (
                                                                  `Id` BIGINT NOT NULL AUTO_INCREMENT,
                                                                  `UserId` INT NOT NULL,
                                                                  `ProposalMadeToUserId` INT NOT NULL,
                                                                  `IsAccepted` TINYINT NULL,
                                                                  PRIMARY KEY (`Id`, `UserId`, `ProposalMadeToUserId`),
                                                                  INDEX `fk_User_has_User_User2_idx` (`ProposalMadeToUserId` ASC) VISIBLE,
                                                                  INDEX `fk_User_has_User_User1_idx` (`UserId` ASC) VISIBLE,
                                                                  CONSTRAINT `fk_User_has_User_User1`
                                                                      FOREIGN KEY (`UserId`)
                                                                          REFERENCES `TTT-Bot`.`User` (`Id`)
                                                                          ON DELETE NO ACTION
                                                                          ON UPDATE NO ACTION,
                                                                  CONSTRAINT `fk_User_has_User_User2`
                                                                      FOREIGN KEY (`ProposalMadeToUserId`)
                                                                          REFERENCES `TTT-Bot`.`User` (`Id`)
                                                                          ON DELETE NO ACTION
                                                                          ON UPDATE NO ACTION)
    ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `TTT-Bot`.`BotStats`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `TTT-Bot`.`BotStats` (
    `TotalCurrencyGenerated` INT NOT NULL)
    ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `TTT-Bot`.`MarriageJoinRequest_Has_User_Has_Marriage`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `TTT-Bot`.`MarriageJoinRequest_Has_User_Has_Marriage` (
                                                                                     `MarriageJoinRequestId` BIGINT NOT NULL,
                                                                                     `UserHasMarriageUserId` INT NOT NULL,
                                                                                     `UserHasMarriageMarriageId` INT NOT NULL,
                                                                                     PRIMARY KEY (`MarriageJoinRequestId`, `UserHasMarriageUserId`, `UserHasMarriageMarriageId`),
                                                                                     INDEX `fk_MarrigaeJoinRequest_has_User_Has_Marriage_User_Has_Marri_idx` (`UserHasMarriageUserId` ASC, `UserHasMarriageMarriageId` ASC) VISIBLE,
                                                                                     INDEX `fk_MarrigaeJoinRequest_has_User_Has_Marriage_MarrigaeJoinRe_idx` (`MarriageJoinRequestId` ASC) VISIBLE,
                                                                                     CONSTRAINT `fk_MarrigaeJoinRequest_has_User_Has_Marriage_MarrigaeJoinRequ1`
                                                                                         FOREIGN KEY (`MarriageJoinRequestId`)
                                                                                             REFERENCES `TTT-Bot`.`MarriageJoinRequest` (`Id`)
                                                                                             ON DELETE NO ACTION
                                                                                             ON UPDATE NO ACTION,
                                                                                     CONSTRAINT `fk_MarrigaeJoinRequest_has_User_Has_Marriage_User_Has_Marriage1`
                                                                                         FOREIGN KEY (`UserHasMarriageUserId` , `UserHasMarriageMarriageId`)
                                                                                             REFERENCES `TTT-Bot`.`User_Has_Marriage` (`UserId` , `MarriageId`)
                                                                                             ON DELETE NO ACTION
                                                                                             ON UPDATE NO ACTION)
    ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
