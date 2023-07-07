#include <stdio.h>
#include <string.h>

/* Escuela.
El programa genera informaci�n estad�stica de los alumnos de una escuela. */

typedef struct /* Declaraci�n de la estructura alumno utilizando untypedef. */
{
int matricula;
char nombre[30];
float cal[5];
   
} alumno;

void Lectura(alumno[], int);
void F1(alumno *, int TAM); 
void F2(alumno *, int TAM);
void F3(alumno *, int TAM);

int main(void)
{
    alumno ARRE[50]; 
    int TAM;
    do
    {
    printf("Ingrese el tama�o del arreglo: ");
    scanf("%d", &TAM);
    } while (TAM > 50 || TAM < 1); 
    Lectura(ARRE, TAM);
    F1(ARRE, TAM);
    F2(ARRE, TAM);
    F3(ARRE, TAM);
}

void Lectura(alumno A[], int T)
/* La funci�n Lectura se utiliza para leer un arreglo unidimensional de tipo
   estructura alumno de T elementos. */
{
    int I, J;
    for (I = 0; I < T; I++)
    {
    printf("\nIngrese los datos del alumno %d", I + 1);
    printf("\nIngrese la matr�cula del alumno: ");
    scanf("%d", &A[I].matricula);
    getchar(); /* Limpia el buffer del teclado despu�s de la lectura de la matr�cula */
    printf("Ingrese el nombre del alumno:");
    fgets(A[I].nombre, 30, stdin);
    A[I].nombre[strcspn(A[I].nombre, "\n")] = 0; /* Elimina el salto de l�nea del final de la cadena */
    for (J = 0; J < 5; J++)
    {
printf("\tIngrese la calificaci�n %d del alumno %d: ", J + 1, I + 1);
scanf("%f", &A[I].cal[J]);
}
}
}
void F1(alumno A[], int T)
/* La funci�n F1 obtiene la matr�cula y el promedio de cada alumno. */
{
    int I, J;
    float SUM, PRO;
    for (I = 0; I < T; I++)
    {
printf("\nMatr�cula del alumno: %d", A[I].matricula);
SUM = 0.0;
for (J=0; J < 5; J++)
SUM = SUM + A[I].cal[J];
PRO = SUM / 5;
printf("\t\tPromedio: %.2f", PRO);
}
}
void F2(alumno A[], int T)
/* La funci�n F2 obtiene las matr�culas de los alumnos cuya calificaci�n en la
?tercera materia es mayor a 9. */
{
int I;
printf("\nAlumnos con calificaci�n en la tercera materia > 9");
for (I=0; I < T; I++)
if (A[I].cal[2] > 9)
printf("\nMatr�cula del alumno: %d", A[I].matricula);
}
void F3(alumno A[], int T)
/* Esta funci�n obtiene el promedio general del grupo de la materia 4. */
{
int I;
float PRO, SUM = 0.0;
for (I=0; I < T; I++)
SUM = SUM + A[I].cal[3];
PRO = SUM / T;
printf("\n\nPromedio de la materia 4: %.2f", PRO);
}
