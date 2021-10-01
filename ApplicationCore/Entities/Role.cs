using System.Collections.Generic;

namespace ApplicationCore.Entities
{
    public class Role
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public ICollection<UserRole> Users { get; set; }
    }
}