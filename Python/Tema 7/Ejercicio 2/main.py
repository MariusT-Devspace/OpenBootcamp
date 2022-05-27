import time


def es_dia_laboral(dia):
    if dia in range(0, 5):
        return True
    else:
        return False


fecha = time.localtime()
dia_semana = fecha.tm_wday
hora = fecha.tm_hour
hora_ir = 19

if es_dia_laboral(dia_semana):
    if hora <= hora_ir:
        if hora == hora_ir:
            print("Hora de ir a casa!")
        else:
            print(f"Te quedan {hora_ir - hora} horas de trabajo.")
