namespace POS.Classes
{
    public class ClsEnums
    {
        public enum MessageType
        {
            INFO,
            WARNING,
            ERROR,
            CONFIRM
        }

        public enum PaymModeEnum
        {
            BONO = 1,
            CHEQUE_DIA = 2,
            CHEQUE_POST = 3,
            CREDITO = 4,
            DEBITO_BANCARIO = 5,
            DEPOSITO_BANCARIO = 6,
            DINERO_ELECTRONICO = 7,
            EFECTIVO = 8,
            NOTA_CREDITO = 9,
            ANTICIPOS = 10,
            PAGOS_WEB = 11,
            RETENCION = 12,
            TARJETA_CREDITO = 13,
            TARJETA_CONSUMO = 14
        }

        public enum InputFromOption
        {
            CHECK_ACCOUNTNUMBER,
            CHECK_AUTHORIZATION,
            CHECK_NUMBER,
            CHECK_OWNERNAME,
            CHECK_OWNERIDENTIFICATION,
            CHECK_PHONE,
            CREDITCARD_AUTHORIZATION,
            GIFTCARD_NUMBER,
            CUSTOMER_IDENTIFICATION,
            CUSTOMER_FIRSTNAME,
            CUSTOMER_LASTNAME,
            CUSTOMER_ADDRESS,
            CUSTOMER_EMAIL,
            CUSTOMER_PHONE,
            LOGIN_USERNAME,
            LOGIN_PASSWORD
        }

        public enum LogType
        {
            Anular_Documento = 1,
            Eliminar_Producto = 2,
            Suspender_Documento = 3,
            Recuperar_Documento = 4
        }
    }
}
