using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Services;
namespace T4模板程序
{
   ///using Model;
    /// <summary>
    /// 负责每个数据表的数据操作
    /// </summary>
    public  partial class B_DepartmentServices:BaseServices<B_Department>,IB_DepartmentServices
    {
         IB_DepartmentRepository dal;
         #region 定义构造函数，接收autofac将数据仓储层的具体实现类的对象注入到此类中
        	public B_DepartmentServices(IB_DepartmentRepository dal)
        	{
        		this.dal = dal;
        		base.baseDal = dal;
        	}
         #endregion


        #region 针对此表的特殊操作写在此处
        
        #endregion
    }
}
