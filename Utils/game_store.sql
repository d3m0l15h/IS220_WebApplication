-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: localhost
-- Generation Time: Dec 25, 2023 at 12:10 PM
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
                           `id` int(10) UNSIGNED NOT NULL,
                           `userID` int(10) UNSIGNED NOT NULL,
                           `street` varchar(255) NOT NULL,
                           `ward` varchar(255) NOT NULL,
                           `city` varchar(255) NOT NULL,
                           `state` varchar(255) NOT NULL,
                           `isDefault` tinyint(1) NOT NULL,
                           `phone` varchar(255) NOT NULL,
                           `receiver` varchar(255) NOT NULL,
                           `created_at` timestamp NOT NULL DEFAULT current_timestamp(),
                           `updated_at` timestamp NULL DEFAULT NULL ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `address`
--

INSERT INTO `address` (`id`, `userID`, `street`, `ward`, `city`, `state`, `isDefault`, `phone`, `receiver`, `created_at`, `updated_at`) VALUES
                                                                                                                                            (1, 1, 'test', 'test', 'test', 'test', 1, 'test', 'test', '2023-12-23 03:44:05', NULL),
                                                                                                                                            (2, 1, 'pcc', 'pcc', 'pcc', 'pcc', 0, '0829004003', 'pcc', '2023-12-23 14:39:15', NULL),
                                                                                                                                            (8, 1, '21413414', '2354235', '423', '213', 0, '4134134', '34421', '2023-12-25 06:15:20', NULL),
                                                                                                                                            (9, 1, 'dá', 'Phường Hòa Cường Nam', 'Quận Hải Châu', 'Thành phố Đà Nẵng', 0, 'dá', 'dá', '2023-12-25 10:59:46', NULL);

-- --------------------------------------------------------

--
-- Table structure for table `aspnetroleclaims`
--

