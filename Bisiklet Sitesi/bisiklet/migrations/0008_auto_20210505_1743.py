# Generated by Django 3.1.7 on 2021-05-05 14:43

from django.db import migrations, models


class Migration(migrations.Migration):

    dependencies = [
        ('bisiklet', '0007_auto_20210502_1610'),
    ]

    operations = [
        migrations.AlterField(
            model_name='urun',
            name='gender',
            field=models.CharField(choices=[('seciniz', 'Seçiniz'), ('Erkek', 'Erkek'), ('Kadın', 'Kadın'), ('Erkek Çocuk', 'Erkek Çocuk'), ('Kız Çocuk', 'Kız Çocuk')], default='seciniz', max_length=50, verbose_name='Cinsiyet'),
        ),
        migrations.AlterField(
            model_name='urun',
            name='medicine',
            field=models.CharField(choices=[('seciniz', 'Seçiniz'), ('Dağ Bisikleti', 'Dağ Bisikleti'), ('Yol-Yarış Bisikleti', 'Yol-Yarış Bisikleti'), ('Şehir Bisikleti', 'Şehir Bisikleti'), ('Çocuk Bisikleti', 'Çocuk Bisikleti')], default='seciniz', max_length=50, verbose_name='Bisiklet Tipi'),
        ),
    ]
