import abc
from os import name
from django.db.models.query import QuerySet
from django.shortcuts import render,HttpResponse,redirect,get_object_or_404,reverse
from .forms import UrunForm,DeneForm
from .models import Urun, Yorum
from django.contrib import messages
from django.contrib.auth.decorators import login_required
from selenium import webdriver
import time
# Create your views here.

def index(request):
    return render(request,"index.html")

def trendyol(request):
    browser = webdriver.Firefox(executable_path=r"C:\Users\HARUN\Desktop\Kurulum\Selenium Python\Selenium ve Hepsiburada\geckodriver.exe")
    url= "https://www.trendyol.com/sr?wc=104580&q=bisiklet&qt=bisiklet&st=bisiklet"
    browser.get(url)

    markalarData=browser.find_elements_by_css_selector(".prdct-desc-cntnr-ttl")
    basliklarData=browser.find_elements_by_css_selector(".prdct-desc-cntnr-name")
    fiyatlarData=browser.find_elements_by_css_selector(".prc-box-dscntd")
    fotolarData=browser.find_elements_by_css_selector(".p-card-img")
    markalar=[]
    basliklar=[]
    fiyatlar=[]
    fotolar=[]
    a=0
    for i in markalarData:
        if a <= 9:
            markalar.append(i.text)
            a+=1
        else:
            break
    b=0
    for j in basliklarData:
        if b <= 9:
            basliklar.append(j.text)
            b+=1
        else:
            break
    c=0
    for k in fiyatlarData:
        if c <= 9:
            fiyatlar.append(k.text)
            c+=1
        else:
            break
    d=0
    for l in fotolarData:
        if d <= 9:
            fotolar.append(l.get_attribute("src"))
            d+=1
        else:
            break

    browser.close()
    print(markalar,basliklar,fiyatlar)

    listeler=zip(markalar,basliklar,fiyatlar,fotolar)

    return render(request,"kategoriler/trendyol.html",{"listeler":listeler})

