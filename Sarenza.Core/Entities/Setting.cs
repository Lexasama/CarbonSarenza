using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sarenza.Core.Entities;

public class Setting : IEquatable<Setting>
{

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public double HotTemperature { get; set; }
    public double ColdTemperature { get; set; }
    public DateTime CreationDateTime { get; set; }
    
    public bool Equals(Setting? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return Id == other.Id && HotTemperature.Equals(other.HotTemperature) && ColdTemperature.Equals(other.ColdTemperature) && CreationDateTime.Equals(other.CreationDateTime);
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Setting)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id, HotTemperature, ColdTemperature, CreationDateTime);
    }
}