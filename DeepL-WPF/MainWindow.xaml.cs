using Hardcodet.Wpf.TaskbarNotification;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Wpf.Ui.Controls;
using MenuItem = Wpf.Ui.Controls.MenuItem;

namespace DeepL_WPF
{
    public partial class MainWindow : FluentWindow
    {
        private TaskbarIcon trayIcon;
        public MainWindow()
        {
            InitializeComponent();
            InitializeTrayIcon();
        }
        private void UiWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            CloseWindow(e);
        }
        private void CloseWindow(System.ComponentModel.CancelEventArgs? e = null, bool exit = false)
        {
            if (exit)
            {
                GC.Collect();
                Environment.Exit(0);
            }
            else
            {
                try
                {
                    e.Cancel = true;
                }
                catch
                {

                }
                Hide();
                WindowState = WindowState.Minimized;
            }
        }

        private void WindowMouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (e.ChangedButton == MouseButton.Left)
                {
                    this.DragMove();
                }
            }
            catch { }
        }
        private void killthisapp(object sender, RoutedEventArgs e)
        {
            CloseWindow(exit: true);
        }
        private void WinStateChanged(object sender, EventArgs e)
        {
            if (WindowState == WindowState.Minimized)
            {
                // тут отключить обновление интерфейса
            }
            else
            {

            }
        }

        private void InitializeTrayIcon()
        {
            trayIcon = new TaskbarIcon();
            trayIcon.Icon = Properties.Resources.DeepL;
            trayIcon.ToolTipText = "DeepL";
            ContextMenu menu = new ContextMenu();
            MenuItem showMenuItem = new MenuItem { Header = "Показать" };
            MenuItem HiddenMenuItem = new MenuItem { Header = "Свернуть" };
            MenuItem exitMenuItem = new MenuItem { Header = "Выход" };
            showMenuItem.Click += ShowMenuItem_Click;
            exitMenuItem.Click += ExitMenuItem_Click;
            HiddenMenuItem.Click += HiddenMenuItem_Click;
            menu.Items.Add(showMenuItem);
            menu.Items.Add(HiddenMenuItem);
            menu.Items.Add(exitMenuItem);
            trayIcon.ContextMenu = menu;
            trayIcon.TrayMouseDoubleClick += ShowMenuItem_Click;
        }

        private void ShowMenuItem_Click(object sender, EventArgs e)
        {

            WindowState = WindowState.Normal;
            Activate();
            Show();
        }
        private void HiddenMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            WindowState = WindowState.Minimized;
        }
        private void ExitMenuItem_Click(object sender, EventArgs e)
        {
            CloseWindow(exit: true);
        }

        private void maintitlebar_MinimizeClicked(TitleBar sender, RoutedEventArgs args)
        {
            Hide();
            WindowState = WindowState.Minimized;
        }

        private void maintitlebar_CloseClicked(TitleBar sender, RoutedEventArgs args)
        {
            if (Keyboard.IsKeyDown(Key.LeftShift))
            {
                CloseWindow(exit: true);
            }
            else
            {
                CloseWindow(exit: false);
            }
        }
    }
}