using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WpfApplication1
{
    class Trach
    {

        //if(Judge.DateClassFileIsExist())
        //    {
        //        MessageBoxResult mbr = MessageBox.Show("检测到本地已经存在课表数据，点击确定将覆盖", "提示！", MessageBoxButton.OKCancel, MessageBoxImage.Information);
        //        if (mbr == MessageBoxResult.OK)
        //        {
        //            File.Delete(System.Windows.Forms.Application.StartupPath + "\\ClassOne.xml");
        //            File.Delete(System.Windows.Forms.Application.StartupPath + "\\ClassTwo.xml");
        //            File.Delete(System.Windows.Forms.Application.StartupPath + "\\ClassThree.xml");
        //            File.Delete(System.Windows.Forms.Application.StartupPath + "\\ClassFour.xml");
        //            File.Delete(System.Windows.Forms.Application.StartupPath + "\\ClassFive.xml");
        //            File.Delete(System.Windows.Forms.Application.StartupPath + "\\ClassSix.xml");
        //        }
        //        if (mbr == MessageBoxResult.Cancel) { return; }
        //    }

        //LbPb.Dispatcher.Invoke(new Action<System.Windows.DependencyProperty, object>(LbPb.SetValue), System.Windows.Threading.DispatcherPriority.Background, ProgressBar.ValueProperty, value);
        //value++;

        //if (cct == 0) { classlist1.Add(j1); classlist1.Add(j2); classlist1.Add(j3); classlist1.Add(j4); classlist1.Add(j5); continue; }
        //if (cct == 1) { classlist2.Add(j1); classlist2.Add(j2); classlist2.Add(j3); classlist2.Add(j4); classlist2.Add(j5); continue; }
        //if (cct == 2) { classlist3.Add(j1); classlist3.Add(j2); classlist3.Add(j3); classlist3.Add(j4); classlist3.Add(j5); continue; }
        //if (cct == 3) { classlist4.Add(j1); classlist4.Add(j2); classlist4.Add(j3); classlist4.Add(j4); classlist4.Add(j5); continue; }
        //if (cct == 4) { classlist5.Add(j1); classlist5.Add(j2); classlist5.Add(j3); classlist5.Add(j4); classlist5.Add(j5); continue; }
        //if (cct == 5) { classlist6.Add(j1); classlist6.Add(j2); classlist6.Add(j3); classlist6.Add(j4); classlist6.Add(j5); continue; }


         //int i = 0, ai = 0;
         //   using (StreamReader srd = new StreamReader(System.Windows.Forms.Application.StartupPath + "\\app.xml", Encoding.UTF8))
         //   {

         //       while (srd.EndOfStream == false)
         //       {
         //           string str = srd.ReadLine();
         //           string strzifu = str.Remove(1);
         //           switch (strzifu)
         //           {
         //               case "!":
         //                   kemuRandomlist.Add(ai);
         //                   break;
         //               case "@":
         //                   kemulist1.Add(ai);
         //                   break;
         //               case "#":
         //                   kemulist2.Add(ai);
         //                   break;
         //               case "$":
         //                   kemulist3.Add(ai);
         //                   break;
         //               default:
         //                   MessageBox.Show("数据分类出错！", "提示", MessageBoxButton.OK, MessageBoxImage.Error);
         //                   break;
                            
         //           }
         //           ai++;
         //           string str1 = str.Remove(11);
         //           str1 = str1.Remove(0, 1);
         //           str1 = str1.Remove(str1.IndexOf("*", 0));
         //           string str2 = str.Remove(0, 12);
         //           hourslist.Add(Convert.ToInt32(str2));
         //           kemulist.Add(str1);
         //           i++;
         //       }
         //   }


        // int it = -1;
        ////在诸多限制下生成j1,j2,j3,j4,j5
        //gt: for (int z = 0; z < zhourslist.Count; z++)
        //    {
        //        hourslist[z] = zhourslist[z];
        //    }
        //it++;
        //if (it > 500) { MessageBox.Show("您之前输入的数据无法生成一个符合要求的课表！请检查您输入的科目及相应的课时", "错误提示", MessageBoxButton.OK, MessageBoxImage.Error); this.Close(); return; }
        //    if (!Judge.DateLastJudge(i,15, 5, 10, 15, hourslist,kemuRandomlist, kemulist1, kemulist2, kemulist3)) { MessageBox.Show("数据出现致命错误！建议到设置中点击清空按钮并重新输入数据！", "失败", MessageBoxButton.OK, MessageBoxImage.Error); }
        //    j1 = Judge.DateArrange(i, kemuRandomlist, kemulist1, kemulist2, kemulist3, Judge.DateReduceV(i, hourslist), hourslist, zhourslist);//给j1生成一个没有重复四位以上的九位数
        //    hourslist = Judge.DateReduce(i, hourslist, j1);//重新配置hourslist，将在j1中已经出现过的科目减去相应课时
        //    Thread.Sleep(20);

        //    if (!Judge.DateLastJudge(i,12, 4, 8, 12, hourslist,kemuRandomlist, kemulist1, kemulist2, kemulist3)) { goto gt; }
        //    j2 = Judge.DateArrange(i, kemuRandomlist, kemulist1, kemulist2, kemulist3, Judge.DateReduceV(i, hourslist), hourslist, zhourslist);//将新的hourslist传入DateReduceV方法中，将返回的值再传入DateArrage中，得到在j1基础上的j2
        //    hourslist = Judge.DateReduce(i, hourslist, j2);
        //    Thread.Sleep(20);

        //    if (!Judge.DateLastJudge(i,9, 3, 6, 9, hourslist,kemuRandomlist, kemulist1, kemulist2, kemulist3)) { goto gt; }
        //    j3 = Judge.DateArrange(i, kemuRandomlist, kemulist1, kemulist2, kemulist3, Judge.DateReduceV(i, hourslist), hourslist, zhourslist);
        //    hourslist = Judge.DateReduce(i, hourslist, j3);
        //    Thread.Sleep(20);

        //    if (!Judge.DateLastJudge(i,6, 2, 4, 6, hourslist,kemuRandomlist, kemulist1, kemulist2, kemulist3)) { goto gt; }
        //    j4 = Judge.DateArrange(i, kemuRandomlist, kemulist1, kemulist2, kemulist3, Judge.DateReduceV(i, hourslist), hourslist, zhourslist);
        //    hourslist = Judge.DateReduce(i, hourslist, j4);
        //    Thread.Sleep(20);

        //    if (!Judge.DateLastJudge(i,3, 1, 2, 3, hourslist,kemuRandomlist, kemulist1, kemulist2, kemulist3)) { goto gt; }
        //    j5 = Judge.DateArrange(i, kemuRandomlist, kemulist1, kemulist2, kemulist3, Judge.DateReduceV(i, hourslist), hourslist, zhourslist);
        //    hourslist = Judge.DateReduce(i, hourslist, j5);

        //    //用来判断生成表的总课时数是否与客户自己添加的总课时数相等
        //    List<int> j1list = Judge.DateCount(i, j1);
        //    List<int> j2list = Judge.DateCount(i, j2);
        //    List<int> j3list = Judge.DateCount(i, j3);
        //    List<int> j4list = Judge.DateCount(i, j4);
        //    List<int> j5list = Judge.DateCount(i, j5);
        //    for (int p = 0; p < i; p++)
        //    {
        //        if (j1list[p] + j2list[p] + j3list[p] + j4list[p] + j5list[p] != zhourslist[p])
        //        {
        //            MessageBox.Show(kemulist[p] + "课时数错误！", "提示", MessageBoxButton.OK, MessageBoxImage.Error);
        //        }
        //    }
        //    MessageBox.Show("课时数校对正确！循环了"+it+"次", "提示", MessageBoxButton.OK, MessageBoxImage.Asterisk);



         ////用来判断生成表的总课时数是否与客户自己添加的总课时数相等
         //       List<int> j1list = Judge.DateCount(i, j1);
         //       List<int> j2list = Judge.DateCount(i, j2);
         //       List<int> j3list = Judge.DateCount(i, j3);
         //       List<int> j4list = Judge.DateCount(i, j4);
         //       List<int> j5list = Judge.DateCount(i, j5);
         //       for (int p = 0; p < i; p++)
         //       {
         //           if (j1list[p] + j2list[p] + j3list[p] + j4list[p] + j5list[p] != zhourslist[p])
         //           {
         //               MessageBox.Show(kemulist[p] + "课时数错误！", "提示", MessageBoxButton.OK, MessageBoxImage.Error); return;
         //           }
         //       }


        //for (int p = 0; p < i; p++)
        //{
        //    if (j1list[p] + j2list[p] + j3list[p] + j4list[p] + j5list[p] != zhourslist[p])
        //    {
        //        j1 = Judge.DateArrange(i);//给j1生成一个没有重复四位以上的九位数
        //        hourslist = Judge.DateReduce(i, hourslist, j1);//重新配置hourslist，将在j1中已经出现过的科目减去相应课时


        //        j2 = Judge.DateArrange(i, Judge.DateReduceV(i, hourslist), hourslist);//将新的hourslist传入DateReduceV方法中，将返回的值再传入DateArrage中，得到在j1基础上的j2
        //        hourslist = Judge.DateReduce(i, hourslist, j2);


        //        j3 = Judge.DateArrange(i, Judge.DateReduceV(i, hourslist), hourslist);
        //        hourslist = Judge.DateReduce(i, hourslist, j3);


        //        j4 = Judge.DateArrange(i, Judge.DateReduceV(i, hourslist), hourslist);
        //        hourslist = Judge.DateReduce(i, hourslist, j4);


        //        j5 = Judge.DateArrange(i, Judge.DateReduceV(i, hourslist), hourslist);
        //        hourslist = Judge.DateReduce(i, hourslist, j5);

        //        //此处为什么调用方法会生成相同的数组？
        //        //j1 = Judge.DateArrange(i, kemuRandomlist, kemulist1, kemulist2, kemulist3);
        //        //j2 = Judge.DateArrange(i, kemuRandomlist, kemulist1, kemulist2, kemulist3);
        //        //j3 = Judge.DateArrange(i, kemuRandomlist, kemulist1, kemulist2, kemulist3);
        //        //j4 = Judge.DateArrange(i, kemuRandomlist, kemulist1, kemulist2, kemulist3);
        //        //j5 = Judge.DateArrange(i, kemuRandomlist, kemulist1, kemulist2, kemulist3);
        //        //j1 = Judge.DateArrange(i,hourslist);
        //        //hourslist = Judge.Datejianyi(i, hourslist, j1);
        //        //j2 = Judge.DateArrange(i, hourslist);
        //        //hourslist = Judge.Datejianyi(i, hourslist, j2);

        //        //j3 = Judge.DateArrange(i, hourslist);
        //        //hourslist = Judge.Datejianyi(i, hourslist, j3);

        //        //j4 = Judge.DateArrange(i, hourslist);
        //        //hourslist = Judge.Datejianyi(i, hourslist, j4);

        //        //j5 = Judge.DateArrange(i, hourslist);
        //        //hourslist = Judge.Datejianyi(i, hourslist, j5);
        //        ////解决生成相同数组的方法
        //        //while (j1[0] == j2[0] && j1[1] == j2[1] && j1[2] == j2[2] && j1[3] == j2[3] && j1[4] == j2[4])
        //        //{
        //        //    j1 = Judge.DateArrange(i);
        //        //    j2 = Judge.DateArrange(i);
        //        //}
        //        //while ((j2[0] == j3[0] && j2[1] == j3[1] && j2[2] == j3[2] && j2[3] == j3[3] && j2[4] == j3[4]) || (j1[0] == j3[0] && j1[1] == j3[1] && j1[2] == j3[2] && j1[3] == j3[3] && j1[4] == j3[4]))
        //        //{
        //        //    j3 = Judge.DateArrange(i);
        //        //}
        //        //while ((j2[0] == j4[0] && j2[1] == j4[1] && j2[2] == j4[2] && j2[3] == j4[3] && j2[4] == j4[4]) || (j1[0] == j4[0] && j1[1] == j4[1] && j1[2] == j4[2] && j1[3] == j4[3] && j1[4] == j4[4]) || (j4[0] == j3[0] && j4[1] == j3[1] && j4[2] == j3[2] && j4[3] == j3[3] && j4[4] == j3[4]))
        //        //{
        //        //    j4 = Judge.DateArrange(i);
        //        //}
        //        //while ((j2[0] == j5[0] && j2[1] == j5[1] && j2[2] == j5[2] && j2[3] == j5[3] && j2[4] == j5[4]) || (j1[0] == j5[0] && j1[1] == j5[1] && j1[2] == j5[2] && j1[3] == j5[3] && j1[4] == j5[4]) || (j4[0] == j5[0] && j4[1] == j5[1] && j4[2] == j5[2] && j4[3] == j5[3] && j4[4] == j5[4]) || (j5[0] == j3[0] && j5[1] == j3[1] && j5[2] == j3[2] && j5[3] == j3[3] && j5[4] == j3[4]))
        //        //{
        //        //    j5 = Judge.DateArrange(i);
        //        //}
        //        j1list = Judge.DateCount(i, j1);
        //        j2list = Judge.DateCount(i, j2);
        //        j3list = Judge.DateCount(i, j3);
        //        j4list = Judge.DateCount(i, j4);
        //        j5list = Judge.DateCount(i, j5);
        //        p = -1;
        //    }
        //}

        //int[] jx1 = new int[] { 0, 1, 1, 2, 3, 3, 3, 4, 4 };
        //int[] jx2 = new int[] { 0, 1, 1, 2, 3, 3, 3, 4, 4 };
        //int[] jx3 = new int[] { 0, 1, 1, 2, 3, 3, 3, 4, 4 };
        //int[] jx4 = new int[] { 0, 1, 1, 2, 3, 3, 3, 4, 4 };
        //int[] jx5 = new int[] { 0, 1, 1, 2, 3, 3, 3, 4, 4 };
        //for (int hj = 0; hj < i; hj++)
        //{
        //    MessageBox.Show("1、" + hourslist[hj]);
        //}
    }
}

