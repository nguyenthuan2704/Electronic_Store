//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Electronic_Store.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public partial class product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public product()
        {
            this.upload_images = new HashSet<upload_images>();
        }
    
        public int id { get; set; }
        [Required(ErrorMessage = "Product Name is required.")]
        public string name { get; set; }
        public string images { get; set; }
        [Required(ErrorMessage = "Price is required.")]
        public decimal price { get; set; }
        public string descriptions { get; set; }
        public bool status { get; set; }
        [Required(ErrorMessage = "Please Select Category")]
        //[Required, Range(1, int.MaxValue, ErrorMessage = "Error: Must Choose a Category")]
        public int category_id { get; set; }
    
        public virtual category category { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<upload_images> upload_images { get; set; }
        

    }
}
