//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Lab4.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class admin
    {
        //Getters and Setters
        public int Id { get; set; }

        //Error Message (Validation)
        [DisplayName("User Name")]
        [Required(ErrorMessage = "This field is required.")]
        public string username { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "This field is required.")]
        public string password { get; set; }

        public string LoginErrorMessage { get; set; }
    }
}
