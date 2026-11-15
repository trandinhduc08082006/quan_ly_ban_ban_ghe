# Quản Lý Bán Bàn Ghế

---

## 👥 Thông Tin Bài Tập Lớn

* **Giảng viên hướng dẫn**: Cao Thị Luyên
* **Học phần**: Lập trình trực quan

| STT | Họ và Tên | Mã Sinh Viên | Lớp - Khóa - Trường |
|:---:|:---|:---:|:---|
| 1 | **Trần Đình Đức** | 241230712 | Công nghệ thông tin 4 - K65 - UTC |
| 2 | **Tô Đình Khoát** | 241230764 | Công nghệ thông tin 4 - K65 - UTC |
| 3 | **Phùng Trung Hiếu** | 241230727 | Công nghệ thông tin 4 - K65 - UTC |
| 4 | **Phạm Chí Kiên** | 241230767 | Công nghệ thông tin 4 - K65 - UTC |

---

## 🚀 Công Nghệ & Kiến Trúc

* **Nền tảng**: C# Windows Forms (.NET Framework 4.8).
* **Cơ sở dữ liệu**: Microsoft SQL Server (100% Stored Procedures qua ADO.NET thuần).
* **Báo cáo & In ấn**: Microsoft RDLC ReportViewer (hỗ trợ in và xuất PDF, Excel, Word).
* **Bảo mật**: Mã hóa SHA-256, phân quyền 3 vai trò (`QuanLy`, `BanHang`, `ThuKho`).
* **Kiến trúc 3 lớp (3-Tier)**:
  * `QuanLyBanBanGhe.GUI`: Tầng giao diện người dùng (Presentation Layer).
  * `QuanLyBanBanGhe.BLL`: Tầng xử lý logic nghiệp vụ (Business Logic Layer).
  * `QuanLyBanBanGhe.DAL`: Tầng truy xuất cơ sở dữ liệu (Data Access Layer).
  * `QuanLyBanBanGhe.DTO`: Đối tượng dữ liệu dùng chung giữa các tầng (Data Transfer Objects).

---

## 📌 Các Tính Năng Cốt Lõi

1. **Hệ thống & Phân quyền**: Đăng nhập, đổi mật khẩu, quản lý tài khoản nhân sự và phân quyền 3 vai trò (`QuanLy`, `BanHang`, `ThuKho`).
2. **Quản lý Hàng hóa & Thuộc tính**: Quản lý thông tin, ảnh sản phẩm, tự động tính giá bán niêm yết và hỗ trợ thêm nhanh 9 danh mục thuộc tính.
3. **Nghiệp vụ Bán hàng & Nhập kho**: Lập hóa đơn bán (kiểm tra tồn kho, giảm giá), lập hóa đơn nhập (tính giá bình quân), hỗ trợ hủy giao dịch hoàn kho tự động với giao dịch an toàn.
4. **Quản lý Bảo hành**: Tiếp nhận bảo hành theo số hóa đơn bán, theo dõi tiến độ xử lý và tra cứu thông tin nhanh chóng.
5. **Tìm kiếm & Trải nghiệm (UX)**: Bộ lọc tìm kiếm đa tiêu chí, hỗ trợ phím tắt và đồng bộ trạng thái giao diện trực quan.
6. **Báo cáo & Thống kê**: 4 biểu đồ báo cáo chuyên sâu (Top 10 bán chạy, nhập hàng, bán hàng, nhân viên doanh số thấp), in hóa đơn và phiếu bảo hành qua RDLC.

---

## ⚙️ Yêu Cầu Môi Trường & Cài Đặt

* **Hệ điều hành**: Windows 10 / 11 (x64).
* **Công cụ phát triển**: Visual Studio 2019 / 2022 (đã cài đặt workload *.NET Desktop Development*).
* **Nền tảng**: .NET Framework 4.8.
* **Hệ quản trị CSDL**: Microsoft SQL Server 2016 trở lên (hoặc SQL Server Express) / SSMS.

---

## 🚀 Hướng Dẫn Khởi Chạy

