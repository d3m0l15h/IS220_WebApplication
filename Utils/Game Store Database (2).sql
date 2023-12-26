-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: localhost
-- Generation Time: Dec 26, 2023 at 12:02 PM
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

CREATE TABLE `ADDRESS` (
  `ID` INT(10) UNSIGNED NOT NULL,
  `USERID` INT(10) UNSIGNED NOT NULL,
  `STREET` VARCHAR(255) NOT NULL,
  `WARD` VARCHAR(255) NOT NULL,
  `CITY` VARCHAR(255) NOT NULL,
  `STATE` VARCHAR(255) NOT NULL,
  `ISDEFAULT` TINYINT(1) NOT NULL,
  `PHONE` VARCHAR(255) NOT NULL,
  `RECEIVER` VARCHAR(255) NOT NULL,
  `CREATED_AT` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP(),
  `UPDATED_AT` TIMESTAMP NULL DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP()
) ENGINE=INNODB DEFAULT CHARSET=UTF8MB4 COLLATE=UTF8MB4_GENERAL_CI;

--
-- Dumping data for table `address`
--

INSERT INTO `ADDRESS` (
  `ID`,
  `USERID`,
  `STREET`,
  `WARD`,
  `CITY`,
  `STATE`,
  `ISDEFAULT`,
  `PHONE`,
  `RECEIVER`,
  `CREATED_AT`,
  `UPDATED_AT`
) VALUES (
  1,
  1,
  'test',
  'test',
  'test',
  'test',
  1,
  'test',
  'test',
  '2023-12-23 03:44:05',
  NULL
),
(
  2,
  1,
  'pcc',
  'pcc',
  'pcc',
  'pcc',
  0,
  '0829004003',
  'pcc',
  '2023-12-23 14:39:15',
  NULL
),
(
  8,
  1,
  '21413414',
  '2354235',
  '423',
  '213',
  0,
  '4134134',
  '34421',
  '2023-12-25 06:15:20',
  NULL
),
(
  9,
  1,
  'dá',
  'Phường Hòa Cường Nam',
  'Quận Hải Châu',
  'Thành phố Đà Nẵng',
  0,
  'dá',
  'dá',
  '2023-12-25 10:59:46',
  NULL
),
(
  10,
  1,
  'da',
  'dsa',
  'Huyện Hoàng Sa',
  'Thành phố Đà Nẵng',
  0,
  'dá',
  'dá',
  '2023-12-26 05:28:27',
  NULL
);

-- --------------------------------------------------------

--
-- Table structure for table `aspnetroleclaims`
--

CREATE TABLE `ASPNETROLECLAIMS` (
  `ID` INT(11) NOT NULL,
  `ROLEID` INT(10) UNSIGNED NOT NULL,
  `CLAIMTYPE` LONGTEXT DEFAULT NULL,
  `CLAIMVALUE` LONGTEXT DEFAULT NULL
) ENGINE=INNODB DEFAULT CHARSET=UTF8MB4 COLLATE=UTF8MB4_GENERAL_CI;

-- --------------------------------------------------------

--
-- Table structure for table `aspnetroles`
--

CREATE TABLE `ASPNETROLES` (
  `ID` INT(10) UNSIGNED NOT NULL,
  `NAME` VARCHAR(256) DEFAULT NULL,
  `NORMALIZEDNAME` VARCHAR(256) DEFAULT NULL,
  `CONCURRENCYSTAMP` LONGTEXT DEFAULT NULL
) ENGINE=INNODB DEFAULT CHARSET=UTF8MB4 COLLATE=UTF8MB4_GENERAL_CI;

-- --------------------------------------------------------

--
-- Table structure for table `aspnetuserclaims`
--

CREATE TABLE `ASPNETUSERCLAIMS` (
  `ID` INT(11) NOT NULL,
  `USERID` INT(10) UNSIGNED NOT NULL,
  `CLAIMTYPE` LONGTEXT DEFAULT NULL,
  `CLAIMVALUE` LONGTEXT DEFAULT NULL
) ENGINE=INNODB DEFAULT CHARSET=UTF8MB4 COLLATE=UTF8MB4_GENERAL_CI;

-- --------------------------------------------------------

--
-- Table structure for table `aspnetuserlogins`
--

CREATE TABLE `ASPNETUSERLOGINS` (
  `LOGINPROVIDER` VARCHAR(128) NOT NULL,
  `PROVIDERKEY` VARCHAR(128) NOT NULL,
  `PROVIDERDISPLAYNAME` LONGTEXT DEFAULT NULL,
  `USERID` INT(10) UNSIGNED NOT NULL
) ENGINE=INNODB DEFAULT CHARSET=UTF8MB4 COLLATE=UTF8MB4_GENERAL_CI;

-- --------------------------------------------------------

--
-- Table structure for table `aspnetuserroles`
--

CREATE TABLE `ASPNETUSERROLES` (
  `USERID` INT(10) UNSIGNED NOT NULL,
  `ROLEID` INT(10) UNSIGNED NOT NULL
) ENGINE=INNODB DEFAULT CHARSET=UTF8MB4 COLLATE=UTF8MB4_GENERAL_CI;

-- --------------------------------------------------------

--
-- Table structure for table `aspnetusers`
--

