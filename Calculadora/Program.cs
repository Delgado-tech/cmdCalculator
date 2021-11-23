using System;
using System.Collections;
using System.Text;

namespace Calculadora {


    public class Calculadora {
        private static double Valor = 0;
        public static double ValorAcumulado = 0;
        private static string Tipo;
        //private static bool ValorStarted = false;

        public Calculadora(double valor, string tipo) {
            Valor = valor;
            Tipo = tipo;
        }
        public Calculadora() {
        }

        public static void Calculando() {

            if (Tipo == "Add" || Tipo == "+") {
                ValorAcumulado = ValorAcumulado.Soma(Valor);
            } else if (Tipo == "Subtract" || Tipo == "-") {
                ValorAcumulado = ValorAcumulado.Sub(Valor);
            } else if (Tipo == "Multiply" || Tipo == "X") {
                ValorAcumulado = ValorAcumulado.Mult(Valor);
            } else if (Tipo == "Divide" || Tipo == "÷") {
                ValorAcumulado = ValorAcumulado.Div(Valor);
            }


        }



    }
    class CalculadoraModelo {
        public static bool isFirstOperation = true;
        public static bool showResult = false;
        public static bool operationEnded = false;

        public static string stringNumAcumulado = "";
        public static string teclaTipo = "";
        public static string armazenamentoValor1 = "";
        public static string armazenamentoValor2 = "";
        public static string operador = "";
        public static double numAcumulado = 0;

        public static string[] teclasCalculadora = new string[24] {
                      "s[̲̅ ̲̅]",    "[̲̅ ̲̅]" ,   "[̲̅ ̲̅]",  "e[ <x] ]",
                      "s[̲̅ ̲̅]",    "[̲̅ ̲̅]",    "[̲̅ ̲̅]",  "e[  ÷  ]",
                    "s[  7  ]","[  8  ]","[  9  ]","e[  X  ]",
                    "s[  4  ]","[  5  ]","[  6  ]","e[  -  ]",
                    "s[  1  ]","[  2  ]","[  3  ]","e[  +  ]",
                      "s[̲̅ ̲̅]",  "[  0  ]",  "[̲̅ ̲̅]",  "e[  =  ]"};
        public static int posicaoTeclaCalcDefault = 8;
        public static int posicaoTeclaCalc = posicaoTeclaCalcDefault;

        public static ConsoleKey tecla;



        public static bool teclaNum(ConsoleKey tecla) {
            var teclaIsNum = false;
            if ((tecla == ConsoleKey.NumPad0 || tecla == ConsoleKey.NumPad1 || tecla == ConsoleKey.NumPad2 ||
                tecla == ConsoleKey.NumPad3 || tecla == ConsoleKey.NumPad4 || tecla == ConsoleKey.NumPad5 ||
                tecla == ConsoleKey.NumPad6 || tecla == ConsoleKey.NumPad7 || tecla == ConsoleKey.NumPad8 ||
                tecla == ConsoleKey.NumPad9 ||
                tecla == ConsoleKey.D0 || tecla == ConsoleKey.D1 || tecla == ConsoleKey.D2 ||
                tecla == ConsoleKey.D3 || tecla == ConsoleKey.D4 || tecla == ConsoleKey.D5 ||
                tecla == ConsoleKey.D6 || tecla == ConsoleKey.D7 || tecla == ConsoleKey.D8 ||
                tecla == ConsoleKey.D9) && stringNumAcumulado.Length < 11) {


                teclaIsNum = true;
            }
            return teclaIsNum;
        }

