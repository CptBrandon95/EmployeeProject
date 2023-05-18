namespace EmployeeProject.Common.Model
{
    public class Team : BaseEntity
    {
        public string Name{ get; set; } = default!;

        public List<Employees>Employees { get; set; } = default!;

    }
}