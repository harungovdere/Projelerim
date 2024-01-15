from user.forms import LoginForm, RegisterForm
from django.shortcuts import redirect, render
from django.contrib import messages
from . import views

from django.contrib.auth.models import User
from django.contrib.auth import login,authenticate,logout

# Create your views here.

def register(request):
    if request.method == "POST":
        form = RegisterForm(request.POST)
        if form.is_valid():
            username = form.cleaned_data.get("username")
            password = form.cleaned_data.get("password")

            newUser = User(username=username)
            newUser.set_password(password)
            newUser.save()

            login(request, newUser)
            messages.info(request,"Başarıyla Kayıt Oldunuz...")
            return redirect("index")
            context = {
                "form": form
            }
            return render(request, "kullanici-islemleri/kullaniciKayit.html", context)
    else:
        form=RegisterForm()
        context = {
                "form": form
            }
        return render(request, "kullanici-islemleri/kullaniciKayit.html", context)

def loginUser(request):
    form=LoginForm(request.POST or None)

    context = {
        "form":form
    }

    if form.is_valid():
        username=form.cleaned_data.get("username")
        password=form.cleaned_data.get("password")
        
        user=authenticate(username=username,password=password)

        if user is None:
            messages.info(request,"Kullanıcı Adı veya Parola Hatalı")
            return render(request,"kullanici-islemleri/oturumAc.html",context)

        messages.success(request,"Başarıyla Giriş Yaptınız")
        login(request,user)
        return redirect("index")

    return render(request, "kullanici-islemleri/oturumAc.html",context)

def logoutUser(request):
    logout(request)
    messages.success(request,"Başarıyla Çıkış Yaptınız...")
    return redirect("index")