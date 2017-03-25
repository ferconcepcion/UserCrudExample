using System;
using System.ComponentModel.DataAnnotations;

namespace UserCrudExample.Models
{
    /// <summary>
    /// UserCrudExample
    /// Author: Fernando Concepción Gutiérrez
    /// http://www.fconcepcion.com
    /// 
    /// This class contains the model to update an user
    /// </summary>
    public class UpdateUserModel
    {
        [Required(ErrorMessage = "Id is required")]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Name is required")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Birthdate is required")]
        [Display(Name = "Birthdate")]
        [DataType(DataType.DateTime)]
        public DateTime Birthdate { get; set; }
    }
}