CREATE TABLE `ASPNETUSERS` (
  `ID` INT(10) UNSIGNED NOT NULL,
  `USERNAME` VARCHAR(50) NOT NULL,
  `EMAIL` VARCHAR(256) DEFAULT NULL,
  `FIRSTNAME` VARCHAR(50) DEFAULT 'NULL',
  `LASTNAME` VARCHAR(50) DEFAULT 'NULL',
  `PHONE` VARCHAR(20) DEFAULT 'NULL',
  `BIRTH` DATE DEFAULT NULL,
  `ROLE` TINYINT(4) NOT NULL DEFAULT 0,
  `CREATED` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP(),
  `MODIFIED` DATETIME DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP(),
  `CASH` DOUBLE(13, 2) NOT NULL DEFAULT 0.00,
  `STATUS` VARCHAR(10) NOT NULL DEFAULT 'active',
  `AVATARPATH` TINYTEXT DEFAULT NULL,
  `NORMALIZEDUSERNAME` VARCHAR(256) DEFAULT NULL,
  `NORMALIZEDEMAIL` VARCHAR(256) DEFAULT NULL,
  `EMAILCONFIRMED` TINYINT(1) NOT NULL,
  `PASSWORDHASH` LONGTEXT DEFAULT NULL,
  `SECURITYSTAMP` LONGTEXT DEFAULT NULL,
  `CONCURRENCYSTAMP` LONGTEXT DEFAULT NULL,
  `PHONENUMBER` LONGTEXT DEFAULT NULL,
  `PHONENUMBERCONFIRMED` TINYINT(1) NOT NULL,
  `TWOFACTORENABLED` TINYINT(1) NOT NULL,
  `LOCKOUTEND` DATETIME(6) DEFAULT NULL,
  `LOCKOUTENABLED` TINYINT(1) NOT NULL,
  `ACCESSFAILEDCOUNT` INT(11) NOT NULL
) ENGINE=INNODB DEFAULT CHARSET=UTF8MB4 COLLATE=UTF8MB4_GENERAL_CI;

--
-- Dumping data for table `aspnetusers`
--

INSERT INTO `ASPNETUSERS` (
  `ID`,
  `USERNAME`,
  `EMAIL`,
  `FIRSTNAME`,
  `LASTNAME`,
  `PHONE`,
  `BIRTH`,
  `ROLE`,
  `CREATED`,
  `MODIFIED`,
  `CASH`,
  `STATUS`,
  `AVATARPATH`,
  `NORMALIZEDUSERNAME`,
  `NORMALIZEDEMAIL`,
  `EMAILCONFIRMED`,
  `PASSWORDHASH`,
  `SECURITYSTAMP`,
  `CONCURRENCYSTAMP`,
  `PHONENUMBER`,
  `PHONENUMBERCONFIRMED`,
  `TWOFACTORENABLED`,
  `LOCKOUTEND`,
  `LOCKOUTENABLED`,
  `ACCESSFAILEDCOUNT`
) VALUES (
  1,
  'admin',
  'davicmax123@gmail.com',
  'Admin',
  NULL,
  '0946388050',
  '2003-04-17',
  1,
  '2023-11-28 00:22:17',
  '2023-12-07 17:28:12',
  0.00,
  'active',
  '\"\"',
  'ADMIN',
  'DAVICMAX123@GMAIL.COM',
  0,
  'AQAAAAIAAYagAAAAEGHYA0mmFwEVvL0QUNRTL+fOMlzMFVaaaI8CZTfk1Zv1MI+jB6iY+BCHw+x27zWQVw==',
  'UZURDN3OXFSJGR4Y27HUMNJ53VUAOOG7',
  '36fdd25c-d0f1-41d2-b32e-6ebab7115bef',
  NULL,
  0,
  0,
  NULL,
  0,
  0
),
(
  2,
  'user',
  'user@gmail.com',
  'Dat',
  'Dao',
  '0946388050',
  '2003-04-17',
  0,
  '2023-11-29 14:48:10',
  '2023-12-07 11:24:02',
  0.00,
  'active',
  '\"\"',
  'USER',
  'USER@GMAIL.COM',
  0,
  'AQAAAAIAAYagAAAAEM1dF2GTfpj+gtvFULVsSHFvGGugzPuAYYMZDkXeXWOiiJXvs6008Z392gavQinzzQ==',
  'YMK4VTSHD73PMYZXLASHRCTKS3RAGOJ4',
  'b45684c9-5141-42b6-b2eb-b8951548af7c',
  NULL,
  0,
  0,
  NULL,
  1,
  0
),
(
  8,
  'test',
  '21521930@gm.uit.edu.vn',
  'Tien',
  'Dat',
  '0946388050',
  '2003-04-17',
  0,
  '2023-12-03 14:39:26',
  '2023-12-07 11:24:02',
  0.00,
  'active',
  '\"\"',
  'TEST',
  '21521930@GM.UIT.EDU.VN',
  0,
  'AQAAAAIAAYagAAAAENi3wqvlzw3m8ylpf7NuJ4PmktmO3GKGQdwXF4S7CppFB2au58C17at0BnWl5z/D7Q==',
  '6NMG46U2NVHWMX7W4563R42BAP73XE7Z',
  '689e2b53-1e17-4e8f-b3d1-790af19002f3',
  NULL,
  0,
  0,
  NULL,
  1,
  0
);

