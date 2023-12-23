-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Dec 23, 2023 at 06:07 PM
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
-- Table structure for table `address`
--

CREATE TABLE `address` (
  `ID` int(10) UNSIGNED NOT NULL,
  `USERID` int(10) UNSIGNED NOT NULL,
  `STREET` varchar(255) NOT NULL,
  `WARD` varchar(255) NOT NULL,
  `CITY` varchar(255) NOT NULL,
  `STATE` varchar(255) NOT NULL,
  `ISDEFAULT` tinyint(1) NOT NULL,
  `PHONE` varchar(255) NOT NULL,
  `RECEIVER` varchar(255) NOT NULL,
  `CREATED_AT` timestamp NOT NULL DEFAULT current_timestamp(),
  `UPDATED_AT` timestamp NULL DEFAULT NULL ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `aspnetroleclaims`
--

CREATE TABLE `aspnetroleclaims` (
  `ID` int(11) NOT NULL,
  `ROLEID` int(10) UNSIGNED NOT NULL,
  `CLAIMTYPE` longtext DEFAULT NULL,
  `CLAIMVALUE` longtext DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `aspnetroles`
--

CREATE TABLE `aspnetroles` (
  `ID` int(10) UNSIGNED NOT NULL,
  `NAME` varchar(256) DEFAULT NULL,
  `NORMALIZEDNAME` varchar(256) DEFAULT NULL,
  `CONCURRENCYSTAMP` longtext DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `aspnetuserclaims`
--

CREATE TABLE `aspnetuserclaims` (
  `ID` int(11) NOT NULL,
  `USERID` int(10) UNSIGNED NOT NULL,
  `CLAIMTYPE` longtext DEFAULT NULL,
  `CLAIMVALUE` longtext DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `aspnetuserlogins`
--

CREATE TABLE `aspnetuserlogins` (
  `LOGINPROVIDER` varchar(128) NOT NULL,
  `PROVIDERKEY` varchar(128) NOT NULL,
  `PROVIDERDISPLAYNAME` longtext DEFAULT NULL,
  `USERID` int(10) UNSIGNED NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `aspnetuserroles`
--

CREATE TABLE `aspnetuserroles` (
  `USERID` int(10) UNSIGNED NOT NULL,
  `ROLEID` int(10) UNSIGNED NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `aspnetusers`
--

CREATE TABLE `aspnetusers` (
  `ID` int(10) UNSIGNED NOT NULL,
  `USERNAME` varchar(50) NOT NULL,
  `EMAIL` varchar(256) DEFAULT NULL,
  `FIRSTNAME` varchar(50) DEFAULT 'NULL',
  `LASTNAME` varchar(50) DEFAULT 'NULL',
  `PHONE` varchar(20) DEFAULT 'NULL',
  `BIRTH` date DEFAULT NULL,
  `ROLE` tinyint(4) NOT NULL DEFAULT 0,
  `CREATED` datetime NOT NULL DEFAULT current_timestamp(),
  `MODIFIED` datetime DEFAULT NULL ON UPDATE current_timestamp(),
  `CASH` double(13,2) NOT NULL DEFAULT 0.00,
  `STATUS` varchar(10) NOT NULL DEFAULT 'active',
  `AVATARPATH` tinytext DEFAULT NULL,
  `NORMALIZEDUSERNAME` varchar(256) DEFAULT NULL,
  `NORMALIZEDEMAIL` varchar(256) DEFAULT NULL,
  `EMAILCONFIRMED` tinyint(1) NOT NULL,
  `PASSWORDHASH` longtext DEFAULT NULL,
  `SECURITYSTAMP` longtext DEFAULT NULL,
  `CONCURRENCYSTAMP` longtext DEFAULT NULL,
  `PHONENUMBER` longtext DEFAULT NULL,
  `PHONENUMBERCONFIRMED` tinyint(1) NOT NULL,
  `TWOFACTORENABLED` tinyint(1) NOT NULL,
  `LOCKOUTEND` datetime(6) DEFAULT NULL,
  `LOCKOUTENABLED` tinyint(1) NOT NULL,
  `ACCESSFAILEDCOUNT` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `aspnetusers`
--

INSERT INTO `aspnetusers` (`ID`, `USERNAME`, `EMAIL`, `FIRSTNAME`, `LASTNAME`, `PHONE`, `BIRTH`, `ROLE`, `CREATED`, `MODIFIED`, `CASH`, `STATUS`, `AVATARPATH`, `NORMALIZEDUSERNAME`, `NORMALIZEDEMAIL`, `EMAILCONFIRMED`, `PASSWORDHASH`, `SECURITYSTAMP`, `CONCURRENCYSTAMP`, `PHONENUMBER`, `PHONENUMBERCONFIRMED`, `TWOFACTORENABLED`, `LOCKOUTEND`, `LOCKOUTENABLED`, `ACCESSFAILEDCOUNT`) VALUES
(1, 'admin', 'davicmax123@gmail.com', 'Admin', NULL, '0946388050', '2003-04-17', 1, '2023-11-28 00:22:17', '2023-12-07 17:28:12', 0.00, 'active', '\"\"', 'ADMIN', 'DAVICMAX123@GMAIL.COM', 0, 'AQAAAAIAAYagAAAAEGHYA0mmFwEVvL0QUNRTL+fOMlzMFVaaaI8CZTfk1Zv1MI+jB6iY+BCHw+x27zWQVw==', 'UZURDN3OXFSJGR4Y27HUMNJ53VUAOOG7', '36fdd25c-d0f1-41d2-b32e-6ebab7115bef', NULL, 0, 0, NULL, 0, 0),
(2, 'user', 'user@gmail.com', 'Dat', 'Dao', '0946388050', '2003-04-17', 0, '2023-11-29 14:48:10', '2023-12-07 11:24:02', 0.00, 'active', '\"\"', 'USER', 'USER@GMAIL.COM', 0, 'AQAAAAIAAYagAAAAEM1dF2GTfpj+gtvFULVsSHFvGGugzPuAYYMZDkXeXWOiiJXvs6008Z392gavQinzzQ==', 'YMK4VTSHD73PMYZXLASHRCTKS3RAGOJ4', 'b45684c9-5141-42b6-b2eb-b8951548af7c', NULL, 0, 0, NULL, 1, 0),
(8, 'test', '21521930@gm.uit.edu.vn', 'Tien', 'Dat', '0946388050', '2003-04-17', 0, '2023-12-03 14:39:26', '2023-12-07 11:24:02', 0.00, 'active', '\"\"', 'TEST', '21521930@GM.UIT.EDU.VN', 0, 'AQAAAAIAAYagAAAAENi3wqvlzw3m8ylpf7NuJ4PmktmO3GKGQdwXF4S7CppFB2au58C17at0BnWl5z/D7Q==', '6NMG46U2NVHWMX7W4563R42BAP73XE7Z', '689e2b53-1e17-4e8f-b3d1-790af19002f3', NULL, 0, 0, NULL, 1, 0);

-- --------------------------------------------------------

--
-- Table structure for table `aspnetusertokens`
--

CREATE TABLE `aspnetusertokens` (
  `USERID` int(10) UNSIGNED NOT NULL,
  `LOGINPROVIDER` varchar(128) NOT NULL,
  `NAME` varchar(128) NOT NULL,
  `VALUE` longtext DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `carts`
--

CREATE TABLE `carts` (
  `ID` int(11) NOT NULL,
  `UID` int(10) UNSIGNED NOT NULL,
  `GAME_ID` int(10) UNSIGNED NOT NULL,
  `QUANTITY` int(10) UNSIGNED DEFAULT NULL,
  `TYPE` int(10) UNSIGNED NOT NULL,
  `CREATED` timestamp NOT NULL DEFAULT current_timestamp(),
  `MODIFIED` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `category`
--

CREATE TABLE `category` (
  `ID` int(10) UNSIGNED NOT NULL,
  `NAME` varchar(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `category`
--

INSERT INTO `category` (`ID`, `NAME`) VALUES
(9, '2D'),
(12, '3D'),
(5, 'Action'),
(28, 'Adventure'),
(16, 'Arcade'),
(32, 'Assassin'),
(22, 'Co-op\n'),
(2, 'Fantasy'),
(24, 'FPS'),
(15, 'Free to Play\n'),
(19, 'Funny'),
(17, 'Horror'),
(1, 'Indie'),
(14, 'Multiplayer'),
(7, 'Open World'),
(30, 'Pixel Graphics'),
(13, 'Puzzle'),
(25, 'PvE'),
(20, 'PvP'),
(31, 'Relaxing'),
(4, 'RPG'),
(26, 'Sandbox'),
(18, 'Sci-fi\n'),
(10, 'Simulation'),
(8, 'Singleplayer'),
(3, 'Soul'),
(23, 'Sports'),
(11, 'Strategy'),
(21, 'Survival'),
(6, 'Viet Hoa'),
(29, 'Western');

-- --------------------------------------------------------

--
-- Table structure for table `developer`
--

CREATE TABLE `developer` (
  `ID` int(10) UNSIGNED NOT NULL,
  `NAME` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `developer`
--

INSERT INTO `developer` (`ID`, `NAME`) VALUES
(1, 'FromSoftWare'),
(2, 'Bethesda'),
(3, ' CD PROJEKT RED'),
(4, ' Rockstar Games'),
(5, ' Klei Entertainment'),
(6, ' ConcernedApe'),
(7, ' Re-Logic'),
(8, 'Ubisoft'),
(9, ' PlayStation PC LLC');

-- --------------------------------------------------------

--
-- Table structure for table `game`
--

CREATE TABLE `game` (
  `ID` int(10) UNSIGNED NOT NULL,
  `TITLE` varchar(100) NOT NULL,
  `PRICE` double(10,2) UNSIGNED NOT NULL,
  `RELEASEDATE` date NOT NULL,
  `DESCRIPTION` text DEFAULT NULL,
  `PUBLISHER` int(10) UNSIGNED NOT NULL,
  `DEVELOPER` int(10) UNSIGNED NOT NULL,
  `IMGPATH` tinytext DEFAULT NULL,
  `DOWNLOADLINK` tinytext NOT NULL,
  `STATUS` varchar(10) NOT NULL DEFAULT 'active',
  `TYPE` int(1) UNSIGNED NOT NULL DEFAULT 2,
  `STOCK` int(11) NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `game`
--

INSERT INTO `game` (`ID`, `TITLE`, `PRICE`, `RELEASEDATE`, `DESCRIPTION`, `PUBLISHER`, `DEVELOPER`, `IMGPATH`, `DOWNLOADLINK`, `STATUS`, `TYPE`, `STOCK`) VALUES
(1, 'Elden Ring', 1000000.00, '2022-02-25', 'THE NEW FANTASY ACTION RPG. Rise, Tarnished, and be guided by grace to brandish the power of the Elden Ring and become an Elden Lord in the Lands Between.', 1, 1, '059911b1-c114-4cf3-b1ad-91e90287bc58_6110RSDn3PL.jpg', 'https://store.steampowered.com/app/1245620/ELDEN_RING/', 'active', 1, 6),
(2, 'Cyberpunk 2077', 495000.00, '2020-12-10', 'Cyberpunk 2077 is an open-world, action-adventure RPG set in the dark future of Night City — a dangerous megalopolis obsessed with power, glamor, and ceaseless body modification.\r\n', 3, 3, 'bd85fbc6-d484-49c3-809e-094bd2467964_cyberpunk-2077-ready-player-v-i102945.jpg', 'https://store.steampowered.com/app/1091500/Cyberpunk_2077', 'active', 1, 0),
(3, 'Red Dead Redemption 2', 1000000.00, '2019-12-05', 'Winner of over 175 Game of the Year Awards and recipient of over 250 perfect scores, RDR2 is the epic tale of outlaw Arthur Morgan and the infamous Van der Linde gang, on the run across America at the dawn of the modern age. Also includes access to the shared living world of Red Dead Online.', 4, 4, 'e968131e-80da-4d56-8979-e2039b55863f_MV5BMjMyZDY5NTctMzQ0Ny00ZTU0LWE1ZDYtNDYzMjAxYjA1ZGYxXkEyXkFqcGdeQXVyNTgyNTA4MjM@._V1_FMjpg_UX1000_.jpg', 'https://store.steampowered.com/app/1174180/Red_Dead_Redemption_2/?curator_clanid=4777282', 'active', 0, 0),
(4, 'Don\'T STARVE TOGETHER', 165000.00, '2016-04-21', 'FIGHT,\r\n  FARM,\r\n  BUILD AND EXPLORE TOGETHER IN THE STANDALONE MULTIPLAYER EXPANSION TO THE UNCOMPROMISING WILDERNESS SURVIVAL GAME,\r\n  DON\'t Starve.', 5, 5, '19217643-1f3c-45f2-9708-c5400ecae926_32-658-048-01.jpg', 'https://store.steampowered.com/app/322330/Dont_Starve_Together/', 'active', 2, 0),
(5, 'Stardew Valley', 165000.00, '2016-02-27', 'You\'VE INHERITED YOUR GRANDFATHER\'s old farm plot in Stardew Valley. Armed with hand-me-down tools and a few coins, you set out to begin your new life. Can you learn to live off the land and turn these overgrown fields into a thriving home?', 6, 6, 'c7a79627-dbd2-4b76-b238-dc8a7654a565_71aqYbO8-xL._AC_UF894,1000_QL80_.jpg', 'https://store.steampowered.com/app/413150/Stardew_Valley/', 'active', 2, 0),
(6, 'Terraria', 142000.00, '2011-05-17', 'Dig, fight, explore, build! Nothing is impossible in this action-packed adventure game. Four Pack also available!', 7, 7, '36035b6d-c4e4-4490-a318-d36edd7eece0_71k0BMp4U1L._AC_UF1000,1000_QL80_.jpg', 'https://store.steampowered.com/app/105600/Terraria/', 'active', 2, 0),
(7, 'Assassin\'S CREED® UNITY', 495000.00, '2014-11-13', 'ASSASSIN’S CREED® UNITY TELLS THE STORY OF ARNO,\r\n  A YOUNG MAN WHO EMBARKS UPON AN EXTRAORDINARY JOURNEY TO EXPOSE THE TRUE POWERS BEHIND THE FRENCH REVOLUTION. IN THE BRAND NEW CO-OP MODE,\r\n  YOU AND YOUR FRIENDS WILL ALSO BE THROWN IN THE MIDDLE OF A RUTHLESS STRUGGLE FOR THE FATE OF A NATION.', 8, 8, 'D84A9147-BF1C-40f2-AF33-1257f368ca58_s-L1600.JPG', 'HTTPS://STORE.STEAMPOWERED.COM/APP/289650/ASSASSINS_CREED_UNITY/', 'active', 2, 0),
(8, 'GOD OF WAR', 1159000.00, '2022-01-14', 'HIS VENGEANCE AGAINST THE GODS OF OLYMPUS YEARS BEHIND HIM,\r\n  KRATOS NOW LIVES AS A MAN IN THE REALM OF NORSE GODS AND MONSTERS. IT IS IN THIS HARSH,\r\n  UNFORGIVING WORLD THAT HE MUST FIGHT TO SURVIVE… AND TEACH HIS SON TO DO THE SAME.', 9, 9, '6651f230-779d-4b9c-84c4-543ead53dcd1_71DRhS9jOeL._AC_UF1000,1000_QL80_.JPG', 'HTTPS://STORE.STEAMPOWERED.COM/APP/1593500/GOD_OF_WAR/', 'active', 2, 0);

-- --------------------------------------------------------

--
-- Table structure for table `game_category`
--

CREATE TABLE `game_category` (
  `gameID` int(10) UNSIGNED NOT NULL,
  `categoryID` int(10) UNSIGNED NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `game_category`
--

INSERT INTO `game_category` (`gameID`, `categoryID`) VALUES
(1, 2),
(1, 3),
(2, 4),
(2, 5),
(3, 7),
(3, 28),
(3, 29),
(4, 14),
(4, 21),
(5, 1),
(5, 4),
(5, 14),
(5, 26),
(5, 30),
(5, 31),
(6, 9),
(6, 14),
(6, 21),
(6, 26),
(6, 28),
(6, 30),
(7, 5),
(7, 7),
(7, 22),
(7, 28),
(7, 32),
(8, 5),
(8, 8),
(8, 12),
(8, 28);

-- --------------------------------------------------------

--
-- Table structure for table `game_owned`
--

CREATE TABLE `game_owned` (
  `GAMEID` int(10) UNSIGNED NOT NULL,
  `USERID` int(10) UNSIGNED NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `order_detail`
--

CREATE TABLE `order_detail` (
  `id` int(10) UNSIGNED NOT NULL,
  `orderID` int(10) UNSIGNED NOT NULL,
  `gameID` int(10) UNSIGNED NOT NULL,
  `quantity` int(10) UNSIGNED DEFAULT NULL,
  `type` varchar(50) NOT NULL,
  `created` int(11) NOT NULL DEFAULT current_timestamp(),
  `modified` timestamp NULL DEFAULT NULL ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `publisher`
--

CREATE TABLE `publisher` (
  `ID` int(10) UNSIGNED NOT NULL,
  `NAME` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `publisher`
--

INSERT INTO `publisher` (`ID`, `NAME`) VALUES
(1, 'FromSoftware'),
(2, 'Bethesda'),
(3, 'CD PROJEKT RED'),
(4, ' Rockstar Games'),
(5, ' Klei Entertainment'),
(6, ' ConcernedApe'),
(7, ' Re-Logic'),
(8, 'Ubisoft'),
(9, 'Santa Monica Studio');

-- --------------------------------------------------------

--
-- Table structure for table `user_order`
--

CREATE TABLE `user_order` (
  `ID` int(10) UNSIGNED NOT NULL,
  `USERID` int(10) UNSIGNED NOT NULL,
  `addressID` int(10) UNSIGNED NOT NULL,
  `paymentMethod` varchar(50) NOT NULL,
  `STATUS` varchar(15) NOT NULL,
  `created_at` timestamp NOT NULL DEFAULT current_timestamp(),
  `updated_at` timestamp NULL DEFAULT NULL ON UPDATE current_timestamp(),
  `total` double(10,2) UNSIGNED NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `__efmigrationshistory`
--

CREATE TABLE `__efmigrationshistory` (
  `MIGRATIONID` varchar(150) NOT NULL,
  `PRODUCTVERSION` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `__efmigrationshistory`
--

INSERT INTO `__efmigrationshistory` (`MIGRATIONID`, `PRODUCTVERSION`) VALUES
('20231127123800_Initial', '7.0.11');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `address`
--
ALTER TABLE `address`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `FK_ADD_USER` (`USERID`);

--
-- Indexes for table `aspnetroleclaims`
--
ALTER TABLE `aspnetroleclaims`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `IX_ASPNETROLECLAIMS_ROLEID` (`ROLEID`);

--
-- Indexes for table `aspnetroles`
--
ALTER TABLE `aspnetroles`
  ADD PRIMARY KEY (`ID`),
  ADD UNIQUE KEY `ROLENAMEINDEX` (`NORMALIZEDNAME`);

--
-- Indexes for table `aspnetuserclaims`
--
ALTER TABLE `aspnetuserclaims`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `IX_ASPNETUSERCLAIMS_USERID` (`USERID`);

--
-- Indexes for table `aspnetuserlogins`
--
ALTER TABLE `aspnetuserlogins`
  ADD PRIMARY KEY (`LOGINPROVIDER`,`PROVIDERKEY`),
  ADD KEY `IX_ASPNETUSERLOGINS_USERID` (`USERID`);

--
-- Indexes for table `aspnetuserroles`
--
ALTER TABLE `aspnetuserroles`
  ADD PRIMARY KEY (`USERID`,`ROLEID`),
  ADD KEY `IX_ASPNETUSERROLES_ROLEID` (`ROLEID`);

--
-- Indexes for table `aspnetusers`
--
ALTER TABLE `aspnetusers`
  ADD PRIMARY KEY (`ID`),
  ADD UNIQUE KEY `USERNAME` (`USERNAME`),
  ADD UNIQUE KEY `EMAIL` (`EMAIL`),
  ADD UNIQUE KEY `USERNAMEINDEX` (`NORMALIZEDUSERNAME`),
  ADD KEY `EMAILINDEX` (`NORMALIZEDEMAIL`);

--
-- Indexes for table `aspnetusertokens`
--
ALTER TABLE `aspnetusertokens`
  ADD PRIMARY KEY (`USERID`,`LOGINPROVIDER`,`NAME`);

--
-- Indexes for table `carts`
--
ALTER TABLE `carts`
  ADD PRIMARY KEY (`ID`,`UID`,`GAME_ID`),
  ADD KEY `FK_GAME-ID` (`GAME_ID`),
  ADD KEY `FK_ASPNETUSERS-UID` (`UID`);

--
-- Indexes for table `category`
--
ALTER TABLE `category`
  ADD PRIMARY KEY (`ID`),
  ADD UNIQUE KEY `NAME` (`NAME`);

--
-- Indexes for table `developer`
--
ALTER TABLE `developer`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `game`
--
ALTER TABLE `game`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `FK_GAME_DEVELOPER` (`DEVELOPER`),
  ADD KEY `FK_GAME_PUBLISHER` (`PUBLISHER`);

--
-- Indexes for table `game_category`
--
ALTER TABLE `game_category`
  ADD PRIMARY KEY (`gameID`,`categoryID`),
  ADD KEY `FK_GC_CATEGORY` (`categoryID`),
  ADD KEY `FK_GC_GAME` (`gameID`);

--
-- Indexes for table `game_owned`
--
ALTER TABLE `game_owned`
  ADD PRIMARY KEY (`GAMEID`,`USERID`),
  ADD KEY `FK_GAMEOWNER_GAME` (`GAMEID`),
  ADD KEY `FK_GAMEOWNER_USER` (`USERID`);

--
-- Indexes for table `order_detail`
--
ALTER TABLE `order_detail`
  ADD PRIMARY KEY (`id`),
  ADD KEY `FK_ord_det_Order` (`orderID`),
  ADD KEY `FK_ord_det_Game` (`gameID`);

--
-- Indexes for table `publisher`
--
ALTER TABLE `publisher`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `user_order`
--
ALTER TABLE `user_order`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `FK_USER_TRANS` (`USERID`),
  ADD KEY `FK_ADDRESS_ORD` (`addressID`);

--
-- Indexes for table `__efmigrationshistory`
--
ALTER TABLE `__efmigrationshistory`
  ADD PRIMARY KEY (`MIGRATIONID`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `address`
--
ALTER TABLE `address`
  MODIFY `ID` int(10) UNSIGNED NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `aspnetroleclaims`
--
ALTER TABLE `aspnetroleclaims`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `aspnetroles`
--
ALTER TABLE `aspnetroles`
  MODIFY `ID` int(10) UNSIGNED NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `aspnetuserclaims`
--
ALTER TABLE `aspnetuserclaims`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `aspnetusers`
--
ALTER TABLE `aspnetusers`
  MODIFY `ID` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `carts`
--
ALTER TABLE `carts`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=40;

--
-- AUTO_INCREMENT for table `category`
--
ALTER TABLE `category`
  MODIFY `ID` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=33;

--
-- AUTO_INCREMENT for table `developer`
--
ALTER TABLE `developer`
  MODIFY `ID` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT for table `game`
--
ALTER TABLE `game`
  MODIFY `ID` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT for table `order_detail`
--
ALTER TABLE `order_detail`
  MODIFY `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `publisher`
--
ALTER TABLE `publisher`
  MODIFY `ID` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT for table `user_order`
--
ALTER TABLE `user_order`
  MODIFY `ID` int(10) UNSIGNED NOT NULL AUTO_INCREMENT;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `address`
--
ALTER TABLE `address`
  ADD CONSTRAINT `FK_ADD_USER` FOREIGN KEY (`USERID`) REFERENCES `aspnetusers` (`ID`);

--
-- Constraints for table `aspnetroleclaims`
--
ALTER TABLE `aspnetroleclaims`
  ADD CONSTRAINT `FK_ASPNETROLECLAIMS_ASPNETROLES_ROLEID` FOREIGN KEY (`ROLEID`) REFERENCES `aspnetroles` (`ID`) ON DELETE CASCADE;

--
-- Constraints for table `aspnetuserclaims`
--
ALTER TABLE `aspnetuserclaims`
  ADD CONSTRAINT `FK_ASPNETUSERCLAIMS_ASPNETUSERS_USERID` FOREIGN KEY (`USERID`) REFERENCES `aspnetusers` (`ID`) ON DELETE CASCADE;

--
-- Constraints for table `aspnetuserlogins`
--
ALTER TABLE `aspnetuserlogins`
  ADD CONSTRAINT `FK_ASPNETUSERLOGINS_ASPNETUSERS_USERID` FOREIGN KEY (`USERID`) REFERENCES `aspnetusers` (`ID`) ON DELETE CASCADE;

--
-- Constraints for table `aspnetuserroles`
--
ALTER TABLE `aspnetuserroles`
  ADD CONSTRAINT `FK_ASPNETUSERROLES_ASPNETROLES_ROLEID` FOREIGN KEY (`ROLEID`) REFERENCES `aspnetroles` (`ID`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_ASPNETUSERROLES_ASPNETUSERS_USERID` FOREIGN KEY (`USERID`) REFERENCES `aspnetusers` (`ID`) ON DELETE CASCADE;

--
-- Constraints for table `aspnetusertokens`
--
ALTER TABLE `aspnetusertokens`
  ADD CONSTRAINT `FK_ASPNETUSERTOKENS_ASPNETUSERS_USERID` FOREIGN KEY (`USERID`) REFERENCES `aspnetusers` (`ID`) ON DELETE CASCADE;

--
-- Constraints for table `carts`
--
ALTER TABLE `carts`
  ADD CONSTRAINT `FK_ASPNETUSERS-UID` FOREIGN KEY (`UID`) REFERENCES `aspnetusers` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `FK_GAME-ID` FOREIGN KEY (`GAME_ID`) REFERENCES `game` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `game`
--
ALTER TABLE `game`
  ADD CONSTRAINT `FK_GAME_DEVELOPER` FOREIGN KEY (`DEVELOPER`) REFERENCES `developer` (`ID`),
  ADD CONSTRAINT `FK_GAME_PUBLISHER` FOREIGN KEY (`PUBLISHER`) REFERENCES `publisher` (`ID`);

--
-- Constraints for table `game_category`
--
ALTER TABLE `game_category`
  ADD CONSTRAINT `FK_GC_CATEGORY` FOREIGN KEY (`categoryID`) REFERENCES `category` (`ID`),
  ADD CONSTRAINT `FK_GC_GAME` FOREIGN KEY (`gameID`) REFERENCES `game` (`ID`);

--
-- Constraints for table `game_owned`
--
ALTER TABLE `game_owned`
  ADD CONSTRAINT `FK_GAMEOWNER_GAME` FOREIGN KEY (`GAMEID`) REFERENCES `game` (`ID`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_GAMEOWNER_USER` FOREIGN KEY (`USERID`) REFERENCES `aspnetusers` (`ID`);

--
-- Constraints for table `order_detail`
--
ALTER TABLE `order_detail`
  ADD CONSTRAINT `FK_ord_det_Game` FOREIGN KEY (`gameID`) REFERENCES `game` (`ID`),
  ADD CONSTRAINT `FK_ord_det_Order` FOREIGN KEY (`orderID`) REFERENCES `user_order` (`ID`);

--
-- Constraints for table `user_order`
--
ALTER TABLE `user_order`
  ADD CONSTRAINT `FK_ADDRESS_ORD` FOREIGN KEY (`addressID`) REFERENCES `address` (`ID`),
  ADD CONSTRAINT `FK_USER_ORD` FOREIGN KEY (`USERID`) REFERENCES `aspnetusers` (`ID`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
