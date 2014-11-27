using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication1
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public int[] j1 = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public int[] j2 = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public int[] j3 = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public int[] j4 = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public int[] j5 = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        List<string> kemulist = new List<string>();//存放本地数据排列的序列号
        public MainWindow()
        {
            InitializeComponent();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (StreamReader srd = new StreamReader(System.Windows.Forms.Application.StartupPath + "\\app.xml", Encoding.UTF8))
            {
                while (srd.EndOfStream == false)
                {
                    string str = srd.ReadLine();
                    string str1 = str.Remove(12);
                    str1 = str1.Remove(0, 2);
                    str1 = str1.Remove(str1.IndexOf("*"));
                    kemulist.Add(str1);
                }
            }

            //将随机数带入kemulist，显示到DataGrid上面
            List<DateSet> list = new List<DateSet>();
            for (int k = 0; k < 9; k++)
            {
                list.Add(new DateSet { Id = k + 1, Monday = kemulist[j1[k]], Tuesday = kemulist[j2[k]], Wednesday = kemulist[j3[k]], Thursday = kemulist[j4[k]], Friday = kemulist[j5[k]] });
            }

            dg1.ItemsSource = list;
        }
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            InputMode Plugin = new InputMode();
            Plugin.ShowDialog();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
