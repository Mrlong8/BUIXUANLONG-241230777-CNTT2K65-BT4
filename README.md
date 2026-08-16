# BÀI 4 - HỆ THỐNG QUẢN LÝ ĐÀO TẠO DEVMASTER

## 1. Giới thiệu

Đây là dự án cuối kỳ môn lập trình C# với đề tài:

**Hệ thống quản lý đào tạo DevMaster**

Ứng dụng được xây dựng dưới dạng Console Application bằng C#, nhằm quản lý hoạt động đào tạo của trung tâm bao gồm:

- Quản lý khóa học
- Quản lý lớp học
- Quản lý học viên
- Đăng ký khóa học
- Chăm sóc học viên
- Báo cáo và thống kê

Dự án áp dụng kiến thức lập trình hướng đối tượng, xử lý file JSON/CSV, LINQ, phân chia tầng và xử lý ngoại lệ.

---

## 2. Mục tiêu

Mục tiêu của dự án:

- Áp dụng kiến thức C# vào một bài toán thực tế.
- Sử dụng lập trình hướng đối tượng.
- Biết cách tổ chức project theo kiến trúc nhiều tầng.
- Làm việc với dữ liệu JSON và CSV.
- Sử dụng LINQ để tìm kiếm, lọc, sắp xếp và thống kê.
- Xử lý lỗi trong quá trình chạy chương trình.
- Xây dựng chương trình có khả năng mở rộng.
- Chuẩn bị nền tảng để học ASP.NET Core MVC và ASP.NET Core Web API.

---

## 3. Công nghệ sử dụng

- C#
- .NET 10
- Console Application
- LINQ
- System.Text.Json
- CSV
- Git / GitHub
- Visual Studio

---

# 4. Các phân hệ của hệ thống

## 4.1. Quản lý khóa học

### Thông tin

Mỗi khóa học gồm:

- Mã khóa học
- Tên khóa học
- Học phí
- Thời lượng
- Mô tả
- Trạng thái

### Chức năng

- [x] Thêm khóa học
- [x] Sửa khóa học
- [x] Xóa khóa học
- [x] Tìm kiếm khóa học
- [x] Sắp xếp khóa học
- [x] Lọc theo trạng thái
- [x] Thống kê học phí

---

## 4.2. Quản lý lớp học

### Thông tin

Mỗi lớp học gồm:

- Mã lớp
- Tên lớp
- Khóa học
- Ngày khai giảng
- Lịch học
- Sĩ số tối đa
- Trạng thái

### Chức năng

- [x] Tạo lớp
- [x] Cập nhật lớp
- [x] Kiểm tra sĩ số
- [x] Hiển thị lớp sắp khai giảng
- [x] Hiển thị lớp đang học
- [x] Đóng lớp
- [x] Hủy lớp

---

## 4.3. Quản lý học viên

### Thông tin

Mỗi học viên gồm:

- Mã học viên
- Họ tên
- Ngày sinh
- Điện thoại
- Email
- Địa chỉ
- Ngày đăng ký

### Chức năng

- [x] Thêm học viên
- [x] Sửa học viên
- [x] Xóa học viên
- [x] Kiểm tra trùng số điện thoại
- [x] Tìm theo tên
- [x] Tìm theo số điện thoại
- [x] Tìm theo email
- [x] Import từ CSV
- [x] Export sang CSV
- [x] Lưu dữ liệu JSON

---

## 4.4. Đăng ký khóa học

### Thông tin

Mỗi đăng ký gồm:

- Mã đăng ký
- Học viên
- Lớp học
- Ngày đăng ký
- Học phí
- Số tiền đã đóng
- Trạng thái thanh toán

### Chức năng

- [x] Đăng ký học
- [x] Kiểm tra lớp còn chỗ
- [x] Kiểm tra đăng ký trùng lớp
- [x] Tính số tiền còn thiếu
- [x] Ghi nhận thanh toán
- [x] Hủy đăng ký
- [x] Thống kê công nợ

---

## 4.5. Chăm sóc học viên

### Thông tin

Mỗi lịch sử chăm sóc gồm:

- Mã chăm sóc
- Học viên
- Ngày chăm sóc
- Kênh liên hệ
- Nội dung
- Kết quả
- Ngày hẹn tiếp theo

### Chức năng

- [ ] Ghi lịch sử chăm sóc
- [ ] Hiển thị lịch sử theo học viên
- [ ] Hiển thị lịch hẹn hôm nay
- [ ] Hiển thị lịch hẹn quá hạn
- [ ] Thống kê kết quả chăm sóc

---

# 5. Báo cáo và thống kê bằng LINQ

Hệ thống dự kiến hỗ trợ các báo cáo:

- [ ] Số học viên theo khóa học
- [ ] Số học viên theo lớp
- [ ] Danh sách lớp sắp khai giảng
- [ ] Danh sách học viên còn nợ học phí
- [ ] Tổng doanh thu
- [ ] Doanh thu theo tháng
- [ ] Khóa học có nhiều học viên nhất
- [ ] Học viên có lịch hẹn hôm nay
- [ ] Học viên lâu ngày chưa được chăm sóc
- [ ] Tỷ lệ học viên đã thanh toán đủ

---

# 6. Kiến trúc dự án

Dự án được tổ chức theo kiến trúc nhiều tầng:

```text
DevmasterTrainingManagement
│
├── Domain
├── Application
├── Infrastructure
├── ConsoleUI
└── Tests