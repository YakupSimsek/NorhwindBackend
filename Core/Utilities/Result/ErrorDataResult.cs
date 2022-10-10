﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Result
{
    public class ErrorDataResult<T>:DataResult<T>
    {
        public ErrorDataResult(T data, string message) : base(data, success: false, message)
        {
        }
        public ErrorDataResult(T data) : base(data, success: false)
        {
        }
    }
}
