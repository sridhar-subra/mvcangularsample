using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework
{
    public class GenericResponse
    {
        public Status Status { get; set; }
        public string[] Messages { get; set; }
    }

    public enum Status
    {
        Failed,
        Success
    }

    public class GenericResponse<T> : GenericResponse
    {
        public T returnObject;
    }
}
