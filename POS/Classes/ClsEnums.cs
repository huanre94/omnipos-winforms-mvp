using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Classes
{
    public class ClsEnums
    {
        public enum MessageType
        {
            INFO
            ,WARNING
            ,ERROR
            ,CONFIRM
        }

        public enum PaymModeEnum
        {
            BONO
            , CHEQUE_DIA
            , CHEQUE_POST
            , CREDITO
            , DEBITO_BANCARIO
            , DEPOSITO_BANCARIO
            , DINERO_ELECTRONICO
            , EFECTIVO
            , NOTA_CREDITO
            , ANTICIPOS
            , PAGOS_WEB
            , RETENCION
            , TARJETA_CREDITO
            , TARJETA_CONSUMO
        }

        public enum InputFromOption
        {
            CHECK_ACCOUNTNUMBER
            , CHECK_NUMBER
            , CHECK_OWNERNAME
            , CHECK_OWNERIDENTIFICATION
            , CHECK_PHONE
            , CREDITCARD_AUTHORIZATION
            , GIFTCARD_NUMBER
            , CUSTOMER_NAME
        }
    }
}
