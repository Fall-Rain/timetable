using Newtonsoft.Json;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Utity
{
    public static class StringOption
    {
        public static T ToObject<T>(this string source)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(source);
            }
            catch
            {
                return default(T);
            }
        }
        public static string ToJson<T>(this T t)
        {
            return JsonConvert.SerializeObject(t);
        }

        private static readonly SymmetricAlgorithm mobjCryptoService = new DESCryptoServiceProvider();
        /// <summary>
        /// 加密数据
        /// </summary>
        /// <param name="plaintext">明文</param>
        /// <param name="key">密钥</param>
        /// <returns>密文</returns>
        public static string EncryptDES(this string plaintext, string key = "123456")
        {
            byte[] bytIn = System.Text.ASCIIEncoding.UTF8.GetBytes(plaintext);
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
            {
                mobjCryptoService.Key = GetLegalKey(key);
                mobjCryptoService.IV = GetLegalIV(key);
                ICryptoTransform encrypto = mobjCryptoService.CreateEncryptor();
                byte[] blankBuffer = GetPadding(mobjCryptoService.BlockSize, bytIn.Length);
                CryptoStream cs = new CryptoStream(ms, encrypto, CryptoStreamMode.Write);
                cs.Write(bytIn, 0, bytIn.Length);
                cs.Write(blankBuffer, 0, blankBuffer.Length);
                cs.FlushFinalBlock();
                cs.Close();
                byte[] bytOut = ms.ToArray();
                return System.Convert.ToBase64String(bytOut);
            }
        }
        /// <summary>
        /// 解密数据
        /// </summary>
        /// <param name="cipher">密文</param>
        /// <param name="key">密钥</param>
        /// <returns>明文</returns>
        public static string DecryptDES(this string cipher, string key = "123456")
        {
            byte[] bytIn = System.Convert.FromBase64String(cipher);
            using (MemoryStream ms = new System.IO.MemoryStream())
            {
                mobjCryptoService.Key = GetLegalKey(key);
                mobjCryptoService.IV = GetLegalIV(key);
                ICryptoTransform decrypto = mobjCryptoService.CreateDecryptor();
                using (CryptoStream cs = new CryptoStream(ms, decrypto, CryptoStreamMode.Write))
                {
                    cs.Write(bytIn, 0, bytIn.Length);
                    cs.FlushFinalBlock();
                    cs.Close();
                }
                byte[] outputs = ms.ToArray();
                ms.Close();
                return System.Text.ASCIIEncoding.UTF8.GetString(outputs).TrimEnd('\0');
            }
        }

        /// <summary>
        /// 根据分组大小和字节长度，计算得到需要补齐的空字节数组
        /// </summary>
        /// <param name="blockSize">分组大小(按bit)</param>
        /// <param name="byteLength">字节长度</param>
        /// <returns>空字节数组</returns>
        private static byte[] GetPadding(int blockSize, int byteLength)
        {
            int blockSizeInByte = blockSize / 8;
            int remainder = byteLength % blockSizeInByte;
            byte[] buffer = new byte[(blockSizeInByte - remainder) % blockSizeInByte];
            return buffer;
        }
        private static byte[] GetLegalKey(string key)
        {
            string temp;
            if (mobjCryptoService.LegalKeySizes.Length > 0)
            {
                int minSize = mobjCryptoService.LegalKeySizes[0].MinSize,
                    maxSize = mobjCryptoService.LegalKeySizes[0].MaxSize,
                    skipSize = mobjCryptoService.LegalKeySizes[0].SkipSize;

                int length = key.Length * 8;
                int moreSize = length;
                if (length > minSize && length <= maxSize)
                {
                    int currentSize = minSize;
                    while (currentSize < moreSize && currentSize < maxSize)
                    {
                        currentSize += skipSize;
                    }
                    if (currentSize >= maxSize)
                    {
                        moreSize = maxSize;
                    }
                    else
                    {
                        moreSize = currentSize;
                    }
                }
                //如果长度大于最大长度，则按最大长度计算
                else if (length > maxSize)
                {
                    moreSize = maxSize;
                    key = key.Substring(0, maxSize / 8);
                }
                else //小于最小长度，则按最小
                {
                    moreSize = minSize;
                }

                temp = key.PadRight(moreSize / 8, ' ');
            }
            else
            {
                temp = key;
            }
            return ASCIIEncoding.ASCII.GetBytes(temp);
        }

        /// <summary>
        /// 初始向量的长度需与分组大小一致，而不是与密钥长度一致
        /// 返回初始向量
        /// </summary>
        /// <param name="key">初始密钥</param>
        /// <returns>初始向量</returns>
        private static byte[] GetLegalIV(string key)
        {
            int blockSize = mobjCryptoService.BlockSize;
            if (key.Length * 8 > blockSize)
            {
                key = key.Substring(0, blockSize / 8);
            }
            return ASCIIEncoding.ASCII.GetBytes(key.PadRight(blockSize / 8, ' '));
        }

    }
}
