-- Script tạo CSDL và dữ liệu mẫu cho Câu 3: QL_DaNgoai
IF DB_ID('QL_DaNgoai') IS NOT NULL
BEGIN
    ALTER DATABASE QL_DaNgoai SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE QL_DaNgoai;
END
GO

CREATE DATABASE QL_DaNgoai;
GO

USE QL_DaNgoai;
GO

CREATE TABLE ChuyenDi (
    MaChuyen INT IDENTITY(1,1) PRIMARY KEY,
    TenChuyen NVARCHAR(100) NOT NULL,
    DiaDiem NVARCHAR(100) NOT NULL,
    NgayDi DATE NOT NULL,
    SoNguoi INT NOT NULL,
    NganSach DECIMAL(18,0) NOT NULL,
    PhuongTien NVARCHAR(30) NOT NULL, -- Xe máy, Ô tô, Xe khách, Tàu hỏa
    DaHoanThanh BIT NOT NULL DEFAULT 0,
    GhiChu NVARCHAR(200) NULL
);
GO

-- Nhập sẵn 8 chuyến đi với ngày đi trải từ vài ngày đến vài tuần tới
INSERT INTO ChuyenDi (TenChuyen, DiaDiem, NgayDi, SoNguoi, NganSach, PhuongTien, DaHoanThanh, GhiChu) VALUES
(N'Cắm trại đồi chè Cầu Đất', N'Đà Lạt', '2026-10-25', 6, 3500000, N'Ô tô', 0, N'Mang theo lều và áo ấm'),
(N'Săn mây Fansipan mùa lúa chín', N'Sa Pa', '2026-10-28', 4, 5000000, N'Tàu hỏa', 0, N'Đặt vé cáp treo sớm'),
(N'Tắm biển cuối tuần', N'Vũng Tàu', '2026-10-31', 5, 2000000, N'Xe máy', 0, N'Ăn hải sản bãi sau'),
(N'Khám phá phố cổ về đêm', N'Hội An', '2026-11-04', 8, 8000000, N'Xe khách', 0, N'Thả đèn hoa đăng'),
(N'Lặn ngắm san hô biển ngọc', N'Nha Trang', '2026-11-08', 6, 6500000, N'Xe khách', 0, N'Tour đảo 1 ngày'),
(N'Chèo thuyền Tràng An', N'Ninh Bình', '2026-11-12', 4, 3000000, N'Ô tô', 0, N'Thăm hang Múa'),
(N'Nghỉ dưỡng Sunset Sanato', N'Phú Quốc', '2026-11-16', 2, 9000000, N'Xe khách', 0, N'Vé máy bay khứ hồi'),
(N'Chinh phục Mã Pí Lèng', N'Hà Giang', '2026-11-20', 4, 4500000, N'Xe máy', 0, N'Mùa hoa tam giác mạch');
GO
