using Model.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Model.Services
{
    public class CreateBasicRequestService<T> : ICreateRequestService<T>
    {
        internal class CreateBasicRequestServiceConstants
        {
            public const string Separator = "&";
            public const string Equal = "=";
        }

        public string BaseRequest { get; set; }
        public string Separator { get; set; }
        public string Equal { get; set; }

        public CreateBasicRequestService()
        {
            this.Separator = CreateBasicRequestServiceConstants.Separator;
            this.Equal = CreateBasicRequestServiceConstants.Equal;
        }

        public string GetUrl(T request)
        {
            string requestString = this.BaseRequest;
            requestString += this.CreateRequestString(request);
            return requestString;
        }

        private string CreateRequestString(T request)
        {
            string requestString = String.Empty;
            foreach (PropertyInfo propertyInfo in request.GetType().GetRuntimeProperties())
            {
                if (propertyInfo.GetValue(request) != null)
                    requestString += this.GetKeyValue((string)propertyInfo.CustomAttributes.ToList()[0].NamedArguments.ToList()[0].TypedValue.Value,
                        (string)(request.GetType().GetRuntimeProperty(propertyInfo.Name).GetValue(request).ToString()) ?? String.Empty);
            }

            requestString = this.RemoveLastElement(requestString);
            return requestString;
        }

        private string GetKeyValue(string key, string value)
        {
            return key + this.Equal + value + this.Separator;
        }
        private string RemoveLastElement(string requestString)
        {
            return requestString.Remove(requestString.Length - 1);
        }

    }
}
