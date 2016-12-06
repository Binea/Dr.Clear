using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalMedical.DentalEnumeration
{
    public enum EMRStatusEnum
    {
        //诊前状态    0
        新建 = 0,
        提交 = 1,
        口腔模型 = 2,
        设计方案 = 4,
        模型修改 = 3,
        方案修改 = 5,
        //诊中状态j 1
        病例已确认 = 6,
        加工下单, 待接单 = 7,
        已接单, 待付款 = 8,
        已付款, 准备排产 = 9,
        已排产, 准备发货 = 10,
        已发货 = 11,
        //诊后状态 2
        病例归档 = 12,//归档按钮暂时放弃
        //结案记录 = 13,
        病例结束, 放弃 = 13,


   

    }
}
