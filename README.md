
# İş Yönetim Sistemi Api Projesi

    Projenin amacı küçük ve orta ölçekli firmaların iş takiplerini yapalabilmesi için geliştirilmiş bir uygulamadır.
    
    İlgili kişiler tarafından işlerin açılması ve işi alan veya iş atanan kişinin işi çözmesi beklenmektedir.


## API Nedir ?
    API, Türkçede “Uygulama Programlama Arayüzü” anlamına gelen “Application Programming Interface” tanımının baş harflerinden ortaya çıkmış bir terimdir. Kısa bir tanımla API, kendine ait veriler ve çalışma prensipleri ile geliştirilmiş uygulamaların, birbirileri ile iletişime geçerek çalışmasını mümkün kılan yazılımdır.



  
## Projede Kullanılan Kavramlar

-	N-Katmanlı Mimari tasarımı(sunum, servis, entity, iş katmanı, dal katmanı)
-	OOP(class, nesne, interface, kalıtım, çoklu kalıtım, yapıcı metod, kapsülleme)
-	ORM-Entityframework
-	Mapper yapısı kurma ve kullanma
-	Transaction yönetimi(UnitOfWork pattern)
-	Repository,gereric repository pattern
-	Generic metod, generic class, generic interface
-	Depency injeciton
-	JWTToken dağıtma ve kullanma
-	REST Api tasarımı
-	Web Api Setup ayarları
-	UML oluşturma
-	UML’i okuyarak veri tabanı oluşturma
-	Veri tabanı:Tablo, Kolon, Primary Key , Foreign Key, Unique key


