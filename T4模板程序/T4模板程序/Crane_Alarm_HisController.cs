using System.Collections.Generic;
using System.Threading.Tasks;
using IServices;
using Model;
namespace T4模板程序
{

    //[SkipCheckLogin123]
    public class Crane_Alarm_HisController //: Controller
    {

        #region DI

        public Crane_Alarm_HisController(ICrane_Alarm_HisService crane_Alarm_His)
        {
            _crane_Alarm_His = crane_Alarm_His;
        }

        ICrane_Alarm_HisService _crane_Alarm_His { get; }

        #endregion

        #region 获取

        public async Task<PageResult<Crane_Alarm_His>> GetDataList(PageInput<Crane_Alarm_His> input)
        {
            return await _crane_Alarm_His.GetDataListAsync(input);
        }

        public async Task<Crane_Alarm_His> GetTheData(IdInputDTO input)
        {
            return await _crane_Alarm_His.GetTheDataAsync(input.id);
        }

        #endregion

        #region 提交

        public async Task SaveData(Crane_Alarm_His data)
        {
            if (data.Id.IsNullOrEmpty())
            {
                InitEntity(data);

                await _crane_Alarm_His.AddDataAsync(data);
            }
            else
            {
                await _crane_Alarm_His.UpdateDataAsync(data);
            }
        }

        public async Task DeleteData(List<string> ids)
        {
            await _crane_Alarm_His.DeleteDataAsync(ids);
        }

        #endregion


    }
}
