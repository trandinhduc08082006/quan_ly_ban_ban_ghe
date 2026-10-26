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
2. Mở file [database/database.sql](database/database.sql) và thực thi (`Execute`) để tạo cơ sở dữ liệu và các bảng.
3. (Tùy chọn) Mở file [database/test_data.sql](database/test_data.sql) và thực thi để nạp dữ liệu mẫu thử nghiệm.

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
