#include <stdio.h>
/* Calcula longitud en forma recursiva.
El programa calcula de manera recursiva la longitud de la cadena sin utilizar
?la funci�n strlen. */
int cuenta(char *); 
int main(void)
{
int i;
char cad[50];
printf("\nIngrese la cadena de caracteres: ");
gets(cad);
i = cuenta(cad);
printf("\nLongitud de la cadena: %d", i);
}
int cuenta(char *cadena)
/* Esta funci�n calcula la longitud de la cadena en forma recursiva*/
{
if (cadena[0] == '\0')
return 0;
else
return (1 + cuenta (&cadena[1]));
}
