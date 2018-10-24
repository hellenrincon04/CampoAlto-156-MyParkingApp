using System;

namespace Core.DataTransferObject
{
    public class BaseApiResponse
    {
        public bool ActionCompleted { get; set; }
        public string Message { get; set; }
        public virtual object Data { get; set; }
    }
}