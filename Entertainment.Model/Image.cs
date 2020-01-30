using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entertainment.Model
{
    public class Image
    {
        public int ImageId { get; set; }
        [Required]
        public string ImageTitle { get; set; }
        public byte[] ImageData { get; set; }

    }
}
