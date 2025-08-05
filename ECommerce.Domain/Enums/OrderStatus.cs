using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Enums
{
    public enum OrderStatus
    {
        [Display(Name = "قيد الانتظار")]
        Pending,

        [Display(Name = "قيد المعالجة")]
        Processing,

        [Display(Name = "تم الشحن")]
        Shipped,

        [Display(Name = "تم التوصيل")]
        Delivered,

        [Display(Name = "ملغى")]
        Cancelled
    }
}
