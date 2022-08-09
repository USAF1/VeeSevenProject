using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EntityLib.ImactStoriesManagment
{
    public class ImpactStory
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [Column(TypeName="varchar(50)")]
        public string Name { get; set; }
        [Required]
        [Column(TypeName = "varchar(max)")]
        public string Headline { get; set; }
        [Required]
        [Column(TypeName = "varchar(max)")]
        public string Discription { get; set; }
    }
}
