

class Vehiculo:
    color = ""
    ruedas = 4
    puertas = 5

    def __init__(self, color, ruedas, puertas):
        self.color = color
        self.ruedas = ruedas
        self.puertas = puertas


class Coche(Vehiculo):
    velocidad = None
    cilindrada = None

    def __init__(self, color, ruedas, puertas, velocidad, cilindrada):
        super().__init__(color, ruedas, puertas)
        self.velocidad = velocidad
        self.cilindrada = cilindrada

coche1 = Coche("Azul", 4, 2, 120, 2)

print("")
print("Características del coche:")
print("")
print(f"Color: {coche1.color}")
print(f"Puertas: {coche1.puertas}")
print(f"Velocidad máxima: {coche1.velocidad}")
print(f"Cilindrada: {coche1.cilindrada}")
print(f"Ruedas: {coche1.ruedas}")