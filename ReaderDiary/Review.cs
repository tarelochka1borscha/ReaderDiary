//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ReaderDiary
{
    using System;
    using System.Collections.Generic;
    
    public partial class Review
    {
        public int id_review { get; set; }
        public int id_passport { get; set; }
        public int id_user { get; set; }
        public Nullable<System.DateTime> first_date { get; set; }
        public Nullable<System.DateTime> last_date { get; set; }
        public Nullable<double> price { get; set; }
        public string description { get; set; }
        public int grade { get; set; }
    
        public virtual Account Account { get; set; }
        public virtual Passport Passport { get; set; }
    }
}
