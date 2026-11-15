USE master;
GO

IF DB_ID(N'QuanLyBanBanGhe') IS NOT NULL
BEGIN
    ALTER DATABASE QuanLyBanBanGhe SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE QuanLyBanBanGhe;
END
GO

CREATE DATABASE QuanLyBanBanGhe;
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



CREATE OR ALTER PROCEDURE dbo.sp_HangHoa_LayDanhSach
    @chi_lay_hoat_dong BIT = 1
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        h.ma_hang, 
        h.ten_hang_hoa, 
        h.so_luong, 
        h.don_gia_nhap, 
        h.don_gia_ban, 
        h.thoi_gian_bao_hanh, 
        h.anh, 
        h.ghi_chu, 
        h.trang_thai_xoa,
        h.ma_loai, 
        l.ten_loai,
        h.ma_chat_lieu, 
        cl.ten_chat_lieu,
        h.ma_kich_thuoc, 
        kt.ten_kich_thuoc,
        h.ma_mau, 
        ms.ten_mau,
        h.ma_nuoc_san_xuat, 
        nsx.ten_nuoc_san_xuat,
        h.ma_hinh_dang, 
        hd.ten_hinh_dang,
        h.ma_nha_san_xuat, 
        nha_sx.ten_nha_san_xuat,
        h.ma_cong_dung, 
        cd.ten_cong_dung,
        h.ma_dac_diem, 
        dd.ten_dac_diem
    FROM dbo.hang_hoa h
    LEFT JOIN dbo.loai l ON h.ma_loai = l.ma_loai
    LEFT JOIN dbo.chat_lieu cl ON h.ma_chat_lieu = cl.ma_chat_lieu
    LEFT JOIN dbo.kich_thuoc kt ON h.ma_kich_thuoc = kt.ma_kich_thuoc
    LEFT JOIN dbo.mau_sac ms ON h.ma_mau = ms.ma_mau
    LEFT JOIN dbo.nuoc_san_xuat nsx ON h.ma_nuoc_san_xuat = nsx.ma_nuoc_san_xuat
    LEFT JOIN dbo.hinh_dang hd ON h.ma_hinh_dang = hd.ma_hinh_dang
    LEFT JOIN dbo.nha_san_xuat nha_sx ON h.ma_nha_san_xuat = nha_sx.ma_nha_san_xuat
    LEFT JOIN dbo.cong_dung cd ON h.ma_cong_dung = cd.ma_cong_dung
    LEFT JOIN dbo.dac_diem dd ON h.ma_dac_diem = dd.ma_dac_diem
    WHERE (@chi_lay_hoat_dong IS NULL OR h.trang_thai_xoa = CASE WHEN @chi_lay_hoat_dong = 1 THEN 0 ELSE 1 END)
    ORDER BY h.ma_hang;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_HangHoa_Them
    @ma_hang VARCHAR(20),
    @ten_hang_hoa NVARCHAR(200),
    @so_luong INT = 0,
    @don_gia_nhap DECIMAL(18,2) = 0,
    @don_gia_ban DECIMAL(18,2) = 0,
    @thoi_gian_bao_hanh INT = NULL,
    @anh NVARCHAR(500) = NULL,
    @ghi_chu NVARCHAR(MAX) = NULL,
    @ma_loai VARCHAR(20),
    @ma_mau VARCHAR(20),
    @ma_cong_dung VARCHAR(20),
    @ma_chat_lieu VARCHAR(20),
    @ma_dac_diem VARCHAR(20),
    @ma_hinh_dang VARCHAR(20),
    @ma_kich_thuoc VARCHAR(20),
    @ma_nha_san_xuat VARCHAR(20),
    @ma_nuoc_san_xuat VARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;

    IF @don_gia_ban <= 0 AND @don_gia_nhap > 0
    BEGIN
        SET @don_gia_ban = CEILING((@don_gia_nhap * 1.10) / 1000.0) * 1000;
    END

    INSERT INTO dbo.hang_hoa 
    (
        ma_hang, 
        ten_hang_hoa, 
        so_luong, 
        don_gia_ban, 
        don_gia_nhap, 
        thoi_gian_bao_hanh, 
        anh, 
        ghi_chu, 
        trang_thai_xoa, 
        ma_loai, 
        ma_mau, 
        ma_cong_dung, 
        ma_chat_lieu, 
        ma_dac_diem, 
        ma_hinh_dang, 
        ma_kich_thuoc, 
        ma_nha_san_xuat, 
        ma_nuoc_san_xuat
    ) 
    VALUES 
    (
        @ma_hang, 
        @ten_hang_hoa, 
        ISNULL(@so_luong, 0), 
        ISNULL(@don_gia_ban, 0), 
        ISNULL(@don_gia_nhap, 0), 
        @thoi_gian_bao_hanh, 
        @anh, 
        @ghi_chu, 
        0, 
        @ma_loai, 
        @ma_mau, 
        @ma_cong_dung, 
        @ma_chat_lieu, 
        @ma_dac_diem, 
        @ma_hinh_dang, 
        @ma_kich_thuoc, 
        @ma_nha_san_xuat, 
        @ma_nuoc_san_xuat
    );
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_HangHoa_CapNhat
    @ma_hang VARCHAR(20),
    @ten_hang_hoa NVARCHAR(200),
    @don_gia_nhap DECIMAL(18,2),
    @don_gia_ban DECIMAL(18,2) = 0,
    @thoi_gian_bao_hanh INT = NULL,
    @anh NVARCHAR(500) = NULL,
    @ghi_chu NVARCHAR(MAX) = NULL,
    @ma_loai VARCHAR(20),
    @ma_mau VARCHAR(20),
    @ma_cong_dung VARCHAR(20),
    @ma_chat_lieu VARCHAR(20),
    @ma_dac_diem VARCHAR(20),
    @ma_hinh_dang VARCHAR(20),
    @ma_kich_thuoc VARCHAR(20),
    @ma_nha_san_xuat VARCHAR(20),
    @ma_nuoc_san_xuat VARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;

    IF (@don_gia_ban IS NULL OR @don_gia_ban <= 0) AND @don_gia_nhap > 0
    BEGIN
        SET @don_gia_ban = CEILING((@don_gia_nhap * 1.10) / 1000.0) * 1000;
    END

    UPDATE dbo.hang_hoa 
    SET 
        ten_hang_hoa = @ten_hang_hoa, 
        don_gia_nhap = @don_gia_nhap, 
        don_gia_ban = @don_gia_ban, 
        thoi_gian_bao_hanh = @thoi_gian_bao_hanh, 
        anh = @anh, 
        ghi_chu = @ghi_chu, 
        ma_loai = @ma_loai, 
        ma_mau = @ma_mau, 
        ma_cong_dung = @ma_cong_dung, 
        ma_chat_lieu = @ma_chat_lieu, 
        ma_dac_diem = @ma_dac_diem, 
        ma_hinh_dang = @ma_hinh_dang, 
        ma_kich_thuoc = @ma_kich_thuoc, 
        ma_nha_san_xuat = @ma_nha_san_xuat, 
        ma_nuoc_san_xuat = @ma_nuoc_san_xuat 
    WHERE ma_hang = @ma_hang;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_HangHoa_XoaMem
    @ma_hang VARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE dbo.hang_hoa 
    SET trang_thai_xoa = 1 
    WHERE ma_hang = @ma_hang;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_HangHoa_KiemTraTonKho
    @ma_hang VARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        ma_hang,
        ten_hang_hoa,
        so_luong,
        trang_thai_xoa
    FROM dbo.hang_hoa
    WHERE ma_hang = @ma_hang;
END;
GO


