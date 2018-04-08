using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
namespace MSNet.Common.Util
{  
    //加密解密
    public static class Encrypt
    {   
        #region [加密/解密]

        /// <summary>
        /// 对字符串进行 base64 编码。
        /// </summary>
        /// <param name="str">待编码的字符串</param>
        /// <returns></returns>
        public static string ToBase64( this string str )
        {
            return ToBase64( str, Encoding.UTF8 );
        }

        /// <summary>
        /// 对字符串进行 base64 编码。
        /// </summary>
        /// <param name="str">待编码的字符串</param>
        /// <param name="encode">字符集</param>
        /// <returns></returns>
        public static string ToBase64( this string str, Encoding encode )
        {
            byte[]
                b = encode.GetBytes( str );
            return Convert.ToBase64String( b );
        }

        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ToMD5( this string str )
        {
            return ToMD5(str, Encoding.UTF8);
        }

        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="str"></param>
        /// <param name="encode">字符集</param>
        /// <returns></returns>
        public static string ToMD5( this string str, Encoding encode )
        {
            using ( MD5 md5 = new MD5CryptoServiceProvider() )
            {
                byte[]
                    _byte = encode.GetBytes( str ),
                    _byteRst = md5.ComputeHash( _byte );
                StringBuilder
                    builder = new StringBuilder();
                foreach ( byte i in _byteRst )
                    builder.Append( i.ToString( "X2" ) );
                return builder.ToString();
            }
        }

        /// <summary>
        /// DES加密
        /// </summary>
        /// <param name="str"></param>
        /// <param name="key">密钥</param>
        /// <returns></returns>
        public static string ToDES( this string str, string key )
        {
            using ( DESCryptoServiceProvider  des = new DESCryptoServiceProvider() )
            {
                byte[] bytes = Encoding.Default.GetBytes( str ),
                    bytesKey = ASCIIEncoding.ASCII.GetBytes( key );

                if ( bytesKey.Length != 8 )
                    throw new Exception( "参数 key 必须是8个字符" );

                des.Key = bytesKey;
                des.IV = bytesKey;

                using ( MemoryStream ms = new MemoryStream() )
                {
                    CryptoStream   cs = new CryptoStream( ms, des.CreateEncryptor(), CryptoStreamMode.Write );
                    cs.Write( bytes, 0, bytes.Length );
                    cs.FlushFinalBlock();

                    StringBuilder    sb = new StringBuilder();
                    foreach ( byte b in ms.ToArray() )
                    {
                        sb.AppendFormat( "{0:X2}", b );
                    }
                    return sb.ToString();
                }
            }
        }

        /// <summary>
        /// DES解密
        /// </summary>
        /// <param name="str"></param>
        /// <param name="key">密钥</param>
        /// <returns></returns>
        public static string FromDES( this string str, string key )
        {
            byte[]  bytesKey = ASCIIEncoding.ASCII.GetBytes( key );

            if ( bytesKey.Length != 8 )
                throw new Exception( "参数 key 必须是8个字符" );

            using ( DESCryptoServiceProvider des = new DESCryptoServiceProvider() )
            {
                byte[]
                    bytes = new byte[str.Length / 2];
                for ( int x = 0; x < str.Length / 2; x++ )
                {
                    int i = ( Convert.ToInt32( str.Substring( x * 2, 2 ), 16 ) );
                    bytes[x] = (byte)i;
                }

                des.Key = bytesKey;
                des.IV = bytesKey;

                using ( MemoryStream ms = new MemoryStream() )
                {
                    using ( CryptoStream cs = new CryptoStream( ms, des.CreateDecryptor(), CryptoStreamMode.Write ) )
                    {
                        cs.Write( bytes, 0, bytes.Length );
                        cs.FlushFinalBlock();
                    }

                    StringBuilder  ret = new StringBuilder();
                    return Encoding.Default.GetString( ms.ToArray() );
                }
            }
        }

        /// <summary>
        /// SHA1加密
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ToSHA1( this string str )
        {
            var bytes = str.ToBytes();

            var oSHA1Hasher = new SHA1CryptoServiceProvider();

            var arrbytHashValue = oSHA1Hasher.ComputeHash( bytes );

            var data = System.BitConverter.ToString( arrbytHashValue ).Replace( "-", "" );

            return data;
        }
        public static byte[] ToBytes(this object obj)
        {
            if (obj == null)
                return new byte[0];

            BinaryFormatter   binaryFormatter = new BinaryFormatter();
            byte[] b;
            using (MemoryStream ms = new MemoryStream())
            {
                binaryFormatter.Serialize(ms, obj);
                ms.Position = 0;
                b = new Byte[ms.Length];
                ms.Read(b, 0, b.Length);
                ms.Close();
            }
            return b;
        } 
        #endregion
    }
}
