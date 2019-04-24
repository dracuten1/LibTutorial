using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models {
    public class AttributeValue {
        public int Id { get; set; }
        public int AttributeTypeId { get; set; }
        public CategoryAttribute CategoryAttribute { get; set; }
        public virtual Product Product { get; set; }
        public string Value { get; set; }
    }
}