CREATE OR ALTER PROCEDURE dbo.sp_HoaDonBan_HuyHoanKho
    @so_hoa_don_ban VARCHAR(30),
    @ly_do_huy NVARCHAR(255) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @hasInternalTrans BIT = 0;
    IF @@TRANCOUNT = 0
    BEGIN
        BEGIN TRANSACTION;
        SET @hasInternalTrans = 1;
    END

    BEGIN TRY
        IF NOT EXISTS (
            SELECT 1 
            FROM dbo.hoa_don_ban 
            WHERE so_hoa_don_ban = @so_hoa_don_ban 
              AND trang_thai_giao_dich = N'HoanThanh'
        )
        BEGIN
            RAISERROR(N'Hóa đơn bán không tồn tại hoặc đã được xử lý hủy trước đó!', 16, 1);
        END

        UPDATE dbo.hoa_don_ban
        SET trang_thai_giao_dich = N'DaHuy'
        WHERE so_hoa_don_ban = @so_hoa_don_ban;

        UPDATE h
        SET h.so_luong = h.so_luong + ct.so_luong,
            h.trang_thai_xoa = 0
        FROM dbo.hang_hoa h
        INNER JOIN dbo.chi_tiet_hoa_don_ban ct ON h.ma_hang = ct.ma_hang
        WHERE ct.so_hoa_don_ban = @so_hoa_don_ban;

        IF @hasInternalTrans = 1
        BEGIN
            COMMIT TRANSACTION;
        END
    END TRY
    BEGIN CATCH
        IF @hasInternalTrans = 1 AND @@TRANCOUNT > 0
        BEGIN
            ROLLBACK TRANSACTION;
        END;
        THROW;
    END CATCH
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_HoaDonNhap_HuyKiemTraTon
    @so_hoa_don_nhap VARCHAR(30),
    @ly_do_huy NVARCHAR(255) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @hasInternalTrans BIT = 0;
    IF @@TRANCOUNT = 0
    BEGIN
        BEGIN TRANSACTION;
        SET @hasInternalTrans = 1;
    END

    BEGIN TRY
        IF NOT EXISTS (
            SELECT 1 
            FROM dbo.hoa_don_nhap 
            WHERE so_hoa_don_nhap = @so_hoa_don_nhap 
              AND trang_thai_giao_dich = N'HoanThanh'
        )
        BEGIN
            RAISERROR(N'Hóa đơn nhập không tồn tại hoặc đã được xử lý hủy trước đó!', 16, 1);
        END

        IF EXISTS (
            SELECT 1
            FROM dbo.chi_tiet_hoa_don_nhap ct
            INNER JOIN dbo.hang_hoa h ON ct.ma_hang = h.ma_hang
            WHERE ct.so_hoa_don_nhap = @so_hoa_don_nhap
              AND h.so_luong < ct.so_luong
        )
        BEGIN
            RAISERROR(N'Không thể hủy hóa đơn nhập vì có sản phẩm tồn kho hiện tại nhỏ hơn số lượng đã nhập (hàng đã xuất bán)!', 16, 1);
        END

        UPDATE dbo.hoa_don_nhap
        SET trang_thai_giao_dich = N'DaHuy'
        WHERE so_hoa_don_nhap = @so_hoa_don_nhap;

        UPDATE h
        SET h.so_luong = h.so_luong - ct.so_luong
        FROM dbo.hang_hoa h
        INNER JOIN dbo.chi_tiet_hoa_don_nhap ct ON h.ma_hang = ct.ma_hang
        WHERE ct.so_hoa_don_nhap = @so_hoa_don_nhap;

        ;WITH GiaCu AS (
            SELECT 
                ct.ma_hang,
                (SELECT TOP 1 cthn.don_gia 
                 FROM dbo.chi_tiet_hoa_don_nhap cthn
                 INNER JOIN dbo.hoa_don_nhap hdn ON cthn.so_hoa_don_nhap = hdn.so_hoa_don_nhap
                 WHERE cthn.ma_hang = ct.ma_hang 
                   AND hdn.trang_thai_giao_dich = N'HoanThanh' 
                   AND hdn.so_hoa_don_nhap <> @so_hoa_don_nhap
                 ORDER BY hdn.thoi_gian_nhap DESC) AS gia_nhap_truoc
            FROM dbo.chi_tiet_hoa_don_nhap ct
            WHERE ct.so_hoa_don_nhap = @so_hoa_don_nhap
        )
        UPDATE h
        SET h.don_gia_nhap = gc.gia_nhap_truoc,
            h.don_gia_ban = CEILING((gc.gia_nhap_truoc * 1.10) / 1000.0) * 1000
        FROM dbo.hang_hoa h
        INNER JOIN GiaCu gc ON h.ma_hang = gc.ma_hang
        WHERE gc.gia_nhap_truoc IS NOT NULL;

        IF @hasInternalTrans = 1
        BEGIN
            COMMIT TRANSACTION;
        END
    END TRY
    BEGIN CATCH
        IF @hasInternalTrans = 1 AND @@TRANCOUNT > 0
        BEGIN
            ROLLBACK TRANSACTION;
        END;
        THROW;
    END CATCH
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_BaoHanh_CapNhatTrangThai
    @ma_phieu_bao_hanh VARCHAR(20),
    @trang_thai_bao_hanh NVARCHAR(50),
    @chi_phi_sua_chua DECIMAL(18,2) = NULL,
    @bien_phap_xu_ly NVARCHAR(255) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (
        SELECT 1 
        FROM dbo.phieu_bao_hanh 
        WHERE ma_phieu_bao_hanh = @ma_phieu_bao_hanh
    )
    BEGIN
        RAISERROR(N'Phiếu bảo hành không tồn tại trong hệ thống!', 16, 1);
        RETURN;
    END

    UPDATE dbo.phieu_bao_hanh
    SET 
        trang_thai = @trang_thai_bao_hanh,
        chi_phi = ISNULL(@chi_phi_sua_chua, chi_phi),
        bien_phap_xu_ly = ISNULL(@bien_phap_xu_ly, bien_phap_xu_ly),
        ngay_tra_thuc_te = CASE 
            WHEN @trang_thai_bao_hanh = N'DaTra' AND ngay_tra_thuc_te IS NULL THEN CAST(GETDATE() AS DATE)
            ELSE ngay_tra_thuc_te 
        END
    WHERE ma_phieu_bao_hanh = @ma_phieu_bao_hanh;
END;
GO


CREATE OR ALTER PROCEDURE dbo.sp_BaoCao_Top10BanChay
    @nam INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT TOP 10 
        h.ma_hang,
        h.ten_hang_hoa,
        SUM(ct.so_luong) AS tong_so_luong_ban,
        SUM(ct.thanh_tien) AS tong_doanh_thu
    FROM dbo.chi_tiet_hoa_don_ban ct
    INNER JOIN dbo.hoa_don_ban hd ON ct.so_hoa_don_ban = hd.so_hoa_don_ban
    INNER JOIN dbo.hang_hoa h ON ct.ma_hang = h.ma_hang
    WHERE YEAR(hd.thoi_gian_ban) = @nam 
      AND hd.trang_thai_giao_dich = N'HoanThanh'
    GROUP BY h.ma_hang, h.ten_hang_hoa
    ORDER BY SUM(ct.so_luong) DESC;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_BaoCao_NhapHangTheoThoiGian
    @nam INT,
    @thang INT = NULL,
    @quy INT = NULL,
    @ma_nhan_vien VARCHAR(20) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        hd.so_hoa_don_nhap,
        hd.thoi_gian_nhap,
        ncc.ten_nha_cung_cap,
        nv.ten_nhan_vien,
        hd.tong_tien
    FROM dbo.hoa_don_nhap hd
    INNER JOIN dbo.nha_cung_cap ncc ON hd.ma_nha_cung_cap = ncc.ma_nha_cung_cap
    INNER JOIN dbo.nhan_vien nv ON hd.ma_nhan_vien = nv.ma_nhan_vien
    WHERE (@ma_nhan_vien IS NULL OR @ma_nhan_vien = '' OR hd.ma_nhan_vien = @ma_nhan_vien)
      AND YEAR(hd.thoi_gian_nhap) = @nam
      AND (@thang IS NULL OR @thang = 0 OR MONTH(hd.thoi_gian_nhap) = @thang)
      AND (@quy IS NULL OR @quy = 0 OR DATEPART(QUARTER, hd.thoi_gian_nhap) = @quy)
      AND hd.trang_thai_giao_dich = N'HoanThanh'
    ORDER BY hd.thoi_gian_nhap DESC;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_BaoCao_BanHangTheoThoiGian
    @nam INT,
    @thang INT = NULL,
    @quy INT = NULL,
    @ma_nhan_vien VARCHAR(20) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        hd.so_hoa_don_ban,
        hd.thoi_gian_ban,
        kh.ten_khach,
        nv.ten_nhan_vien,
        hd.tong_tien
    FROM dbo.hoa_don_ban hd
    INNER JOIN dbo.khach_hang kh ON hd.ma_khach = kh.ma_khach
    INNER JOIN dbo.nhan_vien nv ON hd.ma_nhan_vien = nv.ma_nhan_vien
    WHERE (@ma_nhan_vien IS NULL OR @ma_nhan_vien = '' OR hd.ma_nhan_vien = @ma_nhan_vien)
      AND YEAR(hd.thoi_gian_ban) = @nam
      AND (@thang IS NULL OR @thang = 0 OR MONTH(hd.thoi_gian_ban) = @thang)
      AND (@quy IS NULL OR @quy = 0 OR DATEPART(QUARTER, hd.thoi_gian_ban) = @quy)
      AND hd.trang_thai_giao_dich = N'HoanThanh'
    ORDER BY hd.thoi_gian_ban DESC;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_BaoCao_NhanVienBanItTienNhat
    @nam INT,
    @che_do INT = 1
