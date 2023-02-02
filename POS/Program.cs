using Microsoft.Win32;  //14/07/2022
using System;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Windows.Forms;

namespace POS
{
    static class Program
    {
        public static string customConnectionString;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>        
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string Server = @"HKEY_CURRENT_USER\SOFTWARE\OmniPOS";
            object ValorIP = Registry.GetValue(Server, "IP", null);
            object SBase = Registry.GetValue(Server, "Base", null);
            object SPass = Registry.GetValue(Server, "Pass", null);

            //12/07/2022  Se agregó para que Cadena de conexion sea parametrizable
            EntityConnectionStringBuilder constructorConexion = new EntityConnectionStringBuilder
            {
                Provider = "System.Data.SqlClient",
                ProviderConnectionString = "data source=" + ValorIP + ";initial catalog=" + SBase + ";persist security info=True;user id=sa;password=" + SPass + ";MultipleActiveResultSets=True;App=EntityFramework",
                Metadata = "res://*/ModelPOS.csdl|res://*/ModelPOS.ssdl|res://*/ModelPOS.msl"
            };
            customConnectionString = constructorConexion.ToString();
            //12/07/2022

            //cadena = ConfigurationManager.ConnectionStrings["POSEntities"].ConnectionString;
            //Debug.WriteLine(cadena);


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
