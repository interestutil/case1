using case1.Models;
using System.ComponentModel.DataAnnotations;

internal class Tasks
{
    [Key]
    public int TaskID { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }
    public DateTime DueDate { get; set; }

    public string Name { get; set; }

    public Users User { get; set; }
}