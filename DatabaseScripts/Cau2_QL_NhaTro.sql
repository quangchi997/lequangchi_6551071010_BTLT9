-- Script tạo CSDL và dữ liệu mẫu cho Câu 2: QL_NhaTro
IF DB_ID('QL_NhaTro') IS NOT NULL
BEGIN
    ALTER DATABASE QL_NhaTro SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE QL_NhaTro;
END
GO

CREATE DATABASE QL_NhaTro;
GO

USE QL_NhaTro;
GO

CREATE TABLE PhongTro (
    MaPhong INT IDENTITY(1,1) PRIMARY KEY,
    TenPhong NVARCHAR(20) NOT NULL,
    GiaThue DECIMAL(18,0) NOT NULL,
    TinhTrang NVARCHAR(20) NOT NULL -- 'Trống' hoặc 'Đang thuê'
);
GO

CREATE TABLE KhachThue (
    MaKhach INT IDENTITY(1,1) PRIMARY KEY,
    HoTen NVARCHAR(100) NOT NULL,
    GioiTinh NVARCHAR(5) NOT NULL, -- 'Nam' hoặc 'Nữ'
    NgaySinh DATE NOT NULL,
    SoDienThoai VARCHAR(15) NOT NULL,
    MaTinh INT NOT NULL,
    TenTinh NVARCHAR(100) NOT NULL,
    MaPhuongXa INT NOT NULL,
    TenPhuongXa NVARCHAR(100) NOT NULL,
    DaDangKyTamTru BIT NOT NULL DEFAULT 0,
    MaPhong INT NOT NULL FOREIGN KEY REFERENCES PhongTro(MaPhong)
);
GO

-- Nhập sẵn 6 phòng trọ
INSERT INTO PhongTro (TenPhong, GiaThue, TinhTrang) VALUES
(N'P01', 1500000, N'Đang thuê'),
(N'P02', 1600000, N'Đang thuê'),
(N'P03', 1800000, N'Đang thuê'),
(N'P04', 2000000, N'Đang thuê'),
(N'P05', 1700000, N'Đang thuê'),
(N'P06', 1900000, N'Trống');
GO

-- Nhập sẵn khách thuê
INSERT INTO KhachThue (HoTen, GioiTinh, NgaySinh, SoDienThoai, MaTinh, TenTinh, MaPhuongXa, TenPhuongXa, DaDangKyTamTru, MaPhong) VALUES
(N'Trần Thị Bình', N'Nữ', '2003-05-14', '0876543210', 36, N'Tỉnh Nam Định', 13744, N'Phường Trần Hưng Đạo', 0, 1),
(N'Lê Văn Cường', N'Nam', '2002-11-20', '0901234567', 38, N'Tỉnh Thanh Hóa', 14590, N'Phường Ba Đình', 0, 2),
(N'Nguyễn Văn An', N'Nam', '2004-05-12', '0912345678', 1, N'Thành phố Hà Nội', 28, N'Phường Giảng Võ', 1, 3),
(N'Phạm Minh Đức', N'Nam', '2001-08-09', '0987654321', 38, N'Tỉnh Thanh Hóa', 14593, N'Phường Lam Sơn', 1, 4),
(N'Hoàng Thị Dung', N'Nữ', '2003-02-17', '0765432109', 27, N'Tỉnh Bắc Ninh', 9871, N'Phường Tiền An', 0, 5);
GO
