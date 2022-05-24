

def is_prime(num):
    is_prime = True
    for i in range(2, num):
        if num % 2 == 0:
            is_prime = False
            break
    return is_prime

print("Introduce un número:")
numero = int(input())

if is_prime(numero):
    print(f"{numero} es primo")
else:
    print(f"{numero} no es primo")
