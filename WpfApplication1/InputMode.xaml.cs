using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data;
using System.IO;
using System.Threading;
using System.Windows.Threading;

namespace WpfApplication1
{
    /// <summary>
    /// InputMode.xaml 的交互逻辑
    /// </summary>
    public partial class InputMode : Window
    {
        double it = -1;
        int classcount = 0;
        int alreadyfinishclasscount = 0;
        bool cb1 = false, cb2 = false, cb3 = false, cb4 = false, cb5 = false, cb6 = false;
        JinDu jd = new JinDu();
        public InputMode()
        {
            InitializeComponent();
        }
        private void RichTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void BtFalse_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtPlugin_Click(object sender, RoutedEventArgs e)
        {
            //输入数据前对格式是否正确的检测
            if (TbKemu.Text == "" || TbHours.Text == "")
            {
                MessageBox.Show("请输入内容！", "提示", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (TbKemu.Text == "　")
            {
                MessageBox.Show("请将输入法调为半角模式！", "提示", MessageBoxButton.OK, MessageBoxImage.Error);
                TbKemu.Clear();
                TbKemu.Focus();
                return;
            }
            if (TbKemu.Text.IndexOf(" ") != -1)
            {
                if (TbKemu.Text.Length > 1)
                {
                    MessageBox.Show("课表输入格式错误，不能在科目中加空格！或者如果你想只输入空格，请只输入一个！", "提示", MessageBoxButton.OK, MessageBoxImage.Error);
                    TbKemu.Clear();
                    TbKemu.Focus();
                    return;
                }
            }
            int number;
            bool result = int.TryParse(TbHours.Text, out number);
            if (result)
            {
                if (number <= 0 || number > 15) { MessageBox.Show("你输入的课时错误", "错误", MessageBoxButton.OK, MessageBoxImage.Error); TbHours.Focus(); return; }
            }
            else
            {
                MessageBox.Show("课时格式输入错误", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
                TbHours.Focus();
                return;
            }
            if (File.Exists(System.Windows.Forms.Application.StartupPath + "\\app.xml"))//检测添加科目是否与本地存在的科目重名
            {
                for (int alct = 0; alct < Judge.LocalKemu().Count; alct++)
                {
                    if (TbKemu.Text == Judge.LocalKemu()[alct])
                    {
                        MessageBoxResult mbr = MessageBox.Show("发现该科目已经存在，是否仍然添加？（适用于同一门课不同老师的情况）", "提示", MessageBoxButton.YesNo, MessageBoxImage.Information);
                        if (mbr == MessageBoxResult.Yes) { }
                        if (mbr == MessageBoxResult.No) { TbHours.Text = ""; TbKemu.Text = ""; TbKemu.Focus(); return; }
                    }
                }

            }
            //通过格式检测，开始写入本地文件
            try
            {
                int totalhours = Judge.TotalHours();

                if (totalhours == 0 || totalhours < 45)//如果本地存储文件不存在或者总课时小于45
                {
                    if (totalhours + Convert.ToInt32(TbHours.Text) > 45)
                    {
                        MessageBox.Show("不能添加此科目，否则总课时将超出", "添加失败！", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    Judge.DateRecord((bool)CbSimily.IsChecked, Cbcount.Text, TbKemu.Text, TbHours.Text, true);
                    MessageBox.Show("添加成功！", "提示", MessageBoxButton.OK, MessageBoxImage.Information);
                    LbNumber.Content = Judge.LocalKemu().Count;
                    LbTime.Content = Judge.TotalHours();
                    TbHours.Text = "";
                    TbKemu.Text = "";
                    TbKemu.Focus();
                    CbSimily.IsChecked = false;
                    //显示本地存储的科目及课时信息数据到ComBox上
                    Cbshow.ItemsSource = Judge.ReaderLoaclKemuAndHoursData();
                    Cbshow.SelectedIndex = 0;
                    return;
                }
                if (totalhours >= 45)//如果本地文件存在则判断其中课时是否超出总课时
                {
                    MessageBoxResult mbr = MessageBox.Show("所添加的课时已满或者已经超过45！，是否重新配置？", "错误！", MessageBoxButton.YesNo, MessageBoxImage.Error);
                    if (mbr == MessageBoxResult.Yes)
                    {
                        Judge.DateRecord((bool)CbSimily.IsChecked, Cbcount.Text, TbKemu.Text, TbHours.Text, false);
                        MessageBox.Show("添加成功！", "提示", MessageBoxButton.OK, MessageBoxImage.Information);
                        LbNumber.Content = Judge.LocalKemu().Count;
                        LbTime.Content = Judge.TotalHours();
                        TbHours.Text = "";
                        TbKemu.Text = "";
                        TbKemu.Focus();
                        CbSimily.IsChecked = false;
                        //显示本地存储的科目及课时信息数据到ComBox上
                        Cbshow.ItemsSource = Judge.ReaderLoaclKemuAndHoursData();
                        Cbshow.SelectedIndex = 0;
                    }
                    if (mbr == MessageBoxResult.No)
                    {
                        TbHours.Clear();
                        TbKemu.Clear();
                        return;
                    }
                }
            }
            catch
            {
                MessageBox.Show("存储文件发生错误,将进行删除！", "未知错误！", MessageBoxButton.OK, MessageBoxImage.Error);
                File.Delete(System.Windows.Forms.Application.StartupPath + "\\app.xml");
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CbSimily.ToolTip = Judge.AddStringEnter("你如果勾选上此项则代表你添加的这个科目在不同班级中不会出现在相同位置（注意：如果同时有很多科目都添加了此属性，则可能造成生成课表的时间较长）", 15);
            LbTime.Content = Judge.TotalHours();
            LbNumber.Content = Judge.LocalKemu().Count;
            List<string> Cbcountlist = new List<string>();//此集合仅仅用于生成ComBox中的下拉内容
            Cbcountlist.Add("任意");
            Cbcountlist.Add("1");
            Cbcountlist.Add("2");
            Cbcountlist.Add("3");
            Cbcount.ItemsSource = Cbcountlist;
            Cbcount.SelectedIndex = 0; //ComeBox中用来设置第一个显示的内容，同样可以设置的为SelectedItem
            //显示本地存储的科目及课时信息数据到ComBox上
            if (File.Exists(System.Windows.Forms.Application.StartupPath + "\\app.xml"))
            {
                //显示本地存储的科目及课时信息数据到ComBox上
                Cbshow.ItemsSource = Judge.ReaderLoaclKemuAndHoursData();
                Cbshow.SelectedIndex = 0;
            }
        }
        private void TbKemu_GotFocus(object sender, RoutedEventArgs e)
        {
        }
        public delegate void NextPrimeDelegate();
        public void itcontent()
        {
            // LbContent.Content ="正在为您尝试生成符合要求的课表"+it+"次，请耐心等待！";
            jd.Lbclasscontent.Content = alreadyfinishclasscount;
            double hh = double.Parse((it / 5000).ToString("0.00")) * 100;
            jd.Lab.Content = hh + "%";
            jd.Pbbar.Value++;
        }
        public void threadfist()
        {
            jd.ShowDialog();
        }
        public void JdThread(object a)
        {
            this.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal, new NextPrimeDelegate(threadfist));
            List<int[]> classlist1 = new List<int[]>();//存储1班课表顺序的集合
            Judge.ClassInitialize("ClassOne.xml", classlist1);
            List<int[]> classlist2 = new List<int[]>();//存储2班课表顺序的集合
            Judge.ClassInitialize("ClassTwo.xml", classlist2);
            List<int[]> classlist3 = new List<int[]>();//存储3班课表顺序的集合
            Judge.ClassInitialize("ClassThree.xml", classlist3);
            List<int[]> classlist4 = new List<int[]>();//存储4班课表顺序的集合
            Judge.ClassInitialize("ClassFour.xml", classlist4);
            List<int[]> classlist5 = new List<int[]>();//存储5班课表顺序的集合
            Judge.ClassInitialize("ClassFive.xml", classlist5);
            List<int[]> classlist6 = new List<int[]>();//存储6班课表顺序的集合
            Judge.ClassInitialize("ClassSix.xml", classlist6);
            List<string> kemulist = new List<string>();//存放本地科目数据排列的序列号
            List<string> kemusimilylist = new List<string>();//存放本地科目是否可重复的标记码
            List<int> kemuRandomlist = new List<int>();//存放排列为任意科目的集合
            List<int> kemulist1 = new List<int>();//存放排列为1科目的集合
            List<int> kemulist2 = new List<int>();//存放排列为2科目的集合
            List<int> kemulist3 = new List<int>();//存放排列为3科目的集合
            List<int> hourslist = new List<int>();//存放当前本地数据科目的时间，为动态的，可删减
            List<int> zhourslist = new List<int>();//存放本地数据科目的时间，为永久性数据，不可删减
            Random rd = new Random();
            int i = 0, ai = 0;
            //将数据写入表格中
            //File.Copy(System.Windows.Forms.Application.StartupPath + "\\app.xml", System.Windows.Forms.Application.StartupPath + "\\cpapp.xml", true);
            using (StreamReader srd = new StreamReader(System.Windows.Forms.Application.StartupPath + "\\app.xml", Encoding.UTF8))
            {

                while (srd.EndOfStream == false)
                {
                    string str = srd.ReadLine();
                    string strzifu = str.Remove(1);
                    switch (strzifu)
                    {
                        case "!":
                            kemuRandomlist.Add(ai);
                            break;
                        case "@":
                            kemulist1.Add(ai);
                            break;
                        case "#":
                            kemulist2.Add(ai);
                            break;
                        case "$":
                            kemulist3.Add(ai);
                            break;
                        default:
                            MessageBox.Show("数据分类出错！", "提示", MessageBoxButton.OK, MessageBoxImage.Error);
                            break;

                    }
                    ai++;
                    string str1 = str.Remove(12);
                    str1 = str1.Remove(0, 2);
                    str1 = str1.Remove(str1.IndexOf("*"));
                    string str2 = str.Remove(0, 13);
                    string str3 = str.Remove(2);
                    str3 = str3.Remove(0, 1);
                    hourslist.Add(Convert.ToInt32(str2));
                    kemulist.Add(str1);
                    kemusimilylist.Add(str3);
                    i++;
                }
            }
            for (int z = 0; z < hourslist.Count; z++)
            {
                zhourslist.Add(hourslist[z]);
            }
            int[] j1 = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int[] j2 = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int[] j3 = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int[] j4 = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int[] j5 = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            //在诸多限制下生成指定几个班的j1,j2,j3,j4,j5
            //double value = 0;
            for (int cct = 0; cct < classcount; cct++)
            {
            gt: for (int z = 0; z < zhourslist.Count; z++)
                {
                    hourslist[z] = zhourslist[z];
                }
                it++;
                LbContent.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal, new NextPrimeDelegate(itcontent));
                if (it > 5000) { MessageBox.Show("您之前输入的数据只能生成" + alreadyfinishclasscount + "个符合要求的课表！请检查您输入的科目及相应的课时", "错误提示", MessageBoxButton.OK, MessageBoxImage.Error); jd.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal, new NextPrimeDelegate(windowslose)); return; }
                if (!Judge.DateLastJudge(i, 15, 5, 10, 15, hourslist, kemuRandomlist, kemulist1, kemulist2, kemulist3)) { MessageBox.Show("数据出现致命错误！建议到设置中点击清空按钮并重新输入数据！", "失败", MessageBoxButton.OK, MessageBoxImage.Error); }
                j1 = Judge.DateArrange(i, kemuRandomlist, kemulist1, kemulist2, kemulist3, Judge.DateReduceV(i, hourslist), hourslist, zhourslist);//给j1生成一个没有重复四位以上的九位数
                hourslist = Judge.DateReduce(i, hourslist, j1);//重新配置hourslist，将在j1中已经出现过的科目减去相应课时
                Thread.Sleep(20);

                if (!Judge.DateLastJudge(i, 12, 4, 8, 12, hourslist, kemuRandomlist, kemulist1, kemulist2, kemulist3)) { goto gt; }
                j2 = Judge.DateArrange(i, kemuRandomlist, kemulist1, kemulist2, kemulist3, Judge.DateReduceV(i, hourslist), hourslist, zhourslist);//将新的hourslist传入DateReduceV方法中，将返回的值再传入DateArrage中，得到在j1基础上的j2
                hourslist = Judge.DateReduce(i, hourslist, j2);
                Thread.Sleep(20);

                if (!Judge.DateLastJudge(i, 9, 3, 6, 9, hourslist, kemuRandomlist, kemulist1, kemulist2, kemulist3)) { goto gt; }
                j3 = Judge.DateArrange(i, kemuRandomlist, kemulist1, kemulist2, kemulist3, Judge.DateReduceV(i, hourslist), hourslist, zhourslist);
                hourslist = Judge.DateReduce(i, hourslist, j3);
                Thread.Sleep(20);

                if (!Judge.DateLastJudge(i, 6, 2, 4, 6, hourslist, kemuRandomlist, kemulist1, kemulist2, kemulist3)) { goto gt; }
                j4 = Judge.DateArrange(i, kemuRandomlist, kemulist1, kemulist2, kemulist3, Judge.DateReduceV(i, hourslist), hourslist, zhourslist);
                hourslist = Judge.DateReduce(i, hourslist, j4);
                Thread.Sleep(20);

                if (!Judge.DateLastJudge(i, 3, 1, 2, 3, hourslist, kemuRandomlist, kemulist1, kemulist2, kemulist3)) { goto gt; }
                j5 = Judge.DateArrange(i, kemuRandomlist, kemulist1, kemulist2, kemulist3, Judge.DateReduceV(i, hourslist), hourslist, zhourslist);
                hourslist = Judge.DateReduce(i, hourslist, j5);


                if (cb1 && classlist1.Count == 0) { classlist1.Add(j1); classlist1.Add(j2); classlist1.Add(j3); classlist1.Add(j4); classlist1.Add(j5); if (Judge.IsSimilyBetweenClassTable(kemusimilylist, classlist1, classlist2, classlist3, classlist4, classlist5, classlist6)) { classlist1.Clear(); goto gt; } alreadyfinishclasscount++; continue; }
                if (cb2 && classlist2.Count == 0) { classlist2.Add(j1); classlist2.Add(j2); classlist2.Add(j3); classlist2.Add(j4); classlist2.Add(j5); if (Judge.IsSimilyBetweenClassTable(kemusimilylist, classlist1, classlist2, classlist3, classlist4, classlist5, classlist6)) { classlist2.Clear(); goto gt; } alreadyfinishclasscount++; continue; }
                if (cb3 && classlist3.Count == 0) { classlist3.Add(j1); classlist3.Add(j2); classlist3.Add(j3); classlist3.Add(j4); classlist3.Add(j5); if (Judge.IsSimilyBetweenClassTable(kemusimilylist, classlist1, classlist2, classlist3, classlist4, classlist5, classlist6)) { classlist3.Clear(); goto gt; } alreadyfinishclasscount++; continue; }
                if (cb4 && classlist4.Count == 0) { classlist4.Add(j1); classlist4.Add(j2); classlist4.Add(j3); classlist4.Add(j4); classlist4.Add(j5); if (Judge.IsSimilyBetweenClassTable(kemusimilylist, classlist1, classlist2, classlist3, classlist4, classlist5, classlist6)) { classlist4.Clear(); goto gt; } alreadyfinishclasscount++; continue; }
                if (cb5 && classlist5.Count == 0) { classlist5.Add(j1); classlist5.Add(j2); classlist5.Add(j3); classlist5.Add(j4); classlist5.Add(j5); if (Judge.IsSimilyBetweenClassTable(kemusimilylist, classlist1, classlist2, classlist3, classlist4, classlist5, classlist6)) { classlist5.Clear(); goto gt; } alreadyfinishclasscount++; continue; }
                if (cb6 && classlist6.Count == 0) { classlist6.Add(j1); classlist6.Add(j2); classlist6.Add(j3); classlist6.Add(j4); classlist6.Add(j5); if (Judge.IsSimilyBetweenClassTable(kemusimilylist, classlist1, classlist2, classlist3, classlist4, classlist5, classlist6)) { classlist6.Clear(); goto gt; } alreadyfinishclasscount++; continue; }
            }
            while (it < 5000)
            {
                for (int hu = 0; hu < 5000 - it; hu++)
                {
                    Thread.Sleep(2);
                    it++;
                    LbContent.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal, new NextPrimeDelegate(itcontent));
                }
            }
            //生成六个班级的本地存储文件
            Judge.DateClass(cb1, classlist1, "ClassOne.xml");
            Judge.DateClass(cb2, classlist2, "ClassTwo.xml");
            Judge.DateClass(cb3, classlist3, "ClassThree.xml");
            Judge.DateClass(cb4, classlist4, "ClassFour.xml");
            Judge.DateClass(cb5, classlist5, "ClassFive.xml");
            Judge.DateClass(cb6, classlist6, "ClassSix.xml");
            MessageBox.Show("成功生成了" + alreadyfinishclasscount + "个指定科目未重复的课表,请在主界面点击相应的班级查看！", "提示", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            jd.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal, new NextPrimeDelegate(windowslose));
        }
        public void windowslose()
        {
            jd.Close();

        }

        private void BtFinish_Click(object sender, RoutedEventArgs e)
        {
            if (classcount == 0) { MessageBox.Show("还未选择要班级！", "错误提示！", MessageBoxButton.OK, MessageBoxImage.Error); return; }
            if (classcount > 6) { MessageBox.Show("班级数量发生错误，建议重新运行！", "错误提示！", MessageBoxButton.OK, MessageBoxImage.Error); return; }
            if (Judge.TotalHours() != 45)
            {

                MessageBox.Show("课表无法生成！因为课时数不等于45！,请添加满45课时！", "错误提示！", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            MessageBox.Show("即将进行数据运算，由于是按要求随机生成，不同要求可能需要的时间也不一样，请耐心等待！", "提示", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            ThreadPool.QueueUserWorkItem(this.JdThread);            
            this.Close();
        }

        private void BtDelet_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult mrt = MessageBox.Show("将清空所有本地数据！确定吗？", "提示", MessageBoxButton.OKCancel, MessageBoxImage.Information);
            if (mrt == MessageBoxResult.OK)
            {
                File.Delete(System.Windows.Forms.Application.StartupPath + "\\app.xml");
                File.Delete(System.Windows.Forms.Application.StartupPath + "\\ClassOne.xml");
                File.Delete(System.Windows.Forms.Application.StartupPath + "\\ClassTwo.xml");
                File.Delete(System.Windows.Forms.Application.StartupPath + "\\ClassThree.xml");
                File.Delete(System.Windows.Forms.Application.StartupPath + "\\ClassFour.xml");
                File.Delete(System.Windows.Forms.Application.StartupPath + "\\ClassFive.xml");
                File.Delete(System.Windows.Forms.Application.StartupPath + "\\ClassSix.xml");
                LbTime.Content = Judge.TotalHours();
                TbKemu.Focus();
            }
            if (mrt == MessageBoxResult.Cancel)
            {
                TbKemu.Focus();
                return;
            }
        }

        private void CB1_Checked(object sender, RoutedEventArgs e)
        {
            if (!File.Exists(System.Windows.Forms.Application.StartupPath + "\\app.xml")) { MessageBox.Show("还未添加必要的科目或者课时！", "错误", MessageBoxButton.OK, MessageBoxImage.Information); CB1.IsChecked = false; return; }
            if (File.Exists(System.Windows.Forms.Application.StartupPath + "\\ClassOne.xml"))
            {
                MessageBoxResult mbr = MessageBox.Show("检测到本地有存在该班级文件数据，是否对其进行覆盖？（不可挽回）", "提示", MessageBoxButton.YesNo, MessageBoxImage.Information);
                if (mbr == MessageBoxResult.Yes) { File.Delete(System.Windows.Forms.Application.StartupPath + "\\ClassOne.xml"); }
                if (mbr == MessageBoxResult.No) { CB1.IsChecked = false; return; }
            }
            classcount++;
            CB1.IsEnabled = false;
            cb1 = true;
        }

        private void CB2_Checked(object sender, RoutedEventArgs e)
        {
            if (!File.Exists(System.Windows.Forms.Application.StartupPath + "\\app.xml")) { MessageBox.Show("还未添加必要的科目或者课时！", "错误", MessageBoxButton.OK, MessageBoxImage.Information); CB2.IsChecked = false; return; }
            if (File.Exists(System.Windows.Forms.Application.StartupPath + "\\ClassTwo.xml"))
            {
                MessageBoxResult mbr = MessageBox.Show("检测到本地有存在该班级文件数据，是否对其进行覆盖？（不可挽回）", "提示", MessageBoxButton.YesNo, MessageBoxImage.Information);
                if (mbr == MessageBoxResult.Yes) { File.Delete(System.Windows.Forms.Application.StartupPath + "\\ClassTwo.xml"); }
                if (mbr == MessageBoxResult.No) { CB2.IsChecked = false; return; }
            }
            classcount++;
            CB2.IsEnabled = false;
            cb2 = true;
        }

        private void CB3_Checked(object sender, RoutedEventArgs e)
        {
            if (!File.Exists(System.Windows.Forms.Application.StartupPath + "\\app.xml")) { MessageBox.Show("还未添加必要的科目或者课时！", "错误", MessageBoxButton.OK, MessageBoxImage.Information); CB3.IsChecked = false; return; }
            if (File.Exists(System.Windows.Forms.Application.StartupPath + "\\ClassThree.xml"))
            {
                MessageBoxResult mbr = MessageBox.Show("检测到本地有存在该班级文件数据，是否对其进行覆盖？（不可挽回）", "提示", MessageBoxButton.YesNo, MessageBoxImage.Information);
                if (mbr == MessageBoxResult.Yes) { File.Delete(System.Windows.Forms.Application.StartupPath + "\\ClassThree.xml"); }
                if (mbr == MessageBoxResult.No) { CB3.IsChecked = false; return; }
            }
            classcount++;
            CB3.IsEnabled = false;
            cb3 = true;
        }

        private void CB4_Checked(object sender, RoutedEventArgs e)
        {
            if (!File.Exists(System.Windows.Forms.Application.StartupPath + "\\app.xml")) { MessageBox.Show("还未添加必要的科目或者课时！", "错误", MessageBoxButton.OK, MessageBoxImage.Information); CB4.IsChecked = false; return; }
            if (File.Exists(System.Windows.Forms.Application.StartupPath + "\\ClassFour.xml"))
            {
                MessageBoxResult mbr = MessageBox.Show("检测到本地有存在该班级文件数据，是否对其进行覆盖？（不可挽回）", "提示", MessageBoxButton.YesNo, MessageBoxImage.Information);
                if (mbr == MessageBoxResult.Yes) { File.Delete(System.Windows.Forms.Application.StartupPath + "\\ClassFour.xml"); }
                if (mbr == MessageBoxResult.No) { CB4.IsChecked = false; return; }
            }
            classcount++;
            CB4.IsEnabled = false;
            cb4 = true;
        }

        private void CB5_Checked(object sender, RoutedEventArgs e)
        {
            if (!File.Exists(System.Windows.Forms.Application.StartupPath + "\\app.xml")) { MessageBox.Show("还未添加必要的科目或者课时！", "错误", MessageBoxButton.OK, MessageBoxImage.Information); CB5.IsChecked = false; return; }
            if (File.Exists(System.Windows.Forms.Application.StartupPath + "\\ClassFive.xml"))
            {
                MessageBoxResult mbr = MessageBox.Show("检测到本地有存在该班级文件数据，是否对其进行覆盖？（不可挽回）", "提示", MessageBoxButton.YesNo, MessageBoxImage.Information);
                if (mbr == MessageBoxResult.Yes) { File.Delete(System.Windows.Forms.Application.StartupPath + "\\ClassFive.xml"); }
                if (mbr == MessageBoxResult.No) { CB5.IsChecked = false; return; }
            }
            classcount++;
            CB5.IsEnabled = false;
            cb5 = true;
        }

        private void CB6_Checked(object sender, RoutedEventArgs e)
        {
            if (!File.Exists(System.Windows.Forms.Application.StartupPath + "\\app.xml")) { MessageBox.Show("还未添加必要的科目或者课时！", "错误", MessageBoxButton.OK, MessageBoxImage.Information); CB6.IsChecked = false; return; }
            if (File.Exists(System.Windows.Forms.Application.StartupPath + "\\ClassSix.xml"))
            {
                MessageBoxResult mbr = MessageBox.Show("检测到本地有存在该班级文件数据，是否对其进行覆盖？（不可挽回）", "提示", MessageBoxButton.YesNo, MessageBoxImage.Information);
                if (mbr == MessageBoxResult.Yes) { File.Delete(System.Windows.Forms.Application.StartupPath + "\\ClassSix.xml"); }
                if (mbr == MessageBoxResult.No) { CB6.IsChecked = false; return; }
            }
            classcount++;
            CB6.IsEnabled = false;
            cb6 = true;
        }
        private void BtDeletKemuHours_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult mbr = MessageBox.Show("你确定要删除该科目吗？", "提示", MessageBoxButton.YesNo, MessageBoxImage.Information);
            if (mbr == MessageBoxResult.Yes)
            {
                if (Cbshow.Text == "课目" + "　　　　　　　　　｜　　　　　　　　" + "课时数" || Cbshow.Text == "总课时" + "　　　　　　　　｜　　　　　　　　" + Judge.TotalHours())
                {
                    MessageBox.Show("删除项选择错误", "删除失败", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (File.Exists(System.Windows.Forms.Application.StartupPath + "\\app.xml"))
                {
                    //显示本地存储的科目及课时信息数据到ComBox上
                    Judge.DeletLoaclKemuAndHoursData(this);
                    Cbshow.ItemsSource = Judge.ReaderLoaclKemuAndHoursData();
                    Cbshow.SelectedIndex = 0;
                    LbTime.Content = Judge.TotalHours();
                    LbNumber.Content = Judge.LocalKemu().Count;
                    MessageBox.Show("删除成功！", "信息", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("未存在任何数据可供删除", "删除失败", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
            if (mbr == MessageBoxResult.No) { return; }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CB1.IsChecked = true;
            CB2.IsChecked = true;
            CB3.IsChecked = true;
            CB4.IsChecked = true;
            CB5.IsChecked = true;
            CB6.IsChecked = true;
            BtAll.IsEnabled = false;
        }












    }
}
