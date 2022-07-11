import pandas as pd




if __name__ == '__main__':

    contacts_list = pd.read_excel(r'C:\Users\windo\OpenBootcamp\30 Retos Diarios\Reto 1\contacts.xlsx',
                                  header = 0)
    series = pd.Series(contacts_list["email"]).unique()
    print(series)





