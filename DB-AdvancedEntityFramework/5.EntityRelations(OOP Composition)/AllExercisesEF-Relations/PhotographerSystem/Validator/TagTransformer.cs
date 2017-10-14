namespace PhotographerSystem.Validator
{
    using System.Text;
    using System;
    using System.Linq;

    public static class TagTransformer
    {
        public static string Transform(string tag)
        {
            var currentTag = tag.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            var newTag = string.Join("", currentTag);

            StringBuilder sb = new StringBuilder();

            if (!newTag.StartsWith("#"))
            {
                sb.Append("#");
            }
            if (newTag.Length > 20)
            {
                for (int i = 0; i < 20; i++)
                {
                    sb.Append(newTag[i]);
                }
            }
            else
            {
                for (int i = 0; i < newTag.Length; i++)
                {
                    sb.Append(newTag[i]);
                }
            }

            return sb.ToString();
        }
    }
}
