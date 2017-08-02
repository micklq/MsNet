using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Drawing.Imaging;

namespace MSNet.Common.Web
{
    //VCodeHelper.Create(new VCodeHelper.VCodeImageArg { SessionName = vName }) VCodeHelper.Create( new VCodeHelper.VCodeImageArg())
    public class VerifyCodeHelper
    {
        static readonly string codeStr = "0123456789";
        static readonly int codeLength = codeStr.Length;
        //static char[] chArray = codeStr.ToCharArray();

        static string GenerateCode(int length)
        {
            StringBuilder sb = new StringBuilder();
            Random rnd = new Random();
            for (int i = 0; i < length; i++)
            {
                sb.Append(codeStr[rnd.Next(0, codeLength - 1)].ToString());               
                System.Threading.Thread.Sleep(1);
            }
            return sb.ToString();
        }

        public static string Create(int n)
        {
            return Create(new VerifyCodeImageArg(n)
            {
                //BGColor = Color.Red
            });
        }

        public static string Create(VerifyCodeImageArg arg)
        {
            string  s = GenerateCode(arg.Length);

            HttpContext.Current.Session[arg.SessionName] = s;

            using (Bitmap image = new Bitmap(arg.Width, arg.Height))
            {
                using (Graphics graphics = Graphics.FromImage(image))
                {
                    Random
                        random = new Random();
                    graphics.Clear(arg.BGColor);
                    Font
                        font = arg.Font;

                    using (LinearGradientBrush brush = new LinearGradientBrush(new Rectangle(0, 0, image.Width, image.Height), arg.Color, arg.Color, 1.2f, true))
                    {
                        graphics.DrawString(s, font, brush, (float)2f, (float)2f);
                    }

                    HttpContext.Current.Response.ClearContent();
                    HttpContext.Current.Response.Expires = 0;
                    HttpContext.Current.Response.CacheControl = "no-cache";
                    HttpContext.Current.Response.ContentType = "image/jpeg";

                    using (MemoryStream stream = new MemoryStream())
                    {
                        image.Save(stream, ImageFormat.Jpeg);

                        HttpContext.Current.Response.BinaryWrite(stream.ToArray());
                    }
                    
                }
                
            }
            return s;
        }

        /// <summary>
        /// 验证码图片参数
        /// </summary>
        public class VerifyCodeImageArg : IDisposable
        {
            public VerifyCodeImageArg()
                : this(4)
            {
            }

            public VerifyCodeImageArg(int len)
            {
                Length = len;
            }

            int _Length;
            /// <summary>
            /// 验证码字符长度
            /// </summary>
            public int Length
            {
                get
                {
                    return _Length;
                }
                set
                {
                    if (value <= 0)
                        throw new Exception("属性：Length 必须大于0");

                    _Length = value;
                }
            }

            string _SessionName = "_VerifyCode_";
            /// <summary>
            /// Session名称
            /// </summary>
            public string SessionName
            {
                get
                {
                    return _SessionName;
                }
                set
                {
                    _SessionName = value;
                }
            }

            int _Width = 50;
            /// <summary>
            /// 图片宽度
            /// </summary>
            public int Width
            {
                get
                {
                    return _Width;
                }
                set
                {
                    _Width = value;
                }
            }

            int _Height = 0x16;
            /// <summary>
            /// 图片高度
            /// </summary>
            public int Height
            {
                get
                {
                    return _Height;
                }
                set
                {
                    _Height = value;
                }
            }

            Font _Font = new Font("Arial", 12f, FontStyle.Bold);
            /// <summary>
            /// 字体
            /// </summary>
            public Font Font
            {
                get
                {
                    return _Font;
                }
                set
                {
                    _Font = value;
                }
            }


            Color _Color = Color.White;
            /// <summary>
            /// 字体颜色
            /// </summary>
            public Color Color
            {
                get
                {
                    return _Color;
                }
                set
                {
                    _Color = value;
                }
            }
            Color _bgColor = Color.FromArgb(20, 0x47, 0x74);
            /// <summary>
            /// 背景颜色
            /// </summary>
            public Color BGColor
            {
                get
                {
                    return _bgColor;
                }
                set
                {
                    _bgColor = value;
                }
            }

            public void Dispose()
            {
                _Font.Dispose();

                GC.SuppressFinalize(this);
            }
        }

        public static bool CheckVerifyCode(string vcode)
        {
            string sessionName = "_VerifyCode_";

            return CheckVerifyCode(vcode, sessionName);
        }

        public static bool CheckVerifyCode(string vcode, string sessionName)
        {
            if (string.IsNullOrEmpty(vcode))
                return false;

            var obj = HttpContext.Current.Session[sessionName];


            if (obj == null)
                return false;

            var text = obj.ToString();

            HttpContext.Current.Session[sessionName] = null;

            if (string.IsNullOrEmpty(text))
                return false;

            return string.Compare(text, vcode, true) == 0;
        }
    }
}
