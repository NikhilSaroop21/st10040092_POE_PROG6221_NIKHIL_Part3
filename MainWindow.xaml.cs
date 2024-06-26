using st10040092_POE_PROG6221_NIKHIL; // Importing the namespace for Recipe class
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace st10040092_POE_PROG6221_NIKHIL
{
    // Interaction logic for MainWindow.xaml
    public partial class MainWindow : Window
    {
        // List to store all recipes
        private List<Recipe> CollectionOfRecipe = new List<Recipe>();

        // Event handler for entering a new recipe
        private void EnterRecipe_Click(object sender, RoutedEventArgs e)
        {
            // Instantiate a new Recipe object and enter details
            Recipe newRecipe = new Recipe();
            newRecipe.EnterDetails(); // This method allows user to enter details for the new recipe
            CollectionOfRecipe.Add(newRecipe); // Add the new recipe to the collection
            MessageBox.Show("Recipe has been successfully captured!"); // Confirmation message
        }

        // Event handler for viewing all recipes
        private void ViewAllRecipes_Click(object sender, RoutedEventArgs e)
        {
            // Check if there are recipes in the collection
            if (CollectionOfRecipe == null || CollectionOfRecipe.Count == 0)
            {
                MessageBox.Show("There are no recipes available."); // Notify if no recipes are found
                return;
            }

            // Order recipes by name and prepare a list of recipe names
            var recipeNames = CollectionOfRecipe.OrderBy(r => r.NameOfRecipe).Select(r => r.NameOfRecipe);
            string recipeList = string.Join("\n", recipeNames); // Join recipe names into a single string

            // Display all recipe names in a message box
            MessageBox.Show("List of Recipes:\n\n" + recipeList);
        }

        // Event handler for selecting a recipe to display
        private void SelectRecipe_Click(object sender, RoutedEventArgs e)
        {
            // Prompt user to enter the name of the recipe to display
            string recipeNameChosen = Microsoft.VisualBasic.Interaction.InputBox("Enter the name of the recipe:", "Recipe Selection");

            // Validate user input
            if (string.IsNullOrWhiteSpace(recipeNameChosen))
            {
                MessageBox.Show("Please enter a valid recipe name."); // Notify if recipe name is empty
                return;
            }

            // Find the recipe with the specified name
            Recipe selectedRecipe = CollectionOfRecipe?.Find(r => r.NameOfRecipe == recipeNameChosen);

            // Display the recipe if found; otherwise, show a message
            if (selectedRecipe != null)
            {
                selectedRecipe.Display(); // Method to display details of the selected recipe
            }
            else
            {
                MessageBox.Show("Recipe not found."); // Notify if recipe is not found
            }
        }

        // Event handler for scaling a recipe
        private void ScaleRecipe_Click(object sender, RoutedEventArgs e)
        {
            // Prompt user to enter the name of the recipe to scale
            string recipeNameChosen = Microsoft.VisualBasic.Interaction.InputBox("Enter the name of the recipe to scale:", "Scaling Recipe");

            // Validate user input
            if (string.IsNullOrWhiteSpace(recipeNameChosen))
            {
                MessageBox.Show("Please enter a valid recipe name."); // Notify if recipe name is empty
                return;
            }

            // Find the recipe with the specified name
            Recipe recipeToScale = CollectionOfRecipe?.Find(r => r.NameOfRecipe == recipeNameChosen);

            // Scale the recipe if found; otherwise, show a message
            if (recipeToScale != null)
            {
                recipeToScale.Scale(); // Method to scale up the quantities of ingredients in the recipe
                MessageBox.Show("Recipe scaling successful!"); // Confirmation message
            }
            else
            {
                MessageBox.Show("Recipe not found."); // Notify if recipe is not found
            }
        }

        // Event handler for resetting quantities of a recipe to their original values
        private void ResetQuantities_Click(object sender, RoutedEventArgs e)
        {
            // Prompt user to enter the name of the recipe to reset quantities
            string recipeNameChosen = Microsoft.VisualBasic.Interaction.InputBox("Enter the name of the recipe to reset quantities:", "Reset Quantities");

            // Validate user input
            if (string.IsNullOrWhiteSpace(recipeNameChosen))
            {
                MessageBox.Show("Please enter a valid recipe name."); // Notify if recipe name is empty
                return;
            }

            // Find the recipe with the specified name
            Recipe recipeToReset = CollectionOfRecipe?.Find(r => r.NameOfRecipe == recipeNameChosen);

            // Reset quantities if recipe found; otherwise, show a message
            if (recipeToReset != null)
            {
                recipeToReset.ResetQuantities(); // Method to reset quantities of ingredients in the recipe
                MessageBox.Show("Quantities reset successfully for this recipe."); // Confirmation message
            }
            else
            {
                MessageBox.Show("Recipe not found."); // Notify if recipe is not found
            }
        }

        // Event handler for clearing recipe data
        private void ClearData_Click(object sender, RoutedEventArgs e)
        {
            // Prompt user to enter the name of the recipe to clear
            string recipeNameChosen = Microsoft.VisualBasic.Interaction.InputBox("Enter the name of the recipe to clear:", "Clear Recipe Data");

            // Validate user input
            if (string.IsNullOrWhiteSpace(recipeNameChosen))
            {
                MessageBox.Show("Please enter a valid recipe name."); // Notify if recipe name is empty
                return;
            }

            // Find the recipe with the specified name
            Recipe recipeToClear = CollectionOfRecipe?.Find(r => r.NameOfRecipe == recipeNameChosen);

            // Clear recipe data if found; otherwise, show a message
            if (recipeToClear != null)
            {
                recipeToClear.Clear(); // Method to clear all data associated with the recipe
                CollectionOfRecipe.Remove(recipeToClear); // Remove the recipe from the collection
                MessageBox.Show("Data cleared successfully for the recipe."); // Confirmation message
            }
            else
            {
                MessageBox.Show("Recipe not found."); // Notify if recipe is not found
            }
        }

        // Event handler for exiting the application
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close(); // Close the application window
        }

        // Event handler for filtering recipes by ingredient and food group
        private void Filter_Click(object sender, RoutedEventArgs e)
        {
            // Prompt user to enter the name of the ingredient to filter by
            string ingredientNameChosen = Microsoft.VisualBasic.Interaction.InputBox("Enter the name of the ingredient to filter by:", "Filter by Ingredient Name");

            // Prompt user to choose a food group to filter by
            string foodGroupNameChosen = Microsoft.VisualBasic.Interaction.InputBox("Choose a food group to filter by:", "Filter by Food Group");

            // Validate ingredient name input
            if (string.IsNullOrWhiteSpace(ingredientNameChosen))
            {
                MessageBox.Show("Please enter a valid ingredient name."); // Notify if ingredient name is empty
                return;
            }

            // Validate food group input
            if (string.IsNullOrWhiteSpace(foodGroupNameChosen))
            {
                MessageBox.Show("Please choose a valid food group."); // Notify if food group is not chosen
                return;
            }

            // Check if there are recipes in the collection
            if (CollectionOfRecipe == null || CollectionOfRecipe.Count == 0)
            {
                MessageBox.Show("No recipes available."); // Notify if no recipes are found
                return;
            }

            // List to store filtered recipes
            List<Recipe> filteredRecipes = new List<Recipe>();

            // Iterate through each recipe in the collection
            foreach (var recipe in CollectionOfRecipe)
            {
                // Check if the recipe's ingredient list is not null, contains the specified ingredient, and matches the food group
                if (recipe.IngredientList != null &&
                    recipe.IngredientList.Any(i => i.NameOfIngredient.ToLower().Contains(ingredientNameChosen.ToLower())) &&
                    !string.IsNullOrWhiteSpace(recipe.FoodGroupNameOfIngredients) &&
                    recipe.FoodGroupNameOfIngredients.ToLower() == foodGroupNameChosen.ToLower())
                {
                    filteredRecipes.Add(recipe); // Add the recipe to filtered list if criteria are met
                }
            }

            // Display filtered recipes
            if (filteredRecipes.Count == 0)
            {
                MessageBox.Show("No recipes found matching the criteria."); // Notify if no recipes match the criteria
            }
            else
            {
                // Prepare a string of filtered recipe names
                var recipeNamesFiltered = filteredRecipes.OrderBy(r => r.NameOfRecipe).Select(r => r.NameOfRecipe);
                string filteredRecipeList = string.Join("\n", recipeNamesFiltered);

                // Display filtered recipe names in a message box
                MessageBox.Show("Filtered Recipes:\n\n" + filteredRecipeList);
            }
        }
    }
}
