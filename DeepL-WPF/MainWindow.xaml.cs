using Microsoft.Web.WebView2.Core;
using System.Windows;
using System.Windows.Input;
using Wpf.Ui.Controls;

namespace DeepL_WPF
{
    public partial class MainWindow : FluentWindow
    {
        private NotifyIcon trayIcon;
        public MainWindow()
        {
            InitializeComponent();
            InitializeTrayIcon();
            InitializeWebView();
        }
        private async void InitializeWebView()
        {
            webView = new Microsoft.Web.WebView2.Wpf.WebView2();
            await webView.EnsureCoreWebView2Async(null);
            webView.CoreWebView2.Settings.AreDevToolsEnabled = false;
            webView.PreviewKeyDown += (sender, e) =>
            {
                if (e.Key == Key.F12)
                {
                    e.Handled = true;
                }
            };
            webView.Source = new Uri("https://www.deepl.com/translator");
            webView.CoreWebView2.ContextMenuRequested += CoreWebView2_ContextMenuRequested;
        }

        private void UiWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            CloseWindow(e);
        }

        private void CloseWindow(System.ComponentModel.CancelEventArgs? e = null, bool exit = false)
        {
            if (exit)
            {
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
                webView.Dispose();
                Hide();
                WindowState = WindowState.Minimized;
            }
        }
        private void CoreWebView2_ContextMenuRequested(object sender, CoreWebView2ContextMenuRequestedEventArgs e)
        {
            var deferral = e.GetDeferral();
            foreach (var item in e.MenuItems)
            {
                if (item.Name == "DevTools")
                {
                    e.MenuItems.Remove(item);
                    break;
                }
            }
            deferral.Complete();
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

        }


        private void InitializeTrayIcon()
        {
            trayIcon = new NotifyIcon();
            trayIcon.Icon = Properties.Resources.DeepL;
            trayIcon.Text = "DeepL";
            trayIcon.Visible = true;

            ContextMenuStrip menu = new ContextMenuStrip();
            ToolStripMenuItem showMenuItem = new ToolStripMenuItem("Показать");
            ToolStripMenuItem hiddenMenuItem = new ToolStripMenuItem("Свернуть");
            ToolStripMenuItem exitMenuItem = new ToolStripMenuItem("Выход");

            showMenuItem.Click += ShowMenuItem_Click;
            hiddenMenuItem.Click += HiddenMenuItem_Click;
            exitMenuItem.Click += ExitMenuItem_Click;

            menu.Items.Add(showMenuItem);
            menu.Items.Add(hiddenMenuItem);
            menu.Items.Add(exitMenuItem);

            trayIcon.ContextMenuStrip = menu;
            trayIcon.DoubleClick += new EventHandler(ShowMenuItem_Click);
        }

        private void ShowMenuItem_Click(object sender, EventArgs e)
        {

            WindowState = WindowState.Normal;
            Activate();
            Show();
        }
        private void HiddenMenuItem_Click(object sender, EventArgs e)
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