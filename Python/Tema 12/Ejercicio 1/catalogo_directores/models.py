import uuid

from django.db import models


class Pelicula(models.Model):
    título = models.CharField(max_length=60)
    año = models.IntegerField()
    sinopsis = models.CharField(max_length=1000)


    def __str__(self):
        return self.título


class Director(models.Model):
    nombre = models.CharField(max_length=50)
    apellido = models.CharField(max_length=50)
    peliculas = models.ManyToManyField(Pelicula)

    def __str__(self):
        return self.nombre + " " + self.apellido

