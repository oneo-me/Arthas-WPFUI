using Arthas.Themes;
using Arthas.Utility.Computer;
using Arthas.Utility.Element;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System;
using System.Threading;
#if DEBUG
using System.Diagnostics;
#endif

namespace Arthas.Controls.Metro
{
    public class MetroWindow : Window
    {

        public static readonly DependencyProperty IsSubWindowShowProperty = ElementBase.Property<MetroWindow, bool>(nameof(IsSubWindowShowProperty), false);
        public static readonly DependencyProperty MenuProperty = ElementBase.Property<MetroWindow, object>(nameof(MenuProperty), null);
        public static readonly new DependencyProperty BorderBrushProperty = ElementBase.Property<MetroWindow, Brush>(nameof(BorderBrushProperty));
        public static readonly DependencyProperty TitleForegroundProperty = ElementBase.Property<MetroWindow, Brush>(nameof(TitleForegroundProperty));

        public bool IsSubWindowShow { get { return (bool)GetValue(IsSubWindowShowProperty); } set { SetValue(IsSubWindowShowProperty, value); GoToState(); } }
        public object Menu { get { return GetValue(MenuProperty); } set { SetValue(MenuProperty, value); } }
        public new Brush BorderBrush { get { return (Brush)GetValue(BorderBrushProperty); } set { SetValue(BorderBrushProperty, value); BorderBrushChange(value); } }
        public Brush TitleForeground { get { return (Brush)GetValue(TitleForegroundProperty); } set { SetValue(TitleForegroundProperty, value); } }

        void BorderBrushChange(Brush brush)
        {
            if (IsLoaded)
            {
                Theme.Switch(this);
            }
        }

        void GoToState()
        {
            ElementBase.GoToState(this, IsSubWindowShow ? "Enabled" : "Disable");
        }


        public object ReturnValue { get; set; } = null;
        public bool EscClose { get; set; } = false;

        public MetroWindow()
        {
            Initialized += delegate
            {
                WindowStyle = WindowStyle.SingleBorderWindow;
            };

            Loaded += delegate
            {
                GoToState();

                switch (SizeToContent)
                {
                    case SizeToContent.WidthAndHeight:
                    case SizeToContent.Height:
                    case SizeToContent.Width:
                        SizeToContent = SizeToContent.Manual;
                        Width = ActualWidth - 16;
                        Height = ActualHeight - 32 - 7 + 3;

                        /*
                            // 解决何必DLL到EXE中之后残留的Bug
                            if (!File.Exists(Path.StartPath + @"\Arthas.dll"))
                            {
                                // Height = Height + 10;
                                // Width = Width + 10; // 可能某些情况下不需要，但是无法获取到这些情况，所以全部加10像素，一般来说不会有问题
                            }
                        */
                        break;
                    default:
                        Height = ActualHeight + 32;
                        break;
                }

                MinWidth = MinWidth == 0.0 ? Width : MinWidth;
                MinHeight = MinHeight == 0.0 ? Height : MinHeight;
                if (ResizeMode == ResizeMode.CanMinimize || ResizeMode == ResizeMode.NoResize)
                {
                    MaxWidth = Width;
                    MaxHeight = Height;
                }
                Left = (Screen.ScreenWidthLogic - Width) / 2;
                Top = (Screen.ScreenHeightLogic - Height) / 3;
            };
            KeyUp += delegate (object sender, KeyEventArgs e)
            {
                if (e.Key == Key.Escape && EscClose)
                {
                    Close();
                }
            };

            Closing += delegate
            {
                if (BackgroundThread != null)
                {
                    BackgroundThread.Abort();
                }
            };
            StateChanged += delegate
              {
                  if (ResizeMode == ResizeMode.CanMinimize || ResizeMode == ResizeMode.NoResize)
                  {
                      if (WindowState == WindowState.Maximized)
                      {
                          WindowState = WindowState.Normal;
                      }
                  }
              };
#if DEBUG
            ContentRendered += delegate
            {
                if (Debugger.IsAttached)
                {
                    Title += "　编译器调试模式";
                }
                else
                {
                    Title += "　调试模式";
                }
                Debug.WriteLine("当前处于调试版本，请勿发布！！！");
            };
#endif
            Utility.Refresh(this);
        }

        static MetroWindow()
        {
            ElementBase.DefaultStyle<MetroWindow>(DefaultStyleKeyProperty);
        }

        // 以下给窗口附加一个后台线程

        public Thread BackgroundThread { get; set; }

        /// <summary>
        /// 后台运行
        /// </summary>
        /// <param name="action">动作</param>
        /// <param name="newThread">是否新开线程</param>
        /// <returns></returns>
        public Thread BackgroundRun(Action action, bool newThread = false)
        {
            if (newThread)
            {
                Thread t = new Thread(() => { action(); });
                t.Start();
                return t;
            }
            else
            {
                if (BackgroundThread != null)
                {
                    BackgroundThread.Abort();
                }
                BackgroundThread = new Thread(() => { action(); });
                BackgroundThread.Start();
                return BackgroundThread;
            }
        }

        /// <summary>
        /// 在指定线程运行动作
        /// </summary>
        /// <param name="thread"></param>
        /// <param name="action"></param>
        public void BackgroundRun(Thread thread, Action action)
        {
            if (thread != null)
            {
                thread.Abort();
            }
            thread = new Thread(() => { action(); });
            thread.Start();
        }

        public void Sleep(int millisecondsTimeout = 1)
        {
            Thread.Sleep(millisecondsTimeout);
        }
        public void Invoke(Action action)
        {
            Dispatcher.Invoke(action);
        }
    }
}