AS
BEGIN
    SET NOCOUNT ON;

    IF @che_do = 1
    BEGIN
        SELECT 
            nv.ma_nhan_vien,
            nv.ten_nhan_vien,
            cv.ten_cong_viec,
            nv.dien_thoai,
            0 AS so_hoa_don_da_ban,
            CAST(0.00 AS DECIMAL(18,2)) AS tong_doanh_thu
        FROM dbo.nhan_vien nv
        INNER JOIN dbo.cong_viec cv ON nv.ma_cong_viec = cv.ma_cong_viec
        LEFT JOIN dbo.tai_khoan tk ON nv.ma_nhan_vien = tk.ma_nhan_vien
        WHERE nv.trang_thai_xoa = 0
          AND (
              cv.ten_cong_viec LIKE N'%Bán hàng%' 
              OR cv.ten_cong_viec LIKE N'%Kinh doanh%'
              OR tk.quyen = N'BanHang'
          )
          AND ISNULL(tk.quyen, N'BanHang') NOT IN (N'QuanLy', N'ThuKho')
          AND cv.ma_cong_viec NOT IN ('CV0001', 'CV0003')
          AND cv.ten_cong_viec NOT LIKE N'%Quản lý%'
          AND cv.ten_cong_viec NOT LIKE N'%Thủ kho%'
          AND nv.ma_nhan_vien NOT IN (
              SELECT DISTINCT hd.ma_nhan_vien 
              FROM dbo.hoa_don_ban hd 
              WHERE YEAR(hd.thoi_gian_ban) = @nam 
                AND hd.trang_thai_giao_dich = N'HoanThanh'
          )
        ORDER BY nv.ma_nhan_vien ASC;
    END
    ELSE IF @che_do = 2
    BEGIN
        SELECT TOP 10 
            nv.ma_nhan_vien,
            nv.ten_nhan_vien,
            cv.ten_cong_viec,
            nv.dien_thoai,
            COUNT(hd.so_hoa_don_ban) AS so_hoa_don_da_ban,
            SUM(hd.tong_tien) AS tong_doanh_thu
        FROM dbo.hoa_don_ban hd
        INNER JOIN dbo.nhan_vien nv ON hd.ma_nhan_vien = nv.ma_nhan_vien
        INNER JOIN dbo.cong_viec cv ON nv.ma_cong_viec = cv.ma_cong_viec
        LEFT JOIN dbo.tai_khoan tk ON nv.ma_nhan_vien = tk.ma_nhan_vien
        WHERE YEAR(hd.thoi_gian_ban) = @nam 
          AND hd.trang_thai_giao_dich = N'HoanThanh'
          AND nv.trang_thai_xoa = 0
          AND (
              cv.ten_cong_viec LIKE N'%Bán hàng%' 
              OR cv.ten_cong_viec LIKE N'%Kinh doanh%'
              OR tk.quyen = N'BanHang'
          )
          AND ISNULL(tk.quyen, N'BanHang') NOT IN (N'QuanLy', N'ThuKho')
          AND cv.ma_cong_viec NOT IN ('CV0001', 'CV0003')
          AND cv.ten_cong_viec NOT LIKE N'%Quản lý%'
          AND cv.ten_cong_viec NOT LIKE N'%Thủ kho%'
        GROUP BY nv.ma_nhan_vien, nv.ten_nhan_vien, cv.ten_cong_viec, nv.dien_thoai
        ORDER BY SUM(hd.tong_tien) ASC;
    END;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_TienIch_KiemTraTonTai
    @ten_bang NVARCHAR(100),
    @ten_cot NVARCHAR(100),
    @gia_tri NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @sql NVARCHAR(MAX);
    SET @sql = N'SELECT COUNT(1) FROM dbo.' + QUOTENAME(@ten_bang) + N' WHERE ' + QUOTENAME(@ten_cot) + N' = @val';
    EXEC sp_executesql @sql, N'@val NVARCHAR(100)', @val = @gia_tri;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_TienIch_SinhMaTuDong
    @ten_bang NVARCHAR(100),
    @ten_cot NVARCHAR(100),
    @prefix NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @sql NVARCHAR(MAX);
    DECLARE @lenPrefix INT = LEN(@prefix);
    SET @sql = N'SELECT @maxVal = ISNULL(MAX(TRY_CAST(SUBSTRING(' + QUOTENAME(@ten_cot) + N', ' + CAST(@lenPrefix + 1 AS NVARCHAR(10)) + N', 30) AS INT)), 0) FROM dbo.' + QUOTENAME(@ten_bang) + N' WHERE ' + QUOTENAME(@ten_cot) + N' LIKE @pref + ''%''';
    DECLARE @maxSo INT = 0;
    EXEC sp_executesql @sql, N'@pref NVARCHAR(20), @maxVal INT OUTPUT', @pref = @prefix, @maxVal = @maxSo OUTPUT;
    SELECT @prefix + RIGHT('0000' + CAST(@maxSo + 1 AS NVARCHAR(10)), 4) AS ma_moi;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_KhachHang_LayDanhSach
    @trang_thai_xoa BIT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT ma_khach, ten_khach, dia_chi, dien_thoai, trang_thai_xoa 
    FROM dbo.khach_hang 
    WHERE trang_thai_xoa = @trang_thai_xoa 
    ORDER BY ma_khach;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_KhachHang_Them
    @ma_khach VARCHAR(20),
    @ten_khach NVARCHAR(100),
    @dia_chi NVARCHAR(255) = NULL,
    @dien_thoai VARCHAR(20) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO dbo.khach_hang (ma_khach, ten_khach, dia_chi, dien_thoai, trang_thai_xoa)
    VALUES (@ma_khach, @ten_khach, @dia_chi, @dien_thoai, 0);
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_KhachHang_CapNhat
    @ma_khach VARCHAR(20),
    @ten_khach NVARCHAR(100),
    @dia_chi NVARCHAR(255) = NULL,
    @dien_thoai VARCHAR(20) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE dbo.khach_hang 
    SET ten_khach = @ten_khach, 
        dia_chi = @dia_chi, 
        dien_thoai = @dien_thoai 
    WHERE ma_khach = @ma_khach;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_KhachHang_XoaMem
    @ma_khach VARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE dbo.khach_hang 
    SET trang_thai_xoa = 1 
    WHERE ma_khach = @ma_khach;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_KhachHang_DemPhieuBaoHanhChuaHoanTat
    @ma_khach VARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT COUNT(1) 
    FROM dbo.phieu_bao_hanh 
    WHERE ma_khach = @ma_khach 
      AND trang_thai_xoa = 0 
      AND trang_thai IN ('TiepNhan', 'DangXuLy', 'DaXong');
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_KhachHang_KhoiPhuc
    @ma_khach VARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE dbo.khach_hang 
    SET trang_thai_xoa = 0 
    WHERE ma_khach = @ma_khach;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_KhachHang_KiemTraTrungSDT
    @dien_thoai VARCHAR(20),
    @ma_khach VARCHAR(20) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SELECT COUNT(1) 
    FROM dbo.khach_hang 
    WHERE dien_thoai = @dien_thoai 
      AND trang_thai_xoa = 0 
      AND (@ma_khach IS NULL OR ma_khach <> @ma_khach);
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_KhachHang_LaySDT
    @ma_khach VARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT dien_thoai 
    FROM dbo.khach_hang 
    WHERE ma_khach = @ma_khach;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_KhachHang_TimKiem
    @trang_thai_xoa BIT,
    @ma_khach VARCHAR(20) = NULL,
    @ten_khach NVARCHAR(100) = NULL,
    @dien_thoai VARCHAR(20) = NULL,
    @dia_chi NVARCHAR(255) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SELECT ma_khach, ten_khach, dia_chi, dien_thoai, trang_thai_xoa 
    FROM dbo.khach_hang 
    WHERE trang_thai_xoa = @trang_thai_xoa 
      AND (@ma_khach IS NULL OR @ma_khach = '' OR ma_khach LIKE '%' + @ma_khach + '%')
      AND (@ten_khach IS NULL OR @ten_khach = '' OR ten_khach LIKE '%' + @ten_khach + '%')
      AND (@dien_thoai IS NULL OR @dien_thoai = '' OR dien_thoai LIKE '%' + @dien_thoai + '%')
      AND (@dia_chi IS NULL OR @dia_chi = '' OR dia_chi LIKE '%' + @dia_chi + '%')
    ORDER BY ma_khach;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_NhaCungCap_LayDanhSach
    @trang_thai_xoa BIT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT ma_nha_cung_cap, ten_nha_cung_cap, dia_chi, dien_thoai, trang_thai_xoa 
    FROM dbo.nha_cung_cap 
    WHERE trang_thai_xoa = @trang_thai_xoa 
    ORDER BY ma_nha_cung_cap;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_NhaCungCap_Them
    @ma_nha_cung_cap VARCHAR(20),
    @ten_nha_cung_cap NVARCHAR(150),
    @dia_chi NVARCHAR(255) = NULL,
    @dien_thoai VARCHAR(20) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO dbo.nha_cung_cap (ma_nha_cung_cap, ten_nha_cung_cap, dia_chi, dien_thoai, trang_thai_xoa)
    VALUES (@ma_nha_cung_cap, @ten_nha_cung_cap, @dia_chi, @dien_thoai, 0);
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_NhaCungCap_CapNhat
    @ma_nha_cung_cap VARCHAR(20),
    @ten_nha_cung_cap NVARCHAR(150),
    @dia_chi NVARCHAR(255) = NULL,
    @dien_thoai VARCHAR(20) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE dbo.nha_cung_cap 
    SET ten_nha_cung_cap = @ten_nha_cung_cap, 
        dia_chi = @dia_chi, 
        dien_thoai = @dien_thoai 
    WHERE ma_nha_cung_cap = @ma_nha_cung_cap;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_NhaCungCap_XoaMem
    @ma_nha_cung_cap VARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE dbo.nha_cung_cap 
    SET trang_thai_xoa = 1 
    WHERE ma_nha_cung_cap = @ma_nha_cung_cap;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_NhaCungCap_KhoiPhuc
    @ma_nha_cung_cap VARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE dbo.nha_cung_cap 
    SET trang_thai_xoa = 0 
    WHERE ma_nha_cung_cap = @ma_nha_cung_cap;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_NhaCungCap_TimKiem
    @trang_thai_xoa BIT,
    @ma_ncc VARCHAR(20) = NULL,
    @ten_ncc NVARCHAR(150) = NULL,
    @dien_thoai VARCHAR(20) = NULL,
    @dia_chi NVARCHAR(255) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SELECT ma_nha_cung_cap, ten_nha_cung_cap, dia_chi, dien_thoai, trang_thai_xoa 
    FROM dbo.nha_cung_cap 
    WHERE trang_thai_xoa = @trang_thai_xoa 
      AND (@ma_ncc IS NULL OR @ma_ncc = '' OR ma_nha_cung_cap LIKE '%' + @ma_ncc + '%')
      AND (@ten_ncc IS NULL OR @ten_ncc = '' OR ten_nha_cung_cap LIKE '%' + @ten_ncc + '%')
      AND (@dien_thoai IS NULL OR @dien_thoai = '' OR dien_thoai LIKE '%' + @dien_thoai + '%')
      AND (@dia_chi IS NULL OR @dia_chi = '' OR dia_chi LIKE '%' + @dia_chi + '%')
    ORDER BY ma_nha_cung_cap;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_ThuocTinh_LayDanhSach
    @ten_bang VARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    IF @ten_bang = 'loai'
        SELECT ma_loai AS Ma, ten_loai AS Ten, CAST(NULL AS VARCHAR(20)) AS MaLoai FROM dbo.loai ORDER BY ma_loai;
    ELSE IF @ten_bang = 'kich_thuoc'
        SELECT ma_kich_thuoc AS Ma, ten_kich_thuoc AS Ten, ma_loai AS MaLoai FROM dbo.kich_thuoc ORDER BY ma_kich_thuoc;
    ELSE IF @ten_bang = 'hinh_dang'
        SELECT ma_hinh_dang AS Ma, ten_hinh_dang AS Ten, CAST(NULL AS VARCHAR(20)) AS MaLoai FROM dbo.hinh_dang ORDER BY ma_hinh_dang;
    ELSE IF @ten_bang = 'chat_lieu'
        SELECT ma_chat_lieu AS Ma, ten_chat_lieu AS Ten, CAST(NULL AS VARCHAR(20)) AS MaLoai FROM dbo.chat_lieu ORDER BY ma_chat_lieu;
    ELSE IF @ten_bang = 'nuoc_san_xuat'
        SELECT ma_nuoc_san_xuat AS Ma, ten_nuoc_san_xuat AS Ten, CAST(NULL AS VARCHAR(20)) AS MaLoai FROM dbo.nuoc_san_xuat ORDER BY ma_nuoc_san_xuat;
    ELSE IF @ten_bang = 'mau_sac'
        SELECT ma_mau AS Ma, ten_mau AS Ten, CAST(NULL AS VARCHAR(20)) AS MaLoai FROM dbo.mau_sac ORDER BY ma_mau;
    ELSE IF @ten_bang = 'nha_san_xuat'
        SELECT ma_nha_san_xuat AS Ma, ten_nha_san_xuat AS Ten, CAST(NULL AS VARCHAR(20)) AS MaLoai FROM dbo.nha_san_xuat ORDER BY ma_nha_san_xuat;
    ELSE IF @ten_bang = 'cong_dung'
        SELECT ma_cong_dung AS Ma, ten_cong_dung AS Ten, CAST(NULL AS VARCHAR(20)) AS MaLoai FROM dbo.cong_dung ORDER BY ma_cong_dung;
    ELSE IF @ten_bang = 'dac_diem'
        SELECT ma_dac_diem AS Ma, ten_dac_diem AS Ten, CAST(NULL AS VARCHAR(20)) AS MaLoai FROM dbo.dac_diem ORDER BY ma_dac_diem;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_ThuocTinh_KiemTraTrungTen
    @ten_bang VARCHAR(50),
    @ten NVARCHAR(200),
    @ma_bo_qua VARCHAR(50) = NULL,
    @ma_loai VARCHAR(50) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    IF @ten_bang = 'loai'
        SELECT COUNT(1) FROM dbo.loai WHERE ten_loai = @ten AND (@ma_bo_qua IS NULL OR ma_loai <> @ma_bo_qua);
    ELSE IF @ten_bang = 'kich_thuoc'
        SELECT COUNT(1) FROM dbo.kich_thuoc WHERE ten_kich_thuoc = @ten AND (@ma_bo_qua IS NULL OR ma_kich_thuoc <> @ma_bo_qua) AND (@ma_loai IS NULL OR ma_loai = @ma_loai);
    ELSE IF @ten_bang = 'hinh_dang'
        SELECT COUNT(1) FROM dbo.hinh_dang WHERE ten_hinh_dang = @ten AND (@ma_bo_qua IS NULL OR ma_hinh_dang <> @ma_bo_qua);
    ELSE IF @ten_bang = 'chat_lieu'
        SELECT COUNT(1) FROM dbo.chat_lieu WHERE ten_chat_lieu = @ten AND (@ma_bo_qua IS NULL OR ma_chat_lieu <> @ma_bo_qua);
    ELSE IF @ten_bang = 'nuoc_san_xuat'
        SELECT COUNT(1) FROM dbo.nuoc_san_xuat WHERE ten_nuoc_san_xuat = @ten AND (@ma_bo_qua IS NULL OR ma_nuoc_san_xuat <> @ma_bo_qua);
    ELSE IF @ten_bang = 'mau_sac'
        SELECT COUNT(1) FROM dbo.mau_sac WHERE ten_mau = @ten AND (@ma_bo_qua IS NULL OR ma_mau <> @ma_bo_qua);
    ELSE IF @ten_bang = 'nha_san_xuat'
        SELECT COUNT(1) FROM dbo.nha_san_xuat WHERE ten_nha_san_xuat = @ten AND (@ma_bo_qua IS NULL OR ma_nha_san_xuat <> @ma_bo_qua);
    ELSE IF @ten_bang = 'cong_dung'
        SELECT COUNT(1) FROM dbo.cong_dung WHERE ten_cong_dung = @ten AND (@ma_bo_qua IS NULL OR ma_cong_dung <> @ma_bo_qua);
    ELSE IF @ten_bang = 'dac_diem'
        SELECT COUNT(1) FROM dbo.dac_diem WHERE ten_dac_diem = @ten AND (@ma_bo_qua IS NULL OR ma_dac_diem <> @ma_bo_qua);
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_ThuocTinh_KiemTraRangBuocKhoaNgoai
    @ten_bang VARCHAR(50),
    @ma VARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    IF @ten_bang = 'loai'
    BEGIN
        IF EXISTS (SELECT 1 FROM dbo.kich_thuoc WHERE ma_loai = @ma) OR EXISTS (SELECT 1 FROM dbo.hang_hoa WHERE ma_loai = @ma)
            SELECT 1;
        ELSE
            SELECT 0;
    END
    ELSE IF @ten_bang = 'kich_thuoc'
    BEGIN
        IF EXISTS (SELECT 1 FROM dbo.hang_hoa WHERE ma_kich_thuoc = @ma) SELECT 1; ELSE SELECT 0;
    END
    ELSE IF @ten_bang = 'hinh_dang'
    BEGIN
        IF EXISTS (SELECT 1 FROM dbo.hang_hoa WHERE ma_hinh_dang = @ma) SELECT 1; ELSE SELECT 0;
    END
    ELSE IF @ten_bang = 'chat_lieu'
    BEGIN
        IF EXISTS (SELECT 1 FROM dbo.hang_hoa WHERE ma_chat_lieu = @ma) SELECT 1; ELSE SELECT 0;
    END
    ELSE IF @ten_bang = 'nuoc_san_xuat'
    BEGIN
        IF EXISTS (SELECT 1 FROM dbo.hang_hoa WHERE ma_nuoc_san_xuat = @ma) SELECT 1; ELSE SELECT 0;
    END
    ELSE IF @ten_bang = 'mau_sac'
    BEGIN
        IF EXISTS (SELECT 1 FROM dbo.hang_hoa WHERE ma_mau = @ma) SELECT 1; ELSE SELECT 0;
    END
    ELSE IF @ten_bang = 'nha_san_xuat'
    BEGIN
        IF EXISTS (SELECT 1 FROM dbo.hang_hoa WHERE ma_nha_san_xuat = @ma) SELECT 1; ELSE SELECT 0;
    END
    ELSE IF @ten_bang = 'cong_dung'
    BEGIN
        IF EXISTS (SELECT 1 FROM dbo.hang_hoa WHERE ma_cong_dung = @ma) SELECT 1; ELSE SELECT 0;
    END
    ELSE IF @ten_bang = 'dac_diem'
    BEGIN
        IF EXISTS (SELECT 1 FROM dbo.hang_hoa WHERE ma_dac_diem = @ma) SELECT 1; ELSE SELECT 0;
    END
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_ThuocTinh_Them
    @ten_bang VARCHAR(50),
    @ma VARCHAR(50),
    @ten NVARCHAR(200),
    @ma_loai VARCHAR(50) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    IF @ten_bang = 'loai'
        INSERT INTO dbo.loai (ma_loai, ten_loai) VALUES (@ma, @ten);
    ELSE IF @ten_bang = 'kich_thuoc'
        INSERT INTO dbo.kich_thuoc (ma_kich_thuoc, ten_kich_thuoc, ma_loai) VALUES (@ma, @ten, @ma_loai);
    ELSE IF @ten_bang = 'hinh_dang'
        INSERT INTO dbo.hinh_dang (ma_hinh_dang, ten_hinh_dang) VALUES (@ma, @ten);
    ELSE IF @ten_bang = 'chat_lieu'
        INSERT INTO dbo.chat_lieu (ma_chat_lieu, ten_chat_lieu) VALUES (@ma, @ten);
    ELSE IF @ten_bang = 'nuoc_san_xuat'
        INSERT INTO dbo.nuoc_san_xuat (ma_nuoc_san_xuat, ten_nuoc_san_xuat) VALUES (@ma, @ten);
    ELSE IF @ten_bang = 'mau_sac'
        INSERT INTO dbo.mau_sac (ma_mau, ten_mau) VALUES (@ma, @ten);
    ELSE IF @ten_bang = 'nha_san_xuat'
        INSERT INTO dbo.nha_san_xuat (ma_nha_san_xuat, ten_nha_san_xuat) VALUES (@ma, @ten);
    ELSE IF @ten_bang = 'cong_dung'
        INSERT INTO dbo.cong_dung (ma_cong_dung, ten_cong_dung) VALUES (@ma, @ten);
    ELSE IF @ten_bang = 'dac_diem'
        INSERT INTO dbo.dac_diem (ma_dac_diem, ten_dac_diem) VALUES (@ma, @ten);
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_ThuocTinh_Sua
    @ten_bang VARCHAR(50),
    @ma VARCHAR(50),
    @ten NVARCHAR(200),
    @ma_loai VARCHAR(50) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    IF @ten_bang = 'loai'
        UPDATE dbo.loai SET ten_loai = @ten WHERE ma_loai = @ma;
    ELSE IF @ten_bang = 'kich_thuoc'
        UPDATE dbo.kich_thuoc SET ten_kich_thuoc = @ten, ma_loai = @ma_loai WHERE ma_kich_thuoc = @ma;
    ELSE IF @ten_bang = 'hinh_dang'
        UPDATE dbo.hinh_dang SET ten_hinh_dang = @ten WHERE ma_hinh_dang = @ma;
    ELSE IF @ten_bang = 'chat_lieu'
        UPDATE dbo.chat_lieu SET ten_chat_lieu = @ten WHERE ma_chat_lieu = @ma;
    ELSE IF @ten_bang = 'nuoc_san_xuat'
        UPDATE dbo.nuoc_san_xuat SET ten_nuoc_san_xuat = @ten WHERE ma_nuoc_san_xuat = @ma;
    ELSE IF @ten_bang = 'mau_sac'
        UPDATE dbo.mau_sac SET ten_mau = @ten WHERE ma_mau = @ma;
    ELSE IF @ten_bang = 'nha_san_xuat'
        UPDATE dbo.nha_san_xuat SET ten_nha_san_xuat = @ten WHERE ma_nha_san_xuat = @ma;
    ELSE IF @ten_bang = 'cong_dung'
        UPDATE dbo.cong_dung SET ten_cong_dung = @ten WHERE ma_cong_dung = @ma;
    ELSE IF @ten_bang = 'dac_diem'
        UPDATE dbo.dac_diem SET ten_dac_diem = @ten WHERE ma_dac_diem = @ma;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_ThuocTinh_Xoa
    @ten_bang VARCHAR(50),
    @ma VARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    IF @ten_bang = 'loai'
        DELETE FROM dbo.loai WHERE ma_loai = @ma;
    ELSE IF @ten_bang = 'kich_thuoc'
        DELETE FROM dbo.kich_thuoc WHERE ma_kich_thuoc = @ma;
    ELSE IF @ten_bang = 'hinh_dang'
        DELETE FROM dbo.hinh_dang WHERE ma_hinh_dang = @ma;
    ELSE IF @ten_bang = 'chat_lieu'
        DELETE FROM dbo.chat_lieu WHERE ma_chat_lieu = @ma;
    ELSE IF @ten_bang = 'nuoc_san_xuat'
        DELETE FROM dbo.nuoc_san_xuat WHERE ma_nuoc_san_xuat = @ma;
    ELSE IF @ten_bang = 'mau_sac'
        DELETE FROM dbo.mau_sac WHERE ma_mau = @ma;
    ELSE IF @ten_bang = 'nha_san_xuat'
        DELETE FROM dbo.nha_san_xuat WHERE ma_nha_san_xuat = @ma;
    ELSE IF @ten_bang = 'cong_dung'
        DELETE FROM dbo.cong_dung WHERE ma_cong_dung = @ma;
    ELSE IF @ten_bang = 'dac_diem'
        DELETE FROM dbo.dac_diem WHERE ma_dac_diem = @ma;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_KichThuoc_LayTheoLoai
    @ma_loai VARCHAR(20) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    IF @ma_loai IS NULL OR @ma_loai = ''
        SELECT ma_kich_thuoc AS Ma, ten_kich_thuoc AS Ten, ma_loai AS MaLoai FROM dbo.kich_thuoc ORDER BY ma_kich_thuoc;
    ELSE
        SELECT ma_kich_thuoc AS Ma, ten_kich_thuoc AS Ten, ma_loai AS MaLoai FROM dbo.kich_thuoc WHERE ma_loai = @ma_loai ORDER BY ma_kich_thuoc;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_CongViec_LayDanhSach
    @trang_thai_xoa BIT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT ma_cong_viec, ten_cong_viec, muc_luong, trang_thai_xoa 
    FROM dbo.cong_viec 
    WHERE trang_thai_xoa = @trang_thai_xoa 
    ORDER BY ma_cong_viec ASC;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_CongViec_Them
    @ma_cong_viec VARCHAR(20),
    @ten_cong_viec NVARCHAR(100),
    @muc_luong DECIMAL(18,2) = 0
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO dbo.cong_viec (ma_cong_viec, ten_cong_viec, muc_luong, trang_thai_xoa) 
    VALUES (@ma_cong_viec, @ten_cong_viec, @muc_luong, 0);
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_CongViec_Sua
    @ma_cong_viec VARCHAR(20),
    @ten_cong_viec NVARCHAR(100),
    @muc_luong DECIMAL(18,2) = 0
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE dbo.cong_viec 
    SET ten_cong_viec = @ten_cong_viec, 
        muc_luong = @muc_luong 
    WHERE ma_cong_viec = @ma_cong_viec;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_CongViec_XoaMem
    @ma_cong_viec VARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE dbo.cong_viec 
    SET trang_thai_xoa = 1 
    WHERE ma_cong_viec = @ma_cong_viec;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_CongViec_KhoiPhuc
    @ma_cong_viec VARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE dbo.cong_viec 
    SET trang_thai_xoa = 0 
    WHERE ma_cong_viec = @ma_cong_viec;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_CongViec_LayTheoMa
    @ma_cong_viec VARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT ma_cong_viec, ten_cong_viec, muc_luong, trang_thai_xoa 
    FROM dbo.cong_viec 
    WHERE ma_cong_viec = @ma_cong_viec;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_CongViec_KiemTraDangSuDung
    @ma_cong_viec VARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT COUNT(1) 
    FROM dbo.nhan_vien 
    WHERE ma_cong_viec = @ma_cong_viec 
      AND trang_thai_xoa = 0;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_CongViec_KiemTraTrungTen
    @ten_cong_viec NVARCHAR(100),
    @ma_cong_viec VARCHAR(20) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SELECT COUNT(1) 
    FROM dbo.cong_viec 
    WHERE LOWER(ten_cong_viec) = LOWER(RTRIM(LTRIM(@ten_cong_viec))) 
      AND trang_thai_xoa = 0
      AND (@ma_cong_viec IS NULL OR ma_cong_viec <> @ma_cong_viec);
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_NhanVien_LayDanhSach
    @trang_thai_xoa BIT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT 
        nv.ma_nhan_vien, 
        nv.ten_nhan_vien, 
        nv.gioi_tinh, 
        nv.ngay_sinh, 
        nv.dien_thoai, 
        nv.dia_chi, 
        nv.trang_thai_xoa,
        nv.ma_cong_viec, 
        cv.ten_cong_viec, 
        cv.muc_luong,
        tk.ten_dang_nhap, 
        tk.quyen, 
        tk.trang_thai_hoat_dong
    FROM dbo.nhan_vien nv
    LEFT JOIN dbo.cong_viec cv ON nv.ma_cong_viec = cv.ma_cong_viec
    LEFT JOIN dbo.tai_khoan tk ON nv.ma_nhan_vien = tk.ma_nhan_vien
    WHERE nv.trang_thai_xoa = @trang_thai_xoa
    ORDER BY nv.ma_nhan_vien;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_NhanVien_LayTheoMa
    @ma_nhan_vien VARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT ma_nhan_vien, ten_nhan_vien, gioi_tinh, ngay_sinh, dien_thoai, dia_chi, trang_thai_xoa, ma_cong_viec 
    FROM dbo.nhan_vien 
    WHERE ma_nhan_vien = @ma_nhan_vien;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_NhanVien_Them
    @ma_nhan_vien VARCHAR(20),
    @ten_nhan_vien NVARCHAR(100),
    @gioi_tinh NVARCHAR(10) = NULL,
    @ngay_sinh DATE = NULL,
    @dien_thoai VARCHAR(20) = NULL,
    @dia_chi NVARCHAR(255) = NULL,
    @ma_cong_viec VARCHAR(20) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO dbo.nhan_vien (ma_nhan_vien, ten_nhan_vien, gioi_tinh, ngay_sinh, dien_thoai, dia_chi, trang_thai_xoa, ma_cong_viec)
    VALUES (@ma_nhan_vien, @ten_nhan_vien, @gioi_tinh, @ngay_sinh, @dien_thoai, @dia_chi, 0, @ma_cong_viec);
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_NhanVien_CapNhat
    @ma_nhan_vien VARCHAR(20),
    @ten_nhan_vien NVARCHAR(100),
    @gioi_tinh NVARCHAR(10) = NULL,
    @ngay_sinh DATE = NULL,
    @dien_thoai VARCHAR(20) = NULL,
    @dia_chi NVARCHAR(255) = NULL,
    @ma_cong_viec VARCHAR(20) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE dbo.nhan_vien 
    SET ten_nhan_vien = @ten_nhan_vien, 
        gioi_tinh = @gioi_tinh, 
        ngay_sinh = @ngay_sinh, 
        dien_thoai = @dien_thoai, 
        dia_chi = @dia_chi, 
        ma_cong_viec = @ma_cong_viec 
    WHERE ma_nhan_vien = @ma_nhan_vien;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_NhanVien_XoaMem
    @ma_nhan_vien VARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE dbo.nhan_vien SET trang_thai_xoa = 1 WHERE ma_nhan_vien = @ma_nhan_vien;
    UPDATE dbo.tai_khoan SET trang_thai_hoat_dong = 0 WHERE ma_nhan_vien = @ma_nhan_vien;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_NhanVien_KhoiPhuc
    @ma_nhan_vien VARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE dbo.nhan_vien SET trang_thai_xoa = 0 WHERE ma_nhan_vien = @ma_nhan_vien;
    UPDATE dbo.tai_khoan SET trang_thai_hoat_dong = 1 WHERE ma_nhan_vien = @ma_nhan_vien;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_NhanVien_KiemTraCoTaiKhoan
    @ma_nhan_vien VARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT COUNT(1) 
    FROM dbo.tai_khoan 
    WHERE ma_nhan_vien = @ma_nhan_vien;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_NhanVien_LayTenDangNhap
    @ma_nhan_vien VARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT ten_dang_nhap 
    FROM dbo.tai_khoan 
    WHERE ma_nhan_vien = @ma_nhan_vien;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_TaiKhoan_Them
    @ten_dang_nhap VARCHAR(50),
    @mat_khau VARCHAR(255),
    @quyen NVARCHAR(50),
    @trang_thai_hoat_dong BIT,
    @ma_nhan_vien VARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO dbo.tai_khoan (ten_dang_nhap, mat_khau, quyen, trang_thai_hoat_dong, ma_nhan_vien)
    VALUES (@ten_dang_nhap, @mat_khau, @quyen, @trang_thai_hoat_dong, @ma_nhan_vien);
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_TaiKhoan_CapNhatQuyenVaTrangThai
    @ten_dang_nhap VARCHAR(50),
    @quyen NVARCHAR(50),
    @trang_thai_hoat_dong BIT
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE dbo.tai_khoan 
    SET quyen = @quyen, 
        trang_thai_hoat_dong = @trang_thai_hoat_dong 
    WHERE ten_dang_nhap = @ten_dang_nhap;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_TaiKhoan_DoiTrangThai
    @ten_dang_nhap VARCHAR(50),
    @trang_thai_hoat_dong BIT
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE dbo.tai_khoan 
    SET trang_thai_hoat_dong = @trang_thai_hoat_dong 
    WHERE ten_dang_nhap = @ten_dang_nhap;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_TaiKhoan_ResetMatKhau
    @ten_dang_nhap VARCHAR(50),
    @mat_khau VARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE dbo.tai_khoan 
    SET mat_khau = @mat_khau 
    WHERE ten_dang_nhap = @ten_dang_nhap;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_TaiKhoan_LayThongTinDangNhap
    @ten_dang_nhap VARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT 
        tk.ten_dang_nhap,
        tk.mat_khau,
        tk.quyen,
        tk.trang_thai_hoat_dong,
        tk.ma_nhan_vien,
        nv.ten_nhan_vien,
        nv.trang_thai_xoa
    FROM dbo.tai_khoan tk
    INNER JOIN dbo.nhan_vien nv ON tk.ma_nhan_vien = nv.ma_nhan_vien
    WHERE tk.ten_dang_nhap = @ten_dang_nhap;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_HangHoa_KhoiPhuc
    @ma_hang VARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE dbo.hang_hoa 
    SET trang_thai_xoa = 0 
    WHERE ma_hang = @ma_hang;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_HangHoa_CapNhatTonKhoVaGia
    @ma_hang VARCHAR(20),
    @so_luong INT,
    @don_gia_nhap DECIMAL(18,2) = 0
