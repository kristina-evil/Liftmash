using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Liftmash.Domain.Entities
{
    public class SearchEntity
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Article { get; set; }
    }
}
