-- phpMyAdmin SQL Dump
-- version 4.7.0
-- https://www.phpmyadmin.net/
--
-- Host: localhost:3306
-- Generation Time: Aug 19, 2017 at 04:05 AM
-- Server version: 5.6.34-log
-- PHP Version: 7.1.5

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `hair_salon`
--
CREATE DATABASE IF NOT EXISTS `hair_salon` DEFAULT CHARACTER SET latin1 COLLATE latin1_swedish_ci;
USE `hair_salon`;

-- --------------------------------------------------------

--
-- Table structure for table `client`
--

CREATE TABLE `client` (
  `id` int(11) NOT NULL COMMENT 'client id',
  `name` varchar(255) NOT NULL COMMENT 'client name',
  `email` varchar(255) NOT NULL COMMENT 'client email',
  `phone` varchar(20) NOT NULL COMMENT 'client mobile',
  `stylistId` int(11) NOT NULL COMMENT 'client stylist'
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `client`
--

INSERT INTO `client` (`id`, `name`, `email`, `phone`, `stylistId`) VALUES
(3, 'client4', 'client4@gmail.com', '1234567890', 3),
(4, 'client5', 'client6@gmail.com', '123', 3);

-- --------------------------------------------------------

--
-- Table structure for table `stylist`
--

CREATE TABLE `stylist` (
  `id` int(11) NOT NULL COMMENT 'stylist id',
  `name` varchar(255) NOT NULL COMMENT 'stylist name',
  `expertise` varchar(255) NOT NULL COMMENT 'stylist expertise',
  `experience` int(11) NOT NULL COMMENT 'stylist experience',
  `rate` int(11) NOT NULL COMMENT 'stylist rate'
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `stylist`
--

INSERT INTO `stylist` (`id`, `name`, `expertise`, `experience`, `rate`) VALUES
(2, 'parul', 'Haircut', 2, 60),
(3, 'Ina', 'Haircolor', 2, 100);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `client`
--
ALTER TABLE `client`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `stylist`
--
ALTER TABLE `stylist`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `client`
--
ALTER TABLE `client`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT COMMENT 'client id', AUTO_INCREMENT=5;
--
-- AUTO_INCREMENT for table `stylist`
--
ALTER TABLE `stylist`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT COMMENT 'stylist id', AUTO_INCREMENT=4;COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
