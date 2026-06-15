# GUIRentalFutsal - KPLHEBAT

GUIRentalFutsal adalah aplikasi **Windows Forms** berbasis C# untuk sistem penyewaan lapangan futsal. Project ini merupakan pengembangan dari tugas besar sebelumnya yang berbasis backend/service, lalu diadaptasi menjadi aplikasi desktop menggunakan **C# Windows Forms**.

Project ini dibuat untuk memenuhi tugas besar mata kuliah **Konstruksi Perangkat Lunak (CLO4)**.

## Deskripsi Aplikasi

Aplikasi ini digunakan untuk membantu proses penyewaan lapangan futsal, mulai dari pengelolaan data lapangan, pembuatan booking, pengecekan jadwal, pembayaran, hingga laporan.

Pada versi CLO4, aplikasi menggunakan tampilan **Windows Forms**. Logic bisnis diletakkan pada folder `Services`, data disimpan dalam file JSON, dan setiap form mengakses service melalui `AppServices`.

## Teknologi yang Digunakan

| Komponen           | Teknologi          |
| ------------------ | ------------------ |
| Bahasa Pemrograman | C#                 |
| Framework          | .NET 8             |
| GUI                | Windows Forms      |
| Data Storage       | JSON File          |
| IDE                | Visual Studio 2022 |
| Version Control    | Git dan GitHub     |

## Fitur Aplikasi

### 1. Dashboard

Dashboard berada pada `Form1.cs` dan menjadi halaman utama aplikasi.

Fitur dashboard:

* Membuka Form Kelola Lapangan
* Membuka Form Booking
* Membuka Form Cek Jadwal
* Membuka Form Pembayaran
* Membuka Form Laporan
* Keluar dari aplikasi

### 2. Kelola Lapangan

Form kelola lapangan digunakan untuk mengelola data lapangan futsal.

Fitur:

* Menampilkan daftar lapangan dari `fields.json`
* Menambah lapangan
* Mengubah data lapangan
* Menghapus lapangan
* Mengatur status aktif lapangan

Data lapangan diproses melalui:

* `FieldForm`
* `FieldService`
* `JsonDataStore<Field>`
* `Data/fields.json`

### 3. Booking

Form booking digunakan untuk membuat data penyewaan lapangan.

Fitur:

* Memilih lapangan aktif dari data JSON
* Memilih tanggal booking
* Memilih jam mulai booking
* Memilih durasi booking
* Mendukung durasi 1 sampai 6 jam
* Mendukung opsi Full Day
* Menghitung total harga booking
* Menyimpan booking ke `bookings.json`
* Menampilkan daftar booking pada tabel

Data booking diproses melalui:

* `BookingForm`
* `BookingService`
* `ScheduleService`
* `FieldService`
* `JsonDataStore<Booking>`
* `Data/bookings.json`

### 4. Cek Jadwal

Form cek jadwal digunakan untuk mengecek ketersediaan lapangan.

Fitur:

* Memilih lapangan
* Memilih tanggal
* Memilih jam mulai
* Memilih durasi
* Mengecek apakah jadwal tersedia atau penuh
* Menampilkan booking sesuai tanggal dan lapangan
* Mengambil data dari `bookings.json`

Data jadwal diproses melalui:

* `ScheduleForm`
* `ScheduleService`
* `BookingService`
* `FieldService`

### 5. Pembayaran

Form pembayaran digunakan untuk memproses pembayaran booking.

Fitur:

* Menampilkan data booking
* Memproses pembayaran
* Mengubah status booking sesuai state machine
* Memvalidasi jumlah pembayaran

Data pembayaran diproses melalui:

* `PaymentForm`
* `PaymentService`
* `BookingService`
* `BookingStateMachine`

### 6. Laporan

Form laporan digunakan untuk menampilkan ringkasan data booking dan pendapatan.

Fitur:

* Filter periode laporan
* Menampilkan total booking
* Menampilkan booking pending
* Menampilkan booking paid
* Menampilkan booking completed
* Menampilkan booking cancelled
* Menampilkan total pendapatan
* Menampilkan detail booking pada tabel

Data laporan diproses melalui:

* `ReportForm`
* `ReportService`
* `BookingService`
* `FieldService`

## Struktur Project

```text
GuiRentalFutsal/
├── Data/
│   ├── bookings.json
│   └── fields.json
│
├── Models/
│   ├── Booking.cs
│   ├── BookingStatus.cs
│   ├── Field.cs
│   ├── OperationResult.cs
│   ├── Payment.cs
│   └── TimeSlot.cs
│
├── Services/
│   ├── BookingService.cs
│   ├── BookingStateMachine.cs
│   ├── FieldService.cs
│   ├── JsonDataStore.cs
│   ├── PaymentService.cs
│   ├── ReportService.cs
│   ├── ScheduleService.cs
│   └── TimeOnlyConverter.cs
│
├── AppServices.cs
├── Form1.cs
├── FieldForm.cs
├── BookingForm.cs
├── ScheduleForm.cs
├── PaymentForm.cs
├── ReportForm.cs
└── Program.cs
```

## Arsitektur Aplikasi

Project ini menggunakan pemisahan sederhana antara tampilan, logic bisnis, dan penyimpanan data.

