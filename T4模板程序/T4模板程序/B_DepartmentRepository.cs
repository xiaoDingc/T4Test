using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Repository;
namespace T4模板程序
{
   ///using Model;
    /// <summary>
    /// 负责每个数据表的数据操作
    /// </summary>
    public  partial class B_DepartmentRepository:BaseRepository<B_Department>,IB_DepartmentRepository
    {
        #region 针对此表的特殊操作写在此处
        
        #endregion
    }
}