def filtreAra(request):
    
    if request.method == "POST":
        markaAra=request.POST.getlist("marka")
        vitesAra=request.POST.getlist("vites")
        jantAra=request.POST.getlist("jant")
        cinsiyetAra=request.POST.getlist("cinsiyet")
        turAra=request.POST.getlist("tur")
        bisikletTuru=request.POST.getlist("turu")
        print(markaAra,vitesAra,jantAra,cinsiyetAra,turAra,bisikletTuru)
        markalar=[]
        vitesler=[]
        jantlar=[]
        cinsiyetler=[]
        turler=[]
        basliklar=[]
        fiyatlar=[]
        fotolar=[]
        idler=[]
        for b in bisikletTuru:
            if markaAra != None:
                for i in markaAra:
                    if len(bisikletTuru) == 1:
                        urunler=Urun.objects.filter(medicine=b)
                    else:
                        urunler=Urun.objects.all()
                    urunler=urunler.filter(brand=i)
                    for id in urunler:
                        idler.append(id.id)
            if vitesAra != None:
                for j in vitesAra:
                    if len(bisikletTuru) == 1:
                        urunler=Urun.objects.filter(medicine=b)
                    else:
                        urunler=Urun.objects.all()
                    urunler2=urunler.filter(gear=j)
                    for id in urunler2:
                        idler.append(id.id)
            if jantAra != None:
                for k in jantAra:
                    if len(bisikletTuru) == 1:
                        urunler=Urun.objects.filter(medicine=b)
                    else:
                        urunler=Urun.objects.all()
                    urunler3=urunler.filter(rim=k)
                    for id in urunler3:
                        idler.append(id.id)
            if cinsiyetAra != None:
                for l in cinsiyetAra:
                    if len(bisikletTuru) == 1:
                        urunler=Urun.objects.filter(medicine=b)
                    else:
                        urunler=Urun.objects.all()
                    urunler3=urunler.filter(gender=l)
                    for id in urunler3:
                        idler.append(id.id)
            if turAra != None:
                for m in turAra:
                    if len(bisikletTuru) == 1:
                        urunler=Urun.objects.filter(medicine=b)
                    else:
                        urunler=Urun.objects.all()
                    urunler3=urunler.filter(medicine=m)
                    for id in urunler3:
                        idler.append(id.id)

            idler=list(set(idler))

            for l in idler:
                if len(bisikletTuru) == 1:
                        urunler=Urun.objects.filter(medicine=b)
                else:
                    urunler=Urun.objects.all()
                urunler=Urun.objects.filter(medicine=b)
                urunler4=urunler.filter(id=l)
                for marka in urunler4:
                    markalar.append(marka.brand)
                for baslik in urunler4:
                    basliklar.append(baslik.title)
                for fiyat in urunler4:
                    fiyatlar.append(fiyat.price)
                for foto in urunler4:
                    fotolar.append(foto.bisiklet_image)
                for vites in urunler4:
                    vitesler.append(vites.gear)
                for jant in urunler4:
                    jantlar.append(jant.rim)
                for cinsiyet in urunler4:
                    cinsiyetler.append(cinsiyet.gender)
                for tur in urunler4:
                    turler.append(tur.medicine)
        mesaj=""
        if not idler:
            mesaj=("Filtreleme için seçim yapınız...")

        listeler=zip(idler,markalar,basliklar,fiyatlar,fotolar)
        markalar=list(set(markalar))
        
        if len(bisikletTuru) == 1:
            bTuru=bisikletTuru[0]
        else:
            bTuru=""

        if len(bisikletTuru) == 1:
            urunler=Urun.objects.filter(medicine=b)
        else:
            urunler=Urun.objects.all()
        markalar2=urunler.order_by('brand').values_list('brand',flat=True).distinct()
        vitesler2=urunler.order_by('gear').values_list('gear',flat=True).distinct()
        jantlar2=urunler.order_by('rim').values_list('rim',flat=True).distinct()
        turu=urunler.order_by('medicine').values_list('medicine',flat=True).distinct()
        cinsiyetler2=urunler.order_by('gender').values_list('gender',flat=True).distinct()
        context={
        "turler":turler,
        "cinsiyetler":cinsiyetler,
        "bTuru":bTuru,
        "markalar":markalar,
        "vitesler":vitesler,
        "jantlar":jantlar,
        "listeler":listeler,
        "markalar2":markalar2,
        "vitesler2":vitesler2,
        "jantlar2":jantlar2,
        "turu":turu,
        "cinsiyetler2":cinsiyetler2,
        "mesaj":mesaj,
    }
        return render(request,"filtreAra.html",context)
        
def dag(request):
    urunler=Urun.objects.filter(medicine='Dağ Bisikleti')
    markalar=urunler.order_by('brand').values_list('brand',flat=True).distinct()
    vitesler=urunler.order_by('gear').values_list('gear',flat=True).distinct()
    jantlar=urunler.order_by('rim').values_list('rim',flat=True).distinct()
    turu=urunler.order_by('medicine').values_list('medicine',flat=True).distinct()
    cinsiyetler=urunler.order_by('gender').values_list('gender',flat=True).distinct()
    context={
        "urunler":urunler,
        "markalar":markalar,
        "vitesler":vitesler,
        "jantlar":jantlar,
        "turu":turu,
        "cinsiyetler":cinsiyetler,
    }
    return render(request,"kategoriler/dag.html",context)

def yol(request):
    urunler=Urun.objects.filter(medicine='Yol-Yarış Bisikleti')
    markalar=urunler.order_by('brand').values_list('brand',flat=True).distinct()
    vitesler=urunler.order_by('gear').values_list('gear',flat=True).distinct()
    jantlar=urunler.order_by('rim').values_list('rim',flat=True).distinct()
    turu=urunler.order_by('medicine').values_list('medicine',flat=True).distinct()
    cinsiyetler=urunler.order_by('gender').values_list('gender',flat=True).distinct()
    context={
        "urunler":urunler,
        "markalar":markalar,
        "vitesler":vitesler,
        "jantlar":jantlar,
        "turu":turu,
        "cinsiyetler":cinsiyetler,
    }
    return render(request,"kategoriler/yol.html",context)

