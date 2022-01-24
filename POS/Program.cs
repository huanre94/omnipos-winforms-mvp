using System;
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

            //SplashScreen
            //FluentSplashScreenOptions op = new FluentSplashScreenOptions
            //{
            //    Title = "OmniPOS",
            //    //Title = "Solución Tecnológica para Retail",
            //    Subtitle = "Desarrollado por: Departamento de Tecnología de la Información",

            //    RightFooter = "Iniciando...",
            //    LeftFooter = "Copyright © " + DateTime.Now.Year.ToString() + " Grupo La Española." + Environment.NewLine + "Todos los derechos reservados.",
            //    LoadingIndicatorType = FluentLoadingIndicatorType.Dots,
            //    OpacityColor = Color.FromArgb(88, 84, 105),
            //    Opacity = 200,
            //    LogoImageOptions = {
            //        SvgImage = Properties.Resources.retail,
            //        SvgImageSize = new Size(90, 90)
            //    }
            //};

            //SplashScreenManager.ShowFluentSplashScreen(
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