```text
Windows Form
↓
AppServices
↓
Service
↓
JsonDataStore
↓
File JSON
```

Penjelasan:

* **Windows Form** digunakan sebagai tampilan aplikasi dan input user.
* **AppServices** digunakan sebagai pusat akses service agar form tidak membuat object service secara manual berulang kali.
* **Services** berisi logic bisnis seperti booking, jadwal, pembayaran, laporan, dan kelola lapangan.
* **Models** berisi representasi data seperti booking, field, payment, dan result.
* **Data JSON** digunakan sebagai penyimpanan lokal aplikasi.

## Data JSON

Project menggunakan file JSON sebagai penyimpanan data lokal.

File data:

```text
Data/fields.json
Data/bookings.json
```

Catatan penting:

Saat aplikasi dijalankan, file JSON yang dipakai biasanya berada di folder output:

```text
bin/Debug/net8.0-windows/Data/
```

Agar file JSON ikut terbawa saat build, atur properties file JSON:

```text
Build Action: Content
Copy to Output Directory: Copy if newer
```

## Teknik Konstruksi yang Digunakan

Beberapa teknik konstruksi perangkat lunak yang digunakan pada project ini:

### 1. Parameterization / Generics

Digunakan pada:

```text
JsonDataStore<T>
OperationResult<T>
```

Tujuannya agar logic penyimpanan dan result dapat digunakan ulang untuk berbagai model.

### 2. Table-driven Construction

Data aplikasi disimpan dalam bentuk tabel sederhana melalui file JSON seperti:

```text
fields.json
bookings.json
```

### 3. Defensive Programming

Digunakan untuk validasi input, seperti:

* Nama tidak boleh kosong
* Nomor HP tidak boleh kosong
* Durasi harus valid
* Jam booking tidak boleh melewati jam operasional
* Lapangan harus aktif
* Jadwal tidak boleh bentrok

### 4. Design by Contract

Service melakukan validasi pre-condition sebelum memproses data.

Contoh:

* Booking hanya bisa dibuat jika lapangan valid
* Pembayaran hanya bisa dilakukan jika status booking sesuai
* Jadwal hanya tersedia jika tidak bentrok

### 5. Automata / State Machine

Digunakan pada `BookingStateMachine` untuk mengatur perubahan status booking.

Contoh status:

* `PendingPayment`
* `Paid`
* `Completed`
* `Cancelled`

### 6. Code Reuse

Logic dari service digunakan ulang oleh banyak form agar tidak terjadi duplikasi kode.

Contoh:

* `BookingService` digunakan oleh Booking, Schedule, Payment, dan Report.
* `FieldService` digunakan oleh Field, Booking, Schedule, dan Report.
* `ScheduleService` digunakan untuk cek ketersediaan jadwal.

## Pembagian Tugas

| Anggota                       | Tanggung Jawab                       |
| ----------------------------- | ------------------------------------ |
| Rajaa Azharul Hanafi          | Dashboard, integrasi backend, Report |
| Faiq Prabaswara Riyana        | Schedule / Cek Jadwal                |
| Arkananta Odysa               | Booking                              |
| Muhammad Fitrah Dafa Zulfikar | Payment / Pembayaran                 |
| Petra Panondang Simangunsong  | Field / Kelola Lapangan              |

## Cara Menjalankan Project

1. Clone repository.
2. Buka project menggunakan Visual Studio 2022.
3. Buka solution `GuiRentalFutsal.slnx`.
4. Pastikan project menggunakan .NET 8.
5. Pastikan file JSON pada folder `Data` memiliki properties:

   * Build Action: `Content`
   * Copy to Output Directory: `Copy if newer`
6. Jalankan aplikasi dengan tombol `Start`.

## Alur Aplikasi

```text
Dashboard
├── Kelola Lapangan
├── Booking
├── Cek Jadwal
├── Pembayaran
└── Laporan
```

## Workflow Git

Setiap anggota mengerjakan fitur pada branch masing-masing.

Contoh branch:

```text
master
├── rajaa-dashboard-integrasi
├── rajaa-integrasi-field-booking-schedule
├── faiq-schedule-form
├── arka-booking-form
├── dafa-payment-form
└── petra-field-form
```

Alur kerja:

```text
Pull dari master
↓
Buat / pindah ke branch fitur
↓
Kerjakan fitur
↓
Build dan test
↓
Commit
↓
Push branch
↓
Pull Request ke master
↓
Resolve conflict jika ada
↓
Merge
```

Contoh commit message:

```bash
git commit -m "connect booking form to json data services"
git commit -m "connect schedule form to booking services"
git commit -m "add report form layout and navigation"
```

## Catatan Pengembangan

* Jangan mengubah file di branch `master` secara langsung untuk fitur besar.
* Setiap form sebaiknya dikerjakan pada branch masing-masing.
* Jika terjadi conflict pada `Form1.cs`, gabungkan navigasi dashboard dari setiap fitur.
* Jangan menggunakan dummy data jika service dan JSON sudah tersedia.
* Gunakan `AppServices` untuk mengakses service dari form.
* Pastikan build berhasil sebelum commit dan push.
