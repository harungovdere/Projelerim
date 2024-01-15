from django.contrib import admin
from django.urls import path
from bisiklet import views
from . import views

app_name="bisiklet"

urlpatterns = [
    path('kontrolPaneli/',views.kontrolPaneli,name="kontrolPaneli"),
    path('urunler/',views.urunler,name="urunler"),
    path('urunEkle/',views.urunEkle,name="urunEkle"),
    path('bisiklet/<int:id>',views.urunDetay,name="urunDetay"),
    path('urunGuncelle/<int:id>',views.urunGuncelle,name="urunGuncelle"),
    path('sil/<int:id>',views.urunSil,name="sil"),
    path('yorum/<int:id>',views.yorumEkle,name="yorum"),
    path('filtreAra/',views.filtreAra,name="filtreAra"),
    path('ara/',views.ara,name="ara"),
    path('sepetim/',views.sepetim,name="sepetim"),


]