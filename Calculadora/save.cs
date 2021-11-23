using System;
using System.IO;

namespace Calculadora {
    class save : CalculadoraModelo {
        public static string directory = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\..\")); // Retorna a Pasta bin
        public static string path = directory + "save.txt";
        public static void SaveToFile() {


            string val1 = "???";
            string val2 = "???";
            string result = "???";
            string operadorSave = "???";

            if (!(armazenamentoValor1 == "")) val1 = armazenamentoValor1;
            if (!(armazenamentoValor2 == "")) val2 = armazenamentoValor2;
            if (!(operador == "")) operadorSave = operador;
            if (!(armazenamentoValor1 == "") && !(armazenamentoValor2 == "") && !(operador == "") && showResult)
                result = Convert.ToString(Calculadora.ValorAcumulado);


            if (!File.Exists(path)) {
                using (StreamWriter sw = File.CreateText(path)) sw.WriteLine("Calculator Log \n<§>");
            }

            if (File.Exists(path) && ((stringNumAcumulado.Length == 0 && isFirstOperation) || operationEnded)) {

                using (StreamWriter sw = File.AppendText(path)) {
                    sw.WriteLine("[§dt]{0} ", DateTime.Now);
                    sw.WriteLine("[§v1]{0} [§op]{1} [§v2]{2} ", val1, operadorSave, val2);
                    sw.WriteLine("[§=]{0} ", result);
                    sw.WriteLine("<§>");
                }
            }

            if (File.Exists(path) && (stringNumAcumulado.Length > 0 || isFirstOperation == false)) {

                string[] saveFileContent = File.ReadAllText(path).Split("<§>");
                string[] lastUse = saveFileContent[^2].Split(" ");

                /*LastUse number position*/
                {/* 
                ===========================================
                 * [0] => Date
                 * [1] => Hours
                 * [2] => First Value
                 * [3] => Operator Sinal
                 * [4] => Second Value
                 * [5] => Result of Operation
                ===========================================*/
                }


                saveFileContent[^2] =
                   saveFileContent[^2].Remove(saveFileContent[^2].IndexOf("[§v1]") + 5, lastUse[2].Length - 7);
                //------------------------------------------------------------------------------------------------
                saveFileContent[^2] =
                   saveFileContent[^2].Remove(saveFileContent[^2].IndexOf("[§op]") + 5, lastUse[3].Length - 5);
                //------------------------------------------------------------------------------------------------
                saveFileContent[^2] =
                   saveFileContent[^2].Remove(saveFileContent[^2].IndexOf("[§v2]") + 5, lastUse[4].Length - 5);
                //------------------------------------------------------------------------------------------------
                saveFileContent[^2] =
                   saveFileContent[^2].Remove(saveFileContent[^2].IndexOf("[§=]") + 4, lastUse[5].Length - 6);
                //------------------------------------------------------------------------------------------------


                //------------------------------------------------------------------------------------------------
                saveFileContent[^2] =
                   saveFileContent[^2].Insert(saveFileContent[^2].IndexOf("[§v1]") + 5, val1);
                //------------------------------------------------------------------------------------------------
                saveFileContent[^2] =
                   saveFileContent[^2].Insert(saveFileContent[^2].IndexOf("[§op]") + 5, operadorSave);
                //------------------------------------------------------------------------------------------------
                saveFileContent[^2] =
                   saveFileContent[^2].Insert(saveFileContent[^2].IndexOf("[§v2]") + 5, val2);
                //------------------------------------------------------------------------------------------------
                saveFileContent[^2] =
                   saveFileContent[^2].Insert(saveFileContent[^2].IndexOf("[§=]") + 4, result);
                //------------------------------------------------------------------------------------------------

                string saveFileContentSTR = String.Join("<§>", saveFileContent);
                File.WriteAllText(path, saveFileContentSTR);


            }
        }


        public static void loadSave() {
            if (File.Exists(path)) {
                isFirstOperation = false;
                string[] saveFileContent = File.ReadAllText(path).Split("<§>");
                string[] lastUse = saveFileContent[^2].Split(" ");

                if (lastUse[5].Contains("?")) {
                    if (!lastUse[2].Contains("?")) {
                        armazenamentoValor1 = lastUse[2].Substring(7, lastUse[2].Length - 7);
                        stringNumAcumulado = armazenamentoValor1;
                    }
                    if (!lastUse[3].Contains("?")) {
                        operador = lastUse[3].Substring(5, lastUse[3].Length - 5);
                        teclaTipo = operador;
                    }
                    if (!lastUse[4].Contains("?")) {
                        armazenamentoValor2 = lastUse[4].Substring(5, lastUse[4].Length - 5);
                        stringNumAcumulado = armazenamentoValor2;
                    }

                    if (!lastUse[3].Contains("?") || !lastUse[4].Contains("?")) {
                        Calculadora.ValorAcumulado = Convert.ToDouble(armazenamentoValor1);
                        addNumGetResultado();
                    }
                }

            }
        }
    }
}
