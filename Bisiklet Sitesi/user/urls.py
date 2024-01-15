from django.contrib import admin
from django.urls import path

from . import views

app_name="user"

urlpatterns = [
    path('kullaniciKayit/',views.register,name="kullaniciKayit"),
    path('oturumAc/',views.loginUser,name="oturumAc"),
    path('cikisYap/',views.logoutUser,name="cikisYap"),

    
]