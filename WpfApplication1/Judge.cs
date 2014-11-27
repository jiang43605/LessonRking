using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
/*
 * 程序存在BUG，位于539-585行
 * 具体错误为：每运行一次，当529行处的K值变为1时，539-585行出现跳转BUG，跳转回529行，导致出现无限循环无解
 */

namespace WpfApplication1
{
    class Judge
    {
        public static string AddStringEnter(string str, int i)//用来在一段字符串指定字节数后加换行符
        {
            string str1 = str;
            while (true)
            {
                if (str.Length > i)
                {
                    string str2 = str.Remove(i);
                    if (str1 == str) { str1 = str2 + "\r\n"; }
                    else { str1 = str1 + str2 + "\r\n"; }
                    str = str.Remove(0, i);
                }
                else
                {
                    str1 = str1 + str;
                    return str1;
                }
            }
        }
        public static void ClassInitialize(string classname, List<int[]> classlist)//用来对classlist的值进行初始化
        {
            if (File.Exists(System.Windows.Forms.Application.StartupPath + "\\" + classname))
            {
                for (int cl1 = 0; cl1 < Judge.DateClassReader(classname).Count; cl1++)
                {
                    classlist.Add(Judge.DateClassReader(classname)[cl1]);
                }
            }
        }
        private static bool ISBCT(List<int[]> classpanduan1, List<int[]> classpanduan2, List<string> kemusimilylist)//仅仅用于供该类目下IsSimilyBetweenClassTable调用，不供外部调用
        {
            if (classpanduan2.Count != 0)
            {
                for (int a = 0; a < 5; a++)
                {
                    for (int a1 = 0; a1 < 9; a1++)
                    {
                        if (classpanduan1[a][a1] == classpanduan2[a][a1])
                        {
                            if (kemusimilylist[classpanduan1[a][a1]] == "1") { return true; }
                        }
                    }
                }
            }
            return false;
        }
        public static bool IsSimilyBetweenClassTable(List<string> kemusimilylist, List<int[]> classlist1, List<int[]> classlist2, List<int[]> classlist3, List<int[]> classlist4, List<int[]> classlist5, List<int[]> classlist6)//用来判断生成的课表中是否存在相同科目在不同班级中同一位置出现，如果出现就返回true,否则返回false
        {
            if (classlist1.Count != 0)
            {
                if (Judge.ISBCT(classlist1, classlist2, kemusimilylist)) { return true; }
                if (Judge.ISBCT(classlist1, classlist3, kemusimilylist)) { return true; }
                if (Judge.ISBCT(classlist1, classlist4, kemusimilylist)) { return true; }
                if (Judge.ISBCT(classlist1, classlist5, kemusimilylist)) { return true; }
                if (Judge.ISBCT(classlist1, classlist6, kemusimilylist)) { return true; }
            }
            if (classlist2.Count != 0)
            {
                if (Judge.ISBCT(classlist2, classlist1, kemusimilylist)) { return true; }
                if (Judge.ISBCT(classlist2, classlist3, kemusimilylist)) { return true; }
                if (Judge.ISBCT(classlist2, classlist4, kemusimilylist)) { return true; }
                if (Judge.ISBCT(classlist2, classlist5, kemusimilylist)) { return true; }
                if (Judge.ISBCT(classlist2, classlist6, kemusimilylist)) { return true; }
            }
            if (classlist3.Count != 0)
            {
                if (Judge.ISBCT(classlist3, classlist1, kemusimilylist)) { return true; }
                if (Judge.ISBCT(classlist3, classlist2, kemusimilylist)) { return true; }
                if (Judge.ISBCT(classlist3, classlist4, kemusimilylist)) { return true; }
                if (Judge.ISBCT(classlist3, classlist5, kemusimilylist)) { return true; }
                if (Judge.ISBCT(classlist3, classlist6, kemusimilylist)) { return true; }
            }
            if (classlist4.Count != 0)
            {
                if (Judge.ISBCT(classlist4, classlist1, kemusimilylist)) { return true; }
                if (Judge.ISBCT(classlist4, classlist2, kemusimilylist)) { return true; }
                if (Judge.ISBCT(classlist4, classlist3, kemusimilylist)) { return true; }
                if (Judge.ISBCT(classlist4, classlist5, kemusimilylist)) { return true; }
                if (Judge.ISBCT(classlist4, classlist6, kemusimilylist)) { return true; }
            }
            if (classlist5.Count != 0)
            {
                if (Judge.ISBCT(classlist5, classlist1, kemusimilylist)) { return true; }
                if (Judge.ISBCT(classlist5, classlist2, kemusimilylist)) { return true; }
                if (Judge.ISBCT(classlist5, classlist3, kemusimilylist)) { return true; }
                if (Judge.ISBCT(classlist5, classlist4, kemusimilylist)) { return true; }
                if (Judge.ISBCT(classlist5, classlist6, kemusimilylist)) { return true; }
            }
            if (classlist6.Count != 0)
            {
                if (Judge.ISBCT(classlist6, classlist1, kemusimilylist)) { return true; }
                if (Judge.ISBCT(classlist6, classlist2, kemusimilylist)) { return true; }
                if (Judge.ISBCT(classlist6, classlist3, kemusimilylist)) { return true; }
                if (Judge.ISBCT(classlist6, classlist4, kemusimilylist)) { return true; }
                if (Judge.ISBCT(classlist6, classlist5, kemusimilylist)) { return true; }
            }
            return false;
        }
        public static void DeletLoaclKemuAndHoursData(InputMode Inputmode)//用于从ComBox显示的文本中删除本地存储数据中科目和时间
        {
            string Geshi = "　　　　　　　　　｜　　　　　　　　";
            List<string> OldeKemuHours = new List<string>();
            using (StreamReader sr = new StreamReader(System.Windows.Forms.Application.StartupPath + "\\app.xml", Encoding.UTF8))
            {
                while (sr.EndOfStream == false)
                {
                    string str = sr.ReadLine();
                    string str1 = str;
                    str1 = str1.Remove(0, 2);
                    str1 = str1.Remove(str1.IndexOf("*")) + str1.Remove(0, 11);
                    string str2="";
                    if (Inputmode.Cbshow.Text.Remove(1) == "　")
                    {
                        str2 = " " + Inputmode.Cbshow.Text.Remove(Inputmode.Cbshow.Text.IndexOf("　"), Geshi.Length - (Inputmode.Cbshow.Text.Remove(Inputmode.Cbshow.Text.IndexOf("　")).Length - 2));
                         
                    }
                    else
                    {
                         str2 = Inputmode.Cbshow.Text.Remove(Inputmode.Cbshow.Text.IndexOf("　"), Geshi.Length - (Inputmode.Cbshow.Text.Remove(Inputmode.Cbshow.Text.IndexOf("　")).Length - 2));
                    }
                    if (str1 == str2)
                    {
                        continue;
                    }
                    OldeKemuHours.Add(str);
                }
            }
            File.Delete(System.Windows.Forms.Application.StartupPath + "\\app.xml");
            using (StreamWriter sw = new StreamWriter(System.Windows.Forms.Application.StartupPath + "\\app.xml", false, Encoding.UTF8))
            {
                for (int q = 0; q < OldeKemuHours.Count; q++)
                {
                    sw.WriteLine(OldeKemuHours[q]);
                }
            }

        }
        public static List<string> ReaderLoaclKemuAndHoursData()//用于返回本地存储数据中所有的科目和时间，以便于显示在ComBox上
        {
            List<string> Cbshowkemuhours = new List<string>();//此集合仅仅用于生成ComBox中的下拉内容
            //string cbshowkongge = "                           |                              ";
            string cbshowkongge = "　　　　　　　　　｜　　　　　　　　";
            Cbshowkemuhours.Add("课目" + cbshowkongge + "课时数");
            for (int cb = 0; cb < Judge.LocalHours().Count; cb++)
            {
                if (Judge.LocalKemu()[cb] == " ") { Cbshowkemuhours.Add("　" + "　" + cbshowkongge + Judge.LocalHours()[cb]); continue; }
                if (Judge.LocalKemu()[cb].Length == 1) { Cbshowkemuhours.Add(Judge.LocalKemu()[cb] + "　" + cbshowkongge + Judge.LocalHours()[cb]); continue; }
                if (Judge.LocalKemu()[cb].Length > 2) { Cbshowkemuhours.Add(Judge.LocalKemu()[cb] + cbshowkongge.Remove(0, (Judge.LocalKemu()[cb].Length - 2)) + Judge.LocalHours()[cb]); continue; }
                Cbshowkemuhours.Add(Judge.LocalKemu()[cb] + cbshowkongge + Judge.LocalHours()[cb]);
            }
            Cbshowkemuhours.Add("总课时" + cbshowkongge.Remove(0, 1) + Judge.TotalHours());
            return Cbshowkemuhours;

        }


