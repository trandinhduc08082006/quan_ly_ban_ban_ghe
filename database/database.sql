IF DB_ID(N'QuanLyBanBanGhe') IS NULL
BEGIN
    CREATE DATABASE QuanLyBanBanGhe;
END
GO

USE QuanLyBanBanGhe;
GO

CREATE TABLE dbo.loai (
    ma_loai       VARCHAR(20)    NOT NULL,
    ten_loai      NVARCHAR(100)  NOT NULL,
    CONSTRAINT PK_loai PRIMARY KEY (ma_loai)
);
GO

CREATE TABLE dbo.mau_sac (
    ma_mau        VARCHAR(20)    NOT NULL,
    ten_mau       NVARCHAR(100)  NOT NULL,
    CONSTRAINT PK_mau_sac PRIMARY KEY (ma_mau)
);
GO

CREATE TABLE dbo.cong_dung (
    ma_cong_dung  VARCHAR(20)    NOT NULL,
    ten_cong_dung NVARCHAR(150)  NOT NULL,
    CONSTRAINT PK_cong_dung PRIMARY KEY (ma_cong_dung)
);
GO

CREATE TABLE dbo.chat_lieu (
    ma_chat_lieu  VARCHAR(20)    NOT NULL,
    ten_chat_lieu NVARCHAR(100)  NOT NULL,
    CONSTRAINT PK_chat_lieu PRIMARY KEY (ma_chat_lieu)
);
GO

CREATE TABLE dbo.dac_diem (
    ma_dac_diem   VARCHAR(20)    NOT NULL,
    ten_dac_diem  NVARCHAR(150)  NOT NULL,
    CONSTRAINT PK_dac_diem PRIMARY KEY (ma_dac_diem)
);
GO

CREATE TABLE dbo.hinh_dang (
    ma_hinh_dang  VARCHAR(20)    NOT NULL,
    ten_hinh_dang NVARCHAR(100)  NOT NULL,
    CONSTRAINT PK_hinh_dang PRIMARY KEY (ma_hinh_dang)
);
GO

CREATE TABLE dbo.kich_thuoc (
    ma_kich_thuoc  VARCHAR(20)    NOT NULL,
    ten_kich_thuoc NVARCHAR(100)  NOT NULL,
    ma_loai        VARCHAR(20)    NOT NULL,
    CONSTRAINT PK_kich_thuoc PRIMARY KEY (ma_kich_thuoc),
    CONSTRAINT FK_kich_thuoc_loai FOREIGN KEY (ma_loai)
        REFERENCES dbo.loai(ma_loai)
);
GO

CREATE TABLE dbo.nuoc_san_xuat (
    ma_nuoc_san_xuat  VARCHAR(20)    NOT NULL,
    ten_nuoc_san_xuat NVARCHAR(100)  NOT NULL,
    CONSTRAINT PK_nuoc_san_xuat PRIMARY KEY (ma_nuoc_san_xuat)
);
GO

CREATE TABLE dbo.nha_san_xuat (
    ma_nha_san_xuat  VARCHAR(20)    NOT NULL,
    ten_nha_san_xuat NVARCHAR(150)  NOT NULL,
    CONSTRAINT PK_nha_san_xuat PRIMARY KEY (ma_nha_san_xuat)
);
GO

CREATE TABLE dbo.nha_cung_cap (
    ma_nha_cung_cap  VARCHAR(20)    NOT NULL,
    ten_nha_cung_cap NVARCHAR(150)  NOT NULL,
    dia_chi          NVARCHAR(255)  NULL,
    dien_thoai       VARCHAR(20)    NULL,
    trang_thai_xoa   BIT            NOT NULL CONSTRAINT DF_nha_cung_cap_trang_thai_xoa DEFAULT (0),
    CONSTRAINT PK_nha_cung_cap PRIMARY KEY (ma_nha_cung_cap)
);
GO

