import tkinter
from tkinter import ttk


def reset(self):
    global seleccionado_item
    global seleccionado_string
    seleccionado.set(0)
    seleccionado_item = ""
    seleccionado_string = seleccionado_text + seleccionado_item
    seleccionado_label.config(text=seleccionado_string)


def set_label(*args):
    global seleccionado_item
    global seleccionado_string
    seleccionado_item = lista[seleccionado.get()-1]
    seleccionado_string = seleccionado_text + seleccionado_item
    seleccionado_label.config(text=seleccionado_string)


window = tkinter.Tk()
window.geometry("300x300")
window.columnconfigure(0, weight=1)

main_frame = ttk.Frame(window, width=800, height=600)
main_frame.grid(column=0, row=0, sticky="")
frame1 = ttk.Frame(main_frame)
frame1['relief'] = 'sunken'
frame1.grid(column=0, row=0, sticky="W", pady=10)
frame2 = ttk.Frame(main_frame)
frame2.grid(column=0, row=1, sticky="W")

lista = ['Java', 'Python', 'C#', 'Go', 'Kotlin', 'C']
seleccionado = tkinter.IntVar()
seleccionado.set(0)
seleccionado_text = "Has seleccionado: "
seleccionado_item = ""
seleccionado_string = seleccionado_text + seleccionado_item
seleccionado.trace_add("write", set_label)

for index, item in enumerate(lista, 1):
    r = ttk.Radiobutton(frame1, text=item, value=index, variable=seleccionado)
    r.grid(column=0, row=index, padx=5, pady=5, sticky=tkinter.W)

seleccionado_label = ttk.Label(frame2, text=seleccionado_string, width=30)
seleccionado_label.grid(column=0, row=0, pady=10)

reset_button = ttk.Button(frame2, text="Reiniciar")
reset_button.grid(column=0, row=1, pady=5)
reset_button.bind('<Button-1>', reset)

window.mainloop()


