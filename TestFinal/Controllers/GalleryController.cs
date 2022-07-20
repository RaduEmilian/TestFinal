using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TestFinal.Models;

namespace TestFinal.Controllers
{
    public class GalleryController : Controller
    {
        public IActionResult Index()
        {
            var hikingImageTags = new List<ImageTag>();
            var cityImageTags = new List<ImageTag>();

            var tag1 = new ImageTag()
            {
                Description = "Adventure",
                Id = 0
            };

            var tag2 = new ImageTag()
            {
                Description = "Urban",
                Id = 1
            };

            var tag3 = new ImageTag()
            {
                Description = "New York",
                Id = 2
            };

            hikingImageTags.Add(tag1);
            cityImageTags.AddRange(new List<ImageTag> { tag2, tag3 });

            var imageList = new List<GalleryImage>()
            {
                new GalleryImage()
                {
                    Title = "Hiking Trip",
                    Url = "images/image.jpg",
                    //Created = System.ComponentModel.DataAnnotations.DataType.DateTime.Now,
                    Tags = hikingImageTags
                },
                new GalleryImage()
                {
                    Title = "On the Trail",
                    Url = "https://www.pexels.com/photo/woman-holding-exercise-equipment-416809/",
                    //Created = DateTime.Now,
                    Tags = hikingImageTags
                },
                new GalleryImage()
                {
                    Title = "DownTown",
                    Url = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.pexels.com%2Fsearch%2Fgym%2F&psig=AOvVaw06vnp6Puthf36Pw-gMkokx&ust=1642503208691000&source=images&cd=vfe&ved=0CAsQjRxqFwoTCPCkzrTPuPUCFQAAAAAdAAAAABAD",
                    //Created = DateTime.Now,
                    Tags = cityImageTags
                },

            };
            var model = new GalleryIndexModel()
            {
                Images = imageList,
                SearchQuery = ""

            };
            return View(model);
        }
    }
}
