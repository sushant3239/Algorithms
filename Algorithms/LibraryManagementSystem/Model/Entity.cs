namespace LibraryManagementSystem.Model
{
    public class Entity
    {
        public Entity(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
    }
}