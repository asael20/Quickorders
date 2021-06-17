using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quickorders.Domain.Entities
{
    public class DatabaseResponse<TData>
    {
        public bool Success { get; private set; }
        public TData Data { get; private set; }
        public dynamic Error { get; private set; } = null;
        public string Message { get; private set; } = null;

        public static DatabaseResponse<TData> SuccessQuery(TData data)
        {
            return new DatabaseResponse<TData>() { Success= true, Data= data };
        }

        public static DatabaseResponse<TData> ErrorQuery(string message, dynamic error)
        {
            return new DatabaseResponse<TData>() { Success =false, Message =message, Error =error };
        }

    }
}
