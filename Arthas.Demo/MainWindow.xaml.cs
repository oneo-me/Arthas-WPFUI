using Arthas.Controls.Metro;
using Arthas.Utility.Media;
using System;
using System.Reflection;
using System.Windows;
using System.Windows.Threading;

namespace Arthas.Demo
{
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            color1.ColorChange += delegate
            {
                // 不要通过XAML来绑定颜色，无法获取到通知
                BorderBrush = color1.CurrentColor.OpaqueSolidColorBrush;
            };

            ts.IsOpen = true;


            exit.Click += delegate { Close(); };

            treeView.SizeChanged += delegate { waterfallFlow.Refresh(); };

            rt1.Clear();

            rt1.AddLine("阅读模式");
            rt1.AddLine();
            rt1.AddLine("添加正常内容");
            rt1.AddLine("添加正常内容可点击", delegate { MessageBox.Show("你点击了我！"); });
            rt1.AddLine("添加自定义颜色内容", new RgbaColor(255, 0, 0, 255));
            rt1.AddLine("添加自定义颜色内容可点击", new RgbaColor(255, 0, 0, 255), delegate { MessageBox.Show("你点击了我！"); });

            rt3.Clear();

            rt3.AddLine("内容追加测试（不换行添加）");
            rt3.AddLine("http://www.baidu.com", "http://www.baidu.com");
            rt3.AddLine("中间的间距是Add(\"  \");方法添加的两个空格");
            rt3.AddLine();

            rt3.AddLine("追加正常内容");
            rt3.AddLine();
            rt3.Add("正常1");
            rt3.Add("   ");
            rt3.Add("正常2");
            rt3.Add("   ");
            rt3.Add("正常3");
            rt3.AddLine();

            rt3.AddLine("追加正常内容可点击");
            rt3.AddLine();
            rt3.Add("正常1", delegate { MessageBox.Show("你点击了我！"); });
            rt3.Add("   ");
            rt3.Add("正常2", delegate { MessageBox.Show("你点击了我！"); });
            rt3.Add("   ");
            rt3.Add("正常3", delegate { MessageBox.Show("你点击了我！"); });
            rt3.AddLine();

            rt3.AddLine("追加自定义颜色内容");
            rt3.AddLine();
            rt3.Add("颜色1", new RgbaColor(255, 0, 0, 255));
            rt3.Add("   ");
            rt3.Add("颜色2", new RgbaColor(0, 255, 0, 255));
            rt3.Add("   ");
            rt3.Add("颜色3", new RgbaColor(0, 0, 255, 255));
            rt3.AddLine();

            rt3.AddLine("追加自定义颜色内容可点击");
            rt3.AddLine();
            rt3.Add("颜色1", new RgbaColor(255, 0, 0, 255), delegate { MessageBox.Show("你点击了我！"); });
            rt3.Add("   ");
            rt3.Add("颜色2", new RgbaColor(0, 255, 0, 255), delegate { MessageBox.Show("你点击了我！"); });
            rt3.Add("   ");
            rt3.Add("颜色3", new RgbaColor(0, 0, 255, 255), delegate { MessageBox.Show("你点击了我！"); });
            rt3.AddLine();



            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += delegate
            {
                pb1.Value = pb1.Value + 1 > pb1.Maximum ? 0 : pb1.Value + 1;
                pb2.Value = pb2.Value + 1 > pb2.Maximum ? 0 : pb2.Value + 1;
                pb2.Title = pb2.Hint;
                pb2.Hint = null;
            };
            timer.Interval = new TimeSpan(0, 0, 0, 0, 20);
            timer.Start();

            ContentRendered += delegate
            {
                // 手动加载指定HTML
                web1.Document = ResObj.GetString(Assembly.GetExecutingAssembly(), "Resources.about.html");

                // 导航到指定网页
                web2.Source = new Uri("http://ie.icoa.cn/");
            };


            foreach (FrameworkElement fe in lists.Children)
            {
                if (fe is MetroExpander)
                {
                    (fe as MetroExpander).Click += delegate (object sender, EventArgs e)
                    {
                        if ((fe as MetroExpander).CanHide)
                        {
                            foreach (FrameworkElement fe1 in lists.Children)
                            {
                                if (fe1 is MetroExpander && fe1 != sender)
                                {
                                    (fe1 as MetroExpander).IsExpanded = false;
                                }
                            }
                        }
                    };
                }
            }

            /*
            // Chrome 浏览器封装
            ChromeBrowser chrome = new ChromeBrowser();
            chromeGrid.Children.Add(chrome);
            chromeText.Text = chrome.Address;
            chromeText.ButtonClick += delegate { chrome.Load(chromeText.Text); };
            chromeText.KeyUp += delegate (object sender, KeyEventArgs e) { if (e.Key == Key.Enter) { chrome.Load(chromeText.Text); } };
            chrome.Load("http://ie.icoa.cn/");
            */
        }
    }
}