def sehir(request):
    urunler=Urun.objects.filter(medicine='Şehir Bisikleti')
    markalar=urunler.order_by('brand').values_list('brand',flat=True).distinct()
    vitesler=urunler.order_by('gear').values_list('gear',flat=True).distinct()
    jantlar=urunler.order_by('rim').values_list('rim',flat=True).distinct()
    turu=urunler.order_by('medicine').values_list('medicine',flat=True).distinct()
    cinsiyetler=urunler.order_by('gender').values_list('gender',flat=True).distinct()
    context={
        "urunler":urunler,
        "markalar":markalar,
        "vitesler":vitesler,
        "jantlar":jantlar,
        "turu":turu,
        "cinsiyetler":cinsiyetler,
    }
    return render(request,"kategoriler/sehir.html",context)

def cocuk(request):
    urunler=Urun.objects.filter(medicine='Çocuk Bisikleti')
    markalar=urunler.order_by('brand').values_list('brand',flat=True).distinct()
    vitesler=urunler.order_by('gear').values_list('gear',flat=True).distinct()
    jantlar=urunler.order_by('rim').values_list('rim',flat=True).distinct()
    turu=urunler.order_by('medicine').values_list('medicine',flat=True).distinct()
    cinsiyetler=urunler.order_by('gender').values_list('gender',flat=True).distinct()
    context={
        "urunler":urunler,
        "markalar":markalar,
        "vitesler":vitesler,
        "jantlar":jantlar,
        "turu":turu,
        "cinsiyetler":cinsiyetler,
    }
    return render(request,"kategoriler/cocuk.html",context)

def katlanabilir(request):
    urunler=Urun.objects.filter(medicine='Katlanabilir Bisiklet')
    markalar=urunler.order_by('brand').values_list('brand',flat=True).distinct()
    vitesler=urunler.order_by('gear').values_list('gear',flat=True).distinct()
    jantlar=urunler.order_by('rim').values_list('rim',flat=True).distinct()
    turu=urunler.order_by('medicine').values_list('medicine',flat=True).distinct()
    cinsiyetler=urunler.order_by('gender').values_list('gender',flat=True).distinct()
    context={
        "urunler":urunler,
        "markalar":markalar,
        "vitesler":vitesler,
        "jantlar":jantlar,
        "turu":turu,
        "cinsiyetler":cinsiyetler,
    }
    return render(request,"kategoriler/katlanabilir.html",context)

def cross(request):
    urunler=Urun.objects.filter(medicine='Cross Bisiklet')
    markalar=urunler.order_by('brand').values_list('brand',flat=True).distinct()
    vitesler=urunler.order_by('gear').values_list('gear',flat=True).distinct()
    jantlar=urunler.order_by('rim').values_list('rim',flat=True).distinct()
    turu=urunler.order_by('medicine').values_list('medicine',flat=True).distinct()
    cinsiyetler=urunler.order_by('gender').values_list('gender',flat=True).distinct()
    context={
        "urunler":urunler,
        "markalar":markalar,
        "vitesler":vitesler,
        "jantlar":jantlar,
        "turu":turu,
        "cinsiyetler":cinsiyetler,
    }
    return render(request,"kategoriler/cross.html",context)

def urunler(request):
    urunler=Urun.objects.all()
    markalar=urunler.order_by('brand').values_list('brand',flat=True).distinct()
    vitesler=urunler.order_by('gear').values_list('gear',flat=True).distinct()
    jantlar=urunler.order_by('rim').values_list('rim',flat=True).distinct()
    turu=urunler.order_by('medicine').values_list('medicine',flat=True).distinct()
    cinsiyetler=urunler.order_by('gender').values_list('gender',flat=True).distinct()
    context={
        "urunler":urunler,
        "markalar":markalar,
        "vitesler":vitesler,
        "jantlar":jantlar,
        "turu":turu,
        "cinsiyetler":cinsiyetler,
    }
    return render(request,"kategoriler/urunler.html",context)    
    
