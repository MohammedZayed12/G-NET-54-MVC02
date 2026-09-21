namespace GymManagment.DataAccess.Entity
{
    public class Plan : BaseEntity
    {
        #region Properties
         public string Name { get; set; }
        public string Description { get; set; }=null!;
        public int DurationDays { get; set; }
        public decimal Price { get; set; }
        public bool IsActive { get; set; }
       
        #endregion
    }
}