## Postman Dokümantasyon Link
[PostmanDokumantasyon](https://documenter.getpostman.com/view/15241342/UyxeoThS)
  
## API Özellikleri

#### Employee Login:
- Database tarafında kaydedilmiş olan kullanıcının mail ve password onayından sonra token üreterek sisteme girişinin sağlanması.
#### Manager Login:
- Database tarafında kaydedilmiş olan kullanıcının mail ve password onayından sonra token üreterek sisteme girişinin sağlanması.
- CRUD işlemleri (Create, Read, Update, Delete )<br>
- ID ye göre Department özelliklerinin getirilmesi<br>
#### Employee:
- CRUD işlemleri (Create, Read, Update, Delete )
- ID ye göre Employee özelliklerinin getirilmesi
- Maile gelen şifrenin personel tarafından güncellenerek veritabanına md5 formatıyla hashlenerek tutulması.
#### Manager:
- CRUD işlemleri (Create, Read, Update, Delete )
- ID ye göre Manager özelliklerinin getirilmesi
- Yönetici tarafından personel eklenmesi işlemi
- Eklenen personelin mail adresine şifresinin iletilmesi
#### Message:
- CRUD işlemleri (Create, Read, Update, Delete )
- ID ye göre Message özelliklerinin getirilmesi
- İş yazışmalarının listelenmesi
#### Work:
- CRUD işlemleri (Create, Read, Update, Delete )
- ID ye göre Work özelliklerinin getirilmesi
- Sadece ilgili departmana ait işlerin getirilmesi
- Sistemdeki atanmamış işlerin getirilmesi  


  
## Kullanılan Teknolojiler

**Backend :** ASP .NET CORE:

**VeriTabanı:** Microsoft SQL Server

**Dökümantasyon:** Swagger



  
## API Kullanımı
    Personel Admin veya Yönetici girişi yapılmalıdır. Giriş Yapıldıktan sonra sistem tarafından verilen Token, Authorize kısmına kaydedilmelidir ve giriş yapılmalıdır. Api ye gönderilecek olan işlemler bu aşamadan sonra gerçekleştirilmelidir.

### ManagerLogin

#### Post  ManagerLogin

```http
  POST /api/ManagerLogin/Login
```

| Parametre | Tip     | Açıklama                |
| :-------- | :------- | :------------------------- |
| `managerMail` | `string` | **Gerekli** Manager/Admin Gmail |
| `managerPass` | `string` | **Gerekli** Manager/Admin Parola |

```json
{
  "managerMail": "example@example.com",
  "managerPass": "string"
}
```

### EmployeeLogin

#### Post  EmployeeLogin

```http
  POST /api/EmployeeLogin/Login
```

| Parametre | Tip     | Açıklama                |
| :-------- | :------- | :------------------------- |
| `employeeMail` | `string` | **Gerekli** Employee Gmail |
| `employeePass` | `string` | **Gerekli** Employee Parola |

```json
{
  "employeeMail": "example@example.com",
  "employeePass": "string"
}
```


### Department

#### GET FindID

```http
  GET /api/Department/Find?id=5
```

| Parametre | Tip     | Açıklama                |
| :-------- | :------- | :------------------------- |
| `departmentId` | `int` | **Gerekli** Departman ID |

#### GET GetAll

```http
  GET /api/Department/GetAll
```

#### Post Add

```http
  POST /api/Department/Add
```

| Parametre | Tip     | Açıklama                |
| :-------- | :------- | :------------------------- |
| `departmentId` | `int` | **Gerekli**  Departman ID |
| `departmentName` | `string` | **Gerekli**  Departman ismi |

```json
{
  "departmentId": 0,
  "departmentName": "string"
}
```
#### DEL Delete

```http
  DEL /api/Department/Delete?id=15
```

| Parametre | Tip     | Açıklama                |
| :-------- | :------- | :------------------------- |
| `departmentId` | `int` | **Gerekli**  Departman ID |

#### PUT Update

```http
  PUT /api/Department/Update
```

| Parametre | Tip     | Açıklama                |
| :-------- | :------- | :------------------------- |
| `departmentId` | `int` | **Gerekli**  Departman ID |
| `departmentName` | `string` | **Gerekli**  Departman ismi |

```json
{
  "departmentId": 0,
  "departmentName": "string"
}
```

### Manager

#### GET GetAll

```http
  GET /api/Manager/GetAll
```
#### GET FindID

```http
  GET /api/Manager/Find?id=4
```

| Parametre | Tip     | Açıklama                |
| :-------- | :------- | :------------------------- |
| `managerId` | `int` | **Gerekli** Manager ID |

#### Post Add

```http
  POST /api/Manager/Add
```

| Parametre | Tip     | Açıklama                |
| :-------- | :------- | :------------------------- |
| `managerId` | `int` | **Gerekli**  Manager/Admin ID |
| `managerName` | `string` | **Gerekli**  Manager/Admin ismi |
| `managerSurname` | `string` | **Gerekli**  Manager/Admin soyismi |
| `managerMail` | `string` | **Gerekli**  Manager/Admin maili |
| `managerPhone` | `string` |  Manager/Admin telefon |
| `managerDep` | `int` | **Gerekli**  Manager/Admin departman id |
| `managerAuth` | `string` | **Gerekli**  Manager/Admin yetkisi |
| `managerPass` | `string` | **Gerekli**  Manager/Admin Parola |

```json
{
  "managerId": 0,
  "managerName": "string",
  "managerSurname": "string",
  "managerMail": "string",
  "managerPhone": "string",
  "managerDep": 0,
  "managerAuth": "string",
  "managerPass": "string"
}
```

#### PUT Update

```http
  PUT /api/Manager/Update
```

| Parametre | Tip     | Açıklama                |
| :-------- | :------- | :------------------------- |
| `managerId` | `int` | **Gerekli**  Manager/Admin ID |
| `managerName` | `string` | **Gerekli**  Manager/Admin ismi |
| `managerSurname` | `string` | **Gerekli**  Manager/Admin soyismi |
| `managerMail` | `string` | **Gerekli**  Manager/Admin maili |
| `managerPhone` | `string` |  Manager/Admin telefon |
| `managerDep` | `int` | **Gerekli**  Manager/Admin departman id |
| `managerAuth` | `string` | **Gerekli**  Manager/Admin yetkisi |
| `managerPass` | `string` | **Gerekli**  Manager/Admin Parola |

```json
{
  "managerId": 0,
  "managerName": "string",
  "managerSurname": "string",
  "managerMail": "string",
  "managerPhone": "string",
  "managerDep": 0,
  "managerAuth": "string",
  "managerPass": "string"
}
```
#### DEL Delete

```http
  DEL /api/Manager/Delete?id=5
```

| Parametre | Tip     | Açıklama                |
| :-------- | :------- | :------------------------- |
| `managerId` | `int` | **Gerekli**  Manager ID |

#### Post AddEmployee

```http
  POST /api/Manager/AddEmployee
```

| Parametre | Tip     | Açıklama                |
| :-------- | :------- | :------------------------- |
| `employeeId` | `int` | **Gerekli**  Employee ID |
| `employeeName` | `string` | **Gerekli**  Employee ismi |
| `employeeSurname` | `string` | **Gerekli**  Employee soyismi |
| `employeeMail` | `string` | **Gerekli**  Employee maili |
| `employeePhone` | `string` |  Employee telefon |
| `employeeDep` | `int` | **Gerekli**  Employee departman id |
| `employeeAuth` | `string` | **Gerekli**  Employee yetkisi |
| `employeePass` | `string` | **Gerekli**  Employee Parola |

```json
{
  "employeeId": 0,
  "employeeName": "Deneme",
  "employeeSurname": "Deneme",
  "employeeMail": "Deneme@gmail.com",
  "employeePhone": "5677655665",
  "employeeDep": 5,
  "employeeAuth": "2",
  "employeePass": "123"
}
```

### Employee

#### GET GetAll

```http
  GET /api/Employee/GetAll
```
#### GET FindID

```http
  GET /api/Employee/Find?id=2
```

| Parametre | Tip     | Açıklama                |
| :-------- | :------- | :------------------------- |
| `employeeId` | `int` | **Gerekli** Employee ID |

#### DEL Delete

```http
  DEL /api/Employee/Delete?id=12
```

| Parametre | Tip     | Açıklama                |
| :-------- | :------- | :------------------------- |
| `employeeId` | `int` | **Gerekli**  Employee ID |

#### PUT Update

```http
  PUT /api/Employee/Update
```

| Parametre | Tip     | Açıklama                |
| :-------- | :------- | :------------------------- |
| `employeeId` | `int` | **Gerekli**  Employee ID |
| `employeeName` | `string` | **Gerekli**  Employee ismi |
| `employeeSurname` | `string` | **Gerekli**  Employee soyismi |
| `employeeMail` | `string` | **Gerekli**  Employee maili |
| `employeePhone` | `string` |  Employee telefon |
| `employeeDep` | `int` | **Gerekli**  Employee departman id |
| `employeeAuth` | `string` | **Gerekli**  Employee yetkisi |
| `employeePass` | `string` | **Gerekli**  Employee Parola |

```json
{
  "employeeId": 0,
  "employeeName": "string",
  "employeeSurname": "string",
  "employeeMail": "string",
  "employeePhone": "string",
  "employeeDep": 0,
  "employeeAuth": "string",
  "employeePass": "string"
}
```
#### PUT UpdatePassword

```http
  PUT /api/Employee/UpdatePassword
```

| Parametre | Tip     | Açıklama                |
| :-------- | :------- | :------------------------- |
| `employeeMail` | `int` | **Gerekli**  Employee mail |
| `employeeOldPassword` | `string` | **Gerekli**  Employee eski parola |
| `employeeNewPassword` | `string` | **Gerekli**  Employee yeni parola |

```json
{
  "employeeMail": "string",
  "employeeOldPassword": "string",
  "employeeNewPassword": "string"
}
```
### Message

#### GET GetAll

```http
  GET /api/Message/GetAll
```
#### GET FindID

```http
  GET /api/Message/Find?id=2
```

| Parametre | Tip     | Açıklama                |
| :-------- | :------- | :------------------------- |
| `messageId` | `int` | **Gerekli** Message ID |

#### DEL Delete

```http
  DEL /api/Message/Delete?id=4
```

| Parametre | Tip     | Açıklama                |
| :-------- | :------- | :------------------------- |
| `messageId` | `int` | **Gerekli**  Message ID |

#### Post Add

```http
  POST /api/Message/Add
```

| Parametre | Tip     | Açıklama                |
| :-------- | :------- | :------------------------- |
| `messageId` | `int` | **Gerekli**  Message ID |
| `fromManager` | `int` | **Gerekli**  Message gönderen |
| `toEmployee` | `int` | **Gerekli**  Message alan |
| `messageTitle` | `string` | **Gerekli**  Message Başlığı |
| `messageBody` | `string` |  Manager/Admin Message İçeriği |


```json
{
  "messageId": 0,
  "fromManager": 0,
  "toEmployee": 0,
  "messageTitle": "string",
  "messageBody": "string"
}
```

#### PUT Update

```http
  PUT /api/Message/Update
```

| Parametre | Tip     | Açıklama                |
| :-------- | :------- | :------------------------- |
| `messageId` | `int` | **Gerekli**  Message ID |
| `fromManager` | `int` | **Gerekli**  Message gönderen |
| `toEmployee` | `int` | **Gerekli**  Message alan |
| `messageTitle` | `string` | **Gerekli**  Message Başlığı |
| `messageBody` | `string` |  Manager/Admin Message İçeriği |


```json
{
  "messageId": 0,
  "fromManager": 4,
  "toEmployee": 2,
  "messageTitle": "string",
  "messageBody": "string"
}
```
### Work

#### GET GetAll

```http
  GET /api/Work/GetAll
```
#### GET FindID

```http
  GET /api/Work/Find?id=2
```

| Parametre | Tip     | Açıklama                |
| :-------- | :------- | :------------------------- |
| `workId` | `int` | **Gerekli** Work ID |

#### DEL Delete

```http
  DEL /api/Work/Delete?id=9
```

| Parametre | Tip     | Açıklama                |
| :-------- | :------- | :------------------------- |
| `workId` | `int` | **Gerekli**  Work ID |

#### GET UnassignedWorks

```http
  GET /api/Work/UnassignedWorks?departmentid=7&WorkOwner=4
```

| Parametre | Tip     | Açıklama                |
| :-------- | :------- | :------------------------- |
| `department` | `int` | **Gerekli** Department ID |
| `workOwner` | `int` | **Gerekli** Employee ID |

#### GET UnassignedWorks

```http
  GET /api/Work/FindDepartmetWork?departmentid=5
```

| Parametre | Tip     | Açıklama                |
| :-------- | :------- | :------------------------- |
| `department` | `int` | **Gerekli** Department ID |

#### Post Add

```http
  POST /api/Work/Add
```

| Parametre | Tip     | Açıklama                |
| :-------- | :------- | :------------------------- |
| `workId` | `int` | **Gerekli**  Work ID |
| `requestNo` | `string` | **Gerekli** İstek Numarası  |
| `requestTitle` | `string` | **Gerekli**  İstek Başlığı |
| `requestBody` | `string` | **Gerekli**   İstek İçeriği |
| `department` | `int` |  **Gerekli** İş Departmanı |
| `openingDate` | `date` |  İşin Açılış Tarihi |
| `requester` | `int` | **Gerekli** İş talep eden Yönetici |
| `workOwner` | `int` | **Gerekli** İş talep eden çalışan |
| `priority` | `string` |  **Gerekli** Durum Bilgisi |
| `closingDate` | `date` |  İşin Kapanış Tarihi |


```json
{
  "workId": 0,
  "requestNo": "6",
  "requestTitle": "Empty",
  "requestBody": "Empty",
  "department": 5,
  "openingDate": "2022-05-09T12:21:38.359Z",
  "requester": 4,
  "workOwner": 4,
  "priority": "Empty",
  "closingDate": "2022-05-30T12:21:38.359Z"
}
```

#### PUT Update

```http
  PUT /api/Work/Update
```
| Parametre | Tip     | Açıklama                |
| :-------- | :------- | :------------------------- |
| `workId` | `int` | **Gerekli**  Work ID |
| `requestNo` | `string` | **Gerekli** İstek Numarası  |
| `requestTitle` | `string` | **Gerekli**  İstek Başlığı |
| `requestBody` | `string` | **Gerekli**   İstek İçeriği |
| `department` | `int` |  **Gerekli** İş Departmanı |
| `openingDate` | `date` |  İşin Açılış Tarihi |
| `requester` | `int` | **Gerekli** İş talep eden Yönetici |
| `workOwner` | `int` | **Gerekli** İş talep eden çalışan |
| `priority` | `string` |  **Gerekli** Durum Bilgisi |
| `closingDate` | `date` |  İşin Kapanış Tarihi |

```json
{
  "workId": 0,
  "requestNo": "6",
  "requestTitle": "Empty",
  "requestBody": "Empty",
  "department": 5,
  "openingDate": "2022-05-09T12:21:38.359Z",
  "requester": 4,
  "workOwner": 4,
  "priority": "Empty",
  "closingDate": "2022-05-30T12:21:38.359Z"
}
```

## Lisans

[MIT](https://choosealicense.com/licenses/mit/)

## Postman Koleksiyon Link
[Postman](https://www.postman.com/collections/b344975b2cd22af029f1)
## Ekran Görüntüleri
#### Database Diagram
![BMS_Database_Diagram](https://user-images.githubusercontent.com/71569624/167424057-d1363180-b985-4bd6-a558-9955e0652606.PNG)
#### Kodun Metric Test Sonucu
![metric test](https://user-images.githubusercontent.com/71569624/167424031-ee5f6d10-f580-428c-bca7-3d0e7c2b5928.PNG)

  
