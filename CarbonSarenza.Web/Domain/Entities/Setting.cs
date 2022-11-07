using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CarbonSarenza.Web.Domain.Entities;

public class Setting
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public double HotTemperature { get; set; }
    public double ColdTemperature { get; set; }
    public DateTime CreationDateTime { get; init; } = DateTime.Now;
}