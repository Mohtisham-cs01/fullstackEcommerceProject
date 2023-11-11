using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using WatchSpace.Models;

namespace WatchSpace.Helper
{
    public static class Common
    {

        public static string EncryptString(string text, string keyString)
        {
            var key = Encoding.UTF8.GetBytes(keyString);

            using (var aesAlg = Aes.Create())
            {
                using (var encryptor = aesAlg.CreateEncryptor(key, aesAlg.IV))
                {
                    using (var msEncrypt = new MemoryStream())
                    {
                        using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                        using (var swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(text);
                        }

                        var iv = aesAlg.IV;

                        var decryptedContent = msEncrypt.ToArray();

                        var result = new byte[iv.Length + decryptedContent.Length];

                        Buffer.BlockCopy(iv, 0, result, 0, iv.Length);
                        Buffer.BlockCopy(decryptedContent, 0, result, iv.Length, decryptedContent.Length);

                        return Convert.ToBase64String(result);
                    }
                }
            }
        }

        public static string DecryptString(string cipherText, string keyString)
        {
            var fullCipher = Convert.FromBase64String(cipherText);

            var iv = new byte[16];
            var cipher = new byte[16];

            Buffer.BlockCopy(fullCipher, 0, iv, 0, iv.Length);
            Buffer.BlockCopy(fullCipher, iv.Length, cipher, 0, iv.Length);
            var key = Encoding.UTF8.GetBytes(keyString);

            using (var aesAlg = Aes.Create())
            {
                using (var decryptor = aesAlg.CreateDecryptor(key, iv))
                {
                    string result;
                    using (var msDecrypt = new MemoryStream(cipher))
                    {
                        using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                        {
                            using (var srDecrypt = new StreamReader(csDecrypt))
                            {
                                result = srDecrypt.ReadToEnd();
                            }
                        }
                    }

                    return result;
                }
            }
        }

        public static string DynamicSetPasswordEmailTemplate(string First_Name, string Last_Name, string Link)
        {
            string SetPasswordEmailTemplate = Constants.SetPasswordEmailTemplate;
            return SetPasswordEmailTemplate.Replace(":::First_Name:::", First_Name).Replace(":::Last_Name:::", Last_Name).Replace(":::LINK:::", Link);
        }

        public static string DynamicOrderStatus(string First_Name, string Last_Name, string status , string RefrenceNumber)
        {
            string OrderStatusMessage = Constants.OrderStatusMessage;
            return OrderStatusMessage.Replace(":::First_Name:::", First_Name).Replace(":::Last_Name:::", Last_Name).Replace(":::Status:::", status).Replace(":::RefrenceNumber:::", RefrenceNumber); 
        }

        public static string DynamicResetPasswordEmailTemplate(string First_Name, string Last_Name, string Link)
        {
            string ResetPasswordEmailTemplate = Constants.ResetPasswordEmailTemplate;
            return ResetPasswordEmailTemplate.Replace(":::First_Name:::", First_Name).Replace(":::Last_Name:::", Last_Name).Replace(":::LINK:::", Link);
        }
        
        public static string DynamicSendEmailFromAdminToUsers(string First_Name, string Last_Name, string Message)
        {
            string AdminEmailTemplate = Constants.AdminEmailTemplate;
            return AdminEmailTemplate.Replace(":::First_Name:::", First_Name).Replace(":::Last_Name:::", Last_Name).Replace(":::Message:::", Message);
        }
        
        public static string DynamicOrderRefrenceNumberTemplate(string First_Name, string Last_Name, string RefrenceNumber)
        {
            string OrderRefrenceNumberTemplate = Constants.OrderConfirmTemplate;
            return OrderRefrenceNumberTemplate.Replace(":::First_Name:::", First_Name).Replace(":::Last_Name:::", Last_Name).Replace(":::RefrenceNumber:::", RefrenceNumber);
        }

    }
}
