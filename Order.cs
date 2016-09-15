using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloseTruck
{
    public class Order
    {
        [System.ComponentModel.DisplayName("OrderId")]
        public string OrderId { get; set; }
        [System.ComponentModel.DisplayName("Name")]
        public string Name { get; set; }
        [System.ComponentModel.DisplayName("Mobile")]
        public string Mobile { get; set; }
        [System.ComponentModel.DisplayName("Address")]
        public string Address { get; set; }
        [System.ComponentModel.DisplayName("ZipCode")]
        public string ZipCode { get; set; }
        [System.ComponentModel.DisplayName("TrackingNo")]
        public string TrackingNo { get; set; }
        [System.ComponentModel.DisplayName("TerminalCode")]
        public string TerminalCode { get; set; }
    }
}
