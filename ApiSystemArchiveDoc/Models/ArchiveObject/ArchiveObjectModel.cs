using System.ComponentModel.DataAnnotations;

namespace ApiSystemArchiveDoc.Models;

public class ArchiveObjectModel: AbstractArchiveModel
{
    
   [Required (ErrorMessage = "Не указан тип объекта")]
    public string ObjectType { get; set; }
  
   [Required (ErrorMessage = "Не указана пплощадь")]
    public double Square { get; set; }
    [Required (ErrorMessage = "Не указан вид задания")]
    public string ObjectTaskType { get; set; }
    
    
    public List<ArchiveDocumentModel> Documents { get; set; } = new List<ArchiveDocumentModel>();
//    [Required (ErrorMessage = "Не указан адрес объекта")]

   public  ArchiveObjectAddressModel Address { get; set; }
}