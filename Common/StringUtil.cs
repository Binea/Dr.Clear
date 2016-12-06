using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace DentalMedical.Common
{


    public class StringUtil
    {
        public static int DayOrderNo = 0;

        public static string DataTimeNow()
        {
            return DateTime.Now.ToString("yyyyMMddHHmmssfffffff");
        }

        public static string DayOrderBillNo()
        {
            Interlocked.Increment(ref DayOrderNo);
            return (DateTime.Now.ToString("yyyyMMdd") + string.Format("{0:D4}", DayOrderNo));
        }

        public static Dictionary<string, int> Enum2Dic(Type enumType)
        {
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            foreach (int num in Enum.GetValues(enumType))
            {
                dictionary[Enum.GetName(enumType, num)] = num;
            }
            return dictionary;
        }

        public static string FilterHTML(string s)
        {
            return s.Replace("\r\n", "<br/>").Replace("\n", "<br/>");
        }

        public static string FilterJsonData(string s)
        {
            return s.Replace(@"\", @"\\").Replace("\"", "\\\"").Replace("\r\n", "<br/>").Replace("\n", "<br/>");
        }

        public static string FilterNum(string s)
        {
            if (!string.IsNullOrEmpty(s))
            {
                return Regex.Replace(s, @"[\d+]", "");
            }
            return s;
        }

        public static string FMonth()
        {
            return FMonth(DateTime.Now);
        }

        public static string FMonth(DateTime date)
        {
            return date.ToString("yyyyMM");
        }

        public static string GetSpace(int deep)
        {
            string str = "";
            for (int i = 0; i < deep; i++)
            {
                str = str + "　";
            }
            return str;
        }

        public static string GetSubString(string p_SrcString, int p_Length, string p_TailString)
        {
            return GetSubString(p_SrcString, 0, p_Length, p_TailString);
        }

        public static string GetSubString(string p_SrcString, int p_StartIndex, int p_Length, string p_TailString)
        {
            string str = p_SrcString;
            byte[] bytes = Encoding.UTF8.GetBytes(p_SrcString);
            foreach (char ch in Encoding.UTF8.GetChars(bytes))
            {
                if (((ch > 'ࠀ') && (ch < '一')) || ((ch > 0xac00) && (ch < 0xd7a3)))
                {
                    if (p_StartIndex >= p_SrcString.Length)
                    {
                        return "";
                    }
                    return p_SrcString.Substring(p_StartIndex, ((p_Length + p_StartIndex) > p_SrcString.Length) ? (p_SrcString.Length - p_StartIndex) : p_Length);
                }
            }
            if (p_Length < 0)
            {
                return str;
            }
            byte[] sourceArray = Encoding.Default.GetBytes(p_SrcString);
            if (sourceArray.Length <= p_StartIndex)
            {
                return str;
            }
            int length = sourceArray.Length;
            if (sourceArray.Length > (p_StartIndex + p_Length))
            {
                length = p_Length + p_StartIndex;
            }
            else
            {
                p_Length = sourceArray.Length - p_StartIndex;
                p_TailString = "";
            }
            int num2 = p_Length;
            int[] numArray = new int[p_Length];
            byte[] destinationArray = null;
            int num3 = 0;
            for (int i = p_StartIndex; i < length; i++)
            {
                if (sourceArray[i] > 0x7f)
                {
                    num3++;
                    if (num3 == 3)
                    {
                        num3 = 1;
                    }
                }
                else
                {
                    num3 = 0;
                }
                numArray[i] = num3;
            }
            if ((sourceArray[length - 1] > 0x7f) && (numArray[p_Length - 1] == 1))
            {
                num2 = p_Length + 1;
            }
            destinationArray = new byte[num2];
            Array.Copy(sourceArray, p_StartIndex, destinationArray, 0, num2);
            return (Encoding.Default.GetString(destinationArray) + p_TailString);
        }

        public static string GetUnicodeSubString(string str, int len, string p_TailString)
        {
            string str2 = string.Empty;
            int byteCount = Encoding.Default.GetByteCount(str);
            int length = str.Length;
            int num3 = 0;
            int num4 = 0;
            if (byteCount <= len)
            {
                return str;
            }
            for (int i = 0; i < length; i++)
            {
                if (Convert.ToInt32(str.ToCharArray()[i]) > 0xff)
                {
                    num3 += 2;
                }
                else
                {
                    num3++;
                }
                if (num3 > len)
                {
                    num4 = i;
                    break;
                }
                if (num3 == len)
                {
                    num4 = i + 1;
                    break;
                }
            }
            if (num4 >= 0)
            {
                str2 = str.Substring(0, num4) + p_TailString;
            }
            return str2;
        }

        public static string JsonData(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return s;
            }
            return s.Replace(@"\", @"\\").Replace("\"", "\\\"").Replace("\t", @"\t").Replace("\r\n", @"\r\n").Replace("\n", @"\n");
        }

        public static string MakeRndInt(int Len = 4)
        {
            string str = "";
            Random random = new Random((int) DateTime.Now.Ticks);
            for (int i = 0; i < Len; i++)
            {
                str = str + ((char) random.Next(0x30, 0x3a));
            }
            return str;
        }

        public static string OrderBillNo(int length = 4, int index = 0)
        {
            return (DataTimeNow() + RandNum(length, index));
        }

        public static string RandNum(int length, int index = 0)
        {
            Random random = new Random(((int) DateTime.Now.Ticks) - index);
            if (length < 0)
            {
                length = 1;
            }
            string str = random.Next(0, (int) Math.Pow(10.0, (double) length)).ToString();
            if (str.Length >= length)
            {
                return str;
            }
            string str2 = "";
            for (int i = length; i > str.Length; i--)
            {
                str2 = str2 + "0";
            }
            return (str2 + str);
        }



        #region public static string GetRandomString(int RandomLength) 产生随机字符
        /// <summary>
        /// 产生随机字符
        /// </summary>
        /// <returns>字符串</returns>
        public static string GetRandomString(int RandomLength)
        {
            string RandomString = "0123456789ABCDEFGHIJKMLNOPQRSTUVWXYZ";
            Random Random = new Random(DateTime.Now.Second);
            string returnValue = string.Empty;
            for (int i = 0; i < RandomLength; i++)
            {
                int r = Random.Next(0, RandomString.Length - 1);
                returnValue += RandomString[r];
            }
            return returnValue;
        }
        #endregion

        public static string Replace(string template, string placeholder, string replacement)
        {
            if (template == null)
            {
                return null;
            }
            int index = template.IndexOf(placeholder);
            if (index < 0)
            {
                return template;
            }
            return new StringBuilder(template.Substring(0, index)).Append(replacement).Append(Replace(template.Substring(index + placeholder.Length), placeholder, replacement)).ToString();
        }

        public static string ReplaceAll(string template, string placeholder, string replacement)
        {
            return Replace(template, placeholder, replacement);
        }

        public static string ReplaceHTML2Text(string html)
        {
            html = html.Replace("\r\n", "").Replace("&nbsp;", "");
            html = html.Trim();
            return Regex.Replace(html, "<(.+?)>", "");
        }

        public static string ReplaceHTML2Text1(string html)
        {
            html = html.Replace("\r\n", "").Replace("&nbsp;", "");
            html = html.Trim();
            return Regex.Replace(html, "<([^a|(/a)]+?)>", "");
        }

        public static string ReplaceJson(string s)
        {
            if (!string.IsNullOrEmpty(s))
            {
                s = s.Replace("?", "").Replace("%", "").Replace(@"\", "");
            }
            return s;
        }

        public static string ReplaceLowOrderASCIICharacters(string tmp)
        {
            StringBuilder builder = new StringBuilder();
            foreach (char ch in tmp)
            {
                int num = ch;
                if ((((num >= 0) && (num <= 8)) || ((num >= 11) && (num <= 12))) || ((num >= 14) && (num <= 0x20)))
                {
                    builder.AppendFormat(" ", num);
                }
                else
                {
                    builder.Append(ch);
                }
            }
            return builder.ToString();
        }

        public static string ReplaceSQLChar(string str)
        {
            if (str == string.Empty)
            {
                return string.Empty;
            }
            str = str.Replace("'", "‘");
            str = str.Replace(";", "；");
            str = str.Replace(",", ",");
            str = str.Replace("?", "?");
            str = str.Replace("<", "＜");
            str = str.Replace(">", "＞");
            str = str.Replace("(", "(");
            str = str.Replace(")", ")");
            str = str.Replace("@", "＠");
            str = str.Replace("=", "＝");
            str = str.Replace("+", "＋");
            str = str.Replace("*", "＊");
            str = str.Replace("&", "＆");
            str = str.Replace("#", "＃");
            str = str.Replace("%", "％");
            str = str.Replace("$", "￥");
            return str;
        }

        public static string StripSQLInjection(string sql)
        {
            if (!string.IsNullOrEmpty(sql))
            {
                string pattern = @"(\%27)|(\')|(\-\-)";
                string str2 = @"\s+exec(\s|\+)+(s|x)p\w+";
                sql = Regex.Replace(sql, pattern, string.Empty, RegexOptions.IgnoreCase);
                sql = Regex.Replace(sql, str2, string.Empty, RegexOptions.IgnoreCase);
                sql = sql.Replace("or", "").Replace("OR", "").Replace("Or", "").Replace("oR", "");
                sql = sql.Replace("'", "");
                sql = sql.Replace(">", ">");
                sql = sql.Replace("<", "<");
                sql = sql.Replace("\n", "");
                sql = sql.Replace("\0", "");
            }
            return sql;
        }

        public static string Text2HTML(string s)
        {
            return s.Replace("\r\n", "<br/>").Replace("\n", "<br/>").Replace(" ", "&nbsp;");
        }

        public static string XMLData(string s)
        {
            if (!string.IsNullOrEmpty(s))
            {
                return Regex.Replace(s, @"[\x00-\x08\x0b-\x0c\x0e-\x1f]", " ");
            }
            return s;
        }
    }
}

