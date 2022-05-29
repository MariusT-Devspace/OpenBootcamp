import pickle


class Vehiculo:
    modelo = ""
    anyo = 0
    motor = "2.0 TDI"
    velocidad_maxima = 0
    cv = 105
    color = ""
    puertas = 5
    cilindrada = 0
    consumo = 0

    def __init__(self, modelo, anyo, motor, velocidad_maxima, cv, color, puertas, cilindrada, consumo):
        self.modelo = modelo
        self.anyo = anyo
        self.motor = motor
        self.velocidad_maxima = velocidad_maxima
        self.cv = cv
        self.color = color
        self.puertas = puertas
        self.cilindrada = cilindrada
        self.consumo = consumo


def main():

    vehiculo1 = Vehiculo('Audi A3 Sportback', 2016, "2.0 TDI", 218, 150, "Rojo", 5, 1968, 4)
    f = open('vehiculo1.bin', 'wb')
    pickle.dump(vehiculo1, f)
    f.close()

    f = open('vehiculo1.bin', 'rb')
    vehiculo = pickle.load(f)
    print("")
    print(f"Modelo: {vehiculo.modelo}")
    print(f"Año: {vehiculo.anyo}")
    print(f"Motor: {vehiculo.motor}")
    print(f"Velocidad máxima: {vehiculo.velocidad_maxima} km/h")
    print(f"CV: {vehiculo.cv}")
    print(f"Color: {vehiculo.color}")
    print(f"Puertas: {vehiculo.puertas}")
    print(f"Cilindrada: {vehiculo.cilindrada} cm3")
    print(f"Consumo: {vehiculo.consumo} l/100 km")

    f.close


if __name__ == '__main__':
    main()


