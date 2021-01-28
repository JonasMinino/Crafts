﻿using Crafts.Models;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Crafts.Services
{
    public class JasonFileProductService
    {
        //Creates a new web host environment.//
        public JasonFileProductService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }
        public IWebHostEnvironment WebHostEnvironment { get; }
        
        //Gets the path of the jason file.//
        private string JsonFile { get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "products.json"); } }

        //Deserializes the jason file into a IEnumerable collection.//
        public IEnumerable<Product> GetProducts()
        {
            using(var jsonFileReader = File.OpenText(JsonFile))
            {
                return JsonSerializer.Deserialize<Product[]>(jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
            }
        }
    }
}
