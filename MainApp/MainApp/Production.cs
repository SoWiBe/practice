//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MainApp
{
    using System;
    using System.Collections.Generic;
    
    public partial class Production
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Production()
        {
            this.Epmloyees = new HashSet<Epmloyees>();
        }
    
        public int Id { get; set; }
        public string Time { get; set; }
        public string Price { get; set; }
        public string Number { get; set; }
        public string CountHuman { get; set; }
        public string Materials { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Epmloyees> Epmloyees { get; set; }
    }
}