using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperPortal.Domain.Helper
{
    public class JsonData<T>
    {
        public JsonData()
        {
            Result = default(T);
            EventMessages = new List<EventData>();
        }

        public JsonData(T result)
        {
            Result = result;
            EventMessages = new List<EventData>();
        }

        public List<EventData> EventMessages { get; set; }
        public T Result { get; set; }
    }


    public class EventData
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public string Class { get; set; }

        public EventData()
        {
            this.Key = default(string);
            this.Value = default(string);
            this.Class = default(string);
        }

        public EventData(string key, string value, string className)
        {
            this.Key = key;
            this.Value = value;
            this.Class = className;
        }
    }

    /// <summary>
    /// Using this object to construct a json model for passing the status of an action plus a confirmation message which will be used in model popup.
    /// </summary>
    public class JsonStatus
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
        public string ErrorType { get; set; }
        public string ErrorMessage { get; set; }
        public string Title { get; set; }
    }
}
