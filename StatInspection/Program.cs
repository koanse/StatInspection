using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Text;
using muWrapper;
using MathNet.Numerics.Distributions;

namespace StatInspection
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
            /*string s = StatInspection.GetNCode("S-2", 500000000);
            int l = StatInspection.GetLim(501, 1);            
            int Re, Ac = StatInspection.GetAcRe("A", "Нормальный", 1, out Re);
            Ac = StatInspection.GetAcRe("G", "Ослабленный", 1, out Re);
            int[] arrN, arrAc, arrQ;
            string[] arrCT, arrStr;
            Result[] arrRes;
            arrStr = StatInspection.Inspect(10, 100, 10, 0.004, 0.001, 1, "Нормальный", "I",
                out arrN, out arrAc, out arrQ, out arrCT, out arrRes);*/
        }
    }
    static class Generator
    {
        static NormalDistribution dist = new NormalDistribution();
        static public int NextN(double mN, double sN)   // объем партии
        {
            dist.SetDistributionParameters(mN, sN);
            return (int)Math.Round(dist.NextDouble());
        }
        static public int NextQ(int n, double mQ, double sQ)  // количество дефектов в выборке n
        {
            dist.SetDistributionParameters(mQ, sQ);
            return (int)Math.Round(dist.NextDouble() / 100.0 * n);
        }
        /*static public int[] GenerateData(int smpCount, int n, string exprM, string exprS)
        {
            int[] data = new int[smpCount];
            Parser prsM = new Parser(), prsS = new Parser();
            prsM.SetExpr(exprM);
            prsS.SetExpr(exprS);
            ParserVariable varT = new ParserVariable();
            prsM.DefineVar("t", varT);
            prsS.DefineVar("t", varT);
            NormalDistribution dist = new NormalDistribution();
            for (int i = 0; i < smpCount; i++)
            {
                varT.Value = i + 1;
                dist.SetDistributionParameters(prsM.Eval(), prsS.Eval());
                data[i] = (int)Math.Round(dist.NextDouble() * n);
            }
            return data;
        }
        static public void SaveData(string file, int[] data, int n)
        {
            FileStream fs = new FileStream(file, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs, Encoding.Unicode);
            sw.WriteLine(data.Length.ToString());
            for (int i = 0; i < data.Length; i++)
                sw.Write(String.Format("{0} ", data[i]));
            sw.Close();
        }
        static public int[] ReadData(string file)
        {
            FileStream fs = new FileStream(file, FileMode.Open);
            StreamReader sr = new StreamReader(fs, Encoding.Unicode);
            string str = sr.ReadToEnd();
            sr.Close();
            string[] arrStr = str.Split(new char[] { ' ', '\r', '\n' });
            int smpCount = int.Parse(arrStr[0]);
            int[] data = new int[smpCount];
            for (int i = 0; i < smpCount; i++)
                data[i] = int.Parse(arrStr[i + 2]);
            return data;
        }*/
    }
    static class StatInspection
    {
        #region tables
        static string[,] matrN = new string[,] {
            { "A", "A", "A", "A", "A", "A", "B" },
            { "A", "A", "A", "A", "A", "B", "C" },
            { "A", "A", "B", "B", "B", "C", "D" },
            { "A", "B", "B", "C", "C", "D", "E" },
            { "B", "B", "C", "C", "C", "E", "F" },
            { "B", "B", "C", "D", "D", "F", "G" },
            { "B", "C", "D", "E", "E", "G", "H" },
            { "B", "C", "D", "E", "F", "H", "J" },
            { "C", "C", "E", "F", "G", "J", "K" },
            { "C", "D", "E", "G", "H", "K", "L" },
            { "C", "D", "F", "G", "J", "L", "M" },
            { "C", "D", "F", "H", "K", "M", "N" },
            { "D", "E", "G", "J", "L", "N", "P" },
            { "D", "E", "G", "J", "M", "P", "Q" },
            { "D", "E", "H", "K", "N", "Q", "R" }
        };
        static int[,] matrLim = new int[,] {
            { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1,  0,  0,  2,  4,  8, 14},
            { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1,  0,  0,  1,  3,  7, 13, 22},
            { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1,  0,  0,  2,  3,  7, 14, 25, 40},
            { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1,  0,  0,  2,  4,  7, 14, 24, 42, 68},
            { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1,  0,  0,  2,  4,  7, 13, 25, 42, 72,115},
            { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1,  0,  0,  2,  4,  8, 14, 22, 40, 68,115,181},
            { -1, -1, -1, -1, -1, -1, -1, -1, -1,  0,  0,  1,  4,  8, 14, 24, 39, 68,113,189,181},
            { -1, -1, -1, -1, -1, -1, -1, -1,  0,  0,  2,  3,  7, 14, 25, 40, 63,110,181,189,181},
            { -1, -1, -1, -1, -1, -1, -1,  0,  0,  2,  4,  7, 14, 24, 42, 68,105,181,181,189,181},

            { -1, -1, -1, -1, -1, -1,  0,  0,  2,  4,  7, 13, 24, 40, 69,110,169,181,181,189,181},
            { -1, -1, -1, -1, -1,  0,  0,  2,  4,  8, 14, 22, 40, 68,115,181,169,181,181,189,181},
            { -1, -1, -1, -1,  0,  0,  1,  4,  8, 14, 24, 38, 67,111,186,181,169,181,181,189,181},
            { -1, -1, -1,  0,  0,  2,  3,  7, 14, 25, 40, 63,110,181,186,181,169,181,181,189,181},
            { -1, -1,  0,  0,  2,  4,  7, 14, 24, 42, 68,105,181,181,186,181,169,181,181,189,181},
            { -1,  0,  0,  2,  4,  7, 13, 24, 40, 69,110,169,181,181,186,181,169,181,181,189,181},
            {  0,  0,  2,  4,  8, 14, 22, 40, 68,115,181,169,181,181,186,181,169,181,181,189,181},
            {  0,  1,  4,  8, 14, 24, 38, 67,111,186,181,169,181,181,186,181,169,181,181,189,181},
            {  2,  3,  7, 14, 25, 40, 63,110,181,301,181,169,181,181,186,181,169,181,181,189,181}
        };
        static int[] arrNormHard = new int[] {
            2, 3, 5, 8, 13, 20, 32, 50, 80, 125, 200, 315, 500, 800, 1250, 2000       
        };
        static int[] arrLow = new int[] {
            2, 2, 2, 3, 5, 8, 13, 20, 32, 50, 80, 125, 200, 315, 500, 800       
        };
        static int[,] matrNormAc = new int[,] {
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 2, 3, 5 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 2, 3, 5, 7 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 2, 3, 5, 7,10 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 2, 3, 5, 7,10,14 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 2, 3, 5, 7,10,14,21 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 2, 3, 5, 7,10,14,21,21 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 2, 3, 5, 7,10,14,21,21,21 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 2, 3, 5, 7,10,14,21,21,21,21 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 2, 3, 5, 7,10,14,21,21,21,21,21 },
            { 0, 0, 0, 0, 0, 0, 0, 1, 1, 2, 3, 5, 7,10,14,21,21,21,21,21,21 },
            { 0, 0, 0, 0, 0, 0, 1, 1, 2, 3, 5, 7,10,14,21,21,21,21,21,21,21 },
            { 0, 0, 0, 0, 0, 1, 1, 2, 3, 5, 7,10,14,21,21,21,21,21,21,21,21 },
            { 0, 0, 0, 0, 1, 1, 2, 3, 5, 7,10,14,21,21,21,21,21,21,21,21,21 },
            { 0, 0, 0, 1, 1, 2, 3, 5, 7,10,14,21,21,21,21,21,21,21,21,21,21 },
            { 0, 0, 1, 1, 2, 3, 5, 7,10,14,21,21,21,21,21,21,21,21,21,21,21 },
            { 0, 0, 1, 2, 3, 5, 7,10,14,21,21,21,21,21,21,21,21,21,21,21,21 }
        };
        static int[,] matrHardAc = new int[,] {
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 3 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 3, 5 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 3, 5, 8 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 3, 5, 8,12 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 3, 5, 8,12,18 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 3, 5, 8,12,18,18 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 3, 5, 8,12,18,18,18 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 3, 5, 8,12,18,18,18,18 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 3, 5, 8,12,18,18,18,18,18 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 3, 5, 8,12,18,18,18,18,18,18 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 3, 5, 8,12,18,18,18,18,18,18,18 },
            { 0, 0, 0, 0, 0, 0, 0, 1, 2, 3, 5, 8,12,18,18,18,18,18,18,18,18 },
            { 0, 0, 0, 0, 0, 0, 1, 2, 3, 5, 8,12,18,18,18,18,18,18,18,18,18 },
            { 0, 0, 0, 0, 0, 1, 2, 3, 5, 8,12,18,18,18,18,18,18,18,18,18,18 },
            { 0, 0, 0, 0, 1, 2, 3, 5, 8,12,18,18,18,18,18,18,18,18,18,18,18 },
            { 0, 0, 0, 1, 2, 3, 5, 8,12,18,18,18,18,18,18,18,18,18,18,18,18 }
        };
        static int[,] matrLowAc = new int[,] {
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 3, 5 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 3, 5 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 2, 3, 5 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 2, 3, 5, 7 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 2, 3, 5, 7,10 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 2, 3, 5, 7,10,10 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 2, 3, 5, 7,10,10,10 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 2, 3, 5, 7,10,10,10,10 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 2, 3, 5, 7,10,10,10,10,10 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 2, 3, 5, 7,10,10,10,10,10,10 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 2, 3, 5, 7,10,10,10,10,10,10,10 },
            { 0, 0, 0, 0, 0, 0, 0, 1, 1, 2, 3, 5, 7,10,10,10,10,10,10,10,10 },
            { 0, 0, 0, 0, 0, 0, 1, 1, 2, 3, 5, 7,10,10,10,10,10,10,10,10,10 },
            { 0, 0, 0, 0, 0, 1, 1, 2, 3, 5, 7,10,10,10,10,10,10,10,10,10,10 },
            { 0, 0, 0, 0, 1, 1, 2, 3, 5, 7,10,10,10,10,10,10,10,10,10,10,10 },
            { 0, 0, 0, 1, 1, 2, 3, 5, 7,10,10,10,10,10,10,10,10,10,10,10,10 }
        };
        static int[,] matrLowRe = new int[,] {
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 3, 4, 6 },
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 3, 4, 5, 6 },
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 3, 4, 5, 6, 8 },
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 3, 4, 5, 6, 8,10 },
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 3, 4, 5, 6, 8,10,13 },
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 3, 4, 5, 6, 8,10,13,13 },
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 3, 4, 5, 6, 8,10,13,13,13 },
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 3, 4, 5, 6, 8,10,13,13,13,13 },
            { 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 3, 4, 5, 6, 8,10,13,13,13,13,13 },
            { 1, 1, 1, 1, 1, 1, 1, 2, 2, 3, 4, 5, 6, 8,10,13,13,13,13,13,13 },
            { 1, 1, 1, 1, 1, 1, 2, 2, 3, 4, 5, 8, 8,10,13,13,13,13,13,13,13 },
            { 1, 1, 1, 1, 1, 2, 2, 3, 4, 5, 8,10,10,13,13,13,13,13,13,13,13 },
            { 1, 1, 1, 1, 2, 2, 3, 4, 5, 8,10,13,13,13,13,13,13,13,13,13,13 },
            { 1, 1, 1, 2, 2, 3, 4, 5, 8,10,13,13,13,13,13,13,13,13,13,13,13 },
            { 1, 1, 2, 2, 3, 4, 5, 8,10,13,13,13,13,13,13,13,13,13,13,13,13 },
            { 1, 2, 2, 3, 4, 5, 8,10,13,13,13,13,13,13,13,13,13,13,13,13,13 }
        };
        #endregion
        static public string GetNCode(string controlLevel, int n)
        {
            int[] arrN = new int[] {
                8, 15, 25, 50, 90, 150, 280, 500, 1200,
                3200, 10000, 35000, 150000, 500000, int.MaxValue
            };
            string[] arrStr = new string[] {
                "S-1", "S-2", "S-3", "S-4", "I", "II", "III"
            };            
            int i, j;
            for (i = 0; i < arrN.Length; i++)
                if (n <= arrN[i])
                    break;
            for (j = 0; j < arrStr.Length; j++)
                if (arrStr[j] == controlLevel)
                    break;
            return matrN[i, j];
        }
        static public int GetLim(int n, double AQL)
        {
            int[] arrN = new int[] {
                29, 49, 79, 120, 199, 319, 499, 799, 1249, 1999, 3149,
                4999, 7999, 12499, 19999, 31499, 49999, int.MaxValue
            };
            double[] arrAQL = new double[] {
                0.010, 0.015, 0.025, 0.040, 0.065, 0.10, 0.15, 0.25,
                0.40, 0.65, 1.0, 1.5, 2.5, 4.0, 6.5, 10, 15, 25, 40,
                65, 100
            };
            int i, j;
            for (i = 0; i < arrN.Length; i++)
                if (n <= arrN[i])
                    break;
            for (j = 0; j < arrAQL.Length; j++)
                if (arrAQL[j] == AQL)
                    break;
            return matrLim[i, j];
        }
        static public int GetN(string nCode, string controlType)
        {
            string[] arrStr = new string[] {
                "A", "B", "C", "D", "E", "F", "G", "H", "J",
                "K", "L", "M", "N", "P", "Q", "R"
            };
            int i;
            for (i = 0; i < arrStr.Length; i++)
                if (nCode == arrStr[i])
                    break;
            if (controlType == "Нормальный" ||
                controlType == "Усиленный")
                return arrNormHard[i];
            if (controlType == "Ослабленный")
                return arrLow[i];
            throw new Exception();
        }
        static public int GetAcRe(string nCode, string controlType, double AQL,
            out int Re)
        {
            string[] arrStr = new string[] {
                "A", "B", "C", "D", "E", "F", "G", "H", "J",
                "K", "L", "M", "N", "P", "Q", "R"
            };
            double[] arrAQL = new double[] {
                0.010, 0.015, 0.025, 0.040, 0.065, 0.10, 0.15, 0.25,
                0.40, 0.65, 1.0, 1.5, 2.5, 4.0, 6.5, 10, 15, 25, 40,
                65, 100
            };
            int i, j;
            for (i = 0; i < arrStr.Length; i++)
                if (nCode == arrStr[i])
                    break;
            for (j = 0; j < arrAQL.Length; j++)
                if (arrAQL[j] == AQL)
                    break;
            if (controlType == "Нормальный")
            {
                Re = matrNormAc[i, j] + 1;
                return matrNormAc[i, j];
            }
            if (controlType == "Усиленный")
            {
                Re = matrHardAc[i, j] + 1;
                return matrHardAc[i, j];
            }
            if (controlType == "Ослабленный")
            {
                Re = matrLowRe[i, j];
                return matrLowAc[i, j];
            }
            throw new Exception();
        }
        static public string[] Inspect(int smpCount, double mN, double sN,
            double mQ, double sQ, double AQL, string controlType, string controlLevel,
            out int[] arrN, out int[] arrAc, out int[] arrQ,
            out string[] arrControlType, out Result[] arrResult)
        {
            List<string> listStr = new List<string>();
            List<int> listN = new List<int>();
            List<int> listAc = new List<int>();
            List<int> listQ = new List<int>();
            List<string> listCT = new List<string>();
            List<Result> listRes = new List<Result>();
            for (int i = 0; i < smpCount; i++)
            {
                int nLot = Generator.NextN(mN, sN);
                string nCode = StatInspection.GetNCode(controlLevel, nLot);
                int n = StatInspection.GetN(nCode, controlType);
                int Re, Ac = StatInspection.GetAcRe(nCode, controlType, AQL, out Re);
                int q = Generator.NextQ(nLot, mQ, sQ);
                Result res = Result.Не_определено;
                if (q <= Ac)
                    res = Result.Принята;
                else if (q >= Re)
                    res = Result.Забракована;
                string s = string.Format("Объем партии: {0}<br>Вид контроля: {1}<br>" +
                    "Код объема выборки: {2}<br>Объем выборки: {3}<br>Ac = {4}<br>Re = {5}<br>" +
                    "q = {6}<br>Результат: {7}<br>",
                    nLot, controlType, nCode, n, Ac, Re, q, res);
                listN.Add(n);
                listAc.Add(Ac);
                listQ.Add(q);
                listCT.Add(controlType);
                listRes.Add(res);

                if (controlType == "Нормальный")
                {
                    int j, k = 0;
                    for (j = 0; j < 5; j++)
                    {
                        int index = listCT.Count - 1 - j;
                        if (index < 0 || listCT[index] != "Нормальный")
                            break;
                        if (listRes[index] == Result.Забракована)
                            k++;
                    }
                    if (j == 5 && k >= 2)
                    {
                        controlType = "Усиленный";
                        s += " (переход на усиленный контроль: из пяти партий две или более забракованы)";
                        listStr.Add(s);
                        continue;
                    }

                    k = 0;
                    for (j = 0; j < 10; j++)
                    {
                        int index = listCT.Count - 1 - j;
                        if (index < 0 || listCT[index] != "Нормальный" ||
                            listRes[index] == Result.Забракована)
                            break;
                        k += listQ[index];
                    }
                    int lim = StatInspection.GetLim(n, AQL);
                    if (j == 10 && k <= lim)
                    {
                        controlType = "Ослабленный";
                        s += " (переход на ослабленный контроль: десять партий приняты, " +
                            "суммарное количество дефектов не превышает предельное приемочное число "
                            + lim.ToString() + ")";
                        listStr.Add(s);
                        continue;
                    }
                }

                if (controlType == "Усиленный")
                {
                    int j, k = 0;
                    for (j = 0; j < 5; j++)
                    {
                        int index = listCT.Count - 1 - j;
                        if (index < 0 || listCT[index] != "Усиленный")
                            break;
                        if (listRes[index] == Result.Забракована)
                            k++;
                    }
                    if (j == 5 && k == 0)
                    {
                        controlType = "Нормальный";
                        s += " (переход на нормальный контроль: пять партий приняты)";
                        listStr.Add(s);
                        continue;
                    }
                }

                if (controlType == "Ослабленный")
                {
                    if (res == Result.Забракована || res == Result.Не_определено)
                    {
                        controlType = "Нормальный";
                        s += " (переход на нормальный контроль: партия не принята)";
                        listStr.Add(s);
                        continue;
                    }
                }
                listStr.Add(s);
            }
            arrN = listN.ToArray();
            arrAc = listAc.ToArray();
            arrQ = listQ.ToArray();
            arrControlType = listCT.ToArray();
            arrResult = listRes.ToArray();
            return listStr.ToArray();
        }
        static public double L(double p, int n, int c)
        {
            double pn = p * n, x = Math.Exp(-pn), sum = x;
            for (int i = 1; i <= c; i++)
            {
                x *= pn / i;
                sum += x;
            }
            return sum;
        }
        static public double[] GetL(int n, int c, out double[] arrP)
        {
            int k = 100;
            double max = 0.1, step = max / k;
            arrP = new double[k];
            double[] arrL = new double[k];
            for (int i = 0; i < k; i++)
            {
                arrP[i] = i * step;
                arrL[i] = L(arrP[i], n, c);
            }
            return arrL;
        }
    }
    public enum Result
    {
        Принята, Забракована, Не_определено
    }
}