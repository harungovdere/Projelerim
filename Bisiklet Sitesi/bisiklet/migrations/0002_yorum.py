# Generated by Django 3.1.7 on 2021-04-23 16:52

from django.db import migrations, models
import django.db.models.deletion


class Migration(migrations.Migration):

    dependencies = [
        ('bisiklet', '0001_initial'),
    ]

    operations = [
        migrations.CreateModel(
            name='Yorum',
            fields=[
                ('id', models.AutoField(auto_created=True, primary_key=True, serialize=False, verbose_name='ID')),
                ('yorum_author', models.CharField(max_length=50, verbose_name='İsim')),
                ('yorum_content', models.CharField(max_length=200, verbose_name='Yorum')),
                ('yorum_date', models.DateTimeField(auto_now_add=True)),
                ('urun', models.ForeignKey(on_delete=django.db.models.deletion.CASCADE, related_name='yorumlar', to='bisiklet.urun', verbose_name='Ürün')),
            ],
            options={
                'ordering': ['-yorum_date'],
            },
        ),
    ]
