namespace TP1.Domain.Models.DTO
{
    public class TeamDTO
    {
        public TeamDTO()
        {
        }

        public TeamDTO(string name, bool active)
        {
            Name = name;
            Active = active;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
    }
}
