using System;
using System.Collections.Generic;
using System.Text;

namespace Calculadora {

    //======================================================
    //                   Operações Matemáticas
    //======================================================

    public static class Somar {
        public static double Soma(this double x, double y) {
            return x + y;
        }
    }

    public static class Subtrair {
        public static double Sub(this double x, double y) {
            return x - y;
        }
    }

    public static class Multiplicar {
        public static double Mult(this double x, double y) {
            return x * y;
        }
    }

    public static class Dividir {
        public static double Div(this double x, double y) {
            return x / y;
        }
    }

    //======================================================
    //                  Manipulção de Texto
    //======================================================

    public static class ColorirTexto {
        public static void setColor(this string texto, ConsoleColor cor, bool foregroundColor = true, bool inLine = true) {
            
            
            if (foregroundColor) Console.ForegroundColor = cor;
            else Console.BackgroundColor = cor;

            if (inLine) Console.Write(texto);
            else Console.WriteLine(texto);
          

            Console.ResetColor();
        }
    }

    public class Teclas {

        public static void ifEnterPress() {
            var teclasCalculadora = CalculadoraModelo.teclasCalculadora;
            var posicaoTeclaCalc = CalculadoraModelo.posicaoTeclaCalc;
            var tecla = CalculadoraModelo.tecla;

            if (CalculadoraModelo.tecla == ConsoleKey.Enter) {
                Console.WriteLine(tecla);

                if (teclasCalculadora[posicaoTeclaCalc].Contains("0")) tecla = ConsoleKey.D0;
                if (teclasCalculadora[posicaoTeclaCalc].Contains("1")) tecla = ConsoleKey.D1;
                if (teclasCalculadora[posicaoTeclaCalc].Contains("2")) tecla = ConsoleKey.D2;
                if (teclasCalculadora[posicaoTeclaCalc].Contains("3")) tecla = ConsoleKey.D3;
                if (teclasCalculadora[posicaoTeclaCalc].Contains("4")) tecla = ConsoleKey.D4;
                if (teclasCalculadora[posicaoTeclaCalc].Contains("5")) tecla = ConsoleKey.D5;
                if (teclasCalculadora[posicaoTeclaCalc].Contains("6")) tecla = ConsoleKey.D6;
                if (teclasCalculadora[posicaoTeclaCalc].Contains("7")) tecla = ConsoleKey.D7;
                if (teclasCalculadora[posicaoTeclaCalc].Contains("8")) tecla = ConsoleKey.D8;
                if (teclasCalculadora[posicaoTeclaCalc].Contains("9")) tecla = ConsoleKey.D9;
                if (teclasCalculadora[posicaoTeclaCalc].Contains("+")) tecla = ConsoleKey.Add;
                if (teclasCalculadora[posicaoTeclaCalc].Contains("-")) tecla = ConsoleKey.Subtract;
                if (teclasCalculadora[posicaoTeclaCalc].Contains("X")) tecla = ConsoleKey.Multiply;
                if (teclasCalculadora[posicaoTeclaCalc].Contains("÷")) tecla = ConsoleKey.Divide;
                if (teclasCalculadora[posicaoTeclaCalc].Contains("=")) tecla = ConsoleKey.OemPlus;
                if (teclasCalculadora[posicaoTeclaCalc].Contains("<x]")) tecla = ConsoleKey.Backspace;

                CalculadoraModelo.tecla = tecla;

            }
        }
        public static void lerNumeroDigitado(){
            var stringNumAcumulado = CalculadoraModelo.stringNumAcumulado;
            var teclasCalculadora = CalculadoraModelo.teclasCalculadora;
            var tecla = CalculadoraModelo.tecla;

            if (stringNumAcumulado != "" && CalculadoraModelo.teclaNum(tecla)) { // Função para retornar tecla pressionada na interface da calculadora
               
                for (int i = 0; i < teclasCalculadora.Length; i++) {

                    if (teclasCalculadora[i].Contains(stringNumAcumulado.
                        Substring(stringNumAcumulado.Length - 1))) {

                        CalculadoraModelo.posicaoTeclaCalc = i;
                        break;
                    }
                }

            }
        }
    }

}
