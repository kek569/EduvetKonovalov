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
        public int IdStaff { get; set; }
        public int AmountRequest { get; set; }
        public decimal SumRequest { get; set; }
        public byte[] PhotoVeterinaryEquipment { get; set; }
    
        public virtual Staff Staff { get; set; }
        public virtual TypeVeterinaryEquipment TypeVeterinaryEquipment { get; set; }
    }
}
