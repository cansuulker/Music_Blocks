-- phpMyAdmin SQL Dump
-- version 4.7.7
-- https://www.phpmyadmin.net/
--
-- Anamakine: localhost
-- Üretim Zamanı: 13 May 2019, 01:08:49
-- Sunucu sürümü: 10.1.30-MariaDB
-- PHP Sürümü: 7.2.1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Veritabanı: `tmp`
--

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `patients`
--

CREATE TABLE `patients` (
  `id` int(255) NOT NULL,
  `name` varchar(50) CHARACTER SET latin1 NOT NULL,
  `surname` varchar(50) CHARACTER SET latin1 NOT NULL,
  `username` varchar(50) CHARACTER SET latin1 NOT NULL,
  `password` varchar(100) CHARACTER SET latin1 NOT NULL,
  `salt` varchar(50) CHARACTER SET latin1 NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf16 COLLATE=utf16_turkish_ci;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `patient_therapy`
--

CREATE TABLE `patient_therapy` (
  `patient_id` int(255) NOT NULL,
  `therapy_id` int(255) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Tablo döküm verisi `patient_therapy`
--

INSERT INTO `patient_therapy` (`patient_id`, `therapy_id`) VALUES
(1, 1),
(2, 5),
(3, 2);

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `priviliges_table`
--

CREATE TABLE `priviliges_table` (
  `id` int(11) NOT NULL,
  `user_id` int(11) NOT NULL,
  `admin` tinyint(1) NOT NULL,
  `patient` tinyint(1) NOT NULL,
  `therapist` tinyint(1) NOT NULL,
  `normal` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `therapies`
--

CREATE TABLE `therapies` (
  `id` int(255) NOT NULL,
  `therapy_name` varchar(255) NOT NULL,
  `numberOfGames` varchar(255) NOT NULL,
  `numberOfOperations` varchar(255) NOT NULL,
  `accuracy` varchar(255) NOT NULL,
  `rotation` tinyint(1) NOT NULL,
  `arithmetics` tinyint(1) NOT NULL,
  `effects` tinyint(1) NOT NULL,
  `numberOfDigits` varchar(10) NOT NULL,
  `typeOfOperation` varchar(255) NOT NULL,
  `numberOfOperands` varchar(255) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `therapists`
--

CREATE TABLE `therapists` (
  `id` int(255) NOT NULL,
  `name` varchar(50) NOT NULL,
  `surname` varchar(50) NOT NULL,
  `username` varchar(50) NOT NULL,
  `password` varchar(100) NOT NULL,
  `salt` varchar(50) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Tablo döküm verisi `therapists`
--

INSERT INTO `therapists` (`id`, `name`, `surname`, `username`, `password`, `salt`) VALUES
(1, 'Cansu', 'Ulker', 'culker', '123', ''),
(2, 'Berk', 'Tunc', 'btunc', '123', ''),
(3, 'Bob', 'Mose', 'bmose', '$5$rounds=5000$steamedhamsbmose$U6g5qnioQ9cwIiHVF3qsPjk3Ua.794Yh1tn3QRsMNO7', '$5$rounds=5000$steamedhamsbmose$'),
(4, 'Cindy', 'Rose', 'crose', '$5$rounds=5000$steamedhamscrose$1QvMwubeCpocO3aStNuDd8o0DeZG0GzEjf2nAtyYs0/', '$5$rounds=5000$steamedhamscrose$');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `therapist_patient`
--

CREATE TABLE `therapist_patient` (
  `therapist_id` int(255) NOT NULL,
  `patient_id` int(255) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Tablo döküm verisi `therapist_patient`
--

INSERT INTO `therapist_patient` (`therapist_id`, `patient_id`) VALUES
(1, 1),
(2, 2),
(1, 2);

--
-- Dökümü yapılmış tablolar için indeksler
--

--
-- Tablo için indeksler `patients`
--
ALTER TABLE `patients`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `username` (`username`);

--
-- Tablo için indeksler `therapies`
--
ALTER TABLE `therapies`
  ADD PRIMARY KEY (`id`);

--
-- Tablo için indeksler `therapists`
--
ALTER TABLE `therapists`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `username` (`username`);

--
-- Dökümü yapılmış tablolar için AUTO_INCREMENT değeri
--

--
-- Tablo için AUTO_INCREMENT değeri `patients`
--
ALTER TABLE `patients`
  MODIFY `id` int(255) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- Tablo için AUTO_INCREMENT değeri `therapies`
--
ALTER TABLE `therapies`
  MODIFY `id` int(255) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- Tablo için AUTO_INCREMENT değeri `therapists`
--
ALTER TABLE `therapists`
  MODIFY `id` int(255) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
