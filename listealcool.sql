-- phpMyAdmin SQL Dump
-- version 4.1.14
-- http://www.phpmyadmin.net
--
-- Client :  127.0.0.1
-- Généré le :  Dim 22 Novembre 2015 à 14:21
-- Version du serveur :  5.6.17
-- Version de PHP :  5.5.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Base de données :  `alcool_richardeau`
--
CREATE DATABASE alcool_richardeau;
USE alcool_richardeau;
-- --------------------------------------------------------

--
-- Structure de la table `listealcool`
--

CREATE TABLE IF NOT EXISTS `listealcool` (
  `idListeAlcool` int(11) NOT NULL AUTO_INCREMENT,
  `Nom` varchar(45) DEFAULT NULL,
  `taux` double DEFAULT NULL,
  PRIMARY KEY (`idListeAlcool`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=23 ;

--
-- Contenu de la table `listealcool`
--

INSERT INTO `listealcool` (`idListeAlcool`, `Nom`, `taux`) VALUES
(1, 'Vodka', 37.5),
(2, 'Whisky', 40),
(3, 'Rhum', 40),
(4, 'Tequila', 35),
(5, 'Get 27', 21),
(6, 'Kronenbourg', 4.2),
(7, '1664', 5.5),
(8, 'Grimbergen', 6.7),
(9, 'San Miguel', 5.5),
(10, 'Pastis', 45),
(11, 'Gin', 37.5),
(12, 'Ricard', 45),
(13, 'Leffe', 6.6),
(14, 'Hoegaarden', 5),
(15, 'Heineken', 5);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
