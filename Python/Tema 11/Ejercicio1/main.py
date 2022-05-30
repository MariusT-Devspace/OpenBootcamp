import sqlite3

conn = sqlite3.connect('ejercicio1.db')
cursor = conn.cursor()
query_create_table = '''CREATE TABLE if not exists Alumnos(
                        id INTEGER PRIMARY KEY,
                        nombre TEXT NOT NULL,
                        apellido TEXT NOT NULL
                    )'''

alumnos_list = [('Nestor', 'Lorente'), ('Mia', 'Esteban'), ('Abel', 'Salmeron'),
                ('Ivan', 'Zamora'), ('Ines', 'Caballero'), ('Ana-Maria', 'Tejera'),
                ('Marta', 'Marti'), ('Monserrat', 'Otero')]

query_insert_data = '''INSERT INTO Alumnos (nombre, apellido)
                       VALUES (?, ?)'''

query_show_data = '''SELECT nombre, apellido
                     FROM Alumnos'''

cursor.execute(query_create_table)

for alumno in alumnos_list:
    cursor.execute(query_insert_data, (alumno[0], alumno[1]))

conn.commit()

cursor.execute(query_show_data)
rows = cursor.fetchall()

print("")
print("Alumnos:")
print("")

for row in rows:
    print(f"{row[0]} {row[1]}")

cursor.close()
conn.close()
