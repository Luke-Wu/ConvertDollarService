using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConvertDollarService
{
    public class NumericHandler
    {

        //Store one to Nineteen
        private readonly string[] StrNO = new string[19];
        //Store ten to ninety
        private readonly string[] StrTens = new string[9];
        //Store currencyunit
        private readonly string[] Unit = new string[9];


        /// <summary>
        /// Get text / words of dollars
        /// </summary>
        /// <param name="dollars">dollars amount</param>
        /// <returns></returns>
        public  string GetDollarsText(double dollars)
        {
            string Str, BeforePoint, AfterPoint, temp;
            int Bit;    //number of units
            string CurString; //current string
            int NumLen;
            Init();
            Str = (Math.Round(dollars, 2).ToString("#0.00"));
            if (Str.IndexOf(".") == -1)
            {
                BeforePoint = Str;
                AfterPoint = "";
            }
            else
            {
                BeforePoint = Str.Substring(0, Str.IndexOf("."));
                AfterPoint = Str.Substring(Str.IndexOf(".") + 1, Str.Length - Str.IndexOf(".") - 1);
            }

            //Handle integer parts
            if (BeforePoint.Length > 12)
            {
                return null;
            }
            Str = "";
            // integer part is not 0
            if (dollars >= 1)
            {
                while (BeforePoint.Length > 0)
                {
                    NumLen = BeforePoint.Length;
                    if (NumLen % 3 == 0)
                    {
                        CurString = BeforePoint.Left(3);
                        BeforePoint = BeforePoint.Right(NumLen - 3);
                    }
                    else
                    {
                        CurString = BeforePoint.Left((NumLen % 3));
                        BeforePoint = BeforePoint.Right(NumLen - (NumLen % 3));
                    }
                    Bit = BeforePoint.Length / 3;
                    temp = DecodeHundred(CurString);
                    if (Bit == 0 && CurString.Length == 3)
                    {
                        if (Convert.ToInt32(CurString.Left(1)) != 0 & Convert.ToInt32(CurString.Right(2)) != 0)
                        {
                            temp = temp.Left(temp.IndexOf(Unit[3]) + Unit[3].Length) + Unit[7] + " " +
                                        temp.Right(temp.Length - (temp.IndexOf(Unit[3]) + Unit[3].Length));
                        }
                        else
                        {
                            temp = Unit[7] + " " + temp;
                        }
                    }
                    if (Bit == 0)
                    {
                        Str = Convert.ToString(Str + " " + temp).Trim();
                    }
                    else
                    {
                        if (temp != "")
                        {
                            Str = Convert.ToString(Str + " " + temp + " " + Unit[Bit - 1]).Trim();
                        }
                    }
                    if (Str.Left(3) == Unit[7])
                    {
                        Str = Convert.ToString(Str.Right(Str.Length - 3)).Trim();
                    }
                    if (BeforePoint == BeforePoint.Length.ToString())
                    {
                        return "";
                    }
                }
                BeforePoint = Str + " ";
            }
            // integer part is 0
            else
            {
                BeforePoint = "";
            }
            // Handler decimals part
            if ((dollars * 100) % 100 > 0)//If there is a decimal exist
            {
                if (DecodeHundred(AfterPoint) == "ONE")
                {
                    if (Convert.ToUInt64(dollars) == 1)
                    {
                        AfterPoint = Unit[8] + " AND " + DecodeHundred(AfterPoint) + " " + Unit[6];//singular
                    }
                    else if (Convert.ToUInt64(dollars) == 0)
                    {
                        AfterPoint = DecodeHundred(AfterPoint) + " AND " + Unit[6];//singular
                    }
                    else
                    {
                        AfterPoint = Unit[5] + " AND " + DecodeHundred(AfterPoint) + " " + Unit[6];//singular
                    }
                }
                else
                {
                    if (Convert.ToUInt64(dollars) == 1)
                    {
                        AfterPoint = Unit[8] + " AND " + DecodeHundred(AfterPoint) + " " + Unit[6] + "S";//plural
                    }
                    else if (Convert.ToUInt64(dollars) == 0)
                    {
                        AfterPoint = DecodeHundred(AfterPoint) + " " + Unit[6] + "S";//plural
                    }
                    else
                    {
                        AfterPoint = Unit[5] + " AND " + DecodeHundred(AfterPoint) + " " + Unit[6] + "S";//plural
                    }
                }
            }
            //If the decimal is not exist
            else
            {
                if (Convert.ToUInt64(dollars) == 1)
                {
                    AfterPoint = Unit[8];
                }
                else
                {
                    AfterPoint = Unit[5];
                }

            }
            return (BeforePoint + AfterPoint);




        }







        /// <summary>
        /// Init amount words and units
        /// </summary>
        private  void Init()
        {
            if (StrNO[0] != "ONE")
            {
                StrNO[0] = "ONE";
                StrNO[1] = "TWO";
                StrNO[2] = "THREE";
                StrNO[3] = "FOUR";
                StrNO[4] = "FIVE";
                StrNO[5] = "SIX";
                StrNO[6] = "SEVEN";
                StrNO[7] = "EIGHT";
                StrNO[8] = "NINE";
                StrNO[9] = "TEN";
                StrNO[10] = "ELEVEN";
                StrNO[11] = "TWELVE";
                StrNO[12] = "THIRTEEN";
                StrNO[13] = "FOURTEEN";
                StrNO[14] = "FIFTEEN";
                StrNO[15] = "SIXTEEN";
                StrNO[16] = "SEVENTEEN";
                StrNO[17] = "EIGHTEEN";
                StrNO[18] = "NINETEEN";
                StrTens[0] = "TEN";
                StrTens[1] = "TWENTY";
                StrTens[2] = "THIRTY";
                StrTens[3] = "FORTY";
                StrTens[4] = "FIFTY";
                StrTens[5] = "SIXTY";
                StrTens[6] = "SEVENTY";
                StrTens[7] = "EIGHTY";
                StrTens[8] = "NINETY";
                Unit[0] = "THOUSAND";
                Unit[1] = "MILLION";
                Unit[2] = "BILLION";
                Unit[3] = "HUNDRED";
                Unit[4] = "ONLY";
                Unit[5] = "DOLLARS";
                Unit[6] = "CENT";
                Unit[7] = "";
                Unit[8] = "DOLLAR";
            }
        }



        private string DecodeHundred(string HundredString)
        {
            int temp;
            string rtn = String.Empty;
            if (HundredString.Length > 0 && HundredString.Length <= 3)
            {
                switch (HundredString.Length)
                {
                    case 1:
                        temp = Convert.ToInt32(HundredString);
                        if (temp != 0)
                        {
                            rtn = StrNO[temp - 1];
                        }
                        break;
                    case 2:
                        temp = Convert.ToInt32(HundredString);
                        if (temp != 0)
                        {
                            if ((temp < 20))
                            {
                                rtn = StrNO[temp - 1];
                            }
                            else
                            {
                                if (Convert.ToUInt64(HundredString.Right(1)) == 0)
                                {
                                    rtn = StrTens[Convert.ToInt32(temp / 10) - 1];
                                }
                                else
                                {
                                    rtn = Convert.ToString(StrTens[Convert.ToInt32(temp / 10) - 1] + "-" +
                                                             StrNO[Convert.ToInt32(HundredString.Right(1)) - 1]);
                                }
                            }
                        }
                        break;
                    case 3:
                        //The hundreds digit is not empty
                        if (Convert.ToUInt64(HundredString.Left(1)) != 0)
                        {
                            rtn = Convert.ToString(StrNO[Convert.ToInt32(HundredString.Left(1)) - 1] + " " + Unit[3] +
                                                         " AND " + DecodeHundred(HundredString.Right(2)));
                        }
                        else
                        {
                            if (Convert.ToUInt64(HundredString.Right(2)) != 0)
                            {
                                rtn = "AND " + DecodeHundred(HundredString.Right(2));
                            }
                            else
                            {
                                rtn = DecodeHundred(HundredString.Right(2));
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
            return rtn;
        }




    }
}