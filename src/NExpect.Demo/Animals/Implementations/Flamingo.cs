namespace NExpect.Demo.Animals.Implementations
{
    public class Flamingo: Animal
    {
        public Flamingo()
            : base(
                  2, 
                  DermisProtrusions.Feathers, 
                  IncubationTypes.Egg, 
                  Habitats.Wetlands, 
                  BodyTypes.Vertibrate, 
                  Animals.Colors.Pink, Animals.Colors.Black, Animals.Colors.White
            )
        {
        }
    }
}
