//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AcadLib.Model.User.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class AutocadUsers
    {
        public int ID { get; set; }
        public string Login { get; set; }
        public string FIO { get; set; }
        public string Group { get; set; }
        public bool Disabled { get; set; }
        public string Description { get; set; }
    }
}
