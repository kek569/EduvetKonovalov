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
    
    public partial class Passport
    {
        public Passport()
        {
            this.Staff = new HashSet<Staff>();
        }
    
        public int IdPassport { get; set; }
        public int NumberPassport { get; set; }
        public int SeriesPassport { get; set; }
    
        public virtual ICollection<Staff> Staff { get; set; }
    }
}
