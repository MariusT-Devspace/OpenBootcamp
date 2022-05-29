from functools import reduce

def main():
    lista = [2, 6, 9, 34, 51, 15, 22, 18, 24, 5]
    lista_filtrada = list(filter(lambda x: x % 2 != 0, lista))
    suma = reduce(lambda a, b: a + b, lista_filtrada)
    print(f"Lista: {lista}")
    print(f"Lista filtrada: {lista_filtrada}")
    print(f"Suma: {suma}")

if __name__ == '__main__':
    main()