CREATE TABLE dbo.cong_viec (
    ma_cong_viec   VARCHAR(20)    NOT NULL,
    ten_cong_viec  NVARCHAR(100)  NOT NULL,
    muc_luong      DECIMAL(18,2)  NOT NULL CONSTRAINT DF_cong_viec_muc_luong DEFAULT (0),
    trang_thai_xoa BIT            NOT NULL CONSTRAINT DF_cong_viec_trang_thai_xoa DEFAULT (0),
    CONSTRAINT PK_cong_viec PRIMARY KEY (ma_cong_viec),
    CONSTRAINT CK_cong_viec_muc_luong CHECK (muc_luong >= 0)
);
GO

CREATE TABLE dbo.nhan_vien (
    ma_nhan_vien  VARCHAR(20)    NOT NULL,
    ten_nhan_vien NVARCHAR(150)  NOT NULL,
    gioi_tinh     NVARCHAR(20)   NULL,
    ngay_sinh     DATE           NULL,
    dien_thoai    VARCHAR(20)    NULL,
    dia_chi       NVARCHAR(255)  NULL,
    trang_thai_xoa BIT           NOT NULL CONSTRAINT DF_nhan_vien_trang_thai_xoa DEFAULT (0),
    ma_cong_viec  VARCHAR(20)    NULL,
    CONSTRAINT PK_nhan_vien PRIMARY KEY (ma_nhan_vien),
    CONSTRAINT FK_nhan_vien_cong_viec FOREIGN KEY (ma_cong_viec)
        REFERENCES dbo.cong_viec(ma_cong_viec)
);
GO

CREATE TABLE dbo.khach_hang (
    ma_khach       VARCHAR(20)    NOT NULL,
    ten_khach      NVARCHAR(150)  NOT NULL,
    dia_chi        NVARCHAR(255)  NULL,
    dien_thoai     VARCHAR(20)    NULL,
    trang_thai_xoa BIT            NOT NULL CONSTRAINT DF_khach_hang_trang_thai_xoa DEFAULT (0),
    CONSTRAINT PK_khach_hang PRIMARY KEY (ma_khach)
);
GO

CREATE TABLE dbo.tai_khoan (
    ten_dang_nhap       VARCHAR(100)   NOT NULL,
    mat_khau            NVARCHAR(255)  NOT NULL,
    quyen               NVARCHAR(50)   NOT NULL,
    trang_thai_hoat_dong BIT           NOT NULL CONSTRAINT DF_tai_khoan_trang_thai_hoat_dong DEFAULT (1),
    ma_nhan_vien        VARCHAR(20)    NOT NULL,
    CONSTRAINT PK_tai_khoan PRIMARY KEY (ten_dang_nhap),
    CONSTRAINT UQ_tai_khoan_ma_nhan_vien UNIQUE (ma_nhan_vien),
    CONSTRAINT FK_tai_khoan_nhan_vien FOREIGN KEY (ma_nhan_vien)
        REFERENCES dbo.nhan_vien(ma_nhan_vien),
    CONSTRAINT CK_tai_khoan_quyen CHECK (quyen IN (N'QuanLy', N'BanHang', N'ThuKho'))
);
GO