-- --------------------------------------------------------

--
-- Table structure for table `aspnetusertokens`
--

CREATE TABLE `ASPNETUSERTOKENS` (
  `USERID` INT(10) UNSIGNED NOT NULL,
  `LOGINPROVIDER` VARCHAR(128) NOT NULL,
  `NAME` VARCHAR(128) NOT NULL,
  `VALUE` LONGTEXT DEFAULT NULL
) ENGINE=INNODB DEFAULT CHARSET=UTF8MB4 COLLATE=UTF8MB4_GENERAL_CI;

-- --------------------------------------------------------

--
-- Table structure for table `carts`
--

CREATE TABLE `CARTS` (
  `ID` INT(11) NOT NULL,
  `UID` INT(10) UNSIGNED NOT NULL,
  `GAME_ID` INT(10) UNSIGNED NOT NULL,
  `QUANTITY` INT(10) UNSIGNED DEFAULT NULL,
  `TYPE` INT(10) UNSIGNED NOT NULL,
  `CREATED_AT` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP(),
  `UPDATED_AT` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP() ON UPDATE CURRENT_TIMESTAMP()
) ENGINE=INNODB DEFAULT CHARSET=UTF8MB4 COLLATE=UTF8MB4_GENERAL_CI;

--
-- Dumping data for table `carts`
--

INSERT INTO `CARTS` (
  `ID`,
  `UID`,
  `GAME_ID`,
  `QUANTITY`,
  `TYPE`,
  `CREATED_AT`,
  `UPDATED_AT`
) VALUES (
  69,
  1,
  1,
  1,
  1,
  '2023-12-26 10:16:15',
  '2023-12-26 10:16:15'
);

-- --------------------------------------------------------

--
-- Table structure for table `category`
--

CREATE TABLE `CATEGORY` (
  `ID` INT(10) UNSIGNED NOT NULL,
  `NAME` VARCHAR(30) NOT NULL
) ENGINE=INNODB DEFAULT CHARSET=UTF8MB4 COLLATE=UTF8MB4_GENERAL_CI;

--
-- Dumping data for table `category`
--

INSERT INTO `CATEGORY` (
  `ID`,
  `NAME`
) VALUES (
  9,
  '2D'
),
(
  12,
  '3D'
),
(
  5,
  'Action'
),
(
  28,
  'Adventure'
),
(
  16,
  'Arcade'
),
(
  32,
  'Assassin'
),
(
  22,
  'Co-op\n'
),
(
  2,
  'Fantasy'
),
(
  24,
  'FPS'
),
(
  15,
  'Free to Play\n'
),
(
  19,
  'Funny'
),
(
  17,
  'Horror'
),
(
  1,
  'Indie'
),
(
  14,
  'Multiplayer'
),
(
  7,
  'Open World'
),
(
  30,
  'Pixel Graphics'
),
(
  13,
  'Puzzle'
),
(
  25,
  'PvE'
),
(
  20,
  'PvP'
),
(
  31,
  'Relaxing'
),
(
  4,
  'RPG'
),
(
  26,
  'Sandbox'
),
(
  18,
  'Sci-fi\n'
),
(
  10,
  'Simulation'
),
(
  8,
  'Singleplayer'
),
(
  3,
  'Soul'
),
(
  23,
  'Sports'
),
(
  11,
  'Strategy'
),
(
  21,
  'Survival'
),
(
  6,
  'Viet Hoa'
),
(
  29,
  'Western'
);

-- --------------------------------------------------------

--
-- Table structure for table `developer`
--

CREATE TABLE `DEVELOPER` (
  `ID` INT(10) UNSIGNED NOT NULL,
  `NAME` VARCHAR(50) NOT NULL
) ENGINE=INNODB DEFAULT CHARSET=UTF8MB4 COLLATE=UTF8MB4_GENERAL_CI;

--
-- Dumping data for table `developer`
--

INSERT INTO `DEVELOPER` (
  `ID`,
  `NAME`
) VALUES (
  1,
  'FromSoftWare'
),
(
  2,
  'Bethesda'
),
(
  3,
  ' CD PROJEKT RED'
),
(
  4,
  ' Rockstar Games'
),
(
  5,
  ' Klei Entertainment'
),
(
  6,
  ' ConcernedApe'
),
(
  7,
  ' Re-Logic'
),
(
  8,
  'Ubisoft'
),
(
  9,
  ' PlayStation PC LLC'
);

-- --------------------------------------------------------

--
-- Table structure for table `game`
--

CREATE TABLE `GAME` (
  `ID` INT(10) UNSIGNED NOT NULL,
  `TITLE` VARCHAR(100) NOT NULL,
  `PRICE` DECIMAL(10, 0) NOT NULL,
  `RELEASEDATE` DATE NOT NULL,
  `DESCRIPTION` TEXT DEFAULT NULL,
  `PUBLISHER` INT(10) UNSIGNED NOT NULL,
  `DEVELOPER` INT(10) UNSIGNED NOT NULL,
  `IMGPATH` TINYTEXT DEFAULT NULL,
  `DOWNLOADLINK` TINYTEXT NOT NULL,
  `STATUS` VARCHAR(10) NOT NULL DEFAULT 'active',
  `TYPE` INT(1) UNSIGNED NOT NULL DEFAULT 2,
  `STOCK` INT(11) NOT NULL DEFAULT 0
) ENGINE=INNODB DEFAULT CHARSET=UTF8MB4 COLLATE=UTF8MB4_GENERAL_CI;

