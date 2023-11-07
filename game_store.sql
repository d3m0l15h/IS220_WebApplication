-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Nov 07, 2023 at 08:11 AM
-- Server version: 10.4.28-MariaDB
-- PHP Version: 8.2.4

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `game_store`
--

-- --------------------------------------------------------

--
-- Table structure for table `category`
--

CREATE TABLE `category` (
  `id` int(10) UNSIGNED NOT NULL,
  `name` varchar(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `category`
--

INSERT INTO `category` (`id`, `name`) VALUES
(1, 'Indie'),
(2, 'Fantasy'),
(3, 'Soul');

-- --------------------------------------------------------

--
-- Table structure for table `developer`
--

CREATE TABLE `developer` (
  `id` int(10) UNSIGNED NOT NULL,
  `name` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `developer`
--

INSERT INTO `developer` (`id`, `name`) VALUES
(1, 'FromSoftWare'),
(2, 'Bethesda');

-- --------------------------------------------------------

--
-- Table structure for table `game`
--

CREATE TABLE `game` (
  `id` int(10) UNSIGNED NOT NULL,
  `title` varchar(100) NOT NULL,
  `description` text DEFAULT NULL,
  `price` decimal(10,0) NOT NULL DEFAULT 0,
  `releaseDate` date NOT NULL,
  `imgPath` tinytext DEFAULT NULL,
  `publisher` int(10) UNSIGNED NOT NULL,
  `developer` int(10) UNSIGNED NOT NULL,
  `downloadLink` tinytext NOT NULL,
  `status` varchar(10) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `game`
--

INSERT INTO `game` (`id`, `title`, `description`, `price`, `releaseDate`, `imgPath`, `publisher`, `developer`, `downloadLink`, `status`) VALUES
(1, 'Elden Ring', 'THE NEW FANTASY ACTION RPG. Rise, Tarnished, and be guided by grace to brandish the power of the Elden Ring and become an Elden Lord in the Lands Between.', 1000000, '2022-02-25', '01b2a9b2-d503-4238-85ea-5df323194943_elden-ring-button-03-1623460560664.jpg', 1, 1, 'https://store.steampowered.com/app/1245620/ELDEN_RING/', NULL);

-- --------------------------------------------------------

--
-- Table structure for table `game_category`
--

CREATE TABLE `game_category` (
  `game` int(10) UNSIGNED NOT NULL,
  `category` int(10) UNSIGNED NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `game_category`
--

INSERT INTO `game_category` (`game`, `category`) VALUES
(1, 2),
(1, 3);

-- --------------------------------------------------------

--
-- Table structure for table `game_owned`
--

CREATE TABLE `game_owned` (
  `userID` int(10) UNSIGNED NOT NULL,
  `gameID` int(10) UNSIGNED NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `publisher`
--

CREATE TABLE `publisher` (
  ` id` int(10) UNSIGNED NOT NULL,
  `name` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `publisher`
--

INSERT INTO `publisher` (` id`, `name`) VALUES
(1, 'FromSoftware'),
(2, 'Bethesda');

-- --------------------------------------------------------

--
-- Table structure for table `transaction`
--

CREATE TABLE `transaction` (
  `id` int(10) UNSIGNED NOT NULL,
  `transInfoID` int(11) UNSIGNED NOT NULL,
  `date` timestamp NOT NULL DEFAULT current_timestamp(),
  `userID` int(10) UNSIGNED NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `transaction_infomation`
--

CREATE TABLE `transaction_infomation` (
  `id` int(11) UNSIGNED NOT NULL,
  `typeID` int(11) UNSIGNED NOT NULL,
  `amount` int(11) NOT NULL,
  `gameID` int(11) UNSIGNED DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `transaction_type`
--

CREATE TABLE `transaction_type` (
  `id` int(10) UNSIGNED NOT NULL,
  `name` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `user`
--

CREATE TABLE `user` (
  `id` int(10) UNSIGNED NOT NULL,
  `username` varchar(50) NOT NULL,
  `password` text NOT NULL,
  `email` varchar(100) NOT NULL,
  `firstName` varchar(50) DEFAULT NULL,
  `lastName` varchar(50) DEFAULT NULL,
  `phone` varchar(20) DEFAULT NULL,
  `birth` date DEFAULT NULL,
  `role` tinyint(4) NOT NULL DEFAULT 0,
  `created` datetime NOT NULL DEFAULT current_timestamp(),
  `modified` datetime DEFAULT NULL ON UPDATE current_timestamp(),
  `cash` int(11) NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `user`
--

INSERT INTO `user` (`id`, `username`, `password`, `email`, `firstName`, `lastName`, `phone`, `birth`, `role`, `created`, `modified`, `cash`) VALUES
(1, 'admin', 'admin', 'davicmax123@gmail.com', NULL, NULL, NULL, NULL, 1, '2023-09-26 10:50:34', '2023-09-26 10:51:01', 0);

-- --------------------------------------------------------

--
-- Table structure for table `__efmigrationshistory`
--

CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `__efmigrationshistory`
--

INSERT INTO `__efmigrationshistory` (`MigrationId`, `ProductVersion`) VALUES
('20230927050924_Initial', '7.0.11');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `category`
--
ALTER TABLE `category`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `developer`
--
ALTER TABLE `developer`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `game`
--
ALTER TABLE `game`
  ADD PRIMARY KEY (`id`),
  ADD KEY `FK_Game_Publisher` (`publisher`),
  ADD KEY `FK_Game_Developer` (`developer`);

--
-- Indexes for table `game_category`
--
ALTER TABLE `game_category`
  ADD KEY `FK_GC_Game` (`game`),
  ADD KEY `FK_GC_Category` (`category`);

--
-- Indexes for table `game_owned`
--
ALTER TABLE `game_owned`
  ADD KEY `FK_GameOwner_Game` (`gameID`),
  ADD KEY `FK_GameOwner_User` (`userID`);

--
-- Indexes for table `publisher`
--
ALTER TABLE `publisher`
  ADD PRIMARY KEY (` id`);

--
-- Indexes for table `transaction`
--
ALTER TABLE `transaction`
  ADD PRIMARY KEY (`id`),
  ADD KEY `FK_User_Trans` (`userID`),
  ADD KEY `FK_Info_Trans` (`transInfoID`);

--
-- Indexes for table `transaction_infomation`
--
ALTER TABLE `transaction_infomation`
  ADD PRIMARY KEY (`id`),
  ADD KEY `FK_Game_Trans` (`gameID`),
  ADD KEY `Fk_Type_Trans` (`typeID`);

--
-- Indexes for table `transaction_type`
--
ALTER TABLE `transaction_type`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `username` (`username`),
  ADD UNIQUE KEY `email` (`email`);

--
-- Indexes for table `__efmigrationshistory`
--
ALTER TABLE `__efmigrationshistory`
  ADD PRIMARY KEY (`MigrationId`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `category`
--
ALTER TABLE `category`
  MODIFY `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `developer`
--
ALTER TABLE `developer`
  MODIFY `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `game`
--
ALTER TABLE `game`
  MODIFY `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `publisher`
--
ALTER TABLE `publisher`
  MODIFY ` id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `transaction`
--
ALTER TABLE `transaction`
  MODIFY `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `transaction_infomation`
--
ALTER TABLE `transaction_infomation`
  MODIFY `id` int(11) UNSIGNED NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `transaction_type`
--
ALTER TABLE `transaction_type`
  MODIFY `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `user`
--
ALTER TABLE `user`
  MODIFY `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `game`
--
ALTER TABLE `game`
  ADD CONSTRAINT `FK_Game_Developer` FOREIGN KEY (`developer`) REFERENCES `developer` (`id`),
  ADD CONSTRAINT `FK_Game_Publisher` FOREIGN KEY (`publisher`) REFERENCES `publisher` (`id`);

--
-- Constraints for table `game_category`
--
ALTER TABLE `game_category`
  ADD CONSTRAINT `FK_GC_Category` FOREIGN KEY (`category`) REFERENCES `category` (`id`),
  ADD CONSTRAINT `FK_GC_Game` FOREIGN KEY (`game`) REFERENCES `game` (`id`);

--
-- Constraints for table `game_owned`
--
ALTER TABLE `game_owned`
  ADD CONSTRAINT `FK_GameOwner_Game` FOREIGN KEY (`gameID`) REFERENCES `game` (`id`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_GameOwner_User` FOREIGN KEY (`userID`) REFERENCES `user` (`id`);

--
-- Constraints for table `transaction`
--
ALTER TABLE `transaction`
  ADD CONSTRAINT `FK_Info_Trans` FOREIGN KEY (`transInfoID`) REFERENCES `transaction_infomation` (`id`),
  ADD CONSTRAINT `FK_User_Trans` FOREIGN KEY (`userID`) REFERENCES `user` (`id`);

--
-- Constraints for table `transaction_infomation`
--
ALTER TABLE `transaction_infomation`
  ADD CONSTRAINT `FK_Game_Trans` FOREIGN KEY (`gameID`) REFERENCES `game` (`id`),
  ADD CONSTRAINT `Fk_Type_Trans` FOREIGN KEY (`typeID`) REFERENCES `transaction_type` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
