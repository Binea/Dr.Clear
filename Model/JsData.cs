using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalMedical.Model
{
    public class JsData
    {
        string _code;

        public string code
        {
            get { return _code; }
            set { _code = value; }
        }
        string _message;

        public string message
        {
            get { return _message; }
            set { _message = value; }
        }
        object _data;

        public object data
        {
            get { return _data; }
            set { _data = value; }
        }
    }
}
