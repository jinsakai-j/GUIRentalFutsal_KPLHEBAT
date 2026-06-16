# GUIRentalFutsal - KPLHEBAT

GUIRentalFutsal adalah aplikasi desktop berbasis **C# Windows Forms** untuk sistem penyewaan lapangan futsal. Aplikasi ini dibuat sebagai pengembangan tugas besar Konstruksi Perangkat Lunak dengan fokus pada implementasi GUI, integrasi service, penyimpanan data JSON, dan penerapan teknik konstruksi perangkat lunak.

---

## Deskripsi Project

Aplikasi ini digunakan untuk membantu proses rental lapangan futsal, mulai dari pengelolaan lapangan, pembuatan booking, pengecekan jadwal, pembayaran, hingga laporan.

Pada project ini, GUI dibuat menggunakan **Windows Forms**, sedangkan logic bisnis dipisahkan ke dalam folder `Services`. Data aplikasi disimpan menggunakan file JSON melalui class `JsonDataStore`.

Alur arsitektur sederhana:

```text
Windows Form
↓
AppServices
↓
Service
↓
JsonDataStore
↓
JSON File
```

---

## Teknologi yang Digunakan

| Komponen           | Teknologi          |
| ------------------ | ------------------ |
| Bahasa Pemrograman | C#                 |
| Framework          | .NET 8             |
| GUI                | Windows Forms      |
| Data Storage       | JSON File          |
| IDE                | Visual Studio 2022 |
| Version Control    | Git dan GitHub     |

---

## Fitur Aplikasi

### 1. Dashboard

Dashboard berada pada `DashboardForm.cs` dan berfungsi sebagai menu utama aplikasi.

Fitur:

* Membuka Form Kelola Lapangan
* Membuka Form Booking
* Membuka Form Cek Jadwal
* Membuka Form Pembayaran
* Membuka Form Laporan
* Keluar dari aplikasi

File terkait:

* `DashboardForm.cs`

---

### 2. Kelola Lapangan

Form kelola lapangan digunakan untuk mengatur data lapangan futsal.

Fitur:

* Menampilkan daftar lapangan dari `fields.json`
* Menambah data lapangan
* Mengubah data lapangan
* Menghapus data lapangan
* Mengatur status aktif lapangan
* Menyimpan perubahan data lapangan ke JSON

File terkait:

* `FieldForm.cs`
* `FieldService.cs`
* `JsonDataStore<Field>`
* `Data/fields.json`

---

### 3. Booking

Form booking digunakan untuk membuat data penyewaan lapangan.

Fitur:

* Memilih lapangan aktif dari data JSON
* Memilih tanggal booking
* Memilih jam mulai booking
* Memilih durasi booking
* Mendukung durasi 1 sampai 6 jam
* Mendukung opsi `Full Day`
* Menghitung total harga booking
* Mengecek ketersediaan jadwal sebelum booking
* Menyimpan data booking ke `bookings.json`
* Menampilkan daftar booking pada tabel

Aturan booking:

* Jam operasional: `08:00 - 23:00`
* Jam mulai terakhir: `22:00`
* Booking tidak boleh melewati jam operasional
* Booking baru memiliki status `PendingPayment`
* Jadwal tidak boleh bentrok dengan booking lain

File terkait:

* `BookingForm.cs`
* `BookingService.cs`
* `ScheduleService.cs`
* `FieldService.cs`
* `Data/bookings.json`

---

### 4. Cek Jadwal

Form cek jadwal digunakan untuk mengecek ketersediaan jadwal lapangan.

Fitur:

* Memilih lapangan
* Memilih tanggal
* Memilih jam mulai
* Memilih durasi
* Mendukung opsi `Full Day`
* Mengecek apakah jadwal tersedia atau penuh
* Menampilkan booking berdasarkan tanggal dan lapangan
* Mengambil data dari `bookings.json`

File terkait:

* `ScheduleForm.cs`
* `ScheduleService.cs`
* `BookingService.cs`
* `FieldService.cs`

---

### 5. Pembayaran

Form pembayaran digunakan untuk memproses pembayaran booking.

Fitur:

* Menampilkan daftar booking dengan status `PendingPayment`
* Menampilkan detail booking yang dipilih
* Memvalidasi jumlah pembayaran
* Memproses pembayaran booking
* Mengubah status booking menjadi `Paid`
* Menyimpan perubahan status ke `bookings.json`

File terkait:

* `PaymentForm.cs`
* `PaymentService.cs`
* `BookingService.cs`
* `BookingStateMachine.cs`

---

### 6. Laporan

Form laporan digunakan untuk menampilkan ringkasan booking dan pendapatan.

Fitur:

* Filter laporan berdasarkan periode awal dan periode akhir
* Menampilkan total booking
* Menampilkan booking pending
* Menampilkan booking paid
* Menampilkan booking completed
* Menampilkan booking cancelled
* Menampilkan total pendapatan
* Menampilkan detail booking pada tabel

Aturan laporan:

* Total pendapatan dihitung dari booking dengan status `Paid` dan `Completed`
* Booking dengan status `Cancelled` tidak dihitung sebagai pendapatan
* Data laporan diambil dari `bookings.json`

File terkait:

* `ReportForm.cs`
* `ReportService.cs`
* `BookingService.cs`
* `FieldService.cs`

