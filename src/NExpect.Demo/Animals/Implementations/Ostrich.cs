namespace NExpect.Demo.Animals.Implementations
{
    public class Ostrich : Animal
    {
        public Ostrich()
            : base(
                2,
                DermisProtrusions.Feathers,
                IncubationTypes.Egg,
                Habitats.Savanna,
                BodyTypes.Vertibrate,
                Animals.Colors.Black,
                Animals.Colors.White
            )
        {
        }
    }
}