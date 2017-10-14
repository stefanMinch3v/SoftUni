namespace PhotographerSystem.Attributes
{
    using PhotographerSystem.Validator;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class TagAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string tag = value.ToString();

            if (tag.Any(c => char.IsWhiteSpace(c)) || tag.Length > 20 || !tag.StartsWith("#"))
            {
                return false;
            }

            return true;
        }
    }
}
