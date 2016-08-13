using System;

namespace WakeOnBandXamarin.Core.Models
{
    public class MenuItem
    {
        public string Title { get; set; }

        public Type ViewModelType { get; set; }

        public string ImageName { get; set; }
    }
}