using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace IconDeskTop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        private bool _contentLoaded1;

        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.5.0")]
        public void InitializeComponent1()
        {
            if (_contentLoaded1)
            {
                return;
            }
            _contentLoaded1 = true;

            this.StartupUri = new System.Uri("MainWindow.xaml", System.UriKind.Relative);
            //this.StartupUri = new System.Uri("Views/HomeIcons.xaml", System.UriKind.Relative);

            System.Uri resourceLocater = new System.Uri("/IconDeskTop;component/app.xaml", System.UriKind.Relative);

            System.Windows.Application.LoadComponent(this, resourceLocater);
        }


        /// <summary>
        /// Application Entry Point.
        /// </summary>
        [System.STAThreadAttribute()]
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.5.0")]
        public static void Main()
        {
            IconDeskTop.App app = new IconDeskTop.App();
            app.InitializeComponent1();
            app.Run();
        }
    }
}
