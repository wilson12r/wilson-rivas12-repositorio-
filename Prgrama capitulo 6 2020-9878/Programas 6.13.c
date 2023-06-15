#include <stdio.h>

/* Empresa textil.
El programa, al recibir un arreglo tridimensional que contiene informacion
sobre las ventas mensuales de tres departamentos de los ultimos ocho anos,
genera informacion estadistica valiosa para la empresa. */

const int MES = 12;
const int DEP = 3;
//const int AÑO = 8;
//void Lectura(float [MES][DEP][AÑO], int, int, int);
//void Funcion1(float [MES][DEP][AÑO], int, int, int);
//void Funcion2(float [MES][DEP][AÑO], int, int, int);
//void Funcion3(float [MES][DEP][AÑO], int, int, int);

void main(void)
{
/*float PRO[MES][DEP][AÑO];
//Lectura(PRO, MES, DEP, AÑO);
Funcion1(PRO, MES, DEP, 2);
Funcion2(PRO, MES, DEP, AÑO);
Funcion3(PRO, MES, DEP, AÑO);*/
}

void Lectura(float A[][DEP][AÑO], int F, int C, int P)
/*La funcion Lectura se utiliza para leer un arreglo tridimensional de tipo
real de F filas, C columnas y P planos de profundidad. */
{
int K, I, J;
for (K=0; K<P; K++)
for (I=0; I<F; I++)
for (J=0; J<C; J++)
{
printf("Año: %d\tMes: %d\tDepartamento: %d ", K+1, I+1, J+1);
scanf("%f", &A[I][J][K]);
}
}


void Funcion1(float A[][DEP][AÑO],int F, int C, int P)
/* Esta funcion se utiliza para obtener las ventas totales de la empresa en el segundo ano. */
{
int I, J;
float SUM = 0.0;
for (I=0; I<F; I++)
for (J=0; J<C; J++)
SUM += A[I][J][P-1];
printf("\n\nVentas totales de la empresa en el segundo año: %.2f", SUM);
}
void Funcion2(float A[][DEP][AÑO],int F, int C, int P)
/* Esta funcion se utiliza para obtener el departamento que tuvo las mayores
ventas en el ultima ano. genera ademas el importe de las ventas. */
{
int I, J;
float SUM1 = 0, SUM2 = 0, SUM3 = 0;
for (I=0; I<F; I++)
for (J=0; J<C; J++)
switch (J+1)
{
case 1: SUM1 += A[I][J][P-1];
break;
case 2: SUM2 += A[I][J][P-1];
break;
