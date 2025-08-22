using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using DVLDSystem_BusinessLayer;
using DVLDSystem.Gobal_Classes;
using Microsoft.Win32;
using System.Security.Cryptography;

namespace DVLDSystem.DVLD.Global_User
{
    public static class clsGlobal
    {
        //Path Of Local Registry :-
        public static string KeyPath = @"HKEY_CURRENT_USER\Software\DVDL";
        public static clsUser CurrentUser;

        public static bool DeleteSubKeyFromLocalRegistry(string ValueName)
        {
            string KeyPath = @"Software\DVDL";

            try
            {
                // Open the registry key in read/write mode with explicit registry view
                using (RegistryKey baseKey = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64))
                {
                    using (RegistryKey Subkey = baseKey.OpenSubKey(KeyPath, true))
                    {
                        if (Subkey != null)
                        {
                            // Delete the specified value
                            if (Subkey.GetValue(ValueName) != null)
                            {
                                Subkey.DeleteValue(ValueName);
                            }
                            return true;
                        }
                    }
                }
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("UnauthorizedAccessException: Run the program with administrative privileges.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An Error Occurred : " + ex.Message);
            }
            return false;
        }

        public static bool SaveDataToLocalRegistry(string ValueName, string ValueData)
        {
            //string KeyPath = @"HKEY_CURRENT_USER\Software\DVDL";
            try
            {
                if (string.IsNullOrWhiteSpace(ValueData))
                {
                    return DeleteSubKeyFromLocalRegistry(ValueName);
                }

                Registry.SetValue(KeyPath, ValueName, ValueData, RegistryValueKind.String);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An Error Occurred : " + ex.Message);
                return false;
            }
        }

        public static string GetDataFromLocalRegistry(string ValueName)
        {
            //string KeyPath = @"HKEY_CURRENT_USER\Software\DVDL";
            string ValueData = "";

            try
            {
                ValueData = (string)Registry.GetValue(KeyPath, ValueName, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An Error Occurred : " + ex.Message);
                return null;
            }
            return ValueData;
        }

        public static bool SaveUserNameANDPassWord(string UserName, string PassWord)
        {
            return SaveDataToLocalRegistry("UserName", UserName) && SaveDataToLocalRegistry("PassWord", PassWord);
        }

        public static bool GetUserNameANDPassWord(ref string UserName, ref string PassWord)
        {
            UserName = GetDataFromLocalRegistry("UserName");
            PassWord = GetDataFromLocalRegistry("PassWord");

            return (UserName != null && PassWord != null) ? true : false;
        }

        public static string GenerateSalt()
        {
            byte[] SaltBytes = new byte[32];

            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(SaltBytes);
            }
            return BitConverter.ToString(SaltBytes).Replace("-", "");
        }

        public static string GenerateHash(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] HashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));

                return BitConverter.ToString(HashBytes).Replace("-", "");
            }
        }
    }
}