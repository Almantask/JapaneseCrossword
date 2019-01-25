using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using JapaneseCrossword.Core;

namespace JapaneseCrossword.DesktopClient
{
    internal class AnnouncerMessageBox:IAnnouncer
    {
        public void Show(string message)
        {
            MessageBox.Show(message);
        }
    }
}
