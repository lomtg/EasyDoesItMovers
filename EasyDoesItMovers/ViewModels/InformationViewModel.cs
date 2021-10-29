using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EasyDoesItMovers.ViewModels
{
    public class InformationViewModel
    {
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        [DataType(DataType.MultilineText)]
        public string Text { get; set; }
    }
}
