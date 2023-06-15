#include <stdio.h>
#include <string.h>
/* Declaración de cadenas de caracteres y asignación de valores. */
int main(void)
{
    char *cad0 = "Argentina";
    printf("%s\n", cad0);

    cad0 = "Brasil";
    printf("%s\n", cad0);

    char cad1[100]; // se reserva un espacio de 100 caracteres para cad1
    printf("Ingrese una cadena de caracteres: ");
    gets(cad1);
    printf("La cadena ingresada es: %s\n", cad1);

    char cad2[20] = "México";
    printf("%s\n", cad2);
    gets(cad2);
    printf("%s\n", cad2);

    strcpy(&cad2[10], "Guatemala"); // se utiliza la función strcpy para copiar la cadena "Guatemala" a partir del caracter 11 de cad2
    printf("%s\n", cad2);

    return 0;
}
