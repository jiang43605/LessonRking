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
using System.Windows.Shapes;

namespace WpfApplication1
{
    /// <summary>
    /// XianShiWindow.xaml 的交互逻辑
    /// </summary>
    public partial class XianShiWindow : Window
    {
        //public static List<string> name = new List<string>();
        //public static List<int> hours = new List<int>();
        public XianShiWindow()
        {
            InitializeComponent();
        }
        
        private void Panduan(MainWindow main, string classname)//此函数用于判断在打开课表之前，是否已经存在配置文件且其中配置文件中总课时是否是45
        {
            if (!File.Exists(System.Windows.Forms.Application.StartupPath + "\\" + classname))
            {
                MessageBox.Show("请先添加信息！", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
                return;

            }
            int totalhours = Judge.TotalHours();

            if (totalhours != 45)
            {
                MessageBox.Show("所添加的课时已经超过或小于45！", "错误！", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            main.j1 = Judge.DateClassReader(classname)[0];
            main.j2 = Judge.DateClassReader(classname)[1];
            main.j3 = Judge.DateClassReader(classname)[2];
            main.j4 = Judge.DateClassReader(classname)[3];
            main.j5 = Judge.DateClassReader(classname)[4];
            main.ShowDialog();
        }

        private void BtSet_Click(object sender, RoutedEventArgs e)
        {
            InputMode Input = new InputMode();
            Input.TbKemu.Focus();
            Input.ShowDialog();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow Mian = new MainWindow();
            Mian.Title = "一班";
            Panduan(Mian, "ClassOne.xml");

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow Mian = new MainWindow();
            Mian.Title = "二班";
            Panduan(Mian, "ClassTwo.xml");
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MainWindow Mian = new MainWindow();
            Mian.Title = "三班";
            Panduan(Mian, "ClassThree.xml");
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            MainWindow Mian = new MainWindow();
            Mian.Title = "四班";
            Panduan(Mian, "ClassFour.xml");
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            MainWindow Mian = new MainWindow();
            Mian.Title = "五班";
            Panduan(Mian, "ClassFive.xml");
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            MainWindow Mian = new MainWindow();
            Mian.Title = "六班";
            Panduan(Mian, "ClassSix.xml");

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void Btdeletclass_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult mbr = MessageBox.Show("将清除所有班级数据！", "重要提示", MessageBoxButton.YesNo, MessageBoxImage.Information);
            if (mbr == MessageBoxResult.Yes)
            {
                File.Delete(System.Windows.Forms.Application.StartupPath + "\\ClassOne.xml");
                File.Delete(System.Windows.Forms.Application.StartupPath + "\\ClassTwo.xml");
                File.Delete(System.Windows.Forms.Application.StartupPath + "\\ClassThree.xml");
                File.Delete(System.Windows.Forms.Application.StartupPath + "\\ClassFour.xml");
                File.Delete(System.Windows.Forms.Application.StartupPath + "\\ClassFive.xml");
                File.Delete(System.Windows.Forms.Application.StartupPath + "\\ClassSix.xml");
                MessageBox.Show("清除成功！", "提示", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            if (mbr == MessageBoxResult.No) { return; }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
