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
    
    public partial class TypeVeterinaryEquipment
    {
        public TypeVeterinaryEquipment()
        {
            this.VeterinaryEquipment = new HashSet<VeterinaryEquipment>();
        }
    
        public int IdTypeVeterinaryEquipment { get; set; }
        public string NameTypeVeterinaryEquipment { get; set; }
    
        public virtual ICollection<VeterinaryEquipment> VeterinaryEquipment { get; set; }
    }
}