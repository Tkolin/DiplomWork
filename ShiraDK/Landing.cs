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
    
    public partial class Landing
    {
        public int ID { get; set; }
        public Nullable<int> PlaceNumber { get; set; }
        public Nullable<int> BuyingTicketsID { get; set; }
    
        public virtual BuyingTicket BuyingTicket { get; set; }
    }
}