---

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
├── DashboardForm.cs
├── FieldForm.cs
├── BookingForm.cs
├── ScheduleForm.cs
├── PaymentForm.cs
├── ReportForm.cs
└── Program.cs
```

---

## Arsitektur Aplikasi

Project ini menggunakan pemisahan sederhana antara tampilan, logic bisnis, dan penyimpanan data.

### Windows Form

Digunakan sebagai tampilan aplikasi dan tempat user melakukan input.

Contoh:

* `DashboardForm`
* `FieldForm`
* `BookingForm`
* `ScheduleForm`
* `PaymentForm`
* `ReportForm`

### AppServices

`AppServices` digunakan sebagai pusat akses service agar setiap form tidak perlu membuat object service secara manual berulang kali.

### Services

Folder `Services` berisi logic bisnis aplikasi.

Contoh:

* `FieldService`
* `BookingService`
* `ScheduleService`
* `PaymentService`
* `ReportService`

### Models

Folder `Models` berisi class representasi data.

Contoh:

* `Booking`
* `Field`
* `Payment`
* `OperationResult`

### Data

Folder `Data` berisi file JSON sebagai penyimpanan lokal aplikasi.

---

## Data JSON

Project menggunakan file JSON sebagai penyimpanan data lokal.

File data:

```text
Data/fields.json
Data/bookings.json
```

Catatan penting:

Saat aplikasi dijalankan, file JSON yang digunakan biasanya berada di folder output:

```text
bin/Debug/net8.0-windows/Data/
```

Agar file JSON ikut terbawa saat build, atur properties file JSON:

```text
Build Action: Content
Copy to Output Directory: Copy if newer
```

Jangan gunakan `Copy always` secara terus-menerus karena dapat menimpa data terbaru setiap aplikasi dijalankan.

---

## Teknik Konstruksi yang Digunakan

### 1. Generics

Digunakan pada:

```text
JsonDataStore<T>
OperationResult<T>
```

Tujuannya agar class dapat digunakan ulang untuk berbagai model.

---

### 2. Table-driven Construction

Data aplikasi disimpan dalam bentuk tabel sederhana melalui file JSON.

Contoh:

* `fields.json`
* `bookings.json`

---

### 3. Defensive Programming

Digunakan untuk validasi input dan kondisi program.

Contoh validasi:

* Nama tidak boleh kosong
* Nomor HP tidak boleh kosong
* Durasi harus valid
* Lapangan harus aktif
* Jadwal tidak boleh bentrok
* Booking tidak boleh melewati jam operasional
* Pembayaran tidak boleh kurang dari total harga

---

### 4. Design by Contract

Service melakukan validasi sebelum memproses data.

Contoh:

* Booking hanya dibuat jika lapangan valid
* Pembayaran hanya dilakukan jika status booking sesuai
* Jadwal hanya tersedia jika tidak bentrok

---

### 5. Automata / State Machine

Digunakan pada `BookingStateMachine` untuk mengatur perubahan status booking.

Contoh status:

* `PendingPayment`
* `Paid`
* `Completed`
* `Cancelled`

---

### 6. Code Reuse

Logic service digunakan ulang oleh banyak form agar tidak terjadi duplikasi kode.

Contoh:

* `BookingService` digunakan oleh Booking, Schedule, Payment, dan Report
* `FieldService` digunakan oleh Field, Booking, Schedule, dan Report
* `ScheduleService` digunakan untuk mengecek ketersediaan jadwal
* `PaymentService` digunakan untuk memproses pembayaran booking

---

## Pembagian Tugas

| Anggota                       | Tanggung Jawab                       |
| ----------------------------- | ------------------------------------ |
| Rajaa Azharul Hanafi          | Dashboard, Integrasi Backend, Report |
| Faiq Prabaswara Riyana        | Schedule / Cek Jadwal                |
| Arkananta Odysa               | Booking                              |
| Muhammad Fitrah Dafa Zulfikar | Payment / Pembayaran                 |
| Petra Panondang Simangunsong  | Field / Kelola Lapangan              |

---

## Cara Menjalankan Project

1. Clone repository.

```bash
git clone <repository-url>
```

2. Buka project menggunakan Visual Studio 2022.

3. Buka solution project.

```text
GuiRentalFutsal.slnx
```

4. Pastikan project menggunakan `.NET 8`.

5. Pastikan file JSON pada folder `Data` memiliki properties:

```text
Build Action: Content
Copy to Output Directory: Copy if newer
```

6. Jalankan aplikasi dengan tombol `Start`.

---

## Alur Aplikasi

```text
Dashboard
├── Kelola Lapangan
├── Booking
├── Cek Jadwal
├── Pembayaran
└── Laporan
```

---

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
git commit -m "connect payment form to payment service"
git commit -m "connect report form to booking data"
git commit -m "update project readme"
```

---

## Catatan Pengembangan

* Jangan mengubah branch `master` secara langsung untuk fitur besar.
* Setiap form sebaiknya dikerjakan pada branch masing-masing.
* Jika terjadi conflict pada `DashboardForm.cs`, gabungkan navigasi dashboard dari setiap fitur.
* Jangan menggunakan dummy data jika service dan JSON sudah tersedia.
* Gunakan `AppServices` untuk mengakses service dari form.
* Pastikan build berhasil sebelum commit dan push.
* Pastikan file JSON memiliki property `Copy if newer`, bukan `Copy always`, agar data tidak selalu tertimpa saat aplikasi dijalankan.

---

## Status Project

| Fitur           | Status  |
| --------------- | ------- |
| Dashboard       | Selesai |
| Kelola Lapangan | Selesai |
| Booking         | Selesai |
| Cek Jadwal      | Selesai |
| Pembayaran      | Selesai |
| Laporan         | Selesai |
