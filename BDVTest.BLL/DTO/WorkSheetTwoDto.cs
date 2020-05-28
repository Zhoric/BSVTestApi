namespace BDVTest.BLL.DTO
{
    public class WorkSheetTwoDto : BaseWorkSheetDto
    {
        public override BaseWorkSheetDto CreateNewWorkSheetDto()
        {
            return new WorkSheetTwoDto();
        }
    }
}