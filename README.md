# Quản Lý Bán Bàn Ghế (Furniture Sales Management System)

Dự án bài tập lớn môn **Lập Trình Trực Quan** (Visual Programming). Ứng dụng quản lý cửa hàng kinh doanh bàn ghế / nội thất xây dựng trên nền tảng **C# Windows Forms (.NET Framework 4.8)** với kiến trúc 3 lớp (3-Tier Architecture), cơ sở dữ liệu **Microsoft SQL Server** và tích hợp xuất báo cáo **Microsoft Excel**.

---

## 👥 Nhóm sinh viên thực hiện

| STT | Họ và tên | Mã sinh viên |
|:---:|:---|:---:|
| 1 | Trần Đình Đức | 241230712 |
| 2 | Tô Đình Khoát | 241230764 |
| 3 | Phùng Trung Hiếu | 241230727 |
| 4 | Phạm Chí Kiên | 241230767 |

* **Học phần**: Lập trình trực quan

---

## 📌 Tính năng chính

1. **Hệ thống (System)**:
   - Đăng nhập, đăng xuất, phân quyền người dùng (Quản trị viên / Nhân viên).
   - Đổi mật khẩu, quản lý tài khoản.

2. **Quản lý danh mục (Catalog Management)**:
   - Quản lý sản phẩm bàn ghế (chất liệu, kiểu dáng, màu sắc, kích thước, giá bán, tải/xem hình ảnh,...).
   - Quản lý khách hàng, nhà cung cấp.
   - Quản lý nhân viên.

3. **Nghiệp vụ (Operations)**:
   - Quản lý hóa đơn nhập hàng (nhập kho từ nhà cung cấp).
   - Quản lý hóa đơn bán hàng (bán cho khách hàng, tính tổng tiền, chiết khấu).
   - **Xuất hóa đơn**: Xuất chi tiết hóa đơn bán hàng và hóa đơn nhập hàng trực tiếp ra định dạng Excel (`.xlsx`).

4. **Tìm kiếm & Tra cứu (Search)**:
   - Tra cứu nhanh sản phẩm theo nhiều tiêu chí (tên, loại, khoảng giá).
   - Tra cứu hóa đơn nhập / xuất.

5. **Báo cáo & Thống kê (Reports & Analytics)**:
   - Thống kê doanh thu theo thời gian (ngày, tháng, năm).
   - Báo cáo top 10 sản phẩm bàn ghế bán chạy.
   - Báo cáo doanh số nhân viên kinh doanh.
   - **Xuất báo cáo Excel**: Hỗ trợ kết xuất toàn bộ dữ liệu thống kê, báo cáo ra file Excel hoàn chỉnh và định dạng chuẩn.

---

## 🏗 Kiến trúc giải pháp (Architecture)

Dự án áp dụng mô hình phân lớp rõ ràng:

