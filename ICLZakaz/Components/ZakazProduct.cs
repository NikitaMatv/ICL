//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ICLZakaz.Components
{
    using System;
    using System.Collections.Generic;
    
    public partial class ZakazProduct
    {
        public int Id { get; set; }
        public Nullable<int> ZakazId { get; set; }
        public Nullable<int> ProductId { get; set; }
        public Nullable<int> Count { get; set; }
        public Nullable<int> EmployeId { get; set; }
    
        public virtual Employe Employe { get; set; }
        public virtual Product Product { get; set; }
        public virtual Zakaz Zakaz { get; set; }
    }
}
