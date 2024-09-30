using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsTestRunner.Utilities
{
    internal class DialogFileHandler
    {
        public static string GetFilePath(string fileTypeFilter, string? initialDirectory = null)
        {
            using OpenFileDialog openFileDialog = new OpenFileDialog();

            if (initialDirectory != null && Directory.Exists(initialDirectory))
            {
                openFileDialog.InitialDirectory = initialDirectory;
            }
            else
            {
                openFileDialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
            }

            openFileDialog.Filter = fileTypeFilter;
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                return openFileDialog.FileName;
            }
            else
            {
                return string.Empty;
            }
        }

        public static string GetFolderPath()
        {
            using FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.SelectedPath = AppDomain.CurrentDomain.BaseDirectory;
            folderBrowserDialog.ShowNewFolderButton = true;

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                return folderBrowserDialog.SelectedPath;
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
