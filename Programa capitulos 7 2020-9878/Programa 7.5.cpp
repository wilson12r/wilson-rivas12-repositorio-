#include <stdio.h>
#include <stdlib.h>
/* Funciones para el manejo de caracteres de la biblioteca stdlib.h. */
int main(void)
{
int i;
double d;
long l;
char cad0[20], *cad1;
printf("\nIngrese una cadena de caracteres: ");
gets(cad0);
i = atoi(cad0);
/* La función atoi convierte una cadena de caracteres que contiene números
a ?un valor de tipo entero. */
printf("\n%s \t %d", cad0, i+3);
/* Se imprime el valor de i+3 para demostrar que i ya fue convertido a un
?entero.*/
printf("\nIngrese una cadena de caracteres: ");
gets(cad0);
d = atof(cad0);
/* La función atof convierte una cadena de caracteres que contiene números
?reales a un valor de tipo double. */
printf("\n%s \t %.2lf ", cad0, d+1.50);
d = strtod(cad0, &cad1);
/* La función strtod convierte una cadena de caracteres que contiene números
?reales a un valor de tipo double. */
printf("\n%s \t %.2lf", cad0, d+1.50);
puts(cad1);
l = atol(cad0);
/* La función atol convierte una cadena de caracteres que contiene números a
?un valor de tipo long.*/
printf("\n%s \t %ld ", cad0, l+10);
l = strtol(cad0, &cad1, 0);
/* La función strtol convierte una cadena de caracteres que contiene números a
?un valor de tipo long.*/
printf("\n%s \t %ld", cad0, l+10);
puts(cad1);
}
