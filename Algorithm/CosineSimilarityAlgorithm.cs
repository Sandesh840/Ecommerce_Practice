using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithm.Models;
using Ecommerce.Models;
using Ecommerce.Models.ViewModels;
using Microsoft.ML;

namespace Algorithm
{
    public class CosineSimilarityAlgorithm
    {
        List<AlgoProduct> _products;
        MLContext _mlContext;
        //AlgoProduct _productToRecommendFor;
        public CosineSimilarityAlgorithm(List<Product> products) 
        {
            //create MLContext
            _mlContext = new MLContext();

            _products = products.Select(p=>new AlgoProduct()
            {
                Id = p.Id,
                Description = p.Description
            }).ToList();
            
/*            _productToRecommendFor = new AlgoProduct()
            {
                Id = productToRecommendFor.Id,
                Description = productToRecommendFor.Description

            };*/
        }

        public List<int> GetSimilarProducts(int productId, double similarityThreshold = 0.1)
        {
            // Create an IDataView from the product data
            var dataView = _mlContext.Data.LoadFromEnumerable(_products.Select(p => new ProductData { Description = p.Description }));

            // Define a data preparation pipeline for description
            var descriptionPipeline = _mlContext.Transforms.Text.FeaturizeText("Description", "Description")
                .Append(_mlContext.Transforms.NormalizeMinMax("Description"));

            // Fit the description data preparation pipeline
            var descriptionPreprocessedData = descriptionPipeline.Fit(dataView).Transform(dataView);

            // Extract TF-IDF vectors for description
            var descriptionTfidfVectors = _mlContext.Data
                .CreateEnumerable<TfidfTransformedData>(descriptionPreprocessedData, reuseRowObject: false);

            // Update the products with TF-IDF vectors for description
            int i = 0;
            foreach (var product in _products)
            {
                product.CombinedTFIDFVector = descriptionTfidfVectors.ElementAt(i++).Description;
            }
            var _productToRecommendFor = _products.FirstOrDefault(p => p.Id == productId);
            //recommend product
            if (_productToRecommendFor != null)
            {
                var recommendedProducts = _products
                    .Where(p => p.Id != _productToRecommendFor.Id)
                    .Select(p => new
                    {
                        Product = p,
                        Similarity = CalculateCosineSimilarity(_productToRecommendFor.CombinedTFIDFVector, p.CombinedTFIDFVector)
                    })
                    .Where(r => r.Similarity >= similarityThreshold)
                    .OrderByDescending(r => r.Similarity)
                    .Select(r => r.Product);

                /*Console.WriteLine("Recommended Products:");
                foreach (var recommendedProduct in recommendedProducts)
                {
                    Console.WriteLine($"Product {recommendedProduct.Id}: {recommendedProduct.Description}");
                }*/
                return recommendedProducts
                            .Select(p => p.Id)
                            .Cast<int>() // Explicitly cast to IEnumerable<int>
                            .ToList(); ;
            }
            return new List<int>();

        }
        public double CalculateCosineSimilarity(float[] vector1, float[] vector2)
        {
            if (vector1.Length != vector2.Length)
            {
                throw new ArgumentException("Vectors must have the same length");
            }

            double dotProduct = 0;
            double magnitude1 = 0;
            double magnitude2 = 0;

            for (int i = 0; i < vector1.Length; i++)
            {
                dotProduct += vector1[i] * vector2[i];
                magnitude1 += Math.Pow(vector1[i], 2);
                magnitude2 += Math.Pow(vector2[i], 2);
            }

            magnitude1 = Math.Sqrt(magnitude1);
            magnitude2 = Math.Sqrt(magnitude2);

            if (magnitude1 == 0 || magnitude2 == 0)
            {
                return 0.0; // Handle division by zero
            }

            return dotProduct / (magnitude1 * magnitude2);
        }
    }
}
