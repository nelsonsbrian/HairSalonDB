-- phpMyAdmin SQL Dump
-- version 4.7.0
-- https://www.phpmyadmin.net/
--
-- Host: localhost:8889
-- Generation Time: Sep 21, 2018 at 10:40 PM
-- Server version: 5.6.34-log
-- PHP Version: 7.2.1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `brian_nelson`
--
CREATE DATABASE IF NOT EXISTS `brian_nelson` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;
USE `brian_nelson`;

-- --------------------------------------------------------

--
-- Table structure for table `clients`
--

CREATE TABLE `clients` (
  `id` int(32) NOT NULL,
  `name` varchar(255) NOT NULL,
  `address` varchar(255) NOT NULL,
  `phone` varchar(255) NOT NULL,
  `stylist_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `clients`
--

INSERT INTO `clients` (`id`, `name`, `address`, `phone`, `stylist_id`) VALUES
(10, 'Maggie', '18616 SE 265th ST', '2532934203', 4),
(11, 'Kelsey', '18616 SE 265th ST', '2532934203', 4),
(12, 'Baret', '123 West Military Rd', '2532934203', 4),
(13, 'Sharon', '178 E Sleeper Rd', '333-333-0333', 7),
(14, 'Andrew', '6666 East Rd', '333-333-3322', 5),
(15, 'Troy', '112334 W SE St', '777-666-4444', 6),
(16, 'Captain', '321 Happy Street', '304-303-3033', 5),
(17, 'Larry', '393 Main', '303-3303-3333', 10);

-- --------------------------------------------------------

--
-- Table structure for table `stylists`
--

CREATE TABLE `stylists` (
  `id` int(32) NOT NULL,
  `name` varchar(255) NOT NULL,
  `wage` int(32) NOT NULL,
  `start_date` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `stylists`
--

INSERT INTO `stylists` (`id`, `name`, `wage`, `start_date`) VALUES
(4, 'Ralph', 32, '2018-09-18 00:00:00'),
(5, 'Burt', 32, '2018-09-05 00:00:00'),
(6, 'Bailey', 25, '2018-06-13 00:00:00'),
(7, 'India', 26, '2018-03-08 00:00:00'),
(8, 'Brent', 45, '2018-09-12 00:00:00'),
(9, 'Lauren', 24, '2018-09-03 00:00:00'),
(10, 'Sally', 29, '2018-11-15 00:00:00'),
(11, 'Roxxy', 35, '2233-02-22 00:00:00');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `clients`
--
ALTER TABLE `clients`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `stylists`
--
ALTER TABLE `stylists`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `clients`
--
ALTER TABLE `clients`
  MODIFY `id` int(32) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=18;
--
-- AUTO_INCREMENT for table `stylists`
--
ALTER TABLE `stylists`
  MODIFY `id` int(32) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
