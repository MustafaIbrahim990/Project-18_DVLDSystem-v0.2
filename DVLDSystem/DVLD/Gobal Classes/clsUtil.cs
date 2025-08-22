using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace DVLDSystem.Gobal_Classes
{
    public static class clsUtil
    {
        public static string GenerationGUID()
        {
            return Guid.NewGuid().ToString();
        }

        public static bool CreateFolderIfDoesNotExist(string FolderPath)
        {
            if (!Directory.Exists(FolderPath))
            {
                try
                {
                    Directory.CreateDirectory(FolderPath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Creating Folder : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            return true;
        }

        public static string RepleaceFileNameWithGUID(string SourceFile)
        {
            string fileName = SourceFile;
            FileInfo fi = new FileInfo(fileName);
            string extension = fi.Extension;
            return GenerationGUID() + extension;
        }

        public static bool CopyImageToProjectImagesFolder(ref string SourceFile)
        {
            string FolderPath = @"C:\Course 18 Projects\Project 4 DVLD System\DVLD_People_Images\";

            if (!CreateFolderIfDoesNotExist(FolderPath))
            {
                return false;
            }

            //Rename File To New GUID With The Same Extension :-
            string destinationFile = FolderPath + RepleaceFileNameWithGUID(SourceFile);


            //Copy File To Folder :-
            try
            {
                File.Copy(SourceFile, destinationFile, true);
            }
            catch (IOException iox)
            {
                MessageBox.Show(iox.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            SourceFile = destinationFile;
            return true;
        }

        //

        public static bool CreateFileIfDoesNotExist(string FilePath)
        {
            if (!File.Exists(FilePath))
            {
                try
                {
                    File.Create(FilePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Creating File : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            return true;
        }

        public static bool SaveUserNameANDPassWordInFile(string UserName, string PassWord)
        {
            string FolderPath = @"C:\Course 18 Projects\Project 4 DVLD System\DVLD_Users_LoginInfo\";
            string FilePath = @"C:\Course 18 Projects\Project 4 DVLD System\DVLD_Users_LoginInfo\UsersLoginInf.txt";

            if (!clsUtil.CreateFolderIfDoesNotExist(FolderPath))
                return false;

            if (!clsUtil.CreateFileIfDoesNotExist(FilePath))
                return false;

            try
            {
                File.WriteAllText(FilePath, String.Format($"{UserName}\n{PassWord}"));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        public static bool SaveEmptyUserNameANDPassWordInFile()
        {
            string FolderPath = @"C:\Course 18 Projects\Project 4 DVLD System\DVLD_Users_LoginInfo\";
            string FilePath = @"C:\Course 18 Projects\Project 4 DVLD System\DVLD_Users_LoginInfo\UsersLoginInf.txt";

            if (!clsUtil.CreateFolderIfDoesNotExist(FolderPath))
                return false;

            if (!clsUtil.CreateFileIfDoesNotExist(FilePath))
                return false;

            try
            {
                File.WriteAllText(FilePath, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        public static bool LoadUserNameANDPassWordFromFile(ref string UserName, ref string PassWord)
        {
            try
            {
                string FilePath = @"C:\Course 18 Projects\Project 4 DVLD System\DVLD_Users_LoginInfo\UsersLoginInf.txt";

                if (File.Exists(FilePath))
                {
                    string[] Lines = File.ReadAllLines(FilePath);

                    if (Lines.Length > 0)
                    {
                        UserName = Lines[0].Trim();
                        PassWord = Lines[1].Trim();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
    }
}