import tkinter
from tkinter import ttk


window = tkinter.Tk()
window.geometry("300x300")
window.columnconfigure(0, weight=1)

main_frame = ttk.Frame(window)
main_frame.columnconfigure(0, weight=1)
main_frame.rowconfigure(0, weight=1)
main_frame.rowconfigure(1, weight=3)
main_frame.grid(column=0, row=0, sticky="NSWE")

label_text = "¿Cuál es tu bebida preferida?"
label = ttk.Label(main_frame, text=label_text, width=50)
label.grid(column=0, row=0, sticky='W', pady=10)

list = ['Coca cola', 'Fanta', 'Radler', 'Ladrón de Manzanas',
        'Tinto de Verano', 'Sprite']
list_var = tkinter.StringVar(value=list)
listbox = tkinter.Listbox(main_frame, listvariable=list_var, selectbackground='#c4c7cc', activestyle='none')
listbox.grid(column=0, row=1, sticky='NW', pady=10)

window.mainloop()
