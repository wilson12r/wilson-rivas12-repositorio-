#include <stdio.h>
/* Funciones para el manejo de caracteres de la biblioteca stdio.h */
int main(void)
{
char p1, p2, p3 = '$';
printf("\nIngrese un caracter: ");
p1=getchar(); /* Se utiliza la funci�n getchar para leer un caracter. */
putchar(p1); /* Se utiliza la funci�n putchar para escribir un
?caracter. */
printf("\n");
fflush(stdin);
printf("\nEl caracter p3 es: ");
putchar(p3);
/* Se utiliza la funci�n putchar para escribir el caracter almacenado en p3. */
printf("\n");
printf("\nIngrese otro caracter: ");
fflush(stdin);
scanf("%c", &p2);
printf("%c", p2);

}
