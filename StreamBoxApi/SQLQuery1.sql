INSERT INTO Categories (CategoryName)
VALUES
('Aksiyon'),
('Komedi'),
('Dram'),
('Bilim Kurgu'),
('Korku');

INSERT INTO Movies (Title, Description, ImageUrl, ReleaseYear, CategoryId)
VALUES
('Shadow Mission', 'Gizli bir ajan görevi anlatılır.', 'https://picsum.photos/300/400?random=1', 2021, 1),
('Laugh Night', 'Eğlenceli bir komedi filmi.', 'https://picsum.photos/300/400?random=2', 2020, 2),
('Broken Dreams', 'Duygusal bir dram hikayesi.', 'https://picsum.photos/300/400?random=3', 2019, 3),
('Galaxy War', 'Uzayda geçen büyük savaş.', 'https://picsum.photos/300/400?random=4', 2022, 4),
('Dark House', 'Terk edilmiş evde geçen korku filmi.', 'https://picsum.photos/300/400?random=5', 2018, 5),
('Fast Revenge', 'Aksiyon dolu intikam hikayesi.', 'https://picsum.photos/300/400?random=6', 2023, 1),
('Funny Days', 'Arkadaş grubunun komik maceraları.', 'https://picsum.photos/300/400?random=7', 2017, 2),
('Lost Heart', 'Aşk ve kayıplar üzerine bir dram.', 'https://picsum.photos/300/400?random=8', 2016, 3),
('Robot City', 'Robotların yönettiği gelecek şehir.', 'https://picsum.photos/300/400?random=9', 2024, 4),
('Night Fear', 'Gece ortaya çıkan gizemli olaylar.', 'https://picsum.photos/300/400?random=10', 2015, 5);

INSERT INTO Actors (ActorName, Age, Country)
VALUES
('John Miller', 35, 'USA'),
('Emma Brown', 29, 'UK'),
('Carlos Vega', 42, 'Spain'),
('Ayşe Demir', 31, 'Türkiye'),
('Kenji Sato', 38, 'Japan'),
('Laura Smith', 27, 'USA'),
('Murat Kaya', 45, 'Türkiye'),
('Sofia Rossi', 33, 'Italy'),
('Daniel Green', 40, 'UK'),
('Nina Black', 26, 'Canada');

INSERT INTO MovieActors (MovieId, ActorId)
VALUES
(1, 1), (1, 2),
(2, 3), (2, 4),
(3, 5), (3, 6),
(4, 7), (4, 8),
(5, 9), (5, 10),
(6, 1), (6, 4),
(7, 2), (7, 6),
(8, 3), (8, 7),
(9, 5), (9, 8),
(10, 9), (10, 10);