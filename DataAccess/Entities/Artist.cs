using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities
{
    public class Artist
    {
        public Artist()
        {
            Album = new HashSet<Album>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }
        public string ImageUrl { get; set; }

        public virtual ICollection<Album> Album { get; set; }
    }
}