CREATE TABLE dbo.hang_hoa (
    ma_hang          VARCHAR(20)    NOT NULL,
    ten_hang_hoa     NVARCHAR(200)  NOT NULL,
    so_luong         INT            NOT NULL CONSTRAINT DF_hang_hoa_so_luong DEFAULT (0),
    don_gia_ban      DECIMAL(18,2)  NOT NULL CONSTRAINT DF_hang_hoa_don_gia_ban DEFAULT (0),
    don_gia_nhap     DECIMAL(18,2)  NOT NULL CONSTRAINT DF_hang_hoa_don_gia_nhap DEFAULT (0),
    thoi_gian_bao_hanh INT          NULL,
    anh              NVARCHAR(500)  NULL,
    ghi_chu          NVARCHAR(MAX)  NULL,
    trang_thai_xoa   BIT            NOT NULL CONSTRAINT DF_hang_hoa_trang_thai_xoa DEFAULT (0),
    ma_loai          VARCHAR(20)    NOT NULL,
    ma_mau           VARCHAR(20)    NOT NULL,
    ma_cong_dung     VARCHAR(20)    NOT NULL,
    ma_chat_lieu     VARCHAR(20)    NOT NULL,
    ma_dac_diem      VARCHAR(20)    NOT NULL,
    ma_hinh_dang     VARCHAR(20)    NOT NULL,
    ma_kich_thuoc    VARCHAR(20)    NOT NULL,
    ma_nha_san_xuat  VARCHAR(20)    NOT NULL,
    ma_nuoc_san_xuat VARCHAR(20)    NOT NULL,
    CONSTRAINT PK_hang_hoa PRIMARY KEY (ma_hang),
    CONSTRAINT CK_hang_hoa_so_luong CHECK (so_luong >= 0),
    CONSTRAINT CK_hang_hoa_don_gia_ban CHECK (don_gia_ban >= 0),
    CONSTRAINT CK_hang_hoa_don_gia_nhap CHECK (don_gia_nhap >= 0),
    CONSTRAINT CK_hang_hoa_bao_hanh CHECK (thoi_gian_bao_hanh IS NULL OR thoi_gian_bao_hanh >= 0),
    CONSTRAINT FK_hang_hoa_loai FOREIGN KEY (ma_loai) REFERENCES dbo.loai(ma_loai),
    CONSTRAINT FK_hang_hoa_mau_sac FOREIGN KEY (ma_mau) REFERENCES dbo.mau_sac(ma_mau),
    CONSTRAINT FK_hang_hoa_cong_dung FOREIGN KEY (ma_cong_dung) REFERENCES dbo.cong_dung(ma_cong_dung),
    CONSTRAINT FK_hang_hoa_chat_lieu FOREIGN KEY (ma_chat_lieu) REFERENCES dbo.chat_lieu(ma_chat_lieu),
    CONSTRAINT FK_hang_hoa_dac_diem FOREIGN KEY (ma_dac_diem) REFERENCES dbo.dac_diem(ma_dac_diem),
    CONSTRAINT FK_hang_hoa_hinh_dang FOREIGN KEY (ma_hinh_dang) REFERENCES dbo.hinh_dang(ma_hinh_dang),
    CONSTRAINT FK_hang_hoa_kich_thuoc FOREIGN KEY (ma_kich_thuoc) REFERENCES dbo.kich_thuoc(ma_kich_thuoc),
    CONSTRAINT FK_hang_hoa_nha_san_xuat FOREIGN KEY (ma_nha_san_xuat) REFERENCES dbo.nha_san_xuat(ma_nha_san_xuat),
    CONSTRAINT FK_hang_hoa_nuoc_san_xuat FOREIGN KEY (ma_nuoc_san_xuat) REFERENCES dbo.nuoc_san_xuat(ma_nuoc_san_xuat)
);
GO

CREATE TABLE dbo.hoa_don_nhap (
    so_hoa_don_nhap   VARCHAR(30)    NOT NULL,
    thoi_gian_nhap    DATETIME2(0)   NOT NULL CONSTRAINT DF_hoa_don_nhap_thoi_gian DEFAULT (SYSDATETIME()),
    tong_tien         DECIMAL(18,2)  NOT NULL CONSTRAINT DF_hoa_don_nhap_tong_tien DEFAULT (0),
    trang_thai_giao_dich NVARCHAR(30) NOT NULL CONSTRAINT DF_hoa_don_nhap_trang_thai DEFAULT (N'HoanThanh'),
    ma_nha_cung_cap   VARCHAR(20)    NOT NULL,
    ma_nhan_vien      VARCHAR(20)    NOT NULL,
    CONSTRAINT PK_hoa_don_nhap PRIMARY KEY (so_hoa_don_nhap),
    CONSTRAINT CK_hoa_don_nhap_tong_tien CHECK (tong_tien >= 0),
    CONSTRAINT CK_hoa_don_nhap_trang_thai CHECK (trang_thai_giao_dich IN (N'HoanThanh', N'DaHuy')),
    CONSTRAINT FK_hoa_don_nhap_nha_cung_cap FOREIGN KEY (ma_nha_cung_cap)
        REFERENCES dbo.nha_cung_cap(ma_nha_cung_cap),
    CONSTRAINT FK_hoa_don_nhap_nhan_vien FOREIGN KEY (ma_nhan_vien)
        REFERENCES dbo.nhan_vien(ma_nhan_vien)
);
GO

