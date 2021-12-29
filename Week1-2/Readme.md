# NFTBaazar
Bootcamp sürecince NFTBaazar NFT satış sitesine dönüşecektir. 
## Proje
HTTP request methodları kullanarak CRUD işlemleri yapan bir WebApi tasarladım.

**Get Methodu** : Sunucudan veri almak için kullanılan CRUD işlemlerinde read operasyonuna karşılık gelir.
![img_get](https://github.com/AKBANK-Patika-FullStack-Bootcamp/ZeynepDemirel_Homeworks/blob/main/Week1-2/postmanScreenshots/postman_img_get.PNG)
![img_getbyid](https://github.com/AKBANK-Patika-FullStack-Bootcamp/ZeynepDemirel_Homeworks/blob/main/Week1-2/postmanScreenshots/postman_img_getById.PNG)

**Post Methodu** : Sunucuya veri göndermek için kullanılır. Operasyon sonunda veri setine insert işlemi beklenir, CRUD işlemlerinden read operasyonuna karşılık gelir.

*token*
```
{
    "tokenId": 4,
    "tokenName": "ANOTHER WORLD",
    "dateOfConsruction": "2014-12-26T00:00:00",
    "price": 3000
}
```

*postman response*
```
{
    "status": 1,
    "message": "İnsert new token in list",
    "list": [
        {
            "tokenId": 1,
            "tokenName": "1978 gold candy",
            "dateOfConsruction": "2014-12-26T00:00:00",
            "price": 4200
        },
        {
            "tokenId": 2,
            "tokenName": "rocking a cock near you.",
            "dateOfConsruction": "2008-04-15T00:00:00",
            "price": 2250
        },
        {
            "tokenId": 3,
            "tokenName": "ROUTINE MAINTENANCE",
            "dateOfConsruction": "2019-12-28T00:00:00",
            "price": 2000
        },
        {
            "tokenId": 4,
            "tokenName": "ANOTHER WORLD",
            "dateOfConsruction": "2014-12-26T00:00:00",
            "price": 3000
        }
    ]
}
```
*postman unsuccessful response*
![img_post_wr](https://github.com/AKBANK-Patika-FullStack-Bootcamp/ZeynepDemirel_Homeworks/blob/main/Week1-2/postmanScreenshots/postman_img_post_wr.PNG)

**Put Methodu** :Sunucuya halihazırda var olan bir veriye ait bilgileri değiştirmek için kullanılır. CRUD işlemlerinden update operasyonuna karşılık gelir.

*token*
```
{
  "tokenId": 3,
  "tokenName": "ROUTINE MAINTENANCE",
  "dateOfConsruction": "2019-12-28T00:00:00",
  "price": 2200
}
``` 

*postman response*
```
{
    "status": 1,
    "message": "Updated successfully.",
    "list": [
        {
            "tokenId": 1,
            "tokenName": "1978 gold candy",
            "dateOfConsruction": "2014-12-26T00:00:00",
            "price": 4200
        },
        {
            "tokenId": 2,
            "tokenName": "rocking a cock near you.",
            "dateOfConsruction": "2008-04-15T00:00:00",
            "price": 2250
        },
        {
            "tokenId": 3,
            "tokenName": "ROUTINE MAINTENANCE",
            "dateOfConsruction": "2019-12-28T00:00:00",
            "price": 2000
        }
    ]
}
```

**Delete Methodu** : Bir veriyi sunucudan silmek için kullanılır. CRUD işlemlerinden delete operasyonuna karşılık gelir.

![img_delete](https://github.com/AKBANK-Patika-FullStack-Bootcamp/ZeynepDemirel_Homeworks/blob/main/Week1-2/postmanScreenshots/postman_img_delete.PNG)

*postman response*
```
{
    "status": 1,
    "message": "Deleted successfully",
    "list": [
        {
            "tokenId": 1,
            "tokenName": "1978 gold candy",
            "dateOfConsruction": "2014-12-26T00:00:00",
            "price": 4200
        },
        {
            "tokenId": 2,
            "tokenName": "rocking a cock near you.",
            "dateOfConsruction": "2008-04-15T00:00:00",
            "price": 2250
        }
    ]
}
```

*postman unsuccessful response*
```
{
    "status": 0,
    "message": "Deleted wrong",
    "list": null
}
```

## Kullanılan Teknolojiler
- Visual Studio 2022
Kurulum için [tıklayınız](https://visualstudio.microsoft.com/tr/vs/)

- Postman
Kurulum için [tıklayınız](https://www.postman.com/downloads/)

- .NetCore 6

