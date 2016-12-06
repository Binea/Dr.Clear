using System;
using System.Security.Cryptography;  
using System.Text;
namespace DentalMedical.Common.DEncrypt
{
	/// <summary>
	/// DES加密/解密类。
    /// Copyright (C) JackXu
	/// </summary>
	public class DESEncrypt
	{
		public DESEncrypt()
		{			
		}

		#region ========加密======== 
 
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="Text"></param>
        /// <returns></returns>
		public static string Encrypt(string Text) 
		{
			return Encrypt(Text,"JackXu");
		}
		/// <summary> 
		/// 加密数据 
		/// </summary> 
		/// <param name="Text"></param> 
		/// <param name="sKey"></param> 
		/// <returns></returns> 
		public static string Encrypt(string Text,string sKey) 
		{
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            byte[] inputByteArray;
            inputByteArray = Encoding.Default.GetBytes(Text);
            MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();
            byte[] c = md5Hasher.ComputeHash(Encoding.Default.GetBytes(sKey));
            string str = BitConverter.ToString(c, 0, 4).Replace("-", "");
            des.Key = ASCIIEncoding.ASCII.GetBytes(str);
            des.IV = ASCIIEncoding.ASCII.GetBytes(str);
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            StringBuilder ret = new StringBuilder();
            foreach (byte b in ms.ToArray())
            {
                ret.AppendFormat("{0:X2}", b);
            }
            return ret.ToString(); 
		} 

		#endregion
		
		#region ========解密======== 
   
 
        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="Text"></param>
        /// <returns></returns>
		public static string Decrypt(string Text) 
		{
			return Decrypt(Text,"JackXu");
		}
		/// <summary> 
		/// 解密数据 
		/// </summary> 
		/// <param name="Text"></param> 
		/// <param name="sKey"></param> 
		/// <returns></returns> 
		public static string Decrypt(string Text,string sKey) 
		{
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            int len;
            len = Text.Length / 2;
            byte[] inputByteArray = new byte[len];
            int x, i;
            for (x = 0; x < len; x++)
            {
                i = Convert.ToInt32(Text.Substring(x * 2, 2), 16);
                inputByteArray[x] = (byte)i;
            }
            MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();
            byte[] c = md5Hasher.ComputeHash(Encoding.Default.GetBytes(sKey));
            string str = BitConverter.ToString(c, 0, 4).Replace("-", "");
            des.Key = ASCIIEncoding.ASCII.GetBytes(str);
            des.IV = ASCIIEncoding.ASCII.GetBytes(str);
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            return Encoding.Default.GetString(ms.ToArray()); 
		} 
 
		#endregion 


	}
}
