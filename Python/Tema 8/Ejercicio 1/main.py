
def main():
    f = open('test file.txt', 'w+')
    data = "Primera línea\n"
    f.write(data)
    data = "Segunda línea\n"
    f.write(data)
    f.close()

if __name__ == '__main__':
    main()


