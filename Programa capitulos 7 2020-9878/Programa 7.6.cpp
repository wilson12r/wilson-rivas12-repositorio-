#include <stdio.h>
#include <string.h>
/* Funciones de la biblioteca string.h para el manejo de cadenas de
caracteres. */
int main(void)
{
char (*cad0) = "Hola M�xico";
char cad1[20], cad2[20], cad3[20] = " buenos d�as!!!";
strcpy(cad1, cad0);
/* La funci�n strcpy permite copiar una cadena de caracteres completa. En este
?caso se copia la cadena cad0 a cad1. */
printf("\nPrueba de la funci�n strcpy. Se copia la cadena cad0 a cad1:?%s\n", cad1);
strcpy(cad1, cad3);
printf("\nPrueba de la funci�n strcpy. Se copia la cadena cad3 a cad1:?%s\n", cad1);
strcpy(cad1, "XX");
printf("\nPrueba de la funci�n strcpy. Se copia la cadena XX a cad1:?%s\n", cad1);
strncpy(cad2, cad0, 4);
cad2[4] = '\0';
/* La funci�n strncpy permite copiar un n�mero determinado de caracteres a
?otra cadena de caracteres.*/
printf("\nPrueba de la funci�n strncpy. Se copian 4 caracteres de cad0 a?cad2: %s\n",cad2);
strncpy(cad2, cad3, 3);
cad2[3] = '\0';
printf("\nPrueba de la funci�n strncpy. Se copian 3 caracteres de cad3 a?cad2: %s\n",cad2);
strcat(cad0, cad3);
/* La funci�n strcat permite incorporar una cadena de caracteres a otra
?cadena dada. */
printf("\nPrueba de la funci�n strcat. Se incorpora la cadena cad3 a cad0:?%s\n", cad0);
strcat(cad1,"YY");
printf("\nPrueba de la funci�n strcat. Se incorpora la cadena YY a cad1:?%s\n", cad1);
strcat(cad2, "");
strncat(cad2, cad0, 4);
printf("\nPrueba de la funci�n strncat. Se incorporan 4 caracteres de cad0?a cad2:%s\n", cad2);
/* La funci�n strncat permite incorporar un n�mero determinado de caracteres
?a una cadena.*/
cad0 = strstr(cad0, "M�xico");
printf("\nPrueba de la funci�n strstr. Se trata de localizar la cadena?M�xico dentro de cad0: %s\n", cad0);
/* La funci�n strstr se utiliza para localizar una cadena de caracteres dentro
?de otra cadena. */
cad0 = strstr(cad0, "Guatemala");
printf("\nPrueba de la funci�n strstr. Se trata de localizar la cadena?Guatemala dentro de cad0: %s\n", cad0);
}
