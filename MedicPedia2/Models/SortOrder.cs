using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Medicpedia.Data.Classes
{
    public enum SortOrder
    {
        Logical,

        [Display(Name = "Alphabetical")]
        AlphabeticalAscending,

        [Display(Name = "Alphabetical (reversed)")]
        AlphabeticalDescending
    }
}