CREATE TABLE `aspnetroleclaims` (
                                    `Id` int(11) NOT NULL,
                                    `RoleId` int(10) UNSIGNED NOT NULL,
                                    `ClaimType` longtext DEFAULT NULL,
                                    `ClaimValue` longtext DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `aspnetroles`
--

CREATE TABLE `aspnetroles` (
                               `Id` int(10) UNSIGNED NOT NULL,
                               `Name` varchar(256) DEFAULT NULL,
                               `NormalizedName` varchar(256) DEFAULT NULL,
                               `ConcurrencyStamp` longtext DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `aspnetuserclaims`
--

CREATE TABLE `aspnetuserclaims` (
                                    `Id` int(11) NOT NULL,
                                    `UserId` int(10) UNSIGNED NOT NULL,
                                    `ClaimType` longtext DEFAULT NULL,
                                    `ClaimValue` longtext DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `aspnetuserlogins`
--

CREATE TABLE `aspnetuserlogins` (
                                    `LoginProvider` varchar(128) NOT NULL,
                                    `ProviderKey` varchar(128) NOT NULL,
                                    `ProviderDisplayName` longtext DEFAULT NULL,
                                    `UserId` int(10) UNSIGNED NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `aspnetuserroles`
--

CREATE TABLE `aspnetuserroles` (
                                   `UserId` int(10) UNSIGNED NOT NULL,
                                   `RoleId` int(10) UNSIGNED NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `aspnetusers`
--

CREATE TABLE `aspnetusers` (
                               `id` int(10) UNSIGNED NOT NULL,
                               `username` varchar(50) NOT NULL,
                               `email` varchar(256) DEFAULT NULL,
                               `firstName` varchar(50) DEFAULT 'NULL',
                               `lastName` varchar(50) DEFAULT 'NULL',
                               `phone` varchar(20) DEFAULT 'NULL',
                               `birth` date DEFAULT NULL,
                               `role` tinyint(4) NOT NULL DEFAULT 0,
                               `created` datetime NOT NULL DEFAULT current_timestamp(),
                               `modified` datetime DEFAULT NULL ON UPDATE current_timestamp(),
                               `cash` double(13,2) NOT NULL DEFAULT 0.00,
                               `status` varchar(10) NOT NULL DEFAULT 'active',
                               `avatarPath` tinytext DEFAULT NULL,
                               `NormalizedUserName` varchar(256) DEFAULT NULL,
                               `NormalizedEmail` varchar(256) DEFAULT NULL,
                               `EmailConfirmed` tinyint(1) NOT NULL,
                               `PasswordHash` longtext DEFAULT NULL,
                               `SecurityStamp` longtext DEFAULT NULL,
                               `ConcurrencyStamp` longtext DEFAULT NULL,
                               `PhoneNumber` longtext DEFAULT NULL,
                               `PhoneNumberConfirmed` tinyint(1) NOT NULL,
                               `TwoFactorEnabled` tinyint(1) NOT NULL,
                               `LockoutEnd` datetime(6) DEFAULT NULL,
                               `LockoutEnabled` tinyint(1) NOT NULL,
                               `AccessFailedCount` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `aspnetusers`
--

INSERT INTO `aspnetusers` (`id`, `username`, `email`, `firstName`, `lastName`, `phone`, `birth`, `role`, `created`, `modified`, `cash`, `status`, `avatarPath`, `NormalizedUserName`, `NormalizedEmail`, `EmailConfirmed`, `PasswordHash`, `SecurityStamp`, `ConcurrencyStamp`, `PhoneNumber`, `PhoneNumberConfirmed`, `TwoFactorEnabled`, `LockoutEnd`, `LockoutEnabled`, `AccessFailedCount`) VALUES
                                                                                                                                                                                                                                                                                                                                                                                                    (1, 'admin', 'davicmax123@gmail.com', 'Admin', NULL, '0946388050', '2003-04-17', 1, '2023-11-28 00:22:17', '2023-12-07 17:28:12', 0.00, 'active', '\"\"', 'ADMIN', 'DAVICMAX123@GMAIL.COM', 0, 'AQAAAAIAAYagAAAAEGHYA0mmFwEVvL0QUNRTL+fOMlzMFVaaaI8CZTfk1Zv1MI+jB6iY+BCHw+x27zWQVw==', 'UZURDN3OXFSJGR4Y27HUMNJ53VUAOOG7', '36fdd25c-d0f1-41d2-b32e-6ebab7115bef', NULL, 0, 0, NULL, 0, 0),
                                                                                                                                                                                                                                                                                                                                                                                                    (2, 'user', 'user@gmail.com', 'Dat', 'Dao', '0946388050', '2003-04-17', 0, '2023-11-29 14:48:10', '2023-12-07 11:24:02', 0.00, 'active', '\"\"', 'USER', 'USER@GMAIL.COM', 0, 'AQAAAAIAAYagAAAAEM1dF2GTfpj+gtvFULVsSHFvGGugzPuAYYMZDkXeXWOiiJXvs6008Z392gavQinzzQ==', 'YMK4VTSHD73PMYZXLASHRCTKS3RAGOJ4', 'b45684c9-5141-42b6-b2eb-b8951548af7c', NULL, 0, 0, NULL, 1, 0),
                                                                                                                                                                                                                                                                                                                                                                                                    (8, 'test', '21521930@gm.uit.edu.vn', 'Tien', 'Dat', '0946388050', '2003-04-17', 0, '2023-12-03 14:39:26', '2023-12-07 11:24:02', 0.00, 'active', '\"\"', 'TEST', '21521930@GM.UIT.EDU.VN', 0, 'AQAAAAIAAYagAAAAENi3wqvlzw3m8ylpf7NuJ4PmktmO3GKGQdwXF4S7CppFB2au58C17at0BnWl5z/D7Q==', '6NMG46U2NVHWMX7W4563R42BAP73XE7Z', '689e2b53-1e17-4e8f-b3d1-790af19002f3', NULL, 0, 0, NULL, 1, 0);

-- --------------------------------------------------------

--
-- Table structure for table `aspnetusertokens`
--

CREATE TABLE `aspnetusertokens` (
                                    `UserId` int(10) UNSIGNED NOT NULL,
                                    `LoginProvider` varchar(128) NOT NULL,
                                    `Name` varchar(128) NOT NULL,
                                    `Value` longtext DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `carts`
--

CREATE TABLE `carts` (
                         `id` int(11) NOT NULL,
                         `uid` int(10) UNSIGNED NOT NULL,
                         `game_id` int(10) UNSIGNED NOT NULL,
                         `quantity` int(10) UNSIGNED DEFAULT NULL,
                         `type` int(10) UNSIGNED NOT NULL,
                         `created_at` timestamp NOT NULL DEFAULT current_timestamp(),
                         `updated_at` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

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
                             `id` int(10) UNSIGNED NOT NULL,
                             `name` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `developer`
--

INSERT INTO `developer` (`id`, `name`) VALUES
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
                        `id` int(10) UNSIGNED NOT NULL,
                        `title` varchar(100) NOT NULL,
                        `price` decimal(10,0) NOT NULL,
                        `releaseDate` date NOT NULL,
                        `description` text DEFAULT NULL,
                        `publisher` int(10) UNSIGNED NOT NULL,
                        `developer` int(10) UNSIGNED NOT NULL,
                        `imgPath` tinytext DEFAULT NULL,
                        `downloadLink` tinytext NOT NULL,
                        `status` varchar(10) NOT NULL DEFAULT 'active',
                        `type` int(1) UNSIGNED NOT NULL DEFAULT 2,
                        `stock` int(11) NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `game`
--

INSERT INTO `game` (`id`, `title`, `price`, `releaseDate`, `description`, `publisher`, `developer`, `imgPath`, `downloadLink`, `status`, `type`, `stock`) VALUES
                                                                                                                                                              (1, 'Elden Ring', 1000000, '2022-02-25', 'THE NEW FANTASY ACTION RPG. Rise, Tarnished, and be guided by grace to brandish the power of the Elden Ring and become an Elden Lord in the Lands Between.', 1, 1, '059911b1-c114-4cf3-b1ad-91e90287bc58_6110RSDn3PL.jpg', 'https://store.steampowered.com/app/1245620/ELDEN_RING/', 'active', 1, 6),
                                                                                                                                                              (2, 'Cyberpunk 2077', 495000, '2020-12-10', 'Cyberpunk 2077 is an open-world, action-adventure RPG set in the dark future of Night City — a dangerous megalopolis obsessed with power, glamor, and ceaseless body modification.\r\n', 3, 3, 'bd85fbc6-d484-49c3-809e-094bd2467964_cyberpunk-2077-ready-player-v-i102945.jpg', 'https://store.steampowered.com/app/1091500/Cyberpunk_2077', 'active', 1, 0),
                                                                                                                                                              (3, 'Red Dead Redemption 2', 1000000, '2019-12-05', 'Winner of over 175 Game of the Year Awards and recipient of over 250 perfect scores, RDR2 is the epic tale of outlaw Arthur Morgan and the infamous Van der Linde gang, on the run across America at the dawn of the modern age. Also includes access to the shared living world of Red Dead Online.', 4, 4, 'e968131e-80da-4d56-8979-e2039b55863f_MV5BMjMyZDY5NTctMzQ0Ny00ZTU0LWE1ZDYtNDYzMjAxYjA1ZGYxXkEyXkFqcGdeQXVyNTgyNTA4MjM@._V1_FMjpg_UX1000_.jpg', 'https://store.steampowered.com/app/1174180/Red_Dead_Redemption_2/?curator_clanid=4777282', 'active', 0, 0),
                                                                                                                                                              (4, 'Don\'t Starve Together', 165000, '2016-04-21', 'Fight, Farm, Build and Explore Together in the standalone multiplayer expansion to the uncompromising wilderness survival game, Don\'t Starve.', 5, 5, '19217643-1f3c-45f2-9708-c5400ecae926_32-658-048-01.jpg', 'https://store.steampowered.com/app/322330/Dont_Starve_Together/', 'active', 2, 0),
                                                                                                                                                              (5, 'Stardew Valley', 165000, '2016-02-27', 'You\'ve inherited your grandfather\'s old farm plot in Stardew Valley. Armed with hand-me-down tools and a few coins, you set out to begin your new life. Can you learn to live off the land and turn these overgrown fields into a thriving home?', 6, 6, 'c7a79627-dbd2-4b76-b238-dc8a7654a565_71aqYbO8-xL._AC_UF894,1000_QL80_.jpg', 'https://store.steampowered.com/app/413150/Stardew_Valley/', 'active', 2, 0),
                                                                                                                                                              (6, 'Terraria', 142000, '2011-05-17', 'Dig, fight, explore, build! Nothing is impossible in this action-packed adventure game. Four Pack also available!', 7, 7, '36035b6d-c4e4-4490-a318-d36edd7eece0_71k0BMp4U1L._AC_UF1000,1000_QL80_.jpg', 'https://store.steampowered.com/app/105600/Terraria/', 'active', 2, 0),
                                                                                                                                                              (7, ' Assassin\'s Creed® Unity', 495000, '2014-11-13', 'Assassin’s Creed® Unity tells the story of Arno, a young man who embarks upon an extraordinary journey to expose the true powers behind the French Revolution. In the brand new co-op mode, you and your friends will also be thrown in the middle of a ruthless struggle for the fate of a nation.', 8, 8, 'd84a9147-bf1c-40f2-af33-1257f368ca58_s-l1600.jpg', 'https://store.steampowered.com/app/289650/Assassins_Creed_Unity/', 'active', 2, 0),
(8, 'God of War', 1159000, '2022-01-14', 'His vengeance against the Gods of Olympus years behind him, Kratos now lives as a man in the realm of Norse Gods and monsters. It is in this harsh, unforgiving world that he must fight to survive… and teach his son to do the same.', 9, 9, '6651f230-779d-4b9c-84c4-543ead53dcd1_71DRhS9jOeL._AC_UF1000,1000_QL80_.jpg', 'https://store.steampowered.com/app/1593500/God_of_War/', 'active', 2, 0);

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
  `gameID` int(10) UNSIGNED NOT NULL,
  `userID` int(10) UNSIGNED NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `order`
--

CREATE TABLE `order` (
  `id` int(10) UNSIGNED NOT NULL,
  `date` timestamp NOT NULL DEFAULT current_timestamp(),
  `uid` int(10) UNSIGNED NOT NULL,
  `status` int(10) UNSIGNED NOT NULL DEFAULT 0,
  `paymentMethod` int(10) UNSIGNED NOT NULL,
  `address` int(10) UNSIGNED NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `order`
--

INSERT INTO `order` (`id`, `date`, `uid`, `status`, `paymentMethod`, `address`) VALUES
(2, '2023-12-25 07:16:38', 1, 1, 2, 1),
(3, '2023-12-25 07:24:32', 1, 1, 1, 1),
(4, '2023-12-25 10:46:09', 1, 1, 2, 1),
(5, '2023-12-25 10:46:40', 1, 1, 2, 1),
(6, '2023-12-25 10:46:53', 1, 1, 3, 1),
(7, '2023-12-25 10:47:18', 1, 1, 1, 1),
(8, '2023-12-25 10:48:19', 1, 1, 1, 1),
(9, '2023-12-25 10:49:55', 1, 1, 3, 1),
(10, '2023-12-25 11:00:37', 1, 1, 3, 9);

-- --------------------------------------------------------

--
-- Table structure for table `order_detail`
--

CREATE TABLE `order_detail` (
  `id` int(11) UNSIGNED NOT NULL,
  `price` int(11) NOT NULL,
  `gameId` int(11) UNSIGNED DEFAULT NULL,
  `gameType` int(10) UNSIGNED DEFAULT NULL,
  `quantity` int(10) UNSIGNED DEFAULT NULL,
  `orderId` int(10) UNSIGNED NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `order_detail`
--

INSERT INTO `order_detail` (`id`, `price`, `gameId`, `gameType`, `quantity`, `orderId`) VALUES
(1, 0, 1, 1, 2, 3),
(2, 0, 8, 0, 1, 3),
(3, 0, 1, 1, 2, 4),
(4, 0, 8, 0, 1, 4),
(5, 0, 1, 1, 1, 5),
(6, 0, 1, 1, 1, 8),
(7, 0, 1, 1, 1, 9),
(8, 0, 1, 1, 1, 10);

-- --------------------------------------------------------

--
-- Table structure for table `order_status`
--

CREATE TABLE `order_status` (
  `id` int(10) UNSIGNED NOT NULL,
  `name` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `order_status`
--

INSERT INTO `order_status` (`id`, `name`) VALUES
(1, 'Pending');

-- --------------------------------------------------------

--
-- Table structure for table `paymentmethods`
--

CREATE TABLE `paymentmethods` (
  `id` int(10) UNSIGNED NOT NULL,
  `name` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `paymentmethods`
--

INSERT INTO `paymentmethods` (`id`, `name`) VALUES
(1, 'Banking'),
(2, 'Cash on delivery'),
(3, 'Pay at our store');

-- --------------------------------------------------------

--
-- Table structure for table `publisher`
--

CREATE TABLE `publisher` (
  `id` int(10) UNSIGNED NOT NULL,
  `name` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `publisher`
--

INSERT INTO `publisher` (`id`, `name`) VALUES
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
('20231127123800_Initial', '7.0.11');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `address`
--
ALTER TABLE `address`
  ADD PRIMARY KEY (`id`),
  ADD KEY `FK_Add_User` (`userID`);

--
-- Indexes for table `aspnetroleclaims`
--
ALTER TABLE `aspnetroleclaims`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_AspNetRoleClaims_RoleId` (`RoleId`);

--
-- Indexes for table `aspnetroles`
--
ALTER TABLE `aspnetroles`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `RoleNameIndex` (`NormalizedName`);

--
-- Indexes for table `aspnetuserclaims`
--
ALTER TABLE `aspnetuserclaims`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_AspNetUserClaims_UserId` (`UserId`);

--
-- Indexes for table `aspnetuserlogins`
--
ALTER TABLE `aspnetuserlogins`
  ADD PRIMARY KEY (`LoginProvider`,`ProviderKey`),
  ADD KEY `IX_AspNetUserLogins_UserId` (`UserId`);

--
-- Indexes for table `aspnetuserroles`
--
ALTER TABLE `aspnetuserroles`
  ADD PRIMARY KEY (`UserId`,`RoleId`),
  ADD KEY `IX_AspNetUserRoles_RoleId` (`RoleId`);

--
-- Indexes for table `aspnetusers`
--
ALTER TABLE `aspnetusers`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `username` (`username`),
  ADD UNIQUE KEY `email` (`email`),
  ADD UNIQUE KEY `UserNameIndex` (`NormalizedUserName`),
  ADD KEY `EmailIndex` (`NormalizedEmail`);

--
-- Indexes for table `aspnetusertokens`
--
ALTER TABLE `aspnetusertokens`
  ADD PRIMARY KEY (`UserId`,`LoginProvider`,`Name`);

--
-- Indexes for table `carts`
--
ALTER TABLE `carts`
  ADD PRIMARY KEY (`id`,`uid`,`game_id`),
  ADD KEY `FK_GAME-ID` (`game_id`),
  ADD KEY `FK_aspnetusers-UID` (`uid`);

--
-- Indexes for table `category`
--
ALTER TABLE `category`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `name` (`name`);

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
  ADD KEY `FK_Game_Developer` (`developer`),
  ADD KEY `FK_Game_Publisher` (`publisher`);

--
-- Indexes for table `game_category`
--
ALTER TABLE `game_category`
  ADD PRIMARY KEY (`gameID`,`categoryID`),
  ADD KEY `FK_GC_Category` (`categoryID`),
  ADD KEY `FK_GC_Game` (`gameID`);

--
-- Indexes for table `game_owned`
--
ALTER TABLE `game_owned`
  ADD PRIMARY KEY (`gameID`,`userID`),
  ADD KEY `FK_GameOwner_Game` (`gameID`),
  ADD KEY `FK_GameOwner_User` (`userID`);

--
-- Indexes for table `order`
--
ALTER TABLE `order`
  ADD PRIMARY KEY (`id`),
  ADD KEY `FK_User_Trans` (`uid`),
  ADD KEY `FK_Status_OrderStatus` (`status`),
  ADD KEY `FK_PaymentMethod_PaymentMethod` (`paymentMethod`),
  ADD KEY `FK_Address_Address` (`address`);

--
-- Indexes for table `order_detail`
--
ALTER TABLE `order_detail`
  ADD PRIMARY KEY (`id`),
  ADD KEY `FK_Game_Trans` (`gameId`),
  ADD KEY `FK_OrderId_Order` (`orderId`);

--
-- Indexes for table `order_status`
--
ALTER TABLE `order_status`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `paymentmethods`
--
ALTER TABLE `paymentmethods`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `publisher`
--
ALTER TABLE `publisher`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `__efmigrationshistory`
--
ALTER TABLE `__efmigrationshistory`
  ADD PRIMARY KEY (`MigrationId`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `address`
--
ALTER TABLE `address`
  MODIFY `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT for table `aspnetroleclaims`
--
ALTER TABLE `aspnetroleclaims`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `aspnetroles`
--
ALTER TABLE `aspnetroles`
  MODIFY `Id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `aspnetuserclaims`
--
ALTER TABLE `aspnetuserclaims`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `aspnetusers`
--
ALTER TABLE `aspnetusers`
  MODIFY `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `carts`
--
ALTER TABLE `carts`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=44;

--
-- AUTO_INCREMENT for table `category`
--
ALTER TABLE `category`
  MODIFY `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=33;

--
-- AUTO_INCREMENT for table `developer`
--
ALTER TABLE `developer`
  MODIFY `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT for table `game`
--
ALTER TABLE `game`
  MODIFY `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT for table `order`
--
ALTER TABLE `order`
  MODIFY `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `order_detail`
--
ALTER TABLE `order_detail`
  MODIFY `id` int(11) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT for table `order_status`
--
ALTER TABLE `order_status`
  MODIFY `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `paymentmethods`
--
ALTER TABLE `paymentmethods`
  MODIFY `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `publisher`
--
ALTER TABLE `publisher`
  MODIFY `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `address`
--
ALTER TABLE `address`
  ADD CONSTRAINT `FK_Add_User` FOREIGN KEY (`userID`) REFERENCES `aspnetusers` (`id`);

--
-- Constraints for table `aspnetroleclaims`
--
ALTER TABLE `aspnetroleclaims`
  ADD CONSTRAINT `FK_AspNetRoleClaims_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `aspnetuserclaims`
--
ALTER TABLE `aspnetuserclaims`
  ADD CONSTRAINT `FK_AspNetUserClaims_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`id`) ON DELETE CASCADE;

--
-- Constraints for table `aspnetuserlogins`
--
ALTER TABLE `aspnetuserlogins`
  ADD CONSTRAINT `FK_AspNetUserLogins_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`id`) ON DELETE CASCADE;

--
-- Constraints for table `aspnetuserroles`
--
ALTER TABLE `aspnetuserroles`
  ADD CONSTRAINT `FK_AspNetUserRoles_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_AspNetUserRoles_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`id`) ON DELETE CASCADE;

--
-- Constraints for table `aspnetusertokens`
--
ALTER TABLE `aspnetusertokens`
  ADD CONSTRAINT `FK_AspNetUserTokens_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`id`) ON DELETE CASCADE;

--
-- Constraints for table `carts`
--
ALTER TABLE `carts`
  ADD CONSTRAINT `FK_GAME-ID` FOREIGN KEY (`game_id`) REFERENCES `game` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `FK_aspnetusers-UID` FOREIGN KEY (`uid`) REFERENCES `aspnetusers` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

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
  ADD CONSTRAINT `FK_GC_Category` FOREIGN KEY (`categoryID`) REFERENCES `category` (`id`),
  ADD CONSTRAINT `FK_GC_Game` FOREIGN KEY (`gameID`) REFERENCES `game` (`id`);

--
-- Constraints for table `game_owned`
--
ALTER TABLE `game_owned`
  ADD CONSTRAINT `FK_GameOwner_Game` FOREIGN KEY (`gameID`) REFERENCES `game` (`id`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_GameOwner_User` FOREIGN KEY (`userID`) REFERENCES `aspnetusers` (`id`);

--
-- Constraints for table `order`
--
ALTER TABLE `order`
  ADD CONSTRAINT `FK_Address_Address` FOREIGN KEY (`address`) REFERENCES `address` (`id`),
  ADD CONSTRAINT `FK_PaymentMethod_PaymentMethod` FOREIGN KEY (`paymentMethod`) REFERENCES `paymentmethods` (`id`),
  ADD CONSTRAINT `FK_Status_OrderStatus` FOREIGN KEY (`status`) REFERENCES `order_status` (`id`),
  ADD CONSTRAINT `FK_User_Ord` FOREIGN KEY (`uid`) REFERENCES `aspnetusers` (`id`);

--
-- Constraints for table `order_detail`
--
ALTER TABLE `order_detail`
  ADD CONSTRAINT `FK_OrderId_Order` FOREIGN KEY (`orderId`) REFERENCES `order` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
