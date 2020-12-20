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
            LOGIN_PASSWORD,
            PRODUCT_QUANTITY,
            EMISSIONPOINT_NUMBER,
            INVOICE_NUMBER
        }

        public enum ScaleBrands
        {
            CAS,
            METTLER_TOLEDO,
            RICE_LAKE,
            DATALOGIC
        }

        public enum LogType
        {
            ANULAR_DOCUMENTO = 1,
            ELIMINAR_PRODUCTO = 2,
            SUSPENDER_DOCUMENTO = 3,
            RECUPERAR_DOCUMENTO = 4
        }

        public enum Taxtype
        {
            RENTA = 1,
            IVA = 2,
            ISD = 6
        }

        public enum DocumentType
        {
            INVOICE,
            CLOSINGCASHIER,
            SALESORDER,
            PURCHASEORDER
        }
    }
}
