using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalBlog.Shared.Utilities.Abstract
{
    public interface IDataResult<out T> : IResult
    {
        public T Data { get; }
    }
}