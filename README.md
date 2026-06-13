# GUIRentalFutsal - KPLHEBAT

GUIRentalFutsal adalah project **Windows Forms App** untuk sistem penyewaan lapangan futsal. Project ini merupakan pengembangan dari tugas besar sebelumnya yang berbasis **ASP.NET Core Web API**, lalu diadaptasi menjadi aplikasi desktop menggunakan **C# Windows Forms**.

Project ini dibuat untuk memenuhi tugas besar mata kuliah **Konstruksi Perangkat Lunak (CLO4)**.

## Status Project Saat Ini

Project masih dalam tahap pengembangan dan integrasi.

Fitur yang sudah mulai dibuat:

* Dashboard utama
* Form Booking
* Form Cek Jadwal
* Struktur folder backend lama berupa `Data`, `Models`, dan `Services`
* `AppServices.cs` sebagai penghubung antara Windows Forms dan service backend

Fitur yang masih dalam proses:

* Integrasi penuh form dengan service
* Form Kelola Lapangan
* Form Pembayaran
* Form Laporan
* Validasi lanjutan pada setiap form
* Penyempurnaan tampilan GUI setiap anggota

## Deskripsi Aplikasi

Aplikasi ini dirancang untuk membantu proses penyewaan lapangan futsal, mulai dari pengelolaan data lapangan, pembuatan booking, pengecekan jadwal, pembayaran, hingga laporan.

Pada versi CLO4, tampilan aplikasi dibuat menggunakan Windows Forms. Logic dari project sebelumnya digunakan kembali melalui folder `Models`, `Services`, dan `Data`.

## Teknologi yang Digunakan

| Komponen           | Teknologi          |
| ------------------ | ------------------ |
| Bahasa Pemrograman | C#                 |
| Framework          | .NET 8             |
| GUI                | Windows Forms      |
| Data Storage       | JSON File          |
| IDE                | Visual Studio 2022 |
| Version Control    | Git dan GitHub     |

## Struktur Project Saat Ini

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
├── BookingForm.cs
├── ScheduleForm.cs
└── Program.cs
```

Catatan: `Form1.cs` saat ini digunakan sebagai Dashboard utama. Nantinya file ini dapat di-rename menjadi `DashboardForm.cs` agar lebih rapi.

## Arsitektur yang Digunakan

Project ini menggunakan pemisahan sederhana antara tampilan, logika bisnis, dan penyimpanan data.

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

* **Windows Form** digunakan sebagai tampilan dan input user.
* **AppServices** digunakan sebagai pusat akses service agar form lebih mudah memanggil logic backend.
* **Services** digunakan untuk menyimpan logika bisnis seperti booking, jadwal, pembayaran, laporan, dan data lapangan.
* **Models** digunakan untuk merepresentasikan data seperti booking, lapangan, pembayaran, dan jadwal.
* **Data JSON** digunakan sebagai penyimpanan lokal aplikasi.

## Pembagian Tugas Sementara

| Anggota                       | Tanggung Jawab                       | Status                 |
| ----------------------------- | ------------------------------------ | ---------------------- |
| Rajaa Azharul Hanafi          | Dashboard, integrasi backend, Report | Dalam proses           |
| Faiq Prabaswara Riyana        | Schedule / Cek Jadwal                | Form awal sudah dibuat |
| Arkananta Odysa               | Booking                              | Form awal sudah dibuat |
| Muhammad Fitrah Dafa Zulfikar | Payment / Pembayaran                 | Belum dibuat           |
| Petra Panondang Simangunsong  | Field / Kelola Lapangan              | Belum dibuat           |

## Alur Aplikasi yang Direncanakan

```text
Dashboard
├── Kelola Lapangan
├── Buat Booking
├── Cek Jadwal
├── Pembayaran
└── Laporan
```

Saat ini Dashboard sudah digunakan sebagai halaman utama. Beberapa tombol masih berupa placeholder dan akan dihubungkan ke form masing-masing setelah form dibuat.

## Backend yang Digunakan Kembali

Dari project sebelumnya, bagian yang digunakan kembali adalah:

```text
Data/
Models/
Services/
```

Bagian yang tidak digunakan pada WinForms:

```text
Controllers/
Program.cs Web API
Swagger configuration
appsettings.json Web API
```

Pada versi WinForms, peran Controller dari Web API digantikan oleh Form sebagai presentation layer.

## Teknik Konstruksi yang Tetap Digunakan

Beberapa teknik konstruksi dari project sebelumnya tetap digunakan atau sedang diadaptasi:

* **Parameterization / Generics**
  Digunakan pada `JsonDataStore<T>` dan `OperationResult<T>`.

* **Table-driven Construction**
  Data lapangan dan booking disimpan dalam file JSON seperti `fields.json` dan `bookings.json`.

* **Defensive Programming**
  Digunakan untuk validasi input seperti nama kosong, durasi tidak valid, dan data pembayaran tidak sesuai.

* **Design by Contract**
  Digunakan pada validasi pre-condition di service.

* **Automata / State Machine**
  Digunakan pada `BookingStateMachine` untuk mengatur perubahan status booking.

* **Code Reuse**
  Service dari backend lama digunakan kembali agar logic tidak ditulis ulang di setiap form.

## Cara Menjalankan Project

1. Clone repository ini.
2. Buka project menggunakan Visual Studio 2022.
3. Pastikan project menggunakan .NET 8.
4. Pastikan file JSON pada folder `Data` memiliki pengaturan:

   * Build Action: `Content`
   * Copy to Output Directory: `Copy if newer`
5. Jalankan aplikasi dengan tombol `Start`.

## Workflow Git

Setiap anggota mengerjakan fitur pada branch masing-masing.

Contoh branch:

```text
master / main
├── rajaa-dashboard-integrasi
├── faiq-schedule-form
├── arka-booking-form
├── dafa-payment-form
└── petra-field-form
```

Alur kerja:

```text
Clone repository
↓
Pull / Sync dari master
↓
Buat branch pribadi
↓
Kerjakan form masing-masing
↓
Commit
↓
Push branch
↓
Pull Request ke master
↓
Merge
```

## Catatan Pengembangan

Project ini masih terus dikembangkan secara bertahap. Prioritas saat ini adalah:

1. Menyelesaikan seluruh form anggota.
2. Menghubungkan form ke `AppServices`.
3. Mengganti dummy data menjadi data dari JSON/service.
4. Menambahkan validasi input pada setiap form.
5. Menghubungkan semua halaman melalui Dashboard.
6. Menyiapkan screenshot GUI dan penjelasan kode untuk laporan CLO4.
