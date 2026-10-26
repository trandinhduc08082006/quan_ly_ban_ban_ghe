using System;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;

namespace QuanLyBanBanGhe.BLL.Helpers
{
    public static class SecurityHelper
    {
        public static string HashPassword(string plainText)
        {
            if (string.IsNullOrEmpty(plainText))
            {
                return string.Empty;
            }

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(plainText));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public static string BoDauTiengViet(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return string.Empty;
            }

            text = text.Replace("Đ", "D").Replace("đ", "d");
            string normalized = text.Normalize(NormalizationForm.FormD);
            StringBuilder sb = new StringBuilder();
            foreach (char c in normalized)
            {
                UnicodeCategory uc = CharUnicodeInfo.GetUnicodeCategory(c);
                if (uc != UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(c);
                }
            }
            return sb.ToString().Normalize(NormalizationForm.FormC);
        }

        public static string TaoMatKhauMacDinh(string hoTen)
        {
            if (string.IsNullOrWhiteSpace(hoTen))
            {
                return "User@123456";
            }

            string[] words = hoTen.Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string ten = words[words.Length - 1];
            string tenKhongDau = BoDauTiengViet(ten);
            if (string.IsNullOrWhiteSpace(tenKhongDau))
            {
                tenKhongDau = "User";
            }

            string tenChuanHoa = char.ToUpper(tenKhongDau[0]) + (tenKhongDau.Length > 1 ? tenKhongDau.Substring(1).ToLower() : string.Empty);
            return tenChuanHoa + "@123456";
        }
    }
}
