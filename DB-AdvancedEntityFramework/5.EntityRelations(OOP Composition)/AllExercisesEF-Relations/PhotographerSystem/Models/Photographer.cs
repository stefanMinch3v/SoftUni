namespace PhotographerSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class Photographer
    {
        private string password;

        public Photographer()
        {
            this.Albums = new HashSet<PhotographerAlbum>();
        }

        [Key]
        public int PhotographerId { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password
        {
            get
            {
                return this.password;
            }
            set
            {
                using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
                {
                    byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(value);
                    byte[] hashBytes = md5.ComputeHash(inputBytes);

                    // Convert the byte array to hexadecimal string
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < hashBytes.Length; i++)
                    {
                        sb.Append(hashBytes[i].ToString("X2"));
                    }

                    this.password = sb.ToString();
                }
            }
        }

        [Required]
        public string Email { get; set; }

        [Required]
        public DateTime RegisterDate { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public virtual ICollection<PhotographerAlbum> Albums { get; set; }

    }
}
