-- phpMyAdmin SQL Dump
-- version 4.7.7
-- https://www.phpmyadmin.net/
--
-- Host: localhost:8889
-- Generation Time: May 23, 2019 at 06:47 PM
-- Server version: 5.6.38
-- PHP Version: 7.2.1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `assassins`
--
CREATE DATABASE IF NOT EXISTS `assassins` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;
USE `assassins`;

-- --------------------------------------------------------

--
-- Table structure for table `contracts`
--

CREATE TABLE `contracts` (
  `id` int(11) NOT NULL,
  `game_id` int(11) NOT NULL,
  `assassin_id` int(11) NOT NULL,
  `target_id` int(11) NOT NULL,
  `contract_start` datetime NOT NULL,
  `contract_end` datetime NOT NULL,
  `is_fulfilled` int(11) NOT NULL,
  `weapon` text,
  `death_day` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `contracts`
--

INSERT INTO `contracts` (`id`, `game_id`, `assassin_id`, `target_id`, `contract_start`, `contract_end`, `is_fulfilled`, `weapon`, `death_day`) VALUES
(7, 2, 14, 15, '2019-05-23 00:00:00', '0001-01-01 00:00:00', 0, NULL, 0),
(8, 2, 16, 17, '2019-05-23 00:00:00', '2019-05-23 09:57:52', 1, 'spoon', 0),
(9, 2, 3, 4, '2019-05-23 00:00:00', '2019-05-23 09:57:41', 1, 'sock', 0),
(10, 2, 20, 21, '2019-05-23 00:00:00', '0001-01-01 00:00:00', 0, NULL, 0),
(11, 2, 1, 2, '2019-05-23 00:00:00', '2019-05-23 09:54:40', 1, 'spoon', 0),
(12, 2, 17, 18, '2019-05-23 00:00:00', '2019-05-23 09:57:07', 1, 'spoon', 0),
(13, 2, 22, 23, '2019-05-23 00:00:00', '2019-05-23 09:51:50', 1, 'sock', 0),
(14, 2, 9, 10, '2019-05-23 00:00:00', '2019-05-23 09:50:24', 1, 'spoon', 0),
(15, 2, 19, 20, '2019-05-23 00:00:00', '0001-01-01 00:00:00', 0, NULL, 0),
(16, 2, 23, 1, '2019-05-23 00:00:00', '0001-01-01 00:00:00', 0, NULL, 0),
(17, 2, 21, 22, '2019-05-23 00:00:00', '2019-05-23 09:54:53', 1, 'spoon', 0),
(18, 2, 8, 9, '2019-05-23 00:00:00', '0001-01-01 00:00:00', 0, NULL, 0),
(19, 2, 5, 6, '2019-05-23 00:00:00', '0001-01-01 00:00:00', 0, NULL, 0),
(20, 2, 18, 19, '2019-05-23 00:00:00', '2019-05-23 09:56:07', 1, 'spoon', 0),
(21, 2, 11, 12, '2019-05-23 00:00:00', '2019-05-23 09:50:41', 1, 'spoon', 0),
(22, 2, 12, 13, '2019-05-23 00:00:00', '0001-01-01 00:00:00', 0, NULL, 0),
(23, 2, 10, 11, '2019-05-23 00:00:00', '0001-01-01 00:00:00', 0, NULL, 0),
(24, 2, 6, 7, '2019-05-23 00:00:00', '0001-01-01 00:00:00', 0, NULL, 0),
(25, 2, 7, 8, '2019-05-23 00:00:00', '2019-05-23 09:50:13', 1, 'sock', 0),
(26, 2, 4, 5, '2019-05-23 00:00:00', '2019-05-23 09:55:24', 1, 'sock', 0),
(27, 2, 13, 14, '2019-05-23 00:00:00', '0001-01-01 00:00:00', 0, NULL, 0),
(28, 2, 15, 16, '2019-05-23 00:00:00', '2019-05-23 09:58:14', 1, 'sock', 0),
(29, 2, 2, 3, '2019-05-23 00:00:00', '0001-01-01 00:00:00', 0, NULL, 0),
(30, 2, 7, 9, '2019-05-23 00:00:00', '0001-01-01 00:00:00', 0, NULL, 0),
(31, 2, 9, 11, '2019-05-23 00:00:00', '2019-05-23 09:50:52', 1, 'spoon', 0),
(32, 2, 11, 13, '2019-05-23 00:00:00', '0001-01-01 00:00:00', 0, NULL, 0),
(33, 2, 9, 13, '2019-05-23 00:00:00', '2019-05-23 09:50:55', 1, 'sock', 0),
(34, 2, 9, 14, '2019-05-23 00:00:00', '2019-05-23 09:55:04', 1, 'spoon', 0),
(35, 2, 22, 1, '2019-05-23 00:00:00', '0001-01-01 00:00:00', 0, NULL, 0),
(36, 2, 1, 3, '2019-05-23 00:00:00', '0001-01-01 00:00:00', 0, NULL, 0),
(37, 2, 21, 1, '2019-05-23 00:00:00', '2019-05-23 09:56:41', 1, 'sock', 0),
(38, 2, 9, 15, '2019-05-23 00:00:00', '0001-01-01 00:00:00', 0, NULL, 0),
(39, 2, 4, 6, '2019-05-23 00:00:00', '2019-05-23 09:55:25', 1, 'sock', 0),
(40, 2, 4, 7, '2019-05-23 00:00:00', '2019-05-23 09:55:27', 1, 'sock', 0),
(41, 2, 4, 9, '2019-05-23 00:00:00', '0001-01-01 00:00:00', 0, NULL, 0),
(42, 2, 18, 20, '2019-05-23 00:00:00', '2019-05-23 09:56:13', 1, 'sock', 0),
(43, 2, 18, 21, '2019-05-23 00:00:00', '0001-01-01 00:00:00', 0, NULL, 0),
(44, 2, 21, 3, '2019-05-23 00:00:00', '0001-01-01 00:00:00', 0, NULL, 0),
(45, 2, 17, 21, '2019-05-23 00:00:00', '2019-05-23 09:57:12', 1, 'sock', 0),
(46, 2, 17, 3, '2019-05-23 00:00:00', '0001-01-01 00:00:00', 0, NULL, 0),
(47, 2, 3, 9, '2019-05-23 00:00:00', '2019-05-23 09:59:23', 1, 'sock', 0),
(48, 2, 16, 3, '2019-05-23 00:00:00', '0001-01-01 00:00:00', 0, NULL, 0),
(49, 2, 15, 3, '2019-05-23 00:00:00', '2019-05-23 10:42:36', 1, 'sock', 0),
(50, 2, 3, 15, '2019-05-23 00:00:00', '0001-01-01 00:00:00', 0, NULL, 0),
(51, 4, 1, 1, '2019-05-23 00:00:00', '0001-01-01 00:00:00', 0, NULL, 0);

-- --------------------------------------------------------

--
-- Table structure for table `games`
--

CREATE TABLE `games` (
  `id` int(11) NOT NULL,
  `team_name` text,
  `password` text,
  `is_start` int(11) NOT NULL,
  `is_end` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `games`
--

INSERT INTO `games` (`id`, `team_name`, `password`, `is_start`, `is_end`) VALUES
(2, 'Episassins', '123', 0, 1),
(3, 'Episassins', '123', 0, 0),
(4, 'Assassins-R-Us', '1', 1, 0);

-- --------------------------------------------------------

--
-- Table structure for table `players`
--

CREATE TABLE `players` (
  `id` int(11) NOT NULL,
  `is_alive` int(11) NOT NULL,
  `assassin_id` int(11) NOT NULL,
  `name` text,
  `password` text,
  `email` text,
  `code_name` text,
  `game_id` int(11) NOT NULL,
  `spoon_score` int(11) NOT NULL,
  `sock_score` int(11) NOT NULL,
  `phone_number` text,
  `image_url` text,
  `is_admin` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `players`
--

INSERT INTO `players` (`id`, `is_alive`, `assassin_id`, `name`, `password`, `email`, `code_name`, `game_id`, `spoon_score`, `sock_score`, `phone_number`, `image_url`, `is_admin`) VALUES
(5, 1, 15, 'Katlin A', '123', 'katlin.nbanderson@gmail.com', 'Squid', 2, 0, 2, '1', NULL, 1),
(6, 0, 13, 'Brooke K', '123', 'sdf', 'Cloud', 2, 0, 0, '1', NULL, 0),
(8, 0, 4, 'Reese L', '123', 'kjkl', 'Lil Boba', 2, 0, 3, '1', NULL, 0),
(9, 0, 7, 'Aj A', '123', 'dsfd', 'Hydrant', 2, 0, 1, '1', NULL, 0),
(10, 0, 6, 'Brian H', '123', 'sdfd', 'Verse', 2, 0, 0, '1', NULL, 0),
(11, 0, 10, 'Colton L', '123', 'kjhkj', 'Beetle', 2, 0, 0, '1', NULL, 0),
(12, 0, 12, 'Darrion', '123', 'dfsdf', 'Show', 2, 0, 0, '1', NULL, 0),
(13, 0, 11, 'Dustin H', '123', 'sdfd', 'Face', 2, 1, 0, '1', NULL, 0),
(14, 0, 18, 'Heather Z', '123', 'dfsd', 'Scissors', 2, 1, 1, '1', NULL, 0),
(15, 0, 5, 'Jared F', '123', 'sdfdsfsd', 'Action', 2, 0, 0, '1', NULL, 0),
(16, 0, 14, 'Joe B', '123', 'dkfjdjkf', 'Snake', 2, 0, 0, '1', NULL, 0),
(17, 0, 21, 'Justin K', '123', 'dkfjdjkf', 'Believe', 2, 1, 1, '1', NULL, 0),
(18, 0, 23, 'Kaya J', '123', 'dsfd', 'Competition ', 2, 0, 0, '1', NULL, 0),
(19, 0, 19, 'Kerriann W', '123', 'dsfds', 'Spy', 2, 0, 0, '1', NULL, 0),
(20, 0, 9, 'Lindsey B', '123', 'sdfd', 'Government', 2, 3, 1, '1', NULL, 0),
(21, 0, 22, 'Liz K', '123', 'dsfds', 'Dolls', 2, 0, 1, '1', NULL, 0),
(22, 0, 17, 'Marc D', '123', 'sdfds', 'Burst', 2, 1, 1, '1', NULL, 0),
(23, 0, 1, 'Mathew A', '123', 'dfds', 'Distance', 2, 1, 0, '1', NULL, 0),
(24, 0, 20, 'Megan S', '123', 'dfsd', 'Bike', 2, 0, 0, '1', NULL, 0),
(25, 0, 3, 'Mike L', '123', 'dfdsf', 'Beef', 2, 0, 2, '1', NULL, 0),
(26, 0, 16, 'Todd A', '123', 'dsfdf', 'Comb', 2, 1, 0, '1', NULL, 0),
(27, 0, 2, 'Neil B', '123', 'dkfjdjkf', 'Holiday', 2, 0, 0, '1', NULL, 0),
(28, 0, 8, 'Zsuzsanna M', '123', 'fdsf', 'Wrench', 2, 0, 0, '1', NULL, 0),
(29, 1, 1, 'Katl', '1', 'katl@me.com', 'Break-Neck', 4, 0, 0, '503-234-5678', NULL, 1);

-- --------------------------------------------------------

--
-- Table structure for table `__EFMigrationsHistory`
--

CREATE TABLE `__EFMigrationsHistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `__EFMigrationsHistory`
--

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`) VALUES
('20190523152604_InitialCreate', '2.2.4-servicing-10062');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `contracts`
--
ALTER TABLE `contracts`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `games`
--
ALTER TABLE `games`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `players`
--
ALTER TABLE `players`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `__EFMigrationsHistory`
--
ALTER TABLE `__EFMigrationsHistory`
  ADD PRIMARY KEY (`MigrationId`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `contracts`
--
ALTER TABLE `contracts`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=52;

--
-- AUTO_INCREMENT for table `games`
--
ALTER TABLE `games`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `players`
--
ALTER TABLE `players`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=30;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
