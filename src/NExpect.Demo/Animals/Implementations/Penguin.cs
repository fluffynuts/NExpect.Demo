namespace NExpect.Demo.Animals.Implementations
{
    public class Penguin : Animal
    {
        public Penguin()
            : base(
                2,
                DermisProtrusions.Feathers,
                IncubationTypes.Egg,
                Habitats.Polar,
                BodyTypes.Vertibrate,
                Animals.Colors.Black,
                Animals.Colors.White
            )
        {
        }
    }
}