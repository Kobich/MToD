using MToD;
using System;
using System.Collections.Generic;
using System.Text;

namespace MToD
{
    public enum PartToEdit
    {
        Real, Imag
    };
    public enum NumberPartToEdit
    {
        Left, Right
    };
    public abstract class TEditor
    {
        string pNum;
        PartToEdit mode;
        NumberPartToEdit numberMode;
        string zero = "0,+i*0,";
        string separatorParts = "i*";
        string separatorNumber = ",";
        public TEditor()
        {
            pNum = zero;
            mode = PartToEdit.Real;
            numberMode = NumberPartToEdit.Left;
        }
        public bool IsZero()
        {
            string tmp = pNum;
            if (tmp[0] == '-')
                tmp = tmp.Substring(1);
            tmp = tmp.Replace('-', '+');
            if (tmp == zero)
                return true;
            else
                return false;
        }
        public string ToggleMinus()
        {
            if (mode == PartToEdit.Real)
            {
                if (pNum[0] == '-')
                    pNum = pNum.Substring(1);
                else
                    pNum = '-' + pNum;
            }
            else
            {
                int imagPartIndex = pNum.IndexOf(separatorParts);
                if (imagPartIndex > 0)
                {
                    if (pNum[imagPartIndex - 1] == '+')
                        pNum = pNum.Substring(0, imagPartIndex - 1) + '-' + pNum.Substring(imagPartIndex);
                    else if (pNum[imagPartIndex - 1] == '-')
                        pNum = pNum.Substring(0, imagPartIndex - 1) + '+' + pNum.Substring(imagPartIndex);
                    //else
                        //pNum = pNum.Substring(0, imagPartIndex) + '-' + pNum.Substring(imagPartIndex);
                }
                else
                {
                    pNum = '-' + pNum;
                }
            }
            return pNum;
        }



        public PartToEdit ToggleMode()
        {
            if (mode == PartToEdit.Real)
                mode = PartToEdit.Imag;
            else
                mode = PartToEdit.Real;
            return mode;
        }
        public NumberPartToEdit ToggleNumberMode()
        {
            if (numberMode == NumberPartToEdit.Left)
                numberMode = NumberPartToEdit.Right;
            else
                numberMode = NumberPartToEdit.Left;
            return numberMode;
        }
        public string AddNumber(int a)
        {
            if (a < 0 || a > 9)
                return pNum;

            int ind = pNum.IndexOf(separatorParts);
            if (ind == -1)
            {
               
                pNum += separatorParts + "0,";
                ind = pNum.IndexOf(separatorParts);
            }

            if (mode == PartToEdit.Real)
            {
                if (numberMode == NumberPartToEdit.Left)
                {
                    if (pNum[0] == '0')
                        pNum = a + pNum.Substring(1);
                    else if (pNum[0] == '-' && pNum[1] == '0')
                        pNum = '-' + a + pNum.Substring(2);
                    else
                    {
                        int frstNumbSep = pNum.IndexOf(separatorNumber);
                        pNum = pNum.Insert(frstNumbSep, a.ToString());
                    }
                }
                else
                    pNum = pNum.Insert(ind - 1, a.ToString());
            }
            else
            {
                if (numberMode == NumberPartToEdit.Left)
                {
                    ind += 2;
                    if (pNum[ind] == '0')
                        pNum = pNum.Substring(0, ind) + a + pNum.Substring(ind + 1);
                    else
                    {
                        int lastNumbSep = pNum.LastIndexOf(',');
                        pNum = pNum.Insert(lastNumbSep, a.ToString());
                    }
                }
                else
                    pNum += a.ToString();
            }
            return pNum;
        }

        public string AddZero()
        {
            return AddNumber(0);
        }
        public string DelNumber()
        {
            int ind = pNum.IndexOf(separatorParts);

            if (ind == -1)
            {
                return pNum;
            }

            if (mode == PartToEdit.Real)
            {
                if (numberMode == NumberPartToEdit.Left)
                {
                    if (pNum[0] == '0')
                        return pNum;
                    else if (pNum[0] == '-' && pNum[1] == '0')
                        return pNum;
                    else
                    {
                        int frstNumbSep = pNum.IndexOf(separatorNumber);
                        if (frstNumbSep > 1)
                            pNum = pNum.Remove(frstNumbSep - 1, 1);
                        else if (pNum.Length > 1)
                            pNum = pNum.Substring(0, pNum.Length - 1);
                    }
                }
                else
                {
                    int frstNumbSep = pNum.IndexOf(separatorNumber);

                    if (frstNumbSep != -1 && frstNumbSep + 1 < ind)
                    {
                        int lastDigitIndex = pNum.LastIndexOf(separatorParts);
                        pNum = pNum.Remove(lastDigitIndex-2, 1);
                    }
                }

            }
            else
            {
                if (numberMode == NumberPartToEdit.Left)
                {
                    ind += 2;
                    if (pNum[ind] != '0')
                    {
                        int lastNumbSep = pNum.LastIndexOf(',');
                        if (lastNumbSep > ind)
                            pNum = pNum.Remove(lastNumbSep - 1, 1);
                        else if (pNum.Length > ind + 1)
                            pNum = pNum.Remove(ind, 1);
                    }
                }
                else
                {
                    if (pNum.Length > ind + 2)
                        pNum = pNum.Remove(pNum.Length - 1);
                }
            }

            return pNum;
        }



        public string Clear()
        {
            pNum = zero;
            mode = PartToEdit.Real;
            numberMode = NumberPartToEdit.Left;
            return pNum;
        }
        public string Edit(int command)
        {
            switch (command)
            {
                case 0:
                    ToggleMinus();
                    break;
                case 1:
                    {
                        Console.Write("Enter number to add: ");
                        int num;
                        num = Console.Read();
                        AddNumber(num);
                        break;
                    }
                case 2:
                    AddZero();
                    break;
                case 3:
                    DelNumber();
                    break;
                case 4:
                    Clear();
                    break;
                case 5:
                    {
                        Console.WriteLine("Enter string to write: ");
                        string inp;
                        inp = Console.ReadLine();
                        WriteNumber(inp);
                        break;
                    }
                default:
                    break;
            }
            return pNum;
        }
        public string WriteNumber(string otherNumber)
        {
            pNum = otherNumber;
            return pNum;
        }
        public string ReadNumber()
        {
            return pNum;
        }
    }
}


public class Editor : TEditor
{
    public Editor() : base()
    {
    }
}