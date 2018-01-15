using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp7Samples.Services
{
    public class BooksService
    {
        private readonly ILogger _logger;
        public BooksService(ILogger logger)
        {

            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
    }
}
