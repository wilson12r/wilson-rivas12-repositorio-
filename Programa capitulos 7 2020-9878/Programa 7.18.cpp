#include <stdio.h>
/* Cadena invertida resuelta en forma recursiva. */
void inverso(char *); 
int main(void)
{
char fra[50];
printf("\nIngrese la l�nea de texto: ");
gets(fra);
printf("\nEscribe la l�nea de texto en forma inversa: ");
inverso(fra);
}
void inverso(char *cadena)
/* La funci�n inverso obtiene precisamente el inverso de la cadena.*/
{
if (cadena[0]!= '\0')
{
inverso(&cadena[1]);
putchar(cadena[0]);
}
}