AS
BEGIN
    SET NOCOUNT ON;
    IF @don_gia_nhap > 0
    BEGIN
        DECLARE @don_gia_ban DECIMAL(18,2) = CEILING((@don_gia_nhap * 1.10) / 1000.0) * 1000;
        UPDATE dbo.hang_hoa 
        SET so_luong = so_luong + @so_luong, 
            don_gia_nhap = @don_gia_nhap, 
            don_gia_ban = @don_gia_ban 
        WHERE ma_hang = @ma_hang;
    END
    ELSE
    BEGIN
        UPDATE dbo.hang_hoa 
        SET so_luong = so_luong + @so_luong 
        WHERE ma_hang = @ma_hang;
    END
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_HangHoa_TimKiem
    @trang_thai_xoa BIT,
    @ma_hang VARCHAR(20) = NULL,
    @ten_hang NVARCHAR(200) = NULL,
    @ma_loai VARCHAR(20) = NULL,
    @ma_kich_thuoc VARCHAR(20) = NULL,
    @ma_chat_lieu VARCHAR(20) = NULL,
    @ma_mau VARCHAR(20) = NULL,
    @ma_nuoc_san_xuat VARCHAR(20) = NULL,
    @ma_hinh_dang VARCHAR(20) = NULL,
    @ma_nha_san_xuat VARCHAR(20) = NULL,
    @ma_cong_dung VARCHAR(20) = NULL,
    @ma_dac_diem VARCHAR(20) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SELECT 
        h.ma_hang, 
        h.ten_hang_hoa, 
        h.so_luong, 
        h.don_gia_nhap, 
        h.don_gia_ban, 
        h.thoi_gian_bao_hanh, 
        h.anh, 
        h.ghi_chu, 
        h.trang_thai_xoa,
        h.ma_loai, 
        l.ten_loai,
        h.ma_chat_lieu, 
        cl.ten_chat_lieu,
        h.ma_kich_thuoc, 
        kt.ten_kich_thuoc,
        h.ma_mau, 
        m.ten_mau,
        h.ma_hinh_dang, 
        hd.ten_hinh_dang,
        h.ma_nuoc_san_xuat, 
        nsx.ten_nuoc_san_xuat,
        h.ma_nha_san_xuat, 
        nhasx.ten_nha_san_xuat,
        h.ma_cong_dung, 
        cd.ten_cong_dung,
        h.ma_dac_diem, 
        dd.ten_dac_diem
    FROM dbo.hang_hoa h
    LEFT JOIN dbo.loai l ON h.ma_loai = l.ma_loai
    LEFT JOIN dbo.chat_lieu cl ON h.ma_chat_lieu = cl.ma_chat_lieu
    LEFT JOIN dbo.kich_thuoc kt ON h.ma_kich_thuoc = kt.ma_kich_thuoc
    LEFT JOIN dbo.mau_sac m ON h.ma_mau = m.ma_mau
    LEFT JOIN dbo.hinh_dang hd ON h.ma_hinh_dang = hd.ma_hinh_dang
    LEFT JOIN dbo.nuoc_san_xuat nsx ON h.ma_nuoc_san_xuat = nsx.ma_nuoc_san_xuat
    LEFT JOIN dbo.nha_san_xuat nhasx ON h.ma_nha_san_xuat = nhasx.ma_nha_san_xuat
    LEFT JOIN dbo.cong_dung cd ON h.ma_cong_dung = cd.ma_cong_dung
    LEFT JOIN dbo.dac_diem dd ON h.ma_dac_diem = dd.ma_dac_diem
    WHERE h.trang_thai_xoa = @trang_thai_xoa
      AND (@ma_hang IS NULL OR @ma_hang = '' OR h.ma_hang LIKE '%' + @ma_hang + '%')
      AND (@ten_hang IS NULL OR @ten_hang = '' OR h.ten_hang_hoa LIKE '%' + @ten_hang + '%')
      AND (@ma_loai IS NULL OR @ma_loai = '' OR h.ma_loai = @ma_loai)
      AND (@ma_kich_thuoc IS NULL OR @ma_kich_thuoc = '' OR h.ma_kich_thuoc = @ma_kich_thuoc)
      AND (@ma_chat_lieu IS NULL OR @ma_chat_lieu = '' OR h.ma_chat_lieu = @ma_chat_lieu)
      AND (@ma_mau IS NULL OR @ma_mau = '' OR h.ma_mau = @ma_mau)
      AND (@ma_nuoc_san_xuat IS NULL OR @ma_nuoc_san_xuat = '' OR h.ma_nuoc_san_xuat = @ma_nuoc_san_xuat)
      AND (@ma_hinh_dang IS NULL OR @ma_hinh_dang = '' OR h.ma_hinh_dang = @ma_hinh_dang)
      AND (@ma_nha_san_xuat IS NULL OR @ma_nha_san_xuat = '' OR h.ma_nha_san_xuat = @ma_nha_san_xuat)
      AND (@ma_cong_dung IS NULL OR @ma_cong_dung = '' OR h.ma_cong_dung = @ma_cong_dung)
      AND (@ma_dac_diem IS NULL OR @ma_dac_diem = '' OR h.ma_dac_diem = @ma_dac_diem)
    ORDER BY h.ma_hang ASC;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_HoaDonBan_LayDanhSach
    @tu_ngay DATETIME = NULL,
    @den_ngay DATETIME = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SELECT 
        hdb.so_hoa_don_ban, 
        hdb.thoi_gian_ban, 
        hdb.tong_tien, 
        hdb.trang_thai_giao_dich, 
        hdb.ma_khach, 
        kh.ten_khach, 
        kh.dien_thoai, 
        kh.dia_chi, 
        hdb.ma_nhan_vien, 
        nv.ten_nhan_vien
    FROM dbo.hoa_don_ban hdb
    LEFT JOIN dbo.khach_hang kh ON hdb.ma_khach = kh.ma_khach
    LEFT JOIN dbo.nhan_vien nv ON hdb.ma_nhan_vien = nv.ma_nhan_vien
    WHERE (@tu_ngay IS NULL OR hdb.thoi_gian_ban >= @tu_ngay)
      AND (@den_ngay IS NULL OR hdb.thoi_gian_ban <= @den_ngay)
    ORDER BY hdb.thoi_gian_ban DESC;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_HoaDonBan_LayChiTiet
    @so_hoa_don_ban VARCHAR(30)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT 
        ct.so_hoa_don_ban, 
        ct.ma_hang, 
        hh.ten_hang_hoa, 
        ct.so_luong, 
        ct.don_gia, 
        ct.giam_gia, 
        ct.thanh_tien
    FROM dbo.chi_tiet_hoa_don_ban ct
    LEFT JOIN dbo.hang_hoa hh ON ct.ma_hang = hh.ma_hang
    WHERE ct.so_hoa_don_ban = @so_hoa_don_ban
    ORDER BY ct.ma_hang;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_HoaDonBan_LayTheoMa
    @so_hoa_don_ban VARCHAR(30)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT 
        hdb.so_hoa_don_ban, 
        hdb.thoi_gian_ban, 
        hdb.tong_tien, 
        hdb.trang_thai_giao_dich, 
        hdb.ma_khach, 
        kh.ten_khach, 
        kh.dien_thoai, 
        kh.dia_chi, 
        hdb.ma_nhan_vien, 
        nv.ten_nhan_vien
    FROM dbo.hoa_don_ban hdb
    LEFT JOIN dbo.khach_hang kh ON hdb.ma_khach = kh.ma_khach
    LEFT JOIN dbo.nhan_vien nv ON hdb.ma_nhan_vien = nv.ma_nhan_vien
    WHERE hdb.so_hoa_don_ban = @so_hoa_don_ban;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_HoaDonBan_DemSoPhieuBaoHanh
    @so_hoa_don_ban VARCHAR(30)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT COUNT(1) 
    FROM dbo.phieu_bao_hanh 
    WHERE so_hoa_don_ban = @so_hoa_don_ban 
      AND trang_thai_xoa = 0;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_HoaDonBan_Them
    @so_hoa_don_ban VARCHAR(30),
    @thoi_gian_ban DATETIME,
    @tong_tien DECIMAL(18,2),
    @ma_nhan_vien VARCHAR(20),
    @ma_khach VARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO dbo.hoa_don_ban (so_hoa_don_ban, thoi_gian_ban, tong_tien, trang_thai_giao_dich, ma_nhan_vien, ma_khach)
    VALUES (@so_hoa_don_ban, @thoi_gian_ban, @tong_tien, N'HoanThanh', @ma_nhan_vien, @ma_khach);
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_ChiTietHoaDonBan_Them
    @so_hoa_don_ban VARCHAR(30),
    @ma_hang VARCHAR(20),
    @so_luong INT,
    @don_gia DECIMAL(18,2),
    @giam_gia DECIMAL(5,2),
    @thanh_tien DECIMAL(18,2)
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO dbo.chi_tiet_hoa_don_ban (so_hoa_don_ban, ma_hang, so_luong, don_gia, giam_gia, thanh_tien)
    VALUES (@so_hoa_don_ban, @ma_hang, @so_luong, @don_gia, @giam_gia, @thanh_tien);

    UPDATE dbo.hang_hoa 
    SET so_luong = so_luong - @so_luong 
    WHERE ma_hang = @ma_hang;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_HoaDonNhap_LayDanhSach
    @tu_ngay DATETIME = NULL,
    @den_ngay DATETIME = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SELECT 
        hdn.so_hoa_don_nhap, 
        hdn.thoi_gian_nhap, 
        hdn.tong_tien, 
        hdn.trang_thai_giao_dich, 
        hdn.ma_nha_cung_cap, 
        ncc.ten_nha_cung_cap, 
        ncc.dien_thoai, 
        ncc.dia_chi, 
        hdn.ma_nhan_vien, 
        nv.ten_nhan_vien
    FROM dbo.hoa_don_nhap hdn
    LEFT JOIN dbo.nha_cung_cap ncc ON hdn.ma_nha_cung_cap = ncc.ma_nha_cung_cap
    LEFT JOIN dbo.nhan_vien nv ON hdn.ma_nhan_vien = nv.ma_nhan_vien
    WHERE (@tu_ngay IS NULL OR hdn.thoi_gian_nhap >= @tu_ngay)
      AND (@den_ngay IS NULL OR hdn.thoi_gian_nhap <= @den_ngay)
    ORDER BY hdn.thoi_gian_nhap DESC;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_HoaDonNhap_LayChiTiet
    @so_hoa_don_nhap VARCHAR(30)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT 
        ct.so_hoa_don_nhap, 
        ct.ma_hang, 
        hh.ten_hang_hoa, 
        ct.so_luong, 
        ct.don_gia, 
        ct.giam_gia, 
        ct.thanh_tien
    FROM dbo.chi_tiet_hoa_don_nhap ct
    LEFT JOIN dbo.hang_hoa hh ON ct.ma_hang = hh.ma_hang
    WHERE ct.so_hoa_don_nhap = @so_hoa_don_nhap
    ORDER BY ct.ma_hang;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_HoaDonNhap_LayTheoMa
    @so_hoa_don_nhap VARCHAR(30)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT 
        hdn.so_hoa_don_nhap, 
        hdn.thoi_gian_nhap, 
        hdn.tong_tien, 
        hdn.trang_thai_giao_dich, 
        hdn.ma_nha_cung_cap, 
        ncc.ten_nha_cung_cap, 
        ncc.dien_thoai, 
        ncc.dia_chi, 
        hdn.ma_nhan_vien, 
        nv.ten_nhan_vien
    FROM dbo.hoa_don_nhap hdn
    LEFT JOIN dbo.nha_cung_cap ncc ON hdn.ma_nha_cung_cap = ncc.ma_nha_cung_cap
    LEFT JOIN dbo.nhan_vien nv ON hdn.ma_nhan_vien = nv.ma_nhan_vien
    WHERE hdn.so_hoa_don_nhap = @so_hoa_don_nhap;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_HoaDonNhap_Them
    @so_hoa_don_nhap VARCHAR(30),
    @thoi_gian_nhap DATETIME,
    @tong_tien DECIMAL(18,2),
    @ma_nha_cung_cap VARCHAR(20),
    @ma_nhan_vien VARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO dbo.hoa_don_nhap (so_hoa_don_nhap, thoi_gian_nhap, tong_tien, trang_thai_giao_dich, ma_nha_cung_cap, ma_nhan_vien)
    VALUES (@so_hoa_don_nhap, @thoi_gian_nhap, @tong_tien, N'HoanThanh', @ma_nha_cung_cap, @ma_nhan_vien);
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_ChiTietHoaDonNhap_Them
    @so_hoa_don_nhap VARCHAR(30),
    @ma_hang VARCHAR(20),
    @so_luong INT,
    @don_gia DECIMAL(18,2),
    @giam_gia DECIMAL(5,2),
    @thanh_tien DECIMAL(18,2)
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO dbo.chi_tiet_hoa_don_nhap (so_hoa_don_nhap, ma_hang, so_luong, don_gia, giam_gia, thanh_tien)
    VALUES (@so_hoa_don_nhap, @ma_hang, @so_luong, @don_gia, @giam_gia, @thanh_tien);

    UPDATE dbo.hang_hoa 
    SET so_luong = so_luong + @so_luong, 
        don_gia_nhap = @don_gia, 
        don_gia_ban = CEILING((@don_gia * 1.10) / 1000.0) * 1000
    WHERE ma_hang = @ma_hang;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_BaoHanh_LayTatCa
    @trang_thai_xoa BIT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT 
        pbh.ma_phieu_bao_hanh,
        pbh.so_hoa_don_ban,
        pbh.ma_hang,
        hh.ten_hang_hoa,
        pbh.ma_khach,
        kh.ten_khach,
        kh.dien_thoai AS dien_thoai_khach,
        pbh.ma_nhan_vien,
        nv.ten_nhan_vien,
        pbh.ngay_tiep_nhan,
        pbh.ngay_hen_tra,
        pbh.ngay_tra_thuc_te,
        pbh.mo_ta_loi,
        pbh.bien_phap_xu_ly,
        pbh.chi_phi,
        pbh.trang_thai,
        pbh.ghi_chu,
        pbh.trang_thai_xoa,
        hdb.thoi_gian_ban,
        hdb.trang_thai_giao_dich AS trang_thai_hoa_don_ban,
        hh.thoi_gian_bao_hanh,
        CASE 
            WHEN ISNULL(hh.thoi_gian_bao_hanh, 0) <= 0 THEN NULL
            ELSE DATEADD(MONTH, hh.thoi_gian_bao_hanh, hdb.thoi_gian_ban)
        END AS han_bao_hanh,
        CASE 
            WHEN ISNULL(hh.thoi_gian_bao_hanh, 0) <= 0 THEN 0
            WHEN pbh.ngay_tiep_nhan <= DATEADD(MONTH, hh.thoi_gian_bao_hanh, hdb.thoi_gian_ban) THEN 1 
            ELSE 0 
        END AS con_han_bao_hanh
    FROM dbo.phieu_bao_hanh pbh
    LEFT JOIN dbo.hoa_don_ban hdb ON pbh.so_hoa_don_ban = hdb.so_hoa_don_ban
    LEFT JOIN dbo.hang_hoa hh ON pbh.ma_hang = hh.ma_hang
    LEFT JOIN dbo.khach_hang kh ON pbh.ma_khach = kh.ma_khach
    LEFT JOIN dbo.nhan_vien nv ON pbh.ma_nhan_vien = nv.ma_nhan_vien
    WHERE pbh.trang_thai_xoa = @trang_thai_xoa
    ORDER BY pbh.ngay_tiep_nhan DESC;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_BaoHanh_LayTheoMa
    @ma_phieu VARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT 
        pbh.ma_phieu_bao_hanh,
        pbh.so_hoa_don_ban,
        pbh.ma_hang,
        hh.ten_hang_hoa,
        pbh.ma_khach,
        kh.ten_khach,
        kh.dien_thoai AS dien_thoai_khach,
        pbh.ma_nhan_vien,
        nv.ten_nhan_vien,
        pbh.ngay_tiep_nhan,
        pbh.ngay_hen_tra,
        pbh.ngay_tra_thuc_te,
        pbh.mo_ta_loi,
        pbh.bien_phap_xu_ly,
        pbh.chi_phi,
        pbh.trang_thai,
        pbh.ghi_chu,
        pbh.trang_thai_xoa,
        hdb.thoi_gian_ban,
        hdb.trang_thai_giao_dich AS trang_thai_hoa_don_ban,
        hh.thoi_gian_bao_hanh,
        CASE 
            WHEN ISNULL(hh.thoi_gian_bao_hanh, 0) <= 0 THEN NULL
            ELSE DATEADD(MONTH, hh.thoi_gian_bao_hanh, hdb.thoi_gian_ban)
        END AS han_bao_hanh,
        CASE 
            WHEN ISNULL(hh.thoi_gian_bao_hanh, 0) <= 0 THEN 0
            WHEN pbh.ngay_tiep_nhan <= DATEADD(MONTH, hh.thoi_gian_bao_hanh, hdb.thoi_gian_ban) THEN 1 
            ELSE 0 
        END AS con_han_bao_hanh
    FROM dbo.phieu_bao_hanh pbh
    LEFT JOIN dbo.hoa_don_ban hdb ON pbh.so_hoa_don_ban = hdb.so_hoa_don_ban
    LEFT JOIN dbo.hang_hoa hh ON pbh.ma_hang = hh.ma_hang
    LEFT JOIN dbo.khach_hang kh ON pbh.ma_khach = kh.ma_khach
    LEFT JOIN dbo.nhan_vien nv ON pbh.ma_nhan_vien = nv.ma_nhan_vien
    WHERE pbh.ma_phieu_bao_hanh = @ma_phieu;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_BaoHanh_LayDanhSachHangHoaTheoHoaDon
    @so_hoa_don_ban VARCHAR(30)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT 
        ct.ma_hang,
        hh.ten_hang_hoa,
        hh.thoi_gian_bao_hanh,
        hdb.ma_khach,
        kh.ten_khach,
        kh.dien_thoai AS dien_thoai_khach,
        hdb.thoi_gian_ban,
        CASE 
            WHEN ISNULL(hh.thoi_gian_bao_hanh, 0) <= 0 THEN NULL
            ELSE DATEADD(MONTH, hh.thoi_gian_bao_hanh, hdb.thoi_gian_ban)
        END AS han_bao_hanh,
        CASE 
            WHEN ISNULL(hh.thoi_gian_bao_hanh, 0) <= 0 THEN 0
            WHEN SYSDATETIME() <= DATEADD(MONTH, hh.thoi_gian_bao_hanh, hdb.thoi_gian_ban) THEN 1 
            ELSE 0 
        END AS con_han_bao_hanh
    FROM dbo.chi_tiet_hoa_don_ban ct
    INNER JOIN dbo.hoa_don_ban hdb ON ct.so_hoa_don_ban = hdb.so_hoa_don_ban
    INNER JOIN dbo.hang_hoa hh ON ct.ma_hang = hh.ma_hang
    INNER JOIN dbo.khach_hang kh ON hdb.ma_khach = kh.ma_khach
    WHERE ct.so_hoa_don_ban = @so_hoa_don_ban AND hdb.trang_thai_giao_dich = N'HoanThanh'
    ORDER BY ct.ma_hang;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_BaoHanh_LayDanhSachHoaDonHopLe
