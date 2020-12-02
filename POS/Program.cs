using DevExpress.XtraSplashScreen;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace POS
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //FluentSplashScreenOptions op = new FluentSplashScreenOptions();
            //op.Title = "Solución Tecnológica para Retail";
            //op.Subtitle = "Desarrollado por el Departamento de Tecnología";
            //op.RightFooter = "Iniciando...";
            //op.LeftFooter = "Copyright © " + DateTime.Now.Year.ToString() + " Grupo La Española." + Environment.NewLine + "Todos los derechos reservados.";
            //op.LoadingIndicatorType = FluentLoadingIndicatorType.Dots;
            //op.OpacityColor = Color.FromArgb(248, 248, 248);
            //op.Opacity = 130;
            //op.LogoImageOptions.SvgImage = Properties.Resources.accept;

            //DevExpress.XtraSplashScreen.SplashScreenManager.ShowFluentSplashScreen(
            //    op,
            //    //parentForm: Program,
            //    useFadeIn: true,
            //    useFadeOut: true
            //);

            //System.Threading.Thread.Sleep(5000);
            //SplashScreenManager.CloseForm();

            Application.Run(new FrmLogin());
        }
    }
}
