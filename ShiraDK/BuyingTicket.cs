//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ShiraRDKWork
{
    using System;
    using System.Collections.Generic;
    
    public partial class BuyingTicket
    {
        public int Number { get; set; }
        public System.DateTime PurchaseDate { get; set; }
        public int SalesmanID { get; set; }
        public Nullable<int> BuyerID { get; set; }
        public int EventID { get; set; }
        public Nullable<int> Count { get; set; }
    
        public virtual Event Event { get; set; }
        public virtual User User { get; set; }
        public virtual User User1 { get; set; }
    }
}
