//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VietTravel.DBModels
{
    using System;
    using System.Collections.Generic;
    
    public partial class MAP
    {
        [System.ComponentModel.DataAnnotations.Key]
        public short mapID { get; set; }
        public string mapName { get; set; }
        public Nullable<decimal> longtitude { get; set; }
        public Nullable<decimal> latitude { get; set; }
    }
}