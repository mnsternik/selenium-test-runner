using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsTestRunner.Utilities
{
    internal class Logger
    {
        private static ListView _listView;

        public static void Initialize(ListView listView)
        {
            _listView = listView;
        }

        public static void Log(string message, bool isSuccess = false)
        {
            if (_listView.InvokeRequired)
            {
                _listView.Invoke(new Action(() => AddMessageToListView(message, isSuccess)));
            }
            else
            {
                AddMessageToListView(message, isSuccess);
            }
        }

        public static void Log(string message)
        {
            if (_listView.InvokeRequired)
            {
                _listView.Invoke(new Action(() => AddMessageToListView(message)));
            }
            else
            {
                AddMessageToListView(message);
            }
        }

        private static void AddMessageToListView(string message, bool isSuccess)
        {
            var listViewItem = new ListViewItem(DateTime.Now.ToString("HH:mm:ss"));
            listViewItem.SubItems.Add(message);
            listViewItem.SubItems.Add(isSuccess ? "Sukces" : "Błąd");

            _listView.Items.Add(listViewItem);
            _listView.EnsureVisible(_listView.Items.Count - 1);
        }

        private static void AddMessageToListView(string message)
        {
            var listViewItem = new ListViewItem(DateTime.Now.ToString("HH:mm:ss"));
            listViewItem.SubItems.Add(message);

            _listView.Items.Add(listViewItem);
            _listView.EnsureVisible(_listView.Items.Count - 1);
        }
    }
}
