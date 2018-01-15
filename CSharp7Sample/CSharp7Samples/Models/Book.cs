using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp7Samples.Models
{
    public class Book : BindableBase
    {
        private string _title;

        public string Title
        {
            get => _title;
            set => Set(ref _title, value);
        }

    }
}
