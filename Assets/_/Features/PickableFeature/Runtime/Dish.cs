using InteractableFeature.Runtime;
using PickableFeature.Runtime;

namespace _.Features.PickableFeature.Runtime
{
    public class Dish : Pickable
    {
        public virtual void AddIngredient(Ingredient ingredientToAdd) {}
        public virtual void Empty() {}
    }
}