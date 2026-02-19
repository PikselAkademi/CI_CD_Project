# CI CD Eğitimi İçeriği

### Repository İçeriği
- __CI-CD.pdf__
  > Eğitim sırasında kullanılan sunumun PDF versiyonu
- __CI-CD_Azure.pdf__
  > Eğitimde kullanılan sunuma Azure Pipelines eklenmiş versiyonu
- __workshop__
  > Eğitimde kullandığımız örnek projelerin kodları
- __Microservice CI CD (IIS msdeploy)__
  > Microservice projesinde bütün servisleri msdeploy ile IIS'e gönderen CI/CD akışı örneği
- __actions (yorumsuz)__
  > Yorum satırı bulunmayan workflow örnekleri
  * __1. proje (v1)__
    > GitHub Actions için yml dosyaları bu dizinde yer almakta
    - __Azure versiyonu__ 
      > Azure DevOps Pipelines için yml dosyaları bu dizinde yer almakta
  * __2. proje (v2)__
    > GitHub Actions için yml dosyaları bu dizinde yer almakta
    - __Azure versiyonu__
      > Azure DevOps Pipelines için yml dosyaları bu dizinde yer almakta
- __actions (yorumlu)__
  > Yorum satırı bulunan workflow örnekleri
  * __1. proje (v1)__
    > GitHub Actions için yml dosyaları bu dizinde yer almakta
    - __Azure versiyonu__
      > Azure DevOps Pipelines için yml dosyaları bu dizinde yer almakta
  * __2. proje (v2)__
    > GitHub Actions için yml dosyaları bu dizinde yer almakta
    - __Azure versiyonu__
      > Azure DevOps Pipelines için yml dosyaları bu dizinde yer almakta

---

## Eğitimde Oluşturulan Repository'ler

[1. Proje Uygulaması](https://github.com/PikselAkademi/Workshop_V1)   
[2. Proje Uygulaması](https://github.com/PikselAkademi/Workshop_V2)

---

# Notlar

Yorum satırı bulunmayan yml dosyaları yorum satırı bulunanlar ile aynı dosyalardır, sadece yorum satırları silinmiştir.

İlgili dizinlerde direkt yer alan yml dosyaları GitHub Actions içindir, Azure DevOps Pipelines için olan yml dosyaları Azure versiyonu klasörü altındadır.

Azure için olan yml dosyaları GitHub için olanlarla aynı akıştadır.

## İsimlendirme

ci-cd şeklinde adlandırılan yml dosyalarında ci ve cd işleri aynı dosya içerisindedir, sadece ci veya sadece cd ekini taşıyan doslayar o göreve özel dosyalardır.

azure ekini taşıyan dosyalar Azure App Service'e deploy yapan dosyalardır.

ftp ekini taşıyan dosyalar ftp'ye deploy yapan dosyalardır.

matrix ekini taşıyan dosyalar strategy+matrix yapısını kullanan dosyalardır.