def ara(request):
    keyword=request.GET.get("keyword")
    
    if keyword:
        urunler=Urun.objects.filter(title__contains=keyword)
        urunlerFiltre=Urun.objects.all()
        markalar=urunlerFiltre.order_by('brand').values_list('brand',flat=True).distinct()
        vitesler=urunlerFiltre.order_by('gear').values_list('gear',flat=True).distinct()
        jantlar=urunlerFiltre.order_by('rim').values_list('rim',flat=True).distinct()
        turu=urunlerFiltre.order_by('medicine').values_list('medicine',flat=True).distinct()
        cinsiyetler=urunlerFiltre.order_by('gender').values_list('gender',flat=True).distinct()
        mesaj=(keyword+" ile ilgili arama sonuçları listelenmiştir.")
        context={
            "mesaj":mesaj,
            "urunler":urunler,
            "markalar":markalar,
            "vitesler":vitesler,
            "jantlar":jantlar,
            "turu":turu,
            "cinsiyetler":cinsiyetler,
    }
        if urunler:
            return render(request,"kategoriler/urunler.html",context)
        else:
            mesaj=(keyword+" ile ilgili sonuç bulunamamıştır.")
            return render(request,"kategoriler/urunler.html",{"mesaj":mesaj})
    elif keyword == "":
        mesaj=("Arama yapmak için karakter giriniz.")
        urunler=Urun.objects.all()
        markalar=urunler.order_by('brand').values_list('brand',flat=True).distinct()
        vitesler=urunler.order_by('gear').values_list('gear',flat=True).distinct()
        jantlar=urunler.order_by('rim').values_list('rim',flat=True).distinct()
        turu=urunler.order_by('medicine').values_list('medicine',flat=True).distinct()
        cinsiyetler=urunler.order_by('gender').values_list('gender',flat=True).distinct()
        context={
        "mesaj":mesaj,
        "markalar":markalar,
        "vitesler":vitesler,
        "jantlar":jantlar,
        "turu":turu,
        "cinsiyetler":cinsiyetler,
    }
        
        return render(request,"kategoriler/urunler.html",context)
    else:        
        urunler=Urun.objects.all()
        return render(request,"kategoriler/urunler.html",{"urunler":urunler})

def sepetim(request):
    urunler=Urun.objects.all()
    return render(request,"sepetim.html",{"urunler":urunler})

def urunEkle(request):
    form=UrunForm(request.POST or None,request.FILES or None)

    if form.is_valid():
        urun = form.save(commit=False)
        urun.author=request.user
        urun.save()
        messages.success(request,"Ürün Başarıyla Eklendi...")
        return redirect("bisiklet:kontrolPaneli")

    return render(request,"urun-islemleri/urunEkle.html",{"form":form})

@login_required(login_url="user:login")
def kontrolPaneli(request):
    urunler=Urun.objects.filter(author=request.user)
    print(urunler)
    #article=get_object_or_404(Article,id)
    context={
        "urunler":urunler
    }
    return render(request,"urun-islemleri/kontrolPaneli.html",context)

def urunDetay(request,id):
    #article=Article.objects.filter(id=id).first()
    urun=get_object_or_404(Urun,id=id)
    yorumlar=urun.yorumlar.all()
    return render(request,"urun-islemleri/urunDetay.html",{"urun":urun,"yorumlar":yorumlar})

def yorumEkle(request,id):
    urun=get_object_or_404(Urun,id=id)

    if request.method == "POST":
        yorum_author=request.POST.get("yorum_author")
        yorum_content=request.POST.get("yorum_content")
        print(yorum_content)

        newComment=Yorum(yorum_author=yorum_author,yorum_content=yorum_content)

        newComment.urun=urun

        newComment.save()
    
    return redirect(reverse("bisiklet:urunDetay",kwargs={"id":id}))

def urunGuncelle(request,id):
    
    urun=get_object_or_404(Urun,id=id)
    form=UrunForm(request.POST or None,request.FILES or None,instance=urun)

    if form.is_valid():
        urun = form.save(commit=False)
        urun.author=request.user
        urun.save()
        messages.success(request,"Ürün Başarıyla Güncellendi...")
        return redirect("bisiklet:kontrolPaneli")

    return render(request,"urun-islemleri/urunGuncelle.html",{"form":form})

def urunSil(request,id):
    urun=get_object_or_404(Urun,id=id)

    urun.delete()

    messages.success(request,"Ürün Başarıyla Silindi")

    return redirect("bisiklet:kontrolPaneli")