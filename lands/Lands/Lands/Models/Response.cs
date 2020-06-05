using System;
using System.Collections.Generic;
using System.Text;

namespace Lands.Models
{
    public class Response
    {
        #region Attributes
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public object Result { get; set; }
        #endregion
    }
}
