namespace AttributeShowing
{
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Real life examples
    /// Example of validation attributes - they do not change the code only declare it !! The framework goes through all the code and when see this validations then tells you if its valid this class or not 
    /// They are used also for testing, VS can recognize the tests by their attributes
    /// </summary>
    public class Cat
    {
        [Required]
        [MinLength(3)]
        [MaxLength(100)]
        public string Name { get; set; }

        [Range(0, 50)]
        public int Age { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }
    }
}