CREATE TABLE dbo.chi_tiet_hoa_don_nhap (
    so_hoa_don_nhap VARCHAR(30)    NOT NULL,
    ma_hang         VARCHAR(20)    NOT NULL,
    so_luong        INT            NOT NULL,
    don_gia         DECIMAL(18,2)  NOT NULL,
    giam_gia        DECIMAL(18,2)  NOT NULL CONSTRAINT DF_ct_hoa_don_nhap_giam_gia DEFAULT (0),
    thanh_tien      DECIMAL(18,2)  NOT NULL,
    CONSTRAINT PK_chi_tiet_hoa_don_nhap PRIMARY KEY (so_hoa_don_nhap, ma_hang),
    CONSTRAINT CK_ct_hoa_don_nhap_so_luong CHECK (so_luong > 0),
    CONSTRAINT CK_ct_hoa_don_nhap_don_gia CHECK (don_gia >= 0),
    CONSTRAINT CK_ct_hoa_don_nhap_giam_gia CHECK (giam_gia >= 0 AND giam_gia <= 100),
    CONSTRAINT CK_ct_hoa_don_nhap_thanh_tien CHECK (thanh_tien >= 0),
    CONSTRAINT FK_ct_hoa_don_nhap_hoa_don FOREIGN KEY (so_hoa_don_nhap)
        REFERENCES dbo.hoa_don_nhap(so_hoa_don_nhap),
    CONSTRAINT FK_ct_hoa_don_nhap_hang_hoa FOREIGN KEY (ma_hang)
        REFERENCES dbo.hang_hoa(ma_hang)
);
GO

CREATE TABLE dbo.hoa_don_ban (
    so_hoa_don_ban      VARCHAR(30)    NOT NULL,
    thoi_gian_ban       DATETIME2(0)   NOT NULL CONSTRAINT DF_hoa_don_ban_thoi_gian DEFAULT (SYSDATETIME()),
    tong_tien           DECIMAL(18,2)  NOT NULL CONSTRAINT DF_hoa_don_ban_tong_tien DEFAULT (0),
    trang_thai_giao_dich NVARCHAR(30) NOT NULL CONSTRAINT DF_hoa_don_ban_trang_thai DEFAULT (N'HoanThanh'),
    ma_nhan_vien        VARCHAR(20)    NOT NULL,
    ma_khach            VARCHAR(20)    NOT NULL,
    CONSTRAINT PK_hoa_don_ban PRIMARY KEY (so_hoa_don_ban),
    CONSTRAINT CK_hoa_don_ban_tong_tien CHECK (tong_tien >= 0),
    CONSTRAINT CK_hoa_don_ban_trang_thai CHECK (trang_thai_giao_dich IN (N'HoanThanh', N'DaHuy')),
    CONSTRAINT FK_hoa_don_ban_nhan_vien FOREIGN KEY (ma_nhan_vien)
        REFERENCES dbo.nhan_vien(ma_nhan_vien),
    CONSTRAINT FK_hoa_don_ban_khach_hang FOREIGN KEY (ma_khach)
        REFERENCES dbo.khach_hang(ma_khach)
);
GO

CREATE TABLE dbo.chi_tiet_hoa_don_ban (
    so_hoa_don_ban VARCHAR(30)    NOT NULL,
    ma_hang        VARCHAR(20)    NOT NULL,
    so_luong       INT            NOT NULL,
    don_gia        DECIMAL(18,2)  NOT NULL,
    giam_gia       DECIMAL(18,2)  NOT NULL CONSTRAINT DF_ct_hoa_don_ban_giam_gia DEFAULT (0),
    thanh_tien     DECIMAL(18,2)  NOT NULL,
    CONSTRAINT PK_chi_tiet_hoa_don_ban PRIMARY KEY (so_hoa_don_ban, ma_hang),
    CONSTRAINT CK_ct_hoa_don_ban_so_luong CHECK (so_luong > 0),
    CONSTRAINT CK_ct_hoa_don_ban_don_gia CHECK (don_gia >= 0),
    CONSTRAINT CK_ct_hoa_don_ban_giam_gia CHECK (giam_gia >= 0 AND giam_gia <= 100),
    CONSTRAINT CK_ct_hoa_don_ban_thanh_tien CHECK (thanh_tien >= 0),
    CONSTRAINT FK_ct_hoa_don_ban_hoa_don FOREIGN KEY (so_hoa_don_ban)
        REFERENCES dbo.hoa_don_ban(so_hoa_don_ban),
    CONSTRAINT FK_ct_hoa_don_ban_hang_hoa FOREIGN KEY (ma_hang)
        REFERENCES dbo.hang_hoa(ma_hang)
);
GO

