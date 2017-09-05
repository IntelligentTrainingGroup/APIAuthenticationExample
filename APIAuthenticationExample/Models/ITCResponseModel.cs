using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIAuthenticationExample.Models {
    public class ITCResponseModel<t> {
        public t Data { get; set; }
        public string Error { get; set; }
    }
}