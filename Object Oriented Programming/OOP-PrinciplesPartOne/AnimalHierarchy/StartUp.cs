/*
    Problem 3. Animal hierarchy
    Create a hierarchy Dog, Frog, Cat, Kitten, Tomcat and define useful constructors and methods.
    Dogs, frogs and cats are Animals. All animals can produce sound (specified by the ISound interface). 
    Kittens and tomcats are cats. All animals are described by age, name and sex. Kittens can be only female
    and tomcats can be only male. Each animal produces a specific sound.
    Create arrays of different kinds of animals and calculate the average age of each
    kind of animal using a static method (you may use LINQ).
*/

namespace AnimalHierarchy
{
    public class StartUp
    {
        private static void Main()
        {
            var cats = new Cat[]
            {
                new Cat("Jora", 5, 'M'),
                new Cat("Vqra", 3, 'F')
            };
            var kittens = new Kitten[]
            {
                new Kitten("Roshko", 6) 
            };
        }
    }
}