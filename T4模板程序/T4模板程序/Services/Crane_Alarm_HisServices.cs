using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IServices;
using Model;
using IRepository;
namespace Services
{
   ///using Model;
    /// <summary>
    /// 负责每个数据表的数据操作
    /// </summary>
    public  partial class Crane_Alarm_HisServices:BaseServices<Crane_Alarm_His>,ICrane_Alarm_HisService
    {
         ICrane_Alarm_HisRepository dal;
         #region 定义构造函数，接收autofac将数据仓储层的具体实现类的对象注入到此类中
        	public Crane_Alarm_HisServices(ICrane_Alarm_HisRepository dal)
        	{
        		this.dal = dal;
        		base.baseDal = dal;
        	}
         #endregion


        #region 针对此表的特殊操作写在此处
        
        #endregion
    }
}
