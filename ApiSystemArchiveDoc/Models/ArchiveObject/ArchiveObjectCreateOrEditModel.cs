using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ApiSystemArchiveDoc.Models;

public class ArchiveObjectCreateOrEditModel : AbstractArchiveModel
{
    /// <summary>
    /// References
    /// </summary>
    
    public List<SelectListItem>? ObjectTypes { get; set; }

    public List<SelectListItem>? TaskTypes { get; set; }
    public List<SelectListItem>? DocumentTypes { get; set; }

    /// <summary>
    /// Object proppertires
    /// </summary>
    [Required(ErrorMessage = "Не указан тип объекта")]
    public string ObjectType { get; set; }

    [Required(ErrorMessage = "Не указана пплощадь")]
    public double Square { get; set; }

    [Required(ErrorMessage = "Не указан вид задания")]
    public string ObjectTaskType { get; set; }

    /// <summary>
    /// Address propperties
    /// </summary>
    ///
    [Required(ErrorMessage = "Не указан кадастровый квартал")]

    public string KadKvartal { get; set; }

    public string? FullAddress { get; set; }

   // public string? PostalCode { get; set; }
  // public string? Country { get; set; }
  //  public string? FederalDistrict { get; set; }

   // public string? RegionType { get; set; }
  //  public string? RegionTypeFull { get; set; }
    public string? Region { get; set; }

  // public string? AreaType { get; set; }
   // public string? AreaTypeFull { get; set; }
    public string? Area { get; set; }

   // public string? SubAreaType { get; set; }
   // public string? SubAreaTypeFull { get; set; }
   // public string? SubArea { get; set; }

   // public string? CitygType { get; set; }
   // public string? CityTypeFull { get; set; }
    public string? City { get; set; }

    public string? CityArea { get; set; }
  //  public string? CityDistrictType { get; set; }
  //  public string? CityDistrictTypeFull { get; set; }
    public string? CityDistrict { get; set; }

   // public string? SettlementType { get; set; }
  //  public string? SettlementTypeFull { get; set; }
    public string? Settlement { get; set; }

   // public string? StreetType { get; set; }
   // public string? StreetTypeFull { get; set; }
    public string? Street { get; set; }

   // public string? HouseCadnum { get; set; }
  //  public string? HouseType { get; set; }
  //  public string? HouseTypeFull { get; set; }
    public string? House { get; set; }

   // public string? BlockType { get; set; }
   // public string? BlockTypeFull { get; set; }
    public string? Block { get; set; }

   // public string? Entrance { get; set; }
    public string? Floor { get; set; }

  //  public string? FlatCadnum { get; set; }
  //  public string? FlatType { get; set; }
  //  public string? FlatTypeFull { get; set; }
    public string? Flat { get; set; }

   // public string? SteadType { get; set; }
   // public string? SteadTypeFull { get; set; }
    public string? Stead { get; set; }

   // public string? FlatArea { get; set; }
  //  public string? SquareMeterPrice { get; set; }
  //  public string? FlatPrice { get; set; }
   // public string? PostalBox { get; set; }

  //  public string? FiasActuality_state { get; set; }
    public string? Okato { get; set; }
    public string? Oktmo { get; set; }
    public string? GeoLat { get; set; }
    public string? GeoLon { get; set; }
}