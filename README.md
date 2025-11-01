# C# ve OpenCvSharp ile Gerçek Zamanlı Yüz Tanıma Projesi

Bu proje, Visual Studio'da C# Windows Forms kullanılarak geliştirilmiş, bir webcam üzerinden alınan canlı video akışında yüz tespit etme uygulamasıdır.

## Projenin Amacı

Uygulamanın temel amacı, `OpenCvSharp` kütüphanesinden yararlanarak kameradan alınan görüntüleri (frame) anlık olarak işlemek ve bu görüntülerdeki insan yüzlerini tespit etmektir. Tespit edilen her yüzün etrafına gerçek zamanlı olarak bir dikdörtgen çizilerek sonuç kullanıcıya gösterilir.

## Kullanılan Teknolojiler

* **Yazılım Dili:** C#
* **Platform:** Windows Forms (.NET Framework veya .NET Core)
* **Ana Kütüphane:** `OpenCvSharp4` (OpenCV için bir .NET sarmalayıcısı)
* **Tespit Modeli:** Haar Cascade Sınıflandırıcısı (`haarcascade_frontalface_default.xml`)

## Kurulum ve Gereksinimler

Projenin Visual Studio'da hatasız bir şekilde derlenmesi ve çalıştırılabilmesi için aşağıdaki NuGet paketlerinin kurulu olması **zorunludur**:

1.  `OpenCvSharp4` (Ana kütüphane)
2.  `OpenCvSharp4.runtime.win` (Windows için gerekli olan yerel (native) OpenCV dosyaları)
3.  `OpenCvSharp4.Windows` (`BitmapConverter` gibi Windows Forms'a özel yardımcı sınıfları içerir)

### Gerekli Model Dosyası

Yüz tespitinin çalışması için `haarcascade_frontalface_default.xml` dosyası gereklidir.

* Bu dosya, proje ana dizinine eklenmelidir.
* Dosyanın Visual Studio'daki Özellikler (Properties) penceresinden **"Copy to Output Directory" (Çıktı Dizinine Kopyala)** ayarı **`Copy if newer` (Yeniyse Kopyala)** olarak değiştirilmelidir.
