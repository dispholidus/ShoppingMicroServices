# ShoppingMicroServices Get İşlemleri

localhost:3000/api üzerinden ulaşılabilir. 

/product adresinden veritabanında kayıtlı tüm ürünlere ulaşılabilir.

/product/[id] adresinden idsi verilen ürüne ulaşılabilir.

/product/[id]/[kurismi] adresinden verilen id'deki ürünün verilen kurdaki fiyatına ulaşılabilir

/order adresinden veritabanında kayıtlı tüm siparişlere ulaşılabilir.

# ShoppingMicroServices Post İşlemleri

/order?productId=[productId]&quantity=[alınanürünadedi] adresi ile veritabanına kaydedilmek üzere sipariş verisi gönderilir.

/order?productId=[productId]&quantity=[alınanürünadedi]&exchangeRateName=[kurismi] adresi ile veritabanına kaydedilmek üzere sipariş verisi gönderilir. Kaydedilirken 
kur ismi verildiyse o parabiriminden kaydeder.


