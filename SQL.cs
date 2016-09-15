using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloseTruck
{
    public class SQL
    {
        public static readonly string CONSTRING = "****";

        public static readonly string SELECT_ORDER = "SELECT O.ExternOrderKey AS ID, O.C_Contact1 AS NAME, O.C_Zip AS ZIPCODE, O.C_Phone1 AS MOBILE, O.C_Address2 AS ADDRESS1, O.C_Address3 AS ADDRESS2, C.TrackingNumber AS TRACKINGNO, O.B_City AS TerminalCode FROM Orders O " +
                                                     "INNER JOIN CartonShipmentDetail C ON O.ExternOrderKey = C.ExternOrderKey " +
                                                     "WHERE C.TrackingNumber = @trackingNo";

        public static readonly string UPDATE_ORDER = "UPDATE ORDERS SET STATUS=9 WHERE EXTERNORDERKEY = @externOrderKey and storerkey='MANGOKR'";
    }
}