### 🔹 Bước 1: Khởi tạo Cơ sở dữ liệu (SQL Server)
* Mở **SQL Server Management Studio (SSMS)** và kết nối tới SQL Server.
* Mở tệp `database/database.sql` rồi nhấn **Execute (F5)** để tạo CSDL `QuanLyBanBanGhe`, toàn bộ 20 bảng và 84 Stored Procedures.
* *(Khuyên dùng)* Mở tiếp tệp `database/test_data.sql` và nhấn **Execute (F5)** để nạp dữ liệu mẫu.
* *(Dọn dẹp CSDL)* Mở tệp `database/clean_data.sql` và nhấn **Execute (F5)** khi cần xóa toàn bộ dữ liệu mẫu/thử nghiệm để đưa CSDL về trạng thái ban đầu (vẫn bảo toàn nguyên vẹn 2 tài khoản quản trị `admin` và `admin_phu`).

### 🔹 Bước 2: Cấu hình chuỗi kết nối
Mở tệp `QuanLyBanBanGhe.GUI/App.config` và kiểm tra thuộc tính `Data Source`:

```xml
<connectionStrings>
    <add name="QuanLyBanBanGheDB" 
         connectionString="Data Source=.\SQLEXPRESS;Initial Catalog=QuanLyBanBanGhe;Integrated Security=True;TrustServerCertificate=True;" 
         providerName="System.Data.SqlClient" />
</connectionStrings>
```
> **Lưu ý:** Đổi `.\SQLEXPRESS` thành `.` hoặc `(local)` tùy thuộc vào SQL Server Instance trên máy của bạn.

### 🔹 Bước 3: Biên dịch & Chạy ứng dụng
* Mở solution bằng Visual Studio:
  * **Visual Studio 2019 trở xuống** (hoặc VS 2022 dưới v17.10): Bắt buộc mở tệp `quan_ly_ban_ban_ghe.sln`.
  * **Visual Studio 2022 (từ v17.10 trở lên)**: Có thể mở linh hoạt bằng một trong hai tệp `quan_ly_ban_ban_ghe.sln` hoặc `quan_ly_ban_ban_ghe.slnx`.
* Chuột phải vào `QuanLyBanBanGhe.GUI` chọn **Set as Startup Project**.
* Nhấn **F5** (hoặc nút **Start**) để khởi chạy phần mềm.

---

## 🔑 Danh Sách Tài Khoản Đăng Nhập

### 🔹 1. Quản Lý (`QuanLy`)

| STT | Tên Đăng Nhập | Mật Khẩu | Ghi Chú |
|:---:|:---|:---|:---|
| 1 | `admin` | `Admin@123456` | Mặc định trong `database.sql` |
| 2 | `admin_phu` | `Admin@123456` | Mặc định trong `database.sql` |
| 3 | `trandinhduc` | `Duc@123456` | Trong `test_data.sql` |

### 🔹 2. Bán Hàng (`BanHang`)

| STT | Tên Đăng Nhập | Mật Khẩu | Tên Đăng Nhập | Mật Khẩu |
|:---:|:---|:---|:---|:---|
| 1 | `levancuong` | `Cuong@123456` | `dominhquan` | `Quan@123456` |
| 2 | `hoangthidung` | `Dung@123456` | `ngobaongoc` | `Ngoc@123456` |
| 3 | `phamhoanglong` | `Long@123456` | `buiquochuy` | `Huy@123456` |
| 4 | `vuthimai` | `Mai@123456` | `dinhthihuong` | `Huong@123456` |
| 5 | `nguyenhuuthang` | `Thang@123456` | `phanvannam` | `Nam@123456` |

### 🔹 3. Thủ Kho (`ThuKho`)

| STT | Tên Đăng Nhập | Mật Khẩu | Tên Đăng Nhập | Mật Khẩu |
|:---:|:---|:---|:---|:---|
| 1 | `duongdinhtrong` | `Trong@123456` | `truongcongdinh` | `Dinh@123456` |
| 2 | `havantuan` | `Tuan@123456` | `lamvanphat` | `Phat@123456` |
| 3 | `luongminhtriet` | `Triet@123456` | `danghuutai` | `Tai@123456` |
| 4 | `tathanhbinh` | `Binh@123456` | `hominhkhang` | `Khang@123456` |
| 5 | `caovanson` | `Son@123456` | `vothanhdat` | `Dat@123456` |