        public static bool teclaSeta(ConsoleKey tecla) {
            bool teclaIsSeta = false;

            if (tecla == ConsoleKey.DownArrow || tecla == ConsoleKey.UpArrow || tecla == ConsoleKey.LeftArrow ||
                tecla == ConsoleKey.RightArrow) {

                //=================================================================================
                if (tecla == ConsoleKey.LeftArrow) {

                    if (teclasCalculadora[posicaoTeclaCalc].Contains("s")) {
                        posicaoTeclaCalc += 3;
                    } else { posicaoTeclaCalc--; }

                }


                if (tecla == ConsoleKey.RightArrow) {

                    if (teclasCalculadora[posicaoTeclaCalc].Contains("e")) {
                        posicaoTeclaCalc -= 3;
                    } else { posicaoTeclaCalc++; }

                }


                if (tecla == ConsoleKey.UpArrow) {
                    posicaoTeclaCalc -= 4;
                    if (posicaoTeclaCalc < 0) {
                        posicaoTeclaCalc += 24;
                    }

                }


                if (tecla == ConsoleKey.DownArrow) {
                    posicaoTeclaCalc += 4;
                    if (posicaoTeclaCalc >= teclasCalculadora.Length) {
                        posicaoTeclaCalc -= 24;
                    }

                }
                //=================================================================================

                interfaceCalculadora();
                teclaIsSeta = true;
            }

            return teclaIsSeta;
        }

        public static void addNumGetResultado() { // Função para inserir valor final e mostras resultado
            for (bool i = true; i == true;) {
                save.SaveToFile();
                Console.Clear();

                Teclas.lerNumeroDigitado();
                interfaceCalculadora();
                tecla = Console.ReadKey().Key;

                Teclas.ifEnterPress();

                if (tecla == ConsoleKey.Backspace) {
                    if (stringNumAcumulado != "") {
                        stringNumAcumulado = stringNumAcumulado.Remove(stringNumAcumulado.Length - 1);
                        armazenamentoValor2 = stringNumAcumulado;
                    }
                    posicaoTeclaCalc = 3;
                }

                if (teclaNum(tecla)) {
                    stringNumAcumulado += Convert.ToString(tecla).Replace("NumPad", "").Replace("D", "");
                    armazenamentoValor2 = stringNumAcumulado;
                }

                if (teclaSeta(tecla)) {
                    continue;
                }

                if (tecla == ConsoleKey.OemPlus) {
                    double.TryParse(stringNumAcumulado, out numAcumulado);
                    new Calculadora(numAcumulado, teclaTipo);
                    Calculadora.Calculando();

                    showResult = true;
                    Console.Clear();
                    save.SaveToFile();

                    showResult = false;
                    operationEnded = true;
                    armazenamentoValor1 = Calculadora.ValorAcumulado.ToString();
                    armazenamentoValor2 = "";
                    operador = "";
                    posicaoTeclaCalc = posicaoTeclaCalcDefault;
                    interfaceCalculadora();

                    break;

                }
            }
            stringNumAcumulado = "";


        }


