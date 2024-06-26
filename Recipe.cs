using Microsoft.VisualBasic; // Importing the Microsoft.VisualBasic namespace for InputBox
using st10040092_POE_PROG6221_NIKHIL; // Importing the namespace where the ingredients class is defined
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace st10040092_POE_PROG6221_NIKHIL
{
    // Class representing a recipe
    internal class Recipe
    {
        // Private lists to store ingredients and steps of the recipe
        private List<ingredients> ingredients = new List<ingredients>();
        private List<string> steps = new List<string>();

        // Properties of the recipe

        public string? NameOfRecipe { get; set; } // Name of the recipe
        public string? FoodGroupNameOfIngredients { get; set; } // Food group of ingredients
        public List<ingredients>? IngredientList => ingredients; // List of ingredients

        // Method to prompt the user to enter the recipe details
        public void EnterDetails()
        {
            // Prompt the user to enter the name and food group of the recipe
            NameOfRecipe = PromptInput("Please enter the name of the recipe:");
            FoodGroupNameOfIngredients = PromptInput("Please enter the food group of the recipe:");

            // Prompt the user to enter the number of ingredients
            int numberOfIngredients = GetValidatedIntInput("Please enter the number of ingredients:");
            ingredients.Clear(); // Clear existing ingredients list

            // Loop to get details of each ingredient
            for (int a = 1; a <= numberOfIngredients; a++)
            {
                string nameOfIngredient = PromptInput($"Enter the name of ingredient {a}:");
                double quantityOfIngredient = GetValidatedDoubleInput($"Enter the quantity of {nameOfIngredient}:");
                string unitOfIngredient = PromptInput($"Enter the unit of measurement for {nameOfIngredient}:");
                int caloriesOfIngredient = GetValidatedIntInput($"Enter the calories of {nameOfIngredient}:");

                // Create a new ingredient object and add it to the ingredients list
                ingredients.Add(new ingredients(nameOfIngredient, quantityOfIngredient, unitOfIngredient, caloriesOfIngredient, FoodGroupNameOfIngredients));
            }

            // Prompt the user to enter the number of steps
            int numberOfSteps = GetValidatedIntInput("Please enter the number of steps:");
            steps.Clear(); // Clear existing steps list

            // Loop to get details of each step
            for (int b = 1; b <= numberOfSteps; b++)
            {
                string stepDescription = PromptInput($"Enter description for step {b}:");
                steps.Add(stepDescription); // Add the step description to the steps list
            }

            MessageBox.Show("Recipe entered successfully!"); // Confirmation message
        }

        // Method to display the recipe details
        public void Display()
        {
            StringBuilder recipeDetails = new StringBuilder();

            // Build the recipe details string
            recipeDetails.AppendLine($"Recipe: {NameOfRecipe}");
            recipeDetails.AppendLine($"Food Group: {FoodGroupNameOfIngredients}");
            recipeDetails.AppendLine();
            recipeDetails.AppendLine("Ingredients:");

            // Append each ingredient's details to the recipe details string
            foreach (ingredients ingredient in ingredients)
            {
                recipeDetails.AppendLine($"{ingredient.NameOfIngredient} - {ingredient.QuantityOfTheIngredient} {ingredient.UnitOfMeasurementForIngredient}");
            }

            recipeDetails.AppendLine();
            recipeDetails.AppendLine("Steps:");

            // Append each step's description to the recipe details string
            for (int c = 0; c < steps.Count; c++)
            {
                recipeDetails.AppendLine($"{c + 1}. {steps[c]}");
            }

            recipeDetails.AppendLine();

            // Calculate and append total calories
            int totalCalories = ingredients.Sum(i => i.CaloriesAmount);
            recipeDetails.AppendLine($"Total Calories: {totalCalories}");

            // Display a warning if total calories exceed 300
            if (totalCalories > 300)
            {
                recipeDetails.AppendLine("WARNING: Total calories exceed 300!");
            }

            // Show the recipe details in a message box
            MessageBox.Show(recipeDetails.ToString(), "Recipe Details");
        }

        // Method to scale the recipe quantities by a specified factor
        public void Scale()
        {
            // Prompt user to choose a scaling factor
            double scalingFactor = GetValidatedDoubleInput("Choose a scaling factor (0.5, 2, or 3):");

            // Scale each ingredient's quantity by the scaling factor
            foreach (ingredients ingredient in ingredients)
            {
                ingredient.QuantityOfTheIngredient *= scalingFactor;
            }

            MessageBox.Show("Recipe scaled successfully!"); // Confirmation message
        }

        // Method to reset the quantities of all ingredients in the recipe to their original values
        public void ResetQuantities()
        {
            // Reset each ingredient's quantity to its original value
            foreach (ingredients ingredient in ingredients)
            {
                ingredient.ResetQuantity();
            }

            MessageBox.Show("Quantities reset successfully."); // Confirmation message
            Display(); // Display updated recipe details
        }

        // Method to clear the recipe data
        public void Clear()
        {
            // Confirm with the user before clearing data
            MessageBoxResult result = MessageBox.Show("Are you sure you want to clear the data?", "Clear Recipe Data", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                ingredients.Clear(); // Clear ingredients list
                steps.Clear(); // Clear steps list
                MessageBox.Show("Data cleared successfully!"); // Confirmation message
            }
            else
            {
                MessageBox.Show("Data was not cleared."); // Message if data clearing is cancelled
            }
        }

        // Helper method to prompt the user for input using InputBox
        private string PromptInput(string message)
        {
            return Interaction.InputBox(message, "Recipe Entry");
        }

        // Helper method to get a validated integer input from the user
        private int GetValidatedIntInput(string message)
        {
            int result;
            while (!int.TryParse(PromptInput(message), out result) || result <= 0)
            {
                MessageBox.Show("Please enter a valid positive integer."); // Validation message
            }
            return result;
        }

        // Helper method to get a validated double input from the user
        private double GetValidatedDoubleInput(string message)
        {
            double result;
            while (!double.TryParse(PromptInput(message), out result) || result <= 0)
            {
                MessageBox.Show("Please enter a valid positive number."); // Validation message
            }
            return result;
        }
    }
}