* **QuanLyBanBanGhe.GUI**: Tầng giao diện người dùng (Windows Forms + kết nối Excel Interop).
* **QuanLyBanBanGhe.BLL**: Tầng xử lý nghiệp vụ (Business Logic Layer).
* **QuanLyBanBanGhe.DAL**: Tầng truy xuất dữ liệu (Data Access Layer - kết nối SQL Server).
* **QuanLyBanBanGhe.DTO**: Tầng đối tượng truyền dữ liệu (Data Transfer Objects).
* **database/**: Chứa các script SQL Server (`database.sql`, `test_data.sql`, `clean_data.sql`).

---

## ⚙️ Yêu cầu môi trường & Cài đặt

* **Hệ điều hành**: Windows 10/11
* **IDE**: Visual Studio 2019 / 2022 (đã cài đặt workload *.NET Desktop Development*)
* **Framework**: .NET Framework 4.8
* **Hệ quản trị CSDL**: Microsoft SQL Server (hoặc SQL Server Express) / SSMS
* **Bộ ứng dụng văn phòng**: **Microsoft Excel** (Excel 2013 / 2016 / 2019 / 2021 hoặc Microsoft 365) để chạy các tính năng xuất báo cáo và hóa đơn ra file Excel (`Microsoft.Office.Interop.Excel`).

---

## 🚀 Hướng dẫn chạy dự án

### 1. Cấu hình Cơ sở dữ liệu
1. Mở **SQL Server Management Studio (SSMS)**.
2. Mở file [database/database.sql](database/database.sql) và thực thi (`Execute`) để tạo cơ sở dữ liệu, các bảng và **tự động khởi tạo sẵn 2 tài khoản Admin mặc định** (`admin` và `admin_phu` - mật khẩu: `Admin@123456`) để có thể đăng nhập ngay.
3. (Tùy chọn) Mở file [database/test_data.sql](database/test_data.sql) và thực thi để nạp dữ liệu mẫu thử nghiệm phong phú (nhân viên, khách hàng, hàng hóa, hóa đơn nhập/bán).
4. (Tùy chọn) Mở file [database/clean_data.sql](database/clean_data.sql) và thực thi khi cần làm sạch/xóa toàn bộ dữ liệu phát sinh để kiểm thử lại từ đầu (script này **tự động bảo lưu lại 2 tài khoản Admin mặc định** để bạn luôn có thể đăng nhập quản trị).

### 2. Cấu hình Connection String
Mở file `QuanLyBanBanGhe.GUI/App.config`, kiểm tra và điều chỉnh chuỗi kết nối cho phù hợp với SQL Server trên máy của bạn:

```xml
<connectionStrings>
    <add name="QuanLyBanBanGheDB" 
         connectionString="Data Source=.\SQLEXPRESS;Initial Catalog=QuanLyBanBanGhe;Integrated Security=True;TrustServerCertificate=True;" 
         providerName="System.Data.SqlClient" />
</connectionStrings>
```

> *Lưu ý:* Nếu bạn dùng SQL Server mặc định (không phải bản Express), hãy sửa `Data Source=.` hoặc `Data Source=localhost`.

### 3. Build & Chạy chương trình
Bạn có thể mở dự án bằng một trong hai file Solution trong thư mục gốc:
* **`quan_ly_ban_ban_ghe.sln`**: Định dạng Solution truyền thống (tương thích cả Visual Studio 2019 và 2022).
* **`quan_ly_ban_ban_ghe.slnx`**: Định dạng Solution XML thế hệ mới (hỗ trợ trên Visual Studio 2022 từ phiên bản v17.10 trở lên).

Các bước chạy:
1. Mở một trong 2 file solution trên bằng Visual Studio.
2. Chọn cấu hình `Debug` hoặc `Release` (Any CPU).
3. Nhấn **F5** (hoặc nút **Start**) để biên dịch và khởi chạy ứng dụng.

### 4. Tài khoản dùng để đăng nhập
Danh sách tài khoản mẫu được phân theo 3 nhóm quyền trên hệ thống (*Lưu ý: 2 tài khoản `admin` và `admin_phu` là tài khoản quản trị mặc định được khởi tạo ngay trong `database.sql` và luôn được giữ lại khi dọn dẹp bằng `clean_data.sql`*):

#### 🔹 Quyền Quản lý (`QuanLy`)
> Toàn quyền hệ thống: quản lý tài khoản, danh mục, phân quyền nhân viên và xem tất cả báo cáo doanh thu/thống kê.
> *(Trong đó `admin` và `admin_phu` là 2 tài khoản Admin mặc định có sẵn ngay khi khởi tạo CSDL)*:

| Tên đăng nhập | Mật khẩu |
|:---|:---|
| `admin` | `Admin@123456` |
| `admin_phu` | `Admin@123456` |
| `trandinhduc` | `Duc@123456` |

#### 🔹 Quyền Nhân viên Bán hàng (`BanHang`)
> Thực hiện các nghiệp vụ: lập hóa đơn bán hàng cho khách hàng, tra cứu thông tin sản phẩm và khách hàng.

| Tên đăng nhập | Mật khẩu | Tên đăng nhập | Mật khẩu |
|:---|:---|:---|:---|
| `levancuong` | `Cuong@123456` | `phamhoanglong` | `Long@123456` |
| `hoangthidung` | `Dung@123456` | `vuthimai` | `Mai@123456` |
| `dominhquan` | `Quan@123456` | `ngobaongoc` | `Ngoc@123456` |
| `buiquochuy` | `Huy@123456` | `dinhthihuong` | `Huong@123456` |
| `nguyenhuuthang` | `Thang@123456` | `phanvannam` | `Nam@123456` |

#### 🔹 Quyền Nhân viên Thủ kho (`ThuKho`)
> Thực hiện các nghiệp vụ: lập hóa đơn nhập hàng từ nhà cung cấp, quản lý kho hàng và thông tin bảo hành.

| Tên đăng nhập | Mật khẩu | Tên đăng nhập | Mật khẩu |
|:---|:---|:---|:---|
| `duongdinhtrong` | `Trong@123456` | `havantuan` | `Tuan@123456` |
| `luongminhtriet` | `Triet@123456` | `tathanhbinh` | `Binh@123456` |
| `caovanson` | `Son@123456` | `truongcongdinh` | `Dinh@123456` |
| `lamvanphat` | `Phat@123456` | `danghuutai` | `Tai@123456` |
| `hominhkhang` | `Khang@123456` | `vothanhdat` | `Dat@123456` |
