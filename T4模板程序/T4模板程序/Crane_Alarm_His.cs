using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Model
{

    /// <summary>
    /// Crane_Alarm_His
    /// </summary>
    public partial class Crane_Alarm_His
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 物料编码
        /// </summary>
        public string Crane_Code { get; set; }

        /// <summary>
        /// 指令类型（堆料入库指令、预处理上料指令、理料车间入库指令、划线机上料指令）
        /// </summary>
        public string Order_Id { get; set; }

        /// <summary>
        /// 报警代码
        /// </summary>
        public string Alarm_Code { get; set; }

        /// <summary>
        /// 报警名称
        /// </summary>
        public string Alarm_Name { get; set; }

        /// <summary>
        /// 报警等级
        /// </summary>
        public string Alarm_Level { get; set; }

        /// <summary>
        /// 记录时刻
        /// </summary>
        public DateTime? Rec_Time { get; set; }

        /// <summary>
        /// 控制模式
        /// </summary>
        public string Control_Mode { get; set; }

        /// <summary>
        /// 大车位置
        /// </summary>
        public decimal? Xact { get; set; }

        /// <summary>
        /// 小车位置
        /// </summary>
        public decimal? Yact { get; set; }

        /// <summary>
        /// 电磁吊高度
        /// </summary>
        public decimal? Zact { get; set; }

        /// <summary>
        /// 重量
        /// </summary>
        public decimal? Weight { get; set; }

    }
}