CREATE INDEX IX_hoa_don_nhap_thoi_gian ON dbo.hoa_don_nhap(thoi_gian_nhap);
CREATE INDEX IX_hoa_don_nhap_nhan_vien ON dbo.hoa_don_nhap(ma_nhan_vien);
CREATE INDEX IX_hoa_don_nhap_nha_cung_cap ON dbo.hoa_don_nhap(ma_nha_cung_cap);
CREATE INDEX IX_hoa_don_ban_thoi_gian ON dbo.hoa_don_ban(thoi_gian_ban);
CREATE INDEX IX_hoa_don_ban_nhan_vien ON dbo.hoa_don_ban(ma_nhan_vien);
CREATE INDEX IX_hoa_don_ban_khach ON dbo.hoa_don_ban(ma_khach);
CREATE INDEX IX_hang_hoa_ten ON dbo.hang_hoa(ten_hang_hoa);
GO


CREATE TABLE dbo.phieu_bao_hanh (
    ma_phieu_bao_hanh  VARCHAR(20)    NOT NULL,
    so_hoa_don_ban     VARCHAR(30)    NOT NULL,
    ma_hang            VARCHAR(20)    NOT NULL,
    ma_khach           VARCHAR(20)    NOT NULL,
    ma_nhan_vien       VARCHAR(20)    NOT NULL,
    ngay_tiep_nhan     DATETIME2(0)   NOT NULL CONSTRAINT DF_pbh_ngay_tiep_nhan DEFAULT (SYSDATETIME()),
    ngay_hen_tra       DATE           NULL,
    ngay_tra_thuc_te   DATE           NULL,
    mo_ta_loi          NVARCHAR(500)  NOT NULL,
    bien_phap_xu_ly    NVARCHAR(255)  NULL,
    chi_phi            DECIMAL(18,2)  NOT NULL CONSTRAINT DF_pbh_chi_phi DEFAULT (0),
    trang_thai         NVARCHAR(30)   NOT NULL CONSTRAINT DF_pbh_trang_thai DEFAULT (N'TiepNhan'),
    ghi_chu            NVARCHAR(MAX)  NULL,
    trang_thai_xoa     BIT            NOT NULL CONSTRAINT DF_pbh_trang_thai_xoa DEFAULT (0),
    CONSTRAINT PK_phieu_bao_hanh PRIMARY KEY (ma_phieu_bao_hanh),
    CONSTRAINT CK_pbh_chi_phi CHECK (chi_phi >= 0),
    CONSTRAINT CK_pbh_trang_thai CHECK (trang_thai IN (N'TiepNhan', N'DangXuLy', N'DaXong', N'DaTra', N'TuChoi')),
    CONSTRAINT FK_pbh_hoa_don_ban FOREIGN KEY (so_hoa_don_ban) REFERENCES dbo.hoa_don_ban(so_hoa_don_ban),
    CONSTRAINT FK_pbh_hang_hoa FOREIGN KEY (ma_hang) REFERENCES dbo.hang_hoa(ma_hang),
    CONSTRAINT FK_pbh_khach_hang FOREIGN KEY (ma_khach) REFERENCES dbo.khach_hang(ma_khach),
    CONSTRAINT FK_pbh_nhan_vien FOREIGN KEY (ma_nhan_vien) REFERENCES dbo.nhan_vien(ma_nhan_vien)
);
GO