        public static void interfaceCalculadora() { // Função para gerar a estrutura da calculadora visualmente

            string CalculatorHead;
            string CalculatorHeadBorder = "▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒";
            string CalculatorHeadCenter = "▒        {0} {1} {2}       ▒";


            //---------------------------------------------------------
            //---------------------------------------------> Formatação 
            while ((CalculatorHeadCenter.Length + armazenamentoValor1.Length + operador.Length +
                armazenamentoValor2.Length) < 39 && armazenamentoValor1 != "") {

                if (operador == "" && armazenamentoValor1.Length < 11) {
                    CalculatorHeadCenter = CalculatorHeadCenter.Insert(CalculatorHeadCenter.IndexOf("{2}") - 5, " ");
                } else {
                    CalculatorHeadCenter = CalculatorHeadCenter.Insert(CalculatorHeadCenter.IndexOf("{2}") + 3, " ");
                }
            }
            bool changeRemoveSide = true;

            while ((CalculatorHeadCenter.Length + armazenamentoValor1.Length + operador.Length
                + armazenamentoValor2.Length) > 39 && armazenamentoValor1 != "") {
                if (changeRemoveSide) {

                    CalculatorHeadCenter = CalculatorHeadCenter.Remove(1, 1);

                    changeRemoveSide = false;
                } else {
                    CalculatorHeadCenter = CalculatorHeadCenter.Remove(CalculatorHeadCenter.IndexOf("{2}") + 3, 1);

                    changeRemoveSide = true;
                }
            }

            CalculatorHead = CalculatorHeadBorder + "\n" + CalculatorHeadCenter + "\n" + CalculatorHeadBorder;
            //---------------------------------------------> Formatação
            //---------------------------------------------------------

            Console.WriteLine(CalculatorHead,
                armazenamentoValor1 == "" ? "Calculadora" : armazenamentoValor1, operador, armazenamentoValor2);


            var separador = 0;
            for (int i = 0; i < teclasCalculadora.Length; i++) {
                if (teclasCalculadora[i].Contains("s")) {
                    Console.Write("▒");
                }
                if (posicaoTeclaCalc == i) {
                    teclasCalculadora[i].Replace("s", "").Replace("e", "").Replace("[ ", " [").Replace(" ]", "] ").
                        setColor(ConsoleColor.Cyan);
                } else if (teclasCalculadora[i].Contains("[̲̅ ̲̅]")) {
                    teclasCalculadora[i].Replace("s", "").Replace("e", "").setColor(ConsoleColor.DarkGray);
                } else {
                    teclasCalculadora[i].Replace("s", "").Replace("e", "").setColor(ConsoleColor.DarkCyan);
                }

                if (teclasCalculadora[i].Contains("e")) {
                    Console.Write("▒");
                }

                separador++;
                if (separador > 3) {
                    Console.Write("\n");
                    separador = 0;
                }

            }
            Console.WriteLine("▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
            Console.WriteLine("▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
            Console.WriteLine("▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
        }

            
        public static void Main(string[] args) {

            save.loadSave();

            bool loop = true;
            while (loop == true) {
                save.SaveToFile();
                Console.Clear();
                operationEnded = false;

                Teclas.lerNumeroDigitado();

                interfaceCalculadora();
                tecla = Console.ReadKey().Key;


                if (tecla == ConsoleKey.Escape) {
                    Environment.Exit(0);
                }

                Teclas.ifEnterPress();

                if (tecla == ConsoleKey.Backspace) {
                    if (stringNumAcumulado != "") {
                        stringNumAcumulado = stringNumAcumulado.Remove(stringNumAcumulado.Length - 1);
                        armazenamentoValor1 = stringNumAcumulado;
                    }
                    posicaoTeclaCalc = 3;
                    continue;
                }


                if (teclaNum(tecla)) {
                    stringNumAcumulado += Convert.ToString(tecla).Replace("NumPad", "").Replace("D", "");
                    armazenamentoValor1 = stringNumAcumulado;
                    isFirstOperation = true;
                    Calculadora.ValorAcumulado = 0;
                    continue;
                }

                if (teclaSeta(tecla)) {
                    continue;
                }

                if ((stringNumAcumulado.Length > 0 || isFirstOperation == false) && armazenamentoValor1.Length < 12) {

                    if (tecla == ConsoleKey.Subtract || tecla == ConsoleKey.Add || tecla == ConsoleKey.Multiply ||
                            tecla == ConsoleKey.Divide) {


                        if (tecla == ConsoleKey.Subtract) operador = "-";
                        if (tecla == ConsoleKey.Add) operador = "+";
                        if (tecla == ConsoleKey.Divide) operador = "÷";
                        if (tecla == ConsoleKey.Multiply) operador = "X";


                        for (int i = 0; i < teclasCalculadora.Length; i++) {
                            if (teclasCalculadora[i].Contains(operador) && operador != "") {
                                posicaoTeclaCalc = i;
                                interfaceCalculadora();
                            }
                        }

                        if (teclaSeta(tecla)) {
                            continue;
                        }

                        double.TryParse(stringNumAcumulado, out numAcumulado);
                        teclaTipo = Convert.ToString(tecla);

                        stringNumAcumulado = "";

                        if (!isFirstOperation) {
                            addNumGetResultado();
                            continue;
                        } else {
                            Calculadora.ValorAcumulado = numAcumulado;
                            isFirstOperation = false;

                            addNumGetResultado();

                            continue;
                        }
                    }
                }


            }
        }

    }
}
