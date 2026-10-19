-- Script tạo CSDL và dữ liệu mẫu cho Câu 4: QL_TraSua
IF DB_ID('QL_TraSua') IS NOT NULL
BEGIN
    ALTER DATABASE QL_TraSua SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE QL_TraSua;
END
GO

CREATE DATABASE QL_TraSua;
GO

USE QL_TraSua;
GO

CREATE TABLE DanhMucMon (
    MaDM INT IDENTITY(1,1) PRIMARY KEY,
    TenDM NVARCHAR(50) NOT NULL
);
GO

CREATE TABLE MonUong (
    MaMon INT IDENTITY(1,1) PRIMARY KEY,
    TenMon NVARCHAR(100) NOT NULL,
    GiaBan DECIMAL(18,0) NOT NULL,
    DangBan BIT NOT NULL DEFAULT 1,
    MaDM INT NOT NULL FOREIGN KEY REFERENCES DanhMucMon(MaDM)
);
GO

CREATE TABLE HoaDon (
    MaHD INT IDENTITY(1,1) PRIMARY KEY,
    NgayLap DATETIME NOT NULL,
    TongTien DECIMAL(18,0) NOT NULL,
    HinhThucTT NVARCHAR(20) NOT NULL, -- 'Tiền mặt' hoặc 'Chuyển khoản'
    DaThanhToan BIT NOT NULL DEFAULT 1
);
GO

CREATE TABLE ChiTietHoaDon (
    MaHD INT NOT NULL FOREIGN KEY REFERENCES HoaDon(MaHD) ON DELETE CASCADE,
    MaMon INT NOT NULL FOREIGN KEY REFERENCES MonUong(MaMon),
    SoLy INT NOT NULL,
    DonGia DECIMAL(18,0) NOT NULL,
    PRIMARY KEY (MaHD, MaMon)
);
GO

-- 4 danh mục
INSERT INTO DanhMucMon (TenDM) VALUES 
(N'Trà sữa'),
(N'Trà trái cây'),
(N'Topping'),
(N'Đồ ăn vặt');
GO

-- Ít nhất 12 món
INSERT INTO MonUong (TenMon, GiaBan, DangBan, MaDM) VALUES
-- Trà sữa (MaDM = 1)
(N'Trà sữa trân châu hoàng gia', 35000, 1, 1),
(N'Trà sữa matcha Nhật Bản', 40000, 1, 1),
(N'Hồng trà sữa truyền thống', 32000, 1, 1),
(N'Trà sữa khoai môn béo ngậy', 38000, 1, 1),
-- Trà trái cây (MaDM = 2)
(N'Trà đào cam sả thanh nhiệt', 35000, 1, 2),
(N'Trà ổi hồng chanh leo', 38000, 1, 2),
(N'Trà dâu tây hạt chia', 40000, 1, 2),
(N'Trà xoài nhiệt đới', 36000, 1, 2),
-- Topping (MaDM = 3)
(N'Trân châu đen đường đen', 5000, 1, 3),
(N'Trân châu trắng giòn 3Q', 7000, 1, 3),
(N'Pudding trứng béo', 8000, 1, 3),
(N'Thạch dừa non sợi dài', 6000, 1, 3),
-- Đồ ăn vặt (MaDM = 4)
(N'Khoai tây chiên lắc phô mai', 25000, 1, 4),
(N'Bánh tráng trộn Sa Tế', 20000, 1, 4),
(N'Cá viên chiên nước mắm', 30000, 1, 4);
GO

-- Hóa đơn mẫu
INSERT INTO HoaDon (NgayLap, TongTien, HinhThucTT, DaThanhToan) VALUES
('2026-10-19 08:30:00', 70000, N'Tiền mặt', 1),
('2026-10-19 09:15:00', 82000, N'Chuyển khoản', 1);

INSERT INTO ChiTietHoaDon (MaHD, MaMon, SoLy, DonGia) VALUES
(1, 1, 2, 35000),
(2, 2, 1, 40000),
(2, 5, 1, 35000),
(2, 10, 1, 7000);
GO
