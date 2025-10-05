/**
 * @file: 01_database_schema.sql
 * @description: Script tạo cấu trúc cơ sở dữ liệu cho dự án Website Quản lý Sinh viên.
 * @author: Nhóm 1 - D22CTC1-QLDAPM
 * @created: 19/09/2025
 * @last_modified: 19/09/2025
 */

-- Bắt đầu tạo cơ sở dữ liệu
-- Sử dụng một tên database giả lập để tránh trùng lặp
-- CREATE DATABASE WebQLSV_DB;
-- GO

-- USE WebQLSV_DB;
-- GO

-- Xóa các bảng nếu đã tồn tại để tránh lỗi khi chạy lại script
DROP TABLE IF EXISTS Diem;
DROP TABLE IF EXISTS LopHocPhan;
DROP TABLE IF EXISTS SinhVien;
DROP TABLE IF EXISTS MonHoc;
GO

-----------------------------------------------------------
--              ĐỊNH NGHĨA CÁC BẢNG DỮ LIỆU
-----------------------------------------------------------

-- 1. Bảng SinhVien (Thông tin sinh viên)
CREATE TABLE SinhVien (
    MaSV VARCHAR(20) PRIMARY KEY,
    HoTen NVARCHAR(50) NOT NULL,
    NgaySinh DATE,
    GioiTinh NVARCHAR(10),
    DiaChi NVARCHAR(100),
    Email VARCHAR(50) UNIQUE,
    SoDienThoai VARCHAR(15),
    NgayVaoTruong DATE DEFAULT GETDATE(),
    CONSTRAINT CHK_Email CHECK (Email LIKE '%@%')
);

-- 2. Bảng MonHoc (Thông tin môn học)
CREATE TABLE MonHoc (
    MaMonHoc VARCHAR(10) PRIMARY KEY,
    TenMonHoc NVARCHAR(50) NOT NULL,
    SoTinChi INT CHECK (SoTinChi > 0)
);

-- 3. Bảng LopHocPhan (Thông tin lớp học phần)
CREATE TABLE LopHocPhan (
    MaLHP VARCHAR(20) PRIMARY KEY,
    MaGiangVien VARCHAR(20) NOT NULL,
    MaMonHoc VARCHAR(10) NOT NULL,
    HocKy INT NOT NULL,
    NamHoc VARCHAR(20) NOT NULL,
    PhongHoc NVARCHAR(10),
    FOREIGN KEY (MaMonHoc) REFERENCES MonHoc(MaMonHoc)
        ON DELETE CASCADE -- Tự động xóa LHP nếu Môn học bị xóa
);

-- 4. Bảng Diem (Điểm số của sinh viên)
CREATE TABLE Diem (
    MaDiem INT IDENTITY(1,1) PRIMARY KEY,
    MaSV VARCHAR(20) NOT NULL,
    MaLHP VARCHAR(20) NOT NULL,
    DiemChuyenCan FLOAT,
    DiemGiuaKy FLOAT,
    DiemCuoiKy FLOAT,
    DiemTongKet FLOAT,
    GhiChu NVARCHAR(255),
    FOREIGN KEY (MaSV) REFERENCES SinhVien(MaSV)
        ON DELETE CASCADE,
    FOREIGN KEY (MaLHP) REFERENCES LopHocPhan(MaLHP)
        ON DELETE CASCADE
);

-----------------------------------------------------------
--              TẠO DỮ LIỆU MẪU ĐỂ KIỂM THỬ
-----------------------------------------------------------

-- Dữ liệu mẫu cho bảng MonHoc
INSERT INTO MonHoc (MaMonHoc, TenMonHoc, SoTinChi) VALUES
('PM01', N'Quản lý dự án phần mềm', 3),
('DB01', N'Cơ sở dữ liệu', 4),
('WEB01', N'Lập trình Web', 3);

-- Dữ liệu mẫu cho bảng SinhVien
INSERT INTO SinhVien (MaSV, HoTen, NgaySinh, GioiTinh, DiaChi, Email) VALUES
('SV001', N'Đỗ Phúc Tường', '2004-03-15', N'Nam', N'Phú Yên', 'tuong.dp@example.com'),
('SV002', N'Nguyễn Thị Minh Thư', '2004-05-20', N'Nữ', N'Hà Nội', 'thu.ntm@example.com');

-- Dữ liệu mẫu cho bảng LopHocPhan
INSERT INTO LopHocPhan (MaLHP, MaGiangVien, MaMonHoc, HocKy, NamHoc, PhongHoc) VALUES
('LHP_PM01_2025_01', 'GV001', 'PM01', 1, '2025-2026', 'A101');

-- Dữ liệu mẫu cho bảng Diem
INSERT INTO Diem (MaSV, MaLHP, DiemChuyenCan, DiemGiuaKy, DiemCuoiKy, DiemTongKet) VALUES
('SV001', 'LHP_PM01_2025_01', 9.0, 8.5, 9.5, 9.0);
