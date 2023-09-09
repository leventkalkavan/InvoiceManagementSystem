# Invoice Management System API

Bu proje, bir Fatura Yönetim Sistemi API'sini temsil eder. Bu API, admin ve normal kullanıcılar(user) için farklı yetkilere sahip farklı işlevselliği destekler.

## Kullanıcı Yetkileri

### Admin Yetkileri
- Admin yetkisine sahip kişiler aşağıdaki işlemleri gerçekleştirebilir:
  - Giriş yapabilir.
  - Evlerle ilgili ekleme, silme, düzenleme ve listeleme işlemleri yapabilir.
  - Kişilerle ilgili ekleme, silme, düzenleme ve listeleme işlemleri yapabilir.
  - Faturalarla ilgili ekleme, silme ve listeleme işlemleri yapabilir.

### Normal Kullanıcı Yetkileri
- Normal kullanıcılara aşağıdaki işlemler sunulur:
  - Evin boş olup olmadığını kontrol edebilir.
  - Kendisine atanmış fatura detaylarına bakabilir.
  - Kendisine atanmış faturayı ödeyebilir.

## Başlangıç

Bu projeyi yerel bilgisayarınıza klonlamak ve çalıştırmak için aşağıdaki adımları izleyin:

1. Projeyi klonlayın:
- git clone https://github.com/your-username/InvoiceManagementSystemAPI.git
  
2. Projeyi çalıştırın:
- cd InvoiceManagementSystemAPI
- dotnet run
  
3. API, varsayılan olarak `http://localhost:5000` adresinde çalışır.
   
## API Endpointleri

API'nin sunduğu bazı temel endpoint'ler şunlardır:

- Kullanıcı Endpoinleri(Admin Yetkisi Gerekli)
  - `GET /api/Admin/GetAllUsers`: Tüm kişileri listeler.
  - `POST /api/Admin/CreateUser`: Yeni bir kişi ekler.
  - `PUT /api/Admin/UpdateUser`: Belirli bir kişiyi günceller.
  - `DELETE /api/Admin/DeleteUser/{Id}`: Belirli bir kişiyi siler.
    
- Ev Endpointleri(Admin Yetkisi Gerekli)
  - `POST /api/Admin/CreateHouse`: Yeni bir ev ekler.
  - `PUT /api/Admin/UpdateHouse}`: Belirli bir evi günceller.
  - `DELETE /api/Admin/DeleteHouse/{Id}`: Belirli bir evi siler.
   
- Fatura Endpointleri(Admin Yetkisi Gerekli)
- `GET /api/Admin/GetAllInvoice`: Tüm faturalı listeler.
- `POST /api/Admin/CreateInvoice`: Yeni bir fatura ekler.
- `PUT /api/invoices/{id}`: Belirli bir faturayı günceller.
- `DELETE /api/Admin/DeleteInvoice/{Id}`: Belirli faturayı siler.
  
- Rol Endpointleri
  - `GET /api/Role/GetAllRole`: Tüm rolleri listeler.
  - `POST /api/Role/CreateRole`: Yeni bir rol ekler.
  - `POST /api/Role/AssigningRole`: Belirli bir kişiye belirli bir rol atar.
    
- Kullanıcı(User) Endpointleri,
- `GET /api/User/GetAllHouse`: Tüm evleri listeler.
- `GET /api/User/GetInvoiceById/{Id}e`: Belirli bir faturaya ait detayları listeler.
- `POST /api/User/PayInvoice`: Belirli faturayı, atanan kullanıcının ödemesini sağlar.
- `POST /api/User/Login`: Kayıtlı kullanıcının giriş yapmasını sağlar.
