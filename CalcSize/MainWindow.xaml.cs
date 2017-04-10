using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CalcSize
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            using (FolderBrowserDialog d = new FolderBrowserDialog())
            {
                if (d.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    StartCounterTask(d.SelectedPath);
                }
            }
        }

        private void StartCounterTask(string selectedPath)
        {
            Task t = Task.Run(() => 
            {
                this.Dispatcher.Invoke(() =>
                {
                    DoWork(selectedPath);
                });
                
            });
        }

        private void DoWork(string selectedPath)
        {
            FolderData fd = new FolderData(selectedPath);
            listBox.Items.Add(fd);

            DirectoryInfo di = new DirectoryInfo(selectedPath);

            CollectDirs(di, fd);
        }

        private void CollectDirs(DirectoryInfo di, FolderData fd)
        {
            try
            {
                foreach (var file in di.GetFiles())
                {
                    try
                    {
                        fd.Bytes += file.Length;
                    }
                    catch { }
                }
            }
            catch { }

            try
            {
                foreach (var d in di.GetDirectories())
                {
                    CollectDirs(d, fd);
                }
            }
            catch { }
        }
    }
}
