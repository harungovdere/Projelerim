var adSoyad = document.getElementById("floatingInputAdSoyad").value,
    kullaniciAdi = document.getElementById("floatingInputKullanici").value,
    email = document.getElementById("floatingInputEmail").value,
    sifre = document.getElementById("floatingInputPassword").value;

var girisYapildi = localStorage.getItem('girisDegeri');

function emailIlet() {
    return localStorage.getItem('email');
}

if (girisYapildi == "true") {
    kullaniciProfili();
    document.getElementById("emailProfil").value = localStorage.getItem('email');
} else {
    localStorage.setItem('girisDegeri', 'false')
}


function girisDurumu(girisDurum, kulAdi) {
    if (girisDurum == true && kulAdi != null) {
        kullaniciProfili();
        localStorage.setItem('kullaniciAdi', kulAdi);
    }

}


function doluMu() {
    if (adSoyad != null && kullaniciAdi != null && email != null && sifre != null) {
        return true;
    } else {
        return false;
    }
}

function Onay() {
    adSoyad = document.getElementById("floatingInputAdSoyad").value,
        kullaniciAdi = document.getElementById("floatingInputKullanici").value,
        email = document.getElementById("floatingInputEmail").value,
        sifre = document.getElementById("floatingInputPassword").value;
    var dolu = doluMu();
    if (dolu == true) {
        if (adSoyad == "1" && kullaniciAdi == "1" && email == "1" && sifre == "1") {
            alert("Kaydınız başarıyla gerçekleştirilmiştir");
            modalGizle();
        }
    }
}
function modalGizle() {
    var myModalEl = document.getElementById('kayitOl')
    var kayitOl = bootstrap.Modal.getInstance(myModalEl)
    kayitOl.hide();
    kullaniciProfili();
}

//Giriş yapıldıktan sonra profil resminin ekrana gelmesi
function kullaniciProfili() {
    var btnKayitOl = document.getElementById("btnKayitOl");
    btnKayitOl.style.display = 'none';
    var btnGirisYap = document.getElementById("btnGirisYap");
    btnGirisYap.style.display = 'none';
    var profilKismi = document.getElementById("profil");
    profilKismi.style.display = 'block';


}
function cikis() {
    var btnKayitOl = document.getElementById("btnKayitOl");
    btnKayitOl.style.display = 'block';
    var btnGirisYap = document.getElementById("btnGirisYap");
    btnGirisYap.style.display = 'block';
    var profilKismi = document.getElementById("profil");
    profilKismi.style.display = 'none';
    localStorage.setItem('girisDegeri', "false");
    localStorage.setItem('email', "");
    window.location.replace("/");
}

function doluMuG() {
    var emailG = document.getElementById("floatingInputEmailG").value,
        sifreG = document.getElementById("floatingInputPasswordG").value;
    if (emailG != null && sifreG != null) {
        return true;
    } else {
        return false;
    }
}

async function girisYap() {
    var emailG = document.getElementById("floatingInputEmailG").value,
        sifreG = document.getElementById("floatingInputPasswordG").value;
    localStorage.setItem('email', emailG)
    var myModalEl = document.getElementById('girisYap')
    var girisYap = bootstrap.Modal.getInstance(myModalEl)
    girisYap.hide();
}

function modalGizleG() {
    var myModalEl = document.getElementById('girisYap')
    var girisYap = bootstrap.Modal.getInstance(myModalEl)
    girisYap.hide();
    kullaniciProfili();
}
function kayitOlunaGit() {
    var girisModali = document.getElementById('girisYap'),
        girisYap = bootstrap.Modal.getOrCreateInstance(girisModali),
        kayitModali = document.getElementById('kayitOl'),
        kayitOl = bootstrap.Modal.getOrCreateInstance(kayitModali);
    girisYap.hide();
    kayitOl.show();

}
function girisYapaGit() {
    var girisModali = document.getElementById('girisYap'),
        girisYap = bootstrap.Modal.getOrCreateInstance(girisModali),
        kayitModali = document.getElementById('kayitOl'),
        kayitOl = bootstrap.Modal.getOrCreateInstance(kayitModali);
    kayitOl.hide();
    girisYap.show();
}

function emailAyarla() {
    email = document.getElementById('floatingInputEmailP').value;
    localStorage.setItem('email', email);
}