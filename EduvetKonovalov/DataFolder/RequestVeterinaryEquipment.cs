//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EduvetKonovalov.DataFolder
{
    using System;
    using System.Collections.Generic;
    
    public partial class RequestVeterinaryEquipment
    {
        public int IdRequestVeterinaryEquipment { get; set; }
        public string NameVeterinaryEquipment { get; set; }
        public int IdTypeVeterinaryEquipment { get; set; }
        public System.DateTime RecordingDate { get; set; }
        public string WhereDidItComeFrom { get; set; }
        public int IdStaff { get; set; }
        public int IdRequestComing { get; set; }
        public int IdRequestConsumption { get; set; }
        public int IdRequestRemainder { get; set; }
        public byte[] PhotoVeterinaryEquipment { get; set; }
    
        public virtual RequestComing RequestComing { get; set; }
        public virtual RequestConsumption RequestConsumption { get; set; }
        public virtual RequestRemainder RequestRemainder { get; set; }
        public virtual Staff Staff { get; set; }
        public virtual TypeVeterinaryEquipment TypeVeterinaryEquipment { get; set; }
    }
}
