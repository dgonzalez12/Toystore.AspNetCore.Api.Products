using System;

namespace Toystore.Core.Products.Exceptions
{
    public class ProductException : Exception
    {
        public ProductException(string message)
            : base(message)
        {

        }
    }
}
