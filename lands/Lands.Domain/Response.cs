﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lands.Domain
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
