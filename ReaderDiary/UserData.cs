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
    
    public partial class UserData
    {
        public int id_userdata { get; set; }
        public int id_user { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string patronymic { get; set; }
    
        public virtual Account Account { get; set; }
    }
}
