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
    
    public partial class Photos
    {
        public int id_photo { get; set; }
        public int id_userdata { get; set; }
        public byte[] data { get; set; }
    
        public virtual UserData UserData { get; set; }
    }
}
