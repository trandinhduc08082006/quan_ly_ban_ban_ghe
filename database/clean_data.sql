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
GO
