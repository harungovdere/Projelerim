# Generated by Django 3.1.7 on 2021-05-02 13:10

from django.db import migrations, models


class Migration(migrations.Migration):

    dependencies = [
        ('bisiklet', '0006_auto_20210502_1604'),
    ]

    operations = [
        migrations.AlterField(
            model_name='urun',
            name='gender',
            field=models.CharField(choices=[('seciniz', 'Seçiniz'), ('erkek', 'Erkek'), ('kadın', 'Kadın'), ('erkekcocuk', 'Erkek Çocuk'), ('kızcocuk', 'Kız Çocuk')], default='seciniz', max_length=50, verbose_name='Cinsiyet'),
        ),
        migrations.AlterField(
            model_name='urun',
            name='medicine',
            field=models.CharField(choices=[('seciniz', 'Seçiniz'), ('dag', 'Dağ Bisikleti'), ('yol', 'Yol-Yarış Bisikleti'), ('sehir', 'Şehir Bisikleti'), ('cocuk', 'Çocuk Bisikleti')], default='seciniz', max_length=50, verbose_name='Bisiklet Tipi'),
        ),
    ]