        public static List<string> LocalKemu()//用来返回本地存储的各个课目数
        {
            List<string> hoursstr = new List<string>();
            if (File.Exists(System.Windows.Forms.Application.StartupPath + "\\app.xml"))//判断所添加的总课时是否超过45
            {
                using (StreamReader sr = new StreamReader(System.Windows.Forms.Application.StartupPath + "\\app.xml", Encoding.UTF8))
                {
                    while (sr.EndOfStream == false)
                    {
                        string str = sr.ReadLine();
                        string str1 = str.Remove(12);
                        str1 = str1.Remove(0, 2);
                        str1 = str1.Remove(str1.IndexOf("*"));
                        hoursstr.Add(str1);
                    }
                }
            }
            return hoursstr;
        }
        public static List<string> LocalHours()//用来返回本地存储的各个课时数
        {
            List<string> hoursstr = new List<string>();
            if (File.Exists(System.Windows.Forms.Application.StartupPath + "\\app.xml"))//判断所添加的总课时是否超过45
            {
                using (StreamReader sr = new StreamReader(System.Windows.Forms.Application.StartupPath + "\\app.xml", Encoding.UTF8))
                {
                    while (sr.EndOfStream == false)
                    {
                        string str = sr.ReadLine();
                        string str1 = str.Remove(0, 13);
                        hoursstr.Add(str1);
                    }
                }
            }
            return hoursstr;
        }
        public static bool DateClassFileIsExist()//检查本地是否已经存在班级数据文件，如果存在则返回true,不存在则返回false
        {
            if (File.Exists(System.Windows.Forms.Application.StartupPath + "\\ClassOne.xml")) { return true; }
            if (File.Exists(System.Windows.Forms.Application.StartupPath + "\\ClassTwo.xml")) { return true; }
            if (File.Exists(System.Windows.Forms.Application.StartupPath + "\\ClassThree.xml")) { return true; }
            if (File.Exists(System.Windows.Forms.Application.StartupPath + "\\ClassFour.xml")) { return true; }
            if (File.Exists(System.Windows.Forms.Application.StartupPath + "\\ClassFive.xml")) { return true; }
            if (File.Exists(System.Windows.Forms.Application.StartupPath + "\\ClassSix.xml")) { return true; }
            return false;
        }
        public static List<int[]> DateClassReader(string classname)//输入本地存在的班级文件，将以数组集合返回当前班级课表
        {
            List<int[]> classlist = new List<int[]>();
            int[] j1 = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int[] j2 = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int[] j3 = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int[] j4 = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int[] j5 = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            using (StreamReader sr = new StreamReader(System.Windows.Forms.Application.StartupPath + "\\" + classname, Encoding.UTF8))
            {
                int a = 0, b = 0, c = 0, d = 0, e = 0;
                while (sr.EndOfStream == false)
                {
                    if (a < 9)
                    {
                        string sr1 = sr.ReadLine();
                        j1[a] = Convert.ToInt32(sr1);
                        a++;
                    }
                    if (a >= 9 && a < 18)
                    {
                        string sr1 = sr.ReadLine();
                        j2[b] = Convert.ToInt32(sr1);
                        a++;
                        b++;
                    }
                    if (a >= 18 && a < 27)
                    {
                        string sr1 = sr.ReadLine();
                        j3[c] = Convert.ToInt32(sr1);
                        a++;
                        c++;
                    }
                    if (a >= 27 && a < 36)
                    {
                        string sr1 = sr.ReadLine();
                        j4[d] = Convert.ToInt32(sr1);
                        a++;
                        d++;
                    }
                    if (a >= 36 && a < 45)
                    {
                        string sr1 = sr.ReadLine();
                        j5[e] = Convert.ToInt32(sr1);
                        a++;
                        e++;
                    }
                }
            }
            classlist.Add(j1);
            classlist.Add(j2);
            classlist.Add(j3);
            classlist.Add(j4);
            classlist.Add(j5);
            return classlist;
        }
        public static void DateClass(bool cct1, List<int[]> classlist, string classname)//用来生成相应班级的本地数据文件
        {
            if (cct1)
            {
                using (StreamWriter sw = new StreamWriter(System.Windows.Forms.Application.StartupPath + "\\" + classname, false, Encoding.UTF8))
                {
                    for (int cct2 = 0; cct2 < 5; cct2++)
                    {
                        for (int cct3 = 0; cct3 < 9; cct3++) { sw.WriteLine(classlist[cct2][cct3]); }
                    }
                }
            }
        }
        public static bool DateLastJudge(int i, int kemuRd, int kemu1, int kemu2, int kemu3, List<int> hourslist, List<int> kemuRandom, List<int> kemulist1, List<int> kemulist2, List<int> kemulist3)//用以判断
        {
            for (int ll = 0; ll < i; ll++)
            {
                if (hourslist[ll] != 0)
                {
                    for (int ll1 = 0; ll1 < kemulist1.Count; ll1++)
                    {
                        if (ll == kemulist1[ll1])
                        {
                            if (hourslist[ll] > kemu1)
                            {
                                return false;
                            }
                        }
                    }
                    for (int ll1 = 0; ll1 < kemulist2.Count; ll1++)
                    {
                        if (ll == kemulist2[ll1])
                        {
                            if (hourslist[ll] > kemu2)
                            {
                                return false;
                            }
                        }
                    }
                    for (int ll1 = 0; ll1 < kemulist3.Count; ll1++)
                    {
                        if (ll == kemulist3[ll1])
                        {
                            if (hourslist[ll] > kemu3)
                            {
                                return false;
                            }
                        }
                    }
                    for (int ll1 = 0; ll1 < kemuRandom.Count; ll1++)
                    {
                        if (ll == kemuRandom[ll1])
                        {
                            if (hourslist[ll] > kemuRd)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }
        public static List<int> DateReduceV(int i, List<int> hourslist)//传进hourslist，对hourslist中的值进行是否为零的判断，如果有为零则添加到集合v中，最后返回v
        {
            List<int> v = new List<int>();
            for (int b = 0; b < i; b++)
            {

                if (hourslist[b] <= 0)
                {
                    v.Add(b);
                }
            }
            return v;

        }
        public static List<int> DateReduce(int i, List<int> hourslist, int[] j1)//传进hourslist，对hourslist进行减法运算返回结果
        {
            for (int b = 0; b < 9; b++)
            {
                for (int b1 = 0; b1 < i; b1++)
                {
                    if (j1[b] == b1)
                    {
                        hourslist[b1]--;
                    }
                }
            }
            return hourslist;
        }
        //private static bool DataArrangeAffiliate(int[] j1, List<int> kemulist, int i, int x)//用于此类下DataArrange调用，为bool型
        //{
        //    Random rd = new Random();
        //    int b = 0;
        //    for (int k = 0; k < kemulist.Count; k++)
        //    {
        //        b = 0;
        //        for (int k1 = 0; k1 < 9; k1++)
        //        {
        //            if (j1[k1] == kemulist[k])
        //            {
        //                b++;
        //            }
        //            if (b > x)
        //            {
        //                return false;
        //            }
        //        }
        //    }
        //    return true;
        //}
        public static void DateRecord(bool CbSimily, string Cbcounttext, string TbKemutext, string TbHourstext, bool Tf)//用来生成本地数据存储文件，传入的参数分别为ComBox.Text,TextBox.Text,TextBox.Text,Tf用来判断是否覆盖原文件
        {
            int tbtx = TbKemutext.Length;
            using (StreamWriter sw = new StreamWriter(System.Windows.Forms.Application.StartupPath + "\\app.xml", Tf, Encoding.UTF8))
            {

                if (TbKemutext.Length < 10)
                {
                    for (int lt = 0; lt < 10 - tbtx; lt++)
                    {
                        TbKemutext = TbKemutext + "*";
                    }
                }
                switch (Cbcounttext)
                {
                    case "任意":
                        if (CbSimily) { sw.WriteLine("!1" + TbKemutext + "|" + TbHourstext); }
                        else { sw.WriteLine("!2" + TbKemutext + "|" + TbHourstext); }//当在ComBox中选择“任意”，则在语句前加上“！”
                        break;
                    case "1":
                        if (CbSimily) { sw.WriteLine("@1" + TbKemutext + "|" + TbHourstext); }
                        else { sw.WriteLine("@2" + TbKemutext + "|" + TbHourstext); }//当在ComBox中选择“1”，则在语句前加上“@”
                        break;
                    case "2":
                        if (CbSimily) { sw.WriteLine("#1" + TbKemutext + "|" + TbHourstext); }
                        else { sw.WriteLine("#2" + TbKemutext + "|" + TbHourstext); }//当在ComBox中选择“2”，则在语句前加上“#”
                        break;
                    case "3":
                        if (CbSimily) { sw.WriteLine("$1" + TbKemutext + "|" + TbHourstext); }
                        else { sw.WriteLine("$2" + TbKemutext + "|" + TbHourstext); }//当在ComBox中选择“3”，则在语句前加上“￥”
                        break;
                    default:
                        MessageBox.Show("发生未知错误！", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
                        break;
                }
            }
        }
        public static int TotalHours()//用来计算求和本地存储的总课时数
        {
            int zhours = 0;
            if (File.Exists(System.Windows.Forms.Application.StartupPath + "\\app.xml"))//判断所添加的总课时是否超过45
            {
                using (StreamReader sr = new StreamReader(System.Windows.Forms.Application.StartupPath + "\\app.xml", Encoding.UTF8))
                {
                    while (sr.EndOfStream == false)
                    {
                        string str = sr.ReadLine();
                        string str1 = str.Remove(0, 13);
                        int hours = Convert.ToInt32(str1);
                        zhours = hours + zhours;
                    }
                }
            }
            return zhours;
        }
        public static List<int> DateCount(int i, int[] j1)//用来返回参数j1中生成的0-9的分别个数
        {
            List<int> sumlist = new List<int>();
            //向sumlist中添加i个0，使其完成恰好数量的初始化
            for (int i0 = 0; i0 < i; i0++)
            {
                sumlist.Add(0);
            }
            for (int x = 0; x < i; x++)
            {
                for (int x1 = 0; x1 < 9; x1++)
                {
                    if (j1[x1] == x)
                    {
                        sumlist[x]++;
                    }
                }
            }
            return sumlist;
        }
        public static int[] DateArrange(int i)//用于返回一个包含没有重复4次及以上的九位整数数组
        {
            Random rd = new Random((int)DateTime.Now.Ticks & 0x0000FFFF);
            int[] j1 = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int a = 0;
        gt: for (int k = 0; k < i; k++)
            {
                a = 0;//此处用于将外层的循环的a重新赋值为0
                for (int k1 = 0; k1 < 9; k1++)
                {
                    if (j1[k1] == k)
                    {
                        a++;
                    }
                    if (a == 4 || a == 5 || a == 6 || a == 7 || a == 8 || a == 9)
                    {
                        for (int k2 = 0; k2 < 9; k2++)
                        {
                            j1[k2] = rd.Next(0, i);
                        }
                        a = 0;
                        goto gt;
                    }
                }
            }
            return j1;
        }
        public static int[] DateArrange(int i, List<int> kemuRandom, List<int> kemulist1, List<int> kemulist2, List<int> kemulist3, List<int> v, List<int> hourslist, List<int> zhourslist)//
        {
            Random rd = new Random((int)DateTime.Now.Ticks & 0x0000FFFF);
            //Random rd = new Random();
            //int[] j1 = new int[] { 0, 1, 2, 2, 2, 3, 4, 5, 6 };
            int[] j1 = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int a = 0, b = 0; ;
        gt: for (int k1 = 0; k1 < 9; k1++)//判断j1中是否存在课时数为零的科目，如果存在则从新生成一列j1
            {
                for (int k3 = 0; k3 < v.Count; k3++)
                {

                    if (j1[k1] == v[k3])
                    {
                        for (int k2 = 0; k2 < 9; k2++)
                        {
                            j1[k2] = rd.Next(0, i);
                        }
                        goto gt;
                    }
                }
            }
            for (int k = 0; k < i; k++)//判断新生成的一列中某科目数是否超过该科目目前总课时数
            {
                b = 0;
                for (int k1 = 0; k1 < 9; k1++)
                {
                    if (j1[k1] == k)
                    {
                        b++;
                    }
                }
                if (hourslist[k] - b < 0)
                {
                    for (int k2 = 0; k2 < 9; k2++)
                    {
                        j1[k2] = rd.Next(0, i);
                    }
                    goto gt;
                }
            }
            for (int k = 0; k < i; k++)//用于将对j1表中特定科目数量的限制，超出限制则重新生成j1
            {
                a = 0;
                for (int k1 = 0; k1 < 9; k1++)//计算出j1表中"K"的个数
                {
                    if (j1[k1] == k)
                    {
                        a++;
                    }
                }
                for (int L1 = 0; L1 < kemulist1.Count; L1++)//**********判断k是否属于kemulist1**********
                {
                    if (kemulist1[L1] == k)
                    {
                        if (zhourslist[k] == 5)
                        {
                            if (a == 0)
                            {
                                for (int k2 = 0; k2 < 9; k2++)
                                {
                                    j1[k2] = rd.Next(0, i);
                                }
                                goto gt;
                            }
                        }
                        if (a != 0 && a != 1)
                        {
                            for (int k2 = 0; k2 < 9; k2++)
                            {
                                j1[k2] = rd.Next(0, i);
                            }
                            goto gt;
                        }
                    }
                }
                for (int L1 = 0; L1 < kemulist2.Count; L1++)//**********判断k是否属于kemulist2**********
                {
                    if (kemulist2[L1] == k)
                    {
                        if (zhourslist[k] == 10)
                        {
                            if (a == 0)
                            {
                                for (int k2 = 0; k2 < 9; k2++)
                                {
                                    j1[k2] = rd.Next(0, i);
                                }
                                goto gt;
                            }
                        }
                        if (a != 0 && a != 2)
                        {
                            for (int k2 = 0; k2 < 9; k2++)
                            {
                                j1[k2] = rd.Next(0, i);
                            }
                            goto gt;
                        }
                    }
                }
                for (int L1 = 0; L1 < kemulist3.Count; L1++)//**********判断k是否属于kemulist3**********
                {
                    if (kemulist3[L1] == k)
                    {
                        if (zhourslist[k] == 15)
                        {
                            if (a == 0)
                            {
                                for (int k2 = 0; k2 < 9; k2++)
                                {
                                    j1[k2] = rd.Next(0, i);
                                }
                                goto gt;
                            }
                        }
                        if (a != 0 && a != 3)
                        {
                            for (int k2 = 0; k2 < 9; k2++)
                            {
                                j1[k2] = rd.Next(0, i);
                            }
                            goto gt;
                        }
                    }
                }
                for (int L1 = 0; L1 < kemuRandom.Count; L1++)//**********判断k是否属于kemuRandom**********
                {
                    if (kemuRandom[L1] == k)
                    {
                        if (a == 4 || a == 5 || a == 6 || a == 7 || a == 8 || a == 9)
                        {
                            for (int k2 = 0; k2 < 9; k2++)
                            {
                                j1[k2] = rd.Next(0, i);
                            }
                            goto gt;
                        }
                    }
                }

            }

            return j1;
        }
        public static int[] DateArrange(int i, List<int> kemulist1, List<int> kemulist2, List<int> kemulist3, List<int> v, List<int> hourslist)//为上面函数的重载，增加限定功能
        {
            Random rd = new Random();
            int[] j1 = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int a = 0, b = 0, c = 0, d = 0;
            int e = 0;
        gt: for (int k = 0; k < i; k++)
            {
                e = 0;
                for (int k1 = 0; k1 < 9; k1++)
                {
                    if (j1[k1] == k)
                    {
                        e++;
                    }
                }
                if (hourslist[k] - e < 0)
                {
                    for (int k2 = 0; k2 < 9; k2++)
                    {
                        j1[k2] = rd.Next(0, i);
                    }
                    goto gt;
                }
            }
            for (int k = 0; k < kemulist1.Count; k++)
            {
                b = 0;
                for (int k1 = 0; k1 < 9; k1++)
                {
                    if (j1[k1] == kemulist1[k])
                    {
                        b++;
                    }
                    if (b > 1)
                    {
                        for (int k2 = 0; k2 < 9; k2++)
                        {
                            j1[k2] = rd.Next(0, i);
                        }
                        goto gt;
                    }
                }
            }
            for (int k = 0; k < kemulist2.Count; k++)
            {
                c = 0;
                for (int k1 = 0; k1 < 9; k1++)
                {
                    if (j1[k1] == kemulist2[k])
                    {
                        c++;
                    }
                    if (c != 0 || c != 2)
                    {
                        for (int k2 = 0; k2 < 9; k2++)
                        {
                            j1[k2] = rd.Next(0, i);
                        }
                        goto gt;
                    }
                }
            }
            for (int k = 0; k < kemulist3.Count; k++)
            {
                d = 0;
                for (int k1 = 0; k1 < 9; k1++)
                {
                    if (j1[k1] == kemulist3[k])
                    {
                        d++;
                    }
                    if (d != 0 || d != 3)
                    {
                        for (int k2 = 0; k2 < 9; k2++)
                        {
                            j1[k2] = rd.Next(0, i);
                        }
                        goto gt;
                    }
                }
            }
            for (int k = 0; k < i; k++)
            {
                a = 0;//此处用于将外层的循环的a重新赋值为0
                for (int k1 = 0; k1 < 9; k1++)
                {
                    if (j1[k1] == k)
                    {
                        a++;
                    }
                    if (a == 4 || a == 5 || a == 6 || a == 7 || a == 8 || a == 9)
                    {
                        for (int k2 = 0; k2 < 9; k2++)
                        {
                            j1[k2] = rd.Next(0, i);
                        }
                        goto gt;
                    }
                    for (int k3 = 0; k3 < v.Count; k3++)
                    {

                        if (j1[k1] == v[k3])
                        {
                            for (int k2 = 0; k2 < 9; k2++)
                            {
                                j1[k2] = rd.Next(0, i);
                            }
                            goto gt;
                        }
                    }
                }
            }
            return j1;
        }
    }
}
