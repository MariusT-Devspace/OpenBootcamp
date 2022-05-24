import math

def calcula_area_triangulo(altura, base):
    return (altura * base) / 2

def calcula_area_circulo(radio):
    return math.pi * (radio ** 2)

altura = 7
base = 9
radio = 25

area_triangulo = calcula_area_triangulo(altura, base)
area_circulo = round(calcula_area_circulo(radio), 2)

print(f"El área de un triángulo de altura {altura} y base {base} es: {area_triangulo}")
print(f"El área de un círculo de radio {radio} es: {area_circulo}")