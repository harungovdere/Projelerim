from django.db import models
from django.db.models.deletion import CASCADE

# Create your models here.

class Urun(models.Model):
    author=models.ForeignKey("auth.User",on_delete=models.CASCADE,verbose_name="Yazar")
    title=models.CharField(max_length=50,verbose_name="Ürün Adı")
    brand=models.CharField(max_length=50,verbose_name="Marka Adı")
    rim=models.CharField(max_length=50,verbose_name="Jant")
    gear=models.CharField(max_length=50,verbose_name="Vites")
    price=models.CharField(max_length=50,verbose_name="Fiyat")
    content=models.TextField(verbose_name="Ürün Açıklaması")
    created_date=models.DateTimeField(auto_now_add=True,verbose_name="Oluşturulma Tarihi")
    bisiklet_image=models.FileField(blank=True,null=True,verbose_name="Ürün Fotoğrafı Ekleyin")
    role=(('seciniz',"Seçiniz"),
    ('Dağ Bisikleti',"Dağ Bisikleti"),
    ('Yol-Yarış Bisikleti',"Yol-Yarış Bisikleti"),
    ('Şehir Bisikleti',"Şehir Bisikleti"),
    ('Çocuk Bisikleti',"Çocuk Bisikleti"),
    ('Katlanabilir Bisiklet',"Katlanabilir Bisiklet"),
    ('Cross Bisiklet',"Cross Bisiklet"))
    medicine=models.CharField(max_length=50,choices=role,default="seciniz",verbose_name="Bisiklet Tipi")
    role2=(('seciniz',"Seçiniz"),
    ('Erkek',"Erkek"),
    ('Kadın',"Kadın"),
    ('Erkek Çocuk',"Erkek Çocuk"),
    ('Kız Çocuk',"Kız Çocuk"),
    ('Unisex',"Unisex"))
    gender=models.CharField(max_length=50,choices=role2,default="seciniz",verbose_name="Cinsiyet")


    def __str__(self):
        return self.title

class Yorum(models.Model):
	urun=models.ForeignKey(Urun,on_delete=models.CASCADE,verbose_name="Ürün",related_name="yorumlar")
	yorum_author=models.CharField(max_length=50,verbose_name="İsim")
	yorum_content=models.CharField(max_length=200,verbose_name="Yorum")
	yorum_date=models.DateTimeField(auto_now_add=True)
	def __str__(self):
    		return self.yorum_content
	class Meta:
		ordering=["-yorum_date"]

class Deneme(models.Model):
    ayva=models.ForeignKey("auth.User",on_delete=models.CASCADE,verbose_name="deneme",)
    dana=models.CharField(max_length=50,verbose_name="dene2")
    def __str__(self):
        return self.dana
    