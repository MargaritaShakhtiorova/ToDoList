using System.ComponentModel;
using To_Do_List.Areas.Identity.Data;

namespace To_Do_List.Models
{
    public class UserTask
    {
        public int Id { get; set; }

        [DisplayName("")]
        public string Description { get; set; }

        [DisplayName("")]
        public bool IsDone { get; set; }
        public To_Do_ListUser User { get; set; }
    }
}
