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
            //op.Subtitle = "Desarrollado por: Departamento de Tecnología de la Información";
            //op.RightFooter = "Iniciando...";
            //op.LeftFooter = "Copyright © " + DateTime.Now.Year.ToString() + " Grupo La Española." + Environment.NewLine + "Todos los derechos reservados.";
            //op.LoadingIndicatorType = FluentLoadingIndicatorType.Dots;
            //op.OpacityColor = Color.FromArgb(88, 84, 105);
            //op.Opacity = 200;
            //op.LogoImageOptions.SvgImage = Properties.Resources.retail;
            //op.LogoImageOptions.SvgImageSize = new Size(90, 90);

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
