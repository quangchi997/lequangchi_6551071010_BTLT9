-- Script tạo CSDL và dữ liệu mẫu cho Câu 1: QL_ChiTieu
IF DB_ID('QL_ChiTieu') IS NOT NULL
BEGIN
    ALTER DATABASE QL_ChiTieu SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE QL_ChiTieu;
END
GO

CREATE DATABASE QL_ChiTieu;
GO

USE QL_ChiTieu;
GO

CREATE TABLE ChiTieu (
    MaCT INT IDENTITY(1,1) PRIMARY KEY,
    NgayChi DATE NOT NULL,
    NoiDung NVARCHAR(100) NOT NULL,
    LoaiChi NVARCHAR(30) NOT NULL,
    SoTien DECIMAL(18,0) NOT NULL,
    GhiChu NVARCHAR(200) NULL
);
GO

-- Nhập sẵn ít nhất 10 dòng dữ liệu mẫu
INSERT INTO ChiTieu (NgayChi, NoiDung, LoaiChi, SoTien, GhiChu) VALUES
('2026-10-01', N'Cơm trưa', N'Ăn uống', 35000, N'Cơm sườn bì chả'),
('2026-10-02', N'Đổ xăng xe máy', N'Đi lại', 60000, N'Xăng RON 95'),
('2026-10-03', N'Photo giáo trình .NET', N'Học tập', 25000, N'Tài liệu thực hành'),
('2026-10-04', N'Xem phim rạp CGV', N'Giải trí', 90000, N'Vé xem phim cuối tuần'),
('2026-10-05', N'Trà sữa bạn bè', N'Ăn uống', 40000, N'Gặp mặt nhóm'),
('2026-10-06', N'Mua áo thun mới', N'Khác', 150000, N'Mua sắm cá nhân'),
('2026-10-07', N'Tiền điện tháng 9', N'Khác', 500000, N'Hóa đơn sinh hoạt'),
('2026-10-08', N'Ăn sáng phở bò', N'Ăn uống', 25000, N'Quán gần nhà'),
('2026-10-10', N'Mua bút viết và vở', N'Học tập', 30000, N'Đồ dùng học tập'),
('2026-10-12', N'Bảo dưỡng xe máy', N'Đi lại', 120000, N'Thay nhớt định kỳ'),
('2026-10-15', N'Cà phê với bạn bè', N'Ăn uống', 45000, N'Quán The Coffee House');
GO
