

print('Introduce un número inicial:')
numero_inicial = int(input())
print('Introduce un número final:')
numero_final = int(input())
numeros_impares = []

for numero in range(numero_inicial, numero_final):
    if numero % 2 > 0:
        numeros_impares.append(numero)

print('Números impares:')
print(numeros_impares)