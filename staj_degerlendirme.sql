-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Anamakine: 127.0.0.1
-- Üretim Zamanı: 21 May 2024, 11:38:15
-- Sunucu sürümü: 10.4.32-MariaDB
-- PHP Sürümü: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Veritabanı: `staj_degerlendirme`
--

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `akademisyen`
--

CREATE TABLE `akademisyen` (
  `id` int(11) NOT NULL,
  `ad` varchar(255) NOT NULL,
  `soyad` varchar(255) NOT NULL,
  `email` varchar(255) NOT NULL,
  `sifre` varchar(255) NOT NULL,
  `bolum` varchar(255) NOT NULL,
  `tip` varchar(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Tablo döküm verisi `akademisyen`
--

INSERT INTO `akademisyen` (`id`, `ad`, `soyad`, `email`, `sifre`, `bolum`, `tip`) VALUES
(1, 'Ali', 'Şahin', 'ali.sahin@example.com', '123', 'Bilgisayar Mühendisliği', 'akademisyen'),
(2, 'Feyza', 'Kara', 'feyza.kara@example.com', '321', 'Endüstri Mühendisliği', 'akademisyen'),
(3, 'Ercan', 'Turan', 'ercan.turan@example.com', 'asd', 'Elektrik-Elektronik Mühendisliği', 'akademisyen');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `ogrenci`
--

CREATE TABLE `ogrenci` (
  `id` int(11) NOT NULL,
  `sekreter_id` int(11) DEFAULT NULL,
  `tc_kimlik` int(14) NOT NULL,
  `ad` varchar(255) NOT NULL,
  `soyad` varchar(255) NOT NULL,
  `ogrenci_no` int(11) NOT NULL,
  `email` varchar(255) NOT NULL,
  `sinif` int(11) NOT NULL,
  `telefon` text NOT NULL,
  `bolum` varchar(255) NOT NULL,
  `staj_kodu` varchar(30) NOT NULL,
  `staj_yeri` varchar(255) NOT NULL,
  `staj_baslama_tarihi` date NOT NULL,
  `staj_bitis_tarihi` date NOT NULL,
  `evrak_teslim` tinyint(1) NOT NULL,
  `basvuru_dilekcesi` tinyint(1) NOT NULL,
  `kabul_yazisi` tinyint(1) NOT NULL,
  `mustehaklik` tinyint(1) NOT NULL,
  `kimlik_fotokopisi` tinyint(1) NOT NULL,
  `staj_formu` tinyint(1) NOT NULL,
  `staj_raporu` tinyint(1) NOT NULL,
  `aciklama` text NOT NULL,
  `basari` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Tablo döküm verisi `ogrenci`
--

INSERT INTO `ogrenci` (`id`, `sekreter_id`, `tc_kimlik`, `ad`, `soyad`, `ogrenci_no`, `email`, `sinif`, `telefon`, `bolum`, `staj_kodu`, `staj_yeri`, `staj_baslama_tarihi`, `staj_bitis_tarihi`, `evrak_teslim`, `basvuru_dilekcesi`, `kabul_yazisi`, `mustehaklik`, `kimlik_fotokopisi`, `staj_formu`, `staj_raporu`, `aciklama`, `basari`) VALUES
(1, 4, 1442428534, 'Yiğit', 'Yalım', 22197223, 'mehmet@gmail.com', 2, '545123123', 'Bilgisayar Programcılığı', 'B124', 'Hacettepe Teknokent', '2022-07-15', '2022-08-15', 1, 1, 0, 1, 1, 0, 0, 'Bu bir Açıklamadır', 1),
(2, 5, 1433561859, 'İlter Fehmi', 'Ataulusoy', 22191515, 'ilter@gmail.com', 3, '0', 'Bilgisayar Programcılığı', 'B125', 'Kastamonu', '2022-07-15', '2022-08-15', 1, 1, 1, 0, 0, 1, 1, 'İlter Açıklama', 1),
(3, 9, 1412412451, 'Melisa', 'Akkaş', 22194248, 'melisa@icloud.com', 306, '542124125', 'Yöetim Bilişim Sistemleri', 'B425', 'TOKİ', '2022-07-15', '2022-08-15', 1, 0, 0, 0, 1, 1, 1, 'Melisa Açıklama', 0),
(4, 13, 1412312414, 'Aleyna', 'Yen', 22198595, 'aleyna@yen.com', 551, '514124121', 'Moda Tasarım', 'B221', 'Les Benjamins', '2023-06-15', '2023-07-15', 1, 0, 0, 0, 1, 1, 1, 'Aleyna Yen Açıklama', 1);

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `ogrenci_not`
--

CREATE TABLE `ogrenci_not` (
  `ogrenci_id` int(11) NOT NULL,
  `akademisyen_id` int(11) NOT NULL,
  `isyeri_degerlendirmesi` int(11) NOT NULL,
  `sekil_bicim_yazimdili` int(11) NOT NULL,
  `soru1` int(11) NOT NULL,
  `soru2` int(11) NOT NULL,
  `soru3` int(11) NOT NULL,
  `soru4` int(11) NOT NULL,
  `soru5` int(11) NOT NULL,
  `soru6` int(11) NOT NULL,
  `soru7` int(11) NOT NULL,
  `soru8` int(11) NOT NULL,
  `soru9` int(11) NOT NULL,
  `soru10` int(11) NOT NULL,
  `soru11` int(11) NOT NULL,
  `soru12` int(11) NOT NULL,
  `soru13` int(11) NOT NULL,
  `soru14` int(11) NOT NULL,
  `soru15` int(11) NOT NULL,
  `soru16` int(11) NOT NULL,
  `soru17` int(11) NOT NULL,
  `soru18` int(11) NOT NULL,
  `soru19` int(11) NOT NULL,
  `basari_durumu` varchar(20) NOT NULL,
  `toplam_not` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Tablo döküm verisi `ogrenci_not`
--

INSERT INTO `ogrenci_not` (`ogrenci_id`, `akademisyen_id`, `isyeri_degerlendirmesi`, `sekil_bicim_yazimdili`, `soru1`, `soru2`, `soru3`, `soru4`, `soru5`, `soru6`, `soru7`, `soru8`, `soru9`, `soru10`, `soru11`, `soru12`, `soru13`, `soru14`, `soru15`, `soru16`, `soru17`, `soru18`, `soru19`, `basari_durumu`, `toplam_not`) VALUES
(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, '', 0),
(1, 1, 10, 10, 3, 3, 3, 2, 3, 5, 4, 4, 6, 2, 4, 6, 3, 4, 2, 6, 3, 9, 3, 'Başarılı', 100);

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `sekreter`
--

CREATE TABLE `sekreter` (
  `id` int(11) NOT NULL,
  `ad` varchar(255) NOT NULL,
  `soyad` varchar(255) NOT NULL,
  `email` varchar(255) NOT NULL,
  `sifre` varchar(255) NOT NULL,
  `tip` varchar(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Tablo döküm verisi `sekreter`
--

INSERT INTO `sekreter` (`id`, `ad`, `soyad`, `email`, `sifre`, `tip`) VALUES
(4, 'Ahmet', 'Yıldız', 'ahmet.yildiz@example.com', 'ahmet123', 'sekreter'),
(5, 'Ayşe', 'Demir', 'ayse.demir@example.com', 'ayse123', 'sekreter'),
(6, 'Ali', 'Kara', 'ali.kara@example.com', 'ali123', 'sekreter'),
(7, 'Büşra', 'Özkan', 'busra.ozkan@example.com', 'busra123', 'sekreter'),
(8, 'Caner', 'Kılıç', 'caner.kilic@example.com', 'caner123', 'sekreter'),
(9, 'Deniz', 'Arslan', 'deniz.arslan@example.com', 'deniz123', 'sekreter'),
(10, 'Ebru', 'Güneş', 'ebru.gunes@example.com', 'ebru123', 'sekreter'),
(11, 'Ferhat', 'Şahin', 'ferhat.sahin@example.com', 'ferhat123', 'sekreter'),
(12, 'Gizem', 'Çelik', 'gizem.celik@example.com', 'gizem123', 'sekreter'),
(13, 'Hakan', 'Tuncer', 'hakan.tuncer@example.com', 'hakan123', 'sekreter');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `staj_degerlendirme`
--

CREATE TABLE `staj_degerlendirme` (
  `ogrenci_id` int(11) NOT NULL,
  `akademisyen_id` int(11) NOT NULL,
  `staj_yeri` varchar(255) NOT NULL,
  `staj_tarihi` date NOT NULL,
  `notu` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Tablo döküm verisi `staj_degerlendirme`
--

INSERT INTO `staj_degerlendirme` (`ogrenci_id`, `akademisyen_id`, `staj_yeri`, `staj_tarihi`, `notu`) VALUES
(1, 2, 'Google', '2022-08-15', 85),
(2, 3, 'Microsoft', '2022-09-01', 90),
(3, 1, 'Apple', '2022-08-01', 95),
(4, 3, 'Amazon', '2022-09-15', 80),
(1, 1, 'Google', '2022-08-15', 75);

--
-- Dökümü yapılmış tablolar için indeksler
--

--
-- Tablo için indeksler `akademisyen`
--
ALTER TABLE `akademisyen`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `email` (`email`);

--
-- Tablo için indeksler `ogrenci`
--
ALTER TABLE `ogrenci`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `ogrenci_no` (`ogrenci_no`),
  ADD KEY `sekreter_id` (`sekreter_id`);

--
-- Tablo için indeksler `sekreter`
--
ALTER TABLE `sekreter`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `email` (`email`);

--
-- Tablo için indeksler `staj_degerlendirme`
--
ALTER TABLE `staj_degerlendirme`
  ADD KEY `ogrenci_id` (`ogrenci_id`),
  ADD KEY `akademisyen_id` (`akademisyen_id`);

--
-- Dökümü yapılmış tablolar için AUTO_INCREMENT değeri
--

--
-- Tablo için AUTO_INCREMENT değeri `akademisyen`
--
ALTER TABLE `akademisyen`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- Tablo için AUTO_INCREMENT değeri `sekreter`
--
ALTER TABLE `sekreter`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;

--
-- Dökümü yapılmış tablolar için kısıtlamalar
--

--
-- Tablo kısıtlamaları `ogrenci`
--
ALTER TABLE `ogrenci`
  ADD CONSTRAINT `ogrenci_ibfk_1` FOREIGN KEY (`sekreter_id`) REFERENCES `sekreter` (`id`);

--
-- Tablo kısıtlamaları `staj_degerlendirme`
--
ALTER TABLE `staj_degerlendirme`
  ADD CONSTRAINT `staj_degerlendirme_ibfk_1` FOREIGN KEY (`ogrenci_id`) REFERENCES `ogrenci` (`id`),
  ADD CONSTRAINT `staj_degerlendirme_ibfk_2` FOREIGN KEY (`akademisyen_id`) REFERENCES `akademisyen` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
