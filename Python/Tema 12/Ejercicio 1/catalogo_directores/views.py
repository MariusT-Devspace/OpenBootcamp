from django.shortcuts import render
from .models import Director


def peliculas(request):
    num_directores = Director.objects.all().count()
    lista_directores = Director.objects.all

    return render(
        request,
        'peliculas.html',
        context={
            'num_directores': num_directores,
            'lista_directores': lista_directores,
        }
    )

