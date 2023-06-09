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
    
    public partial class Event
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Event()
        {
            this.BuyingTickets = new HashSet<BuyingTicket>();
            this.ItemsForEvents = new HashSet<ItemsForEvent>();
        }
    
        public int ID { get; set; }
        public string Name { get; set; }
        public System.DateTime DateStart { get; set; }
        public double Duration { get; set; }
        public string Description { get; set; }
        public int OrganizerID { get; set; }
        public Nullable<double> Price { get; set; }
        public Nullable<int> AvailableOfSeat { get; set; }
        public Nullable<int> NumberOfSeat { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BuyingTicket> BuyingTickets { get; set; }
        public virtual Organizer Organizer { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ItemsForEvent> ItemsForEvents { get; set; }
    }
}
