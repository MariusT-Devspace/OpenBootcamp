

def is_bisiesto(year):
    if year % 4 == 0:
        if year % 100 == 0:
            if year % 400 == 0:
                return True
            else:
                return False
        else:
            return True
    else:
        return False


print("Introduce el año:")
year = int(input())

if (is_bisiesto(year)):
    print(f"El año {year} es bisiesto")
else:
    print(f"El año {year} no es bisiesto")