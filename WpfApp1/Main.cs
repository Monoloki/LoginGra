//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfApp1
{
    using System;
    using System.Collections.Generic;
    
    public partial class Main
    {
        public string Login { get; set; }
        public string Haslo { get; set; }
        public Nullable<int> RolaID { get; set; }
        public string NazwaPostaci { get; set; }
        public Nullable<int> KlasaID { get; set; }
        public Nullable<int> FrakcjaID { get; set; }
    
        public virtual Frakcje Frakcje { get; set; }
        public virtual Klasy Klasy { get; set; }
        public virtual Role Role { get; set; }
    }
}
