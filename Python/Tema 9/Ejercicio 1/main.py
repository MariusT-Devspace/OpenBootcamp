


def main():
    entrada = input("Introduzca los países separados por coma: ")
    paises = set(entrada.split(','))
    paises_ordenados = sorted(paises)
    print("Países: " + ','.join(paises_ordenados))



if __name__ == '__main__':
    main()
