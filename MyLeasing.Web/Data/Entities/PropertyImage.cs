﻿using System.ComponentModel.DataAnnotations;

namespace MyLeasing.Web.Data.Entities
{
    public class PropertyImage
    {
        public int Id { get; set; }

        [Display(Name = "Image")]
        public string ImageUrl { get; set; }

        public Property Property { get; set; }

        // TODO: Change the path when publish
        public string ImageFullPath => string.IsNullOrEmpty(ImageUrl)
            ? "https://TBD.azurewebsites.net/images/Properties/noImage.png"
            : $"https://TBD.azurewebsites.net{ImageUrl.Substring(1)}";
    }
}