--
-- Dumping data for table `game`
--

INSERT INTO `GAME` (
  `ID`,
  `TITLE`,
  `PRICE`,
  `RELEASEDATE`,
  `DESCRIPTION`,
  `PUBLISHER`,
  `DEVELOPER`,
  `IMGPATH`,
  `DOWNLOADLINK`,
  `STATUS`,
  `TYPE`,
  `STOCK`
) VALUES (
  1,
  'Elden Ring',
  1000000,
  '2022-02-25',
  'THE NEW FANTASY ACTION RPG. Rise, Tarnished, and be guided by grace to brandish the power of the Elden Ring and become an Elden Lord in the Lands Between.',
  1,
  1,
  '059911b1-c114-4cf3-b1ad-91e90287bc58_6110RSDn3PL.jpg',
  'https://store.steampowered.com/app/1245620/ELDEN_RING/',
  'active',
  1,
  2
),
(
  2,
  'Cyberpunk 2077',
  495000,
  '2020-12-10',
  'Cyberpunk 2077 is an open-world, action-adventure RPG set in the dark future of Night City — a dangerous megalopolis obsessed with power, glamor, and ceaseless body modification.\r\n',
  3,
  3,
  'bd85fbc6-d484-49c3-809e-094bd2467964_cyberpunk-2077-ready-player-v-i102945.jpg',
  'https://store.steampowered.com/app/1091500/Cyberpunk_2077',
  'active',
  1,
  0
),
(
  3,
  'Red Dead Redemption 2',
  1000000,
  '2019-12-05',
  'Winner of over 175 Game of the Year Awards and recipient of over 250 perfect scores, RDR2 is the epic tale of outlaw Arthur Morgan and the infamous Van der Linde gang, on the run across America at the dawn of the modern age. Also includes access to the shared living world of Red Dead Online.',
  4,
  4,
  'e968131e-80da-4d56-8979-e2039b55863f_MV5BMjMyZDY5NTctMzQ0Ny00ZTU0LWE1ZDYtNDYzMjAxYjA1ZGYxXkEyXkFqcGdeQXVyNTgyNTA4MjM@._V1_FMjpg_UX1000_.jpg',
  'https://store.steampowered.com/app/1174180/Red_Dead_Redemption_2/?curator_clanid=4777282',
  'active',
  0,
  0
),
(
  4,
  'Don\'T STARVE TOGETHER', 165000, '2016-04-21', 'FIGHT,
  FARM,
  BUILD AND EXPLORE TOGETHER IN THE STANDALONE MULTIPLAYER EXPANSION TO THE UNCOMPROMISING WILDERNESS SURVIVAL GAME,
  DON\'t Starve.',
  5,
  5,
  '19217643-1f3c-45f2-9708-c5400ecae926_32-658-048-01.jpg',
  'https://store.steampowered.com/app/322330/Dont_Starve_Together/',
  'active',
  2,
  4
),
(
  5,
  'Stardew Valley',
  165000,
  '2016-02-27',
  'You\'VE INHERITED YOUR GRANDFATHER\'s old farm plot in Stardew Valley. Armed with hand-me-down tools and a few coins, you set out to begin your new life. Can you learn to live off the land and turn these overgrown fields into a thriving home?',
  6,
  6,
  'c7a79627-dbd2-4b76-b238-dc8a7654a565_71aqYbO8-xL._AC_UF894,1000_QL80_.jpg',
  'https://store.steampowered.com/app/413150/Stardew_Valley/',
  'active',
  2,
  0
),
(
  6,
  'Terraria',
  142000,
  '2011-05-17',
  'Dig, fight, explore, build! Nothing is impossible in this action-packed adventure game. Four Pack also available!',
  7,
  7,
  '36035b6d-c4e4-4490-a318-d36edd7eece0_71k0BMp4U1L._AC_UF1000,1000_QL80_.jpg',
  'https://store.steampowered.com/app/105600/Terraria/',
  'active',
  2,
  0
),
(
  7,
  ' Assassin\'S CREED® UNITY', 495000, '2014-11-13', 'ASSASSIN’S CREED® UNITY TELLS THE STORY OF ARNO,
  A YOUNG MAN WHO EMBARKS UPON AN EXTRAORDINARY JOURNEY TO EXPOSE THE TRUE POWERS BEHIND THE FRENCH REVOLUTION. IN THE BRAND NEW CO-OP MODE,
  YOU AND YOUR FRIENDS WILL ALSO BE THROWN IN THE MIDDLE OF A RUTHLESS STRUGGLE FOR THE FATE OF A NATION.', 8, 8, 'D84A9147-BF1C-40f2-AF33-1257f368ca58_s-L1600.JPG', 'HTTPS://STORE.STEAMPOWERED.COM/APP/289650/ASSASSINS_CREED_UNITY/', 'ACTIVE', 2, 0),
(8, 'GOD OF WAR', 1159000, '2022-01-14', 'HIS VENGEANCE AGAINST THE GODS OF OLYMPUS YEARS BEHIND HIM,
  KRATOS NOW LIVES AS A MAN IN THE REALM OF NORSE GODS AND MONSTERS. IT IS IN THIS HARSH,
  UNFORGIVING WORLD THAT HE MUST FIGHT TO SURVIVE… AND TEACH HIS SON TO DO THE SAME.', 9, 9, '6651f230-779d-4b9c-84c4-543ead53dcd1_71DRhS9jOeL._AC_UF1000,
  1000_QL80_.JPG', 'HTTPS://STORE.STEAMPOWERED.COM/APP/1593500/GOD_OF_WAR/', 'ACTIVE', 2, 0);

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

INSERT INTO `GAME_CATEGORY` (
  `GAMEID`,
  `CATEGORYID`
) VALUES (
  1,
  2
),
(
  1,
  3
),
(
  2,
  4
),
(
  2,
  5
),
(
  3,
  7
),
(
  3,
  28
),
(
  3,
  29
),
(
  4,
  14
),
(
  4,
  21
),
(
  5,
  1
),
(
  5,
  4
),
(
  5,
  14
),
(
  5,
  26
),
(
  5,
  30
),
(
  5,
  31
),
(
  6,
  9
),
(
  6,
  14
),
(
  6,
  21
),
(
  6,
  26
),
(
  6,
  28
),
(
  6,
  30
),
(
  7,
  5
),
(
  7,
  7
),
(
  7,
  22
),
(
  7,
  28
),
(
  7,
  32
),
(
  8,
  5
),
(
  8,
  8
),
(
  8,
  12
),
(
  8,
  28
);

-- --------------------------------------------------------

--
-- Table structure for table `game_owned`
--

CREATE TABLE `GAME_OWNED` (
  `GAMEID` INT(10) UNSIGNED NOT NULL,
  `USERID` INT(10) UNSIGNED NOT NULL
) ENGINE=INNODB DEFAULT CHARSET=UTF8MB4 COLLATE=UTF8MB4_GENERAL_CI;

-- --------------------------------------------------------

--
-- Table structure for table `order`
--

CREATE TABLE `ORDER` (
  `ID` INT(10) UNSIGNED NOT NULL,
  `DATE` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP(),
  `UID` INT(10) UNSIGNED NOT NULL,
  `STATUS` INT(10) UNSIGNED NOT NULL DEFAULT 0,
  `PAYMENTMETHOD` INT(10) UNSIGNED NOT NULL,
  `ADDRESS` INT(10) UNSIGNED NOT NULL
) ENGINE=INNODB DEFAULT CHARSET=UTF8MB4 COLLATE=UTF8MB4_GENERAL_CI;

--
-- Dumping data for table `order`
--

INSERT INTO `ORDER` (
  `ID`,
  `DATE`,
  `UID`,
  `STATUS`,
  `PAYMENTMETHOD`,
  `ADDRESS`
) VALUES (
  2,
  '2023-12-25 07:16:38',
  1,
  1,
  2,
  1
),
(
  3,
  '2023-12-25 07:24:32',
  1,
  1,
  1,
  1
),
(
  4,
  '2023-12-25 10:46:09',
  1,
  1,
  2,
  1
),
(
  5,
  '2023-12-25 10:46:40',
  1,
  1,
  2,
  1
),
(
  6,
  '2023-12-25 10:46:53',
  1,
  1,
  3,
  1
),
(
  7,
  '2023-12-25 10:47:18',
  1,
  1,
  1,
  1
),
(
  8,
  '2023-12-25 10:48:19',
  1,
  1,
  1,
  1
),
(
  9,
  '2023-12-25 10:49:55',
  1,
  1,
  3,
  1
),
(
  10,
  '2023-12-25 11:00:37',
  1,
  1,
  3,
  9
),
(
  11,
  '2023-12-26 05:27:50',
  1,
  1,
  2,
  1
),
(
  12,
  '2023-12-26 05:44:23',
  1,
  1,
  2,
  1
),
(
  13,
  '2023-12-26 05:49:21',
  1,
  1,
  2,
  1
),
(
  14,
  '2023-12-26 05:54:58',
  1,
  1,
  3,
  1
),
(
  15,
  '2023-12-26 06:53:11',
  1,
  1,
  2,
  1
),
(
  16,
  '2023-12-26 08:51:48',
  1,
  1,
  2,
  1
),
(
  17,
  '2023-12-26 09:36:19',
  1,
  1,
  3,
  8
);

-- --------------------------------------------------------

--
-- Table structure for table `order_detail`
--

CREATE TABLE `ORDER_DETAIL` (
  `ID` INT(11) UNSIGNED NOT NULL,
  `PRICE` INT(11) NOT NULL,
  `GAMEID` INT(11) UNSIGNED DEFAULT NULL,
  `GAMETYPE` INT(10) UNSIGNED DEFAULT NULL,
  `QUANTITY` INT(10) UNSIGNED DEFAULT NULL,
  `ORDERID` INT(10) UNSIGNED NOT NULL
) ENGINE=INNODB DEFAULT CHARSET=UTF8MB4 COLLATE=UTF8MB4_GENERAL_CI;

--
-- Dumping data for table `order_detail`
--

INSERT INTO `ORDER_DETAIL` (
  `ID`,
  `PRICE`,
  `GAMEID`,
  `GAMETYPE`,
  `QUANTITY`,
  `ORDERID`
) VALUES (
  1,
  0,
  1,
  1,
  2,
  3
),
(
  2,
  0,
  8,
  0,
  1,
  3
),
(
  3,
  0,
  1,
  1,
  2,
  4
),
(
  4,
  0,
  8,
  0,
  1,
  4
),
(
  5,
  0,
  1,
  1,
  1,
  5
),
(
  6,
  0,
  1,
  1,
  1,
  8
),
(
  7,
  0,
  1,
  1,
  1,
  9
),
(
  8,
  0,
  1,
  1,
  1,
  10
),
(
  9,
  0,
  1,
  1,
  1,
  11
),
(
  10,
  0,
  8,
  0,
  1,
  12
),
(
  11,
  0,
  8,
  0,
  1,
  13
),
(
  12,
  165000,
  5,
  0,
  1,
  14
),
(
  13,
  165000,
  4,
  1,
  2,
  15
),
(
  14,
  165000,
  4,
  0,
  1,
  15
),
(
  15,
  1000000,
  1,
  1,
  1,
  16
),
(
  16,
  1000000,
  1,
  1,
  3,
  17
);

-- --------------------------------------------------------

--
-- Table structure for table `order_status`
--

CREATE TABLE `ORDER_STATUS` (
  `ID` INT(10) UNSIGNED NOT NULL,
  `NAME` VARCHAR(50) NOT NULL
) ENGINE=INNODB DEFAULT CHARSET=UTF8MB4 COLLATE=UTF8MB4_GENERAL_CI;

--
-- Dumping data for table `order_status`
--

INSERT INTO `ORDER_STATUS` (
  `ID`,
  `NAME`
) VALUES (
  1,
  'Pending'
),
(
  2,
  'Confirmed'
),
(
  3,
  'Completed'
),
(
  4,
  'Canceled'
);

-- --------------------------------------------------------

--
-- Table structure for table `paymentmethods`
--

CREATE TABLE `PAYMENTMETHODS` (
  `ID` INT(10) UNSIGNED NOT NULL,
  `NAME` VARCHAR(50) NOT NULL
) ENGINE=INNODB DEFAULT CHARSET=UTF8MB4 COLLATE=UTF8MB4_GENERAL_CI;

--
-- Dumping data for table `paymentmethods`
--

INSERT INTO `PAYMENTMETHODS` (
  `ID`,
  `NAME`
) VALUES (
  1,
  'Banking'
),
(
  2,
  'Cash on delivery'
),
(
  3,
  'Pay at our store'
);

-- --------------------------------------------------------

--
-- Table structure for table `publisher`
--

CREATE TABLE `PUBLISHER` (
  `ID` INT(10) UNSIGNED NOT NULL,
  `NAME` VARCHAR(50) NOT NULL
) ENGINE=INNODB DEFAULT CHARSET=UTF8MB4 COLLATE=UTF8MB4_GENERAL_CI;

--
-- Dumping data for table `publisher`
--

INSERT INTO `PUBLISHER` (
  `ID`,
  `NAME`
) VALUES (
  1,
  'FromSoftware'
),
(
  2,
  'Bethesda'
),
(
  3,
  'CD PROJEKT RED'
),
(
  4,
  ' Rockstar Games'
),
(
  5,
  ' Klei Entertainment'
),
(
  6,
  ' ConcernedApe'
),
(
  7,
  ' Re-Logic'
),
(
  8,
  'Ubisoft'
),
(
  9,
  'Santa Monica Studio'
);

-- --------------------------------------------------------

--
-- Table structure for table `__efmigrationshistory`
--

CREATE TABLE `__EFMIGRATIONSHISTORY` (
  `MIGRATIONID` VARCHAR(150) NOT NULL,
  `PRODUCTVERSION` VARCHAR(32) NOT NULL
) ENGINE=INNODB DEFAULT CHARSET=UTF8MB4 COLLATE=UTF8MB4_GENERAL_CI;

--
-- Dumping data for table `__efmigrationshistory`
--

INSERT INTO `__EFMIGRATIONSHISTORY` (
  `MIGRATIONID`,
  `PRODUCTVERSION`
) VALUES (
  '20231127123800_Initial',
  '7.0.11'
);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `address`
--
ALTER TABLE `ADDRESS` ADD PRIMARY KEY (`ID`), ADD KEY `FK_ADD_USER` (`USERID`);

--
-- Indexes for table `aspnetroleclaims`
--
ALTER TABLE `ASPNETROLECLAIMS` ADD PRIMARY KEY (`ID`), ADD KEY `IX_ASPNETROLECLAIMS_ROLEID` (`ROLEID`);

--
-- Indexes for table `aspnetroles`
--
ALTER TABLE `ASPNETROLES` ADD PRIMARY KEY (`ID`), ADD UNIQUE KEY `ROLENAMEINDEX` (`NORMALIZEDNAME`);

--
-- Indexes for table `aspnetuserclaims`
--
ALTER TABLE `ASPNETUSERCLAIMS` ADD PRIMARY KEY (`ID`), ADD KEY `IX_ASPNETUSERCLAIMS_USERID` (`USERID`);

--
-- Indexes for table `aspnetuserlogins`
--
ALTER TABLE `ASPNETUSERLOGINS` ADD PRIMARY KEY (`LOGINPROVIDER`, `PROVIDERKEY`), ADD KEY `IX_ASPNETUSERLOGINS_USERID` (`USERID`);

--
-- Indexes for table `aspnetuserroles`
--
ALTER TABLE `ASPNETUSERROLES` ADD PRIMARY KEY (`USERID`, `ROLEID`), ADD KEY `IX_ASPNETUSERROLES_ROLEID` (`ROLEID`);

--
-- Indexes for table `aspnetusers`
--
ALTER TABLE `ASPNETUSERS` ADD PRIMARY KEY (`ID`), ADD UNIQUE KEY `USERNAME` (`USERNAME`), ADD UNIQUE KEY `EMAIL` (`EMAIL`), ADD UNIQUE KEY `USERNAMEINDEX` (`NORMALIZEDUSERNAME`), ADD KEY `EMAILINDEX` (`NORMALIZEDEMAIL`);

--
-- Indexes for table `aspnetusertokens`
--
ALTER TABLE `ASPNETUSERTOKENS` ADD PRIMARY KEY (`USERID`, `LOGINPROVIDER`, `NAME`);

--
-- Indexes for table `carts`
--
ALTER TABLE `CARTS` ADD PRIMARY KEY (`ID`, `UID`, `GAME_ID`), ADD KEY `FK_GAME-ID` (`GAME_ID`), ADD KEY `FK_ASPNETUSERS-UID` (`UID`);

--
-- Indexes for table `category`
--
ALTER TABLE `CATEGORY` ADD PRIMARY KEY (`ID`), ADD UNIQUE KEY `NAME` (`NAME`);

--
-- Indexes for table `developer`
--
ALTER TABLE `DEVELOPER` ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `game`
--
ALTER TABLE `GAME` ADD PRIMARY KEY (`ID`), ADD KEY `FK_GAME_DEVELOPER` (`DEVELOPER`), ADD KEY `FK_GAME_PUBLISHER` (`PUBLISHER`);

--
-- Indexes for table `game_category`
--
ALTER TABLE `GAME_CATEGORY` ADD PRIMARY KEY (`GAMEID`, `CATEGORYID`), ADD KEY `FK_GC_CATEGORY` (`CATEGORYID`), ADD KEY `FK_GC_GAME` (`GAMEID`);

--
-- Indexes for table `game_owned`
--
ALTER TABLE `GAME_OWNED` ADD PRIMARY KEY (`GAMEID`, `USERID`), ADD KEY `FK_GAMEOWNER_GAME` (`GAMEID`), ADD KEY `FK_GAMEOWNER_USER` (`USERID`);

--
-- Indexes for table `order`
--
ALTER TABLE `ORDER` ADD PRIMARY KEY (`ID`), ADD KEY `FK_USER_TRANS` (`UID`), ADD KEY `FK_STATUS_ORDERSTATUS` (`STATUS`), ADD KEY `FK_PAYMENTMETHOD_PAYMENTMETHOD` (`PAYMENTMETHOD`), ADD KEY `FK_ADDRESS_ADDRESS` (`ADDRESS`);

--
-- Indexes for table `order_detail`
--
ALTER TABLE `ORDER_DETAIL` ADD PRIMARY KEY (`ID`), ADD KEY `FK_GAME_TRANS` (`GAMEID`), ADD KEY `FK_ORDERID_ORDER` (`ORDERID`);

--
-- Indexes for table `order_status`
--
ALTER TABLE `ORDER_STATUS` ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `paymentmethods`
--
ALTER TABLE `PAYMENTMETHODS` ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `publisher`
--
ALTER TABLE `PUBLISHER` ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `__efmigrationshistory`
--
ALTER TABLE `__EFMIGRATIONSHISTORY` ADD PRIMARY KEY (`MIGRATIONID`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `address`
--
ALTER TABLE `ADDRESS` MODIFY `ID` INT(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `aspnetroleclaims`
--
ALTER TABLE `ASPNETROLECLAIMS` MODIFY `ID` INT(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `aspnetroles`
--
ALTER TABLE `ASPNETROLES` MODIFY `ID` INT(10) UNSIGNED NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `aspnetuserclaims`
--
ALTER TABLE `ASPNETUSERCLAIMS` MODIFY `ID` INT(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `aspnetusers`
--
ALTER TABLE `ASPNETUSERS` MODIFY `ID` INT(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `carts`
--
ALTER TABLE `CARTS` MODIFY `ID` INT(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=70;

--
-- AUTO_INCREMENT for table `category`
--
ALTER TABLE `CATEGORY` MODIFY `ID` INT(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=33;

--
-- AUTO_INCREMENT for table `developer`
--
ALTER TABLE `DEVELOPER` MODIFY `ID` INT(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT for table `game`
--
ALTER TABLE `GAME` MODIFY `ID` INT(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT for table `order`
--
ALTER TABLE `ORDER` MODIFY `ID` INT(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=18;

--
-- AUTO_INCREMENT for table `order_detail`
--
ALTER TABLE `ORDER_DETAIL` MODIFY `ID` INT(11) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=17;

--
-- AUTO_INCREMENT for table `order_status`
--
ALTER TABLE `ORDER_STATUS` MODIFY `ID` INT(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `paymentmethods`
--
ALTER TABLE `PAYMENTMETHODS` MODIFY `ID` INT(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `publisher`
--
ALTER TABLE `PUBLISHER` MODIFY `ID` INT(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `address`
--
ALTER TABLE `ADDRESS` ADD CONSTRAINT `FK_ADD_USER` FOREIGN KEY (`USERID`) REFERENCES `ASPNETUSERS` (`ID`);

--
-- Constraints for table `aspnetroleclaims`
--
ALTER TABLE `ASPNETROLECLAIMS` ADD CONSTRAINT `FK_ASPNETROLECLAIMS_ASPNETROLES_ROLEID` FOREIGN KEY (`ROLEID`) REFERENCES `ASPNETROLES` (`ID`) ON DELETE CASCADE;

--
-- Constraints for table `aspnetuserclaims`
--
ALTER TABLE `ASPNETUSERCLAIMS` ADD CONSTRAINT `FK_ASPNETUSERCLAIMS_ASPNETUSERS_USERID` FOREIGN KEY (`USERID`) REFERENCES `ASPNETUSERS` (`ID`) ON DELETE CASCADE;

--
-- Constraints for table `aspnetuserlogins`
--
ALTER TABLE `ASPNETUSERLOGINS` ADD CONSTRAINT `FK_ASPNETUSERLOGINS_ASPNETUSERS_USERID` FOREIGN KEY (`USERID`) REFERENCES `ASPNETUSERS` (`ID`) ON DELETE CASCADE;

--
-- Constraints for table `aspnetuserroles`
--
ALTER TABLE `ASPNETUSERROLES` ADD CONSTRAINT `FK_ASPNETUSERROLES_ASPNETROLES_ROLEID` FOREIGN KEY (`ROLEID`) REFERENCES `ASPNETROLES` (`ID`) ON DELETE CASCADE, ADD CONSTRAINT `FK_ASPNETUSERROLES_ASPNETUSERS_USERID` FOREIGN KEY (`USERID`) REFERENCES `ASPNETUSERS` (`ID`) ON DELETE CASCADE;

--
-- Constraints for table `aspnetusertokens`
--
ALTER TABLE `ASPNETUSERTOKENS` ADD CONSTRAINT `FK_ASPNETUSERTOKENS_ASPNETUSERS_USERID` FOREIGN KEY (`USERID`) REFERENCES `ASPNETUSERS` (`ID`) ON DELETE CASCADE;

--
-- Constraints for table `carts`
--
ALTER TABLE `CARTS` ADD CONSTRAINT `FK_GAME-ID` FOREIGN KEY (`GAME_ID`) REFERENCES `GAME` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE, ADD CONSTRAINT `FK_ASPNETUSERS-UID` FOREIGN KEY (`UID`) REFERENCES `ASPNETUSERS` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `game`
--
ALTER TABLE `GAME` ADD CONSTRAINT `FK_GAME_DEVELOPER` FOREIGN KEY (`DEVELOPER`) REFERENCES `DEVELOPER` (`ID`), ADD CONSTRAINT `FK_GAME_PUBLISHER` FOREIGN KEY (`PUBLISHER`) REFERENCES `PUBLISHER` (`ID`);

--
-- Constraints for table `game_category`
--
ALTER TABLE `GAME_CATEGORY` ADD CONSTRAINT `FK_GC_CATEGORY` FOREIGN KEY (`CATEGORYID`) REFERENCES `CATEGORY` (`ID`), ADD CONSTRAINT `FK_GC_GAME` FOREIGN KEY (`GAMEID`) REFERENCES `GAME` (`ID`);

--
-- Constraints for table `game_owned`
--
ALTER TABLE `GAME_OWNED` ADD CONSTRAINT `FK_GAMEOWNER_GAME` FOREIGN KEY (`GAMEID`) REFERENCES `GAME` (`ID`) ON DELETE CASCADE, ADD CONSTRAINT `FK_GAMEOWNER_USER` FOREIGN KEY (`USERID`) REFERENCES `ASPNETUSERS` (`ID`);

--
-- Constraints for table `order`
--
ALTER TABLE `ORDER` ADD CONSTRAINT `FK_ADDRESS_ADDRESS` FOREIGN KEY (`ADDRESS`) REFERENCES `ADDRESS` (`ID`), ADD CONSTRAINT `FK_PAYMENTMETHOD_PAYMENTMETHOD` FOREIGN KEY (`PAYMENTMETHOD`) REFERENCES `PAYMENTMETHODS` (`ID`), ADD CONSTRAINT `FK_STATUS_ORDERSTATUS` FOREIGN KEY (`STATUS`) REFERENCES `ORDER_STATUS` (`ID`), ADD CONSTRAINT `FK_USER_ORD` FOREIGN KEY (`UID`) REFERENCES `ASPNETUSERS` (`ID`);

--
-- Constraints for table `order_detail`
--
ALTER TABLE `ORDER_DETAIL` ADD CONSTRAINT `FK_ORDERID_ORDER` FOREIGN KEY (`ORDERID`) REFERENCES `ORDER` (`ID`);

COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;

/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;

/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;