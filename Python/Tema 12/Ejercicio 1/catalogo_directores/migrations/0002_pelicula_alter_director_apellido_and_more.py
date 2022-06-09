# Generated by Django 4.0.4 on 2022-05-30 13:42

from django.db import migrations, models


class Migration(migrations.Migration):

    dependencies = [
        ('catalogo_directores', '0001_initial'),
    ]

    operations = [
        migrations.CreateModel(
            name='Pelicula',
            fields=[
                ('id', models.BigAutoField(auto_created=True, primary_key=True, serialize=False, verbose_name='ID')),
                ('titulo', models.CharField(max_length=60)),
                ('año', models.IntegerField(max_length=4)),
                ('descripcion', models.CharField(max_length=1000)),
            ],
        ),
        migrations.AlterField(
            model_name='director',
            name='apellido',
            field=models.CharField(max_length=50),
        ),
        migrations.AlterField(
            model_name='director',
            name='nombre',
            field=models.CharField(max_length=50),
        ),
        migrations.AddField(
            model_name='director',
            name='peliculas',
            field=models.ManyToManyField(to='catalogo_directores.pelicula'),
        ),
    ]