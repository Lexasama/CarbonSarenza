using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CarbonSarenza.Web.Domain.Entities;

public class History
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public DateTime Date { get; init; } = DateTime.Now;
    public  double TemperatureC { get; init; }
}