CREATE INDEX IX_pbh_so_hdb ON dbo.phieu_bao_hanh(so_hoa_don_ban);
CREATE INDEX IX_pbh_ma_khach ON dbo.phieu_bao_hanh(ma_khach);
CREATE INDEX IX_pbh_ma_hang ON dbo.phieu_bao_hanh(ma_hang);
CREATE INDEX IX_pbh_trang_thai ON dbo.phieu_bao_hanh(trang_thai);
GO

IF NOT EXISTS (SELECT 1 FROM dbo.cong_viec WHERE ma_cong_viec = 'CV0001')
BEGIN
    INSERT INTO dbo.cong_viec (ma_cong_viec, ten_cong_viec, muc_luong, trang_thai_xoa)
    VALUES ('CV0001', N'Quản lý cửa hàng', 18000000.00, 0);
END
GO

IF NOT EXISTS (SELECT 1 FROM dbo.nhan_vien WHERE ma_nhan_vien = 'NV0001')
BEGIN
    INSERT INTO dbo.nhan_vien (ma_nhan_vien, ten_nhan_vien, gioi_tinh, ngay_sinh, dien_thoai, dia_chi, trang_thai_xoa, ma_cong_viec)
    VALUES ('NV0001', N'Văn Admin', N'Nam', '1988-03-12', '0912345678', N'Số 12 Chùa Láng, Đống Đa, Hà Nội', 0, 'CV0001');
END

IF NOT EXISTS (SELECT 1 FROM dbo.nhan_vien WHERE ma_nhan_vien = 'NV0002')
BEGIN
    INSERT INTO dbo.nhan_vien (ma_nhan_vien, ten_nhan_vien, gioi_tinh, ngay_sinh, dien_thoai, dia_chi, trang_thai_xoa, ma_cong_viec)
    VALUES ('NV0002', N'Thị Admin', N'Nữ', '1990-07-25', '0987654321', N'Số 45 Cầu Giấy, Cầu Giấy, Hà Nội', 0, 'CV0001');
END
GO

IF NOT EXISTS (SELECT 1 FROM dbo.tai_khoan WHERE ten_dang_nhap = 'admin_phu')
BEGIN
    INSERT INTO dbo.tai_khoan (ten_dang_nhap, mat_khau, quyen, trang_thai_hoat_dong, ma_nhan_vien)
    VALUES ('admin_phu', 'ad89b64d66caa8e30e5d5ce4a9763f4ecc205814c412175f3e2c50027471426d', N'QuanLy', 1, 'NV0001');
END

IF NOT EXISTS (SELECT 1 FROM dbo.tai_khoan WHERE ten_dang_nhap = 'admin')
BEGIN
    INSERT INTO dbo.tai_khoan (ten_dang_nhap, mat_khau, quyen, trang_thai_hoat_dong, ma_nhan_vien)
    VALUES ('admin', 'ad89b64d66caa8e30e5d5ce4a9763f4ecc205814c412175f3e2c50027471426d', N'QuanLy', 1, 'NV0002');
END
GO

CREATE OR ALTER TRIGGER TR_tai_khoan_chan_xoa_admin
ON dbo.tai_khoan
FOR DELETE
AS
BEGIN
    SET NOCOUNT ON;
    IF EXISTS (SELECT 1 FROM deleted WHERE ten_dang_nhap IN ('admin', 'admin_phu'))
    BEGIN
        RAISERROR(N'Không thể xóa 2 tài khoản Quản trị viên hệ thống (admin, admin_phu)!', 16, 1);
        ROLLBACK TRANSACTION;
        RETURN;
    END
END
GO

CREATE OR ALTER TRIGGER TR_nhan_vien_chan_xoa_admin
ON dbo.nhan_vien
FOR DELETE
AS
BEGIN
    SET NOCOUNT ON;
    IF EXISTS (SELECT 1 FROM deleted WHERE ma_nhan_vien IN ('NV0001', 'NV0002'))
    BEGIN
        RAISERROR(N'Không thể xóa 2 nhân viên Quản trị viên hệ thống (NV0001, NV0002)!', 16, 1);
        ROLLBACK TRANSACTION;
        RETURN;
    END
END
GO
