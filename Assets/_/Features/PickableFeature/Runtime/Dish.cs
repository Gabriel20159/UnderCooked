using InteractableFeature.Runtime;
using PickableFeature.Runtime;

namespace _.Features.PickableFeature.Runtime
{
    public abstract class Dish : Pickable
    {
        public abstract bool AddIngredient(Ingredient ingredientToAdd);
        public abstract void Empty();
    }
}