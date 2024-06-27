using System;

namespace st10040092_POE_PROG6221_NIKHIL
{
    // Class representing an ingredient in a recipe
    internal class ingredients
    {
        // Properties of the ingredient

      

        // Current quantity of the ingredient in the recipe
        public double QuantityOfTheIngredient { get; set; }




  // Name of the ingredient
        public string NameOfIngredient { get; set; }



        // Original quantity of the ingredient stored for resetting purposes
        public double OriginalQuantityOfTheStoredIngredient { get; private set; }

        // Unit of measurement for the ingredient (e.g., grams, cups)
        public string UnitOfMeasurementForIngredient { get; set; }

          // Food group type to which the ingredient belongs (e.g., dairy, vegetables)
        public string FoodGroupType { get; set; }


        // Calories amount associated with the ingredient
        public int CaloriesAmount { get; set; }

       

        // Constructor to initialize an ingredient with specified values
        public ingredients(string name, double quantity, string unit, int calories, string foodGroup)
        {
            NameOfIngredient = name;                            // Initialize name of the ingredient
            QuantityOfTheIngredient = quantity;                 // Initialize current quantity
            OriginalQuantityOfTheStoredIngredient = quantity;   // Store original quantity for reset
            UnitOfMeasurementForIngredient = unit;              // Initialize unit of measurement
            CaloriesAmount = calories;                          // Initialize calories amount
            FoodGroupType = foodGroup;                          // Initialize food group type
        }

        // Method to reset the quantity of the ingredient to its original value
        public void ResetQuantity()
        {
            QuantityOfTheIngredient = OriginalQuantityOfTheStoredIngredient;  // Reset quantity to original
        }
    }
}
//CODE ATTRIBUTION: A. Troelsen and P. Japikse. 2022. Pro C# 10 with .NET 6. 11th ed.West Chester, OH, USA. Apress.
// code attribution
// W3schools
// https://www.w3schools.com/cs/index.php
