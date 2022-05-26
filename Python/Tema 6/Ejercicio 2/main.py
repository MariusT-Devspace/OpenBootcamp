
class Alumno:
    _nombre = ""
    _nota = None

    def __init__(self, nombre, nota):
        self._nombre = nombre
        self._nota = nota

    def get_nombre(self):
        return self._nombre

    def get_nota(self):
        return self._nota

    def is_aprobado(self):
        if self._nota >= 5:
            return True
        else:
            return False

alumno1 = Alumno("María Pérez Hernandez", 7)
alumno2 = Alumno("José Rodríguez Casas", 3)
alumno3 = Alumno("Fernando Miguel Ortíz", 8)
alumnos = [alumno1, alumno2, alumno3]

for alumno in alumnos:
    if alumno.is_aprobado():
        print(f"{alumno.get_nombre()} ha aprobado con un {alumno.get_nota()}")
    else:
        print(f"{alumno.get_nombre()} ha suspendido con un {alumno.get_nota()}")
