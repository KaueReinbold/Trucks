using System;
using System.ComponentModel.DataAnnotations;
using Trucks.Application.Attributes;
using Trucks.Application.ViewModels.Enumerables;

namespace Trucks.Application.ViewModels
{
    /// <summary>
    /// Object that represents a Truck to end user applications.
    /// </summary>  
    public class TruckViewModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(17)]
        [RegularExpression("[A-HJ-NPR-Z0-9]{13}[0-9]{4}", ErrorMessage = "The Chassis is invalid.")]
        [Display(Name = "Chassis", Prompt = "Type the Chassis identifier")]
        public string Chassis { get; set; }

        [Required]
        [Display(Name = "Model")]
        [EnumValidateExists]
        public EnumModelViewModel? Model { get; set; }

        [MaxLength(100)]
        [Display(Name = "Model Complement", Prompt = "Type the Complement of Model")]
        public string ModelComplement { get; set; }

        [Required]
        [Display(Name = "Year")]
        public int? Year { get; set; }

        [Required]
        [Display(Name = "Model Year")]
        public int? ModelYear { get; set; }

        [Display(Name = "Model Complement")]
        public string ModelComplementDisplay
        {
            get
            {
                if (string.IsNullOrEmpty(ModelComplement))
                {
                    return string.Format("{0}", Model);
                }

                return string.Format("{0} - {1}", Model, ModelComplement);
            }
        }

    }
}
