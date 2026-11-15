USE QuanLyBanBanGhe;
GO

SET NOCOUNT ON;

DELETE FROM dbo.phieu_bao_hanh;
DELETE FROM dbo.chi_tiet_hoa_don_ban;
DELETE FROM dbo.hoa_don_ban;
DELETE FROM dbo.chi_tiet_hoa_don_nhap;
DELETE FROM dbo.hoa_don_nhap;

DELETE FROM dbo.hang_hoa;

DELETE FROM dbo.khach_hang;
DELETE FROM dbo.nha_cung_cap;

DELETE FROM dbo.tai_khoan WHERE ten_dang_nhap NOT IN ('admin_phu', 'admin');
DELETE FROM dbo.nhan_vien WHERE ma_nhan_vien NOT IN ('NV0001', 'NV0002');
DELETE FROM dbo.cong_viec WHERE ma_cong_viec NOT IN ('CV0001');

DELETE FROM dbo.kich_thuoc;
DELETE FROM dbo.loai;
DELETE FROM dbo.mau_sac;
DELETE FROM dbo.cong_dung;
DELETE FROM dbo.chat_lieu;
DELETE FROM dbo.dac_diem;
DELETE FROM dbo.hinh_dang;
DELETE FROM dbo.nuoc_san_xuat;
DELETE FROM dbo.nha_san_xuat;

IF NOT EXISTS (SELECT 1 FROM dbo.cong_viec WHERE ma_cong_viec = 'CV0001')
BEGIN
    INSERT INTO dbo.cong_viec (ma_cong_viec, ten_cong_viec, muc_luong, trang_thai_xoa)
    VALUES ('CV0001', N'Quản lý cửa hàng', 18000000.00, 0);
END
ELSE
BEGIN
    UPDATE dbo.cong_viec 
    SET trang_thai_xoa = 0 
    WHERE ma_cong_viec = 'CV0001';
END

IF NOT EXISTS (SELECT 1 FROM dbo.nhan_vien WHERE ma_nhan_vien = 'NV0001')
BEGIN
    INSERT INTO dbo.nhan_vien (ma_nhan_vien, ten_nhan_vien, gioi_tinh, ngay_sinh, dien_thoai, dia_chi, trang_thai_xoa, ma_cong_viec)
    VALUES ('NV0001', N'Văn Admin', N'Nam', '1988-03-12', '0912345678', N'Số 12 Chùa Láng, Đống Đa, Hà Nội', 0, 'CV0001');
END
ELSE
BEGIN
    UPDATE dbo.nhan_vien 
    SET trang_thai_xoa = 0 
    WHERE ma_nhan_vien = 'NV0001';
END

IF NOT EXISTS (SELECT 1 FROM dbo.nhan_vien WHERE ma_nhan_vien = 'NV0002')
BEGIN
    INSERT INTO dbo.nhan_vien (ma_nhan_vien, ten_nhan_vien, gioi_tinh, ngay_sinh, dien_thoai, dia_chi, trang_thai_xoa, ma_cong_viec)
    VALUES ('NV0002', N'Thị Admin', N'Nữ', '1990-07-25', '0987654321', N'Số 45 Cầu Giấy, Cầu Giấy, Hà Nội', 0, 'CV0001');
END
ELSE
BEGIN
    UPDATE dbo.nhan_vien 
    SET trang_thai_xoa = 0 
    WHERE ma_nhan_vien = 'NV0002';
END

IF NOT EXISTS (SELECT 1 FROM dbo.tai_khoan WHERE ten_dang_nhap = 'admin_phu')
BEGIN
    INSERT INTO dbo.tai_khoan (ten_dang_nhap, mat_khau, quyen, trang_thai_hoat_dong, ma_nhan_vien)
    VALUES ('admin_phu', 'ad89b64d66caa8e30e5d5ce4a9763f4ecc205814c412175f3e2c50027471426d', N'QuanLy', 1, 'NV0001');
END
ELSE
BEGIN
    UPDATE dbo.tai_khoan 
    SET mat_khau = 'ad89b64d66caa8e30e5d5ce4a9763f4ecc205814c412175f3e2c50027471426d', 
        quyen = N'QuanLy', 
        trang_thai_hoat_dong = 1, 
        ma_nhan_vien = 'NV0001' 
    WHERE ten_dang_nhap = 'admin_phu';
END

IF NOT EXISTS (SELECT 1 FROM dbo.tai_khoan WHERE ten_dang_nhap = 'admin')
BEGIN
    INSERT INTO dbo.tai_khoan (ten_dang_nhap, mat_khau, quyen, trang_thai_hoat_dong, ma_nhan_vien)
    VALUES ('admin', 'ad89b64d66caa8e30e5d5ce4a9763f4ecc205814c412175f3e2c50027471426d', N'QuanLy', 1, 'NV0002');
END
ELSE
BEGIN
    UPDATE dbo.tai_khoan 
    SET mat_khau = 'ad89b64d66caa8e30e5d5ce4a9763f4ecc205814c412175f3e2c50027471426d', 
        quyen = N'QuanLy', 
        trang_thai_hoat_dong = 1, 
        ma_nhan_vien = 'NV0002' 
    WHERE ten_dang_nhap = 'admin';
END
GO
