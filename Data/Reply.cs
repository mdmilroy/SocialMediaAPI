using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data
{
    public class Reply : Comment
    {        
        public Comment ReplyComment { get; set; }
    }
}