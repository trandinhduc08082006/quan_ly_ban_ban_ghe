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

## 🚀 Công Nghệ & Kiến Trúc Sử Dụng

* **Nền tảng**: C# Windows Forms (.NET Framework 4.8).
* **Cơ sở dữ liệu**: Microsoft SQL Server (20 bảng chuẩn hóa `snake_case`).
* **Truy xuất dữ liệu**: **100% Stored Procedures trên SQL Server** qua ADO.NET thuần (`DatabaseHelper`), sử dụng `SqlParameter` (ngăn chặn triệt để SQL Injection) và `SqlTransaction` cho giao dịch nhiều bước.
* **Báo cáo & In ấn**: Microsoft Reporting Services (**RDLC ReportViewer**), hỗ trợ xem trước, in ấn và xuất file trực tiếp sang PDF, Excel, Word.
* **Bảo mật**: Mã hóa mật khẩu một chiều SHA-256, phân quyền 3 vai trò độc lập, Regex kiểm tra mật khẩu mạnh.
* **Mô hình kiến trúc 3 lớp (3-Tier)**:
  * `QuanLyBanBanGhe.GUI`: Tầng giao diện người dùng (Presentation Layer).
  * `QuanLyBanBanGhe.BLL`: Tầng xử lý logic nghiệp vụ & tính toán (Business Logic Layer).
  * `QuanLyBanBanGhe.DAL`: Tầng giao tiếp cơ sở dữ liệu (Data Access Layer).
  * `QuanLyBanBanGhe.DTO`: Tầng đối tượng truyền dữ liệu (Data Transfer Objects).

---

## 📌 Các Tính Năng Cốt Lõi

1. **Hệ thống & Phân quyền người dùng**:
   * Đăng nhập, đăng xuất, đổi mật khẩu, phân quyền 3 vai trò: **Quản lý (`QuanLy`)**, **Bán hàng (`BanHang`)**, **Thủ kho (`ThuKho`)**.
   * Quản lý tài khoản nhân sự: Khóa/mở tài khoản, reset mật khẩu về mặc định, bảo vệ tài khoản quản trị hệ thống.

2. **Quản lý Hàng hóa & 9 Danh mục thuộc tính**:
   * Quản lý thông tin hàng hóa, ảnh sản phẩm (đọc qua Stream chống khóa file GDI+).
   * Tự động tính giá bán niêm yết: $Giá\ bán = \lceil (Giá\ nhập \times 1.10) / 1000 \rceil \times 1000$ (làm tròn lên hàng nghìn).
   * Tích hợp nút `[+]` thêm nhanh ngay trên form cho 9 danh mục thuộc tính (Loại, Kích thước, Chất liệu, Màu sắc, Nước sản xuất, Hình dáng, Nhà sản xuất, Công dụng, Đặc điểm) với ràng buộc tự động theo loại bàn ghế.

3. **Nghiệp vụ Bán hàng & Nhập kho**:
   * **Bán hàng**: Kiểm tra tồn kho, gợi ý & kiểm tra chéo khách hàng 2 chiều (SĐT - Tên - Địa chỉ), thêm nhanh khách hàng mới, chặn sai lệch mức giảm giá cho cùng mặt hàng.
   * **Nhập hàng**: Quản lý nhập kho từ nhà cung cấp, hỗ trợ gộp dòng theo đơn giá bình quân gia quyền làm tròn trần hàng nghìn.
   * **Hủy giao dịch an toàn**: Hỗ trợ hủy hóa đơn hoàn kho tự động với `SqlTransaction`.

4. **Quản lý Bảo hành sản phẩm**:
   * Tiếp nhận bảo hành liên kết chặt chẽ với số hóa đơn bán và thời hạn bảo hành của sản phẩm.
   * Chuyển đổi trạng thái chuẩn theo máy trạng thái (State Machine): *Tiếp nhận* $\rightarrow$ *Đang xử lý* $\rightarrow$ *Đã sửa xong* $\rightarrow$ *Đã trả khách* / *Từ chối*.
   * Tìm kiếm nhanh thông minh có chữ gợi ý placeholder (`Số HDB - Tên khách - SĐT`).

5. **Tìm kiếm đa năng & Trải nghiệm giao diện (UX)**:
   * Tích hợp bộ lọc tìm kiếm đa tiêu chí trực tiếp trên các tab Hàng hóa, Khách hàng, Nhà cung cấp (hỗ trợ cả dữ liệu đang hoạt động và đã xóa mềm).
   * Tự động bật/tắt nút *Bỏ qua* theo ngữ cảnh dữ liệu, hỗ trợ phím mũi tên bàn phím duyệt dòng tức thì, phím `Esc` đóng nhanh modal.

6. **Báo cáo Thống kê & In ấn RDLC**:
   * Lazy Loading tải mượt mà 4 tab báo cáo:
     1. Top 10 sản phẩm bán chạy nhất theo năm.
     2. Báo cáo nhập hàng theo tháng / quý.
     3. Báo cáo bán hàng theo tháng / quý.
     4. Báo cáo nhân viên có doanh số thấp / bằng 0.
   * In hóa đơn bán hàng, hóa đơn nhập hàng, phiếu bảo hành và các bảng báo cáo thống kê qua RDLC ReportViewer chuẩn xác.

---

## ⚙️ Yêu Cầu Môi Trường & Cài Đặt

* **Hệ điều hành**: Windows 10 / 11 (x64).
* **Công cụ phát triển**: Visual Studio 2019 / 2022 (đã cài đặt workload *.NET Desktop Development*).
* **Nền tảng**: .NET Framework 4.8.
* **Hệ quản trị CSDL**: Microsoft SQL Server 2016 trở lên (hoặc SQL Server Express) / SSMS.

---

## 🚀 Hướng Dẫn Khởi Chạy Dự Án

### 1. Cài đặt Cơ sở dữ liệu
1. Mở **SQL Server Management Studio (SSMS)** và kết nối tới SQL Server của bạn.
2. Mở tệp `database/database.sql` và nhấn **Execute (F5)** để tạo CSDL `QuanLyBanBanGhe`, toàn bộ 20 bảng, các ràng buộc và 2 tài khoản quản trị mặc định.
3. *(Khuyên dùng)* Mở tệp `database/test_data.sql` và nhấn **Execute (F5)** để nạp đầy đủ dữ liệu mẫu phong phú cho hàng hóa, khách hàng, nhà cung cấp, nhân viên và các giao dịch mẫu.

### 2. Cấu hình Chuỗi kết nối (Connection String)
Mở tệp `QuanLyBanBanGhe.GUI/App.config`, kiểm tra và điều chỉnh thuộc tính `Data Source` cho khớp với tên SQL Server trên máy:

```xml
<connectionStrings>
    <add name="QuanLyBanBanGheDB" 
         connectionString="Data Source=.;Initial Catalog=QuanLyBanBanGhe;Integrated Security=True;TrustServerCertificate=True;" 
         providerName="System.Data.SqlClient" />
</connectionStrings>
```
*(Nếu dùng SQL Express, hãy đổi `Data Source=.\SQLEXPRESS`)*.

### 3. Biên dịch và Chạy ứng dụng
1. Mở `quan_ly_ban_ban_ghe.sln` bằng Visual Studio.
2. Đặt `QuanLyBanBanGhe.GUI` làm **Set as Startup Project**.
3. Chọn cấu hình **Debug** hoặc **Release** (`Any CPU`).
4. Nhấn **F5** (hoặc nút **Start**) để khởi chạy phần mềm.

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
