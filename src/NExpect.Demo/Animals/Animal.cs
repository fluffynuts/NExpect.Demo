namespace NExpect.Demo.Animals
{
    public enum BodyTypes
    {
        Unknown,
        Invertibrate,
        Vertibrate
    }

    public abstract class Animal
    {
        public BodyTypes BodyType { get; }
        public DermisProtrusions DermisProtrusion { get; }
        public IncubationTypes IncubationType { get; }
        public Habitats Habitat { get; }
        public int Legs { get; }
        public Colors[] Colors { get; }

        public Genders Gender { get; set; }
        public string Name { get; set; }

        protected Animal(
            int legs,
            DermisProtrusions dermisProtrusion,
            IncubationTypes incubationType,
            Habitats habitat,
            BodyTypes bodyType,
            params Colors[] colors
        )
        {
            Legs = legs;
            DermisProtrusion = dermisProtrusion;
            IncubationType = incubationType;
            Habitat = habitat;
            Colors = colors;
        }
    }
}