AS
BEGIN
    SET NOCOUNT ON;
    SELECT 
        hdb.so_hoa_don_ban,
        hdb.thoi_gian_ban,
        hdb.ma_khach,
        kh.ten_khach,
        kh.dien_thoai
    FROM dbo.hoa_don_ban hdb
    INNER JOIN dbo.khach_hang kh ON hdb.ma_khach = kh.ma_khach
    WHERE hdb.trang_thai_giao_dich = N'HoanThanh'
    ORDER BY hdb.thoi_gian_ban DESC;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_BaoHanh_Them
    @ma_phieu VARCHAR(20),
    @so_hdb VARCHAR(30),
    @ma_hang VARCHAR(20),
    @ma_khach VARCHAR(20),
    @ma_nv VARCHAR(20),
    @ngay_tiep_nhan DATE,
    @ngay_hen_tra DATE = NULL,
    @ngay_tra_thuc_te DATE = NULL,
    @mo_ta_loi NVARCHAR(255) = NULL,
    @bien_phap_xu_ly NVARCHAR(255) = NULL,
    @chi_phi DECIMAL(18,2) = 0,
    @trang_thai NVARCHAR(50) = N'TiepNhan',
    @ghi_chu NVARCHAR(MAX) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO dbo.phieu_bao_hanh 
    (ma_phieu_bao_hanh, so_hoa_don_ban, ma_hang, ma_khach, ma_nhan_vien, ngay_tiep_nhan, ngay_hen_tra, ngay_tra_thuc_te, mo_ta_loi, bien_phap_xu_ly, chi_phi, trang_thai, ghi_chu, trang_thai_xoa)
    VALUES 
    (@ma_phieu, @so_hdb, @ma_hang, @ma_khach, @ma_nv, @ngay_tiep_nhan, @ngay_hen_tra, @ngay_tra_thuc_te, ISNULL(@mo_ta_loi, N''), @bien_phap_xu_ly, @chi_phi, ISNULL(@trang_thai, N'TiepNhan'), @ghi_chu, 0);
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_BaoHanh_Sua
    @ma_phieu VARCHAR(20),
    @so_hdb VARCHAR(30),
    @ma_hang VARCHAR(20),
    @ma_khach VARCHAR(20),
    @ma_nv VARCHAR(20),
    @ngay_hen_tra DATE = NULL,
    @ngay_tra_thuc_te DATE = NULL,
    @mo_ta_loi NVARCHAR(255) = NULL,
    @bien_phap_xu_ly NVARCHAR(255) = NULL,
    @chi_phi DECIMAL(18,2) = 0,
    @trang_thai NVARCHAR(50) = N'TiepNhan',
    @ghi_chu NVARCHAR(MAX) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @ngayTraThucTeCu DATE = @ngay_tra_thuc_te;
    IF @trang_thai = N'DaTra' AND @ngayTraThucTeCu IS NULL
        SET @ngayTraThucTeCu = CAST(GETDATE() AS DATE);

    UPDATE dbo.phieu_bao_hanh 
    SET 
        so_hoa_don_ban = @so_hdb,
        ma_hang = @ma_hang,
        ma_khach = @ma_khach,
        ma_nhan_vien = @ma_nv,
        ngay_hen_tra = @ngay_hen_tra,
        ngay_tra_thuc_te = @ngayTraThucTeCu,
        mo_ta_loi = ISNULL(@mo_ta_loi, N''),
        bien_phap_xu_ly = @bien_phap_xu_ly,
        chi_phi = @chi_phi,
        trang_thai = ISNULL(@trang_thai, N'TiepNhan'),
        ghi_chu = @ghi_chu
    WHERE ma_phieu_bao_hanh = @ma_phieu;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_BaoHanh_XoaMem
    @ma_phieu VARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE dbo.phieu_bao_hanh 
    SET trang_thai_xoa = 1 
    WHERE ma_phieu_bao_hanh = @ma_phieu;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_BaoHanh_KhoiPhuc
    @ma_phieu VARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE dbo.phieu_bao_hanh 
    SET trang_thai_xoa = 0 
    WHERE ma_phieu_bao_hanh = @ma_phieu;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_BaoHanh_TimKiem
    @trang_thai_xoa BIT,
    @tu_khoa NVARCHAR(100) = NULL,
    @trang_thai NVARCHAR(50) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @tu_khoa_like NVARCHAR(105) = '%' + ISNULL(RTRIM(LTRIM(@tu_khoa)), '') + '%';
    SELECT 
        pbh.ma_phieu_bao_hanh,
        pbh.so_hoa_don_ban,
        pbh.ma_hang,
        hh.ten_hang_hoa,
        pbh.ma_khach,
        kh.ten_khach,
        kh.dien_thoai AS dien_thoai_khach,
        pbh.ma_nhan_vien,
        nv.ten_nhan_vien,
        pbh.ngay_tiep_nhan,
        pbh.ngay_hen_tra,
        pbh.ngay_tra_thuc_te,
        pbh.mo_ta_loi,
        pbh.bien_phap_xu_ly,
        pbh.chi_phi,
        pbh.trang_thai,
        pbh.ghi_chu,
        pbh.trang_thai_xoa,
        hdb.thoi_gian_ban,
        hdb.trang_thai_giao_dich AS trang_thai_hoa_don_ban,
        hh.thoi_gian_bao_hanh,
        CASE 
            WHEN ISNULL(hh.thoi_gian_bao_hanh, 0) <= 0 THEN NULL
            ELSE DATEADD(MONTH, hh.thoi_gian_bao_hanh, hdb.thoi_gian_ban)
        END AS han_bao_hanh,
        CASE 
            WHEN ISNULL(hh.thoi_gian_bao_hanh, 0) <= 0 THEN 0
            WHEN pbh.ngay_tiep_nhan <= DATEADD(MONTH, hh.thoi_gian_bao_hanh, hdb.thoi_gian_ban) THEN 1 
            ELSE 0 
        END AS con_han_bao_hanh
    FROM dbo.phieu_bao_hanh pbh
    LEFT JOIN dbo.hoa_don_ban hdb ON pbh.so_hoa_don_ban = hdb.so_hoa_don_ban
    LEFT JOIN dbo.hang_hoa hh ON pbh.ma_hang = hh.ma_hang
    LEFT JOIN dbo.khach_hang kh ON pbh.ma_khach = kh.ma_khach
    LEFT JOIN dbo.nhan_vien nv ON pbh.ma_nhan_vien = nv.ma_nhan_vien
    WHERE pbh.trang_thai_xoa = @trang_thai_xoa
      AND (ISNULL(@tu_khoa, '') = '' OR pbh.ma_phieu_bao_hanh LIKE @tu_khoa_like 
           OR pbh.so_hoa_don_ban LIKE @tu_khoa_like 
           OR kh.ten_khach LIKE @tu_khoa_like 
           OR kh.dien_thoai LIKE @tu_khoa_like 
           OR hh.ten_hang_hoa LIKE @tu_khoa_like)
      AND (ISNULL(@trang_thai, '') = '' OR pbh.trang_thai = @trang_thai)
    ORDER BY pbh.ngay_tiep_nhan DESC;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_BaoHanh_LayTrangThaiHoaDonBan
    @so_hoa_don_ban VARCHAR(30)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT trang_thai_giao_dich 
    FROM dbo.hoa_don_ban 
    WHERE so_hoa_don_ban = @so_hoa_don_ban;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_TimKiem_HangHoa
    @tu_khoa NVARCHAR(200) = NULL,
    @ma_loai VARCHAR(20) = NULL,
    @ma_kich_thuoc VARCHAR(20) = NULL,
    @ma_hinh_dang VARCHAR(20) = NULL,
    @ma_chat_lieu VARCHAR(20) = NULL,
    @ma_nuoc_san_xuat VARCHAR(20) = NULL,
    @ma_mau VARCHAR(20) = NULL,
    @ma_nha_san_xuat VARCHAR(20) = NULL,
    @ma_cong_dung VARCHAR(20) = NULL,
    @ma_dac_diem VARCHAR(20) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SELECT 
        h.ma_hang, 
        h.ten_hang_hoa, 
        h.so_luong, 
        h.don_gia_nhap, 
        h.don_gia_ban, 
        h.thoi_gian_bao_hanh, 
        h.anh, 
        h.ghi_chu,
        l.ten_loai,
        kt.ten_kich_thuoc,
        hd.ten_hinh_dang,
        cl.ten_chat_lieu,
        nsx.ten_nuoc_san_xuat,
        m.ten_mau,
        nhasx.ten_nha_san_xuat,
        cd.ten_cong_dung,
        dd.ten_dac_diem
    FROM dbo.hang_hoa h
    LEFT JOIN dbo.loai l ON h.ma_loai = l.ma_loai
    LEFT JOIN dbo.kich_thuoc kt ON h.ma_kich_thuoc = kt.ma_kich_thuoc
    LEFT JOIN dbo.hinh_dang hd ON h.ma_hinh_dang = hd.ma_hinh_dang
    LEFT JOIN dbo.chat_lieu cl ON h.ma_chat_lieu = cl.ma_chat_lieu
    LEFT JOIN dbo.nuoc_san_xuat nsx ON h.ma_nuoc_san_xuat = nsx.ma_nuoc_san_xuat
    LEFT JOIN dbo.mau_sac m ON h.ma_mau = m.ma_mau
    LEFT JOIN dbo.nha_san_xuat nhasx ON h.ma_nha_san_xuat = nhasx.ma_nha_san_xuat
    LEFT JOIN dbo.cong_dung cd ON h.ma_cong_dung = cd.ma_cong_dung
    LEFT JOIN dbo.dac_diem dd ON h.ma_dac_diem = dd.ma_dac_diem
    WHERE h.trang_thai_xoa = 0
      AND (@tu_khoa IS NULL OR @tu_khoa = '' OR h.ma_hang LIKE '%' + @tu_khoa + '%' OR h.ten_hang_hoa LIKE '%' + @tu_khoa + '%')
      AND (@ma_loai IS NULL OR @ma_loai = '' OR h.ma_loai = @ma_loai)
      AND (@ma_kich_thuoc IS NULL OR @ma_kich_thuoc = '' OR h.ma_kich_thuoc = @ma_kich_thuoc)
      AND (@ma_hinh_dang IS NULL OR @ma_hinh_dang = '' OR h.ma_hinh_dang = @ma_hinh_dang)
      AND (@ma_chat_lieu IS NULL OR @ma_chat_lieu = '' OR h.ma_chat_lieu = @ma_chat_lieu)
      AND (@ma_nuoc_san_xuat IS NULL OR @ma_nuoc_san_xuat = '' OR h.ma_nuoc_san_xuat = @ma_nuoc_san_xuat)
      AND (@ma_mau IS NULL OR @ma_mau = '' OR h.ma_mau = @ma_mau)
      AND (@ma_nha_san_xuat IS NULL OR @ma_nha_san_xuat = '' OR h.ma_nha_san_xuat = @ma_nha_san_xuat)
      AND (@ma_cong_dung IS NULL OR @ma_cong_dung = '' OR h.ma_cong_dung = @ma_cong_dung)
      AND (@ma_dac_diem IS NULL OR @ma_dac_diem = '' OR h.ma_dac_diem = @ma_dac_diem)
    ORDER BY h.ma_hang ASC;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_TimKiem_HoaDonNhap
    @tu_ngay DATE,
    @den_ngay DATE,
    @ma_nhan_vien VARCHAR(20) = NULL,
    @ma_nha_cung_cap VARCHAR(20) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SELECT 
        hd.so_hoa_don_nhap, 
        hd.thoi_gian_nhap, 
        ncc.ten_nha_cung_cap, 
        nv.ten_nhan_vien, 
        hd.tong_tien, 
        hd.trang_thai_giao_dich
    FROM dbo.hoa_don_nhap hd
    INNER JOIN dbo.nha_cung_cap ncc ON hd.ma_nha_cung_cap = ncc.ma_nha_cung_cap
    INNER JOIN dbo.nhan_vien nv ON hd.ma_nhan_vien = nv.ma_nhan_vien
    WHERE CAST(hd.thoi_gian_nhap AS DATE) BETWEEN @tu_ngay AND @den_ngay
      AND (@ma_nhan_vien IS NULL OR @ma_nhan_vien = '' OR hd.ma_nhan_vien = @ma_nhan_vien)
      AND (@ma_nha_cung_cap IS NULL OR @ma_nha_cung_cap = '' OR hd.ma_nha_cung_cap = @ma_nha_cung_cap)
    ORDER BY hd.thoi_gian_nhap DESC;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_TimKiem_HoaDonBan
    @tu_ngay DATE,
    @den_ngay DATE,
    @ma_nhan_vien VARCHAR(20) = NULL,
    @ma_khach VARCHAR(20) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SELECT 
        hd.so_hoa_don_ban, 
        hd.thoi_gian_ban, 
        kh.ten_khach, 
        kh.dien_thoai,
        nv.ten_nhan_vien, 
        hd.tong_tien, 
        hd.trang_thai_giao_dich
    FROM dbo.hoa_don_ban hd
    INNER JOIN dbo.khach_hang kh ON hd.ma_khach = kh.ma_khach
    INNER JOIN dbo.nhan_vien nv ON hd.ma_nhan_vien = nv.ma_nhan_vien
    WHERE CAST(hd.thoi_gian_ban AS DATE) BETWEEN @tu_ngay AND @den_ngay
      AND (@ma_nhan_vien IS NULL OR @ma_nhan_vien = '' OR hd.ma_nhan_vien = @ma_nhan_vien)
      AND (@ma_khach IS NULL OR @ma_khach = '' OR hd.ma_khach = @ma_khach)
    ORDER BY hd.thoi_gian_ban DESC;
END;
GO
